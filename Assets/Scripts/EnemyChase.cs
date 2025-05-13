using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    //public ParticleSystem explosionParticle;
    private Rigidbody2D enemyRb;
    public Transform player;
    private GameObject manager;

    private float life = 100;

    private float minimumImpactLimit = 3.0f;
    private float damageIntensifier = 3.0f;

    private bool isAlive = true;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        // player = GameObject.Find("Player");
        manager = GameObject.Find("BossEvil");

    }

    private void Update()
    {
        // Vector2 lookDirection = (transform.position - player.transform.position).normalized;//ojo error se debe solucionar cuando muera
        Debug.Log($"Enemy Pos: {transform.position}, Player Pos: {player.transform.position}");
        // enemyRb.AddForce((transform.position - player.transform.position).normalized * speed);
        // enemyRb.linearVelocity = (transform.position - player.transform.position) * speed;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        Debug.Log($"look direction {(transform.position - player.transform.position).normalized}, {speed}");
        // if (transform.position.y < -10 || !isAlive)
        // {
        //     // player.GetComponent<PlayerController>().addPointsForKill();
        //     Destroy(gameObject);

        //     // ParticleSystem explosionInstance = Instantiate(
        //     //     explosionParticle,
        //     //     transform.position,
        //     //     explosionParticle.transform.rotation
        //     // );
        //     // explosionInstance.transform.localScale *= 50f;
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* if (!collision.gameObject.CompareTag("Player")) return;

         Vector2 contactNormal = collision.GetContact(0).normal;
         Vector2 playerVelocity = player.GetComponent<PlayerController>().CalculateVelocity();

         float playerImpact = Vector2.Dot(playerVelocity, contactNormal);
         float enemyImpact = Vector2.Dot(enemyRb.linearVelocity, -contactNormal);

         float calculatedImpact = Mathf.Max(0, playerImpact) - Mathf.Max(0, enemyImpact);

         if (calculatedImpact > minimumImpactLimit)
         {
             life -= calculatedImpact * damageIntensifier;
             if (life <= 0)
             {
                 life = 0;
                 isAlive = false;
             }

             Debug.Log($"Enemy life updated, current: {life}, isAlive={isAlive}");
         }*/
    }
}
