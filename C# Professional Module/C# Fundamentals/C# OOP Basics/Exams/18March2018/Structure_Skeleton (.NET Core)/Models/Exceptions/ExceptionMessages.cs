namespace DungeonsAndCodeWizards.Models.Items
{
    public static class ExceptionMessages
    {
        public static string BagIsFull = "Bag is full!";
        public static string BagIsEmpty = "Bag is empty!";
        public static string ItemDoesNotExist = "No item with name {0} in bag!";
        public static string ItemNotNull = "Name cannot be null or whitespace!";
        public static string MustBeAlive = "Must be alive to perform this action!";
        public static string CannotAttackSelf = "Cannot attack self!";
        public static string FriendlyFire = "Friendly fire! Both characters are from {0} faction!";
        public static string CannotHealEnemy = "Cannot heal enemy character!";
        public static string InvalidFaction = "Invalid faction \"{0}\"!";
        public static string InvalidCharacterType = "Invalid character type \"{0}\"!";
        public static string NoCharacter = "Character {0} not found!";
        public static string NoItems = "No items left in pool!";
        public static string CannotHeal = "{0} cannot heal!";
        public static string CannotAttack = "{0} cannot attack!";
        public static string InvalidItem = "Invalid item \"{0}\"!";
    }
}
