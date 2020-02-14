using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroller : MonoBehaviour
{

    public static CameraConroller instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject target;
    public GameObject moving;

    public float fSpeed;
    public float movingRange = 3f;
    public float movingSpeed = 3f;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * fSpeed);
    }

    public void CameraMoving()
    {
        Vector3 targetForward = target.transform.forward;
        Vector3 movingPos = target.transform.position + targetForward * movingRange;
        moving.transform.position = Vector3.Lerp(moving.transform.position, movingPos, Time.deltaTime * movingSpeed);
    }

    public void ResetMoving()
    {
        moving.transform.position = Vector3.Lerp(moving.transform.position, transform.position, Time.deltaTime * movingSpeed);
    }
}
