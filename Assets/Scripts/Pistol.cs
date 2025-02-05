using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

/// <summary>
/// Class <c>Pistol</c> shoots a bullet when the attached XRGrabInteractable is activated.
/// </summary>
public class Pistol : MonoBehaviour
{
    [Header("References")]
    [SerializeField, Tooltip("The attached XRGrabInteractable")] private XRGrabInteractable grabInteractable;
    [SerializeField, Tooltip("Where to spawn the bullet")] private Transform muzzle;
    [SerializeField, Tooltip("The bullet to spawn")] private GameObject bulletPrefab;
    
    [Header("Parameters")]
    [SerializeField, Tooltip("The force at which the bullet will be shot")] private float force = 10f;
    
    private void Awake()
    {
        // If a grab interactable has been assigned in the inspector, don't override it
        if (grabInteractable != null) return;
        
        // Get the attached XRGrabInteractable in parent
        grabInteractable = GetComponentInParent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.LogWarning($"{gameObject.name}: no XRGrabInteractable found in parent");
        }
    }

    private void OnEnable()
    {
        // Attach "Shoot" to the "activated" event
        grabInteractable?.activated.AddListener(Shoot);
    }
    
    private void OnDisable()
    {
        // Detach "Shoot" from the "activated" event
        grabInteractable?.activated.RemoveListener(Shoot);
    }

    /// <summary>
    /// Method <c>Shoot</c> shoots the bullet prefab at a certain force, all specified by this <c>Pistol</c>.
    /// </summary>
    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
        var rb = bullet.GetComponent<Rigidbody>();
        rb?.AddForce(muzzle.forward * force, ForceMode.Impulse);
    }
    
    private void Shoot(ActivateEventArgs _)
    {
        Shoot();
    }
}
