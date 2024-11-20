using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScenceController : MonoBehaviour
{
    public GameObject inputPanelGo;
    public TMP_InputField nameInputField;
    public TextMeshProUGUI nameText;

    private void Start()
    {
        UpdateNameUI();
    }
    public void OnChangeNameButtonClick()
    {
        string name = PlayerPrefs.GetString("Name", "Input Name");
        nameInputField.text = name;
        inputPanelGo.SetActive(true);
        AudioManager.Instance.PlayClip(Config.btn_click);
    }
    public void OnSubmmitButtonClick()
    {
        PlayerPrefs.SetString("Name",nameInputField.text);
        inputPanelGo.SetActive(false);
        UpdateNameUI();
        AudioManager.Instance.PlayClip(Config.btn_click);
    }
    void UpdateNameUI()
    {
        string name= PlayerPrefs.GetString("Name","-");
        nameText.text = name;
    }
    public void OnadventureButtonClick()
    {
        AudioManager.Instance.PlayClip(Config.btn_click);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
