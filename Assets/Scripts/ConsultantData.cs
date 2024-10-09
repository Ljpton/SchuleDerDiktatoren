using System;
using System.ComponentModel;
using System.Reflection;
using Random = System.Random;

public class ConsultantData
{
    private Categories category1;
    private Categories category2;
    private bool malePronouns;
    
    public ConsultantData(Categories category1, Categories category2)
    {
        Random random = new Random();
        
        this.category1 = category1;
        this.category2 = category2;
        this.malePronouns = random.NextDouble() > 0.5; // Random bool
    }

    public ConsultantData()
    {
        Random random = new Random();
        
        category1 = EnumUtils.GetRandomEnumValue<Categories>();
        category2 = EnumUtils.GetRandomEnumValue<Categories>();
        malePronouns = random.NextDouble() > 0.5; // Random bool
    }
    
    public override string ToString()
    {
        if (malePronouns)
        {
            return "Berater für " + category1.GetDescription() + " und " + category2.GetDescription();
        }
        else
        {
            return "Beraterin für " + category1.GetDescription() + " und " + category2.GetDescription();
        }
        
    }

    public string Consult(Effect effect, bool civilRightsEnshrined, bool participationEnshrined, bool freedomOfSpeechEnshrined, bool separationOfPowerEnshrined)
    {
        string response = "";

        if (civilRightsEnshrined)
        {
            if (effect.civilRights < 0)
            {
                if (response.Length == 0)
                {
                    response += "Verstößt gegen Menschrecht";
                }
                else
                {
                    response += ", verstößt gegen Menschenrecht";
                }
            }
        }
        else
        {
            response = ConsultSingleCategory(response, effect.civilRights, Categories.CivilRights);
        }
        
        if (participationEnshrined)
        {
            if (effect.participation < 0)
            {
                if (response.Length == 0)
                {
                    response += "Verstößt gegen Polit. Partizipation";
                }
                else
                {
                    response += ", verstößt gegen Polit. Partizipation";
                }
            }
        }
        else
        {
            response = ConsultSingleCategory(response, effect.participation, Categories.Participation);
        }
        
        if (freedomOfSpeechEnshrined)
        {
            if (effect.freedomOfSpeech < 0)
            {
                if (response.Length == 0)
                {
                    response += "Verstößt gegen Meinungsfreiheit";
                }
                else
                {
                    response += ", verstößt gegen Meinungsfreiheit";
                }
            }
        }
        else
        {
            response = ConsultSingleCategory(response, effect.freedomOfSpeech, Categories.FreedomOfSpeech);
        }
        
        if (separationOfPowerEnshrined)
        {
            if (effect.separationOfPower < 0)
            {
                if (response.Length == 0)
                {
                    response += "Verstößt gegen Gewaltenteilung";
                }
                else
                {
                    response += ", verstößt gegen Gewaltenteilung";
                }  
            }
        }
        else
        {
            response = ConsultSingleCategory(response, effect.separationOfPower, Categories.SeparationOfPower);   
        }
        
        response = ConsultSingleCategory(response, effect.economy, Categories.Economy);
        response = ConsultSingleCategory(response, effect.military, Categories.Military);
        response = ConsultSingleCategory(response, effect.science, Categories.Science);
        response = ConsultSingleCategory(response, effect.culture, Categories.Culture);

        if (response.Length == 0)
        {
            response = "Dazu kann ich nichts sagen.";
        }
        
        return response;
    }

    public string ConsultSingleCategory(string response, int value, Categories category)
    {
        if (category1 == category || category2 == category)
        {
            if (value > 0)
            {
                if (response.Length == 0)
                {
                    return response + category.GetDescription() + " steigt";
                }
                else
                {
                    return response + ", " + category.GetDescription() + " steigt";
                }
                
            }

            if (value < 0)
            {
                if (response.Length == 0)
                {
                    return response + category.GetDescription() + " sinkt";
                }
                else
                {
                    return response + ", " + category.GetDescription() + " sinkt";
                }
            }
        }

        return response;
    }
    
    // TODO: Add GameObject (?) which will be instantiated and contains visualisation and animation stuff
}

public enum Categories
{
    [Description("Menschenrechte")]
    CivilRights,
    [Description("Polit. Partizipation")]
    Participation,
    [Description("Meinungsfreiheit")]
    FreedomOfSpeech,
    [Description("Gewaltenteilung")]
    SeparationOfPower,
    [Description("Wirtschaft")]
    Economy,
    [Description("Militär")]
    Military,
    [Description("Forschung")]
    Science,
    [Description("Kultur")]
    Culture
}

public static class EnumUtils
{
    private static Random random = new Random();

    // This method is used to get a random value of a given Enum
    public static T GetRandomEnumValue<T>() where T : Enum
    {
        var values = Enum.GetValues(typeof(T));
        
        return (T) values.GetValue(random.Next(values.Length));
    }
    
    // Returns the Description attribute of a given Enum value
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
        return attribute == null ? value.ToString() : attribute.Description;
    }
}