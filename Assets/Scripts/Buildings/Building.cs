using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    public Vector2Int Size;
    public EBuildingType BuildingType;
    public Vector2Int Offset;

    [Space(20)]
    [SerializeField] Vector2Int _position;


    bool _active = false;
    [SerializeField] List<Vector2Int> _occupyingTiles; // tiles this is on

    // Start is called before the first frame update
    void Awake()
    {
        _occupyingTiles = new List<Vector2Int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void LoadModel()
    {

    }

    public void SetTransformPositionToGridPos(Vector2Int pos)
    {
        _position = pos;
        transform.position = new Vector3(pos.x, 0, pos.y) * 2;
    }    

    public void SetBuildingActive(bool val)
    {
        _active = val;
    }

    public void AddOccupiedPos(Vector2Int pos)
    {
        _occupyingTiles.Add(pos);
    }
}
