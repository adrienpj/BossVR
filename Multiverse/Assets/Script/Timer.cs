using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    float time;
    Boolean is_alive = true;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (is_alive)
        {
            GetComponent<Text>().text = Math.Round((time / 60), 2).ToString() + " minutes";
            time = Time.time;
        }

        
    }
    
    public void toogle_alive()
    {
        is_alive = !is_alive;
        if (is_alive)
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
    }

    public float get_time()
    {
        return time;
    }
}
