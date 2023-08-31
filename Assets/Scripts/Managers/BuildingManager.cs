using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    static BuildingManager _instance;

    Dictionary<EBuildingType, Building> buildings = new Dictionary<EBuildingType, Building>();

    [SerializeField] Building _defaultBuilding;
    [SerializeField] List<BuildingModelInfo> _infos;

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


        TownManager.TryPlaceBuilding(
            BuildingManager.InstanceBuildingByType(
                EBuildingType.Misc_Portal), new Vector2Int(0, 0));
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
        foreach (BuildingModelInfo info in _infos)
        {
            buildings[info.BuildingType] = info.ModelObject;
        }
    }

    public static Building InstanceBuildingByType(EBuildingType type)
    {
        if (_instance.buildings.ContainsKey(type))
        {
            Building b = Instantiate(_instance.buildings[type]);
            return b;
        }

        else
        {
            return Instantiate(_instance._defaultBuilding);
        }
    }
}
