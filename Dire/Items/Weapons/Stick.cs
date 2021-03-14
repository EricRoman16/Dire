namespace Dire.Items.Weapons
{
    class Stick : Weapon
    {
        public new int damage = 5;
        public new int blocking = 1;
        public new int armor = 0;
        public new int durability = 10;

        public override bool CheckDurability()
        {
            if (durability <= 0)
                return false;
            return true;
        }
        public override string ToString()
        {
            return "Stick";
        }
    }
}
