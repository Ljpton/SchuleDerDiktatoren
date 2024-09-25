using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    
    public int currentRound;
    public int maxRounds = 50;

    public int currentHealth = 3;
    public int maxHealth = 3;

    public int legislatureTerm = 4;

    public int civilRights = 50;
    public int participation = 50;
    public int freedomOfSpeech = 50;
    public int separationOfPower = 50;

    public int economy = 50;
    public int military = 50;
    public int science = 50;
    public int culture = 50;
    
    public int civilRightsBalance = 50;
    public int participationBalance = 50;
    public int freedomOfSpeechBalance = 50;
    public int separationOfPowerBalance = 50;

    public int economyBalance = 50;
    public int militaryBalance = 50;
    public int scienceBalance = 50;
    public int cultureBalance = 50;
    
    private EventData currentEvent;
    private ConsultantData consultant1;
    private ConsultantData consultant2;
    
    [SerializeField] private EventData[] allEvents;
    
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        if (uiManager == null)
        {
            Debug.Log("UIManager couldn't be found.");
        }

        consultant1 = new ConsultantData();
        consultant2 = new ConsultantData();
        
        uiManager.SetConsultantDescriptionText1(consultant1.ToString());
        uiManager.SetConsultantDescriptionText2(consultant2.ToString());
        
        StartRound();
    }

    private void StartRound()
    {
        currentRound++;

        currentEvent = allEvents[Random.Range(0, allEvents.Length)];
        
        // Update UI
        uiManager.SetRoundCounter(currentRound);
        uiManager.SetEventDescription(currentEvent.eventDescription);
        uiManager.SetReactionText1(currentEvent.reaction1.reactionDescription);
        uiManager.SetReactionText2(currentEvent.reaction2.reactionDescription);
        
        uiManager.SetConsultant1Reaction1Text(consultant1.Consult(currentEvent.reaction1.effect)); 
        uiManager.SetConsultant1Reaction2Text(consultant1.Consult(currentEvent.reaction2.effect)); 
        uiManager.SetConsultant2Reaction1Text(consultant2.Consult(currentEvent.reaction1.effect)); 
        uiManager.SetConsultant2Reaction2Text(consultant2.Consult(currentEvent.reaction2.effect)); 
    }

    private void EndRound()
    {
        // Update UI
        uiManager.SetEconomyText(economy);
        uiManager.SetMilitaryText(military);
        uiManager.SetScienceText(science);
        uiManager.SetCultureText(culture);
        uiManager.SetCivilRightsText(civilRights);
        uiManager.SetParticipationText(participation);
        uiManager.SetFreedomOfSpeechText(freedomOfSpeech);
        uiManager.SetSeparationOfPowerText(separationOfPower);

        if (currentRound > 0 && currentRound % legislatureTerm == 0)
        {
            StartBalance();
        }
        else
        {
            StartRound();
        }
    }

    private void StartBalance()
    {
        uiManager.SetBalanceScreenVisible(true);
        
        uiManager.SetEconomyBalanceSlider(economy);
        uiManager.SetEconomyDeltaText(economy - economyBalance);
        economyBalance = economy;
        
        uiManager.SetMilitaryBalanceSlider(military);
        uiManager.SetMilitaryDeltaText(military - militaryBalance);
        militaryBalance = military;
        
        uiManager.SetScienceBalanceSlider(science);
        uiManager.SetScienceDeltaText(science - scienceBalance);
        scienceBalance = science;
        
        uiManager.SetCultureBalanceSlider(culture);
        uiManager.SetCultureDeltaText(culture - cultureBalance);
        cultureBalance = culture;
        
        uiManager.SetCivilRightsBalanceSlider(civilRights);
        uiManager.SetCivilRightsDeltaText(civilRights - civilRightsBalance);
        civilRightsBalance = civilRights;
        
        uiManager.SetParticipationBalanceSlider(participation);
        uiManager.SetParticipationDeltaText(participation - participationBalance);
        participationBalance = participation;
        
        uiManager.SetFreedomOfSpeechBalanceSlider(freedomOfSpeech);
        uiManager.SetFreedomOfSpeechDeltaText(freedomOfSpeech - freedomOfSpeechBalance);
        freedomOfSpeechBalance = freedomOfSpeech;
        
        uiManager.SetSeparationOfPowerBalanceSlider(separationOfPower);
        uiManager.SetSeparationOfPowerDeltaText(separationOfPower - separationOfPowerBalance);
        separationOfPowerBalance = separationOfPower;
    }

    public void EndBalance()
    {
        uiManager.SetBalanceScreenVisible(false);

        StartRound();
    }

    public void Reaction1()
    {
        Effect effect = currentEvent.reaction1.effect;
        
        civilRights += effect.civilRights;
        participation += effect.participation;
        freedomOfSpeech += effect.freedomOfSpeech;
        separationOfPower += effect.separationOfPower;

        economy += effect.economy;
        military += effect.military;
        science += effect.science;
        culture += effect.culture;

        EndRound();
    }

    public void Reaction2()
    { 
        Effect effect = currentEvent.reaction2.effect;
        
        civilRights += effect.civilRights;
        participation += effect.participation;
        freedomOfSpeech += effect.freedomOfSpeech;
        separationOfPower += effect.separationOfPower;

        economy += effect.economy;
        military += effect.military;
        science += effect.science;
        culture += effect.culture;

        EndRound();
    }

    public void ExchangeConsultant1()
    {
        consultant1 = new ConsultantData();
        uiManager.SetConsultantDescriptionText1(consultant1.ToString());
        
        uiManager.SetConsultant1Reaction1Text(consultant1.Consult(currentEvent.reaction1.effect)); 
        uiManager.SetConsultant1Reaction2Text(consultant1.Consult(currentEvent.reaction2.effect));
    }

    public void ExchangeConsultant2()
    {
        consultant2 = new ConsultantData();
        uiManager.SetConsultantDescriptionText2(consultant2.ToString());
        
        uiManager.SetConsultant2Reaction1Text(consultant2.Consult(currentEvent.reaction1.effect)); 
        uiManager.SetConsultant2Reaction2Text(consultant2.Consult(currentEvent.reaction2.effect));
    }
}
