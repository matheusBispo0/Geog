using UnityEngine;

public class MovimentoSol : MonoBehaviour
{
    [Header("Configuração")]
    public float distancia = 0.15f;
    public float velocidade = 2f;

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        float movimento = Mathf.Sin(Time.time * velocidade) * distancia;

        transform.position = posicaoInicial + new Vector3(0f, movimento, 0f);
    }
}