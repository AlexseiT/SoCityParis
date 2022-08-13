using UnityEngine;

public class ShootController : MonoBehaviour, Idamagable
{
    public void GiveDamage(Weapon weapon)
    {
        Shoot(weapon);
    }

    public void Shoot(Weapon weapon)
    {
        //Instantiate(bulletPrefab, bulletPoint.position, transform.rotation);
    }
}