using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResourceManager : MonoBehaviour
{
    static ResourceManager _instance;
    static Dictionary<EResourceType, Resource> _resourceDict;

    // Set in editor, pulled into the class
    [SerializeField] List<Resource> _humanResources;
    [SerializeField] List<Resource> _rawResources;
    [SerializeField] List<Resource> _manufacturedResources;

    // Start is called before the first frame update
    void Awake()
    {
        if (FindObjectsOfType<ResourceManager>().Length > 1)
        {
            Debug.Log("Can only have one Resource Manager! Destroying " + name);
            Destroy(gameObject);
            return;
        }
        _instance = this;
        
        SetupResourceLookups();
    }

    void SetupResourceLookups()
    {
        _resourceDict = new Dictionary<EResourceType, Resource>();

        AddResourcesToLookup(_humanResources);
        UIManager.HumanResourcePanel.TrackResourceList(_humanResources);

        AddResourcesToLookup(_rawResources);
        UIManager.RawResourcePanel.TrackResourceList(_rawResources);

        AddResourcesToLookup(_manufacturedResources);
        UIManager.ManufacturedResourcePanel.TrackResourceList(_manufacturedResources);
    }

    void AddResourcesToLookup(List<Resource> resources)
    {
        Resource r;
        foreach (Resource resource in resources)
        {
            if (_resourceDict.TryGetValue(resource.ResourceType, out r))
            {
                throw new System.Exception("Resource already exists: " + resource.ResourceType.ToString());
            }

            _resourceDict[resource.ResourceType] = resource;
            Debug.Log("Registered [RESOURCE] type [" + resource.ResourceType + "]");
        }
    }

    public static Resource GetResource(EResourceType type)
    {
        if (_resourceDict.ContainsKey(type))
        {
            return _resourceDict[type];
        }
        return null;
    }

 
}
