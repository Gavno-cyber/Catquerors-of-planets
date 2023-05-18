using UnityEngine;

public class FillBar : MonoBehaviour
{
    public float fillAmount;
    public float maxAmount;
    public GameObject FillCircle;

    float amountToFill = 0;

    void Start()
    {
        fillAmount = this.gameObject.GetComponent<Planet>().HP / this.gameObject.GetComponent<Planet>().MaxHP;

        TranslateCircle(fillAmount);
    }

    public void ChangeAmount(float amount)
    {
        fillAmount += amount;

        if (fillAmount > 1)
        {
            fillAmount = 1;
            return;
        }

        if (fillAmount < 0) {
            fillAmount = 0;
            return;
        }

        TranslateCircle(amount);
    }

    public void TranslateCircle(float amount)
    {
        amountToFill = maxAmount * amount;

        FillCircle.transform.Translate(0, amountToFill / 2, 0);
    }
}
