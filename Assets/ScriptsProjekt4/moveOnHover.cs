using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class moveOnHover : MonoBehaviour
{
    public Transform childToAmplify;
    public float yMultiplier = 3f;

    private XRGrabInteractable grabInteractable;

    private Vector3 parentOriginalPos;
    private Vector3 childOriginalLocalPos;

    private float parentStartY;
    private bool isGrabbed;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        parentOriginalPos = transform.position;

        if (childToAmplify != null)
            childOriginalLocalPos = childToAmplify.localPosition;

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        parentStartY = transform.position.y;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;

        //Instantly snap parent back
        transform.position = parentOriginalPos;

        // Reset child as well (optional but recommended)
        if (childToAmplify != null)
            childToAmplify.localPosition = childOriginalLocalPos;
    }

    void Update()
    {
        if (!isGrabbed || childToAmplify == null) return;

        float parentOffsetY = transform.position.y - parentStartY;

        Vector3 newLocalPos = childOriginalLocalPos;
        newLocalPos.y += parentOffsetY * yMultiplier;

        childToAmplify.localPosition = newLocalPos;
    }
}
