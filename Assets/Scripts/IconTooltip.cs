using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IconTooltip : MonoBehaviour
{
    public Categories currentCategory = Categories.CivilRights;

    private GameObject tooltip;
    private TMP_Text text;

    private void Start()
    {
        tooltip = transform.GetChild(0).gameObject;
        text = tooltip.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
    }

    public void ShowTooltip()
    {
        tooltip.SetActive(true);
        
        text.SetText(currentCategory.GetDescription());
        
        Invoke(nameof(HideTooltip), 5);
    }

    private void HideTooltip()
    {
        tooltip.SetActive(false);
    }
}
