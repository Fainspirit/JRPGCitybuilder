using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDirtPath : Building
{
    public override EBuildingType BuildingType => EBuildingType.Misc_DirtPath;

    protected override void AwakeProtected()
    {
    }

    protected override bool AllowedToBuildProtected()
    {
        return true;
    }

    protected override void DisableBuildingProtected()
    {
    }

    protected override void EnableBuildingProtected()
    {

    }


}
