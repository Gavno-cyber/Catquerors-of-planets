using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public string team = null;

    [SerializeField] protected int _healthpoints;
    [SerializeField] protected int max_healthpoints;

    public abstract string GetClass();
    
    public int HP { get => _healthpoints; }
    public int MaxHP { get => max_healthpoints; }

    public virtual void _TakeDamage(int _damage)
    {
        _healthpoints -= _damage;
        if (_healthpoints < 0) _healthpoints = 0;
    }
    
    public void RestoreHP(int hp)
    {
        _healthpoints += hp;

        if (_healthpoints > max_healthpoints) _healthpoints = max_healthpoints;
    }

    public void RestoreHP()
    {
        _healthpoints = max_healthpoints;
    }
}
