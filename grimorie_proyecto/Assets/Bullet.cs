using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    [Tooltip("Launch force speed")]
    float launchForce = 10f;
    float timeSinceSpawn = 0f;

    [SerializeField]
    [Tooltip("Time since this bullet is shot until it is automatically destoyed")]
    float lifetime = 4f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Add impulse on start
        rb.AddForce(transform.right * launchForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Llego la bala al monstruo");
        EnemyController soldier = col.gameObject.GetComponent<EnemyController>();
        if (soldier)
        {
            soldier.Fix();
        }
        Destroy(gameObject);
    }
}
