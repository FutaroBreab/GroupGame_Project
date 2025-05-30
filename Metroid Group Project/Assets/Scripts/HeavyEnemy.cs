using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Authors: Christian Gomez-Ruiz
 * 4/16/2025
 * Handles the interactions of the heavy enemies with their health and death
*/
public class HeavyEnemy : MonoBehaviour
{
    public int health = 10;
    public float speed = 1f;
    public Vector3 direction;
    public Transform leftPoint;
    public Transform rightPoint;

    private Vector3 leftStart;
    private Vector3 rightStart;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.right;
        leftStart = leftPoint.position;
        rightStart = rightPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();

        // This should be Checking constantly if the enemy has any health
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //this should subtract the bullet damage from the enemies health
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    //player collision
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<PlayerScript>())
        {
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(15);
        }

    }

    private void EnemyMovement()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.x < leftStart.x)
        {
            direction = Vector3.right;
        }
        if (transform.position.x > rightStart.x)
        {
            direction = Vector3.left;
        }

    }
}
