using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Brandt, Hunter
//4/21/2025
//Bullet projectile script (normal & heavy)
public class BulletScript : MonoBehaviour
{
    public int bulletDamage = 1;
    public float speed = 19;
    public int direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Death", 0.25f, 1);   
        if (direction == 0)
        {
            speed *= -1;
        }
    }

    //This kills the crab
    void Death()
    {
        Object.Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed,0,0) * Time.deltaTime;
    }





    //BULLET COLLISIONS YEAAA COLLISIONS
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.GetComponent<Door>())
        {
        
        other.gameObject.GetComponent<Door>().HitByBullet();
        Destroy(gameObject);

        }

        // takes away health from the heavy enemy though bullet detection

        if (other.gameObject.GetComponent<HeavyEnemy>())
        {
            other.gameObject.GetComponent<HeavyEnemy>().TakeDamage(bulletDamage);
            Destroy(gameObject);

        }

        // takes away health from the light enemy though bullet detection
        if (other.gameObject.GetComponent<LightEnemyScript>())
        {


            other.gameObject.GetComponent<LightEnemyScript>().TakeDamage(bulletDamage);
            Destroy(gameObject);

        }

    }
}
