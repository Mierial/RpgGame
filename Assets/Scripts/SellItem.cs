using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD

public class BothItem : MonoBehaviour
{
    [SerializeField] private Item[] items;
=======
using System.Collections.Generic;  

public class BothItem : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>(); 
>>>>>>> origin/test
    public Text buyText;
    public Image image;
    private int _buyPrice;
    public GameObject panel;
    public InventoryManager inventoryManager;

<<<<<<< HEAD
    public Sell sellManager;

    private int _currentNumberSlot = 0;
=======
    private int curenntItem = 0;
    public Image[] images;

    private int currentArmor = 0;

    public ArmorBar bar;

    public Sell sellManager;
    private int _currentNumberSlot = 0;

>>>>>>> origin/test
    private void Start()
    {
        SetItems();
    }
<<<<<<< HEAD
    public void SetItems()
    {
            image.sprite = items[0].icon;
            _buyPrice = items[0].ItemValue;
            buyText.text = _buyPrice.ToString();
    }
    public void SwicthItem()
    {
        if (_currentNumberSlot == items.Length)
        {
            _currentNumberSlot = 0;
        }
        image.sprite = items[_currentNumberSlot].icon;
        _buyPrice = items[_currentNumberSlot].ItemValue;
=======

    public void SetItems()
    {
        if (items.Count > 0)
        {
            image.sprite = items[0].icon;
            _buyPrice = items[0].ItemValue;
            buyText.text = _buyPrice.ToString();
        }
    }

    public void SwicthItem()
    {
        if (_currentNumberSlot == items.Count) 
        {
            _currentNumberSlot = 0;
        }

        image.sprite = items[_currentNumberSlot].icon;
        _buyPrice = items[_currentNumberSlot].ItemValue;
        buyText.text = _buyPrice.ToString();
>>>>>>> origin/test
    }

    public void NextItem()
    {
<<<<<<< HEAD
        if(_currentNumberSlot == items.Length)
=======
        if (_currentNumberSlot == items.Count)
>>>>>>> origin/test
        {
            _currentNumberSlot = 0;
        }
        else
        {
            _currentNumberSlot++;
            SwicthItem();
        }
    }

    public void PreviousItem()
    {
        if (_currentNumberSlot != 0)
        {
            _currentNumberSlot--;
            SwicthItem();
        }
    }
<<<<<<< HEAD
    
=======

>>>>>>> origin/test
    public void BuyItem()
    {
        if (sellManager.totalValue >= _buyPrice)
        {
<<<<<<< HEAD
            InventoryManager.Instance.Add(items[_currentNumberSlot]);
            sellManager.totalValue -= _buyPrice;
            sellManager.UpdateText();

=======

            if (items[_currentNumberSlot].armorCount == 0)
            {
                InventoryManager.Instance.Add(items[_currentNumberSlot]);
            }
            else
            {

                images[curenntItem].sprite = items[_currentNumberSlot].icon;
                curenntItem++;
                currentArmor += items[_currentNumberSlot].armorCount;
                bar.SetHealth(currentArmor);
            }


            sellManager.totalValue -= _buyPrice;
            sellManager.UpdateText();

            RemoveItemFromList(_currentNumberSlot);

            SwicthItem();
        }
    }


    private void RemoveItemFromList(int index)
    {
        if (items.Count > 0 && index < items.Count)
        {
            items.RemoveAt(index);  
>>>>>>> origin/test
        }
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
