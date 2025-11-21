using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

public class controllerInputBoard : MonoBehaviour
{
    // create more fields for the touch sensors on the controllers

    [Header("Buttons")]

    [SerializeField]
    Vector2 m_ButtonPressDistance = new Vector2(0f, -0.025f);
    [SerializeField]
    Transform m_RightPrimaryButtonTr;
    [SerializeField]
    Transform m_RightSecondaryButtonTr;
    [SerializeField]
    Transform m_LeftPrimaryButtonTr;
    [SerializeField]
    Transform m_LeftSecondaryButtonTr;

    [SerializeField]
    Material m_ButtonEnabledMaterial;
    [SerializeField]
    Material m_ButtonDisabledMaterial;

    [SerializeField]
    XRInputValueReader<float> m_RightPrimaryBPress = new XRInputValueReader<float>("Button Press");
    [SerializeField]
    XRInputValueReader<float> m_LeftPrimaryBPress = new XRInputValueReader<float>("Button Press");
    [SerializeField]
    XRInputValueReader<float> m_RightSecondaryBPress = new XRInputValueReader<float>("Button Press");
    [SerializeField]
    XRInputValueReader<float> m_LeftSecondaryBPress = new XRInputValueReader<float>("Button Press");

    [SerializeField]
    XRInputValueReader<float> m_RightPrimaryBTouch = new XRInputValueReader<float>("Button Touch");
    [SerializeField]
    XRInputValueReader<float> m_LeftPrimaryBTouch = new XRInputValueReader<float>("Button Touch");
    [SerializeField]
    XRInputValueReader<float> m_RightSecondaryBTouch = new XRInputValueReader<float>("Button Touch");
    [SerializeField]
    XRInputValueReader<float> m_LeftSecondaryBTouch = new XRInputValueReader<float>("Button Touch");

    [Header("Thumbstick")]
    [SerializeField]
    Transform m_RThumbstickTransform;
    [SerializeField]
    Transform m_LThumbstickTransform;
    [SerializeField]
    Transform m_RThumbstickRing;
    [SerializeField]
    Transform m_LThumbstickRing;

    [SerializeField]
    Material m_ThumbTouchActive;
    [SerializeField]
    Material m_ThumbTouchInactive;

    [SerializeField]
    Vector2 m_StickRotationRange = new Vector2(0.2f, 0.2f);

    [SerializeField]
    XRInputValueReader<Vector2> m_RightStickInput = new XRInputValueReader<Vector2>("Thumbstick");
    [SerializeField]
    XRInputValueReader<Vector2> m_LeftStickInput = new XRInputValueReader<Vector2>("Thumbstick");
    [SerializeField]
    XRInputValueReader<float> m_RightStickTouch = new XRInputValueReader<float>("Thumbstick Touch");
    [SerializeField]
    XRInputValueReader<float> m_LeftStickTouch = new XRInputValueReader<float>("Thumbstick Touch");
    [SerializeField]
    XRInputValueReader<float> m_RightStickClick = new XRInputValueReader<float>("Thumbstick Click");
    [SerializeField]
    XRInputValueReader<float> m_LeftStickClick = new XRInputValueReader<float>("Thumbstick Click");

    [Header("Trigger")]
    [SerializeField]
    Transform m_RTriggerTransform;
    [SerializeField]
    Transform m_LTriggerTransform;

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
    Material m_gripDisableMaterial;
    [SerializeField]
    Material m_gripEnableMaterial;

    [SerializeField]
    XRInputValueReader<float> m_RightGripInput = new XRInputValueReader<float>("Grip");
    [SerializeField]
    XRInputValueReader<float> m_LeftGripInput = new XRInputValueReader<float>("Grip");


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (m_RThumbstickTransform == null || m_RGripTransform == null || m_RTriggerTransform == null || m_LThumbstickTransform == null || m_LGripTransform == null || m_LTriggerTransform == null 
            || m_RightPrimaryButtonTr == null|| m_LeftPrimaryButtonTr == null || m_RightSecondaryButtonTr == null || m_LeftSecondaryButtonTr == null || m_RThumbstickRing == null || m_LThumbstickRing == null)
        {
            enabled = false;
            Debug.LogWarning($"Controller Animator component missing references on {gameObject.name}", this);
            return;
        }

        //stick, grip, trigger
        m_RightStickInput?.EnableDirectActionIfModeUsed();
        m_RightTriggerInput?.EnableDirectActionIfModeUsed();
        m_RightGripInput?.EnableDirectActionIfModeUsed();
        m_LeftStickInput?.EnableDirectActionIfModeUsed();
        m_LeftTriggerInput?.EnableDirectActionIfModeUsed();
        m_LeftGripInput?.EnableDirectActionIfModeUsed();

        //buttons
        m_RightSecondaryBPress?.EnableDirectActionIfModeUsed();
        m_LeftSecondaryBPress?.EnableDirectActionIfModeUsed();
        m_RightPrimaryBPress?.EnableDirectActionIfModeUsed();
        m_LeftPrimaryBPress?.EnableDirectActionIfModeUsed();
        m_RightSecondaryBTouch?.EnableDirectActionIfModeUsed();
        m_LeftSecondaryBTouch?.EnableDirectActionIfModeUsed();
        m_RightPrimaryBTouch?.EnableDirectActionIfModeUsed();
        m_LeftPrimaryBTouch?.EnableDirectActionIfModeUsed();

        //thumb touch and click
        m_RightStickTouch?.EnableDirectActionIfModeUsed();
        m_LeftStickTouch?.EnableDirectActionIfModeUsed();
        m_RightStickClick?.EnableDirectActionIfModeUsed();
        m_LeftStickClick?.EnableDirectActionIfModeUsed();
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

        //buttons
        m_RightSecondaryBPress?.DisableDirectActionIfModeUsed();
        m_LeftSecondaryBPress?.DisableDirectActionIfModeUsed();
        m_RightPrimaryBPress?.DisableDirectActionIfModeUsed();
        m_LeftPrimaryBPress?.DisableDirectActionIfModeUsed();
        m_RightSecondaryBTouch?.DisableDirectActionIfModeUsed();
        m_LeftSecondaryBTouch?.DisableDirectActionIfModeUsed();
        m_RightPrimaryBTouch?.DisableDirectActionIfModeUsed();
        m_LeftPrimaryBTouch?.DisableDirectActionIfModeUsed();

        //thumb touch and click
        m_RightStickTouch?.DisableDirectActionIfModeUsed();
        m_LeftStickTouch?.DisableDirectActionIfModeUsed();
        m_RightStickClick?.DisableDirectActionIfModeUsed();
        m_LeftStickClick?.DisableDirectActionIfModeUsed();
    }
    private void Update()
    {
        if (m_RightPrimaryBPress != null)
        {
            var rPButtonVal = m_RightPrimaryBPress.ReadValue();
            var rPButtonCurP = m_RightPrimaryButtonTr.localPosition;
            m_RightPrimaryButtonTr.localPosition = new Vector3(rPButtonCurP.x, m_ButtonPressDistance.y+(m_ButtonPressDistance.y-m_ButtonPressDistance.x)*rPButtonVal,rPButtonCurP.z);
        }

        if (m_RightSecondaryBPress != null)
        {
            var rSButtonVal = m_RightSecondaryBPress.ReadValue();
            var rSButtonCurP = m_RightSecondaryButtonTr.localPosition;
            m_RightSecondaryButtonTr.localPosition = new Vector3(rSButtonCurP.x, m_ButtonPressDistance.y + (m_ButtonPressDistance.y - m_ButtonPressDistance.x) * rSButtonVal, rSButtonCurP.z);
        }

        if (m_LeftPrimaryBPress != null)
        { 
            var lPButtonVal = m_LeftPrimaryBPress.ReadValue();
            var lPButtonCurP = m_LeftPrimaryButtonTr.localPosition;
            m_LeftPrimaryButtonTr.localPosition = new Vector3(lPButtonCurP.x, m_ButtonPressDistance.y + (m_ButtonPressDistance.y-m_ButtonPressDistance.x)*lPButtonVal, lPButtonCurP.z);
        }

        if (m_LeftSecondaryBPress != null)
        {
            var lSButtonVal = m_LeftSecondaryBPress.ReadValue();
            var lSButtonCurP = m_LeftSecondaryButtonTr.localPosition;
            m_LeftSecondaryButtonTr.localPosition = new Vector3(lSButtonCurP.x, m_ButtonPressDistance.y + (m_ButtonPressDistance.y - m_ButtonPressDistance.x) * lSButtonVal, lSButtonCurP.z);
        }

        if (m_RightPrimaryBTouch != null)
        {
            var touchVal = m_RightPrimaryBTouch.ReadValue();
            if (touchVal != 0)
            {
                m_RightPrimaryButtonTr.GetComponent<Renderer>().material = m_ButtonEnabledMaterial;
            }
            else 
            {
                m_RightPrimaryButtonTr.GetComponent<Renderer>().material = m_ButtonDisabledMaterial;
            }
        }

        if (m_RightSecondaryBTouch != null)
        {
            var touchVal = m_RightSecondaryBTouch.ReadValue();
            if (touchVal != 0)
            {
                m_RightSecondaryButtonTr.GetComponent<Renderer>().material = m_ButtonEnabledMaterial;
            }
            else
            {
                m_RightSecondaryButtonTr.GetComponent<Renderer>().material = m_ButtonDisabledMaterial;
            }
        }

        if (m_LeftPrimaryBTouch != null)
        {
            var touchVal = m_LeftPrimaryBTouch.ReadValue();
            if (touchVal != 0)
            {
                m_LeftPrimaryButtonTr.GetComponent<Renderer>().material = m_ButtonEnabledMaterial;
            }
            else
            {
                m_LeftPrimaryButtonTr.GetComponent<Renderer>().material = m_ButtonDisabledMaterial;
            }
        }

        if (m_LeftSecondaryBTouch != null)
        {
            var touchVal = m_LeftSecondaryBTouch.ReadValue();
            if (touchVal != 0)
            {
                m_LeftSecondaryButtonTr.GetComponent<Renderer>().material = m_ButtonEnabledMaterial;
            }
            else
            {
                m_LeftSecondaryButtonTr.GetComponent<Renderer>().material = m_ButtonDisabledMaterial;
            }
        }

        if (m_RightStickTouch != null)
        {
            var touchVal = m_RightStickTouch.ReadValue();
            if (touchVal != 0)
            {
                m_RThumbstickRing.GetComponent<Renderer>().material = m_ThumbTouchActive;
            }
            else
            {
                m_RThumbstickRing.GetComponent<Renderer>().material = m_ThumbTouchInactive;
            }
        }
        if (m_LeftStickTouch != null)
        {
            var touchVal = m_LeftStickTouch.ReadValue();
            if (touchVal != 0)
            {
                m_LThumbstickRing.GetComponent<Renderer>().material = m_ThumbTouchActive;
            }
            else
            {
                m_LThumbstickRing.GetComponent<Renderer>().material = m_ThumbTouchInactive;
            }
        }

        if (m_RightStickInput != null)
        {
            var rStickVal = m_RightStickInput.ReadValue();
            m_RThumbstickTransform.localPosition = new Vector3(rStickVal.x * m_StickRotationRange.x * -1, m_StickRotationRange.y * rStickVal.y, 0f);
            // move circle around on the Y and (x?) axis within limits based on local space
            // also change colour
        }

        if (m_LeftStickInput != null)
        {
            var lStickVal = m_LeftStickInput.ReadValue();
            m_LThumbstickTransform.localPosition = new Vector3(lStickVal.x*m_StickRotationRange.x*-1,m_StickRotationRange.y* lStickVal.y,0f);
        }
        if (m_RightGripInput != null)
        {
            var rGripVal = m_RightGripInput.ReadValue();
            m_RGripTransform.localScale = new Vector3(1, 1 - (rGripVal*0.95f), 1);
            if (rGripVal != 0.0)
            {
                m_RGripTransform.GetComponent<Renderer>().material = m_gripEnableMaterial;
            }
            else
            {
                m_RGripTransform.GetComponent<Renderer>().material = m_gripDisableMaterial;
            }
        }

        if (m_LeftGripInput != null)
        {
            var lGripVal = m_LeftGripInput.ReadValue();
            m_LGripTransform.localScale = new Vector3(1, 1 - (lGripVal * 0.95f), 1);
            if (lGripVal != 0.0)
            {
                m_LGripTransform.GetComponent<Renderer>().material = m_gripEnableMaterial;
            }
            else
            {
                m_LGripTransform.GetComponent<Renderer>().material = m_gripDisableMaterial;
            }
        }
        if (m_RightTriggerInput != null)
        {
            var rTriggerVal = m_RightTriggerInput.ReadValue();
            m_RTriggerTransform.localScale = new Vector3(1, 1 - (rTriggerVal * 0.95f), 1);
            if (rTriggerVal != 0.0)
            {
                m_RTriggerTransform.GetComponent<Renderer>().material = m_gripEnableMaterial;
            }
            else
            {
                m_RTriggerTransform.GetComponent<Renderer>().material = m_gripDisableMaterial;
            }
        }

        if (m_LeftTriggerInput != null) 
        { 
            var lTriggerVal = m_LeftTriggerInput.ReadValue();
            m_LTriggerTransform.localScale = new Vector3(1, 1 - (lTriggerVal * 0.95f), 1);
            if (lTriggerVal != 0.0)
            {
                m_LTriggerTransform.GetComponent<Renderer>().material = m_gripEnableMaterial;
            }
            else
            {
                m_LTriggerTransform.GetComponent<Renderer>().material = m_gripDisableMaterial;
            }
        }

    }
}
