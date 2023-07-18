using UnityEngine;

public class BulletSettings : MonoBehaviour
{
    [SerializeField] private float speed;
	[SerializeField] private float timeToRun;
	
	public float Speed => speed;
	public float TimeToRun => timeToRun;
}