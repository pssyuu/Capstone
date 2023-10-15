using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChanger : MonoBehaviour
{
    public GameObject[] Btn;
    public Text[] textEx;
    public OptionData[] data;

    [HideInInspector]
    public bool btnClick = false;

    Option option0;
    Option option1;
    Option option2;
    Option option3;
    Option option4; 

    void Awake()
    {

        /*
          for (int i = 0; i < Btn.Length; i++)
          {
              option[i] = Btn[i].GetComponent<Option>();                            왜 안되는지 모르겠다..
          }
        */

        option0 = Btn[0].GetComponent<Option>();
        option1 = Btn[1].GetComponent<Option>();
        option2 = Btn[2].GetComponent<Option>();
        option3 = Btn[3].GetComponent<Option>();
        option4 = Btn[4].GetComponent<Option>(); 

        // 처음 버튼에 텍스트를 넣어준다.
        for (int i = 0; i < textEx.Length; i++)
        {
            textEx[i].text = data[i].optionEx;
        }
    }

    public void Option1()
    {
        int i = option0.data.optionId;
        option0.data = data[data[i].nextOptionId];
        textEx[0].text = option0.data.optionEx;

        int j = option1.data.optionId;
        option1.data = data[data[j].nextOptionId];
        textEx[1].text = option1.data.optionEx;

        int k = option2.data.optionId;
        option2.data = data[data[k].nextOptionId];
        textEx[2].text = option2.data.optionEx;

        int l = option3.data.optionId;
        option3.data = data[data[l].nextOptionId];
        textEx[3].text = option3.data.optionEx;

        int m = option4.data.optionId;
        option4.data = data[data[m].nextOptionId];
        textEx[4].text = option4.data.optionEx;

        btnClick = true;
    }
}
