using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Player HUD Canvas 
    public GameObject HUDCanvas;
    public GameObject StoneTabletHUD;
    //Totem Combo
    public int totemCombo;
    private int currentTotemCombo = 0;

    //Cardinal Totems
    public GameObject nTotem;
    public GameObject eTotem;
    public GameObject sTotem;
    public GameObject wTotem;

    public Material deactivatedTotemMat;
    public Material activatedTotemMat;

    public GameObject GlyphLock1, GlyphLock2, GlyphLock3, GlyphLock4;

    public GameObject pressurePlateCentralManaLine;
    public bool pressurePlateChallengeComplete = false;
    //Pressure Plates
    //public GameObject EasternPressurePlate;
    //public GameObject WesternPressurePlate;

    //HUD
    public Text interactionText;

    /*********************
     * Private Variables *
     *********************/
    private bool pressurePlate1Active, pressurePlate2Active;
    void Start()
    {
        DontDestroyOnLoad(this);
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StoneTabletHUD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTotem(int totemNumber)
    {
        if (currentTotemCombo < 1)
        {
            currentTotemCombo = totemNumber;
        }
        else if (currentTotemCombo < 10)
        {
            currentTotemCombo += totemNumber * 10;
        }
        else if (currentTotemCombo < 100)
        {
            currentTotemCombo += totemNumber * 100;
        }
        else if (currentTotemCombo < 1000)
        {
            currentTotemCombo += totemNumber * 1000;

            if (currentTotemCombo == totemCombo)
            {
                GlyphLock1.GetComponent<MeshRenderer>().material = activatedTotemMat;
                Debug.Log("Totem Challenge Complete!");
            }
            else
            {
                DeactivateTotem();
            }
        }
        Debug.Log(currentTotemCombo);
        
    }

    public void DeactivateTotem()
    {
        currentTotemCombo = 0;
        nTotem.GetComponent<TotemBehaviour>().Deactivate();
        eTotem.GetComponent<TotemBehaviour>().Deactivate();
        sTotem.GetComponent<TotemBehaviour>().Deactivate();
        wTotem.GetComponent<TotemBehaviour>().Deactivate();
    }
    
    public void SetInteractionText(string text)
    {
        interactionText.text = text;
    }

    public void ActivatePressurePlate(bool isActive, bool isEast)
    {
        if (isEast && isActive)
        {
            pressurePlate1Active = true;
        }
        else if (!isEast && isActive)
        {
            pressurePlate2Active = true;
        }
        else if (!isActive && isEast)
        {
            pressurePlate1Active = false;
        }
        else
        {
            pressurePlate2Active = false;
        }

        if (pressurePlate1Active && pressurePlate2Active)
        {
            Debug.Log("Challenge Complete!");
            GlyphLock3.GetComponent<MeshRenderer>().material = activatedTotemMat;
            pressurePlateChallengeComplete = true;
            pressurePlateCentralManaLine.GetComponent<MeshRenderer>().material = activatedTotemMat;
        }
    }
}
