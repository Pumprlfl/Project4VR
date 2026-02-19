using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class MoveOnHover : MonoBehaviour
{
    public float yMultiplier = 3f;   // How much stronger the movement is

    private XRGrabInteractable grabInteractable;

    private Vector3 originalLocalPos;
    private float parentStartY;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        originalLocalPos = transform.localPosition;
        parentStartY = transform.parent.position.y;
    }

    void Update()
    {
        if (transform.parent == null) return;

        float parentOffsetY = transform.parent.position.y - parentStartY;

        Vector3 newLocalPos = originalLocalPos;
        newLocalPos.y += parentOffsetY * yMultiplier;

        transform.localPosition = newLocalPos;
    }
}