using UnityEditor;
using UnityEngine;

public class PeaShooter : Plant
{
    public float shootDurtion=2;//Éä»÷Ê±¼ä¼ä¸ô
    private float shootTimer=0;
    public Transform ShootPointTransform;
    public PeaBullet peaBulletPrefab;

    public float bulletSpeed;
    public int atkValue = 20;
    protected override void EnableUpdate()
    {
        shootTimer+= Time.deltaTime;
        if (shootTimer > shootDurtion)
        {
            Shoot();
            shootTimer=0;
        }
    }
    void Shoot()
    {
        PeaBullet pb= GameObject.Instantiate(peaBulletPrefab,ShootPointTransform.position,Quaternion.identity);
        pb.SetSpeed(bulletSpeed);
        pb.SetAtkValue(atkValue);
    }
}
