using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

    public ConsultantData(List<Categories> categoriesToSkip = null)
    {
        Random random = new Random();

        List<Categories> validCategories = Enum.GetValues(typeof(Categories)).Cast<Categories>().ToList();
        
        if (categoriesToSkip is not null)
        {
            foreach (var c in categoriesToSkip)
            {
                validCategories.Remove(c);
            }
        }
        
        category1 = validCategories[random.Next(validCategories.Count)];

        validCategories.Remove(category1);
        
        category2 = validCategories[random.Next(validCategories.Count)];
        
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
        
        return response;
    }

    public Categories GetCategory1()
    {
        return category1;
    }

    public Categories GetCategory2()
    {
        return category2;
    }

    public List<Categories> GetCategoriesList()
    {
        List<Categories> list = new List<Categories>();
        
        list.Add(category1);
        list.Add(category2);

        return list;
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