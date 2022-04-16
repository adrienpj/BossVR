using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;

    void Update()
    {   

    }

    public void RestartRaycast()
    {
        SceneManager.LoadScene("BossVR");
    }

    public void MenuButton()
    {
        
    }

}
