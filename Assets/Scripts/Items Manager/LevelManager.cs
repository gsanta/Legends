using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;

    private Vector3 bottomLeftEdge;
    private Vector3 topRigthEdge;

    void Start()
    {
        bottomLeftEdge = tilemap.localBounds.min + new Vector3(0.8f, 1f, 0);
        topRigthEdge = tilemap.localBounds.max - new Vector3(0.8f, 1f, 0);

        Player.instance.SetLimit(bottomLeftEdge, topRigthEdge);
    }

    void Update()
    {
        
    }
}
