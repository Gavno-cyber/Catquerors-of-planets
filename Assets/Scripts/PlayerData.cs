using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public Color color;
    string team;

    public PlayerData(Color color, string team)
    {
        this.color = color;
        this.team = team;
    }

    public Color Color { get => color; set => color = value; }
    public string Team { get => team; set => team = value; }
}
