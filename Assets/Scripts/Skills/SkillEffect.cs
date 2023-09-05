using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class SkillEffect : ScriptableObject
{
    // Can make particles or animations appear, deal damage, etc
    public abstract IEnumerator ApplyEffect(Battle battle, Unit unit, float power);
}

