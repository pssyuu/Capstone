using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOption : MonoBehaviour
{

    void RandomOpt()
    {
        int[] random = new int[3];
        while (true)
        {
            random[0] = Random.Range(0,1);
            random[1] = Random.Range(0,1);
            random[2] = Random.Range(0,1);

            if (random[0] != random[1] && random[1] != random[2] && random[0] != random[2])
                break;
        }
    }

}
