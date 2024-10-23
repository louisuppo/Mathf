using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ZombieMouvement : MonoBehaviour
{

    public Transform flics;

    public float alpha;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float opposite = (flics.transform.rotation.y - transform.rotation.y);
        float adjacent = (flics.transform.rotation.x - transform.rotation.x);


        alpha = Mathf.Atan2(opposite, adjacent) * (180 / Mathf.PI);
        transform.rotation  = Quaternion.Euler(0f , 0f, alpha);
    }
}
