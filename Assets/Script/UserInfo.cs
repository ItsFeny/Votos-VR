using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInfoDisplayer : MonoBehaviour
{
    public TMP_Text nombreText;
    public TMP_Text cedulaText;
    public Usuario[] usuarios; 
    public Image imagenUsuario; 

    private void Start()
    {
        // Obtener el nombre y la c�dula verificada del PlayerPrefs
        string nombre = PlayerPrefs.GetString("NombreUsuario", "Nombre no encontrado");
        string cedula = PlayerPrefs.GetString("CedulaUsuario", "C�dula no encontrada");

        // Mostrar el nombre y la c�dula en los TextMeshPro
        nombreText.text = nombre;
        cedulaText.text = cedula;

        // Buscar el usuario correspondiente a la c�dula verificada
        Usuario usuarioVerificado = null;
        foreach (var usuario in usuarios)
        {
            if (usuario.cedula == cedula)
            {
                usuarioVerificado = usuario;
                break;
            }
        }

        if (usuarioVerificado != null)
        {
            // Mostrar la imagen del usuario verificado
            if (usuarioVerificado.imagen != null)
            {
                // Asignar la imagen al componente de imagen
                imagenUsuario.sprite = usuarioVerificado.imagen;
                imagenUsuario.preserveAspect = true; 
            }
            else
            {
                Debug.LogWarning("Imagen no encontrada para el usuario: " + nombre);
            }
        }
        else
        {
            Debug.LogWarning("Usuario no encontrado para la c�dula: " + cedula);
        }

        // Agregar mensaje de depuraci�n para verificar la ruta de la imagen
        Debug.Log("Ruta de la imagen: " + "ImagenesUsuarios/" + cedula);
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }
}
