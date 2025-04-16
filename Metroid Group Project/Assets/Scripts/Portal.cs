using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Connor Edgar
 * 4/16/2025
 * Teleports player to chosen point
*/ 

public class Portal : MonoBehaviour
{
    public Transform portalExit;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = portalExit.position;
    }

}
