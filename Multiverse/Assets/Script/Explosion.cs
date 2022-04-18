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
    BossHealth bossHealth;
    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Awake()
    {
        fireball.GetComponent<GameObject>();
    }

    void Start()
    {
        bossHealth = FindObjectOfType<BossHealth>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        GameObject expl = Instantiate(explosionVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(fireball);
        Destroy(expl, 1);

        if (col.gameObject.tag == "Boss")
        {
            bossHealth.Damage(5);
        }
        if (col.gameObject.tag == "Shield")
        {
    
        }
        else if (col.gameObject.tag == "Player")
        {
            playerHealth.Damage(15);

        }
    }

    private void OnDestroy()
    {
        //bossHealth.Damage(5);
    }
}
