using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    // MOVE
    public Transform TargetTransform { get => _target; set => _target = value; }
    [SerializeField] Transform _target;

    public float lerpSpeed = 0.5f;

    [SerializeField, Range(0.0f, 1.0f), Tooltip("How closely to follow the cursor")]
    public float followCursorAmount;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Move();
    }

    void Move()
    {
        if (TargetTransform == null)
        {
            return;
        }

        // Get the position of the cursor in world space
        //Vector3 cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.y));
        cursorPos.y = _target.position.y;

        // Target can be midpoint of them and cursor
        //Vector3 xyDist = target.position - transform.position;
        Vector3 xyDist = ((1.0f - followCursorAmount) * _target.position + followCursorAmount * cursorPos) - transform.position;

        Vector3 toMove = new Vector3(xyDist.x, 0, xyDist.z) * Time.deltaTime * lerpSpeed;
        transform.position = transform.position + toMove;




    }

    public void SnapToTarget()
    {
        transform.position = _target.position + new Vector3(0, transform.position.y, 0);
    }

    public void SetTarget(Transform t)
    {
        TargetTransform = t;
        Debug.Log("Camera target changed to " + t.name);
    }
}
