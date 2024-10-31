using UnityEngine;

[CreateAssetMenu(fileName = "NewEventData", menuName = "ScriptableObjects/EventData", order = 1)]
public class EventData : ScriptableObject
{
    public string eventDescription;
    public Reaction reaction1;
    public Reaction reaction2;
    
    // TODO: How to handle conditions for when event can occur or not occur?
}

[System.Serializable]
public struct Reaction
{
    public string reactionDescription;
    public Effect effect;

    // TODO: How to check if Reaction is against a rule of democracy?
}

[System.Serializable]
public struct Effect
{
    public int economy;
    public int military;
    public int science;
    public int culture;
 
    public int civilRights;
    public int freedomOfSpeech;
    public int participation;
    public int separationOfPower;

    public int GetCategoryValue(Categories category)
    {
        switch (category)
        {
            case Categories.Culture:
                return culture;
            case Categories.Economy:
                return economy;
            case Categories.Military:
                return military;
            case Categories.Participation:
                return participation;
            case Categories.Science:
                return science;
            case Categories.FreedomOfSpeech:
                return freedomOfSpeech;
            case Categories.CivilRights:
                return civilRights;
            case Categories.SeparationOfPower:
                return separationOfPower;
            default:
                return 0;
        }
    }

    // TODO: How to handle special effects like changing legislative term, activating follow-up Events?
}
