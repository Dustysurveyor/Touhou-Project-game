using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterSettings rootObject;
    [SerializeField] private Rigidbody2D rigidBody;
    private Vector2 _moveInput;

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 diff = _moveInput * rootObject.Speed * Time.fixedDeltaTime;
        rigidBody.MovePosition(rigidBody.position + diff);
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}