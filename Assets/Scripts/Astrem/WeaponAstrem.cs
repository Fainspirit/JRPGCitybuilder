using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponAstrem : Astrem
{

    [SerializeField] List<Skill> Skills;
    // type / category buffs

    public WeaponAstrem()
    {
        Skills = new List<Skill>();
    }

    public IEnumerable<Skill> GetSkills()
    {
        foreach (Skill skill in Skills)
        {
            yield return skill;
        }
    }

    public void AddSkill(Skill s)
    {
        Skills.Add(s);
    }
}
