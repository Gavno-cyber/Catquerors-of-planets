using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsManager : UnitManager
{
    public GameObject catSprite;

    void Start()
    {
        team = this.gameObject.GetComponent<Unit>().Team;

        if (Globals.MYTEAM != team)
        {
            maskCircle.SetActive(false);
        }
        selectionCircle.GetComponent<DrawScript>().radius = (this.gameObject.GetComponent<BoxCollider2D>().size.x * this.gameObject.transform.localScale.x);
    }

    public override void Select(bool clearSelection)
    {
        if (Globals.MYTEAM == team)
        {
            ActivateCircle();
        }
        if (team != null)
        {
            if (Globals.SELECTED_UNITS.ContainsKey(team))
            {
                SelectUnits(clearSelection, Globals.SELECTED_UNITS[team]);
            }
        }
    }

    private void SelectUnits(bool clearSelection, List<UnitManager> selected_units)
    {
        if (selected_units.Contains(this))
        {
            Deselect();
        }
        if (clearSelection)
        {
            for (int i = 0; i < selected_units.Count; i++)
            {
                UnitManager selected_unit = selected_units[i];
                selected_unit.Deselect();
            }
        }

        selected_units.Add(this);
    }
}