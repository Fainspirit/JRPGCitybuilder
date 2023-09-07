using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Astrem
{
    [SerializeField] string AstremName;
    [SerializeField] EClass Class;

    public int Level { get => _level; }
    [SerializeField] protected int _level;

}
