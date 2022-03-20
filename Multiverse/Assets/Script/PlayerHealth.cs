using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float health = 75f;
    public float maxHealth = 100f;

    public Image PlayerHealthBarImage;
    

    // Update is called once per frame
    void Update()
    {
        PlayerHealthBarImage.fillAmount = health / maxHealth;

        health = Mathf.Clamp(health, 0f, maxHealth);
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
    }

   
}
