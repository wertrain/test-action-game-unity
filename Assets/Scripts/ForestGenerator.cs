using UnityEngine;
using System.Collections;

public class ForestGenerator : MonoBehaviour
{
    // 元となるゲームオブジェクト
    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;
    public GameObject bush1;
    public GameObject bush2;
    public GameObject bush3;
    public GameObject bush4;

    private int treeZArea = 30;
    private int treeXArea = 30;
    private int bushZArea = 40;
    private int bushXArea = 40;
    private float putStartX = -30.0f;
    private float putStartZ = -30.0f;
    private float treePutInterval = 4.0f;
    private float bushPutInterval = 2.0f;

    // Use this for initialization
    void Start () {
        GameObject[] baseTrees = { tree1, tree2, tree3, tree4 };
        for (int z = 0; z < treeZArea; ++z)
        {
            for (int x = 0; x < treeXArea; ++x)
            {
                if (Random.value > 0.5f)
                {
                    int treeIndex = Mathf.FloorToInt(Random.value * baseTrees.Length);
                    Instantiate(baseTrees[treeIndex], 
                        new Vector3(putStartX + x * treePutInterval, 0, putStartZ + z * treePutInterval), 
                        new Quaternion());
                }
            }
        }
        GameObject[] baseBushs = { bush1, bush2, bush3, bush4 };
        for (int z = 0; z < bushZArea; ++z)
        {
            for (int x = 0; x < bushXArea; ++x)
            {
                if (Random.value > 0.5f)
                {
                    int bushIndex = Mathf.FloorToInt(Random.value * baseBushs.Length);
                    Instantiate(baseBushs[bushIndex], 
                        new Vector3(putStartX + x * bushPutInterval, 0, putStartZ + z * bushPutInterval), 
                        new Quaternion());
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
        
    }
}
