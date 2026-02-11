using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(XRGrabInteractable))]
public class TrackObjectForPitch : MonoBehaviour
{
    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;

    private Vector3 originalPos;

    [SerializeField] private float startPitch = 1f;
    [SerializeField] private AudioClip frogSound;

    private bool isGrabbed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        originalPos = transform.position;

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        audioSource.Play();
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
        audioSource.Stop();

        transform.position = originalPos;
    }

    void Update()
    {
        if (isGrabbed)
        {
            float pitchValue = transform.position.y;
            audioSource.pitch = startPitch + pitchValue;
        }
    }
}
