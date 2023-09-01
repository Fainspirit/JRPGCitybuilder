using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResourceDisplayPanel : MonoBehaviour
{
    [SerializeField] List<Resource> _trackedResources;
    [SerializeField] UIResourceDisplayElement _elementPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrackResourceList(List<Resource> list)
    {
        _trackedResources = list;
        int count = 0;
        float offsetEach = -_elementPrefab.GetComponent<RectTransform>().rect.height;

        foreach (Resource resource in _trackedResources)
        {

            // Make display element
            UIResourceDisplayElement displayElement = Instantiate(_elementPrefab);

            // Parent
            displayElement.transform.SetParent(transform, false);

            // Track it
            displayElement.TrackResource(resource);

            // position it
            displayElement.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, offsetEach) * count;

            count++;
        }

        // Resize panel
        RectTransform t = GetComponent<RectTransform>();
        t.sizeDelta = new Vector2(t.sizeDelta.x, -offsetEach * count);
    }

    public void StopTrackingResources()
    {
        foreach (UIResourceDisplayElement uirde in GetComponentsInChildren<UIResourceDisplayElement>())
        {
            Destroy(uirde);
        }
    }
}
