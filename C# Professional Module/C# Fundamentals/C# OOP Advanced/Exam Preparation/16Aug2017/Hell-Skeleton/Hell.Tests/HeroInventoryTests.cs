using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HeroInventoryTests
{
    private HeroInventory heroInventory;
    [SetUp]
    public void Initialize()
    {
        this.heroInventory = new HeroInventory();
    }

    [Test]
    public void AddCommonItemCorrect()
    {
        CommonItem commonItem = new CommonItem("item", 1, 2, 3, 4, 5);
        this.heroInventory.AddCommonItem(commonItem);

        Type type = typeof(HeroInventory);

        FieldInfo field = type
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);

        var collection = (Dictionary<string, IItem>)field.GetValue(this.heroInventory);

        Assert.AreEqual(1, collection.Count);
    }
    [Test]
    public void AddRecipeItemCorrect()
    {
        RecipeItem commonItem = new RecipeItem("item", 1, 2, 3, 4, 5, new List<string>());
        this.heroInventory.AddRecipeItem(commonItem);

        Type type = typeof(HeroInventory);

        FieldInfo field = type
            .GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic);

        var collection = (Dictionary<string, IRecipe>)field.GetValue(this.heroInventory);

        Assert.AreEqual(1, collection.Count);
    }
    [Test]
    public void StrengthBonusFromItems()
    {
        CommonItem commonItem = new CommonItem("item", 1, 2, 3, 4, 5);
        this.heroInventory.AddCommonItem(commonItem);

        Assert.AreEqual(1, this.heroInventory.TotalStrengthBonus);
    }
    [Test]
    public void AgilityBonusFromItems()
    {
        CommonItem commonItem = new CommonItem("item", 1, 2, 3, 4, 5);
        this.heroInventory.AddCommonItem(commonItem);

        Assert.AreEqual(2, this.heroInventory.TotalAgilityBonus);
    }
    [Test]
    public void IntelligenceBonusFromItems()
    {
        CommonItem commonItem = new CommonItem("item", 1, 2, 3, 4, 5);
        this.heroInventory.AddCommonItem(commonItem);

        Assert.AreEqual(3, this.heroInventory.TotalIntelligenceBonus);
    }
    [Test]
    public void HitPointshBonusFromItems()
    {
        CommonItem commonItem = new CommonItem("item", 1, 2, 3, 4, 5);
        this.heroInventory.AddCommonItem(commonItem);

        Assert.AreEqual(4, this.heroInventory.TotalHitPointsBonus);
    }
    [Test]
    public void DamageBonusFromItems()
    {
        CommonItem commonItem = new CommonItem("item", 1, 2, 3, 4, 5);
        this.heroInventory.AddCommonItem(commonItem);

        Assert.AreEqual(5, this.heroInventory.TotalDamageBonus);
    }
}