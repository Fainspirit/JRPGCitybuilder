using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TemplateManager : MonoBehaviour
{
    static TemplateManager _instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (FindObjectsOfType<TemplateManager>().Length > 1)
        {
            Debug.Log("Can only have one Template Manager! Destroying " + name);
            Destroy(gameObject);
            return;
        }

        _instance = this;


    }


}
