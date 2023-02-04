using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private int shroomNumber;
    public GameObject[] shroomContainer;
    public TMP_Text numberToShow;
    
    private void OnEnable()
    {
        shroomNumber = GameManager.instance.mushroomCounter;
        
        for(int i = 0; i < shroomNumber; i++)
        {
            if(shroomContainer[i] != null)
            {
                shroomContainer[i].SetActive(true);
            }
        }
        numberToShow.text = shroomNumber.ToString();
    }


}
