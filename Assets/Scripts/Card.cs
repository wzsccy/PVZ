//using System;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

enum CardState
{
    Disable,
    Cooling,
    WaitingSun,
    Ready
}
public enum PlantType
{
    SunFlower,
    PeaShooter
}
public class Card : MonoBehaviour
{
    //冷却 可以被点击 阳光不够不可用
    private CardState cardState = CardState.Disable;
    public PlantType plantType = PlantType.SunFlower;
    public GameObject cardLight;
    public GameObject cardGray;
    public Image cardMask;
    [SerializeField]
    private float cdTime = 2;//冷却时间
    private float cdTimer = 0;//计时器
    [SerializeField]
    private int needSunPoint = 50;


    private void Update()
    {
        switch (cardState)
        {
            case CardState.Cooling:
                CoolingUpdate();
                break;
            case CardState.WaitingSun:
                WaitingSunUpdate();
                break;
            case CardState.Ready:
                ReadyUpdate();
                break;
            default:
                break;
        }
    }

    private void CoolingUpdate()
    {
        cdTimer += Time.deltaTime;//增量时间保证时间每秒都会增加
        cardMask.fillAmount = (cdTime - cdTimer) / cdTime;//fillAmount显示剩余时间的比例
        if (cdTimer >= cdTime)
        {
            TransitionToWaitingSun();
        }
    }
    private void WaitingSunUpdate()
    {
        if (needSunPoint <= SunManager.instance.SunPoint)
            TransitionToReady();
    }
    private void ReadyUpdate()
    {
        if (needSunPoint > SunManager.instance.SunPoint)
            TransitionToWaitingSun();
    }
    void TransitionToWaitingSun()
    {
        cardState = CardState.WaitingSun;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(false);
    }
    void TransitionToReady()
    {
        cardState = CardState.Ready;
        cardLight.SetActive(true);
        cardGray.SetActive(false);
        cardMask.gameObject.SetActive(false);
    }
    void TransitionToCooling()
    {
        cardState = CardState.Cooling;
        cdTimer = 0;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(true);
    }
    public void OnClick()
    {
        AudioManager.Instance.PlayClip(Config.btn_click);
        if (cardState == CardState.Disable) return;
        if (needSunPoint > SunManager.instance.SunPoint) return;
        //消耗阳光值，并进行种植
        bool isSuccess = HandManager.Instance.AddPlant(plantType);
        if (isSuccess)
        {
            SunManager.instance.SubSun(needSunPoint);
            TransitionToCooling();
        }
    }
    public void DisableCard()
    {
        cardState = CardState.Disable;
    }
    public void EnableCard()
    {
        TransitionToCooling();
    }
}
