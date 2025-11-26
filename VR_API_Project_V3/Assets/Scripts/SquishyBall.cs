using Mono.Cecil;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class SquishyBall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string handedness = "Right";
    [SerializeField]
    float squeezeAmount = 0.5f;
    [SerializeField]
    XRInputValueReader<float> m_RightTriggerInput = new XRInputValueReader<float>("Trigger");
    [SerializeField]
    XRInputValueReader<float> m_LeftTriggerInput = new XRInputValueReader<float>("Trigger");
    [SerializeField]
    GameObject m_rController;
    [SerializeField]
    GameObject m_lController;
    [SerializeField]
    Transform m_rightEyeTransform;
    [SerializeField]
    Transform m_leftEyeTransform;
    AudioSource audioSource;
    [SerializeField]
    AudioClip squeakInAudio;
    [SerializeField]
    AudioClip squeakOutAudio;
    Vector3 scaler = Vector3.one;
    float eyeScaler = 1f;
    //Transform myTransform;
    //XRGeneralGrabTransformer grabTransformer;
    void Start()
    {
        // grabTransformer = GetComponent<XRGeneralGrabTransformer>();
        audioSource = GetComponent<AudioSource>();
        
        enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
        float triggerVal = 0;
        switch (handedness)
        {
            case "Right":
                triggerVal = m_RightTriggerInput.ReadValue();
                break;
            case "Left":
                triggerVal = m_LeftTriggerInput.ReadValue();
                break;
        }
        Debug.Log(triggerVal);
        
        transform.localScale = scaler;
        if (scaler.y > triggerVal & audioSource.resource != squeakOutAudio)
        {
            audioSource.Stop();
            audioSource.resource = squeakOutAudio;
            audioSource.Play();
        }
        if (scaler.y < triggerVal & audioSource.resource != squeakInAudio)
        {
            audioSource.Stop();
            audioSource.resource = squeakInAudio;
            audioSource.Play();
        }
        if (eyeScaler == 1 + (triggerVal * squeezeAmount))
        {
            audioSource.Stop();
        }
        m_rightEyeTransform.localScale = new Vector3(eyeScaler, eyeScaler, eyeScaler / scaler.y);
        m_leftEyeTransform.localScale = new Vector3(eyeScaler, eyeScaler, eyeScaler / scaler.y);
        scaler.y = Mathf.Lerp(scaler.y, 1-(triggerVal*squeezeAmount),.1f);
        eyeScaler = Mathf.Lerp(eyeScaler, 1 + (triggerVal * squeezeAmount), 0.1f);
       


    }
    private void OnDisable()
    {
        transform.localScale = new Vector3(1, 1, 1);
        m_rightEyeTransform.localScale = new Vector3(1,1,1);
        m_leftEyeTransform.localScale = new Vector3(1,1,1);
        scaler = Vector3.one;
        m_lController.SetActive(true);
        m_rController.SetActive(true);
        audioSource.Stop();
    }

    public void Squeeze(SelectEnterEventArgs Args)
    {
        Debug.Log(Args.interactorObject.handedness);
        if (Args.interactorObject.handedness == InteractorHandedness.Right)
        {
            handedness = "Right";
            m_rController.SetActive(false);
        }
        else 
        {
            handedness = "Left";
            m_lController.SetActive(false);
        }

        
        
        enabled = true;
    }

    public void Unsqueeze(SelectExitEventArgs Args)
    {
        enabled = false;
    }
}
