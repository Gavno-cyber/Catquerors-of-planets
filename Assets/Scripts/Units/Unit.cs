using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int _healthpoints;

    public abstract string GetClass();
    
    public int HP { get => _healthpoints; }

    public void _TakeDamage(int _damage)
    {
        _healthpoints -= _damage;
        if (_healthpoints < 0) _healthpoints = 0;
    }
}
