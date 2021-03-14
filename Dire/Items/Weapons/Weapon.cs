namespace Dire.Items.Weapons
{
    class Weapon : Item
    {
        public int damage = 0;
        public int blocking = 0;
        public int armor = 0;
        public int durability = 0;
        public bool canRepair = true;
        public virtual bool CheckDurability()
        {
            return true;
        }
    }
}
