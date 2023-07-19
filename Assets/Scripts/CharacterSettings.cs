using UnityEngine;

public class CharacterSettings : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private BulletSettings bulletTemplate;
    [SerializeField] private float bulletTimer;

    public float Speed => speed;
    public BulletSettings BulletTemplate => bulletTemplate;
    public float BulletTimer => bulletTimer;
}
