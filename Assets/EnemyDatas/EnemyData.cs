using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ZeroQuest/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int body;
    public int spirit;
    public int attack;
    public int defense;
    public int movement;
    public GameObject model;
}
