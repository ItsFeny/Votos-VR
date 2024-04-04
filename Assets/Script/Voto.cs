using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Voto : MonoBehaviour
{
    public List<GameObject> buttons; 

    private bool votoConfirmado = false;

    void Start()
    {
        // Desactivar todos los objetos hijos de los botones TMP
        foreach (var button in buttons)
        {
            button.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void OnButtonPress(GameObject button)
    {
        // Verificar si el botón está en la lista y si el voto no ha sido confirmado
        if (buttons.Contains(button) && !votoConfirmado)
        {
            // Activar el objeto hijo del botón presionado
            button.transform.GetChild(0).gameObject.SetActive(true);

            Debug.Log("Voto");
            SceneManager.LoadScene(2);
            // Iniciar la rutina para confirmar el voto
            StartCoroutine(ConfirmarVoto());
        }
    }

    IEnumerator ConfirmarVoto()
    {
        votoConfirmado = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("ConfirmacionVoto");
    }
}
