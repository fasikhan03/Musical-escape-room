using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallPressed : MonoBehaviour
{
    public GameObject redCube;
    public UnityEvent onPress;
    public UnityEvent onRelease;

    bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(!isPressed){
            isPressed = true;
           // AudioManager.instance.Play("RedCube");
        }
    }

        public void OnTriggerExit(Collider other)
    {
        if(isPressed){
            isPressed = false;
        }
    }
}
