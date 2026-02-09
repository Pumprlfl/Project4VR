using UnityEngine;
//maybe try including the ResetObjectPosition here instead of another script
public class TrackobjectForPitch : MonoBehaviour
{
    AudioSource audiosource;
    [SerializeField] int startpitch;
    [SerializeField] AudioClip audioResource;
    private float pitchValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.pitch = startpitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(0))
        {
            audiosource.PlayOneShot(audioResource);

            pitchValue = gameObject.transform.GetChild(0).position.y;
            print(pitchValue);
            audiosource.pitch = startpitch + pitchValue;
        }
    }
}
