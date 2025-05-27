using UnityEngine;
using UnityEngine.SceneManagement;
public class Jump : MonoBehaviour
{
    public void EnterTheScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
