using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : PlayerMove
{


    public Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    protected override void Translation()
    {
        if (cController.isGrounded)
        {
            moveDirection = Vector3.forward;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

        }

        moveDirection.y -= gravity * Time.deltaTime;
        cController.Move(moveDirection * Time.deltaTime);
    }
    protected override void Rotation()
    {
        transform.LookAt(target);
    }
    protected override void Animation()
    {
        if (!target.gameObject.activeInHierarchy)
        {
            anime.SetBool("Walk", false);
        }
        else
        {
            anime.SetBool("Walk", true);
        }
    }
    protected override void Update()
    {

        Animation();
        float dist = Vector3.Distance(transform.position, target.position);
        if (!target.gameObject.activeInHierarchy || dist > 70)
        {

            return;
        }
        Translation();
        Rotation();

    }
}
