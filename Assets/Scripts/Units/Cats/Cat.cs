using UnityEngine;

public abstract class Cat : Unit
{
    [SerializeField] protected int _damage;

    protected bool _attacked = false;

    public bool IsAttacked { get => _attacked; set => _attacked = value; }
    public int Damage { get => _damage; }
}
