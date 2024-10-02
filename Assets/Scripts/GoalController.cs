using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    [SerializeField] Animator transition;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadMainMenu());
        }
    }

    IEnumerator LoadMainMenu()
    {
        transition.SetTrigger("NewTransition");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
