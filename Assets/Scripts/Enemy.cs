using System;
using UnityEngine;

// Código base de um inimigo base
public class Enemy : MonoBehaviour
{
    // Eventos do inimiog
    public static event Action<Enemy> Died;
    public static event Action<Enemy> ReachedBase;

    [SerializeField] private float maxHealth = 10f; // Vida inicial também
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private int baseDamage = 1;

    public WaypointPath path; // Caminho que será seguido

    private Rigidbody2D body;
    private float health;
    private int targetIndex;
    private bool isRemoved;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Basicamente anda até chegar no próximo waypont do caminho, depois manda "avança" a target pro próximo waypont
    private void FixedUpdate()
    {
        if (path == null || targetIndex >= path.waypoints.Length) return;

        Vector2 target = path.waypoints[targetIndex].position;
        Vector2 newPosition = Vector2.MoveTowards(body.position, target, speed * Time.fixedDeltaTime);
        body.MovePosition(newPosition);

        if (newPosition == target) targetIndex++;
    }

    public void TakeDamage(float amount)
    {
        if (isRemoved) return;

        health -= amount;
        if (health <= 0f)
        {
            
            isRemoved = true;
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }

    // Encosta em algo (base)
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerBase playerBase = other.GetComponent<PlayerBase>();
        if (playerBase == null || isRemoved) return;

        // Da dano e desaparece, igual bloons 
        isRemoved = true;
        playerBase.TakeDamage(baseDamage);
        ReachedBase?.Invoke(this);
        Destroy(gameObject);
    }
}
