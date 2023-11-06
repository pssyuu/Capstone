using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject btn;
    public Image myImage;
    public Sprite smileimg;
    public Sprite sadimg;
    public Sprite baseimg;
    int nextoptid;

    // Start is called before the first frame update
    void Awake()
    {
       //nextoptid = btn.GetComponent<ButtonChanger>().nextoptid;
        myImage = GetComponent<Image>();
       // myImage.sprite = smileimg;
    }

   void FixedUpdate()
    {
        nextoptid = btn.GetComponent<ButtonChanger>().nextoptid;

        switch (nextoptid)
        {
            case 0:
                myImage.sprite = baseimg;
                break;

            case 1:
                myImage.sprite = smileimg;
                break;

            case 2:
                myImage.sprite = sadimg;
                break;

        }
    }
}
