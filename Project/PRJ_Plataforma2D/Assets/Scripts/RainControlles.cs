using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainControlles : MonoBehaviour
{
    // La prefab del meteorito
    public GameObject meteoritePrefab;

    // La fuerza del disparo del meteorito
    public float shootForce = 10f;

    // La posición de la parte superior de la pantalla en coordenadas de mundo
    public Vector2 meteoriteMakerPos = new Vector2(-3.95f, 1.6f);

    void Update()
    {
        // Si se hace clic, creamos un meteorito y lo disparamos
        if (Input.GetMouseButtonDown(0))
        {
            // Establecemos la posición inicial del meteorito haciendo la ilusion de que vienen desde el sol
            Vector3 startPosition = new Vector3(meteoriteMakerPos.x, meteoriteMakerPos.y, transform.position.z);

            // Creamos una instancia del meteorito
            GameObject meteorite = Instantiate(meteoritePrefab, startPosition, Quaternion.identity);
            Destroy(meteorite, 2);

            // Obtenemos el componente Rigidbody del meteorito
            Rigidbody2D rb = meteorite.GetComponent<Rigidbody2D>();

            // Calculamos una dirección aleatoria para el disparo
            float angle = Random.Range(0, 360);
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // Disparamos el meteorito con la fuerza especificada en la dirección aleatoria
            rb.AddForce(direction * shootForce, ForceMode2D.Impulse);
        }
    }
}
