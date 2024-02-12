using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class ActionControll : MonoBehaviour
{
    public List<GameObject> swappedHats = new List<GameObject>();
    public List<GameObject> letterBoxes = new List<GameObject>();

    public string[] letterboxMemory = new string[10];

    public bool stopWin;

    public GameObject winM;

    public LayerMask layermask;

    UnityEngine.Touch touch;

    void Start()
    {
        stopWin = false;
        GameObject[] lb = GameObject.FindGameObjectsWithTag("letterbox");
        foreach (GameObject rb in lb) 
        {
            letterBoxes.Add(rb);
        }
    }

    void Update()
    {
        PhraseCheck();
        if (stopWin)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000f, layermask))
                {
                    if(hit.collider.gameObject.name == "WinM")
                    {
                        //TODO: add return to point
                        Application.Quit();
                    }
                }
            }
        }
    }

    void PhraseCheck()
    {
        if (letterboxMemory[0] == "hat1" || letterboxMemory[0] == "hat7")
        {
            if (letterboxMemory[1] == "hat4" || letterboxMemory[1] == "hat2" || letterboxMemory[1] == "hat8")
            {
                if (letterboxMemory[2] == "hat5" || letterboxMemory[2] == "hat12")
                {
                    if (letterboxMemory[3] == "hat4" || letterboxMemory[3] == "hat2" || letterboxMemory[3] == "hat8")
                    {
                        if (letterboxMemory[4] == "hat10")
                        {
                            if (letterboxMemory[5] == "hat1" || letterboxMemory[5] == "hat7")
                            {
                                if (letterboxMemory[6] == "hat11")
                                {
                                    if (letterboxMemory[7] == "hat5" || letterboxMemory[7] == "hat12")
                                    {
                                        if (letterboxMemory[8] == "hat4" || letterboxMemory[8] == "hat2" || letterboxMemory[8] == "hat8")
                                        {
                                            if (letterboxMemory[9] == "hat9")
                                            {
                                                stopWin = true;
                                                winM.SetActive(true);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
