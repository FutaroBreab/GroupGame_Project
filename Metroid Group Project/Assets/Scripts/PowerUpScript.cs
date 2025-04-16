using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public int xHealth;
    public int xJump;
    private int MaxHealth;

    private void Start()
    {
        MaxHealth = playerScript.playerHealth;
    }

    //Checks if player interacts with health pack.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerScript>())
        {
            Destroy(gameObject);
            
            playerScript.playerHealth += xHealth;

            playerScript.jumpStrength += xJump;
        }
    }

    

}
