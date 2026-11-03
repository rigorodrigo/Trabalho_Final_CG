using UnityEngine;

// Projétil disparado pela torre: vai em linha reta e causa dano aos inimigos que acerta (como o do Bloons)
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float damage = 2f;
    [SerializeField] private int pierce = 1;      
    [SerializeField] private float lifetime = 1f; 

    private Rigidbody2D body;
    private Vector2 direction;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // A torre chama ao atirar
    public void Launch(Vector2 targetPoint)
    {
        direction = (targetPoint - (Vector2)transform.position).normalized;
        transform.right = direction;
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy == null || pierce <= 0) return;

        enemy.TakeDamage(damage);
        pierce--;
        if (pierce <= 0) Destroy(gameObject); // Destroy só acontece no fim do frame pra garantir
    }
}
