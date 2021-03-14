namespace Dire.Items.Weapons
{
    class Sword : Weapon
    {
        public new int damage = 10;
        public new int blocking = 2;
        public new int armor = 0;
        public new int durability = 30;

        public override bool CheckDurability()
        {
            if (durability <= 0)
                return false;
            return true;
        }
        public override string ToString()
        {
            return "Sword";
        }
    }
}
