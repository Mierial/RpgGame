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
        if (other.CompareTag("Player"))
        {
            _button.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _button.gameObject.SetActive(false);
    }
}
