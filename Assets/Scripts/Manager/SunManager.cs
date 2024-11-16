using TMPro;
using UnityEngine;

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
    private void Awake()//��֤��һʱ����Գ�ʼ��
    {
        instance = this;
    }
    //����Ϸ��ʼʱ��������ֵ
    private void Start()
    {
        UpdateSunPointText();
    }
    //��UI��ֵ��SunPoint
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
