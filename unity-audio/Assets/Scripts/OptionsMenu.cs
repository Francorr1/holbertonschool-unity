using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertedToggle;

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("PrevScene"));
    }

    public void Apply()
    {
        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        CameraController cameraControl = mainCamera.GetComponent<CameraController>();
        cameraControl.isInverted = invertedToggle.isOn;
    }
}
