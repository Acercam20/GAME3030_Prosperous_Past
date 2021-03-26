using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Player HUD Canvas 
    public GameObject HUDCanvas;
    public GameObject StoneTabletHUD;
    public GameObject pauseCanvas;
    //Totem Combo
    public int totemCombo;
    private int currentTotemCombo = 0;
    //Centre Platform
    public GameObject centrePlatform;
    public bool isDescending, descendingStatement = true;
    private bool glyphUnlocked1, glyphUnlocked2, glyphUnlocked3, glyphUnlocked4;
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

    //Tetra Game
    public GameObject TetraUI;
    public List<GameObject> tetraButtonBools;
    public List<GameObject> tetraManaLines;

    //Pushable Objects
    public Vector3 rockRespawnLocation = new Vector3(-7, 7, 34);

    //Player
    public Vector3 playerRespawnLocation = new Vector3(-80, 0, -5);

    //HUD
    public Text interactionText;

    /*********************
     * Private Variables *
     *********************/
    private bool pressurePlate1Active, pressurePlate2Active;
    void Start()
    {
        DontDestroyOnLoad(pauseCanvas);
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(HUDCanvas);
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StoneTabletHUD.SetActive(false);
        TetraUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (glyphUnlocked1 && glyphUnlocked2 && glyphUnlocked3 && glyphUnlocked4 && descendingStatement)
        {
            isDescending = true;
            descendingStatement = false;
            GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().platformLowering);
        }
        if (isDescending)
        {
            if (centrePlatform != null)
                centrePlatform.transform.position = new Vector3(centrePlatform.transform.position.x, centrePlatform.transform.position.y - 0.01f, centrePlatform.transform.position.z);
        }
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
                GlyphLock4.GetComponent<MeshRenderer>().material = activatedTotemMat;
                glyphUnlocked4 = true;
                GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().puzzleComplete);
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
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().puzzleFailed);
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
            GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().puzzleComplete);
            pressurePlateChallengeComplete = true;
            pressurePlateCentralManaLine.GetComponent<MeshRenderer>().material = activatedTotemMat;
            glyphUnlocked3 = true;
        }
    }

    public void TetraBoolChecks()
    {
        bool isComplete = true;
        for (int i = 0; i < 5; i++)
        {
            if (!tetraButtonBools[i].GetComponent<TetraButtonsBehaviour>().isActive)
            {
                isComplete = false;
            }
        }
        if (isComplete)
        {
            GlyphLock1.GetComponent<MeshRenderer>().material = activatedTotemMat;
            for (int i = 0; i < tetraManaLines.Count; i++)
            {
                tetraManaLines[i].GetComponent<MeshRenderer>().material = activatedTotemMat;
            }
            GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().puzzleComplete);
            glyphUnlocked1 = true;
        }
    }

    public void FinishObjectiveFour(bool finished)
    {
        GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().puzzleComplete);
        GlyphLock2.GetComponent<MeshRenderer>().material = activatedTotemMat;
        glyphUnlocked2 = true;
    }
}
