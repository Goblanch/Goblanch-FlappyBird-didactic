using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    [Header("Obstacle Config")]
    public float movementSpeed = 5f;
    public float timeToDestroy = 7f;

    // Start is called before the first frame update
    void Start()
    {
        // Destruimos el obstáculo en el tiempo para destruir
        Destroy(this.gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculamos lo que se mueve en un frame
        Vector3 step = Vector3.left * movementSpeed * Time.deltaTime;
        // Aplicamos la diferencia al transform
        transform.position += step;
    }
}
