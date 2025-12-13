using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ArrowSpawner : MonoBehaviour
{

    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject notch;

    private XRGrabInteractable bow;
    private bool arrowNotched = false;
    private GameObject currentArrow;
    void Start()
    {
        bow = GetComponentInParent<XRGrabInteractable>();
        PullInteraction.PullActionReleased += NotchEmpty;
    }

    private void OnDestroy()
    {
        PullInteraction.PullActionReleased -= NotchEmpty;
    }

    // Update is called once per frame
    void Update()
    {
        if (bow.isSelected && !arrowNotched)
        {
            arrowNotched = true;
            Invoke("Spawn", 1);
        }
        if (!bow.isSelected)
        {
            Destroy(currentArrow);
        }
        
    }

    private void NotchEmpty(float args)
    {
        arrowNotched = false;
    }

    private void Spawn()
    {
        currentArrow = Instantiate(arrow, notch.transform);
    }
}
