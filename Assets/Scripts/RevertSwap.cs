using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class RevertSwap : MonoBehaviour
{
    public LayerMask mask;

    Touch touch;

    ActionControll actionControll;

    int position;

    void Start()
    {
        actionControll = GameObject.Find("Map").GetComponent<ActionControll>();    
    }

    void Update()
    {
        if (Input.touchCount > 0 && !actionControll.stopWin)
        {
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f, mask))
            {
                if (hit.collider != null && hit.collider.gameObject.name == this.gameObject.name && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    string value = this.gameObject.name.Substring(0, this.gameObject.name.Length - 13);
                    GameObject temp = actionControll.swappedHats.Where(obj => obj.name == value).SingleOrDefault();
                    int index = actionControll.swappedHats.IndexOf(temp);
                    temp.SetActive(true);
                    temp.transform.position = temp.GetComponent<HatSwapper>().initialPosition;
                    actionControll.swappedHats.RemoveAt(index);
                    for (int i = 0; i < actionControll.letterboxMemory.Length; i++)
                    {
                        if (actionControll.letterboxMemory[i] == value)
                        {
                            position = i+1;
                            actionControll.letterboxMemory[i] = "";
                            break;
                        }
                    }
                    actionControll.letterBoxes.Add(GameObject.Find("Letter"+position.ToString()));
                    Destroy(gameObject);
                }
            }
        }
    }
}
