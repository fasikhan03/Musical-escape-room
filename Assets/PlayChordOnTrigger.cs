using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayChordOnTrigger : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource source;
    public string targetTag;
   
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag(targetTag)){
            source.PlayOneShot(clip);
        }
    }
}
