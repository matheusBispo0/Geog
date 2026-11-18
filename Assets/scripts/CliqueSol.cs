using System.Collections;
using UnityEngine;

public class CliqueSol : MonoBehaviour
{
    [Header("Animação")]
    public float tamanhoClique = 1.2f;
    public float velocidadeAnimacao = 8f;

    private Vector3 tamanhoOriginal;
    private Coroutine animacaoAtual;

    void Start()
    {
        tamanhoOriginal = transform.localScale;
    }

    void OnMouseDown()
    {
        if (animacaoAtual != null)
        {
            StopCoroutine(animacaoAtual);
        }

        animacaoAtual = StartCoroutine(AnimarClique());
    }

    IEnumerator AnimarClique()
    {
        Vector3 tamanhoGrande = tamanhoOriginal * tamanhoClique;

        // Cresce
        while (Vector3.Distance(transform.localScale, tamanhoGrande) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(
                transform.localScale,
                tamanhoGrande,
                Time.deltaTime * velocidadeAnimacao
            );

            yield return null;
        }

        transform.localScale = tamanhoGrande;

        // Volta ao tamanho original
        while (Vector3.Distance(transform.localScale, tamanhoOriginal) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(
                transform.localScale,
                tamanhoOriginal,
                Time.deltaTime * velocidadeAnimacao
            );

            yield return null;
        }

        transform.localScale = tamanhoOriginal;
    }
}