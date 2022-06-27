using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadSceneZero()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadSceneOne()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadSceneTwo()
    {
        SceneManager.LoadScene(2);

    }
    public void LoadSceneThree()
    {
        SceneManager.LoadScene(3);
    }


}
