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
    // マテリアル
    public Material material;

    // Use this for initialization
    void Start () {
        rootObject = transform.FindChild("Root").gameObject;
        tipObject = transform.FindChild("Tip").gameObject;
        positionQueue = new Queue();

        var meshrenderer = renderer.GetComponent<MeshRenderer>();
        meshrenderer.material = material;
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
            var uvs = new List<Vector2>();
            int baseNum = 0;
            //1 ÷ 過去フレーム数 - 1
            float uvBaseNum = 1.0f / (positionQueue.Count - 1);
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

                Vector2[] uv = new Vector2[] {
                    new Vector2 (uvBaseNum * i, 1f),
                    new Vector2 (uvBaseNum * (i + 1), 1f),
                    new Vector2 (uvBaseNum * i, 0),
                    new Vector2 (uvBaseNum * (i + 1), 0),
                };
                uvs.AddRange(uv);
            }
            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
            mesh.uv = uvs.ToArray();
            var filter = renderer.GetComponent<MeshFilter>();
            filter.sharedMesh = mesh;
        }
    }
}
