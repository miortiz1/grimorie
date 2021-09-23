using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using EZCameraShake;

public class bombScript : MonoBehaviour {

	public float fieldofImpact;

	public float force;

	public LayerMask LayerToHit;

	public GameObject ExplosionEffect; 

  float timeSinceSpawn = 0f;

  float lifetime = 4f;
	// Use this for initialitazion

	void Start () {
		explode();

	}


	// Update is called once per frame

	void Update () {
		timeSinceSpawn += Time.deltaTime;

		if (timeSinceSpawn >= lifetime)
		{
				Destroy(gameObject);
		}
	}

	void explode ()
	{
    Debug.Log("Llegaste a explode() ");
		Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, LayerToHit);

		foreach(Collider2D obj in objects)
		{
			Vector2 direction = obj.transform.position - transform.position;

			obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
		}

		// CameraShaker.Instance.ShakeOnce(4,4,0.1f,1f);


		GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
		Destroy(ExplosionEffectIns,4);
		Destroy(gameObject);
	}


	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;

		Gizmos.DrawWireSphere(transform.position, fieldofImpact);
	}
}