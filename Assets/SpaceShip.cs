using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class SpaceShip : MonoBehaviour
{
    Vector2 speed;
    public float accel;

    Vector2 screenSize;

    public float alpha;

    private Vector3 tempMousePos;

    public float radius;


    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;

    public float bulletSpeed = 10f;

    private GameObject bulletShot;
    private bool canShoot = true;

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

        //il y a un probleme ici, faut que le vaiseau continue sa route si la souris na pas bouger
        if ((distance>1f))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, alpha);

        }



        //D�placement
        transform.position += -transform.up * speed.x;
        Debug.Log(speed);

        if (Input.GetKeyDown(KeyCode.E))
        {
            speed += new Vector2(accel*Time.deltaTime, 0f);
        }


        // Screen wrapping
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

         tempMousePos = Input.mousePosition;


        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            projectileShot();
            canShoot = false;
            Invoke("Cooldown", 1f);
            if (GetComponent<SpriteRenderer>().enabled == false)
                SceneManager.LoadScene(0);

        }


    }

    public Vector3 GetBulletPosition()
    {
        if (bulletShot)
        {
            return bulletShot.transform.position;
        }
        return Vector3.positiveInfinity;
    }

    void projectileShot()
    {
        // Cr�er le projectile
        bulletShot = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Destroy(bulletShot, 1.0f);
        // R�cup�rer le Rigidbody2D du projectile et lui appliquer la vitesse
        Rigidbody2D bulletRb = bulletShot.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            bulletRb.velocity = -bulletSpawnPoint.up * bulletSpeed;
        }
    }

    void Cooldown()
    {
        canShoot = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
