using UnityEngine;

using System.Collections.Generic;
using UnityEngine.XR;
using System.Linq;

public enum STATE_SINALEIRO
{
    VERDE,
    AMARELO,
    VERMELHO,
}

public class Sinaleiro : MonoBehaviour
{

    [SerializeField] public STATE_SINALEIRO estado = STATE_SINALEIRO.VERDE;
    float timer = 4F;
    public List<STATE_SINALEIRO> estadoPilha = new List<STATE_SINALEIRO>();
    private SpriteRenderer spriteRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //sempre adiciono o verde primeiro na lista
        estadoPilha.Add(STATE_SINALEIRO.VERDE);
        estadoPilha.Add(estado);
        UpdateState();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            ChangeState();
            UpdateState();
            timer = 4f;
        }

    }


    void UpdateState()
    {


        estado = estadoPilha.Last();

        if (estadoPilha.Last() == STATE_SINALEIRO.VERDE)
        {


            spriteRenderer.color = Color.green;
        }
        if (estadoPilha.Last() == STATE_SINALEIRO.AMARELO)
        {

            spriteRenderer.color = Color.yellow;

        }
        if (estadoPilha.Last() == STATE_SINALEIRO.VERMELHO)
        {

            spriteRenderer.color = Color.red;
        }

    }


    public void ChangeState()
    {

        if (estadoPilha.Last() == STATE_SINALEIRO.VERDE)
        {

            estado = STATE_SINALEIRO.AMARELO;
            estadoPilha.Add(STATE_SINALEIRO.AMARELO);




        }
        else if (estadoPilha.Last() == STATE_SINALEIRO.VERMELHO)
        {

            estado = STATE_SINALEIRO.VERDE;
            estadoPilha.Remove(STATE_SINALEIRO.VERMELHO);


        }
        else if (estadoPilha.Last() == STATE_SINALEIRO.AMARELO)
        {

            estado = STATE_SINALEIRO.VERMELHO;
            estadoPilha.Remove(STATE_SINALEIRO.AMARELO);
            estadoPilha.Add(STATE_SINALEIRO.VERMELHO);


        }

    }

}
