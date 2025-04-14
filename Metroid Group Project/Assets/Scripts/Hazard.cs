using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Name: Connor Edgar
 * Last Updated: 4/14/2025
 * File responsible for Hazard management. Objects that deal damage when a player comes in contact with it.
*/

public class Hazard : MonoBehaviour
{

    /// <summary>
    /// Check if collision with player object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerScript>())
        {
            //Call on the lose a life function from the player script if the player takes damage
            collision.gameObject.GetComponent<PlayerScript>().LoseLife();

        }
    }

    //Checks for overlaps with the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerScript>())
        {
            //Call on the lose a life function from the player script if the player takes damage
            other.gameObject.GetComponent<PlayerScript>().LoseLife();

        }
    }

}
