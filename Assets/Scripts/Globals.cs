using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static PlayerData MYTEAM;

    public static Dictionary<GameObject, List<GameObject>> PLANETS =
        new Dictionary<GameObject, List<GameObject>>();

    public static Dictionary<PlayerData, List<UnitManager>> SELECTED_UNITS =
        new Dictionary<PlayerData, List<UnitManager>>();

    public static List<PlayerData> PLAYERS = new List<PlayerData>();
}