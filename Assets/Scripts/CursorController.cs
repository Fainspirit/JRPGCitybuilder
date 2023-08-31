using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Follow cursor
public class CursorController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveSnapped();
    }


    void MoveSnapped()
    {
        Vector2Int pos = InputManager.CursorGridPos * 2;
        transform.position = new Vector3(pos.x, 0, pos.y);

    }
}
