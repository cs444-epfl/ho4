using UnityEngine;

public class ActiveManager : MonoBehaviour
{
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void SetInactive(bool inactive)
    {
        SetActive(!inactive);
    }
}
