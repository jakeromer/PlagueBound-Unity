using UnityEngine;

public class Movement : MonoBehaviour, IMovement
{
    public Vector3 GetMovementDirection()
    {
        float horizontal = 0;
        float vertical = 0;

        if (Input.GetKey(KeyCode.D))
            horizontal = 1;
        else if (Input.GetKey(KeyCode.A))
            horizontal = -1;

        if (Input.GetKey(KeyCode.W))
            vertical = 1;
        else if (Input.GetKey(KeyCode.S))
            vertical = -1;

        return new Vector3(horizontal, vertical, 0).normalized;
    }
}
