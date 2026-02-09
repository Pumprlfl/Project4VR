using UnityEngine;

public class ResetObjectPosition : MonoBehaviour
{
    Vector3 originalpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalpos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            gameObject.transform.position = originalpos;        
        }
    }
}
