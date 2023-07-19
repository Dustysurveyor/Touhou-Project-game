using UnityEngine;

public class EnemySettings : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    public float MovementSpeed => movementSpeed;
}
