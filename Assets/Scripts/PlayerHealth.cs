using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health;

public void ReduceHealth()
    {
        Health -=1;
        if(Health == 0)
        {
            print("Dead");
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }
    }
}
