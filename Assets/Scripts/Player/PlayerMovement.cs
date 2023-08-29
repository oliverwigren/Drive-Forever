using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float minX;
    public float maxX;

    Vector3 touchPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.);
        mousePosition.y = -1.5f;
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane + 1 ;

        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    if (touch.phase == TouchPhase.Moved)
        //    {
        //        Vector3 pos = touch.position;
        //        pos.x = (pos.x - 450) / 450;
        //        pos.y = (pos.y - 800) / 800;
        //        touchPosition = new Vector3(-pos.x, pos.y, 0);

        //        //transform.position = touchPosition;
        //    }
        //}

        if (mousePosition.x < minX || mousePosition.x > maxX)
        {
            gameObject.transform.position = gameObject.transform.position;
        }
        else
        {
            gameObject.transform.position = mousePosition;
        }

        //if (touchPosition.x < minX || touchPosition.x > maxX)
        //{
        //    gameObject.transform.position = gameObject.transform.position;
        //}
        //else
        //{
        //    gameObject.transform.position = touchPosition;
        //}
    }
}
        
