using UnityEditor;
using UnityEngine;

public class PeaShooter : Plant
{
    public float shootDurtion=2;//射击时间间隔
    private float shootTimer=0;
    public Transform ShootPointTransform;
    public PeaBullet peaBulletPrefab;

    public float bulletSpeed;
    public int atkValue = 20;

    //private bool isZombieInRange = false;

    protected override void EnableUpdate()
    {
        //if (isZombieInRange)
        //{
            shootTimer += Time.deltaTime;
            if (shootTimer > shootDurtion)
            {
                Shoot();
                shootTimer = 0;
            }
       // }
    }
    void Shoot()
    {
        PeaBullet pb= GameObject.Instantiate(peaBulletPrefab,ShootPointTransform.position,Quaternion.identity);
        pb.SetSpeed(bulletSpeed);
        pb.SetAtkValue(atkValue);
        AudioManager.Instance.PlayClip(Config.shoot);
    }
    //// 接收僵尸检测器的通知
    //public void SetZombieInRange(bool isInRange)
    //{
    //    isZombieInRange = isInRange;
    //}
}
