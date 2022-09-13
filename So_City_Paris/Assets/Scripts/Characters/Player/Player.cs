namespace Architecture.PlayerSpace
{
    public class Player : Character
    {
        public static bool isTakeWeapon = true;
        public void Heal(int health)
        {
            if (health < 0)
                throw new System.Exception("Health less zero!");

            _health += health;

            if (_health > _maxHealth)
                _health = _maxHealth;
        }
    }
}