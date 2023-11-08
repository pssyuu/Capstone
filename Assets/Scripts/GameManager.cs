using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public NPC [] NPC;

    public void Probability()
    {

    }

    private void FixedUpdate()
    {
        for (int i = 0; i < 4 ; i++)
        {
            if ( GetComponent<FlowBar>().Flowbar[i].value < 25)
            {

            }
            else if (75 <= GetComponent<FlowBar>().Flowbar[i].value)
            {

            }
            else
            {

            }
        }
    }
}
