using UnityEngine;

public abstract class Unit : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] protected int _healthpoints;
=======
    public string team = null;

    [SerializeField] protected int _healthpoints;
    [SerializeField] protected int max_healthpoints;
>>>>>>> Stashed changes

    public abstract string GetClass();
    
    public int HP { get => _healthpoints; }
<<<<<<< Updated upstream

    public void _TakeDamage(int _damage)
=======
    public int MaxHP { get => max_healthpoints; }

    public virtual void _TakeDamage(int _damage)
>>>>>>> Stashed changes
    {
        _healthpoints -= _damage;
        if (_healthpoints < 0) _healthpoints = 0;
    }
<<<<<<< Updated upstream
=======
    
    public void RestoreHP(int hp)
    {
        _healthpoints += hp;

        if (_healthpoints > max_healthpoints) _healthpoints = max_healthpoints;
    }

    public void RestoreHP()
    {
        _healthpoints = max_healthpoints;
    }
>>>>>>> Stashed changes
}
