using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
        audioManager.PlayButtonSound();
    }
}
