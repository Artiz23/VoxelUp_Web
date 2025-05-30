using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Transform Begin;
    public Transform End;

    public Mesh[] BlockMeshes;
    
    public AnimationCurve ChanceFromDistance;

    private void Start()
    {
        if (BlockMeshes != null && BlockMeshes.Length > 0)
        {
            foreach (var filter in GetComponentsInChildren<MeshFilter>())
            {
                if (filter.sharedMesh == BlockMeshes[0])
                {
                    int randomMeshIndex = Random.Range(0, BlockMeshes.Length);
                    filter.sharedMesh = BlockMeshes[randomMeshIndex];
                    filter.transform.rotation = Quaternion.Euler(-90, 0, 90 * Random.Range(0, 4));
                }
            }
        }
       
    }
}
