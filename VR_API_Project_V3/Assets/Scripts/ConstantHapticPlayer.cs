using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ConstantHapticPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    XRInputHapticImpulseProvider m_rHapticOutput;
    [SerializeField]
    XRInputHapticImpulseProvider m_lHapticOutput;
    [SerializeField, Range(0f, 1f)]
    float m_AmplitudeMultiplier;
    [SerializeField]
    float m_vibrationDuration;
    [SerializeField]
    float m_vibrationFrequency;
    string handedness = "Right";
    IXRHapticImpulseChannel leftChannel;
    IXRHapticImpulseChannel rightChannel;
    void Start()
    {
        enabled = false;
        leftChannel = m_lHapticOutput.GetChannelGroup()?.GetChannel();
        rightChannel = m_rHapticOutput.GetChannelGroup()?.GetChannel();
    }


    public void startVibrations(InteractorHandedness hand)
    {
        if (hand == InteractorHandedness.Right)
        {
            handedness = "Right";
        }
        else 
        {
            handedness = "Left";
        }
        enabled = true;
        InvokeRepeating(nameof(SendHapticImpulse), 0, m_vibrationDuration + m_vibrationFrequency);
    }
    public void stopVibrations() 
    { 
        enabled = false;
        CancelInvoke();
    }


    public bool SendHapticImpulse()
    {
        if (!isActiveAndEnabled)
            return false;
        switch (handedness)
        {
            case "Right":
                return rightChannel?.SendHapticImpulse(m_AmplitudeMultiplier, m_vibrationDuration, m_vibrationFrequency) ?? false;

            case "Left":
                return leftChannel?.SendHapticImpulse(m_AmplitudeMultiplier, m_vibrationDuration, m_vibrationFrequency) ?? false;
            default:
                return false;
        }
       
    }
}
