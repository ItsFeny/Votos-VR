// CedulaVerifier.cs
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Usuario
{
    public string cedula;
    public string nombre;
    public string fechaNacimiento;
    public string fechaexpiracion;
    public string lugarNacimiento;
    public string sexo;
    public string sangre;
    public string estadocivil;
    public string ocupacion;
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
                PlayerPrefs.SetString("NacimientoUsuario", usuario.fechaNacimiento);
                PlayerPrefs.SetString("FechaUsuario", usuario.fechaexpiracion);
                PlayerPrefs.SetString("LugarUsuario", usuario.lugarNacimiento);
                PlayerPrefs.SetString("SexoUsuario", usuario.sexo);
                PlayerPrefs.SetString("SangreUsuario", usuario.sangre);
                PlayerPrefs.SetString("EstadoUsuario", usuario.estadocivil);
                PlayerPrefs.SetString("OcupacionUsuario", usuario.ocupacion);
                SceneManager.LoadScene(1);
                return;
            }
        }
        Debug.Log("Cédula no válida");
    }
}
