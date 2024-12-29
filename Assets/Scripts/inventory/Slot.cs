using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemScriptableObject item;
    public int amount;
    public bool isEmpty = true;
    public GameObject iconGameObject;
    public Text textItemAmount;

    private Image iconImage;



    private void Awake()
    {
        textItemAmount = transform.GetChild(0).GetComponent<Text>();  
        iconGameObject = transform.GetChild(1).gameObject;  
        iconImage = iconGameObject.GetComponent<Image>();
    }

    public void SetIcon(Sprite icon)
    {
        if (icon != null)
        {
            iconImage.color = new Color(1, 1, 1, 1);
            iconImage.sprite = icon;
        }
    }


}

