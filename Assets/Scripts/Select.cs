using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    GameObject btnChanger;
    Option[] options;
    public int stateStartNum = 0;
    public int stateEndNum = 0;
    bool ranEnd = true;
    int[] ran = new int[5];


    void Awake()
    {
        options = GetComponentsInChildren<Option>();
        btnChanger = GameObject.Find("ButtonChanger");

        RanSelect();

    } 

    public void RanSelect()
    {
        foreach (Option option in options)
        {
            option.gameObject.SetActive(false);
        }

        while (ranEnd)
        {
            ran[0] = Random.Range(stateStartNum, stateEndNum);
            ran[1] = Random.Range(stateStartNum, stateEndNum);
            ran[2] = Random.Range(stateStartNum, stateEndNum);
            ran[3] = Random.Range(stateStartNum, stateEndNum);
            ran[4] = Random.Range(stateStartNum, stateEndNum);


            if (ran[0] != ran[1] && ran[0] != ran[2])
            {
                ranEnd = false;
            }
        }

        ranEnd = true;

        for (int index = 0; index < ran.Length; index++)
        {
            Option ranoption = options[ran[index]];
            ranoption.gameObject.SetActive(true);
        }

        System.Array.Clear(ran,0,5);

    }
    
    private void FixedUpdate()
    {
        if (btnChanger.GetComponent<ButtonChanger>().btnClick == true)
        {
            RanSelect();
            btnChanger.GetComponent<ButtonChanger>().btnClick = false;
        }
    }
}
