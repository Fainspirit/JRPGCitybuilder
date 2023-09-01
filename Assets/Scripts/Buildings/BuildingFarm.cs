using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFarm : Building
{
    public override EBuildingType BuildingType => EBuildingType.Gathering_Farm;

    [SerializeField] int FoodProduced;
    [SerializeField] int WaterConsumed;
    [SerializeField] Resource _waterRef;
    [SerializeField] Resource _foodRef;

    protected override void AwakeProtected()
    {
        _waterRef = ResourceManager.GetResource(EResourceType.Water);
        _foodRef = ResourceManager.GetResource(EResourceType.Food);
    }

    protected override bool AllowedToBuildProtected()
    {
        return ResourceManager.GetResource(EResourceType.Water).Surplus >= WaterConsumed;
    }

    protected override void DisableBuildingProtected()
    {
        _waterRef.ChangeDemand(-WaterConsumed);
        _foodRef.ChangeSupply(-FoodProduced);
    }

    protected override void EnableBuildingProtected()
    {
        _waterRef.ChangeDemand(WaterConsumed);
        _foodRef.ChangeSupply(FoodProduced);
    }


}
