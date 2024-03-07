using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 10; // You can adjust the damage amount as needed

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is an enemy
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        Debug.Log("Collision detected on enemy");
        if (enemy != null)
        {
            Debug.Log("Enemy detected");
            enemy.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}