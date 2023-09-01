using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public int CivilianCost;
    public Vector2Int Size;
    public abstract EBuildingType BuildingType { get; }
    public Vector2Int Offset;

    [Space(20)]
    [SerializeField] Vector2Int _position;


    bool _active = false;
    [SerializeField] List<Vector2Int> _occupyingTiles; // tiles this is on

    public delegate void VoidDelegate();
    public event VoidDelegate OnBuildingActivated;
    public event VoidDelegate OnBuildingDisabled;



    // Start is called before the first frame update
    void Awake()
    {
        _occupyingTiles = new List<Vector2Int>();
        AwakeProtected();
    }
    protected abstract void AwakeProtected();


    // Update is called once per frame
    void Update()
    {
        
    }

    protected void LoadModel()
    {

    }

    public List<Vector2Int> GetOccupiedTiles()
    {
        return _occupyingTiles;
    }


    public bool AllowedToBuild()
    {
        return ResourceManager.GetResource(EResourceType.Civilian).Surplus >= CivilianCost &&
            AllowedToBuildProtected();
    }
    protected abstract bool AllowedToBuildProtected();



    public void SetTransformPositionToGridPos(Vector2Int pos)
    {
        _position = pos;
        transform.position = new Vector3(pos.x, 0, pos.y) * 2;
    }


    // State change


    public void EnableBuilding()
    {
        _active = true;
        ResourceManager.GetResource(EResourceType.Civilian).ChangeDemand(CivilianCost);
        //OnBuildingActivated?.Invoke();
        EnableBuildingProtected();
    }
    protected abstract void EnableBuildingProtected();



    public void DisableBuilding()
    {
        _active = false;
        ResourceManager.GetResource(EResourceType.Civilian).ChangeDemand(-CivilianCost);
        // OnBuildingDisabled?.Invoke();
        DisableBuildingProtected();
    }
    protected abstract void DisableBuildingProtected();


    public void DestroyBuilding()
    {
        DisableBuilding();

        TownManager.FreeTiles(_occupyingTiles);

        Destroy(gameObject);
    }

    public void AddOccupiedPos(Vector2Int pos)
    {
        _occupyingTiles.Add(pos);
    }
}
