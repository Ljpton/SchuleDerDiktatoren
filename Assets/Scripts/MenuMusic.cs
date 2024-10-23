using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public static MenuMusic Instance { get; private set; }
    
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
        GameMusic gameMusic = FindObjectOfType<GameMusic>();
        
        if (gameMusic != null)
        {
            Destroy(gameMusic.gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }
}
