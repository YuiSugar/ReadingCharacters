using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadingScript : MonoBehaviour
{
    // ancient monument is hitted by avatar
    bool isHitAvatar = false;
    // avatar object
    GameObject monument;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && monument != null)
        {
            AudioSource audioSource = monument.GetComponentInChildren<AudioSource>();
            audioSource.volume = 1.0F;
            audioSource.Play(0);
            monument = null;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("Hit");
        GameObject hittedObject = collision.gameObject;
        string hittedObjectName = hittedObject.name;
        UnityEngine.Debug.Log("Hit at: " + hittedObjectName);
        if (hittedObjectName.Equals("Behistun_relief") ||
            hittedObjectName.Equals("Rosetta_Stone")) 
        { 
            isHitAvatar = true;
            monument = hittedObject;
        } 
        else 
        {
            isHitAvatar = false;
            monument = null;
        }
    }
}
