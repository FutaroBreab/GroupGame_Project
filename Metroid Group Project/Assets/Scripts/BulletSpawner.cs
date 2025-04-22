using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Brandt, Hunter
//4/21/2025
//Bullet projectile SPAWNER script
public class BulletSpawner : MonoBehaviour
{
    //Set these bullet types to a bullet prefab
    public GameObject bullet;
    public GameObject heavyBullet;

    //To check player direction for bullet direction
    public GameObject player;
  
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
            /*
            GameObject bulletspawn = Instantiate(bullet, transform.position, transform.rotation);
            bulletspawn.GetComponent<BulletScript>().direction = player.GetComponent<PlayerScript>().direction;
            */
            SpawnBullet();
            //InvokeRepeating("SpawnBullet", 0.5f, 0.15f);
            InvokeRepeating("SpawnBullet", 0.5f, 0.5f);

        }
        if (!Input.GetKey(KeyCode.X))
        {
            CancelInvoke();
        }

    }

    //Spawns a bullet
    void SpawnBullet()
    {


        //checks type
        if (bulletType == 0)
        {
            GameObject bulletspawn = Instantiate(bullet, transform.position, transform.rotation);
            bulletspawn.GetComponent<BulletScript>().direction = player.GetComponent<PlayerScript>().direction;
        }
        else if (bulletType == 1)
        {
            GameObject bulletspawn = Instantiate(heavyBullet, transform.position, transform.rotation);
            bulletspawn.GetComponent<BulletScript>().direction = player.GetComponent<PlayerScript>().direction;
        }
    }
}
