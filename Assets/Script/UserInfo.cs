using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInfoDisplayer : MonoBehaviour
{
    public TMP_Text nombreText;
    public TMP_Text cedulaText;
    public TMP_Text fechaNacimiento;
    public TMP_Text fechaexpiracion;
    public TMP_Text lugarNacimiento;
    public TMP_Text sexotext;
    public TMP_Text sangretext;
    public TMP_Text estadociviltext;
    public TMP_Text ocupaciontext;
    public Usuario[] usuarios; 
    public Image imagenUsuario; 

    private void Start()
    {
        // Obtener el nombre y la cédula verificada del PlayerPrefs
        string nombre = PlayerPrefs.GetString("NombreUsuario");
        string cedula = PlayerPrefs.GetString("CedulaUsuario");
        string nacimiento = PlayerPrefs.GetString("NacimientoUsuario");
        string fecha = PlayerPrefs.GetString("FechaUsuario");
        string lugar = PlayerPrefs.GetString("LugarUsuario");
        string sexo = PlayerPrefs.GetString("SexoUsuario");
        string sangre = PlayerPrefs.GetString("SangreUsuario");
        string estado = PlayerPrefs.GetString("EstadoUsuario");
        string ocupacion = PlayerPrefs.GetString("OcupacionUsuario");

        // Mostrar el nombre y la cédula en los TextMeshPro
        nombreText.text = nombre;
        cedulaText.text = cedula;
        fechaNacimiento.text = nacimiento;
        fechaexpiracion.text = fecha;
        lugarNacimiento.text = lugar;
        sexotext.text = sexo;
        sangretext.text = sangre;
        estadociviltext.text = estado;
        ocupaciontext.text = ocupacion;

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
