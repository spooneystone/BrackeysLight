using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    Animator handAnimator;
    PlayerHitBehaviour hitBehavior;
    LevelManagement lM;

    private void Awake()
    {
        Transform holder = transform.Find("Graphic").transform.Find("OBJholder");
        handAnimator = holder.GetComponent<Animator>();
        hitBehavior = holder.GetComponent<PlayerHitBehaviour>();

        lM = FindObjectOfType<LevelManagement>();
        
    }
   
    void Start () {

        
      
	}
	
	
	void Update () {

        if (Input.GetButtonDown("Fire1") && lM.hasSword)
        {
            Debug.Log("Stike");
            Strike();
        }
		
	}
    void Strike()
    {
        handAnimator.SetTrigger("Strike");
    }
    /// <summary>
    /// These Fuctions are called in the animator
    /// </summary>
    public void StrikeStarted()
    {
        hitBehavior.EnableHitBox();
    }
    public void StrikeFinished()
    {
        hitBehavior.DisableHitBox();
    }
}
