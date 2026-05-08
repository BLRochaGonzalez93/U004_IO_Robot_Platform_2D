using UnityEngine;

public class ButtonDoorControl : MonoBehaviour
{
    public Transform door;
    public Transform[] doorPoints;
    public Transform button;
    public Transform[] buttonPoints;
    public float speed;
    public Vector3 originalPos;

    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        speed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == true)
        {

            door.position = Vector2.MoveTowards(door.position, doorPoints[1].position, (speed * 2) * Time.deltaTime);
        }
        else
        {
            door.position = Vector2.MoveTowards(door.position, doorPoints[0].position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "GrabbedItem")
        {
            isOpen = true;

            // Calculamos la nueva posición del boton
            button.position = Vector2.MoveTowards(button.position, buttonPoints[1].position, (speed * 2) * Time.deltaTime);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "GrabbedItem")
        {
            isOpen = false;

            // Calculamos la nueva posición del boton
            button.position = Vector2.MoveTowards(button.position, buttonPoints[0].position, speed * Time.deltaTime);
        }
    }
}
