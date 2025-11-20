using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

public class controllerInputBoard : MonoBehaviour
{
    [Header("Thumbstick")]
    [SerializeField]
    Transform m_RThumbstickTransform;
    [SerializeField]
    Transform m_LThumbstickTransform;

    [SerializeField]
    Vector2 m_StickRotationRange = new Vector2(30f, 30f);

    [SerializeField]
    XRInputValueReader<Vector2> m_RightStickInput = new XRInputValueReader<Vector2>("Thumbstick");
    [SerializeField]
    XRInputValueReader<Vector2> m_LeftStickInput = new XRInputValueReader<Vector2>("Thumbstick");

    [Header("Trigger")]
    [SerializeField]
    Transform m_RTriggerTransform;
    [SerializeField]
    Transform m_LTriggerTransform;

    [SerializeField]
    Vector2 m_TriggerXAxisRotationRange = new Vector2(0f, -15f);

    [SerializeField]
    XRInputValueReader<float> m_RightTriggerInput = new XRInputValueReader<float>("Trigger");
    [SerializeField]
    XRInputValueReader<float> m_LeftTriggerInput = new XRInputValueReader<float>("Trigger");

    [Header("Grip")]
    [SerializeField]
    Transform m_RGripTransform;
    [SerializeField]
    Transform m_LGripTransform;

    [SerializeField]
    Vector2 m_GripRightRange = new Vector2(-0.0125f, -0.011f);

    [SerializeField]
    XRInputValueReader<float> m_RightGripInput = new XRInputValueReader<float>("Grip");
    [SerializeField]
    XRInputValueReader<float> m_LeftGripInput = new XRInputValueReader<float>("Grip");


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (m_RThumbstickTransform == null || m_RGripTransform == null || m_RTriggerTransform == null || m_LThumbstickTransform == null || m_LGripTransform == null || m_LTriggerTransform == null)
        {
            enabled = false;
            Debug.LogWarning($"Controller Animator component missing references on {gameObject.name}", this);
            return;
        }

        m_RightStickInput?.EnableDirectActionIfModeUsed();
        m_RightTriggerInput?.EnableDirectActionIfModeUsed();
        m_RightGripInput?.EnableDirectActionIfModeUsed();
        m_LeftStickInput?.EnableDirectActionIfModeUsed();
        m_LeftTriggerInput?.EnableDirectActionIfModeUsed();
        m_LeftGripInput?.EnableDirectActionIfModeUsed();
    }

    // Update is called once per frame
    void OnDisable()
    {
        m_RightStickInput?.DisableDirectActionIfModeUsed();
        m_RightTriggerInput?.DisableDirectActionIfModeUsed();
        m_RightGripInput?.DisableDirectActionIfModeUsed();
        m_LeftStickInput?.DisableDirectActionIfModeUsed();
        m_LeftTriggerInput?.DisableDirectActionIfModeUsed();
        m_LeftGripInput?.DisableDirectActionIfModeUsed();
    }
    private void Update()
    {
        if (m_RightStickInput != null)
        {
            var rStickVal = m_RightStickInput.ReadValue();
        }

        if (m_LeftStickInput != null)
        {
            var lStickVal = m_LeftStickInput.ReadValue();
        }
        if (m_RightGripInput != null)
        {
            var rGripVal = m_RightGripInput.ReadValue();
        }
        
        if (m_LeftGripInput != null)
        {
            var lGripVal = m_LeftGripInput.ReadValue();
        }

        if (m_RightTriggerInput != null) 
        { 
            var rTriggerVal = m_RightTriggerInput.ReadValue();
        }

        if (m_LeftTriggerInput != null) 
        { 
            var lTriggerVal = m_LeftTriggerInput.ReadValue();
        }

    }
}
