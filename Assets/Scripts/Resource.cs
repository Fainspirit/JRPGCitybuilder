using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Resource
{
    public EResourceType ResourceType { get => _resourceType; }
    [SerializeField] EResourceType _resourceType;
    public Sprite Icon;
    public int Supply;
    public int Demand;

    public delegate void ValuesChangedDelegate(int supply, int demand);
    public event ValuesChangedDelegate OnValuesChanged;

    public int Surplus { get => Supply - Demand; }

    public bool CanChangeSupplyBy(int amount)
    {
        return Supply + amount >= Demand;
    }
    
    public bool CanChangeDemandBy(int amount)
    {
        return Supply >= Demand + amount;
    }

    public bool TryChangeSupply(int amount)
    {
        if (CanChangeSupplyBy(amount))
        {
            ChangeSupply(amount);
            return true;
        }

        return false;
    }

    public bool TryChangeDemand(int amount)
    {
        if (CanChangeDemandBy(amount))
        {
            ChangeDemand(amount);
            return true;
        }

        return false;
    }

    // Demolition / raids
    public void ChangeDemand(int amount)
    {
        Demand += amount;
        OnValuesChanged?.Invoke(Supply, Demand);
    }

    public void ChangeSupply(int amount)
    {
        Supply += amount;
        OnValuesChanged?.Invoke(Supply, Demand);
    }

}
