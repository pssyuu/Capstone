using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowBar : MonoBehaviour 
{
    public GameObject ButtonChanger;
    public Slider[] Flowbar;
    public float Damage;
    int nextoptid;
    bool btnClick = true;

    void FixedUpdate()
    {
        nextoptid = ButtonChanger.GetComponent<ButtonChanger>().nextoptid;

        if (btnClick)
        {
            switch (nextoptid)
            {
                case 3:
                    Flowbar[1].value += Damage;
                    Flowbar[2].value -= Damage;
                    break;

                case 1:
                    Flowbar[1].value -= Damage;
                    Flowbar[2].value += Damage;
                    Flowbar[3].value -= Damage;
                    break;

                case 2:
                    Flowbar[0].value += Damage;
                    Flowbar[2].value -= Damage;
                    Flowbar[3].value += Damage;
                    break;
            }
            btnClick = false;
        }

   

        for (int i = 0; i < 4; i++)
        {
            if (Flowbar[i].value == 0)
            {
                Flowbar[i].transform.parent.gameObject.SetActive(false);
            }

            for (int j = 0; j < 4; j++)
            {
                if ( i == j)
                {
                    break;
                }
                else
                {
                    if (Flowbar[i].value == 0 && Flowbar[j].value == 0)
                    {
                        GetComponent<NextScene>().LoadScene("Gameover");
                    }
                }
            }
        }

    }

    public void Cilcktr()
    {
        btnClick = true;
    }

}
