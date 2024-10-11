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
    
    public bool civilRightsEnshrined;
    public bool participationEnshrined;
    public bool freedomOfSpeechEnshrined;
    public bool separationOfPowerEnshrined;
    
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

    private bool lawEnshrinedThisRound = false;
    
    [SerializeField] private EventData[] eventsPhase1;
    [SerializeField] private EventData[] eventsPhase2A;
    [SerializeField] private EventData[] eventsPhase2B;
    [SerializeField] private EventData[] eventsPhase3;
    
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
        
        if (currentRound > 0)
        {
            uiManager.SetLegislativeTermSliderValue(currentRound % legislatureTerm == 0 ? 4 : currentRound % legislatureTerm);
        }

        if (civilRightsEnshrined || freedomOfSpeechEnshrined || participationEnshrined || separationOfPowerEnshrined)
        {
            Debug.Log("We are in Phase 3.");
            
            EventData nextEvent = eventsPhase3[Random.Range(0, eventsPhase3.Length)];

            while (currentEvent == nextEvent)
            {
                nextEvent = eventsPhase3[Random.Range(0, eventsPhase3.Length)];
            }

            currentEvent = nextEvent;
        }
        else if (civilRights + freedomOfSpeech + participation + separationOfPower >= 275)
        {
            Debug.Log("We are in Phase 2B.");
            
            EventData nextEvent = eventsPhase2B[Random.Range(0, eventsPhase2B.Length)];

            while (currentEvent == nextEvent)
            {
                nextEvent = eventsPhase2B[Random.Range(0, eventsPhase2B.Length)];
            }

            currentEvent = nextEvent;
        }
        else if (economy + science + culture + military >= 250)
        {
            Debug.Log("We are in Phase 2A.");
            
            EventData nextEvent = eventsPhase2A[Random.Range(0, eventsPhase2A.Length)];

            while (currentEvent == nextEvent)
            {
                nextEvent = eventsPhase2A[Random.Range(0, eventsPhase2A.Length)];
            }

            currentEvent = nextEvent;
        }
        else
        {
            Debug.Log("We are in Phase 1.");
            
            EventData nextEvent = eventsPhase1[Random.Range(0, eventsPhase1.Length)];

            while (currentEvent == nextEvent)
            {
                nextEvent = eventsPhase1[Random.Range(0, eventsPhase1.Length)];
            }

            currentEvent = nextEvent;
        }
        
        uiManager.SetDecisionScreenVisible(false);
        
        // Update UI
        if (Random.Range(0, 2) == 1)
        {
            uiManager.SwapReactionButtons();
        }
        
        uiManager.SetRoundCounter(currentRound);
        uiManager.SetEventDescription(currentEvent.eventDescription);
        uiManager.SetReactionText1(currentEvent.reaction1.reactionDescription);
        uiManager.SetReactionText2(currentEvent.reaction2.reactionDescription);
        
        uiManager.SetConsultant1Reaction1Text(consultant1.Consult(currentEvent.reaction1.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined)); 
        uiManager.SetConsultant1Reaction2Text(consultant1.Consult(currentEvent.reaction2.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined)); 
        uiManager.SetConsultant2Reaction1Text(consultant2.Consult(currentEvent.reaction1.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined)); 
        uiManager.SetConsultant2Reaction2Text(consultant2.Consult(currentEvent.reaction2.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined)); 
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

        int resourcesSum = 0;
        int democracySum = 0;
        
        uiManager.SetEconomyBalanceSlider(economy);
        int economyDelta = economy - economyBalance;
        resourcesSum += economyDelta;
        uiManager.SetEconomyDeltaText(economyDelta);
        economyBalance = economy;
        
        uiManager.SetMilitaryBalanceSlider(military);
        int militaryDelta = military - militaryBalance;
        resourcesSum += militaryDelta;
        uiManager.SetMilitaryDeltaText(militaryDelta);
        militaryBalance = military;
        
        uiManager.SetScienceBalanceSlider(science);
        int scienceDelta = science - scienceBalance;
        resourcesSum += scienceDelta;
        uiManager.SetScienceDeltaText(scienceDelta);
        scienceBalance = science;
        
        uiManager.SetCultureBalanceSlider(culture);
        int cultureDelta = culture - cultureBalance;
        resourcesSum += cultureDelta;
        uiManager.SetCultureDeltaText(cultureDelta);
        cultureBalance = culture;
        
        uiManager.SetResourcesSumText(resourcesSum);
        
        uiManager.SetCivilRightsBalanceSlider(civilRights);
        int civilRightsDelta = civilRights - civilRightsBalance;
        democracySum += civilRightsDelta;
        uiManager.SetCivilRightsDeltaText(civilRightsDelta);
        civilRightsBalance = civilRights;

        if (civilRights >= 100)
        {
            if (!civilRightsEnshrined)
            {
                Debug.Log("Civil Rights got enshrined into our constitution.");
                civilRightsEnshrined = true;

                uiManager.SetLawText(
                    "Menschenrechtsgesetz\n\nArtikel 1: Die Würde des Menschen ist unantastbar. Sie zu achten und zu schützen ist Verpflichtung aller staatlichen Gewalt.\n\nArtikel 2: Jeder hat das Recht auf Leben und körperliche Unversehrtheit. Die Freiheit der Person ist unverletzlich.");
                uiManager.SetNewsText("In einem bedeutenden Schritt hat die Regierung das Menschenrechtsgesetz verabschiedet, das die Würde und Unversehrtheit des Einzelnen zum höchsten Gut erklärt. Menschenrechtsorganisationen loben das klare Bekenntnis zu den grundlegenden Werten und hoffen auf eine konsequente Umsetzung. Viele Bürger fühlen sich durch das Gesetz ermutigt, ihre Rechte einzufordern, und erwarten eine neue Ära des Respekts und der Menschlichkeit.");

                lawEnshrinedThisRound = true;
            }
            
            uiManager.ClearCivilRightsDeltaText();
        }
        
        uiManager.SetParticipationBalanceSlider(participation);
        int participationDelta = participation - participationBalance;
        democracySum += participationDelta;
        uiManager.SetParticipationDeltaText(participationDelta);
        participationBalance = participation;
        
        if (participation >= 100)
        {
            if (!participationEnshrined)
            {
                Debug.Log("Political Participation got enshrined into our constitution.");
                participationEnshrined = true;
                
                uiManager.SetLawText("Gesetz für Politische Partizipation\n\nArtikel 1: Alle Bürger haben das Recht, an der politischen Willensbildung des Staates durch Wahlen und Abstimmungen mitzuwirken.\n\nArtikel 2: Das aktive und passive Wahlrecht steht allen volljährigen Bürgern gleichermaßen zu. Diskriminierung ist unzulässig.");
                uiManager.SetNewsText("Das neue Gesetz für politische Partizipation erweitert die Möglichkeiten der Bürger, aktiv an Wahlen und politischen Prozessen teilzunehmen. Wahlrechtsexperten begrüßen die Maßnahme als Stärkung der Demokratie. In der Bevölkerung ist ein Aufschwung politischer Aktivität spürbar, denn viele Bürger fühlen sich nun motiviert, ihre Stimme zu erheben und am politischen Leben teilzuhaben.");
                
                lawEnshrinedThisRound = true;
            }
            
            uiManager.ClearParticipationDeltaText();
        }
        
        uiManager.SetFreedomOfSpeechBalanceSlider(freedomOfSpeech);
        int freedomOfSpeechDelta = freedomOfSpeech - freedomOfSpeechBalance;
        democracySum += freedomOfSpeechDelta;
        uiManager.SetFreedomOfSpeechDeltaText(freedomOfSpeechDelta);
        freedomOfSpeechBalance = freedomOfSpeech;
        
        if (freedomOfSpeech >= 100)
        {
            if (!freedomOfSpeechEnshrined)
            {
                Debug.Log("Freedom of Speech got enshrined into our constitution.");
                freedomOfSpeechEnshrined = true;
                
                uiManager.SetLawText("Gesetz für Meinungs- und Pressefreiheit\n\nArtikel 1: Jeder hat das Recht, seine Meinung in Wort, Schrift und Bild frei zu äußern und zu verbreiten.\n\nArtikel 2: Die Pressefreiheit und die Freiheit der Berichterstattung durch Rundfunk und Film werden gewährleistet. Eine Zensur findet nicht statt.");
                uiManager.SetNewsText("Die Verabschiedung des Gesetzes für Meinungs- und Pressefreiheit wird in der Gesellschaft als Meilenstein für die individuelle Freiheit gefeiert. Journalisten und Medienhäuser atmen auf, da ihre Arbeit nun rechtlich abgesichert wird. Viele Bürger nutzen die Gelegenheit, offen ihre Meinung zu äußern, und sehen in dem Gesetz einen Schritt hin zu mehr Transparenz und freier Meinungsbildung.");
                
                lawEnshrinedThisRound = true;
            }
            
            uiManager.ClearFreedomOfSpeechDeltaText();
        }
        
        uiManager.SetSeparationOfPowerBalanceSlider(separationOfPower);
        int separationOfPowerDelta = separationOfPower - separationOfPowerBalance;
        democracySum += separationOfPowerDelta;
        uiManager.SetSeparationOfPowerDeltaText(separationOfPowerDelta);
        separationOfPowerBalance = separationOfPower;
        
        if (separationOfPower >= 100)
        {
            if (!separationOfPowerEnshrined)
            {
                Debug.Log("Separation of Power got enshrined into our constitution.");
                separationOfPowerEnshrined = true;
                
                uiManager.SetLawText("Gesetz zur Gewaltenteilung\n\nArtikel 1: Die Staatsgewalt ist in Legislative, Exekutive und Judikative unterteilt. Sie wirken eigenständig und kontrollieren sich gegenseitig.\n\nArtikel 2: Keine der Gewaltenteilungsinstanzen darf die Aufgaben einer anderen dauerhaft und vollumfänglich übernehmen.");
                uiManager.SetNewsText("Mit der Einführung des Gesetzes zur Gewaltenteilung setzt die Regierung ein starkes Zeichen für eine gerechte Machtverteilung. Die klare Trennung von Legislative, Exekutive und Judikative wird von Verfassungsexperten als wesentlicher Schritt hin zu einem demokratischeren System gewertet. In der Bevölkerung herrscht Hoffnung auf eine Stärkung der demokratischen Prozesse, wobei Skeptiker gespannt beobachten, ob die Gewaltenteilung in der Praxis greift.");
                
                lawEnshrinedThisRound = true;
            }
            
            uiManager.ClearSeparationOfPowerDeltaText();
        }
        
        uiManager.SetDemocracySumText(democracySum);

        // Add Health
        if (currentHealth is < 3 and > 0)
        {
            currentHealth++;
            uiManager.SetHealthRegenerationTextVisible(true);
        }
        else
        {
            uiManager.SetHealthRegenerationTextVisible(false);
        }
        
        uiManager.SetHealthText(currentHealth);
        
        // Exchange Consultants
        consultant1 = new ConsultantData();
        uiManager.SetConsultantDescriptionText1(consultant1.ToString());
        consultant2 = new ConsultantData();
        uiManager.SetConsultantDescriptionText2(consultant2.ToString());
        
        // Reenable ExchangeConsultantButtons
        uiManager.SetExchangeConsultantButton1Enabled(true);
        uiManager.SetExchangeConsultantButton2Enabled(true);
    }

    public void EndBalance()
    {
        uiManager.SetBalanceScreenVisible(false);

        if (civilRights >= 100 && participation >= 100 && freedomOfSpeech >= 100 && separationOfPower >= 100)
        {
            if (lawEnshrinedThisRound)
            {
                uiManager.SetNewLawScreenVisibility(true);
                lawEnshrinedThisRound = false;
            }
            else
            {
                uiManager.SetGameOverScreenVisible(true);
            
                uiManager.SetGameOverLabelText("Glückwunsch!");
                uiManager.SetGameOverText("Du hast alle Grundwerte einer Demokratie etabliert und im Grundgesetz verankert. Natürlich musst du jetzt einem gewählten Parlament Platz machen. Dafür werden du und dieser Tag in die Geschichte dieses Landes eingehen.");
            }
        }
        else if (currentHealth <= 0)
        {
            uiManager.SetGameOverScreenVisible(true);
            
            uiManager.SetGameOverLabelText("Game Over");
            uiManager.SetGameOverText("Du hast es auf dem Weg zur Demokratie weit gebracht, aber dazu gehört auch, sich an die eigenen Gesetze zu halten. Du musst deinen Posten in der Regierung abgeben und joa.");
        }
        else if (civilRights <= 0 || participation <= 0 || freedomOfSpeech <= 0 || separationOfPower <= 0 ||
            economy <= 0 || military <= 0 || science <= 0 || culture <= 0)
        {
            uiManager.SetGameOverScreenVisible(true);
            
            // TODO: Set LabelText and GameOverText
        }
        else
        {
            if (lawEnshrinedThisRound)
            {
                uiManager.SetNewLawScreenVisibility(true);
                lawEnshrinedThisRound = false;
            }
            else
            {
                StartRound();
            }
        }
    }

    public void Reaction1()
    {
        Effect effect = currentEvent.reaction1.effect;

        if (effect.civilRights < 0 && civilRightsEnshrined)
        {
            Debug.Log("You acted against the law.");
            currentHealth--;
            uiManager.SetHealthText(currentHealth);
        }
        else
        {
            civilRights = Mathf.Clamp(civilRights + effect.civilRights, 0, 100);
        }
        
        if (effect.participation < 0 && participationEnshrined)
        {
            Debug.Log("You acted against the law.");
            currentHealth--;
            uiManager.SetHealthText(currentHealth);
        }
        else
        {
            participation = Mathf.Clamp(participation + effect.participation, 0, 100);
        }
        
        if (effect.freedomOfSpeech < 0 && freedomOfSpeechEnshrined)
        {
            Debug.Log("You acted against the law.");
            currentHealth--;
            uiManager.SetHealthText(currentHealth);
        }
        else
        {
            freedomOfSpeech = Mathf.Clamp(freedomOfSpeech + effect.freedomOfSpeech, 0, 100); 
        }
        
        if (effect.separationOfPower < 0 && separationOfPowerEnshrined)
        {
            Debug.Log("You acted against the law.");
            currentHealth--;
            uiManager.SetHealthText(currentHealth);
        }
        else
        {
            separationOfPower = Mathf.Clamp(separationOfPower + effect.separationOfPower, 0, 100);
        }

        economy = Mathf.Clamp(economy + effect.economy, 0, 100);
        military = Mathf.Clamp(military + effect.military, 0, 100);
        science = Mathf.Clamp(science + effect.science, 0, 100);
        culture = Mathf.Clamp(culture + effect.culture, 0, 100);

        EndRound();
    }

    public void Reaction2()
    { 
        Effect effect = currentEvent.reaction2.effect;
        
        if (effect.civilRights < 0 && civilRightsEnshrined)
        {
            Debug.Log("You acted against the law.");
            currentHealth--;
            uiManager.SetHealthText(currentHealth);
        }
        else
        {
            civilRights = Mathf.Clamp(civilRights + effect.civilRights, 0, 100);
        }
        
        if (effect.participation < 0 && participationEnshrined)
        {
            Debug.Log("You acted against the law.");
            currentHealth--;
            uiManager.SetHealthText(currentHealth);
        }
        else
        {
            participation = Mathf.Clamp(participation + effect.participation, 0, 100);
        }
        
        if (effect.freedomOfSpeech < 0 && freedomOfSpeechEnshrined)
        {
            Debug.Log("You acted against the law.");
            currentHealth--;
            uiManager.SetHealthText(currentHealth);
        }
        else
        {
            freedomOfSpeech = Mathf.Clamp(freedomOfSpeech + effect.freedomOfSpeech, 0, 100); 
        }
        
        if (effect.separationOfPower < 0 && separationOfPowerEnshrined)
        {
            Debug.Log("You acted against the law.");
            currentHealth--;
            uiManager.SetHealthText(currentHealth);
        }
        else
        {
            separationOfPower = Mathf.Clamp(separationOfPower + effect.separationOfPower, 0, 100);
        }

        economy = Mathf.Clamp(economy + effect.economy, 0, 100);
        military = Mathf.Clamp(military + effect.military, 0, 100);
        science = Mathf.Clamp(science + effect.science, 0, 100);
        culture = Mathf.Clamp(culture + effect.culture, 0, 100);

        EndRound();
    }

    public void ExchangeConsultant1()
    {
        consultant1 = new ConsultantData();
        uiManager.SetConsultantDescriptionText1(consultant1.ToString());
        
        uiManager.SetConsultant1Reaction1Text(consultant1.Consult(currentEvent.reaction1.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined)); 
        uiManager.SetConsultant1Reaction2Text(consultant1.Consult(currentEvent.reaction2.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined));
        
        uiManager.SetExchangeConsultantButton1Enabled(false);
    }

    public void ExchangeConsultant2()
    {
        consultant2 = new ConsultantData();
        uiManager.SetConsultantDescriptionText2(consultant2.ToString());
        
        uiManager.SetConsultant2Reaction1Text(consultant2.Consult(currentEvent.reaction1.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined)); 
        uiManager.SetConsultant2Reaction2Text(consultant2.Consult(currentEvent.reaction2.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined));
        
        uiManager.SetExchangeConsultantButton2Enabled(false);
    }

    public void ContinueEvent()
    {
        uiManager.SetDecisionScreenVisible(true);
    }

    public void Stamped()
    {
        uiManager.SetNewsScreenVisibility(true);
        uiManager.SetNewLawScreenVisibility(false);
    }

    public void StartRoundAfterNewLaw()
    {
        if (civilRights >= 100 && participation >= 100 && freedomOfSpeech >= 100 && separationOfPower >= 100)
        {
            uiManager.SetGameOverScreenVisible(true);
            
            uiManager.SetGameOverLabelText("Glückwunsch!");
            uiManager.SetGameOverText("Du hast alle Grundwerte einer Demokratie etabliert und im Grundgesetz verankert. Natürlich musst du jetzt einem gewählten Parlament Platz machen. Dafür werden du und dieser Tag in die Geschichte dieses Landes eingehen.");
        }
        else
        {
            uiManager.SetNewsScreenVisibility(false);
            StartRound();
        }
    }
}
