using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private AudioManager audioManager;

    [SerializeField] private GameObject loadingHint;
    
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
        audioManager.PlayButtonSound();
        loadingHint.SetActive(true);
    }

    public void LoadPlakat()
    {
        SceneManager.LoadScene("Plakat");
        audioManager.PlayButtonSound();
        loadingHint.SetActive(true);
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        audioManager.PlayButtonSound();
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
        audioManager.PlayButtonSound();
        loadingHint.SetActive(true);
    }
}
