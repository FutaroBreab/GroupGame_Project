using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Connor Edgar
 * 4/16/2025
 * Responsible for handling Powerups
 * 
*/
public class PowerUpScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public BulletSpawner bulletSpawner;
    public int xHealth;
    public int xJump;
    private int MaxHealth;
    public bool MaxHealthPowerUp = false;
    public bool MaxJumpPowerUp = false;
    public bool HeavyBulletsPowerUp = false;
    public bool HealthPack = false;

    private void Start()
    {
        MaxHealth = playerScript.playerHealth;
    }

    //Checks if player interacts with standard health pack.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerScript>())
        {
            if(MaxJumpPowerUp == true)
            {
                //increases jump amount twice as much
                playerScript.jumpStrength += 4;
            }

            if (HealthPack == true)
            {
                if (xHealth + playerScript.playerHealth > playerScript.maxHP)
                {
                    playerScript.playerHealth = playerScript.maxHP;
                }
                else playerScript.playerHealth += xHealth;
            }

            //Check if max power up is checked. If not checked it should default to standard healthpack
            if (MaxHealthPowerUp == true)
            {
                //increases max health and fully heals.
                playerScript.playerHealth = MaxHealth + 100;
            } else if (MaxHealth > playerScript.playerHealth)
            {
                playerScript.playerHealth += xHealth;

                //Supposed to keep health from going over. Definetely easier way to do this. Clamp?
                if (playerScript.playerHealth > MaxHealth)
                {
                    playerScript.playerHealth = MaxHealth;
                }

            }
            
            //Script to change bullets to heavy. Likely checking a bool if on in player script. Reference when available.
            if(HeavyBulletsPowerUp == true)
            {
                bulletSpawner.bulletType = 1;
            }

            Destroy(gameObject);
        }
    }

    

}
