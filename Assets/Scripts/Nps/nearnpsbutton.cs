using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class nearnpsbutton : MonoBehaviour
{
    [SerializeField] public Button _button;
    private void Awake()
    {
        _button.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
<<<<<<< HEAD:Assets/Scripts/inventory/Nps/nearnpsbutton.cs
<<<<<<< HEAD
        if (other.CompareTag("Player")&& inventory.heldItem!=null)
=======
        if (other.CompareTag("Player"))
>>>>>>> origin/test
=======
        if (other.CompareTag("Player"))
>>>>>>> stas-nps:Assets/Scripts/Nps/nearnpsbutton.cs
        {
            _button.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _button.gameObject.SetActive(false);
    }
}
