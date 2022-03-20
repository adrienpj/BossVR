using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Explosion : MonoBehaviour
{
    public GameObject fireball;
    [SerializeField] private Collision collision;
    public GameObject explosionVFX;
    
    // Start is called before the first frame update
    void Awake()
    {
        fireball.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      void OnCollisionEnter()
    {
        GameObject expl = Instantiate(explosionVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(fireball);
        Destroy(expl, 1);
    }
}
