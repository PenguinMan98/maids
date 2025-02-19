using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    // Editor vars
    [SerializeField] AudioClip loadingSound; 
    
    // cached references
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.PlayOneShot(loadingSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
