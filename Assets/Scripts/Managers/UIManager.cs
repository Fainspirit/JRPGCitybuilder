using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;
    public static UIResourceDisplayPanel HumanResourcePanel { get => _instance._humanResourcePanel; }
    [SerializeField] UIResourceDisplayPanel _humanResourcePanel;

    public static UIResourceDisplayPanel RawResourcePanel { get => _instance._rawResourcePanel; }
    [SerializeField] UIResourceDisplayPanel _rawResourcePanel;

    public static UIResourceDisplayPanel ManufacturedResourcePanel { get => _instance._manufacturedResourcePanel; }
    [SerializeField] UIResourceDisplayPanel _manufacturedResourcePanel;

    // Start is called before the first frame update
    void Awake()
    {
        if (FindObjectsOfType<UIManager>().Length > 1)
        {
            Debug.Log("Can only have one UI Manager! Destroying " + name);
            Destroy(gameObject);
            return;
        }

        _instance = this;


    }


}
