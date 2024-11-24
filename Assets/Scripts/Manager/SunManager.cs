
using TMPro;
using UnityEngine;
//using UnityEngine.InputSystem.iOS;
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
    private Vector3 sunPointTextPosition;
    public float produceTime;
    private float produceTimer;
    public GameObject sunPrefab;
    private bool isStartProduce=false;
    private void Awake()//保证第一时间可以初始化
    {
        instance = this;
    }
    //在游戏开始时更新阳光值
    private void Start()
    {
        UpdateSunPointText();
        CalcSunPointTextPosition();
        StartProduce();
    }
    private void Update()
    {
        if(isStartProduce)
            ProduceSun();

    }
    public void StartProduce()
    {
        isStartProduce = true;
    }
    public void StopProduce()
    {
        isStartProduce = false;
    }
    void ProduceSun()
    {
        produceTimer += Time.deltaTime;
        if (produceTimer > produceTime)
        {
            produceTimer = 0;
            Vector3 postion = new Vector3(Random.Range(-4.3f,6),6,-1);
            GameObject go = GameObject.Instantiate(sunPrefab,postion,Quaternion.identity);//第三个参数为旋转保持不变
            go.transform.position = postion;
            postion.y = Random.Range(-3.8f,2.8f);
            go.GetComponent<Sun>().LinearTo(postion);
        }
    }

    //将UI赋值给SunPoint
    private void UpdateSunPointText()
    {
        sunPointText.text = SunPoint.ToString();
    }
    //种植植物，消耗阳光值
    public void SubSun(int point)
    {
        sunPoint -= point;
        UpdateSunPointText();
    }
    //收集阳光
    public void AddSun(int point)
    {
        sunPoint += point;
        UpdateSunPointText();
    }
    public Vector3 GetSunPointTextPosition()
    {
        return sunPointTextPosition;
    }
    private void CalcSunPointTextPosition()
    {
        Vector3 postion = Camera.main.ScreenToWorldPoint(sunPointText.transform.position);
        postion.z = 0;
        sunPointTextPosition = postion;
    }
}
