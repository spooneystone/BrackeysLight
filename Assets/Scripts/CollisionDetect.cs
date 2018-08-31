using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour {

    LevelManagement lM;

    private void Start()
    {
        lM = FindObjectOfType<LevelManagement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torch"))
        {
            //  Debug.Log("Can Light");
            if (lM.hasTorch)
            {
                other.transform.Find("Particle System").gameObject.SetActive(true);
                other.transform.GetComponent<BoxCollider>().enabled = false;
                lM.SetTorch();
                if (EventManager.SoundPlayEvent != null)
                {
                    EventManager.SoundPlayEvent(1);
                }

            }

        }

        PickUpBehavior(other);
        
    }
    void PickUpBehavior(Collider other)
    {
        if (other.CompareTag ("PlayerTorch"))
        {
            // Debug.Log("Can pick Up");

            Transform holder = transform.Find("Graphic").transform.Find("OBJholder");
            if (holder.childCount > 0)
            {
                holder.GetChild(0).SetParent(null);
            }
            other.transform.position = holder.transform.position;
            other.transform.rotation = holder.transform.rotation;
            other.transform.SetParent(holder);
            if (GameObject.Find("WorldCanvas").transform.Find("PickUpText"))
            {
                
                    GameObject.Find("WorldCanvas").transform.Find("PickUpText").gameObject.SetActive(false);
                
                
            }
            if (EventManager.SoundPlayEvent != null)
            {
                EventManager.SoundPlayEvent(0);
            }
            lM.HasTorch(true);
            
            lM.HasSword(false);

        }
        if (other.CompareTag("Sword"))
        {

            
            Transform holder = transform.Find("Graphic").transform.Find("OBJholder");
            if(holder.childCount > 0)
            {
                holder.GetChild(0).SetParent(null);
            }
            other.transform.position = holder.transform.position;
            other.transform.rotation = holder.transform.rotation;
            other.transform.SetParent(holder);
            if (GameObject.Find("WorldCanvas").transform.Find("PickUpText1"))
            {
                GameObject.Find("WorldCanvas").transform.Find("PickUpText1").gameObject.SetActive(false);
            }
            if(EventManager.collectedSwordEvent != null)
            {
                EventManager.collectedSwordEvent();
            }
            if (EventManager.SoundPlayEvent != null)
            {
                EventManager.SoundPlayEvent(0);
            }
            lM.HasSword(true);
            
            lM.HasTorch(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
      
       
    }
}
