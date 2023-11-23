using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chainf : MonoBehaviour
{
    public GameObject ChaInform;
    public Scriptable_NPC [] npc;
    bool OnOff = true;

    int i = 0;

    public void ChaInformOnOff()
    {
        if (OnOff)
        {
            ChaInform.SetActive(true);
            OnOff = false;
        }
        else
        {
            ChaInform.SetActive(false);
            OnOff = true;
        }
    }

    public void NextChaInform()
    {
        if (i > npc.Length - 2)
        {
            i = 0;
        }
        else
        {
            i++;
        }
        
    }

    private void FixedUpdate()
    {
        ChaInform.GetComponentInChildren<Text>().text = "Name: " + npc[i].npcName + "\n" + "Max Health: " + npc[i].maxHealth + "\n" + "Level: " + npc[i].level + "\n" + "Speed: " + npc[i].speed + "\n" + "Agility: " + npc[i].agility;
    }
}
