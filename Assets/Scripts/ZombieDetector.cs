using UnityEngine;

public class ZombieDetector : MonoBehaviour
{
    public PeaShooter peashooter; // �����㶹���ֵĿ��ƽű�
    public GameObject Dectector;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �����뷶Χ�Ķ����Ƿ��ǽ�ʬ
        if (other.CompareTag("Zombie"))
        {
            //peashooter.SetZombieInRange(true); // ֪ͨ�㶹���֣���ʬ�ѽ��뷶Χ
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ����뿪��Χ�Ķ����Ƿ��ǽ�ʬ
        if (other.CompareTag("Zombie"))
        {
            //peashooter.SetZombieInRange(false); // ֪ͨ�㶹���֣���ʬ���뿪��Χ
        }
    }
}
