using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScenceController : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        //������һ������
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
