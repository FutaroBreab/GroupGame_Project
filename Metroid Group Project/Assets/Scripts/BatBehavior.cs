using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//UNUSED FILE
//Brandt, Hunter
//4/21/2025
//Unused bat behavior
public class BatBehavior : MonoBehaviour
{

    public GameObject player;
    public bool chaseMode = false;
    public float chaseRange = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.transform.position.x > transform.position.x - chaseRange && player.transform.position.x < transform.position.x + chaseRange)
        {
            chaseMode = true;
        }

        if (chaseMode == true){

            transform.position = new Vector3(Mathf.Lerp(transform.position.x,player.transform.position.x,2f * Time.deltaTime), Mathf.Lerp(transform.position.y, player.transform.position.y+0.5f, 2f * Time.deltaTime), transform.position.z) ;

            
        }


    }
}
