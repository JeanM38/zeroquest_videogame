using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{
    public EnemyData enemyData;
    public int body;
    public int spirit;
    public int attack;
    public int defense;
    public int movement;

    // Start is called before the first frame update
    void Start()
    {
        if (enemyData)
        {
            Initialize(enemyData);
        }
    }

    // Update is called once per frame
    private void Initialize(EnemyData data)
    {
        GameObject enemy = Instantiate(data.model);
        enemy.transform.SetParent(transform);
        enemy.transform.localPosition = Vector3.zero;
        enemy.transform.rotation = Quaternion.identity;

        enemy.name = data.enemyName;
        body = data.body;
        attack = data.attack;
        defense = data.defense;
        movement = data.movement;
        spirit = data.spirit;

        BoxCollider boxCollider = this.gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(0.1f, 0.1f, 0.1f);
        boxCollider.isTrigger = true;
    }
}
