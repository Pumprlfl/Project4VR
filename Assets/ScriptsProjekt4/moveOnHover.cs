using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;

[RequireComponent(typeof(XRGrabInteractable))]
public class MoveOnHover : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private Vector3 hoverStartPos;
    private Coroutine moveRoutine;

    public Vector3 hoverOffset = new Vector3(0, 0.1f, 0);
    public float moveDuration = 0.15f;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.hoverEntered.AddListener(OnHoverEnter);
        grabInteractable.hoverExited.AddListener(OnHoverExit);
    }

    void OnHoverEnter(HoverEnterEventArgs args)
    {
        hoverStartPos = transform.position;
        StartSmoothMove(hoverStartPos + hoverOffset);
    }

    void OnHoverExit(HoverExitEventArgs args)
    {
        StartSmoothMove(hoverStartPos);
    }

    void StartSmoothMove(Vector3 target)
    {
        if (moveRoutine != null)
            StopCoroutine(moveRoutine);

        moveRoutine = StartCoroutine(SmoothMove(target));
    }

    IEnumerator SmoothMove(Vector3 target)
    {
        Vector3 start = transform.position;
        float time = 0f;

        while (time < moveDuration)
        {
            transform.position = Vector3.Lerp(start, target, time / moveDuration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }

    void OnDestroy()
    {
        grabInteractable.hoverEntered.RemoveListener(OnHoverEnter);
        grabInteractable.hoverExited.RemoveListener(OnHoverExit);
    }
}