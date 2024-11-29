using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public SpaceShip ship;
    private Vector2 diff;
    private float SquareDistance;
    public float radius;

    public float distanceB;
    private Vector2 diffB;


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
            //destroye la bullete
            //victoire si tous detrui
          //faire que ca fasse la fonction de splite
            Debug.Log("fdss");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
