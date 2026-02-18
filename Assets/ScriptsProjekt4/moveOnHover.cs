using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class moveOnHover : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private Vector3 originalPos;


    private bool isGrabbed = false;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        originalPos = transform.position;

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;

        transform.position = originalPos;
    }

    void Update()
    {

    }
}
