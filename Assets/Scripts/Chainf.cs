using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainf : MonoBehaviour
{
    public GameObject ChaInform;
    bool OnOff = true;

    public void ChainforOnOff()
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
}
