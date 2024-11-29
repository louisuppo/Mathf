using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public SpaceShip ship;
    private Vector2 difference;
    private float SquareDistance;
    public float radius;

    public GameObject bullet;
    private Vector2 differenceB;

    private void Update()
    {
        difference = ship.transform.position - transform.position;
        SquareDistance = (difference.x * difference.x) + (difference.y * difference.y);
        if (ship && SquareDistance < ((ship.radius + radius) * (ship.radius + radius)))
        {
            ship.gameObject.SetActive(false);
        }

        differenceB = bullet.transform.position - transform.position;
        if (differenceB > radius)
        {
            Asteroid.GetDestroyed();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
