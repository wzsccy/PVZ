using UnityEngine;

public class ZombieDetector : MonoBehaviour
{
    public PeaShooter peashooter; // 引用豌豆射手的控制脚本
    public GameObject Dectector;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检测进入范围的对象是否是僵尸
        if (other.CompareTag("Zombie"))
        {
            //peashooter.SetZombieInRange(true); // 通知豌豆射手，僵尸已进入范围
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 检测离开范围的对象是否是僵尸
        if (other.CompareTag("Zombie"))
        {
            //peashooter.SetZombieInRange(false); // 通知豌豆射手，僵尸已离开范围
        }
    }
}
