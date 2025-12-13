using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PullInteraction : XRBaseInteractable
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] Transform start, end;
    [SerializeField] GameObject notch;
    [SerializeField] float pullAmount { get; set; } = 0.0f;

    public static event Action<float> PullActionReleased;
    private LineRenderer lineRenderer;
    private IXRSelectInteractor pullingInteractor = null;

    protected override void Awake()
    {
        base.Awake();
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void setInteractor(SelectEnterEventArgs args)
    {
        pullingInteractor = args.interactorObject;
    }

    public void releaseString()
    {
        PullActionReleased?.Invoke(pullAmount);
        pullingInteractor = null;
        pullAmount = 0.0f;
        notch.transform.localPosition = new Vector3(notch.transform.localPosition.x, notch.transform.localPosition.y, 0f);
        UpdateString();

    }
    private float CalculatePull(Vector3 pullPosition)
    {
        Vector3 pullDirection = pullPosition-start.position;
        Vector3 targetDirection = end.position - start.position;
        float maxLength = targetDirection.magnitude;
        targetDirection.Normalize();

        float pullValue = Vector3.Dot(pullDirection, targetDirection)/maxLength;
        return Mathf.Clamp(pullValue, 0, 1);
    }

    private void UpdateString()
    {
        Vector3 linePosition = Vector3.forward * Mathf.Lerp(start.transform.localPosition.z, end.transform.localPosition.z, pullAmount);
        notch.transform.localPosition = new Vector3(notch.transform.localPosition.x, notch.transform.localPosition.y, linePosition.z);
        lineRenderer.SetPosition(1, linePosition);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if (isSelected)
            {
                Vector3 pullingPosition = pullingInteractor.transform.position;
                pullAmount = CalculatePull(pullingPosition);

                UpdateString();
                
            }

        }
    }


}
