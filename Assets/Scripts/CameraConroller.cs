using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroller : MonoBehaviour
{
    public GameObject target;

    public float fSpeed;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * fSpeed);

        Vector3 targetForward = target.transform.forward;

    }
}
