using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomPool;

public class LootBag : MonoBehaviour
{
    [SerializeField] public Item _gameObject;
    [SerializeField] public int counter;

    private CustomPool<Item> _customPool;
    private void Awake()
    {
        _customPool = new CustomPool<Item>(_gameObject, counter);
    }

    public void GetLot()
    { 
        
            
        
    }





}
