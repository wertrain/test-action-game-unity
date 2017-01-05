using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour
{
    private const float ENEMY_RESPAWN_RANGE = 8.0f;
    private GameObjectFactory enemyFactory;
    private float enemyRespawnTime;
    public GameObject enemySource;

    private const float BLOCK_CREATE_RANGE = 8.0f;
    private GameObjectFactory blockFactory;
    private float blockCreateTime;
    public GameObject blockSource;

    // Use this for initialization
    void Start ()
    {
        enemyFactory = new GameObjectFactory();
        enemyFactory.SetSource(enemySource);
        enemyRespawnTime = Time.time;

        blockFactory = new GameObjectFactory();
        blockFactory.SetSource(blockSource);
        blockCreateTime = Time.time;
    }
	
    // Update is called once per frame
    void Update ()
    {
        if (enemyRespawnTime + 3.0f < Time.time)
        {
            //enemyFactory.Put(new Vector3(Random.value * ENEMY_RESPAWN_RANGE - Random.value * ENEMY_RESPAWN_RANGE, 0, Random.value * ENEMY_RESPAWN_RANGE - Random.value * ENEMY_RESPAWN_RANGE));
            enemyRespawnTime = Time.time;
        }

        if (blockCreateTime + 3.0f < Time.time)
        {
            //blockFactory.Put(new Vector3(Random.value * BLOCK_CREATE_RANGE - Random.value * BLOCK_CREATE_RANGE, 0, Random.value * BLOCK_CREATE_RANGE - Random.value * BLOCK_CREATE_RANGE));
            blockCreateTime = Time.time;
        }
    }
}
