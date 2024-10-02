using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float startDelay;

    public void StartLoadingGame()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        transition.SetTrigger("NewTransition");
        yield return new WaitForSeconds(startDelay);
        SceneManager.LoadSceneAsync("Gameplay");
    }

}
