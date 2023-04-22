using UnityEngine;

public abstract class Cat : Unit
{
    [SerializeField] protected int _damage;

<<<<<<< Updated upstream
=======
    protected bool _attacked = false;

    public bool IsAttacked { get => _attacked; set => _attacked = value; }
>>>>>>> Stashed changes
    public int Damage { get => _damage; }
}
