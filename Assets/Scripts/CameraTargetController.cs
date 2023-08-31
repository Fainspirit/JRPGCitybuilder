using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraTargetController : MonoBehaviour
{
    // MOVE
    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    public float distanceFromEdgeToMove;

    Coroutine inputMoveRoutine;
    InputAction moveAction;

    private void Awake()
    {
        moveAction = InputManager.Controls.Global.Move;
        moveAction.started += Input_MoveCursor;
        moveAction.canceled += Input_StopMoveCursor;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Input_MoveCursor(InputAction.CallbackContext c)
    {
        inputMoveRoutine = StartCoroutine(InputMoveRoutine());
    }

    void Input_StopMoveCursor(InputAction.CallbackContext c)
    {
        if (inputMoveRoutine != null)
        {
            StopCoroutine(inputMoveRoutine);
            inputMoveRoutine = null;
        }
    }

    IEnumerator InputMoveRoutine()
    {
        while (true)
        {
            MoveInDir2D(moveAction.ReadValue<Vector2>());
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckEdgeMove();
    }

    void CheckEdgeMove()
    {
        // Get the position of the cursor in world space
        //Vector3 cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        Vector2 mousePos = Mouse.current.position.ReadValue();

        // Check if it's close enough to the edge
        if (mousePos.x <= distanceFromEdgeToMove ||
            Screen.width - mousePos.x <= distanceFromEdgeToMove ||
            mousePos.y < distanceFromEdgeToMove ||
            Screen.height - mousePos.y <= distanceFromEdgeToMove)
        {
            Vector2 center = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            Vector2 dir = (mousePos - center).normalized;
            MoveInDir2D(dir);
            return;

        }
    }

    void MoveInDir2D(Vector3 dir)
    {
        transform.position = transform.position + new Vector3(dir.x, 0, dir.y) * Time.deltaTime * moveSpeed;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
