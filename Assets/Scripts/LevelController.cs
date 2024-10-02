using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject virtualCam;
    [SerializeField] Transform respawnLocation;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            virtualCam.SetActive(true);
            RespawnController.respawnLocation = respawnLocation;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            virtualCam.SetActive(false);
        }
    }
}
