using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Authors: Christian Gomez-Ruiz
 * 4/17/2025
 * Handles the simple teleportation between parts of the levels
*/
public class PortalScript : MonoBehaviour
{
    public Transform portalExit;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = portalExit.position;
        other.GetComponent<PlayerScript>().respawnPoint = portalExit.position;
    }

    
}
