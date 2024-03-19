// CedulaVerifier.cs
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Usuario
{
    public string cedula;
    public string nombre;
    public Sprite imagen;
}

public class CedulaVerifier : MonoBehaviour
{
    public TMP_InputField cedulaInputField;
    public Usuario[] usuarios;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            VerifyCedula();
        }
    }

    public void VerifyCedula()
    {
        string inputCedula = cedulaInputField.text.Trim();
        foreach (var usuario in usuarios)
        {
            if (usuario.cedula == inputCedula)
            {
                PlayerPrefs.SetString("NombreUsuario", usuario.nombre);
                PlayerPrefs.SetString("CedulaUsuario", usuario.cedula);
                SceneManager.LoadScene(1);
                return;
            }
        }
        Debug.Log("Cédula no válida");
    }
}
