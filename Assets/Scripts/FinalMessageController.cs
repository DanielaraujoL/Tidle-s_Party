using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalMessageController : MonoBehaviour
{
    public TextMeshProUGUI mensagem1;
    public TextMeshProUGUI mensagem2;
    public GameObject creditosPanel;

    void Start()
    {
        mensagem1.gameObject.SetActive(false);
        mensagem2.gameObject.SetActive(false);
        creditosPanel.SetActive(false);

        StartCoroutine(SequenciaFinal());
    }

    IEnumerator SequenciaFinal()
    {
        yield return new WaitForSeconds(1f);
        mensagem1.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(mensagem1.gameObject);

        yield return new WaitForSeconds(1f);
        mensagem2.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(mensagem2.gameObject);

        yield return new WaitForSeconds(3f);

        // Ativar os créditos
        creditosPanel.SetActive(true);
    }
}


