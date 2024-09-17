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
        Debug.Log(consultant1.ToString());
        consultant2 = new ConsultantData();
        Debug.Log(consultant2.ToString());
        
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
}
