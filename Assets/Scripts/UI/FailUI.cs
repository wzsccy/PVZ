using UnityEngine;

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
}
