using System;
using UnityEngine;

public class ShootController : MonoBehaviour, Idamagable
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    public void GiveDamage(Weapon weapon)
    {
        Shoot();
    }
    public void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab);
        bullet.transform.parent = this. transform; //������ ���� �������� �������� HandWithWeapon
        bullet.transform.localPosition = _firePoint.localPosition;
    }
}