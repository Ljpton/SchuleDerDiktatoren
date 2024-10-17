using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    private bool audioEnabled = true;
    
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private GameObject buttonSound;
    [SerializeField] private GameObject loseHealthSound;
    // Stamp Sound is handled in Stamp Object

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(gameObject); 
        }
        else 
        { 
            Instance = this; 
        } 
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
        
        if (GetMasterVolume() > -1)
        {
            audioEnabled = true;
        }
        else
        {
            audioEnabled = false;
        }
    }

    public void PlayButtonSound()
    {
        Instantiate(buttonSound);
    }

    public void PlayLoseHealthSound()
    {
        Instantiate(loseHealthSound);
    }

    public float GetMasterVolume()
    {
        audioMixer.GetFloat("MasterVolume", out var volume);

        return volume;
    }
    
    public bool ToggleAudioVolume()
    {
        if (audioEnabled)
        {
            audioMixer.SetFloat("MasterVolume", -80);
            audioEnabled = false;
        }
        else
        {
            audioMixer.SetFloat("MasterVolume", 0);
            audioEnabled = true;
        }

        return audioEnabled;
    }
}
