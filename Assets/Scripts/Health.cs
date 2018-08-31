using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    int health = 100;



    public void TakeHealth(int _value)
    {
        health -= _value;
        if(health <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        if( gameObject.GetComponentInChildren<Camera>())
        {
           // gameObject.GetComponentInChildren<Camera>().transform.SetParent(null);
        }
        if(EventManager.PlayerDead != null && this.gameObject.CompareTag("Player"))
        {
            EventManager.PlayerDead();
        }
        gameObject.SetActive(false);

        health = 100;
    }
}
