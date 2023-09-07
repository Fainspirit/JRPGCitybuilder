using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Equipment : ScriptableObject
{
    public int Level { get => _level; }
    [SerializeField, Range(1,10)] protected int _level = 1;

}
