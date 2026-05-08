using UnityEngine;

public class GrabbedItemControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlatformCollider")
        {
            if (transform.parent == null)
            {
                transform.SetParent(other.transform);
                transform.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlatformCollider")
        {
            transform.SetParent(null);

            transform.GetComponent<Rigidbody2D>().gravityScale = 5;
        }
    }
}
