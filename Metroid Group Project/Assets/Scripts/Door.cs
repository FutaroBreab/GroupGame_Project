using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int hp = 3;
    private float hitFlash = 0;

    public void HitByBullet()
    {
        hp -= 1;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        hitFlash = 0.1f;

        //gameObject.GetComponent<Renderer>().material.color = new Color(0 + (3 - hp) * 50, 0 + (3 - hp) * 50, 200+(3-hp)*50);
        //gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(50, 50, 50, 1));
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
       // gameObject.GetComponent<Renderer>().material.color = new Color(50,50,50, 1);

    }

    // Update is called once per frame
    void Update()
    {
        if (hitFlash > 0)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(50, 50, 50, 1);
            hitFlash -= 1 * Time.deltaTime;
        } else
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1);
        }
    }
}
