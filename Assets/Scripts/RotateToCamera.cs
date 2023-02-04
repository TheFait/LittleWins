using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    public Transform cameraPosition;

    private void Update()
    {
        transform.LookAt(cameraPosition);
    }
}
