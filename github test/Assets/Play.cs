using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuReturn : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        { SceneManager.LoadScene(1); }
    }
}
