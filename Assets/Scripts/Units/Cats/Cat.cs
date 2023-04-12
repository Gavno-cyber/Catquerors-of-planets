using UnityEngine;

public abstract class Cat : Unit
{
    [SerializeField] protected int _damage;

    public int Damage { get => _damage; }
}
