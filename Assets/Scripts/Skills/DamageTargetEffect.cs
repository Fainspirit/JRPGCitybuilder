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
    [SerializeField] float powerMultiplier = 1;
    [SerializeField] EElement damageType;

    // Can make particles or animations appear, deal damage, etc
    public override IEnumerator ApplyEffect(Battle battle, Unit target, float power)
    {
        Debug.Log("Damaging unit " + target.UnitName + " for " + powerMultiplier * power);
        yield return null;
    }
}

