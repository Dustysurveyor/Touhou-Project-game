using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterSettings rootObject;
    private Vector2 _moveInput;

    private void Update()
    {
        Vector2 diff = _moveInput * rootObject.Speed * Time.deltaTime;
        rootObject.transform.position = (Vector3)diff;
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}