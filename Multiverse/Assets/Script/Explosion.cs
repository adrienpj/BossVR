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

    // Start is called before the first frame update
    void Awake()
    {
        fireball.GetComponent<GameObject>();
    }

    void Start()
    {
        bossHealth = FindObjectOfType<BossHealth>();
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

    private void OnDestroy()
    {
        bossHealth.Damage(15);
    }
}
