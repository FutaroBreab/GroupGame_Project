using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerTEST : MonoBehaviour
{
    //Set these bullet types to a bullet prefab
    public GameObject bullet;
    public GameObject heavyBullet;

    public int bulletType = 0;
    //BulletType Index:
    //0 = Regular Bullet
    //1 = Heavy Bullet



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //If X is held, shoot once, and then start to rapid fire after held
        if(Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            InvokeRepeating("SpawnBullet", 0.5f, 0.15f);
        }
        if(!Input.GetKey(KeyCode.X))
        {
            CancelInvoke();
        }

    }

    //Spawns a bullet
    void SpawnBullet()
    {
        
       

        if (bulletType == 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
        else if (bulletType == 1)
        {
            Instantiate(heavyBullet, transform.position, transform.rotation);
        }
    }

}
