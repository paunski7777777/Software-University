public interface IWareHouse
{
    void EquipArmy(IArmy army);
    bool TryEquipSoldier(ISoldier soldier);
    void AddAmmunition(string ammunitionName, int quantity);
}