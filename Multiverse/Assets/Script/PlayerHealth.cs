using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public int tmp = 0;

    public GameObject Boutons;
    public GameObject FondNoir;
    public GameObject PlayerHealthBar;
    public GameObject PlayerHealthBarBackground;



    public Image PlayerHealthBarImage;
    
    // Start is called before the first frame update
    void Start()
    {
        FondNoir.gameObject.SetActive(false);
        Boutons.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealthBarImage.fillAmount = health / maxHealth;

        health = Mathf.Clamp(health, 0f, maxHealth);

        if(health <= 0 && tmp == 0)
        {
            PlayerHealthBar.gameObject.SetActive(false);
            PlayerHealthBarBackground.gameObject.SetActive(false);
            Boutons.gameObject.SetActive(true);
            FondNoir.gameObject.SetActive(true);
            tmp = 1;

        }
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;

    }
}
