using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TownManager : MonoBehaviour
{
    static TownManager _instance;

    Dictionary<Vector2, Building> _tiles;
    Building _ghostInstance;

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

        InputManager.Controls.Global.Enable();
        InputManager.Controls.Global.One.started += Input_TestOne;
        InputManager.Controls.Global.Two.started += Input_TestTwo;
        InputManager.Controls.Global.Three.started += Input_TestThree;
        InputManager.Controls.Global.Four.started += Input_TestFour;

    }

    void Input_TestOne(InputAction.CallbackContext c)
    {
        TestTryPlaceBuildingAtCursor(EBuildingType.Misc_DirtPath);
    }
    void Input_TestTwo(InputAction.CallbackContext c)
    {
        TestTryPlaceBuildingAtCursor(EBuildingType.Misc_Portal);
    }
    void Input_TestThree(InputAction.CallbackContext c)
    {
        TestTryPlaceBuildingAtCursor(EBuildingType.Gathering_Farm);
    }
    void Input_TestFour(InputAction.CallbackContext c)
    {
        TestTryPlaceBuildingAtCursor(EBuildingType.Gathering_Well);
    }

    void TestTryPlaceBuildingAtCursor(EBuildingType type)
    {
        Debug.Log("Test building placement!");
        Building b = BuildingManager.InstanceBuildingByType(type);

        Vector2Int pos = InputManager.CursorGridPos;
        TryPlaceBuilding(b, pos);
    }

    // BUILDING PLACEMENT
    public static void GhostBuildingPlacement(EBuildingType type, Vector2Int pos)
    {
        _instance._ghostInstance = BuildingManager.InstanceBuildingByType(type);
        _instance._ghostInstance.transform.position = new Vector3(pos.x, 0, pos.y);
    }

    public static void TryPlaceBuilding(Building building, Vector2Int pos)
    {
        if (!IsPlacementValid(building, pos))
        {
            Debug.LogWarning("Invalid placement!");
            Destroy(building.gameObject); // maybe check first eh
            return;
        }

        PlaceBuilding(building, pos);
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
        building.SetBuildingActive(true);

    }
}
