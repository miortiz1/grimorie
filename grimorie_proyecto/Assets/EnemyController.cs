using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    [Tooltip("Speed at which this unit will move")]
    float speed = 5f;
    [SerializeField]
    [Tooltip("Duration before a change in direction during patrol")]
    float patrolDuration = 2f;
    [SerializeField]
    [Tooltip("True if this unit moves horizontally, false if it moves vertically")]
    bool bHorizontalMovement = true;
    [SerializeField]
    [Tooltip("Maximum health for the enemy")]
    public float maxHealth = 100f;
    public float currentHealth;
    // public HealthbarBehaviour Healthbar;


    // Changes the direction of movement (1 or -1)
    int orientation = 1;
    float hitDamage = 10f;
    bool bFixed = false;

    Vector2 movementDirection;
    float patrolElapsedTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        // Healthbar.SetHealth(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        patrolElapsedTime += Time.deltaTime;
        if (patrolElapsedTime >= patrolDuration)
        {
            orientation *= -1;
            patrolElapsedTime = 0;
        }
    }

    void FixedUpdate()
    {
        // Update location
        if (!bFixed)
        {
            Vector2 newPosition = transform.position;
        if (bHorizontalMovement)
        {
            newPosition.x += speed * orientation * Time.fixedDeltaTime;

        }
        else
        {
            newPosition.y += speed * orientation * Time.fixedDeltaTime;

        }

        // Move the rigidbody
        rb.MovePosition(newPosition);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        PlayerController player = col.gameObject.GetComponent<PlayerController>();
        if (player && !bFixed)
        {
            player.TakeDamage(hitDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth);

        Debug.Log("CurrentEnemyHealth: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died! :(");
        Destroy(gameObject);
        SceneManager.LoadScene("Winner");
    }
}
