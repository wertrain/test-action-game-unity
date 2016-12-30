using UnityEngine;
using System.Collections;

public class BlockFactory {

    private GameObject blockSource;

    public BlockFactory()
    {

    }

    public void SetSource(GameObject source)
    {
        blockSource = source;
    }

    public void Put(Vector3 pos)
    {
        GameObject copied = Object.Instantiate(blockSource) as GameObject;
        copied.transform.Translate(pos);
    }
}
