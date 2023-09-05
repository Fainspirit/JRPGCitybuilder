using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Battle
{
    List<Unit> allies;
    List<Unit> enemies;

    void Initialize()
    {
        allies = new List<Unit>();
        enemies = new List<Unit>();
    }

    public IEnumerable<Unit> GetAllies()
    {
        foreach (var unit in allies)
        {
            yield return unit;  
        }
    }

    public IEnumerable<Unit> GetEnemies()
    {
        foreach (var unit in enemies)
        {
            yield return unit;
        }
    }

    public void AddAlly(Unit unit)
    {
        allies.Add(unit);
        unit.Battle = this;
    }

    public void AddEnemy(Unit unit)
    {
        enemies.Add(unit);
        unit.Battle = this;
    }
}