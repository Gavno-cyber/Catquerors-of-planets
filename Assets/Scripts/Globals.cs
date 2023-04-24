using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static Dictionary<GameObject, List<GameObject>> PLANETS =
        new Dictionary<GameObject, List<GameObject>>();

    public static List<UnitManager> SELECTED_UNITS = new List<UnitManager>();
}