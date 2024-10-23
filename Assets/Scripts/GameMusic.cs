using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public static GameMusic Instance { get; private set; }
    
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
    
    // Start is called before the first frame update
    void Start()
    {
        MenuMusic menuMusic = FindObjectOfType<MenuMusic>();
        
        if (menuMusic != null)
        {
            Destroy(menuMusic.gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }
}
