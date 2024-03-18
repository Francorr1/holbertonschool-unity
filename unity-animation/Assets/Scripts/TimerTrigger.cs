using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public MonoBehaviour timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer.enabled = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer.enabled = true;
        }
    }
}
