using System;
using System.Collections.Generic;
using System.Linq;
public class Dough
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 200;
    private const int DEFAULT_MULTIPLIER = 2;

    private Dictionary<string, double> validFlourTypes = new Dictionary<string, double>()
    {
        ["white"] = 1.5,
        ["wholegrain"] = 1.0,
    };

    private Dictionary<string, double> validBakingTechniques = new Dictionary<string, double>()
    {
        ["crispy"] = 0.9,
        ["chewy"] = 1.1,
        ["homemade"] = 1.0
    };

    private string flourType;
    private string bakingTechnique;
    private double weight;

    private double FlourMultiplier => validFlourTypes[this.FlourType];
    private double BakingTechniqueMultiplier => validBakingTechniques[this.BakingTechnique];
    public double Calories => DEFAULT_MULTIPLIER * this.Weight * FlourMultiplier * BakingTechniqueMultiplier;
    public string FlourType
    {
        get { return flourType; }
        set
        {
            ValidateTypes(value, validFlourTypes);
            flourType = value.ToLower();
        }
    }
    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            ValidateTypes(value, validBakingTechniques);
            bakingTechnique = value.ToLower();
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
            }
            weight = value;
        }
    }
    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }
    private static void ValidateTypes(string type, Dictionary<string, double> types)
    {
        if (!types.Any(f => f.Key == type.ToLower()))
        {
            throw new ArgumentException("Invalid type of dough.");
        }
    }
}

