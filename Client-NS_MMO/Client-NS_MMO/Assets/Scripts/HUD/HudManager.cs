using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{

    public GameObject inventoryWB;
    public GameObject inventoryCTN;

    public GameObject characterWB;
    public GameObject characterCTN;

    void Update()
    {        
        displayInventory();
    }

    private void displayInventory()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
                inventoryWB.SetActive(!inventoryWB.activeSelf);
                inventoryCTN.SetActive(!inventoryCTN.activeSelf);
        }

    }
    private void displayCharacter()
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            characterWB.SetActive(!characterWB.activeSelf);
            characterCTN.SetActive(!characterCTN.activeSelf);
        }

    }
}
