using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    Animator handAnimator;
    PlayerHitBehaviour hitBehavior;
    float cooldowntimer = 1;



    private void Awake()
    {
        Transform holder = transform.Find("Graphic").transform.Find("OBJholder");
        handAnimator = holder.GetComponent<Animator>();
        hitBehavior = holder.GetComponent<PlayerHitBehaviour>();

    }

    void Start()
    {



    }


    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        cooldowntimer += Time.deltaTime;
        if (cooldowntimer >= 1)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
            {

                if (hit.collider.CompareTag("Player"))
                {
                    cooldowntimer = 0;
                    Debug.Log("See player");
                    Strike();
                }
            }
        }

        // {
        //      Debug.Log("Stike");
        //    
        //}

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
