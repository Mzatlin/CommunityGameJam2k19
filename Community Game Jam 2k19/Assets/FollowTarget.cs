using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    private float offset = 0.5f;
    [SerializeField]
    private float speed = 2f;
    Vector2 direction;

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = target.transform.position - transform.position;
        direction = direction.normalized;
        transform.position += new Vector3(direction.x*speed-offset ,0,0)*Time.fixedDeltaTime;
    }
}
