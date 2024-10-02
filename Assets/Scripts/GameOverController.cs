using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    void GameOver()
    {
        StartCoroutine(GoToMainMenu());
    }

    IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
