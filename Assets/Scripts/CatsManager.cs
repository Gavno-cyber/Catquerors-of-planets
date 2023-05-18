using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsManager : UnitManager
{
    public GameObject catSprite;
    void Start()
    {
        if (Globals.MYTEAM != this.gameObject.GetComponent<Unit>().Team)
        {
            maskCircle.SetActive(false);
        }
        selectionCircle.GetComponent<DrawScript>().radius = (this.gameObject.GetComponent<BoxCollider2D>().size.x * this.gameObject.transform.localScale.x);
    }

    public override void Select(bool clearSelection)
    {
        if (Globals.MYTEAM != this.gameObject.GetComponent<Unit>().Team)
        {
            return;
        }

        if (Globals.SELECTED_UNITS.Contains(this))
        {
            Deselect();
        }
        if (clearSelection)
        {
            List<UnitManager> selectedUnits = new List<UnitManager>(Globals.SELECTED_UNITS);
            foreach (UnitManager um in selectedUnits)
                um.Deselect();
        }

        Globals.SELECTED_UNITS.Add(this);
        ActivateCircle();
    }
}