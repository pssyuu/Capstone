using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    Option[] options;
    public int stateStartNum = 0;
    public int stateEndNum = 0;
    bool ranEnd = true;

    void Awake()
    {
        options = GetComponentsInChildren<Option>();

        foreach (Option option in options)
        {
            option.gameObject.SetActive(false);
        }

        int[] ran = new int[3];
        
        while (ranEnd)
        {
            ran[0] = Random.Range(stateStartNum, stateEndNum);
            ran[1] = Random.Range(stateStartNum, stateEndNum);
            ran[2] = Random.Range(stateStartNum, stateEndNum);

            break;
        }

        for (int index = 0; index < ran.Length; index++)
        {
            Option ranoption = options[ran[index]];
            ranoption.gameObject.SetActive(true);
        }

    }
}
