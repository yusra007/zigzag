
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{

    public static bool isRestart = false;

    public void restartGame()//restart paneldeki yeniden oyna butonuna týklanýnca çalýþacak
    {
        isRestart = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }


    public void quitGame()
    {
        Application.Quit();
    }
}
