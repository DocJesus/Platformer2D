using UnityEngine;

public class ennemyPatrol : MonoBehaviour
{
    public int damages;
    public float speed;
    public Transform[] wayPoints;
    public SpriteRenderer graphics;

    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        target = wayPoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // calcule la distance entre l'ennemy et le waypoint
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % wayPoints.Length;
            target = wayPoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.instance.TakeDamage(damages);
        }
    }
}
