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

    public VariableJoystick variableJoystick;

    private void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        //rigidbody.AddForce(direction * fSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        direction = direction * fSpeed * Time.fixedDeltaTime;

        rigidbody.MovePosition(transform.position + direction);

        if(direction.x == 0f && direction.z == 0f)
        {
            anim.SetBool("Run", false);
            CameraConroller.instance.ResetMoving();
        }
        else
        {
            CameraConroller.instance.CameraMoving();
            anim.SetBool("Run", true);
            Quaternion newRot = Quaternion.LookRotation(direction);
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newRot, fRotSpeed * Time.deltaTime);
        }
       

        Collider[] colls = Physics.OverlapSphere(transform.position, radius, 1 << 2);

        ArrayList distanceArr = new ArrayList();

        float distance = 0f;

        for(int i=0; i<colls.Length; i++)
        {
            float newDis = Vector3.Distance(colls[i].transform.position, transform.position);

            if(newDis < distance || distance <= 0f)
            {
                distance = newDis;
                currentTarget = colls[i].gameObject;
                //Debug.Log(currentTarget);
            }
        }

        if(colls.Length <= 0)
        {
            currentTarget = null;
        }

    }

    GameObject currentTarget;


    float radius = 5f;

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

        if(currentTarget != null)
        {
            Gizmos.DrawLine(transform.position, currentTarget.transform.position);
        }

    }
}
