using System;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using Random = System.Random;

public class ConsultantData
{
    public ConsultantData(Categories category1, Categories category2)
    {
        this.Category1 = category1;
        this.Category2 = category2;
    }

    public ConsultantData()
    {
        Category1 = EnumUtils.GetRandomEnumValue<Categories>();
        Category2 = EnumUtils.GetRandomEnumValue<Categories>();
    }

    public string ToString()
    {
        return "Berater:in für " + Category1.GetDescription() + " und " + Category2.GetDescription();
    }
    
    public Categories Category1;
    public Categories Category2;

    public string Consult(Effect effect)
    {
        string response = "";

        response = ConsultSingleCategory(response, effect.civilRights, Categories.CivilRights);
        response = ConsultSingleCategory(response, effect.participation, Categories.Participation);
        response = ConsultSingleCategory(response, effect.freedomOfSpeech, Categories.FreedomOfSpeech);
        response = ConsultSingleCategory(response, effect.separationOfPower, Categories.SeparationOfPower);
        
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
        if (Category1 == category || Category2 == category)
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
    [Description("Bürgerrechte")]
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