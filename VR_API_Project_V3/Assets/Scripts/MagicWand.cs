using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagicWand : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    float vibrationForce = 0.1f;
    [SerializeField]
    float vibrationSpeed = 1.0f;
    [SerializeField]
    AudioSource audioSource;
    ConstantHapticPlayer hapticPlayer;

    Quaternion visualRotation;
    Quaternion initialRotation;
    void Start()
    {
        hapticPlayer = GetComponent<ConstantHapticPlayer>();
        audioSource = GetComponent<AudioSource>();
        enabled = false;
        /*
        visualRotation = wandVisualTransform.rotation;
        initialRotation = wandVisualTransform.rotation;
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Quaternion vGoal = Quaternion.Euler(Random.Range(-vibrationForce, vibrationForce),Random.Range(-vibrationForce,vibrationForce),Random.Range(-vibrationForce,vibrationForce));
        visualRotation.x = Mathf.Lerp(visualRotation.x, vGoal.x, vibrationSpeed);
        visualRotation.y = Mathf.Lerp(visualRotation.y, vGoal.y, vibrationForce);
        visualRotation.z = Mathf.Lerp(visualRotation.z, vGoal.z, vibrationSpeed);
        wandVisualTransform.Rotate(visualRotation.eulerAngles);
        */
    }

    public void grab(SelectEnterEventArgs Args)
    {
        audioSource.Play();
        hapticPlayer.startVibrations(Args.interactorObject.handedness);
        //enabled = true;
    }

    public void unGrab(SelectExitEventArgs Args) 
    {
        /*
        wandVisualTransform.Rotate(initialRotation.eulerAngles);
        visualRotation = wandVisualTransform.rotation;
        */
        audioSource.Stop();
        hapticPlayer.stopVibrations();
        //enabled = false;
    }
}
