using UnityEngine;

public class CharacterSettings : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private BulletSettings bulletTemplate;

    public float Speed => speed;
    public BulletSettings BulletTemplate => bulletTemplate;
}
