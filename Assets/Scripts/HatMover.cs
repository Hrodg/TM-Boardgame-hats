using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatMover : MonoBehaviour
{
    public LayerMask layermask;

    Touch touch;

    float touchSpeed = 0.0077f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit, 1000f, layermask))
            {
                if (hit.collider != null && hit.collider.gameObject.name == this.gameObject.name && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.x * touchSpeed,
                        transform.position.y + touch.deltaPosition.y * touchSpeed,
                        transform.position.z
                        );
                    //transform.position = new Vector3(
                    //    touch.position.x,
                    //    touch.position.y,
                    //    transform.position.z
                    //    );
                }
            }
        }
    }
}
