using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWell : Building
{
    public override EBuildingType BuildingType => EBuildingType.Gathering_Well;

    [SerializeField] int WaterProduced;
    [SerializeField] Resource _waterRef;

    protected override void AwakeProtected()
    {
        _waterRef = ResourceManager.GetResource(EResourceType.Water);
    }

    protected override bool AllowedToBuildProtected()
    {
        return true;
    }

    protected override void DisableBuildingProtected()
    {
        _waterRef.ChangeSupply(-WaterProduced);
    }

    protected override void EnableBuildingProtected()
    {
        _waterRef.ChangeSupply(WaterProduced);

    }


}
