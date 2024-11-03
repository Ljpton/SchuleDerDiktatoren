using UnityEngine;

public class Hint : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void PressOkayButton()
    {
        audioManager.PlayButtonSound();
        
        Destroy(gameObject);
    }
}