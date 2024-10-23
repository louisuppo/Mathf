using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ZombieMouvement : MonoBehaviour
{
    public float alpha;
    public Transform flics;

    void Update()
    {
        float opposite = (flics.transform.rotation.y - transform.rotation.y);
        float adjacent = (flics.transform.rotation.x - transform.rotation.x);

        alpha = Mathf.Atan2(opposite, adjacent) * (180 / Mathf.PI);


        transform.rotation  = Quaternion.Euler(0f , 0f, alpha);
    }
}
