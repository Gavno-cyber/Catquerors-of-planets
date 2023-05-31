using UnityEngine;
using System.Collections;

public abstract class Cat : Unit
{
    [SerializeField] protected int _damage;

    protected bool _attacked = false;

    public bool IsAttacked { get => _attacked; set => _attacked = value; }
    public int Damage { get => _damage; }

    [SerializeField] GameObject fillbar;
    [SerializeField] GameObject slash;

    public override void ChangeHP(float hp)
    {
        fillbar.SetActive(true);
        slash.SetActive(true);

        if (slash.activeSelf)
        {
            StartCoroutine(F());
        }

        IEnumerator F()
        {
            yield return new WaitForSeconds(0.7f);
            slash.SetActive(false);
        }

        _healthpoints += hp;

        

        this.gameObject.GetComponent<Healthbar>().ChangeAmount(_healthpoints / max_healthpoints);

        if (_healthpoints < 0) _healthpoints = 0;

        if (_healthpoints >= max_healthpoints) _healthpoints = max_healthpoints;
    }

    public override void SetColor(Color color)
    {
        this.gameObject.GetComponent<CatsManager>().catSprite.GetComponent<SpriteRenderer>().color = color;
    }
}
