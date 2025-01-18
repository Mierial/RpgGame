using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomPool;

public class LootBag : MonoBehaviour
{
    [SerializeField] public Items _gameObject;
    [SerializeField] public int counter;

    private CustomPool<Items> _customPool;
    private void Awake()
    {
        _customPool = new CustomPool<Items>(_gameObject, counter);
    }

    public void GetLot()
    {
        
        int number = Random.Range(1, 101);
        if ( _gameObject.dropChanse >= number)
        {
            _customPool.Get();
        }
    }





}
