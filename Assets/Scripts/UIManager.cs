using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;
    
    private bool optionsMenuVisible;
    
    // INFO SCREEN
    [Category("Info Screen")]
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
    [Category("Event Screen")]
    [SerializeField] private GameObject eventScreen;
    [SerializeField] private TMP_Text eventDescription;
    [SerializeField] private Button continueEventButton;
    
    // DECISION SCREEN
    [Category("Decision Screen")]
    [SerializeField] private GameObject decisionScreen;
    
    [SerializeField] private TMP_Text reactionText1;
    [SerializeField] private TMP_Text reactionText2;
    
    [SerializeField] private TMP_Text consultant1Reaction1Text;
    [SerializeField] private TMP_Text consultant1Reaction2Text;
    [SerializeField] private TMP_Text consultant2Reaction1Text;
    [SerializeField] private TMP_Text consultant2Reaction2Text;
    
    [SerializeField] private Button reactionButton1;
    [SerializeField] private Button reactionButton2;

    [SerializeField] private Button exchangeConsultantButton1;
    [SerializeField] private Button exchangeConsultantButton2;

    [SerializeField] private RectTransform reaction1;
    [SerializeField] private RectTransform reaction2;
    
    [SerializeField] private Image consultant1CategoryIcon1;
    [SerializeField] private Image consultant1CategoryIcon2;
    [SerializeField] private Image consultant2CategoryIcon1;
    [SerializeField] private Image consultant2CategoryIcon2;

    [SerializeField] private Sprite[] economyConsultants;
    [SerializeField] private Sprite[] militaryConsultants;
    [SerializeField] private Sprite[] scienceConsultants;
    [SerializeField] private Sprite[] cultureConsultants;
    [SerializeField] private Sprite[] civilRightsConsultants;
    [SerializeField] private Sprite[] freedomOfSpeechConsultants;
    [SerializeField] private Sprite[] participationConsultants;
    [SerializeField] private Sprite[] separationOfPowerConsultants;

    [SerializeField] private Image consultant1Image;
    [SerializeField] private Image consultant2Image;
    
    [SerializeField] private Sprite economyUpIcon;
    [SerializeField] private Sprite economyDownIcon;
    [SerializeField] private Sprite militaryUpIcon;
    [SerializeField] private Sprite militaryDownIcon;
    [SerializeField] private Sprite scienceUpIcon;
    [SerializeField] private Sprite scienceDownIcon;
    [SerializeField] private Sprite cultureUpIcon;
    [SerializeField] private Sprite cultureDownIcon;
    [SerializeField] private Sprite civilRightsUpIcon;
    [SerializeField] private Sprite civilRightsDownIcon;
    [SerializeField] private Sprite freedomOfSpeechUpIcon;
    [SerializeField] private Sprite freedomOfSpeechDownIcon;
    [SerializeField] private Sprite participationUpIcon;
    [SerializeField] private Sprite participationDownIcon;
    [SerializeField] private Sprite separationOfPowerUpIcon;
    [SerializeField] private Sprite separationOfPowerDownIcon;
    [SerializeField] private Sprite economyEqualIcon;
    [SerializeField] private Sprite militaryEqualIcon;
    [SerializeField] private Sprite scienceEqualIcon;
    [SerializeField] private Sprite cultureEqualIcon;
    [SerializeField] private Sprite civilRightsEqualIcon;
    [SerializeField] private Sprite freedomOfSpeechEqualIcon;
    [SerializeField] private Sprite participationEqualIcon;
    [SerializeField] private Sprite separationOfPowerEqualIcon;
    
    [SerializeField] private Sprite civilRightsLawIcon;
    [SerializeField] private Sprite freedomOfSpeechLawIcon;
    [SerializeField] private Sprite participationLawIcon;
    [SerializeField] private Sprite separationOfPowerLawIcon;
    
    [SerializeField] private Sprite economyIcon;
    [SerializeField] private Sprite militaryIcon;
    [SerializeField] private Sprite scienceIcon;
    [SerializeField] private Sprite cultureIcon;
    [SerializeField] private Sprite civilRightsIcon;
    [SerializeField] private Sprite freedomOfSpeechIcon;
    [SerializeField] private Sprite participationIcon;
    [SerializeField] private Sprite separationOfPowerIcon;

    [SerializeField] private Image reaction1Consultant1Icon1;
    [SerializeField] private Image reaction1Consultant1Icon2;
    [SerializeField] private Image reaction1Consultant2Icon1;
    [SerializeField] private Image reaction1Consultant2Icon2;
    
    [SerializeField] private Image reaction2Consultant1Icon1;
    [SerializeField] private Image reaction2Consultant1Icon2;
    [SerializeField] private Image reaction2Consultant2Icon1;
    [SerializeField] private Image reaction2Consultant2Icon2;

    // BALANCE SCREEN
    [Category("Balance Screen")]
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
    
    // NEW LAW SCREEN
    [Category("New Law Screen")]
    [SerializeField] private GameObject newLawScreen;

    [SerializeField] private TMP_Text lawText;
    
    // NEWS SCREEN
    [Category("News Screen")]
    [SerializeField] private GameObject newsScreen;

    [SerializeField] private TMP_Text newsText;
    [SerializeField] private Image newsImage;
    
    // GAME OVER SCREEN
    [Category("Game Over Screen")]
    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text gameOverLabelText;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();

        if (gameManager == null)
        {
            Debug.Log("GameManager couldn't be found.");
        }
        
        soundButtonImage.sprite = audioManager.GetMasterVolume() > -1 ? soundOnImage : soundOffImage;
    }

    public void SetEventScreenActive()
    {
        balanceScreen.SetActive(false);
        decisionScreen.SetActive(false);
        
        eventScreen.SetActive(true);
        
        newsScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        newLawScreen.SetActive(false);
    }
    
    public void SetRoundCounter(int round)
    {
        roundCounter.SetText("Runde: " + round);
    }

    public void SetEventDescription(string description)
    {
        eventDescription.SetText(description);
    }

    public void SetReaction1Consultant1Icon1(Categories category, int value, bool enshrined = false)
    {
        reaction1Consultant1Icon1.sprite = ChooseSpriteFromCategoryAndValue(category, value, enshrined);
    }
    
    public void SetReaction1Consultant1Icon2(Categories category, int value, bool enshrined = false)
    {
        reaction1Consultant1Icon2.sprite = ChooseSpriteFromCategoryAndValue(category, value, enshrined);
    }
    
    public void SetReaction1Consultant2Icon1(Categories category, int value, bool enshrined = false)
    {
        reaction1Consultant2Icon1.sprite = ChooseSpriteFromCategoryAndValue(category, value, enshrined);
    }
    
    public void SetReaction1Consultant2Icon2(Categories category, int value, bool enshrined = false)
    {
        reaction1Consultant2Icon2.sprite = ChooseSpriteFromCategoryAndValue(category, value, enshrined);
    }
    
    public void SetReaction2Consultant1Icon1(Categories category, int value, bool enshrined = false)
    {
        reaction2Consultant1Icon1.sprite = ChooseSpriteFromCategoryAndValue(category, value, enshrined);
    }
    
    public void SetReaction2Consultant1Icon2(Categories category, int value, bool enshrined = false)
    {
        reaction2Consultant1Icon2.sprite = ChooseSpriteFromCategoryAndValue(category, value, enshrined);
    }
    
    public void SetReaction2Consultant2Icon1(Categories category, int value, bool enshrined = false)
    {
        reaction2Consultant2Icon1.sprite = ChooseSpriteFromCategoryAndValue(category, value, enshrined);
    }
    
    public void SetReaction2Consultant2Icon2(Categories category, int value, bool enshrined = false)
    {
        reaction2Consultant2Icon2.sprite = ChooseSpriteFromCategoryAndValue(category, value, enshrined);
    }

    private Sprite ChooseSpriteFromCategoryAndValue(Categories category, int value, bool enshrined)
    {
        if (category == Categories.Economy)
        {
            if (value == 0) return economyEqualIcon;
            return value > 0 ? economyUpIcon : economyDownIcon;
        }
        
        if (category == Categories.Military)
        {
            if (value == 0) return militaryEqualIcon;
            return value > 0 ? militaryUpIcon : militaryDownIcon;
        }
        
        if (category == Categories.Science)
        {
            if (value == 0) return scienceEqualIcon;
            return value > 0 ? scienceUpIcon : scienceDownIcon;
        }
        
        if (category == Categories.Culture)
        {
            if (value == 0) return cultureEqualIcon;
            return value > 0 ? cultureUpIcon : cultureDownIcon;
        }
        
        if (category == Categories.CivilRights)
        {
            if (enshrined) return civilRightsLawIcon;
            if (value == 0) return civilRightsEqualIcon;
            return value > 0 ? civilRightsUpIcon : civilRightsDownIcon;
        }
        
        if (category == Categories.FreedomOfSpeech)
        {
            if (enshrined) return freedomOfSpeechLawIcon;
            if (value == 0) return freedomOfSpeechEqualIcon;
            return value > 0 ? freedomOfSpeechUpIcon : freedomOfSpeechDownIcon;
        }
        
        if (category == Categories.Participation)
        {
            if (enshrined) return participationLawIcon;
            if (value == 0) return participationEqualIcon;
            return value > 0 ? participationUpIcon : participationDownIcon;
        }
        
        if (category == Categories.SeparationOfPower)
        {
            if (enshrined) return separationOfPowerLawIcon;
            if (value == 0) return separationOfPowerEqualIcon;
            return value > 0 ? separationOfPowerUpIcon : separationOfPowerDownIcon;
        }

        return null;
    }
    
    public void SetReactionText1(string text)
    {
        reactionText1.SetText(text);
    }

    public void SetReactionText2(string text)
    {
        reactionText2.SetText(text);
    }

    public void PressReactionButton1()
    {
        audioManager.PlayButtonSound();
        gameManager.Reaction1();
    }

    public void PressReactionButton2()
    {
        audioManager.PlayButtonSound();
        gameManager.Reaction2();
    }

    public void PressExchangeConsultantButton1()
    {
        audioManager.PlayButtonSound();
        gameManager.ExchangeConsultant1();
    }

    public void SetExchangeConsultantButton1Enabled(bool enabled)
    {
        exchangeConsultantButton1.interactable = enabled;
    }

    public void PressExchangeConsultantButton2()
    {
        audioManager.PlayButtonSound();
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

    public void SetBalanceScreenActive()
    { 
        balanceScreen.SetActive(true);
        
        decisionScreen.SetActive(false);
        eventScreen.SetActive(false);
        newsScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        newLawScreen.SetActive(false);
    }

    public void PressContinueButton()
    {
        audioManager.PlayButtonSound();
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

    public void AnimateHealthText()
    {
        healthText.GetComponent<Animator>().SetTrigger("flash");
    }

    public void SetGameOverScreenActive()
    {
        balanceScreen.SetActive(false);
        decisionScreen.SetActive(false);
        eventScreen.SetActive(false);
        newsScreen.SetActive(false);
        
        gameOverScreen.SetActive(true);
        
        newLawScreen.SetActive(false);
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
        audioManager.PlayButtonSound();
        SceneManager.LoadScene("Menu");
    }

    public void SetDecisionScreenActive()
    {
        balanceScreen.SetActive(false);
        
        decisionScreen.SetActive(true);
        
        eventScreen.SetActive(false);
        newsScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        newLawScreen.SetActive(false);
    }

    public void SetLegislativeTermSliderValue(int value)
    {
        legislativeTermSlider.value = value;
    }

    public void PressContinueEventButton()
    {
        audioManager.PlayButtonSound();
        gameManager.ContinueEvent();
    }

    public void SetNewLawScreenActive()
    {
        balanceScreen.SetActive(false);
        decisionScreen.SetActive(false);
        eventScreen.SetActive(false);
        newsScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        
        newLawScreen.SetActive(true);
    }

    public void SetLawText(string text)
    {
        lawText.SetText(text);
    }

    public void SetNewsScreenActive()
    {
        balanceScreen.SetActive(false);
        decisionScreen.SetActive(false);
        eventScreen.SetActive(false);
        
        newsScreen.SetActive(true);
        
        gameOverScreen.SetActive(false);
        newLawScreen.SetActive(false);
    }

    public void SetNewsText(string text)
    {
        newsText.SetText(text);
    }

    public void PressNewsContinueButton()
    {
        audioManager.PlayButtonSound();
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
        bool audioEnabled = audioManager.ToggleAudioVolume();

        soundButtonImage.sprite = audioEnabled ? soundOnImage : soundOffImage;
        
        audioManager.PlayButtonSound();
    }

    public void PressOptionsButton()
    {
        audioManager.PlayButtonSound();
        
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
    
    public void SetConsultant1Icons(Categories category1, Categories category2)
    {
        switch (category1)
        {
            case Categories.Culture:
                consultant1CategoryIcon1.sprite = cultureIcon;
                break;
            case Categories.CivilRights:
                consultant1CategoryIcon1.sprite = civilRightsIcon;
                break;
            case Categories.FreedomOfSpeech:
                consultant1CategoryIcon1.sprite = freedomOfSpeechIcon;
                break;
            case Categories.Participation:
                consultant1CategoryIcon1.sprite = participationIcon;
                break;
            case Categories.Military:
                consultant1CategoryIcon1.sprite = militaryIcon;
                break;
            case Categories.Economy:
                consultant1CategoryIcon1.sprite = economyIcon;
                break;
            case Categories.Science:
                consultant1CategoryIcon1.sprite = scienceIcon;
                break;
            case Categories.SeparationOfPower:
                consultant1CategoryIcon1.sprite = separationOfPowerIcon;
                break;
        }
        
        switch (category2)
        {
            case Categories.Culture:
                consultant1CategoryIcon2.sprite = cultureIcon;
                break;
            case Categories.CivilRights:
                consultant1CategoryIcon2.sprite = civilRightsIcon;
                break;
            case Categories.FreedomOfSpeech:
                consultant1CategoryIcon2.sprite = freedomOfSpeechIcon;
                break;
            case Categories.Participation:
                consultant1CategoryIcon2.sprite = participationIcon;
                break;
            case Categories.Military:
                consultant1CategoryIcon2.sprite = militaryIcon;
                break;
            case Categories.Economy:
                consultant1CategoryIcon2.sprite = economyIcon;
                break;
            case Categories.Science:
                consultant1CategoryIcon2.sprite = scienceIcon;
                break;
            case Categories.SeparationOfPower:
                consultant1CategoryIcon2.sprite = separationOfPowerIcon;
                break;
        }
    }
    
    public void SetConsultant2Icons(Categories category1, Categories category2)
    {
        switch (category1)
        {
            case Categories.Culture:
                consultant2CategoryIcon1.sprite = cultureIcon;
                break;
            case Categories.CivilRights:
                consultant2CategoryIcon1.sprite = civilRightsIcon;
                break;
            case Categories.FreedomOfSpeech:
                consultant2CategoryIcon1.sprite = freedomOfSpeechIcon;
                break;
            case Categories.Participation:
                consultant2CategoryIcon1.sprite = participationIcon;
                break;
            case Categories.Military:
                consultant2CategoryIcon1.sprite = militaryIcon;
                break;
            case Categories.Economy:
                consultant2CategoryIcon1.sprite = economyIcon;
                break;
            case Categories.Science:
                consultant2CategoryIcon1.sprite = scienceIcon;
                break;
            case Categories.SeparationOfPower:
                consultant2CategoryIcon1.sprite = separationOfPowerIcon;
                break;
        }
        
        switch (category2)
        {
            case Categories.Culture:
                consultant2CategoryIcon2.sprite = cultureIcon;
                break;
            case Categories.CivilRights:
                consultant2CategoryIcon2.sprite = civilRightsIcon;
                break;
            case Categories.FreedomOfSpeech:
                consultant2CategoryIcon2.sprite = freedomOfSpeechIcon;
                break;
            case Categories.Participation:
                consultant2CategoryIcon2.sprite = participationIcon;
                break;
            case Categories.Military:
                consultant2CategoryIcon2.sprite = militaryIcon;
                break;
            case Categories.Economy:
                consultant2CategoryIcon2.sprite = economyIcon;
                break;
            case Categories.Science:
                consultant2CategoryIcon2.sprite = scienceIcon;
                break;
            case Categories.SeparationOfPower:
                consultant2CategoryIcon2.sprite = separationOfPowerIcon;
                break;
        }
    }

    public void SetConsultant1Image(Categories category)
    {
        switch (category)
        {
            case Categories.Culture:
                consultant1Image.sprite = cultureConsultants[Random.Range(0, cultureConsultants.Length)];
                break;
            case Categories.CivilRights:
                consultant1Image.sprite = civilRightsConsultants[Random.Range(0, civilRightsConsultants.Length)];
                break;
            case Categories.FreedomOfSpeech:
                consultant1Image.sprite = freedomOfSpeechConsultants[Random.Range(0, freedomOfSpeechConsultants.Length)];
                break;
            case Categories.Participation:
                consultant1Image.sprite = participationConsultants[Random.Range(0, participationConsultants.Length)];
                break;
            case Categories.Military:
                consultant1Image.sprite = militaryConsultants[Random.Range(0, militaryConsultants.Length)];
                break;
            case Categories.Economy:
                consultant1Image.sprite = economyConsultants[Random.Range(0, economyConsultants.Length)];
                break;
            case Categories.Science:
                consultant1Image.sprite = scienceConsultants[Random.Range(0, scienceConsultants.Length)];
                break;
            case Categories.SeparationOfPower:
                consultant1Image.sprite = separationOfPowerConsultants[Random.Range(0, separationOfPowerConsultants.Length)];
                break;
        }
    }
    
    public void SetConsultant2Image(Categories category)
    {
        switch (category)
        {
            case Categories.Culture:
                consultant2Image.sprite = cultureConsultants[Random.Range(0, cultureConsultants.Length)];
                break;
            case Categories.CivilRights:
                consultant2Image.sprite = civilRightsConsultants[Random.Range(0, civilRightsConsultants.Length)];
                break;
            case Categories.FreedomOfSpeech:
                consultant2Image.sprite = freedomOfSpeechConsultants[Random.Range(0, freedomOfSpeechConsultants.Length)];
                break;
            case Categories.Participation:
                consultant2Image.sprite = participationConsultants[Random.Range(0, participationConsultants.Length)];
                break;
            case Categories.Military:
                consultant2Image.sprite = militaryConsultants[Random.Range(0, militaryConsultants.Length)];
                break;
            case Categories.Economy:
                consultant2Image.sprite = economyConsultants[Random.Range(0, economyConsultants.Length)];
                break;
            case Categories.Science:
                consultant2Image.sprite = scienceConsultants[Random.Range(0, scienceConsultants.Length)];
                break;
            case Categories.SeparationOfPower:
                consultant2Image.sprite = separationOfPowerConsultants[Random.Range(0, separationOfPowerConsultants.Length)];
                break;
        }
    }
}
