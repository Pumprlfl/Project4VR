using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MoveOnHover : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Vector3 originalPos;

    public Vector3 hoverOffset = new Vector3(0, 0.1f, 0);

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        originalPos = transform.position;

        grabInteractable.hoverEntered.AddListener(OnHoverEnter);
        grabInteractable.hoverExited.AddListener(OnHoverExit);
    }

    void OnHoverEnter(HoverEnterEventArgs args)
    {
        transform.position = originalPos + hoverOffset;
    }

    void OnHoverExit(HoverExitEventArgs args)
    {
        transform.position = originalPos;
    }
}