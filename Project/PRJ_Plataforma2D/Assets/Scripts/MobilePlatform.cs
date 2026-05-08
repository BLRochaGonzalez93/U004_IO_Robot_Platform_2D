using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    // La velocidad de movimiento de la plataforma
    public float movementSpeed = 1f;

    // La distancia máxima que se puede mover la plataforma hacia arriba o abajo
    public float movementDistance = 2f;

    public float originalPosition;

    // La dirección en la que se está moviendo la plataforma (1 = arriba, -1 = abajo)
    public int movementDirection;

    private void Start()
    {
        originalPosition = transform.position.y;
        movementDirection = Random.Range(0, 2) == 0 ? -1 : 1;
    }

    void Update()
    {
        // Si la nueva posición de la plataforma se sale del intervalo de movimiento permitido, cambiamos la dirección de movimiento
        if (transform.position.y >= originalPosition + movementDistance || transform.position.y <= originalPosition - movementDistance)
        {
            movementDirection *= -1;
        }

        // Calculamos la nueva posición de la plataforma
        Vector3 newPosition = transform.position + new Vector3(0, movementDirection * movementSpeed * Time.deltaTime, 0);

        // Actualizamos la posición de la platafor
        transform.position = newPosition;
    }
}
