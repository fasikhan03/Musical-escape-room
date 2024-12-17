using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayChord : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(PlayAudio);
    }

  
    public void PlayAudio(GameObject go)
    {
        Debug.Log("Audio Played");
        AudioManager.instance.Play("RedCube");
    }
}
