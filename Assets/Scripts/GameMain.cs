using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour
{
    private EnemyFactory enemyFactory;
    private float respawnTime;
    public GameObject enemySource;

    private BlockFactory blockFactory;
    public GameObject blockSource;

    // Use this for initialization
    void Start ()
    {
        enemyFactory = new EnemyFactory();
        enemyFactory.SetSource(enemySource);
        respawnTime = Time.time;

        blockFactory = new BlockFactory();
        blockFactory.SetSource(blockSource);
    }
	
    // Update is called once per frame
    void Update ()
    {
        if (respawnTime + 3.0f < Time.time)
        {
            //enemyFactory.Put(new Vector3(Random.value * 8.0f - Random.value * 8.0f, 0, Random.value * 8.0f - Random.value * 8.0f));
            respawnTime = Time.time;
        }
    }
}
