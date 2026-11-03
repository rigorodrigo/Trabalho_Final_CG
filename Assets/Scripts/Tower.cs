using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Torre que detecta inimigos dentro de um raio e dispara projéteis no mais próximo
public class Tower : MonoBehaviour
{
    [SerializeField] private float range = 3.5f;
    [SerializeField] private float fireInterval = 0.5f; // segundos entre ataques
    [SerializeField] private Projectile projectilePrefab;

    public AudioClip pupupuSound;
    private AudioSource towerAudio;

    private float cooldown;

    void Start()
    {
        towerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown > 0f) return;

        Enemy target = FindClosestEnemy();
        if (target == null) return;

        // Mira onde o inimigo está agore, se ele for rápido o tiro pode passar atrás dele
        Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.Launch(target.transform.position);
        cooldown = fireInterval;
        towerAudio.PlayOneShot(pupupuSound, 1.0f);
    }

    private Enemy FindClosestEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range);
        Enemy closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy == null) continue;

            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closest = enemy;
                closestDistance = distance;
            }
        }
        return closest;
    }

    // Desenha o alcance na aba Scene quando a torre está selecionada (Bruxaria)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
