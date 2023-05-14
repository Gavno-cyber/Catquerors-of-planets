using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    string unit;
    string typeUnit;
    string team;
    int max;
    int range;
    int health;
    int damage;
    public Text info;
    public GameObject textField;
    GameObject cat;
    public GameObject infoPlanets;
    public GameObject infoCats;

    void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "PlanetAttack":
                unit = "Планета";
                typeUnit = "Спавнер (атака)";
                max = GetComponent<PlanetAttack>().MaxSpawn;
                range = GetComponent<PlanetAttack>().MaxRange;
                info = textField.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t\t    " + max + '\n' + "\t\t\t " + range;
                break;
            case "StandartPlanet":
                unit = "Планета";
                typeUnit = "Стандартная (союзн.)";
                max = GetComponent<StandartPlanet>().MaxSpawn;
                range = GetComponent<StandartPlanet>().MaxRange;
                info = textField.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t\t    " + max + '\n' + "\t\t\t " + range;
                break;
            case "StandartPlanet (1)":
                unit = "Планета";
                typeUnit = "Стандартная (вражеск.)";
                max = GetComponent<StandartPlanet>().MaxSpawn;
                range = GetComponent<StandartPlanet>().MaxRange;
                info = textField.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t\t    " + max + '\n' + "\t\t\t " + range;
                break;
            case "Planet (6)":
                unit = "Планета";
                typeUnit = "Спавнер (защита)";
                max = GetComponent<PlanetDefend>().MaxSpawn;
                range = GetComponent<PlanetDefend>().MaxRange;
                info = textField.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t\t    " + max + '\n' + "\t\t\t " + range;
                break;
            case "BasePlanet":
;               unit = "Планета";
                typeUnit = "Стандартная";
                max = GetComponent<StandartPlanet>().MaxSpawn;
                range = GetComponent<StandartPlanet>().MaxRange;
                info = textField.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t\t    " + max + '\n' + "\t\t\t " + range;
                break;

            case "Standart1(Clone)":
                unit = "Кот";
                typeUnit = "Стандартный";
                team = "Союзный";
                health = GetComponent<CatStandart>().HP;
                damage = GetComponent<CatStandart>().Damage;
                info = info.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t  " + team + '\n' + "\t\t   " + health + '\n' + "   " + damage;
                break;
            case "Standart2(Clone)":
                unit = "Кот";
                typeUnit = "Стандартный";
                team = "Вражеский";
                health = GetComponent<CatStandart>().HP;
                damage = GetComponent<CatStandart>().Damage;
                info = info.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t  " + team + '\n' + "\t\t   " + health + '\n' + "   " + damage;
                break;
            case "Attacker(Clone)":
                unit = "Кот";
                typeUnit = "Атакующий";
                team = GetComponent<CatDamager>().team;
                health = GetComponent<CatDamager>().HP;
                damage = GetComponent<CatDamager>().Damage;
                info = info.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t  " + team + '\n' + "\t\t   " + health + '\n' + "   " + damage;
                break;
            case "Defender(Clone)":
                unit = "Кот";
                typeUnit = "Защитный";
                team = GetComponent<CatDefender>().team;
                health = GetComponent<CatDefender>().HP;
                damage = GetComponent<CatDefender>().Damage;
                info = info.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t  " + team + '\n' + "\t\t   " + health + '\n' + "   " + damage;
                break;
        }
    }
}
