using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Bouclier : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private GameObject shield;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Select");
        activate.Enable();
        activate.performed += ShieldActivate;

    }

    private void ShieldActivate(InputAction.CallbackContext context)
    {
        //var bouclier = this.gameObject.transform.GetChild(1);
        if (shield.gameObject.activeSelf == false)
        {
            shield.gameObject.SetActive(true);
        }
        else
        {
            shield.gameObject.SetActive(false);
        }
    }

}
