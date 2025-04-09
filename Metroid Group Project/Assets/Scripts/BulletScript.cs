using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 15;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Death", 0.22f, 1);   
    }

    void Death()
    {
        Object.Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed,0,0) * Time.deltaTime;
    }
}
