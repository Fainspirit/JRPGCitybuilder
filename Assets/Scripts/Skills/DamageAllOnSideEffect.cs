using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DamageAllOnSideEffect : SkillEffect
{
    // Can make particles or animations appear, deal damage, etc
    public override IEnumerator ApplyEffect(Battle battle, Unit unit, float power)
    {
        Debug.Log("Damaging unit " + unit.name);
        yield return null;
    }
}

