using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    [Header("objects")]
    public SpriteRenderer LayerOne;
    public SpriteRenderer LayerTwo;
    public SpriteRenderer LayerThree;
    public SpriteRenderer LayerFour;
    public SpriteRenderer LayerFive;

 
    [Header("Originals")]
    public Sprite blkone;
    public Sprite blktwo;
    public Sprite blkthree;
    public Sprite blkfour;
    public Sprite blkfive;


    [Header("images")]
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;

   
    public void ColourLayer(string colour)
    {
        switch (colour)
        {
            case "Red":
                LayerTwo.sprite = two;
                break;

            case "Green":
                LayerFour.sprite = four;
                LayerFive.sprite = five;
                break;
            case "Blue":
                LayerOne.sprite = one;
                break;
            case "Yellow":
                LayerThree.sprite = three;
                break;
        }
    }

    public void ResetRoom()
    {
        LayerOne.sprite = blkone;
        LayerTwo.sprite = blktwo;
        LayerThree.sprite = blkthree;
        LayerFour.sprite = blkfour;
        LayerFive.sprite = blkfive;
    }

}
