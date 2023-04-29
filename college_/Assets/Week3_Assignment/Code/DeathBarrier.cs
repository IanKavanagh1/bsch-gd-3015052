using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Simple class to reload the game scene when the player falls off screen into a death barrier
/// </summary>
public class DeathBarrier : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Death Barrier Hit - Restart Game!");
            SceneManager.LoadScene("Week3_Scene", LoadSceneMode.Single);
        }
    }
}
