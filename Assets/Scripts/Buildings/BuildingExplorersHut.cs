using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingExplorersHut : Building
{
    public override EBuildingType BuildingType => EBuildingType.Scouting_ExplorersHut;

    [SerializeField] int FoodConsumed;

    [SerializeField] Dungeon _currentDungeon;
    [SerializeField] float scoutTimeNeeded;
    [SerializeField] float scoutTimeElapsed;

    Coroutine _scoutRoutine;

    protected override void AwakeProtected()
    {

    }

    private void Update()
    {
        
    }

    IEnumerator ScoutRoutine()
    {
        Debug.Log("Begin scouting dungeon!");

        while (scoutTimeElapsed < scoutTimeNeeded)
        {
            scoutTimeElapsed += Time.deltaTime;
            yield return null;
        }

        // Find a dungeon (DungeonManager)
        Debug.Log("Found dungeon!");

        // Start this again
        //_scoutRoutine = StartCoroutine(ScoutRoutine());
    }

    protected override bool AllowedToBuildProtected()
    {
        return ResourceManager.GetResource(EResourceType.Food).Surplus >= FoodConsumed;
    }



    protected override void EnableBuildingProtected()
    {
        // res
        ResourceManager.GetResource(EResourceType.Food).ChangeDemand(FoodConsumed);

        _scoutRoutine = StartCoroutine(ScoutRoutine());
    }

    protected override void DisableBuildingProtected()
    {
        // res
        ResourceManager.GetResource(EResourceType.Food).ChangeDemand(-FoodConsumed);

        if (_scoutRoutine != null)
        {
            StopCoroutine(_scoutRoutine);
        }
    }

}
