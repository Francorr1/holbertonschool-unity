using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public MonoBehaviour timer;
    public Text timerText;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer.enabled = false;
            timerText.color = Color.green;
            timerText.fontSize = 60;
        }
    }
}
