using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSettings rootObject;
	[SerializeField] private Rigidbody2D rigidBody;

	private float _fireTime;

	private void FixedUpdate()
	{
		rigidBody.velocity = Vector2.up * rootObject.Speed;
		if(Time.time - _fireTime >= rootObject.TimeToRun)
			ReturnBullet(rootObject);
	}

	private void ResetObject(Vector2 position)
	{
		_fireTime = Time.time;
		rigidBody.position = position;
	}

	private static readonly Queue<BulletSettings> _bulletQueue = new();
	
	public static BulletSettings SpawnBullet(Vector2 position, GameObject template)
	{
		if (!_bulletQueue.TryDequeue(out var bullet))
		{
			bullet = Instantiate(template).GetComponent<BulletSettings>();
		}

		bullet.gameObject.SetActive(true);
		bullet.BroadcastMessage("ResetObject", position);
		return bullet;
	}

	private static void ReturnBullet(BulletSettings obj)
	{
		obj.gameObject.SetActive(false);
		_bulletQueue.Enqueue(obj);
	}
}