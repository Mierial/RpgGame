using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Lvl_Mech : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Text lvltext;
    private ClassHerro hero;
    private CharacterHealth hp;
    public int Lvl;
    private int need_forLvl = 10;
    private int cuterexp = 0;
    public Slider slider; 
    private void SetLvlSlider()
    {
        slider.maxValue = need_forLvl;
        slider.value = cuterexp;
    }

   
    public void AddPoints(int points)
    {
        cuterexp += points;
        cuterexp = Mathf.Clamp(cuterexp, 0, need_forLvl); 
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        slider.value = cuterexp;
    }


    private void Awake()
    {
        hero = player.GetComponent<ClassHerro>();
        hp = player.GetComponent<CharacterHealth>();
        SetLvlSlider();
    }
    public void Lvlupgrade()
    {

        if (cuterexp >= need_forLvl)
        {
            cuterexp -= need_forLvl;
            Lvl++;
            double nextlvl = need_forLvl * 1.1;
            need_forLvl = (int)Math.Ceiling(need_forLvl * 1.1);
            lvltext.text = Lvl.ToString();
            Debug.Log("Lvl2");
            hero.HaracteristicUp(Lvl);
            hp.HealthSet();
            SetLvlSlider();
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("exp"))
        {
            Debug.Log("+exp");
            Destroy(other.gameObject);
            cuterexp += 10;
            AddPoints(cuterexp);
            Lvlupgrade();
        }
    }
}
