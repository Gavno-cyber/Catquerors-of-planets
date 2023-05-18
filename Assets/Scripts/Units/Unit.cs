using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected PlayerData playerdata;

    [SerializeField] protected float _healthpoints;
    [SerializeField] protected float max_healthpoints;

    public abstract string GetClass();

    public float HP { get => _healthpoints; }
    public float MaxHP { get => max_healthpoints; }

    public PlayerData Team { get => playerdata; set => playerdata = value; }

    public virtual void ChangeHP(float hp)
    {
        _healthpoints += hp;

        if (_healthpoints < 0) _healthpoints = 0;

        if (_healthpoints >= max_healthpoints) _healthpoints = max_healthpoints;
    }

    public void ChangeTeam(PlayerData playerdata)
    {
        this.playerdata = playerdata;
        SetColor(playerdata.Color);
    }

    public abstract void SetColor(Color color);
}
