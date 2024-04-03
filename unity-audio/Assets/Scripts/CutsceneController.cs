using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject timerCanvas;
    public GameObject player;
    public MonoBehaviour playerController;

    void Start()
    {
        mainCamera.SetActive(false);
        timerCanvas.SetActive(false);
        playerController.enabled = false;
    }

    public void AnimationFinished()
    {
        mainCamera.SetActive(true);
        timerCanvas.SetActive(true);
        playerController.enabled = true;
        gameObject.SetActive(false);
    }
}
