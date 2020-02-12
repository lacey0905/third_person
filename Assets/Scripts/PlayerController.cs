using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rigidbody;
    Animator anim;

    public GameObject model;

    private Vector3 movement;

    public float fSpeed;
    public float fRotSpeed;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = model.GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        movement.Set(h, 0, v);
        movement = movement.normalized * fSpeed * Time.deltaTime;

        rigidbody.MovePosition(transform.position + movement);


        if(h == 0 && v == 0)
        {
            anim.SetBool("Run", false);
        }
        else
        {

            anim.SetBool("Run", true);

            Quaternion newRot = Quaternion.LookRotation(movement);
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newRot, fRotSpeed * Time.deltaTime);
        }

    }


}
