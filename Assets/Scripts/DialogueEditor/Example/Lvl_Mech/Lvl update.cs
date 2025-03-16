using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvlupdate : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Text power;
    [SerializeField] private Text agility;
    [SerializeField] private Text intelct;

    public void LvlUpd()
    {
        ClassHerro character = player.GetComponent<ClassHerro>();
        character.HealthUp();
        power.text = character.strenght.ToString();
        agility.text = character.agility.ToString();
        intelct.text = character.intelect.ToString();


    }
    private void Lvlprogres()
    {

    }
}
