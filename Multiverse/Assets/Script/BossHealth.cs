using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealth : MonoBehaviour
{
    public float health = 75f;
    public float maxHealth = 100f;

    public Image BossHealthBarImage;

    [SerializeField] private Collision collision;
    
    

    // Update is called once per frame
    void Update()
    {
        BossHealthBarImage.fillAmount = health / maxHealth;

        health = Mathf.Clamp(health, 0f, maxHealth);
    }
    
    void OnCollisionEnter()
    {
        Damage(15);

    }
    
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
    }


}
