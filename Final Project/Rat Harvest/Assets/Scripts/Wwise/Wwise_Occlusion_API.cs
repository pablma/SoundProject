using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wwise_Occlusion_API : MonoBehaviour
{
    [SerializeField] private GameObject audioListener;
    private string nameOfListener;

    // Start is called before the first frame update
    void Start()
    {
        nameOfListener = audioListener.name;
        AkSoundEngine.RegisterGameObj(gameObject);
        AkSoundEngine.RegisterGameObj(audioListener);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = audioListener.transform.position - gameObject.transform.position;
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(gameObject.transform.position, dir, out hitInfo);

        if (hit)
        {
            if (hitInfo.collider.gameObject.name != nameOfListener)
            {
                AkSoundEngine.SetObjectObstructionAndOcclusion(gameObject, audioListener.gameObject, 0.0f, 0.5f);
                Debug.Log("Doing occlusion");
            }
            else
            {
                AkSoundEngine.SetObjectObstructionAndOcclusion(gameObject, audioListener.gameObject, 0.0f, 0.0f);
            }
        }
    }
}
