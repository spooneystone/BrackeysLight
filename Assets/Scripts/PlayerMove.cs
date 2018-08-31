using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    protected CharacterController cController;
    protected Animator anime;
    Transform Graphic;
    protected Vector3 moveDirection = Vector3.zero;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    void Awake()
    {
        anime = GetComponent<Animator>();
        cController = GetComponent<CharacterController>();
        Graphic = transform.Find("Graphic");
    }
   
    protected virtual void Translation()
    {



        if (cController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            
        }

        moveDirection.y -= gravity * Time.deltaTime;
        cController.Move(moveDirection * Time.deltaTime);
    }
    protected virtual void Rotation()
    {
        Vector3 facingrotation = Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));
        if (facingrotation != Vector3.zero)         //This condition prevents from spamming "Look rotation viewing vector is zero" when not moving.
            Graphic.forward = -facingrotation;

    }
    protected virtual void Animation()
    {

        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            anime.SetBool("Walk", true);
        }
        else
        {
            anime.SetBool("Walk", false);
        }
        if (!cController.isGrounded)
        {
            anime.SetBool("Walk", false);
        }

    }
    // Update is called once per frame
    protected virtual void Update()
    {

        Translation();
        Rotation();
        Animation();



    }
}
