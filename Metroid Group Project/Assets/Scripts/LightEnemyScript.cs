using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemyScript : MonoBehaviour
{
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
