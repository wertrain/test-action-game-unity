using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
    GameObject parent;

    // Use this for initialization
    void Start ()
    {
        parent = gameObject.transform.parent.gameObject;
    }
	
    // Update is called once per frame
    void Update ()
    {
	
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("EnemySight::OnCollisionEnter -> " + collision.gameObject.name);
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("EnemySight::OnTriggerEnter -> " + collider.name);
    }
}
