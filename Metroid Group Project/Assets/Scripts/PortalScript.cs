using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Transform portalExit;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = portalExit.position;
        other.GetComponent<PlayerScript>().respawnPoint = portalExit.position;
    }

    
}
