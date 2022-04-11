using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        RotateBoss();
    }
    
    void RotateBoss()
    {
        Vector3 dir = target.position - transform.position;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(dir), 1* Time.deltaTime);
    }
}
