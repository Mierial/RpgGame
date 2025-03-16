using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expspawn : MonoBehaviour
{
    [SerializeField] private GameObject exp;
    public void dropexp()
    {
        if (1 ==1 )
        {
            Instantiate(exp, transform.position, Quaternion.identity);
        }
    }
}
