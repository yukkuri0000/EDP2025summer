using UnityEngine;

public class HitboxController : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (player != null)
            {
                player.OnHit();
            }

            Destroy(other.gameObject); // íeÇè¡Ç∑
        }
    }
}
