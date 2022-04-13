using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] float destroyTime = 5;
    public Transform target;
    public Transform boss;
    public Transform player;


    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vérifié la distance et l'attaque
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange);

        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(5);
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void AttackPlayer()
    {
        if (!alreadyAttacked)
        {
            ///Attaque code ici
            Rigidbody fireball = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            fireball.AddForce(transform.forward * 15f, ForceMode.Impulse );
            fireball.AddForce(transform.up * -3f, ForceMode.Impulse);
            
            Destroy(fireball.GetComponent<Rigidbody>(),destroyTime);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
