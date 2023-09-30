using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    Option[] options;

    void Awake()
    {
        options = GetComponentsInChildren<Option>();

        foreach (Option option in options)
        {
            option.gameObject.SetActive(false);
        }

        int[] ran = new int[3];
        while (true)
        {
            ran[0] = Random.Range(0, options.Length);
            ran[1] = Random.Range(0, options.Length);
            ran[2] = Random.Range(0, options.Length);

            if (ran[0] != ran[1] && ran[1] != ran[2] && ran[0] != ran[2])
            {
                break;
            }
        }

        for (int index = 0; index < ran.Length; index++)
        {
            Option ranoption = options[ran[index]];
            ranoption.gameObject.SetActive(true);
        }

    }
}
