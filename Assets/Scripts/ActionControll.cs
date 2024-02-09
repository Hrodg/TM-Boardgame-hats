using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionControll : MonoBehaviour
{
    public List<GameObject> swappedHats = new List<GameObject>();
    public List<GameObject> letterBoxes = new List<GameObject>();

    public string[] letterboxMemory = new string[10];

    void Start()
    {
        GameObject[] lb = GameObject.FindGameObjectsWithTag("letterbox");
        foreach (GameObject rb in lb) 
        {
            letterBoxes.Add(rb);
        }
    }
}
