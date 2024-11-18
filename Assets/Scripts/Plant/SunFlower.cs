using UnityEngine;

public class SunFlower : Plant
{
    public float produceDurtion = 5;//阳光生产间隔
    private float produceTimer = 0;
    private Animator anim;
    public GameObject sunPrefab;
    public float jumpMinDistance = 0.3f;
    public float jumpMaxDistance = 2f;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    protected override void EnableUpdate()
    {
        produceTimer += Time.deltaTime;
        if (produceTimer > produceDurtion)
        {
            produceTimer = 0;
            anim.SetTrigger("IsGlowing");
        }
    }
    public void ProduceSun()
    {
        GameObject go = GameObject.Instantiate(sunPrefab, transform.position, Quaternion.identity);
        float distance = Random.Range(jumpMinDistance, jumpMaxDistance);
        distance = Random.Range(0, 2) < 1 ? -distance : distance;
        Vector3 postion = transform.position;
        postion.x+= distance;
        go.GetComponent<Sun>().JumpTo(postion );
    }

}
