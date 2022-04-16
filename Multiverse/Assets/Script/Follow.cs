using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    //Vitesse de déplacement du boss
    [SerializeField] private float bossSpeed = 20f;
    //limitation de la zone
    [SerializeField] private float _rightBoundary = 0f;
    [SerializeField] private float _leftBoundary = 0f;
    [SerializeField] private float _upBoundary = 0f;
    [SerializeField] private float _downBoundary = 0f;

    public Transform target;
    bool enableAct;
    public int act;

    void Start()
    {
        enableAct = true;
    }

    void Update()
    {   
        RotateBoss();
        if(enableAct == true)
        {
            TranslateBoss(act);
        } 
        else if(enableAct == false)
        {
            Debug.Log("débloqué le boss");
            UnFreezeBoss();
            TranslateBoss(act);
        }       
    }
    
    void RotateBoss()
    {
        Vector3 dir = target.position - transform.position;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(dir), Time.deltaTime);
    }

    void TranslateBoss(int act)
    {   
        if(act == 1)
        {
            if(transform.position.z <= _rightBoundary)
            {
                Debug.Log("déplacement à droite");
                transform.Translate(Vector3.right * bossSpeed * Time.deltaTime, Space.Self);
                
            }
            else if(transform.position.z >= _rightBoundary)
            {
                FreezeBoss();
            } 
              
        }
        
        else if(act == 2)
        {
            if (transform.position.y <= _upBoundary)
            {
                Debug.Log("déplacement à haut");
                transform.Translate(Vector3.up * bossSpeed * Time.deltaTime, Space.Self);
                
            }
            else if(transform.position.y >= _upBoundary)
            {
                FreezeBoss();
            }
        }
        /*
        else if(act == 3)
        {
            transform.Translate(Vector3.up * bossSpeed * Time.deltaTime, Space.Self);
            BossBoundaries();
        }
        else if(act == 4)
        {
            transform.Translate(Vector3.down * bossSpeed * Time.deltaTime, Space.Self);
            BossBoundaries();
        }
        */
    }

    //Méthode de vérification de la limite de zone
    void BossBoundaries()
    {
        //axe z translation gauche et droite
        if(transform.position.z >= _rightBoundary)
        {
            FreezeBoss();
        }
        else if(transform.position.z <= _leftBoundary)
        {
            FreezeBoss();
        }
        //axe y translation haut et bas
        else if(transform.position.y >= _upBoundary)
        {
            FreezeBoss();
        }
        else if(transform.position.y <= _downBoundary)
        {
            FreezeBoss();
        }
    }

    void FreezeBoss()
    {
        enableAct = false;
    }

    void UnFreezeBoss()
    {
        enableAct = true;
        int act = Random.Range(1, 4);
        //int act = 2;
        Debug.Log(act);
    }


}