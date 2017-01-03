using UnityEngine;
using System.Collections;

public class GameObjectFactory
{

    private GameObject objectSource;

    public GameObjectFactory()
    {

    }

    public void SetSource(GameObject source)
    {
        objectSource = source;
    }

    public void Put(Vector3 pos)
    {
        GameObject copied = Object.Instantiate(objectSource) as GameObject;
        copied.transform.Translate(pos);
    }
}