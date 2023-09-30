using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{

    public OptionData data;
    Text textEx;

    void Awake ()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        textEx = texts[0];
        textEx.text = data.optionEx;
    }

}
