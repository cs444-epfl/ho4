using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] private float timer = 5f;
    private void Start()
    {
        Destroy(gameObject, timer);
    }
}
