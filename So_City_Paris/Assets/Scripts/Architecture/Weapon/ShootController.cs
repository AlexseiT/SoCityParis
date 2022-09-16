using System;
using UnityEngine;

public class ShootController : MonoBehaviour, Idamagable
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    private Animator _handAnimator;
    private readonly string _shootNameAnimation = "Shoot";
    private void Start()
    {
        _handAnimator = GetComponent<Animator>();
    }
    public void GiveDamage(Weapon weapon)
    {
        Shoot();
    }
    public void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = _firePoint.position;
        SetShootAnim();
    }
    private void SetShootAnim()
    {
        _handAnimator.SetTrigger(_shootNameAnimation);
    }
}