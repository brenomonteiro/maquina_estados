using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;



public enum STATE_DIRECTION
{
    VERTICAL,
    HORIZONTAL
}

public enum STATE_DIRECTION_CAR
{
    PARADO,
    ANDANDO
}


public class Carro : MonoBehaviour
{

    [SerializeField] GameObject sinal;
    [SerializeField] STATE_DIRECTION direction;
    [SerializeField] STATE_DIRECTION_CAR estado;

    bool dentroDoTrigger = false;
    Sinaleiro sinaleiro;
    [SerializeField] int speed = 2;


    void Start()
    {
        sinaleiro = sinal.GetComponent<Sinaleiro>();
    }

    void Update()
    {
        VerificarSemaforo();
        MoverCarro();
    }

    void VerificarSemaforo()
    {
        if (!dentroDoTrigger)
        {
            estado = STATE_DIRECTION_CAR.ANDANDO;

        }
        else if (sinaleiro.estado == STATE_SINALEIRO.VERDE)
        {
            estado = STATE_DIRECTION_CAR.ANDANDO;

        }
        else
        {
            estado = STATE_DIRECTION_CAR.PARADO;

        }
    }

    void MoverCarro()
    {
        if (estado == STATE_DIRECTION_CAR.ANDANDO)
        {

            if (direction == STATE_DIRECTION.HORIZONTAL)
            {

                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

            }

        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        dentroDoTrigger = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        dentroDoTrigger = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sinaleiro"))
        {
            dentroDoTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sinaleiro"))
        {
            dentroDoTrigger = false;
            estado = STATE_DIRECTION_CAR.ANDANDO;
        }
    }

}
