using UnityEngine;

public class Cell : MonoBehaviour
{
    public Plant currentPlant;
    private void OnMouseDown()
    {
        HandManager.Instance.OnCellClick(this);
    }
    public bool AddPlant(Plant plant)
    {
        if (currentPlant != null) return false;//当前位置已有植物
        currentPlant= plant;
        currentPlant.transform.position=transform.position;
        plant.TranstionToEnable();
        return true;

    }
}
