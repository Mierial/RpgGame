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
        if (sellManager.totalValue >= _buyPrice)
        {
            InventoryManager.Instance.Add(items[_currentNumberSlot]);
            sellManager.totalValue -= _buyPrice;
            sellManager.UpdateText();

        }
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
