using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private float previousTimeScale;
    public GameObject Camera;
    public GameObject PauseCanvas;

    void Start()
    {
        PauseCanvas.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        Camera.GetComponent<CameraController>().enabled = false;
        PauseCanvas.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = previousTimeScale;
        Camera.GetComponent<CameraController>().enabled = true;
        PauseCanvas.SetActive(false);
    }
    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
    public void Options()
    {
        PlayerPrefs.SetInt("PrevScene", SceneManager.GetActiveScene().buildIndex);
        Resume();
        SceneManager.LoadScene("Options");
    }
}
