using UnityEngine;

public abstract class Planet : Unit
{
    [SerializeField] protected int max_count;
    [SerializeField] protected int max_range;

    public int MaxSpawn { get => max_count; }
    public int MaxRange { get => max_range; }

    public override void ChangeHP(float hp)
    {
        _healthpoints += hp;

        if (_healthpoints >= max_healthpoints) _healthpoints = max_healthpoints;
        else if (_healthpoints <= 0) _healthpoints = 0;
        else this.gameObject.GetComponent<FillBar>().ChangeAmount(hp / max_healthpoints);
    }

    public override void SetColor(Color color)
    {
        this.gameObject.GetComponent<FillBar>().FillCircle.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.5f);
    }
}
