using UnityEngine;
using System.Collections;

public class EnemyFactory
{
    private GameObject enemySource;

    public EnemyFactory()
    {

    }

    public void SetSource(GameObject source)
    {
        enemySource = source;
    }

    public void Put(Vector3 pos)
    {
        GameObject copied = Object.Instantiate(enemySource) as GameObject;
        copied.transform.Translate(pos);
    }
}
