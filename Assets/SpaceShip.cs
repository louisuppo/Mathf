using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class SpaceShip : MonoBehaviour
{
    Vector2 speed;
    public float accel;

    Vector2 screenSize;

    public float alpha;

    private Vector3 tempMousePos;

    private void Start()
    {
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        tempMousePos = Input.mousePosition;
    }
    void Update()
    {
        //Rotation ship
        Vector3 mousePos = Input.mousePosition;

        float opposite = (mousePos.x - Camera.main.WorldToScreenPoint(transform.position).x - transform.localPosition.x);
        float adjacent = (mousePos.y - Camera.main.WorldToScreenPoint(transform.position).y - transform.localPosition.y);
        float distance = ((tempMousePos.x - Input.mousePosition.x) * (tempMousePos.x - Input.mousePosition.x) + (tempMousePos.y - Input.mousePosition.y) * (tempMousePos.y - Input.mousePosition.y));
        alpha = 180 - Mathf.Atan2(opposite, adjacent) * (180 / Mathf.PI);

        //ya unblem ici faut régler distance face au truc
        if ((distance<1 && mousePos != tempMousePos))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, alpha);

        }



        //Déplacement
        transform.position += -transform.up * speed.x;
        Debug.Log(speed);

        if (Input.GetKeyDown(KeyCode.E))
        {
            speed += new Vector2(accel*Time.deltaTime, 0f);
        }


        //TP screensize
        if (transform.position.x > screenSize.x - 5 || transform.position.x < -screenSize.x - 5)
        {
            transform.position = new Vector3(screenSize.x - 30, 0f, 0f);
        }

        if (transform.position.y > screenSize.y - 5 || transform.position.y < -screenSize.y - 5)
        {
            transform.position = new Vector3(0f, screenSize.x - 15, 0f);
        }
         tempMousePos = Input.mousePosition;
    }
}
