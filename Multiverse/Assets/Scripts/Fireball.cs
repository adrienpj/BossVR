using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Fireball : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private GameObject fireball;
    [SerializeField] float destroyTime = 5;
    public float burst =700f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var activate = actionAsset.FindActionMap("XRI RightHand").FindAction("Activate");
        activate.Enable();
        activate.performed += FireballActivate;
    }

    //Méthode de tire de boule de feu
    private void FireballActivate(InputAction.CallbackContext context)
    {
        //Création du projectile (boule de feu)
        GameObject projectile = Instantiate(fireball, transform.position, transform.rotation);
        //Donner une force et une direction
        projectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * burst);
        //Le temps limite avant la destruction du projectile (boule de feu)
        Destroy(projectile, destroyTime);
        
    }


    //Contact avec un élément (ostacle ou ennemi)
    private void OnCollisionEnter (Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            // get comp for enemy script
            // Enmey - damage from health
        }

        Destroy(this.gameObject);


    }

    
}
