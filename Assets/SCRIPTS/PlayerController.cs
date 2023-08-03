using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Control Personaje")]
    [Header("Vida Personaje")]
    public int vidaTotal;
    public int vidaActual;
    public TMP_Text textoVidaPlayer;

    public Vector3 posicionInicial;

    [Header("Movimiento Personaje")]
    float horizontal;
    float vertical;
    public float fuerzaHorizontal;
    public float fuerzaVertical;
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaTotal;
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0f; // Desactivar gravedad
    }

    private void Update()
    {
        // Movimiento Horizontal del personaje
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            transform.position += Vector3.right * horizontal * fuerzaHorizontal * Time.deltaTime;
        }

        // Movimiento Vertical del personaje
        vertical = Input.GetAxisRaw("Vertical");
        if (vertical != 0)
        {
            transform.position += Vector3.up * vertical * fuerzaVertical * Time.deltaTime;
        }

        PlayerDead();
    }

    public void Vida(int vidaRecibe)
    {
        vidaActual += vidaRecibe;
        textoVidaPlayer.text = "Vida:" + vidaActual.ToString();
        Debug.Log("Cambio de vida: " + vidaRecibe);
    }

    public void PlayerDead()
    {
        if (vidaActual <= 0)
        {
            vidaActual = 100;
            transform.position = posicionInicial;
            textoVidaPlayer.text = "Vida:" + vidaActual.ToString();
        }
    }
}
