using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    private AudioManager audioManager;
    
    private int currentScreenIndex = 0;

    [SerializeField] private TMP_Text backButtonText; 
    [SerializeField] private GameObject[] tutorialScreens;
    
    // Start is called before the first frame update
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        
        backButtonText.text = "Menü";
        ShowTutorialScreen(currentScreenIndex);
    }

    public void PressContinueButton()
    {
        audioManager.PlayButtonSound();
        currentScreenIndex++;
        ShowTutorialScreen(currentScreenIndex);
    }

    public void PressBackButton()
    {
        audioManager.PlayButtonSound();
        
        if (currentScreenIndex <= 0)
        {
            SceneManager.LoadScene("Menu");
            return;
        }
        
        currentScreenIndex--;
        ShowTutorialScreen(currentScreenIndex);
    }

    private void ShowTutorialScreen(int index)
    {
        if (index > 0)
        {
            backButtonText.text = "Zurück";
        }
        else
        {
            backButtonText.text = "Menü";
        }
        
        if (index >= tutorialScreens.Length)
        {
            SceneManager.LoadScene("Game");
            return;
        }
        
        for (var i = 0; i < tutorialScreens.Length; i++)
        {
            tutorialScreens[i].SetActive(index == i); // Set only selected screen visible
        }
    }
}
