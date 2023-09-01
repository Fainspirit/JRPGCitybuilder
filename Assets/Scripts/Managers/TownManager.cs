using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TownManager : MonoBehaviour
{
    static TownManager _instance;

    Dictionary<Vector2, Building> _tiles;
    Building _placementGhostBuilding;

    [SerializeField] List<Building> _buildingList;

    // Start is called before the first frame update
    void Awake()
    {
        if (FindObjectsOfType<TownManager>().Length > 1)
        {
            Debug.Log("Can only have one Town Manager! Destroying " + name);
            Destroy(gameObject);
            return;
        }
        _instance = this;

        _tiles = new Dictionary<Vector2, Building>();
        _buildingList = new List<Building>();

        Testing();
    }

    void Testing()
    {

        InputManager.Controls.Global.Enable();
        InputManager.Controls.Global.One.started += Input_TestOne;
        InputManager.Controls.Global.Two.started += Input_TestTwo;
        InputManager.Controls.Global.Three.started += Input_TestThree;
        InputManager.Controls.Global.Four.started += Input_TestFour;

        InputManager.Controls.Global.Delete.started += Input_DeleteBuildingUnderCursor;
        InputManager.Controls.Global.Confirm.started += Input_PlaceBuildingGhost;
        InputManager.Controls.Global.Cancel.started += Input_DeleteBuildingGhost;

        ResourceManager.GetResource(EResourceType.Civilian).ChangeSupply(99);


        TownManager.TryPlaceBuilding(
            BuildingManager.InstanceBuildingByType(
                EBuildingType.Misc_Portal), new Vector2Int(0, 0));
    }

    void Input_PlaceBuildingGhost(InputAction.CallbackContext c)
    {
        if (_placementGhostBuilding == null)
        {
            return;
        }

        if (BuildingManager.CanBuildBuildingOfType(_placementGhostBuilding.BuildingType))
        {
            // If you put it down
            if (TryPlaceBuilding(_placementGhostBuilding, InputManager.CursorGridPos))
            {
                EBuildingType buildingType = _placementGhostBuilding.BuildingType;

                ForgetPlacementGhost();

                // Make a new one
                CreatePlacementGhost(buildingType);
                
            }
        }
    }

    void Input_DeleteBuildingGhost(InputAction.CallbackContext c)
    {
        DeletePlacementGhost();
    }

    void Input_DeleteBuildingUnderCursor(InputAction.CallbackContext c)
    {
        Building b;
        if (_tiles.TryGetValue(InputManager.CursorGridPos, out b)) {
            b.DestroyBuilding();
        }
    }



    void Input_TestOne(InputAction.CallbackContext c)
    {
        DeleteAndChangePlacementGhost(EBuildingType.Misc_DirtPath);
    }
    void Input_TestTwo(InputAction.CallbackContext c)
    {
        DeleteAndChangePlacementGhost(EBuildingType.Gathering_Well);
    }
    void Input_TestThree(InputAction.CallbackContext c)
    {
        DeleteAndChangePlacementGhost(EBuildingType.Gathering_Farm);
    }
    void Input_TestFour(InputAction.CallbackContext c)
    {
        DeleteAndChangePlacementGhost(EBuildingType.Scouting_ExplorersHut);
    }


    // PLACEMENT GHOST
    void DeleteAndChangePlacementGhost(EBuildingType type)
    {
        Debug.Log("Changing ghost to " + type);
        if (_placementGhostBuilding != null) {
            DeletePlacementGhost();
        }
        CreatePlacementGhost(type);
    }

    void CreatePlacementGhost(EBuildingType type)
    {
        Debug.Log("Creating ghost of " + type);
        _placementGhostBuilding = BuildingManager.InstanceBuildingByType(type);
        MovePlacementGhostTo(InputManager.CursorGridPos);

        InputManager.OnCursorGridPosChanged += MovePlacementGhostTo;
    }

    void MovePlacementGhostTo(Vector2Int gridPos)
    {
        _placementGhostBuilding.transform.position = new Vector3(gridPos.x, 0, gridPos.y) * 2;
    }

    // Remove object entirely
    void DeletePlacementGhost()
    {
        Debug.Log("Removing ghost of " + _placementGhostBuilding.BuildingType);
        Destroy(_placementGhostBuilding.gameObject);
        InputManager.OnCursorGridPosChanged -= MovePlacementGhostTo;
    }

    // Placed it - keep object but remove from tracking
    void ForgetPlacementGhost()
    {
        _placementGhostBuilding = null;
        InputManager.OnCursorGridPosChanged -= MovePlacementGhostTo;
    }


    // BUILDING PLACEMENT
    public static void GhostBuildingPlacement(EBuildingType type, Vector2Int pos)
    {
        _instance._placementGhostBuilding = BuildingManager.InstanceBuildingByType(type);
        _instance._placementGhostBuilding.transform.position = new Vector3(pos.x, 0, pos.y);
    }

    public static bool TryPlaceBuilding(Building building, Vector2Int pos)
    {
        if (!IsPlacementValid(building, pos))
        {
            Debug.LogWarning("Invalid placement!");
            return false;
        }

        PlaceBuilding(building, pos);
        return true;
    }

    static bool IsPlacementValid(Building building, Vector2Int pos)
    {
        var tileDict = _instance._tiles;

        for (int xOff = 0; xOff < building.Size.x; xOff++)
        {
            for (int yOff = 0; yOff < building.Size.y; yOff++)
            {
                Vector2Int posWithOffset = new Vector2Int(pos.x + xOff + building.Offset.x, pos.y + yOff + building.Offset.y);

                // If there's something on one of the tiles
                if (tileDict.ContainsKey(posWithOffset))
                {
                    return false;
                }
            }
        }

        // Never failed
        return true;
    }

    static void PlaceBuilding(Building building, Vector2Int pos)
    {

        Debug.Log("Building " + building.BuildingType + " placed at " + pos);

        _instance._buildingList.Add(building);

        // Mark spots filled
        var tileDict = _instance._tiles;
        for (int xOff = 0; xOff < building.Size.x; xOff++)
        {
            for (int yOff = 0; yOff < building.Size.y; yOff++)
            {
                Vector2Int posWithOffset = new Vector2Int(pos.x + xOff + building.Offset.x, pos.y + yOff + building.Offset.y);
                // If there's something on one of the tiles
                if (tileDict.ContainsKey(posWithOffset))
                {
                    throw new System.Exception("A building was placed where one of its tiles can't be placed!");
                }
                else
                {
                    _instance._tiles[posWithOffset] = building;
                    building.AddOccupiedPos(posWithOffset);
                }
            }
        }

        building.SetTransformPositionToGridPos(pos);
        building.EnableBuilding();

    }

    public static bool IsTileEmpty(Vector2Int pos)
    {
        return !_instance._tiles.ContainsKey(pos);
    }

    public static void FreeTiles(IEnumerable<Vector2Int> positions)
    {
        foreach (var pos in positions)
        {
            _instance._tiles.Remove(pos);
        }
    }
}
