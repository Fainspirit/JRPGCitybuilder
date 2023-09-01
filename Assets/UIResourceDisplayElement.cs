using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIResourceDisplayElement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image image;
    [SerializeField] Resource resource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrackResource(Resource r)
    {
        // Register events
        r.OnValuesChanged += UpdateText;
        resource = r;

        // Image
        image.sprite = r.Icon;

        // Initial value
        UpdateText(r.Supply, r.Demand);
    }

    public void UntrackResources()
    {
        if (resource != null)
        {
            resource.OnValuesChanged -= UpdateText;
        }
    }

    public void OnDestroy()
    {
        UntrackResources();    
    }

    void UpdateText(int supply, int demand)
    {
        text.text = (supply - demand).ToString();
    }

    void UpdateTextOld(int supply, int demand)
    {
        int surplus = supply - demand;

        StringBuilder sb = new StringBuilder();

        sb.Append(demand.ToString());
        sb.Append(" / ");
        sb.Append(supply.ToString());

        if (surplus != 0)
        {
            sb.Append(" (");

            if (surplus > 0)
                sb.Append('+');
            else
                sb.Append('-');

            sb.Append(surplus.ToString());
            sb.Append(')');
        }
        text.text = sb.ToString();
    }

}
