using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public int sceneNumber;
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
