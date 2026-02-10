using Oculus.Interaction;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

//maybe try including the ResetObjectPosition here instead of another script
public class TrackobjectForPitch : MonoBehaviour
{
    AudioSource  audiosource;
    [SerializeField] int startpitch;
    [SerializeField] AudioClip audioResource;
    Vector3 originalpos;
    private float pitchValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.pitch = startpitch;
        originalpos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            audiosource.PlayOneShot(audioResource);

            pitchValue = gameObject.transform.position.y;
            print(pitchValue);
            audiosource.pitch = startpitch + pitchValue;
        

    }
}
