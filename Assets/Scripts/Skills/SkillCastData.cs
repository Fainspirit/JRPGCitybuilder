using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct SkillCastData
{
    public Skill Skill;
    public int CastLevel;

    public SkillCastData(Skill s, int l)
    {
        Skill = s;
        CastLevel = l;
    }
}