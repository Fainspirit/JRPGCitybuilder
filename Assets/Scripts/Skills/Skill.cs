using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill")]
public class Skill : ScriptableObject
{
    //[SerializeField, Tooltip("Skill Name")] 
    //string SkillName;

    //[SerializeField]
    //EClass Class;

    [SerializeField]
    EElement Element;

    [SerializeField, Tooltip("Mana Cost"), Range(0,18)] 
    int Mana = 6;
    
    //[SerializeField, Tooltip("Skill Level"), Range(1, 10)] 
    //int Level = 1;

    [SerializeField, Tooltip("Who can be targeted by this skill")]
    ESkillTargetType TargetType;

    //[SerializeField, Tooltip("How will the target change when the skill effect repeats")]
    //ESkillRepeatTargetChangeType RepeatTargetChangeType;

    [SerializeField] List<SkillEffect> SkillEffects;
    public int EffectCount { get => SkillEffects.Count; }

    static float MANA_POW_COEF = 1f / 48f;
    static float MANA_POW_BIAS = 0.25f;

    static float POWER_COEF = 0.3f;
    static float POWER_SCALAR = 20;


    public IEnumerator CastAtLevel(Battle battle, Unit target, int level)
    {
        float power = GetManaPowerMultiplier() * GetPowerFromLevel(level);
        Debug.Log("Casting skill " + name + " with power " + power);
        foreach (SkillEffect effect in SkillEffects)
        {
            yield return effect.ApplyEffect(battle, target, power);
        }
    }

    // 0: 0.25, 3: 0.43475, 6: 1, 9: 1.9375, 12: 3.25, 15: 4.9375, 18: 7
    float GetManaPowerMultiplier()
    {
        return MANA_POW_COEF * Mana * Mana + MANA_POW_BIAS;
    }

    // approx 34, 51, 72, 97, 125, 157, 192, 231, 274, 320
    float GetPowerFromLevel(int level)
    {
        return Mathf.Pow(1 + POWER_COEF * level, 2.0f) * POWER_SCALAR;
    }
}
