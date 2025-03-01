using UnityEngine;
using UnityEngine.UI;

public class BothItem : MonoBehaviour
{
    [SerializeField] private Item[] items;
    public Text buyText;
    public Image image;
    private int _buyPrice;
    public GameObject panel;
    public InventoryManager inventoryManager;

    public Image[] images; 

    public Sell sellManager;
    private int _currentNumberSlot = 0;
    private void Start()
    {
        SetItems();
    }
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
        buyText.text = _buyPrice.ToString();
    }

    public void NextItem()
    {
        if(_currentNumberSlot == items.Length)
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
    
    public void BuyItem()
    {
        if (sellManager.totalValue >= _buyPrice&& items[_currentNumberSlot].armorCount==0)
        {
            InventoryManager.Instance.Add(items[_currentNumberSlot]);
            sellManager.totalValue -= _buyPrice;
            sellManager.UpdateText();
        }
        else if(sellManager.totalValue >= _buyPrice && items[_currentNumberSlot].armorCount >= 0)
        {
            int curenntItem = 0;
            images[curenntItem].sprite = items[_currentNumberSlot].icon;
            curenntItem++;
            sellManager.totalValue -= _buyPrice;
            sellManager.UpdateText();
        }
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
