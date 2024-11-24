
using TMPro;
using UnityEngine;
//using UnityEngine.InputSystem.iOS;
public class SunManager : MonoBehaviour
{
    public static SunManager instance { get; private set; }//ͨ������ʣ�������Ҫͨ��ʵ��������

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
    private void Awake()//��֤��һʱ����Գ�ʼ��
    {
        instance = this;
    }
    //����Ϸ��ʼʱ��������ֵ
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
            GameObject go = GameObject.Instantiate(sunPrefab,postion,Quaternion.identity);//����������Ϊ��ת���ֲ���
            go.transform.position = postion;
            postion.y = Random.Range(-3.8f,2.8f);
            go.GetComponent<Sun>().LinearTo(postion);
        }
    }

    //��UI��ֵ��SunPoint
    private void UpdateSunPointText()
    {
        sunPointText.text = SunPoint.ToString();
    }
    //��ֲֲ���������ֵ
    public void SubSun(int point)
    {
        sunPoint -= point;
        UpdateSunPointText();
    }
    //�ռ�����
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
