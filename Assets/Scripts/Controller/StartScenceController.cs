using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScenceController : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        //加载下一个场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
