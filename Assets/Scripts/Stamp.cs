using UnityEngine;
using UnityEngine.EventSystems;

public class Stamp : MonoBehaviour, IPointerClickHandler
{
    private GameObject spawnedStamp;
    
    private GameManager gameManager;
    private AudioManager audioManager;
    private UIManager uiManager;

    [SerializeField] private GameObject stampObject;
    
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!spawnedStamp) // Check if stamp doesn't exist
        {
            var canvas = FindObjectOfType<Canvas>();
            var screenPosition = eventData.position;
            var uiCamera = canvas.worldCamera;
            var planeDistance = canvas.planeDistance;
            
            Vector3 worldPosition = uiCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, planeDistance));
            
            spawnedStamp = Instantiate(stampObject, worldPosition, Quaternion.Euler(0, 0, Random.Range(-15f, 15f)));
            spawnedStamp.transform.SetParent(gameObject.transform);
            spawnedStamp.transform.localScale = Vector3.one * 2;
        }
        
        Invoke(nameof(NotifyStamp), 2);
        
        Destroy(spawnedStamp, 3);
    }

    public void NotifyStamp()
    {
        gameManager.Stamped();
    }
}
