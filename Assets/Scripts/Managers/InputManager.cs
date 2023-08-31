using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    static InputManager _instance;
    public static Controls Controls { get; private set; }

    [SerializeField] LayerMask _layerMaskIgnoredForMouseRaycast;

    public static Vector3 CursorPos3D { get => _cursorPos3D; }
    static Vector3 _cursorPos3D;

    public static Vector2Int CursorGridPos { get => _cursorGridPos; }
    static Vector2Int _cursorGridPos;


    // Start is called before the first frame update
    private void Awake()
    {
        if (FindObjectsOfType<InputManager>().Length > 1)
        {
            Debug.LogError("Can only have one Input Manager! Destroying " + name);
            Destroy(gameObject);
            return;
        }

        _instance = this;
        Controls = new Controls();

    }


    // Update is called once per frame
    void Update()
    {
        UpdateMousePos3D();
        UpdateMouseGridPos();
    }


    void UpdateMousePos3D()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~_instance._layerMaskIgnoredForMouseRaycast))
        {
            _cursorPos3D = hit.point;
        }
    }

    void UpdateMouseGridPos()
    {
        _cursorGridPos = new Vector2Int(Mathf.RoundToInt(_cursorPos3D.x * 0.5f), Mathf.RoundToInt(_cursorPos3D.z * 0.5f));
    }
}
