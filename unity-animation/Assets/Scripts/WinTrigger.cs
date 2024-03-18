using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public MonoBehaviour timer;
    public Text timerText;
    public GameObject winCanvas;
    public GameObject finalTime;

    void Start()
    {
        winCanvas.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer.enabled = false;
            timerText.color = Color.green;
            timerText.fontSize = 60;
            winCanvas.SetActive(true);
            TextMeshPro finalTimeTMP = finalTime.GetComponent<TextMeshPro>();
            if (finalTimeTMP != null)
            {
                finalTimeTMP.text = timerText.text;
            }
            else
            {
                Debug.LogError("Could not find TextMeshPro component");
            }
        }
    }
}
