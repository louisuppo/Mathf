using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float speed = 1;
    Vector2 screenSize;

    public float radius = 1;

    public enum AsteroidSize
    {
        Big,
        Medium,
        Small,
    }
    public GameObject AsteroidMEDIUM;
    public GameObject AsteroidSMALL;
    public AsteroidSize currentSize = AsteroidSize.Big;


    private void Start()
    {
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
    }
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        //SCREEN WARPE
        if (transform.position.x > screenSize.x / 2)
        {
            transform.position = new Vector3(-screenSize.x / 2, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -screenSize.x / 2)
        {
            transform.position = new Vector3(screenSize.x / 2, transform.position.y, transform.position.z);
        }

        if (transform.position.y > screenSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, -screenSize.y / 2, transform.position.z);
        }
        else if (transform.position.y < -screenSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, screenSize.y / 2, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("PRESS");

            GetDestroyed();
        }
    }



    void GetDestroyed()
    {

        Debug.Log("oUI");

        GameObject asteroid = null;
        if (currentSize == AsteroidSize.Big)
            asteroid = AsteroidMEDIUM;
        else if (currentSize == AsteroidSize.Medium)
            asteroid = AsteroidSMALL;
        if (asteroid != null) Destroy(asteroid);

        if (asteroid != null)
        {
            Instantiate(asteroid, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 359)));
            Instantiate(asteroid, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 359)));
        }

        Destroy(gameObject);
    }
}
