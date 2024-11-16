using TMPro;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    public static SunManager instance { get; private set; }//通过类访问，而不需要通过实例化访问
    
    [SerializeField]
    private int sunPoint;
    public int SunPoint
    {
        get { return sunPoint; }
    }
    public TextMeshProUGUI sunPointText;
    private void Awake()//保证第一时间可以初始化
    {
        instance = this;
    }
    //在游戏开始时更新阳光值
    private void Start()
    {
        UpdateSunPointText();
    }
    //将UI赋值给SunPoint
    private void UpdateSunPointText()
    {
        sunPointText.text = SunPoint.ToString();
    }
    public void SubSun(int point)
    {
        sunPoint-=point;
        UpdateSunPointText();
    }
}
