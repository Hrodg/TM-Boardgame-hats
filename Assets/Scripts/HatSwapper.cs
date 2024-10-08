using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HatSwapper : MonoBehaviour
{

    public GameObject mapHolder;
    public GameObject letterToInstantiate;

    public Vector3 initialPosition;

    SpriteRenderer spriteRenderer;
    SpriteRenderer addedSpriteRenderer;

    float disappearingDistance;

    Transform hatLetter;

    GameObject currentLetterBox;

    ActionControll actionControll;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        disappearingDistance = 0.6f;
        hatLetter = gameObject.transform.GetChild(0);
        initialPosition = gameObject.transform.position;
        currentLetterBox = null;
        actionControll = mapHolder.GetComponent<ActionControll>();
        
    }

    void Update()
    {
        CheckDistance();
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended && currentLetterBox !=null)
            {
                Swap();
            }
        }
    }

    private void Swap()
    {
        GameObject instantiatedLetter = Instantiate(letterToInstantiate, currentLetterBox.transform.position, Quaternion.identity);
        instantiatedLetter.transform.SetParent(currentLetterBox.transform);
        addedSpriteRenderer = instantiatedLetter.GetComponent<SpriteRenderer>();
        instantiatedLetter.name = gameObject.name + "_instantiated";
        Sprite sprite1;
        switch (gameObject.name)
        {
            case "hat12":
                sprite1 = Resources.Load<Sprite>("Hats/Group_44");
                addedSpriteRenderer.sprite = sprite1;
                break;
            case "hat1":
                sprite1 = Resources.Load<Sprite>("Hats/Group_42");
                addedSpriteRenderer.sprite = sprite1;
                break;
            case "hat11":
                sprite1 = Resources.Load<Sprite>("Hats/Group_46");
                addedSpriteRenderer.sprite = sprite1;
                break;
            case "hat9":
                sprite1 = Resources.Load<Sprite>("Hats/Group_41");
                addedSpriteRenderer.sprite = sprite1;
                break;
            case "hat4":
                sprite1 = Resources.Load<Sprite>("Hats/Group_43");
                addedSpriteRenderer.sprite = sprite1;
                break;
            case "hat5":
                sprite1 = Resources.Load<Sprite>("Hats/Group_44");
                addedSpriteRenderer.sprite = sprite1;
                break;
            case "hat2":
                sprite1 = Resources.Load<Sprite>("Hats/Group_43");
                addedSpriteRenderer.sprite = sprite1;
                break;
            case "hat8":
                sprite1 = Resources.Load<Sprite>("Hats/Group_43");
                addedSpriteRenderer.sprite = sprite1;
                break;
            case "hat10":
                sprite1 = Resources.Load<Sprite>("Hats/Group_45");
                addedSpriteRenderer.sprite = sprite1;
                break;
            case "hat7":
                sprite1 = Resources.Load<Sprite>("Hats/Group_42");
                addedSpriteRenderer.sprite = sprite1;
                break;
            default:
                break;
        }
        instantiatedLetter.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        actionControll.swappedHats.Add(gameObject);
        int memoryPlace = int.Parse(currentLetterBox.name.Substring(6, currentLetterBox.name.Length-6)) - 1;
        actionControll.letterboxMemory[memoryPlace] = gameObject.name;
        int index = actionControll.letterBoxes.IndexOf(currentLetterBox);
        actionControll.letterBoxes.RemoveAt(index);
        gameObject.SetActive(false);
    }

    private void CheckDistance()
    {
        foreach (var letterBox in actionControll.letterBoxes)
        {
            if (Vector3.Magnitude(letterBox.transform.position - hatLetter.position) < disappearingDistance )
            {
                if (spriteRenderer.enabled)
                {
                    spriteRenderer.enabled = false;
                }
                currentLetterBox = letterBox;
                return;
            } else
            {
                if (Vector3.Magnitude(letterBox.transform.position - hatLetter.position) >= disappearingDistance && !spriteRenderer.enabled)
                {
                    spriteRenderer.enabled = true;
                    currentLetterBox = null;
                }
            }
        }
    }
}
