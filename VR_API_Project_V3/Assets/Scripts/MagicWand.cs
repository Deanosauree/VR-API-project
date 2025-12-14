using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagicWand : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    AudioSource audioSource;
    ConstantHapticPlayer hapticPlayer;
    GameObject currentController;

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
        if (Args.interactorObject.transform.parent != null)
        {
            currentController = getControllerObject(Args.interactorObject.transform.parent);
            if (currentController != null)
            {
                audioSource.Play();
                hapticPlayer.startVibrations(Args.interactorObject.handedness);
                currentController.SetActive(false);
            }
        }
        
    }

    public void unGrab(SelectExitEventArgs Args) 
    {
        if (currentController != null)
        {
            audioSource.Stop();
            hapticPlayer.stopVibrations();
            currentController?.SetActive(true);
            currentController = null;
        }
    }
    private GameObject getControllerObject(Transform parent)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.tag == "GameController")
            {
                return child.gameObject;
            }
        }
        return null;
    }
}
