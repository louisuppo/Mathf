using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagMouvement : MonoBehaviour
{
    Vector2 screenSize;
    Vector2 flagSize;
    public float _horizontalSpeed = -10;
    public float _verticalSpeed = 10;



    void Start()
    {

        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        flagSize = GetComponent<SpriteRenderer>().bounds.size;
    }

    private void Update()
    {
        transform.position += new Vector3 (_horizontalSpeed*Time.deltaTime, _verticalSpeed*Time.deltaTime, 0);
        if (transform.position.x > screenSize.x/2 || transform.position.x < -screenSize.x/2)
        {
            _horizontalSpeed = -_horizontalSpeed;
        }
        if (transform.position.y > screenSize.y/2 || transform.position.y < -screenSize.y/2)
        {
            _verticalSpeed = -_verticalSpeed;
        }
    }
}
