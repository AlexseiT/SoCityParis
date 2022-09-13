using UnityEngine;

public abstract class FireArms : Weapon
{
    [SerializeField] protected float timeReload;
    [SerializeField] protected float dispersion;
    [SerializeField] protected int countBullet;
}