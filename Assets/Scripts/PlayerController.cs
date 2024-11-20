using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    // Variable para almacenar una referencia al rigidbody
    public Rigidbody2D rb2d;
    // Referencia a la UI para mostrar la pantalla de GameOver
    public UIController ui;

    [Header("Jump Config")]
    // Fuerza con la que el personaje va a saltar
    public float jumpForce = 5f;

    // N�mero de monedas actuales del jugador
    private int _playerPoints;

    private void Start() {
        // Recogemos la referencia al rigidbody
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        PlayerMovement();
    }

    /// <summary>
    /// M�todo que hace que el personaje salte cuando apretamos espacio
    /// </summary>
    private void PlayerMovement() {
        // Si pulsamos la tecla espacio...
        if (Input.GetButtonDown("Jump")) {
            // Detenemos la velocidad del jugador en cualquir direcci�n.
            rb2d.velocity = Vector2.zero;
            // Le a�adimos una velocidad vertical para realizar el salto.
            rb2d.velocity = Vector3.up * jumpForce;

            // OTRA OPCI�N
            //rb2d.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // Si colisiono con una moneda
        if (collision.CompareTag("Coin")) {
            AddPoint();
            // Destruyo la moneda que he cogido
            Destroy(collision.gameObject);
        }else if(collision.CompareTag("PointTrigger")){
            AddPoint();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        // Si me choco con un obst�culo
        if (collision.gameObject.CompareTag("Obstacle")){
            // Muerte
            PlayerDeath();
        }
    }

    private void PlayerDeath() {
        // Activamos la pantalla de gameOver
        ui.ShowGameOverTab(_playerPoints);
    }

    private void AddPoint(){
        // Aumento el valor de las monedas que tiene el jugador
        _playerPoints++;
        // Actualizo la UI para mostrar la cantidad de monedas actual
        ui.UpdateScoreText(_playerPoints);
    }
}
