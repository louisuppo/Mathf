using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpaceShip : MonoBehaviour
{
    Vector2 speed;
    public float accel;

    Vector2 screenSize;

    private void Start()
    {
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);

    }

    void Update()
    {
        transform.position += new Vector3(speed.x, 0f, 0f);
        Debug.Log("speed :"+ speed );


        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("oui");
            speed += new Vector2(accel*Time.deltaTime, 0f);
        }

        if (transform.position.x > screenSize.x-5)
        {
            transform .position = new Vector3(screenSize.x-30, 0f, 0f);
        }
    }
}
