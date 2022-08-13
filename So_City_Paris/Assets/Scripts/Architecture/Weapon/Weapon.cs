using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float distance;
    [SerializeField] protected float intervalTimeBetweenAttack;
    [SerializeField] protected string gunName;
    public bool WeaponCanAttack { get; protected set; }

}