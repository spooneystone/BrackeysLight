using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBehaviour : MonoBehaviour {

    BoxCollider hitBox;

    private void Awake()
    {
        hitBox = GetComponent<BoxCollider>();
    }
    // Use this for initialization
    void Start () {

        hitBox.enabled = false;
	}
	
    public void EnableHitBox()
    {
        hitBox.enabled = true;
    }
    public void DisableHitBox()
    {
        hitBox.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().TakeHealth(35);
        }
    }
}
