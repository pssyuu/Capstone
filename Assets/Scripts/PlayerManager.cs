using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject btn;
    public Image[] player;
    public Sprite smileimg;
    public Sprite sadimg;
    public Sprite baseimg;
    int nextoptid;

    // Start is called before the first frame update
    void Awake()
    {
        //nextoptid = btn.GetComponent<ButtonChanger>().nextoptid; 
        // myImage.sprite = smileimg;
    }

   void FixedUpdate()
    {
        nextoptid = btn.GetComponent<ButtonChanger>().nextoptid;

        switch (nextoptid)
        {
            case 3:
                player[0].sprite = baseimg;
                player[1].sprite = smileimg;
                player[2].sprite = sadimg;
                player[3].sprite = baseimg;
                break;

            case 1:
                player[0].sprite = baseimg;
                player[1].sprite = sadimg;
                player[2].sprite = smileimg;
                player[3].sprite = sadimg;
                break;

            case 2:
                player[0].sprite = smileimg;
                player[1].sprite = baseimg;
                player[2].sprite = sadimg;
                player[3].sprite = smileimg;
                break;

            case 0:
                player[0].sprite = baseimg;
                player[1].sprite = baseimg;
                player[2].sprite = baseimg;
                player[3].sprite = baseimg;
                break;

        }
    }
}
