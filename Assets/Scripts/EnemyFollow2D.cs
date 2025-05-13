using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] patrolPoints; // Asigna 4 puntos en el inspector

    private int currentPointIndex = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (patrolPoints.Length == 0)
        {
            Debug.LogError("¡No se asignaron puntos de patrulla!");
        }
    }

    void Update()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPointIndex];
        Vector2 direction = (targetPoint.position - transform.position).normalized;
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);

        // Voltear sprite si se mueve horizontalmente
        if (direction.x != 0)
            GetComponent<SpriteRenderer>().flipX = direction.x < 0;

        // Verifica si llegó al punto
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }
}
