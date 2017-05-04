using UnityEngine;
using System.Collections;
using System;

public class CanonMovement : MonoBehaviour
{

    public GameObject canon;

    void FixedUpdate()
    {
        float rotateSpeed = 30.0f;       
        canon.transform.rotation = Quaternion.Euler((float)Mathf.PingPong(Time.time * rotateSpeed, 360.0f) + 45f, 90f, 90f);

    }
}
