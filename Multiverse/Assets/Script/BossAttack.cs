using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    //[SerializeField] float destroyTime = 5;
    public Transform target;
    public float burst = 350f;
    public Transform boss;
    public Transform player;
    public Vector3 newPosition;

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
            //Vector3 newPosition = new Vector3(transform.position.x - 14, transform.position.y + 11, transform.position.z);
            Vector3 newPosition = new Vector3(boss.transform.position.x - 14, boss.transform.position.y + 11, boss.transform.position.z * 2);
            ///Attaque code ici
            //Rigidbody rb = Instantiate(projectile, new Vector3(-14, 25, 0), Quaternion.identity).GetComponent<Rigidbody>();
            Rigidbody fireball = Instantiate(projectile, newPosition, Quaternion.identity).GetComponent<Rigidbody>();
            fireball.AddForce(transform.forward * 15f, ForceMode.Impulse);
            fireball.AddForce(transform.up * -5.5f, ForceMode.Impulse);
            //Destroy(fireball.GetComponent<Rigidbody>(),destroyTime);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
