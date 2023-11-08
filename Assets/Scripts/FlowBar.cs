using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowBar : MonoBehaviour 
{
    public Slider[] Flowbar;
    public float Damage;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Flowbar[0].value -= Damage;
            Flowbar[2].value -= Damage;
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
}
