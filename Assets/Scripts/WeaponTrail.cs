using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[RequireComponent(typeof(MeshRenderer))]
//[RequireComponent(typeof(MeshFilter))]
public class WeaponTrail : MonoBehaviour {

    // 軌跡のポリゴン数
    private const int MAX_TRAIL_NUM = 7;
    // 軌跡を描く根の位置
    private GameObject rootObject;
    // 軌跡を描く先端の位置
    private GameObject tipObject;
    // 位置の履歴
    private Queue positionQueue;
    // 軌跡情報格納構造体
    private struct WeaponPosInfo
    {
        public Vector3 Root { get; set; }
        public Vector3 Tip { get; set; }
    }
    // レンダラー
    public new GameObject renderer;

    // Use this for initialization
    void Start () {
        rootObject = GameObject.Find("Root");
        tipObject = GameObject.Find("Tip");
        positionQueue = new Queue();

        /*var mesh = new Mesh();
        mesh.vertices = new Vector3[] {
            new Vector3 (tipObject.transform.localPosition.x, tipObject.transform.localPosition.y - 0.1f, tipObject.transform.localPosition.z),
            new Vector3 (tipObject.transform.localPosition.x, tipObject.transform.localPosition.y + 0.1f, tipObject.transform.localPosition.z),
            new Vector3 (rootObject.transform.localPosition.x, rootObject.transform.localPosition.y + 0.1f, rootObject.transform.localPosition.z),
            new Vector3 (rootObject.transform.localPosition.x, rootObject.transform.localPosition.y - 0.1f, rootObject.transform.localPosition.z),
        };
        mesh.triangles = new int[] {
            0, 2, 1,
            0, 3, 2
        };

        var filter = GetComponent<MeshFilter>();
        filter.sharedMesh = mesh;*/

    }

    // Update is called once per frame
    void Update () {

        positionQueue.Enqueue(new WeaponPosInfo
        {
            Root = rootObject.transform.position,
            Tip = tipObject.transform.position,
        });
        if (positionQueue.Count > MAX_TRAIL_NUM)
        {
            positionQueue.Dequeue();

            var mesh = new Mesh();
            var array = positionQueue.ToArray();
            var vertices = new List<Vector3>();
            var triangles = new List<int>();
            int baseNum = 0;
            for (int i = 0; i < positionQueue.Count - 1; ++i)
            {
                WeaponPosInfo i0 = (WeaponPosInfo)array[i + 0];
                WeaponPosInfo i1 = (WeaponPosInfo)array[i + 1];
                Vector3[] vecs = new Vector3[]
                {
                    new Vector3 (i0.Tip.x, i0.Tip.y, i0.Tip.z),
                    new Vector3 (i1.Tip.x, i1.Tip.y, i1.Tip.z),
                    new Vector3 (i1.Root.x, i1.Root.y, i1.Root.z),
                    new Vector3 (i0.Root.x, i0.Root.y, i0.Root.z)
                };
                vertices.AddRange(vecs);

                int[] tris = new int[]
                {
                    baseNum, baseNum + 2, baseNum + 1,
                    baseNum, baseNum + 3, baseNum + 2,
                };
                triangles.AddRange(tris);
                baseNum += 4;
            }
            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
            var filter = renderer.GetComponent<MeshFilter>();
            filter.sharedMesh = mesh;
        }
    }
}
