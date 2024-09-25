using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MySlider : MonoBehaviour
{
    [SerializeField] private TMP_Text valueText;
    
    private Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        
        // Initially set value
        valueText.SetText(slider.value.ToString());
        
        slider.onValueChanged.AddListener(delegate { UpdateValueText(); });
    }

    private void UpdateValueText()
    {
        valueText.SetText(slider.value.ToString());
    }
}
