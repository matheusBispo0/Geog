using System.Collections;
using UnityEngine;

public class CliqueSol : MonoBehaviour
{
    [Header("Configuração do Clique")]
    public float tamanhoDoClique = 1.25f;
    public float velocidadeCrescer = 15f;
    public float velocidadeVoltar = 10f;

    private Vector3 tamanhoOriginal;
    private Coroutine animacao;

    void Start()
    {
        tamanhoOriginal = transform.localScale;
    }

    void OnMouseDown()
    {
        if (animacao != null)
        {
            StopCoroutine(animacao);
        }

        animacao = StartCoroutine(AnimacaoClique());
    }

    IEnumerator AnimacaoClique()
    {
        Vector3 tamanhoMaior = tamanhoOriginal * tamanhoDoClique;

        // Cresce
        float tempo = 0f;

        while (tempo < 1f)
        {
            tempo += Time.deltaTime * velocidadeCrescer;

            transform.localScale = Vector3.Lerp(
                tamanhoOriginal,
                tamanhoMaior,
                tempo
            );

            yield return null;
        }

        // Volta
        tempo = 0f;

        while (tempo < 1f)
        {
            tempo += Time.deltaTime * velocidadeVoltar;

            transform.localScale = Vector3.Lerp(
                tamanhoMaior,
                tamanhoOriginal,
                tempo
            );

            yield return null;
        }

        transform.localScale = tamanhoOriginal;
        animacao = null;
    }
}