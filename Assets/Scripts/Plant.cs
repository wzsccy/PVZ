using UnityEngine;


enum PlantState
{
    Disable,
    Enable
}
public class Plant : MonoBehaviour
{
    PlantState plantState=PlantState.Disable;
    public PlantType plantType = PlantType.SunFlower;
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
    void EnableUpdate()
    {

    }
}
