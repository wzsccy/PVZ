using UnityEngine;
enum PlantState
{
    Disable,
    Enable
}
public class Plant : MonoBehaviour
{
    PlantState plantState = PlantState.Disable;
    public PlantType plantType = PlantType.SunFlower;
    public int HP = 100;
    private void Start()
    {
        TranstionToDisable();
    }
    private void Update()
    {
        switch (plantState)
        {
            case PlantState.Disable:
                DisableUpdate();
                break;
            case PlantState.Enable:
                EnableUpdate();
                break;
            default:
                break;
        }
    }
    void DisableUpdate()
    {

    }
    protected virtual void EnableUpdate()
    {

    }
    void TranstionToDisable()
    {
        plantState = PlantState.Disable;
        GetComponent<Animator>().enabled = false;//植物在选中的情况下不会做动作
        GetComponent<Collider2D>().enabled = false;
    }
    public void TranstionToEnable()
    {
        plantState = PlantState.Enable;
        GetComponent<Animator>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
    public void TakeDamage(int damage)
    {
        this.HP -= damage;
        if (HP <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
