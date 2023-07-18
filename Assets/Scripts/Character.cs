using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    private CharacterSettings _rootObject;
    private Vector2 _moveInput;

    private void Update()
    {
        Vector2 diff = _moveInput * _rootObject.Speed;
        transform.position = (Vector3)diff;
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}