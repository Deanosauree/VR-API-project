using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagicWand : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
