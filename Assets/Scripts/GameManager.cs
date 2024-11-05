using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    private AudioManager audioManager;
    
    public int currentRound;

    public int currentHealth = 5;

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
    
    public EventData currentEvent;
    public ConsultantData consultant1;
    public ConsultantData consultant2;

    private bool lawEnshrinedThisRound = false;
    
    [SerializeField] private EventData[] eventsPhase1;
    [SerializeField] private EventData[] eventsPhase2A;
    [SerializeField] private EventData[] eventsPhase2B;
    [SerializeField] private EventData[] eventsPhase3;
    
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        audioManager = FindObjectOfType<AudioManager>();

        if (uiManager == null)
        {
            Debug.Log("UIManager couldn't be found.");
        }

        consultant1 = new ConsultantData();
        consultant2 = new ConsultantData(consultant1.GetCategoriesList());
        
        uiManager.SetConsultant1Icons(consultant1.GetCategory1(), consultant1.GetCategory2());
        uiManager.SetConsultant2Icons(consultant2.GetCategory1(), consultant2.GetCategory2());
        
        uiManager.SetConsultant1Image(consultant1.GetCategory1());
        uiManager.SetConsultant2Image(consultant2.GetCategory1());
        
        uiManager.SetHealthText(currentHealth);
        
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
        
        uiManager.SetEventScreenActive();
        
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

        SetConsultant1Reaction1Icons(currentEvent.reaction1.effect);
        
        uiManager.SetConsultant1Reaction2Text(consultant1.Consult(currentEvent.reaction2.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined));
        
        SetConsultant1Reaction2Icons(currentEvent.reaction2.effect);
        
        uiManager.SetConsultant2Reaction1Text(consultant2.Consult(currentEvent.reaction1.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined));
        
        SetConsultant2Reaction1Icons(currentEvent.reaction1.effect);
        
        uiManager.SetConsultant2Reaction2Text(consultant2.Consult(currentEvent.reaction2.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined));
        
        SetConsultant2Reaction2Icons(currentEvent.reaction2.effect);
    }

    private void SetConsultant1Reaction1Icons(Effect reactionEffect)
    {
        // Category 1 value
        int value = reactionEffect.GetCategoryValue(consultant1.GetCategory1());
        
        // Set first Icon
        switch (consultant1.GetCategory1())
        {
            case Categories.Culture:
                uiManager.SetReaction1Consultant1Icon1(Categories.Culture, value);
                break;
            case Categories.Economy:
                uiManager.SetReaction1Consultant1Icon1(Categories.Economy, value);
                break;
            case Categories.Military:
                uiManager.SetReaction1Consultant1Icon1(Categories.Military, value);
                break;
            case Categories.Science:
                uiManager.SetReaction1Consultant1Icon1(Categories.Science, value);
                break;
            case Categories.CivilRights:
                uiManager.SetReaction1Consultant1Icon1(Categories.CivilRights, value, civilRightsEnshrined);
                break;
            case Categories.Participation:
                uiManager.SetReaction1Consultant1Icon1(Categories.Participation, value, participationEnshrined);
                break;
            case Categories.FreedomOfSpeech:
                uiManager.SetReaction1Consultant1Icon1(Categories.FreedomOfSpeech, value, freedomOfSpeechEnshrined);
                break;
            case Categories.SeparationOfPower:
                uiManager.SetReaction1Consultant1Icon1(Categories.SeparationOfPower, value, separationOfPowerEnshrined);
                break;
        }   
        
        // Category 2 value
        value = reactionEffect.GetCategoryValue(consultant1.GetCategory2());
                
        // Set second icon
        switch (consultant1.GetCategory2())
        {
            case Categories.Culture:
                uiManager.SetReaction1Consultant1Icon2(Categories.Culture, value);
                break;
            case Categories.Economy:
                uiManager.SetReaction1Consultant1Icon2(Categories.Economy, value);
                break;
            case Categories.Military:
                uiManager.SetReaction1Consultant1Icon2(Categories.Military, value);
                break;
            case Categories.Science:
                uiManager.SetReaction1Consultant1Icon2(Categories.Science, value);
                break;
            case Categories.CivilRights:
                uiManager.SetReaction1Consultant1Icon2(Categories.CivilRights, value, civilRightsEnshrined);
                break;
            case Categories.Participation:
                uiManager.SetReaction1Consultant1Icon2(Categories.Participation, value, participationEnshrined);
                break;
            case Categories.FreedomOfSpeech:
                uiManager.SetReaction1Consultant1Icon2(Categories.FreedomOfSpeech, value, freedomOfSpeechEnshrined);
                break;
            case Categories.SeparationOfPower:
                uiManager.SetReaction1Consultant1Icon2(Categories.SeparationOfPower, value, separationOfPowerEnshrined);
                break;
        }
    }
    
    private void SetConsultant1Reaction2Icons(Effect reactionEffect)
    {
        // Category 1 value
        int value = reactionEffect.GetCategoryValue(consultant1.GetCategory1());
        
        // Set first Icon
        switch (consultant1.GetCategory1())
        {
            case Categories.Culture:
                uiManager.SetReaction2Consultant1Icon1(Categories.Culture, value);
                break;
            case Categories.Economy:
                uiManager.SetReaction2Consultant1Icon1(Categories.Economy, value);
                break;
            case Categories.Military:
                uiManager.SetReaction2Consultant1Icon1(Categories.Military, value);
                break;
            case Categories.Science:
                uiManager.SetReaction2Consultant1Icon1(Categories.Science, value);
                break;
            case Categories.CivilRights:
                uiManager.SetReaction2Consultant1Icon1(Categories.CivilRights, value, civilRightsEnshrined);
                break;
            case Categories.Participation:
                uiManager.SetReaction2Consultant1Icon1(Categories.Participation, value, participationEnshrined);
                break;
            case Categories.FreedomOfSpeech:
                uiManager.SetReaction2Consultant1Icon1(Categories.FreedomOfSpeech, value, freedomOfSpeechEnshrined);
                break;
            case Categories.SeparationOfPower:
                uiManager.SetReaction2Consultant1Icon1(Categories.SeparationOfPower, value, separationOfPowerEnshrined);
                break;
        }   
        
        // Category 2 value
        value = reactionEffect.GetCategoryValue(consultant1.GetCategory2());
                
        // Set second icon
        switch (consultant1.GetCategory2())
        {
            case Categories.Culture:
                uiManager.SetReaction2Consultant1Icon2(Categories.Culture, value);
                break;
            case Categories.Economy:
                uiManager.SetReaction2Consultant1Icon2(Categories.Economy, value);
                break;
            case Categories.Military:
                uiManager.SetReaction2Consultant1Icon2(Categories.Military, value);
                break;
            case Categories.Science:
                uiManager.SetReaction2Consultant1Icon2(Categories.Science, value);
                break;
            case Categories.CivilRights:
                uiManager.SetReaction2Consultant1Icon2(Categories.CivilRights, value, civilRightsEnshrined);
                break;
            case Categories.Participation:
                uiManager.SetReaction2Consultant1Icon2(Categories.Participation, value, participationEnshrined);
                break;
            case Categories.FreedomOfSpeech:
                uiManager.SetReaction2Consultant1Icon2(Categories.FreedomOfSpeech, value, freedomOfSpeechEnshrined);
                break;
            case Categories.SeparationOfPower:
                uiManager.SetReaction2Consultant1Icon2(Categories.SeparationOfPower, value, separationOfPowerEnshrined);
                break;
        }
    }
    
    private void SetConsultant2Reaction1Icons(Effect reactionEffect)
    {
        // Category 1 value
        int value = reactionEffect.GetCategoryValue(consultant2.GetCategory1());
        
        // Set first Icon
        switch (consultant2.GetCategory1())
        {
            case Categories.Culture:
                uiManager.SetReaction1Consultant2Icon1(Categories.Culture, value);
                break;
            case Categories.Economy:
                uiManager.SetReaction1Consultant2Icon1(Categories.Economy, value);
                break;
            case Categories.Military:
                uiManager.SetReaction1Consultant2Icon1(Categories.Military, value);
                break;
            case Categories.Science:
                uiManager.SetReaction1Consultant2Icon1(Categories.Science, value);
                break;
            case Categories.CivilRights:
                uiManager.SetReaction1Consultant2Icon1(Categories.CivilRights, value, civilRightsEnshrined);
                break;
            case Categories.Participation:
                uiManager.SetReaction1Consultant2Icon1(Categories.Participation, value, participationEnshrined);
                break;
            case Categories.FreedomOfSpeech:
                uiManager.SetReaction1Consultant2Icon1(Categories.FreedomOfSpeech, value, freedomOfSpeechEnshrined);
                break;
            case Categories.SeparationOfPower:
                uiManager.SetReaction1Consultant2Icon1(Categories.SeparationOfPower, value, separationOfPowerEnshrined);
                break;
        }   
        
        // Category 2 value
        value = reactionEffect.GetCategoryValue(consultant2.GetCategory2());
                
        // Set second icon
        switch (consultant2.GetCategory2())
        {
            case Categories.Culture:
                uiManager.SetReaction1Consultant2Icon2(Categories.Culture, value);
                break;
            case Categories.Economy:
                uiManager.SetReaction1Consultant2Icon2(Categories.Economy, value);
                break;
            case Categories.Military:
                uiManager.SetReaction1Consultant2Icon2(Categories.Military, value);
                break;
            case Categories.Science:
                uiManager.SetReaction1Consultant2Icon2(Categories.Science, value);
                break;
            case Categories.CivilRights:
                uiManager.SetReaction1Consultant2Icon2(Categories.CivilRights, value, civilRightsEnshrined);
                break;
            case Categories.Participation:
                uiManager.SetReaction1Consultant2Icon2(Categories.Participation, value, participationEnshrined);
                break;
            case Categories.FreedomOfSpeech:
                uiManager.SetReaction1Consultant2Icon2(Categories.FreedomOfSpeech, value, freedomOfSpeechEnshrined);
                break;
            case Categories.SeparationOfPower:
                uiManager.SetReaction1Consultant2Icon2(Categories.SeparationOfPower, value, separationOfPowerEnshrined);
                break;
        }
    }
    
    private void SetConsultant2Reaction2Icons(Effect reactionEffect)
    {
        // Category 1 value
        int value = reactionEffect.GetCategoryValue(consultant2.GetCategory1());
        
        // Set first Icon
        switch (consultant2.GetCategory1())
        {
            case Categories.Culture:
                uiManager.SetReaction2Consultant2Icon1(Categories.Culture, value);
                break;
            case Categories.Economy:
                uiManager.SetReaction2Consultant2Icon1(Categories.Economy, value);
                break;
            case Categories.Military:
                uiManager.SetReaction2Consultant2Icon1(Categories.Military, value);
                break;
            case Categories.Science:
                uiManager.SetReaction2Consultant2Icon1(Categories.Science, value);
                break;
            case Categories.CivilRights:
                uiManager.SetReaction2Consultant2Icon1(Categories.CivilRights, value, civilRightsEnshrined);
                break;
            case Categories.Participation:
                uiManager.SetReaction2Consultant2Icon1(Categories.Participation, value, participationEnshrined);
                break;
            case Categories.FreedomOfSpeech:
                uiManager.SetReaction2Consultant2Icon1(Categories.FreedomOfSpeech, value, freedomOfSpeechEnshrined);
                break;
            case Categories.SeparationOfPower:
                uiManager.SetReaction2Consultant2Icon1(Categories.SeparationOfPower, value, separationOfPowerEnshrined);
                break;
        }   
        
        // Category 2 value
        value = reactionEffect.GetCategoryValue(consultant2.GetCategory2());
                
        // Set second icon
        switch (consultant2.GetCategory2())
        {
            case Categories.Culture:
                uiManager.SetReaction2Consultant2Icon2(Categories.Culture, value);
                break;
            case Categories.Economy:
                uiManager.SetReaction2Consultant2Icon2(Categories.Economy, value);
                break;
            case Categories.Military:
                uiManager.SetReaction2Consultant2Icon2(Categories.Military, value);
                break;
            case Categories.Science:
                uiManager.SetReaction2Consultant2Icon2(Categories.Science, value);
                break;
            case Categories.CivilRights:
                uiManager.SetReaction2Consultant2Icon2(Categories.CivilRights, value, civilRightsEnshrined);
                break;
            case Categories.Participation:
                uiManager.SetReaction2Consultant2Icon2(Categories.Participation, value, participationEnshrined);
                break;
            case Categories.FreedomOfSpeech:
                uiManager.SetReaction2Consultant2Icon2(Categories.FreedomOfSpeech, value, freedomOfSpeechEnshrined);
                break;
            case Categories.SeparationOfPower:
                uiManager.SetReaction2Consultant2Icon2(Categories.SeparationOfPower, value, separationOfPowerEnshrined);
                break;
        }
    }

    private void EndRound()
    {
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
        uiManager.SetBalanceScreenActive();

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

        if(civilRightsEnshrined)
        {
            uiManager.SetCivilRightsEnshrined();
        }
        
        if (civilRights >= 100)
        {
            if (!civilRightsEnshrined)
            {
                Debug.Log("Civil Rights got enshrined into our constitution.");
                civilRightsEnshrined = true;

                uiManager.SetLawText(
                    "Menschenrechtsgesetz\n\nArtikel 1: Die Würde des Menschen ist unantastbar. Sie zu achten und zu schützen ist Verpflichtung aller staatlichen Gewalt.\n\nArtikel 2: Jeder hat das Recht auf Leben und körperliche Unversehrtheit. Die Freiheit der Person ist unverletzlich.");
                uiManager.SetNewsText("Die Regierung hat ein Menschenrechtsgesetz verabschiedet, das die grundlegende Bürgerrechte sichern soll. Menschenrechts-gruppen feiern dies als Fortschritt, doch die Bevölkerung bleibt skeptisch. Internationale Beobachter betonen, dass jetzt Taten folgen müssen.");

                lawEnshrinedThisRound = true;
            }
            
            uiManager.ClearCivilRightsDeltaText();
        }
        
        uiManager.SetParticipationBalanceSlider(participation);
        int participationDelta = participation - participationBalance;
        democracySum += participationDelta;
        uiManager.SetParticipationDeltaText(participationDelta);
        participationBalance = participation;

        if (participationEnshrined)
        {
            uiManager.SetParticipationEnshrined();
        }
        
        if (participation >= 100)
        {
            if (!participationEnshrined)
            {
                Debug.Log("Political Participation got enshrined into our constitution.");
                participationEnshrined = true;
                
                uiManager.SetLawText("Gesetz für Politische Partizipation\n\nArtikel 1: Alle Bürger haben das Recht, an der politischen Willensbildung des Staates durch Wahlen und Abstimmungen mitzuwirken.\n\nArtikel 2: Das aktive und passive Wahlrecht steht allen volljährigen Bürgern gleichermaßen zu. Diskriminierung ist unzulässig.");
                uiManager.SetNewsText("Das Gesetz zur politischen Partizipation erweitert die Möglichkeiten der Bürger, an Wahlen teilzunehmen. Experten sehen darin eine Stärkung der Demokratie. Bürger sind motiviert, aktiv am politischen Leben teilzuhaben.");
                
                lawEnshrinedThisRound = true;
            }
            
            uiManager.ClearParticipationDeltaText();
        }
        
        uiManager.SetFreedomOfSpeechBalanceSlider(freedomOfSpeech);
        int freedomOfSpeechDelta = freedomOfSpeech - freedomOfSpeechBalance;
        democracySum += freedomOfSpeechDelta;
        uiManager.SetFreedomOfSpeechDeltaText(freedomOfSpeechDelta);
        freedomOfSpeechBalance = freedomOfSpeech;

        if (freedomOfSpeechEnshrined)
        {
            uiManager.SetFreedomOfSpeechEnshrined();
        }
        
        if (freedomOfSpeech >= 100)
        {
            if (!freedomOfSpeechEnshrined)
            {
                Debug.Log("Freedom of Speech got enshrined into our constitution.");
                freedomOfSpeechEnshrined = true;
                
                uiManager.SetLawText("Gesetz für Meinungs- und Pressefreiheit\n\nArtikel 1: Jeder hat das Recht, seine Meinung in Wort, Schrift und Bild frei zu äußern und zu verbreiten.\n\nArtikel 2: Die Pressefreiheit und die Freiheit der Berichterstattung durch Rundfunk und Film werden gewährleistet. Eine Zensur findet nicht statt.");
                uiManager.SetNewsText("Das Gesetz für Meinungs- und Pressefreiheit wird als Meilenstein gefeiert. Journalisten fühlen sich rechtlich abgesichert, und Bürger äußern freier ihre Meinung. Es wird als Schritt zu mehr Transparenz gesehen.");
                
                lawEnshrinedThisRound = true;
            }
            
            uiManager.ClearFreedomOfSpeechDeltaText();
        }
        
        uiManager.SetSeparationOfPowerBalanceSlider(separationOfPower);
        int separationOfPowerDelta = separationOfPower - separationOfPowerBalance;
        democracySum += separationOfPowerDelta;
        uiManager.SetSeparationOfPowerDeltaText(separationOfPowerDelta);
        separationOfPowerBalance = separationOfPower;

        if (separationOfPowerEnshrined)
        {
            uiManager.SetSeparationOfPowerEnshrined();
        }
        
        if (separationOfPower >= 100)
        {
            if (!separationOfPowerEnshrined)
            {
                Debug.Log("Separation of Power got enshrined into our constitution.");
                separationOfPowerEnshrined = true;
                
                uiManager.SetLawText("Gesetz zur Gewaltenteilung\n\nArtikel 1: Die Staatsgewalt ist in Legislative, Exekutive und Judikative unterteilt. Sie wirken eigenständig und kontrollieren sich gegenseitig.\n\nArtikel 2: Keine der Gewaltenteilungsinstanzen darf die Aufgaben einer anderen dauerhaft und vollumfänglich übernehmen.");
                uiManager.SetNewsText("Das Gesetz zur Gewaltenteilung fördert eine gerechte Machtverteilung. Experten sehen dies als wichtigen Schritt zu einem demokratischeren System. In der Bevölkerung gibt es Hoffnung auf stärkere demokratische Prozesse, während Skeptiker die Umsetzung abwarten.");
                
                lawEnshrinedThisRound = true;
            }
            
            uiManager.ClearSeparationOfPowerDeltaText();
        }
        
        uiManager.SetDemocracySumText(democracySum);
        
        // Exchange Consultants
        consultant1 = new ConsultantData();
        consultant2 = new ConsultantData(consultant1.GetCategoriesList());
        uiManager.SetConsultant1Icons(consultant1.GetCategory1(), consultant1.GetCategory2());
        uiManager.SetConsultant2Icons(consultant2.GetCategory1(), consultant2.GetCategory2());
        uiManager.SetConsultant1Image(consultant1.GetCategory1());
        uiManager.SetConsultant2Image(consultant2.GetCategory1());
        
        // Reenable ExchangeConsultantButtons
        uiManager.SetExchangeConsultantButton1Enabled(true);
        uiManager.SetExchangeConsultantButton2Enabled(true);
    }

    public void EndBalance()
    {
        if (civilRights >= 100 && participation >= 100 && freedomOfSpeech >= 100 && separationOfPower >= 100)
        {
            if (lawEnshrinedThisRound)
            {
                uiManager.SetNewLawScreenActive();
                lawEnshrinedThisRound = false;
            }
            else
            {
                uiManager.SetGameOverScreenActive();
            
                uiManager.SetGameOverLabelText("Gratulation!");
                uiManager.SetGameOverText("Du hast alle Grundwerte einer Demokratie etabliert und im Grundgesetz verankert. Natürlich musst du jetzt einem gewählten Parlament Platz machen. Dafür werden du und dieser Tag in die Geschichte dieses Landes eingehen.");
            }
        }
        else if (currentHealth <= 0)
        {
            uiManager.SetGameOverScreenActive();
            
            uiManager.SetGameOverLabelText("Game Over");
            uiManager.SetGameOverText("Du hast es auf dem Weg zur Demokratie weit gebracht, aber dazu gehört auch, sich an die eigenen Gesetze zu halten. Leider hast du einmal zu oft gegen das Gesetz verstoßen und den Unmut des Volkes erregt.");
        }
        else if (civilRights <= 0 || participation <= 0 || freedomOfSpeech <= 0 || separationOfPower <= 0 ||
            economy <= 0 || military <= 0 || science <= 0 || culture <= 0)
        {
            uiManager.SetGameOverScreenActive();
            
            uiManager.SetGameOverLabelText("Game Over");
            uiManager.SetGameOverText("Es ist schwierig, so viele Dinge gleichzeitig im Auge zu behalten und letztendlich ist deiner Aufmerksamkeit wohl etwas entgangen. Das Volk hingegen hat das sehr wohl zu spüren bekommen und nutzt alle Mittel, um eine neue Führungsperson an deine Stelle zu setzen.");
        }
        else
        {
            if (lawEnshrinedThisRound)
            {
                uiManager.SetNewLawScreenActive();
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
            LoseHealth();
        }
        else
        {
            civilRights = Mathf.Clamp(civilRights + effect.civilRights, 0, 100);
        }
        
        if (effect.participation < 0 && participationEnshrined)
        {
            LoseHealth();
        }
        else
        {
            participation = Mathf.Clamp(participation + effect.participation, 0, 100);
        }
        
        if (effect.freedomOfSpeech < 0 && freedomOfSpeechEnshrined)
        {
            LoseHealth();
        }
        else
        {
            freedomOfSpeech = Mathf.Clamp(freedomOfSpeech + effect.freedomOfSpeech, 0, 100); 
        }
        
        if (effect.separationOfPower < 0 && separationOfPowerEnshrined)
        {
            LoseHealth();
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
            LoseHealth();
        }
        else
        {
            civilRights = Mathf.Clamp(civilRights + effect.civilRights, 0, 100);
        }
        
        if (effect.participation < 0 && participationEnshrined)
        {
            LoseHealth();
        }
        else
        {
            participation = Mathf.Clamp(participation + effect.participation, 0, 100);
        }
        
        if (effect.freedomOfSpeech < 0 && freedomOfSpeechEnshrined)
        {
            LoseHealth();
        }
        else
        {
            freedomOfSpeech = Mathf.Clamp(freedomOfSpeech + effect.freedomOfSpeech, 0, 100); 
        }
        
        if (effect.separationOfPower < 0 && separationOfPowerEnshrined)
        {
            LoseHealth();
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
        List<Categories> categoriesToSkip = new List<Categories>
        {
            consultant1.GetCategory1(),
            consultant1.GetCategory2(),
            consultant2.GetCategory1(),
            consultant2.GetCategory2()
        };

        consultant1 = new ConsultantData(categoriesToSkip);
        uiManager.SetConsultant1Icons(consultant1.GetCategory1(), consultant1.GetCategory2());
        uiManager.SetConsultant1Image(consultant1.GetCategory1());
        
        uiManager.SetConsultant1Reaction1Text(consultant1.Consult(currentEvent.reaction1.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined));

        SetConsultant1Reaction1Icons(currentEvent.reaction1.effect);
        
        uiManager.SetConsultant1Reaction2Text(consultant1.Consult(currentEvent.reaction2.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined));
        
        SetConsultant1Reaction2Icons(currentEvent.reaction2.effect);
        
        uiManager.SetExchangeConsultantButton1Enabled(false);
    }

    public void ExchangeConsultant2()
    {
        List<Categories> categoriesToSkip = new List<Categories>
        {
            consultant1.GetCategory1(),
            consultant1.GetCategory2(),
            consultant2.GetCategory1(),
            consultant2.GetCategory2()
        };

        consultant2 = new ConsultantData(categoriesToSkip);
        uiManager.SetConsultant2Icons(consultant2.GetCategory1(), consultant2.GetCategory2());
        uiManager.SetConsultant2Image(consultant2.GetCategory1());
        
        uiManager.SetConsultant2Reaction1Text(consultant2.Consult(currentEvent.reaction1.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined)); 
        
        SetConsultant2Reaction1Icons(currentEvent.reaction1.effect);
        
        uiManager.SetConsultant2Reaction2Text(consultant2.Consult(currentEvent.reaction2.effect,
            civilRightsEnshrined, participationEnshrined, freedomOfSpeechEnshrined, separationOfPowerEnshrined));
        
        SetConsultant2Reaction2Icons(currentEvent.reaction2.effect);
        
        uiManager.SetExchangeConsultantButton2Enabled(false);
    }

    public void ContinueEvent()
    {
        uiManager.SetDecisionScreenActive();
    }

    public void Stamped()
    {
        uiManager.SetNewsScreenActive();
    }

    public void StartRoundAfterNewLaw()
    {
        if (civilRights >= 100 && participation >= 100 && freedomOfSpeech >= 100 && separationOfPower >= 100)
        {
            uiManager.SetGameOverScreenActive();
            
            uiManager.SetGameOverLabelText("Gratulation!");
            uiManager.SetGameOverText("Du hast alle Grundwerte einer Demokratie etabliert und im Grundgesetz verankert. Natürlich musst du jetzt einem gewählten Parlament Platz machen. Dafür werden du und dieser Tag in die Geschichte dieses Landes eingehen.");
        }
        else
        {
            uiManager.SetNewsScreenActive();
            StartRound();
        }
    }

    private void LoseHealth()
    {
        Debug.Log("You acted against the law.");
        currentHealth--;
        audioManager.PlayLoseHealthSound();
        uiManager.SetHealthText(currentHealth);
        uiManager.AnimateHealthText();
    }
}
