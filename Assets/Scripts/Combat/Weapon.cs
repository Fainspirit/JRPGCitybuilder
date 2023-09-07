using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skill + category Power
[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]

public class Weapon : Equipment
{
    [SerializeField] Skill LockedSkill;

    [SerializeField] WeaponAstrem[] SkillAstremSlots;
    [SerializeField] ArmorAstrem[] PowerAstremSlots;

    public IEnumerable<SkillCastData> SkillCastData { get => GetSkillCastData(); }

    private void Awake()
    {

    }

    IEnumerable<SkillCastData> GetSkillCastData()
    {
        yield return new SkillCastData(LockedSkill, _level);

        foreach (WeaponAstrem skillAstrem in SkillAstremSlots)
        {
            if (skillAstrem == null) continue;

            int maxLevel = Mathf.Max(skillAstrem.Level, _level);
            foreach (Skill skill in skillAstrem.GetSkills())
            {
                yield return new SkillCastData(skill, maxLevel);
            }
        }
    }

    public bool SetSkillAstrem(WeaponAstrem sa, int slot)
    {
        if (slot >= 0 && slot < SkillAstremSlots.Length)
        {
            SkillAstremSlots[slot] = sa;
            return true;
        }

        return false;
    }

    public bool SetPowerAstrem(ArmorAstrem pa, int slot)
    {
        if (slot >= 0 && slot < PowerAstremSlots.Length)
        {
            PowerAstremSlots[slot] = pa;
            return true;
        }

        return false;
    }

    public Weapon CreateAtLevel(int level)
    {
        Weapon newWeapon = Instantiate(this);
        newWeapon._level = level;

        newWeapon.SkillAstremSlots = new WeaponAstrem[level / 2];
        newWeapon.PowerAstremSlots = new ArmorAstrem[level / 2];

        return newWeapon;
    }
}
