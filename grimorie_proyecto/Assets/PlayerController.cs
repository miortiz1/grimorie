using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject explotionPrefab;
    Vector2 movementDirection;
    Vector2 lookDirection;

    // Serializing private fields makes them appear in the editor
    [SerializeField]
    [Tooltip("Speed at which Player will move")]
    float speed = 5f;

    [SerializeField]
    [Tooltip("Maximum health for the player")]
    float maxHealth = 100f;
    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShootCondition();
        UpdateExplodeCondition();
    }

    void UpdateMovement()
    {
        // Get movement input
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
        movementDirection.Normalize();

        // Save look direction only when input is registered
        if (movementDirection.magnitude > 0f)
        {
            lookDirection = movementDirection;
        }

    }

    void FixedUpdate()
    {
        // Called every fixed amount of time
        // Make physics calculations here
        rb.MovePosition(rb.position + movementDirection * speed * Time.fixedDeltaTime);
    }

    void UpdateShootCondition()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (CanShoot())
            {
                Shoot();
            }
        }
    }

    bool CanShoot()
    {
        return true;
    }

    void Shoot()
    {
        float armLength = .5f;
        float armHeight = .75f;
        Vector2 spawnPosition2D = lookDirection * armLength;
        Vector3 spawnPosition = transform.position + new Vector3(spawnPosition2D.x, spawnPosition2D.y + armHeight, 0f);


        GameObject bulletInstance = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        // Set rotation
        bulletInstance.transform.right = lookDirection;
    }

    void UpdateExplodeCondition()
    {
        if (Input.GetButtonDown("Fire2")) // Con click derecho
        {
            Debug.Log("Clickeaste Fire2 ");
            if (CanExplode())
            {
                Explode();
            }
        }
    }

    bool CanExplode()
    {
        return true;
    }

    void Explode()
    {
        float armLength = .5f;
        float armHeight = .75f;
        Vector2 spawnPosition2D = lookDirection * armLength;
        Vector3 spawnPosition = transform.position + new Vector3(spawnPosition2D.x, spawnPosition2D.y + armHeight, 0f);


        GameObject explotionInstance = Instantiate(explotionPrefab, spawnPosition, Quaternion.identity);

        // Set rotation
        explotionInstance.transform.right = lookDirection;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth);

        Debug.Log("CurrentHealth: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died! :(");
        Destroy(gameObject);
    }
}
