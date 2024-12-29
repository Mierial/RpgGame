using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private float raycastDistance = 1f;
    public Camera _camera;
    [SerializeField] private Color rayColor = Color.red; 

    private void Update()
    {
        RaycastHit hit;
        Vector3 rayOrigin = _camera.transform.position;
        Vector3 rayDirection = _camera.transform.forward;


        Debug.DrawRay(rayOrigin, rayDirection * raycastDistance, rayColor);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(rayOrigin, rayDirection, out hit, raycastDistance))
            {
                if (hit.collider.TryGetComponent(out ItemPickUp itemPickUp))
                {
                    inventoryManager.AddItem(itemPickUp.item, itemPickUp.amount);
                    Destroy(itemPickUp.gameObject);
                }
            }
        }
    }
}
