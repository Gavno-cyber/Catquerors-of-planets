using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public float fillAmount;
    [SerializeField] float maxAmount;

    public GameObject FillBar;
    public GameObject HealthBar;
    public GameObject Bar;

    public Color Low;
    public Color High;

    void Start()
    {
        fillAmount = this.gameObject.GetComponent<Unit>().HP / this.gameObject.GetComponent<Unit>().MaxHP;

        Bar.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.green, fillAmount);
    }

    public void ChangeAmount(float amount)
    {
        fillAmount = amount;

        if (fillAmount > 1)
        {
            fillAmount = 1;
            return;
        }

        if (fillAmount < 0)
        {
            fillAmount = 0;
            return;
        }

        HealthBar.SetActive(fillAmount * maxAmount < maxAmount);

        Bar.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.green, fillAmount);

        FillBar.transform.localScale = new Vector3(fillAmount * maxAmount, 0.955f, 1);
    }
}
