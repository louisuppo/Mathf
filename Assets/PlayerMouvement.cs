using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.position += new Vector3(0,speed * Time.deltaTime, 0);
    }
}
