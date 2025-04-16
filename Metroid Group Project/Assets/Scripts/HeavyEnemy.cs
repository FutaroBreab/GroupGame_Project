using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
