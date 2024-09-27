using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    
    [SerializeField] private TMP_Text roundCounter;
    [SerializeField] private TMP_Text healthText;
    
    // GAME SCREEN
    [SerializeField] private TMP_Text eventDescription;
    [SerializeField] private TMP_Text reactionText1;
    [SerializeField] private TMP_Text reactionText2;

    [SerializeField] private TMP_Text economyText;
    [SerializeField] private TMP_Text militaryText;
    [SerializeField] private TMP_Text scienceText;
    [SerializeField] private TMP_Text cultureText;

    [SerializeField] private TMP_Text civilRightsText;
    [SerializeField] private TMP_Text participationText;
    [SerializeField] private TMP_Text freedomOfSpeechText;
    [SerializeField] private TMP_Text separationOfPowerText;
    
    [SerializeField] private TMP_Text consultant1Reaction1Text;
    [SerializeField] private TMP_Text consultant1Reaction2Text;
    [SerializeField] private TMP_Text consultant2Reaction1Text;
    [SerializeField] private TMP_Text consultant2Reaction2Text;
    [SerializeField] private TMP_Text consultantDescriptionText1;
    [SerializeField] private TMP_Text consultantDescriptionText2;
    
    [SerializeField] private Button reactionButton1;
    [SerializeField] private Button reactionButton2;

    [SerializeField] private Button exchangeConsultantButton1;
    [SerializeField] private Button exchangeConsultantButton2;

    // BALANCE SCREEN
    [SerializeField] private GameObject balanceScreen;
    
    [SerializeField] private Slider economyBalanceSlider;
    [SerializeField] private Slider militaryBalanceSlider;
    [SerializeField] private Slider scienceBalanceSlider;
    [SerializeField] private Slider cultureBalanceSlider;

    [SerializeField] private Slider civilRightsBalanceSlider;
    [SerializeField] private Slider participationBalanceSlider;
    [SerializeField] private Slider freedomOfSpeechBalanceSlider;
    [SerializeField] private Slider separationOfPowerBalanceSlider;

    [SerializeField] private TMP_Text economyDeltaText;
    [SerializeField] private TMP_Text militaryDeltaText;
    [SerializeField] private TMP_Text scienceDeltaText;
    [SerializeField] private TMP_Text cultureDeltaText;

    [SerializeField] private TMP_Text civilRightsDeltaText;
    [SerializeField] private TMP_Text participationDeltaText;
    [SerializeField] private TMP_Text freedomOfSpeechDeltaText;
    [SerializeField] private TMP_Text separationOfPowerDeltaText;
    
    [SerializeField] private Button continueButton;

    [SerializeField] private TMP_Text democracySumText;
    [SerializeField] private TMP_Text resourcesSumText;

    [SerializeField] private TMP_Text healthRegenerationText;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.Log("GameManager couldn't be found.");
        }
    }

    public void SetRoundCounter(int round)
    {
        roundCounter.SetText("Runde: " + round);
    }

    public void SetEventDescription(string description)
    {
        eventDescription.SetText(description);
    }

    public void SetReactionText1(string text)
    {
        reactionText1.SetText(text);
    }

    public void SetReactionText2(string text)
    {
        reactionText2.SetText(text);
    }

    public void SetEconomyText(int value)
    {
        economyText.SetText("Wirtschaft: " + value);
    }
    
    public void SetMilitaryText(int value)
    {
        militaryText.SetText("Militär: " + value);
    }
    
    public void SetScienceText(int value)
    {
        scienceText.SetText("Forschung: " + value);
    }
    
    public void SetCultureText(int value)
    {
        cultureText.SetText("Kultur: " + value);
    }
    
    public void SetCivilRightsText(int value)
    {
        civilRightsText.SetText("Bürgerrechte: " + value);
    }
    
    public void SetParticipationText(int value)
    {
        participationText.SetText("Polit. Partizipation: " + value);
    }
    
    public void SetFreedomOfSpeechText(int value)
    {
        freedomOfSpeechText.SetText("Meinungsfreiheit: " + value);
    }
    
    public void SetSeparationOfPowerText(int value)
    {
        separationOfPowerText.SetText("Gewaltenteilung: " + value);
    }

    public void PressReactionButton1()
    {
        gameManager.Reaction1();
    }

    public void PressReactionButton2()
    {
        gameManager.Reaction2();
    }

    public void PressExchangeConsultantButton1()
    {
        gameManager.ExchangeConsultant1();
    }

    public void SetExchangeConsultantButton1Enabled(bool enabled)
    {
        exchangeConsultantButton1.interactable = enabled;
    }

    public void PressExchangeConsultantButton2()
    {
        gameManager.ExchangeConsultant2();
    }
    
    public void SetExchangeConsultantButton2Enabled(bool enabled)
    {
        exchangeConsultantButton2.interactable = enabled;
    }

    public void SetConsultant1Reaction1Text(string text)
    {
        consultant1Reaction1Text.SetText(text);
    }
    
    public void SetConsultant1Reaction2Text(string text)
    {
        consultant1Reaction2Text.SetText(text);
    }
    
    public void SetConsultant2Reaction1Text(string text)
    {
        consultant2Reaction1Text.SetText(text);
    }
    
    public void SetConsultant2Reaction2Text(string text)
    {
        consultant2Reaction2Text.SetText(text);
    }

    public void SetConsultantDescriptionText1(string text)
    {
        consultantDescriptionText1.SetText(text);
    }

    public void SetConsultantDescriptionText2(string text)
    {
        consultantDescriptionText2.SetText(text);
    }

    public void SetEconomyBalanceSlider(int value)
    {
        economyBalanceSlider.value = value;
    }
    
    public void SetMilitaryBalanceSlider(int value)
    {
        militaryBalanceSlider.value = value;
    }
    
    public void SetScienceBalanceSlider(int value)
    {
        scienceBalanceSlider.value = value;
    }
    
    public void SetCultureBalanceSlider(int value)
    {
        cultureBalanceSlider.value = value;
    }
    
    public void SetCivilRightsBalanceSlider(int value)
    {
        civilRightsBalanceSlider.value = value;
    }
    
    public void SetParticipationBalanceSlider(int value)
    {
        participationBalanceSlider.value = value;
    }
    
    public void SetFreedomOfSpeechBalanceSlider(int value)
    {
        freedomOfSpeechBalanceSlider.value = value;
    }
    
    public void SetSeparationOfPowerBalanceSlider(int value)
    {
        separationOfPowerBalanceSlider.value = value;
    }

    public void SetEconomyDeltaText(int delta)
    {
        string str = "";
        
        if (delta >= 0)
        {
            str += "+";
        }

        str += delta.ToString();
        
        economyDeltaText.SetText(str);
    }
    
    public void SetMilitaryDeltaText(int delta)
    {
        string str = "";
        
        if (delta >= 0)
        {
            str += "+";
        }

        str += delta.ToString();
        
        militaryDeltaText.SetText(str);
    }
    
    public void SetScienceDeltaText(int delta)
    {
        string str = "";
        
        if (delta >= 0)
        {
            str += "+";
        }

        str += delta.ToString();

        scienceDeltaText.SetText(str);
    }
    
    public void SetCultureDeltaText(int delta)
    {
        string str = "";
        
        if (delta >= 0)
        {
            str += "+";
        }

        str += delta.ToString();

        cultureDeltaText.SetText(str);
    }
    
    public void SetCivilRightsDeltaText(int delta)
    {
        string str = "";
        
        if (delta >= 0)
        {
            str += "+";
        }

        str += delta.ToString();

        civilRightsDeltaText.SetText(str);
    }

    public void ClearCivilRightsDeltaText()
    {
        civilRightsDeltaText.SetText("");
    }
    
    public void SetParticipationDeltaText(int delta)
    {
        string str = "";
        
        if (delta >= 0)
        {
            str += "+";
        }

        str += delta.ToString();

        participationDeltaText.SetText(str);
    }
    
    public void ClearParticipationDeltaText()
    {
        participationDeltaText.SetText("");
    }
    
    public void SetFreedomOfSpeechDeltaText(int delta)
    {
        string str = "";
        
        if (delta >= 0)
        {
            str += "+";
        }

        str += delta.ToString();

        freedomOfSpeechDeltaText.SetText(str);
    }
    
    public void ClearFreedomOfSpeechDeltaText()
    {
        freedomOfSpeechDeltaText.SetText("");
    }
    
    public void SetSeparationOfPowerDeltaText(int delta)
    {
        string str = "";
        
        if (delta >= 0)
        {
            str += "+";
        }

        str += delta.ToString();

        separationOfPowerDeltaText.SetText(str);
    }
    
    public void ClearSeparationOfPowerDeltaText()
    {
        separationOfPowerDeltaText.SetText("");
    }

    public void SetBalanceScreenVisible(bool visible)
    { 
        balanceScreen.SetActive(visible);
    }

    public void PressContinueButton()
    {
        gameManager.EndBalance();
    }

    public void SetDemocracySumText(int value)
    {
        string str = "";
        
        if (value >= 0)
        {
            str += "+";
        }

        str += value.ToString();

        democracySumText.SetText(str);
    }
    
    public void SetResourcesSumText(int value)
    {
        string str = "";
        
        if (value >= 0)
        {
            str += "+";
        }

        str += value.ToString();

        resourcesSumText.SetText(str);
    }

    public void SetHealthText(int value)
    {
        healthText.SetText("Gesetzesverstöße: " + value);
    }

    public void SetHealthRegenerationTextVisible(bool visible)
    {
        healthRegenerationText.gameObject.SetActive(visible);
    }
}
