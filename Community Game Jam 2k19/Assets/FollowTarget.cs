using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        direction = target.transform.position - transform.position;
        direction = direction.normalized;
        transform.position += new Vector3(direction.x*2 ,0,0)*Time.fixedDeltaTime;
    }
}
