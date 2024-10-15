using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;

    private bool optionsMenuVisible = false;
    
    // INFO SCREEN
    [SerializeField] private TMP_Text roundCounter;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Slider legislativeTermSlider;

    [SerializeField] private Image soundButtonImage;
    [SerializeField] private Sprite soundOnImage;
    [SerializeField] private Sprite soundOffImage;

    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private Image optionsButtonImage;
    [SerializeField] private Sprite menuImage;
    [SerializeField] private Sprite closeImage;
    
    // EVENT SCREEN
    [SerializeField] private TMP_Text eventDescription;
    [SerializeField] private Button continueEventButton;
    
    // DECISION SCREEN
    [SerializeField] private GameObject decisionScreen;
    
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

    [SerializeField] private RectTransform reaction1;
    [SerializeField] private RectTransform reaction2;

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
    
    [SerializeField] private TMP_Text civilRightsLawText;
    [SerializeField] private TMP_Text participationLawText;
    [SerializeField] private TMP_Text freedomOfSpeechLawText;
    [SerializeField] private TMP_Text separationOfPowerLawText;
    
    [SerializeField] private Button continueButton;

    [SerializeField] private TMP_Text democracySumText;
    [SerializeField] private TMP_Text resourcesSumText;

    [SerializeField] private TMP_Text healthRegenerationText;
    
    // NEW LAW SCREEN
    [SerializeField] private GameObject newLawScreen;

    [SerializeField] private TMP_Text lawText;
    
    // NEWS SCREEN
    [SerializeField] private GameObject newsScreen;

    [SerializeField] private TMP_Text newsText;
    [SerializeField] private Image newsImage;
    
    // GAME OVER SCREEN
    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text gameOverLabelText;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.Log("GameManager couldn't be found.");
        }

        float volume;

        gameManager.audioMixer.GetFloat("MasterVolume", out volume);
        
        if (volume > -1)
        {
            soundButtonImage.sprite = soundOnImage;
        }
        else
        {
            soundButtonImage.sprite = soundOffImage;
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
        civilRightsText.SetText("Menschenrechte: " + value);
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
        healthText.SetText("Leben: " + value);
    }

    public void SetHealthRegenerationTextVisible(bool visible)
    {
        healthRegenerationText.gameObject.SetActive(visible);
    }

    public void SetGameOverScreenVisible(bool visible)
    {
        gameOverScreen.SetActive(visible);
    }

    public void SetGameOverText(string text)
    {
        gameOverText.SetText(text);
    }

    public void SetGameOverLabelText(string text)
    {
        gameOverLabelText.SetText(text);
    }

    public void PressMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SetDecisionScreenVisible(bool visible)
    {
        decisionScreen.SetActive(visible);
    }

    public void SetLegislativeTermSliderValue(int value)
    {
        legislativeTermSlider.value = value;
    }

    public void PressContinueEventButton()
    {
        gameManager.ContinueEvent();
    }

    public void SetNewLawScreenVisibility(bool visible)
    {
        newLawScreen.SetActive(visible);
    }

    public void SetLawText(string text)
    {
        lawText.SetText(text);
    }

    public void SetNewsScreenVisibility(bool visible)
    {
        newsScreen.SetActive(visible);
    }

    public void SetNewsText(string text)
    {
        newsText.SetText(text);
    }

    public void PressNewsContinueButton()
    {
        gameManager.StartRoundAfterNewLaw();
    }

    public void SwapReactionButtons()
    {
        Vector3 pos1 = reaction1.position;
        Vector3 pos2 = reaction2.position;

        reaction1.position = pos2;
        reaction2.position = pos1;
    }

    public void SetCivilRightsEnshrined()
    {
        civilRightsBalanceSlider.gameObject.SetActive(false);
        civilRightsLawText.gameObject.SetActive(true);
    }
    
    public void SetFreedomOfSpeechEnshrined()
    {
        freedomOfSpeechBalanceSlider.gameObject.SetActive(false);
        freedomOfSpeechLawText.gameObject.SetActive(true);
    }
    
    public void SetParticipationEnshrined()
    {
        participationBalanceSlider.gameObject.SetActive(false);
        participationLawText.gameObject.SetActive(true);
    }
    
    public void SetSeparationOfPowerEnshrined()
    {
        separationOfPowerBalanceSlider.gameObject.SetActive(false);
        separationOfPowerLawText.gameObject.SetActive(true);
    }

    public void PressSoundButton()
    {
        bool audioEnabled = gameManager.ToggleAudioVolume();

        if (audioEnabled)
        {
            soundButtonImage.sprite = soundOnImage;
        }
        else
        {
            soundButtonImage.sprite = soundOffImage;
        }
    }

    public void PressOptionsButton()
    {
        if (optionsMenuVisible)
        {
            optionsButtonImage.sprite = menuImage;
            optionsMenu.SetActive(false);
            optionsMenuVisible = false;
        }
        else
        {
            optionsButtonImage.sprite = closeImage;
            optionsMenu.SetActive(true);
            optionsMenuVisible = true;
        }
    }
}
