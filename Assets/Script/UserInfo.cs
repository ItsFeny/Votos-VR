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
        // Obtener el nombre y la cédula verificada del PlayerPrefs
        string nombre = PlayerPrefs.GetString("NombreUsuario", "Nombre no encontrado");
        string cedula = PlayerPrefs.GetString("CedulaUsuario", "Cédula no encontrada");

        // Mostrar el nombre y la cédula en los TextMeshPro
        nombreText.text = nombre;
        cedulaText.text = cedula;

        // Buscar el usuario correspondiente a la cédula verificada
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
            Debug.LogWarning("Usuario no encontrado para la cédula: " + cedula);
        }

        // Agregar mensaje de depuración para verificar la ruta de la imagen
        Debug.Log("Ruta de la imagen: " + "ImagenesUsuarios/" + cedula);
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }
}
