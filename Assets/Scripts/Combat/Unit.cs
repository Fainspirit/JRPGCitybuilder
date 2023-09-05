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

    [SerializeField] List<Skill> _skills;

    public Battle Battle;

    private void Start()
    {
        foreach (var skill in _skills)
        {
            CastSkill(skill, this);
        }
    }


    public void CastSkill(Skill skill, Unit target)
    {
        Debug.Log(UnitName + " casting " + skill.name + " on " + target.UnitName);
        StartCoroutine(CastSkillRoutine(skill, target));
    }

    IEnumerator CastSkillRoutine(Skill skill, Unit target)
    {
        int currentEffect = 0;

        while (currentEffect < _skills.Count)
        {
            yield return _skills.ElementAt(currentEffect).Cast(Battle, target);
            currentEffect++;
        }

        yield return null;
    }
}