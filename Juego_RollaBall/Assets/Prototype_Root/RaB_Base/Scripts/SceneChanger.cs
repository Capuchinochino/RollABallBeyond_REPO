using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Librer�a que permite usar m�todos de carga y descarga de escenas

public class SceneChanger : MonoBehaviour
{
    public void SceneLoader(int sceneToLoad) 
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void ExitGame() {
        Application.Quit(); //Cierra la aplicaci�n o juego.
    }


}
