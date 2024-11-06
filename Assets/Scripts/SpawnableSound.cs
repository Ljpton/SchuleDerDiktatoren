using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnableSound : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private bool dontDestroyOnLoad = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if (dontDestroyOnLoad) DontDestroyOnLoad(this);

        audioSource = GetComponent<AudioSource>();
        
        audioSource.pitch = Random.Range(0.85f, 1.1f);
        
        //Destroy(gameObject, 5);
    }
    
    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
