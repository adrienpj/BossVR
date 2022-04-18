using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BossHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public GameObject text;
    public GameObject boss;
    public GameObject defeatAnime;
    public GameObject BossHealthBar;
    public GameObject BossHealthBarBackground;
    public Image BossHealthBarImage;
    public int tmp = 0;
    public GameObject message1;
    public GameObject message2;
    public GameObject fireworks;
    public GameObject victoireCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        message1.gameObject.SetActive(false);
        victoireCanvas.gameObject.SetActive(false);
        message2.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        BossHealthBarImage.fillAmount = health / maxHealth;

        health = Mathf.Clamp(health, 0f, maxHealth);
        
        if(health <= 0 && tmp == 0)
        {
            Vector3 position = new Vector3(0f, 20f, 0f);
            boss.gameObject.SetActive(false);
            BossHealthBar.gameObject.SetActive(false);
            BossHealthBarBackground.gameObject.SetActive(false);
            DefeatAnimation(position);
            tmp = 1;

        }
    }

    //Dégats infligés
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
    }

    //Animation après avoir battu le boss
    public void DefeatAnimation(Vector3 position)
    {
        GameObject explosion = Instantiate(defeatAnime, position, Quaternion.identity) as GameObject;
        Destroy(explosion, 3);
        string flag = "Victoire";
        StartCoroutine(Wait(flag));

    }

    //Animation après la victoire
    public void VictoryAnimation(Vector3 position)
    {
        GameObject victoryAnimation = Instantiate(fireworks, position, Quaternion.identity) as GameObject;
    }

    //wait
    IEnumerator Wait(string flag)
    {
        
        yield return new WaitForSeconds(3);
        
        DiscardObjects(flag);
        
    }

    //Cas de figure
    public void DiscardObjects(string flag)
    {
        if(flag == "Victoire")
        {
            message1.gameObject.SetActive(true);
            message2.gameObject.SetActive(true);
            Vector3 position = new Vector3(0f, 17f, 0f);
            VictoryAnimation(position);
            victoireCanvas.gameObject.SetActive(true);
            text.GetComponent<Timer>().toogle_alive();
            message2.GetComponent<Text>().text = "you won in : " + Math.Round((text.GetComponent<Timer>().get_time() / 60), 2).ToString() + " minutes";
            
        }
    }
}
