using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    static BuildingManager _instance;

    Dictionary<EBuildingType, Building> _buildings;
    [SerializeField] Building _defaultBuilding;
    [SerializeField] List<Building> _buildingPool;

    void Awake()
    {
        if (FindObjectsOfType<BuildingManager>().Length > 1)
        {
            Debug.LogError("Can only have one Building Manager! Destroying " + name);
            Destroy(gameObject);
            return;
        }
        _instance = this;

        SetupModelLookups();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetupModelLookups()
    {
        _buildings = new Dictionary<EBuildingType, Building>();
        Building b;

        foreach (Building building in _buildingPool)
        {
            if (_buildings.TryGetValue(building.BuildingType, out b))
            {
                throw new System.Exception("Building type already exists: " + building.BuildingType.ToString());
            }

            _buildings[building.BuildingType] = building;
            Debug.Log("Registered [BUILDING] type [" + building.BuildingType + "]");



        }
    }

    public static Building InstanceBuildingByType(EBuildingType type)
    {
        if (_instance._buildings.ContainsKey(type))
        {
            Building b = Instantiate(_instance._buildings[type]);
            return b;
        }

        else
        {
            Debug.LogWarning("Could not find building of type " + type);
            return Instantiate(_instance._defaultBuilding);
        }
    }

    public static bool CanBuildBuildingOfType(EBuildingType type)
    {
        if (_instance._buildings.ContainsKey(type))
        {
            return _instance._buildings[type].AllowedToBuild();
        }

        Debug.LogWarning("Could not find building of type " + type);
        return false;
    }
}
