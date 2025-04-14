using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Manager : MonoBehaviour
{
    public PlayerScript playerScript;
    public TMP_Text healthText;

    private void Update()
    {
        healthText.text = "Health: " + playerScript.playerHealth;
    }
}
