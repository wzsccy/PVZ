using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailUI : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
       anim= GetComponent<Animator>();
    }
    private void Start()
    {
        Hide();
    }
    void Hide()
    {
        anim.enabled = false;
    }
    public void show()
    {
        anim.enabled=true;
    }
    //IEnumerable Renew()
    //{
    //    show();
    //    yield return new WaitForSeconds(3);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    //}
}
