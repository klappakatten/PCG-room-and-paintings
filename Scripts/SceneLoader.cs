using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
   

    public void LoadScene(int sceneToLoadIndex)
    {
        SceneManager.LoadScene(sceneToLoadIndex);
        Debug.Log("Loading Scene" + sceneToLoadIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Qutting");
    }


}
