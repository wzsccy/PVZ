using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public PrepareUI prepareUI;
    public CardListUI cardListUI;
    public bool IsGameEnd = false;
    public FailUI failUI;
    public WinUI winUI;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GameStart();
    }
    void GameStart()
    {
        Vector3 currentPostion=Camera.main.transform.position;
        Camera.main.transform.DOPath(new Vector3[] { currentPostion, new Vector3(5,0,-10),currentPostion },3,PathType.Linear).OnComplete(OnCameraMoveComplete);
            
    }
    private void Update()
    {
        if (IsGameEnd == true)
            StartCoroutine(Renew());
    }
    IEnumerator Renew()
    {
        GameEndSuccess();
        GameEndFail();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void GameEndFail()
    {
        if (IsGameEnd == true) return;
        IsGameEnd = true;
        failUI.show();
        ZombieManager.instance.Pause();
        HandManager.Instance.TrantionToPause();
        cardListUI.DisableCardList();
        SunManager.instance.StopProduce();
        AudioManager.Instance.PlayClip(Config.lose_music);
       
    }
    public void GameEndSuccess()
    {
        if (IsGameEnd == true) return;
        IsGameEnd = true;
        winUI.Show();
        cardListUI.DisableCardList();
        HandManager.Instance.TrantionToPause();
        SunManager.instance.StopProduce();
        AudioManager.Instance.PlayClip(Config.win_music);
    }
    void OnCameraMoveComplete()
    {
        prepareUI.Show(OnPrepareUIOncomplete);
    }
    
    void OnPrepareUIOncomplete()
    {
        SunManager.instance.StartProduce();
        ZombieManager.instance.StartSpawn();
        cardListUI.ShowCardList();
        AudioManager.Instance.PlayBgm(Config.bgm1);
    }
    
}
