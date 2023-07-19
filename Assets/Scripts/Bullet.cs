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
		rigidBody.gameObject.transform.position = position;
	}

	private static readonly Queue<BulletSettings> BulletQueue = new();
	
	public static void SpawnBullet(Vector2 position, GameObject template)
	{
		if (!BulletQueue.TryDequeue(out var bullet))
			bullet = Instantiate(template).GetComponent<BulletSettings>();

		bullet.gameObject.SetActive(true);
		bullet.BroadcastMessage("ResetObject", position);
	}

	private static void ReturnBullet(BulletSettings obj)
	{
		obj.gameObject.SetActive(false);
		BulletQueue.Enqueue(obj);
	}
}