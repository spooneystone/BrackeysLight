using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    BoxCollider bCollider;

    private void Awake()
    {
        bCollider = GetComponent<BoxCollider>();
    }
    private void Start()
    {
        bCollider.isTrigger = true;
        bCollider.enabled = false;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(bCollider.enabled)
        {
            Debug.Log("Progress to next level");
            if(EventManager.LevelEnded != null)
            {
                EventManager.LevelEnded();
            }
        }
    }
    public void OpenDoor()
    {
        GetComponent<Animator>().SetTrigger("Open");
       if(EventManager.SoundForDoorPlayEvent != null)
        {
            EventManager.SoundForDoorPlayEvent(2);
        }
        bCollider.enabled = true;
    }
    
}
