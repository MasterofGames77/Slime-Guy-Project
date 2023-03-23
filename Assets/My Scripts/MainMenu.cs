using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsScreen;

    public GameObject creditsScreen;

    public GameObject optionsScreen;

    // Called Zero
    void Awake()
    {
        Debug.Log("Awake!");
    }

    // Called First
    void OnEnable()
    {
        Debug.Log("OnEnable Called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Called Second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    // Called Third
    void Start()
    {
        Debug.Log("Start");
    }

    // Called when the scene is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
        Time.timeScale = 1f;
    }

    public void OpenControls()
    {
        controlsScreen.SetActive(true);
    }

    public void CloseControls()
    {
        controlsScreen.SetActive(false);
    }

    public void OpenCredits()
    {
        creditsScreen.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsScreen.SetActive(false);
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
