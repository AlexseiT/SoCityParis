namespace Architecture.Player
{
    public class Player : Character
    {
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