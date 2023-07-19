using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterSettings rootObject;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform firePosition;
    private Vector2 _moveInput;
    private float _fireInput;
    private float _fireTime;

    private void Update()
    {
        if (!_fireInput.NearZero() && Time.time >= _fireTime)
        {
            Bullet.SpawnBullet(firePosition.position, rootObject.BulletTemplate.gameObject);
        }
    }
    
    private void FixedUpdate()
    {
        Vector2 diff = _moveInput * (rootObject.Speed * Time.fixedDeltaTime);
        rigidBody.MovePosition(rigidBody.position + diff);
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void OnFire(InputValue value)
    {
        _fireInput = value.Get<float>();
    }
}