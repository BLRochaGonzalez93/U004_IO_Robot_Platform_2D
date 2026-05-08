using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    private float cameraSpeed;

    public Transform[] limits;

    // Start is called before the first frame update
    void Start()
    {
        cameraSpeed = 4f;
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null || target.parent == null)
        {
            return;
        }
        Movement();
    }

    private void FixedUpdate()
    {
        if (target == null || target.parent != null)
        {
            return;
        }
        Movement();
    }

    void Movement()
    {
        Vector3 finalPos = (Vector2)target.position;
        finalPos.z = -10f;

        if (finalPos.x < limits[0].position.x)
        {
            finalPos.x = limits[0].position.x;
        }

        if (finalPos.x > limits[1].position.x)
        {
            finalPos.x = limits[1].position.x;
        }

        if (finalPos.y > limits[0].position.y)
        {
            finalPos.y = limits[0].position.y;
        }

        if (finalPos.y < limits[1].position.y)
        {
            finalPos.y = limits[1].position.y;
        }

        transform.position = Vector3.Lerp(transform.position, finalPos, cameraSpeed * Time.deltaTime);
    }
}
