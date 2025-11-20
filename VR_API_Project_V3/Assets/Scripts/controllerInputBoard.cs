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
    [Header("Trigger")]
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
        
    }

    // Update is called once per frame
    void OnDisable()
    {
       
    }
    private void Update()
    {
        
    }
}
