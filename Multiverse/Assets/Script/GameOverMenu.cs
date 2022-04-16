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
        /*
        //Bouton A
        var buttonA = actionAsset.FindActionMap("XRI RightHand").FindAction("Teleport Select");
        buttonA.Enable();
        buttonA.performed += ResrartButton;

        //Bouton X
        var buttonB = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Select");
        buttonB.Enable();
        buttonB.performed += MenuButton;
        */
    }

    public void ResrartRaycast()
    {
        SceneManager.LoadScene("BossVR");
    }

    public void MenuButton()
    {
        
    }

    /*
    public void ResrartButton(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("BossVR");
    }

    public void MenuButton(InputAction.CallbackContext context)
    {
        
    }
    */
}
