using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string UnitName;
    [SerializeField] EClass Class;
    [SerializeField] public bool IsAlly;
    [SerializeField] Weapon Weapon;

    public Battle Battle;

    private void Start()
    {
        Weapon = Weapon.CreateAtLevel(7);
        foreach (var skillCastData in Weapon.SkillCastData)
        {
            CastSkill(skillCastData, this);
        }
    }


    public void CastSkill(SkillCastData skillCastData, Unit target)
    {
        StartCoroutine(CastSkillRoutine(skillCastData, target));
    }

    IEnumerator CastSkillRoutine(SkillCastData skillCastData, Unit target)
    {
        Debug.Log(UnitName +
            " casting " +
            skillCastData.Skill.name +
            " at level " +
            skillCastData.CastLevel +
            " on " +
            target.UnitName);

        yield return skillCastData.Skill.CastAtLevel(Battle, target, skillCastData.CastLevel);
    }
}