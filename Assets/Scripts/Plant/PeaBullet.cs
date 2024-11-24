using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    private float speed = 3;
    public GameObject PeaBulletHitPrefab;
    public int atkValue = 30;
    

    public void SetAtkValue(int atkValue)
    {
        this.atkValue = atkValue;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    private void Start()
    {
        Destroy(this.gameObject,2.4f);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
        {
            Destroy(this.gameObject);
            collision.GetComponent<Zombie>().TakeDamage(atkValue);
            GameObject go= GameObject.Instantiate(PeaBulletHitPrefab,transform.position,Quaternion.identity);
            Destroy(go,1);
        }
    }
}
