using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class Button_SentPanel : MonoBehaviour
{

    [SerializeField] private GameObject _panel1;
    [SerializeField] private GameObject _panel2;
    private void Awake()
    {
        _panel2.SetActive(false);
    }
    public void OnClickeble1()
    {
        _panel2.SetActive(true);
    }
}
