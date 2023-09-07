using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DamageAllOnSideEffect : SkillEffect
{
    [SerializeField] float powerMultiplier = 1;
    [SerializeField] EElement damageType;

    // Can make particles or animations appear, deal damage, etc
    public override IEnumerator ApplyEffect(Battle battle, Unit target, float power)
    {
        IEnumerable units;
        if (target.IsAlly)
        {
            units = battle.GetAllies();
        }
        else
        {
            units = battle.GetEnemies();
        }

        foreach (Unit u in units)
        {
            Debug.Log("Damaging unit " + u.UnitName + " for " + powerMultiplier * power);
            yield return null;
        }

    }
}

