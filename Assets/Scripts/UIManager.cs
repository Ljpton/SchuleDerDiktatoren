using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    
    [SerializeField] private TMP_Text roundCounter;
    
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

    public void PressExchangeConsultantButton2()
    {
        gameManager.ExchangeConsultant2();
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
}
