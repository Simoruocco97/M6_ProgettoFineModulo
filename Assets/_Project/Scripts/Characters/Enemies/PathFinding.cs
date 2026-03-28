using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask obstacles;
    [SerializeField] private float raycastDistance = 2f;
    [SerializeField] private float raycastAngle = 30f;

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    public Vector2 GetPath(Vector2 dir)
    {
        if (!Physics2D.Raycast(rb.position, dir, raycastDistance, obstacles))
            return dir;

        Vector2 rightRaycast = Quaternion.Euler(0f, 0f, -raycastAngle) * dir;
        if (!Physics2D.Raycast(rb.position, rightRaycast, raycastDistance, obstacles))
            return rightRaycast;

        Vector2 leftRaycast = Quaternion.Euler(0f, 0f, raycastAngle) * dir;
        if (!Physics2D.Raycast(rb.position, leftRaycast, raycastDistance, obstacles))
            return leftRaycast;

        return dir;
    }
}