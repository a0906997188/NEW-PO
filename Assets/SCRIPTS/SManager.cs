using UnityEngine;
using UnityEngine.SceneManagement;

public class SManager : MonoBehaviour
{
    public static int levelNO;
    public static int levelScore =0;
    private void Update()
    {
        if(levelNO == 4 && levelScore >= levelNO)
        {
            levelScore = 0;
            SceneManager.LoadScene(2);
        }
        else if (levelNO == 6 && levelScore >= levelNO)
        {
            levelScore = 0;
            SceneManager.LoadScene(3);
        }
        else if(levelNO == 8 && levelScore >= levelNO)
        {
            levelScore = 0;
            SceneManager.LoadScene(4);
        }
        

    }
}
