using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnableSound : MonoBehaviour
{
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

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
