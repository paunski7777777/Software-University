using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private Dictionary<string, int> ammunitions;
    private IAmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.ammunitions = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        var weapons = soldier.Weapons
            .Where(w => w.Value == null)
            .Select(w => w.Key).ToList();

        bool isSoldierEquiped = true;

        foreach (var weapon in weapons)
        {
            if (ammunitions.ContainsKey(weapon) && ammunitions[weapon] > 0)
            {
                soldier.Weapons[weapon] = ammunitionFactory.CreateAmmunition(weapon);
                ammunitions[weapon]--;
            }
            else
            {
                isSoldierEquiped = false;
            }
        }

        return isSoldierEquiped;
    }

    public void AddAmmunition(string ammunitionName, int quantity)
    {
        if (ammunitions.ContainsKey(ammunitionName))
        {
            ammunitions[ammunitionName] += quantity;
        }
        else
        {
            ammunitions.Add(ammunitionName, quantity);
        }
    }
}