using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(ChangeScene0());
    }

    IEnumerator ChangeScene0()
    {
       yield return new WaitForSeconds(4f);
       SceneManager.LoadScene(0);
     }
}
