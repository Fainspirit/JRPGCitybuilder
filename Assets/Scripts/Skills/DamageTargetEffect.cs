using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageTargetEffect", menuName = "Skill Effects/Damage Target")]
public class DamageTargetEffect : SkillEffect
{
    [SerializeField] int repeatCount = 1;
    [SerializeField] float powerMultiplier = 1;
    [SerializeField] EElement damageType;

    // Can make particles or animations appear, deal damage, etc
    public override IEnumerator ApplyEffect(Battle battle, Unit unit, float power)
    {
        for (int i = 0; i < repeatCount; i++)
        {
            Debug.Log("Damaging unit " + unit.UnitName + " for " + powerMultiplier * power);
            yield return null;
        }

        yield return null;  
    }
}

