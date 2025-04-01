using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class OneWayBoxColliderScript : MonoBehaviour
{
    [SerializeField] private Vector3 entryDirection = Vector3.up;
    [SerializeField] private bool localDirenction = false;
    [SerializeField, Range(1.0f, 2.0f)] private float triggerScale = 1.25f;
    private new BoxCollider collider = null;


    private BoxCollider collisionCheckTrigger = null;

    private void Awake()
    {
        collider = GetComponent<BoxCollider>();

        collisionCheckTrigger = gameObject.AddComponent<BoxCollider>();
        collisionCheckTrigger.size = collider.size * triggerScale;
        collisionCheckTrigger.center = collider.center;
        collisionCheckTrigger.isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Physics.ComputePenetration(
            collisionCheckTrigger, transform.position, transform.rotation,
            other, other.transform.position, other.transform.rotation,
            out Vector3 collisionDirection, out float penetrationDepth
            ))
        {
            float dot = Vector3.Dot(entryDirection, collisionDirection);
            // Opposite direction; passing is not allowed.
            if (dot < 0)
            {
                Physics.IgnoreCollision(collider,other, false);
            }
            else
            {
                Physics.IgnoreCollision(collider, other, true);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 direction;
        if (localDirenction)
        {
            direction = transform.TransformDirection(entryDirection.normalized);
        }
        else
        {
            direction = entryDirection;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, direction);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, -direction);
    }
}
