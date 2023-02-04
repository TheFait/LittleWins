using UnityEngine;

public class SpinOnAxis : MonoBehaviour
{
    public Vector3 axis = Vector3.up;
    public float speed = 10f;

    private void Update()
    {
        transform.RotateAround(transform.position, axis, speed * Time.deltaTime);
    }
}
