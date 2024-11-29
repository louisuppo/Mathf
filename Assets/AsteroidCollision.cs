using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public SpaceShip ship;
    private Vector2 diff;
    private float SquareDistance;
    public float radius;

    public float distanceB;
    private Vector2 diffB;

    private void Start()
    {
        if (ship == null)
        {
            GameObject shipObject = GameObject.Find("Ship"); // Recherche l'objet par son nom
            if (shipObject != null)
            {
                ship = shipObject.GetComponent<SpaceShip>(); // Associe le script SpaceShip
            }

        }
    }

    private void Update()
    {
        diff = ship.transform.position - transform.position;
        SquareDistance = (diff.x * diff.x) + (diff.y * diff.y);
        if (ship && SquareDistance < ((ship.radius + radius) * (ship.radius + radius)))
        {
            ship.gameObject.SetActive(false);

        }

        diffB = ship.GetBulletPosition() - transform.position;
        distanceB = diffB.sqrMagnitude;
        if (distanceB < radius*radius)
        {
            Destroy(ship.bulletShot);
            SpaceShip.ScoreAste ++;
            GetComponent<Asteroid>().GetDestroyed();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
