using UnityEngine;

public abstract class FireArms : Weapon
{
    [SerializeField] protected float timeReload;
    [SerializeField] protected float dispersion;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] protected int countBullet;
    public Transform FirePoint { get; private set; }
}