using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleportation : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider provider;
    private bool _isActive;

    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;
        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Select");
        activate.Enable();

        activate.performed += TeleportActivate;

        var cancel = actionAsset.FindActionMap("XRI LeftHand").FindAction("Select");
        cancel.Enable();

        cancel.performed += TeleportCancel;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isActive)
        {
            return;
        }
        
        if(!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            _isActive = false;
            return;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point,
        };

        provider.QueueTeleportRequest(request);
        
    }

    private void TeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        _isActive = true;
    }

    private void TeleportCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        _isActive = false;
    }

}
