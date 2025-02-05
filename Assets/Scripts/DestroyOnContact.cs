using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    [SerializeField, Tooltip("Delay to wait before destruction on collision enter")]
    private float delay = 0.5f;
    
    private void OnCollisionEnter(Collision _)
    {
        Destroy(gameObject, delay);
    }
}
