using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    private int shroomNumber;
    public Sprite [] shroomContainer;
    public Image imageRef;

    public TMP_Text numberToShow;
    
    private void OnEnable()
    {
        shroomNumber = GameManager.instance.mushroomCounter;
        if (shroomContainer[shroomNumber] != null)
        {
            imageRef.sprite = shroomContainer[shroomNumber];
        }

        numberToShow.text = shroomNumber.ToString("D3");
    }
}
