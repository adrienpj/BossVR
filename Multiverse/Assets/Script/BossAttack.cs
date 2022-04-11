using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private GameObject fireball;
    [SerializeField] float destroyTime = 5;
    public Transform target;
    public float burst = 350f;
    public Transform boss;

    // Update is called once per frame
    void Update()
    {
        BossAtk();
    }

    void BossAtk()
    {
        if(boss.position == (target.position -transform.position))
        {
            Debug.Log("AttackFireBall");
            FireballActivate();
        }
    }

    private void FireballActivate()
    {
        //Création du projectile (boule de feu)
        GameObject projectile = Instantiate(fireball, transform.position, transform.rotation);
        //Donner une force et une direction
        projectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * burst);
        
        //Le temps limite avant la destruction du projectile (boule de feu)
        Destroy(projectile, destroyTime); 
    }
}
