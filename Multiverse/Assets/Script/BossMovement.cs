using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{   /*
    public Transform target;
    public float movementSpeed = 20f;

    public bool _rightTranslation = false;
    public bool _leftTranslation = false;
    public bool _upTranslation = false;
    public bool _downTranslation = false;
    public bool _wandering = false;

    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateBoss();

        if(_wandering == false)
        {
            StartCoroutine(Wander());
        }
    }

    void RotateBoss()
    {
        Vector3 dir = target.position - transform.position;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(dir), Time.deltaTime);
    }

    IEnumerator Wander()
    {
        int waitTime = Random.Range(1, 3);

        _rightTranslation = true;

        yield return new WaitForSeconds(waitTime);

        _leftTranslation = false;

        yield return new WaitForSeconds(waitTime);

        _upTranslation = false;

        yield return new WaitForSeconds(waitTime);

        _downTranslation = false;

        yield return new WaitForSeconds(waitTime);

        if(_leftTranslation == 1 )
        {

        } 


    }
    */
}
