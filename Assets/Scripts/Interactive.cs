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
                unit = "�������";
                typeUnit = "������� (�����)";
                max = GetComponent<PlanetAttack>().MaxSpawn;
                range = GetComponent<PlanetAttack>().MaxRange;
                info = textField.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t\t    " + max + '\n' + "\t\t\t " + range;
                break;
            case "StandartPlanet":
                unit = "�������";
                typeUnit = "����������� (�����.)";
                max = GetComponent<StandartPlanet>().MaxSpawn;
                range = GetComponent<StandartPlanet>().MaxRange;
                info = textField.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t\t    " + max + '\n' + "\t\t\t " + range;
                break;
            case "StandartPlanet (1)":
                unit = "�������";
                typeUnit = "����������� (�������.)";
                max = GetComponent<StandartPlanet>().MaxSpawn;
                range = GetComponent<StandartPlanet>().MaxRange;
                info = textField.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t\t    " + max + '\n' + "\t\t\t " + range;
                break;
            case "Planet (6)":
                unit = "�������";
                typeUnit = "������� (������)";
                max = GetComponent<PlanetDefend>().MaxSpawn;
                range = GetComponent<PlanetDefend>().MaxRange;
                info = textField.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t\t    " + max + '\n' + "\t\t\t " + range;
                break;
            case "BasePlanet":
;               unit = "�������";
                typeUnit = "�����������";
                max = GetComponent<StandartPlanet>().MaxSpawn;
                range = GetComponent<StandartPlanet>().MaxRange;
                info = textField.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t\t    " + max + '\n' + "\t\t\t " + range;
                break;

            case "Standart1(Clone)":
                unit = "���";
                typeUnit = "�����������";
                team = "�������";
                health = GetComponent<CatStandart>().HP;
                damage = GetComponent<CatStandart>().Damage;
                info = info.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t  " + team + '\n' + "\t\t   " + health + '\n' + "   " + damage;
                break;
            case "Standart2(Clone)":
                unit = "���";
                typeUnit = "�����������";
                team = "���������";
                health = GetComponent<CatStandart>().HP;
                damage = GetComponent<CatStandart>().Damage;
                info = info.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t  " + team + '\n' + "\t\t   " + health + '\n' + "   " + damage;
                break;
            case "Attacker(Clone)":
                unit = "���";
                typeUnit = "���������";
                team = GetComponent<CatDamager>().team;
                health = GetComponent<CatDamager>().HP;
                damage = GetComponent<CatDamager>().Damage;
                info = info.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t  " + team + '\n' + "\t\t   " + health + '\n' + "   " + damage;
                break;
            case "Defender(Clone)":
                unit = "���";
                typeUnit = "��������";
                team = GetComponent<CatDefender>().team;
                health = GetComponent<CatDefender>().HP;
                damage = GetComponent<CatDefender>().Damage;
                info = info.GetComponent<Text>();
                info.text = "    " + unit + '\n' + " " + typeUnit + '\n' + "\t\t  " + team + '\n' + "\t\t   " + health + '\n' + "   " + damage;
                break;
        }
    }
}
