using UnityEngine;
using UnityEngine.EventSystems;

public class Stamp : MonoBehaviour, IPointerClickHandler
{
    private GameObject spawnedStamp;
    
    private GameManager gameManager;
    private UIManager uiManager;

    [SerializeField] private GameObject stampObject;
    
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!spawnedStamp) // Check if stamp doesn't exist
        {
            spawnedStamp = Instantiate(stampObject, eventData.position, Quaternion.Euler(0, 0, Random.Range(-15f, 15f)));
            spawnedStamp.transform.SetParent(gameObject.transform);
        }
        
        Invoke(nameof(NotifyStamp), 2);
        
        Destroy(spawnedStamp, 3);
    }

    public void NotifyStamp()
    {
        gameManager.Stamped();
    }
}
