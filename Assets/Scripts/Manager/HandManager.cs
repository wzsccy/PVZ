using System;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance { get; private set; }
    public List<Plant> plantPrefabsList;
    private Plant currentPlant;
    [SerializeField]
    private List<Plant> plants=new List<Plant>();
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        FollowCuesor();
    }
    public bool AddPlant(PlantType plantType)
    {
        if (currentPlant != null) return false;
        Plant plantPrefab = GetPlantPrefabs(plantType);
        if (plantPrefab == null)
        {
            print("Ҫ��ֲ��ֲ�ﲻ����"); return false;
        }
        currentPlant = GameObject.Instantiate(plantPrefab);
        plants.Add(currentPlant.GetComponent<Plant>());
        return true;
    }
    private Plant GetPlantPrefabs(PlantType plantType)
    {
        foreach (Plant plant in plantPrefabsList)
        {
            if (plant.plantType == plantType)
                return plant;
        }
        return null;
    }
    void FollowCuesor()
    {
        if (currentPlant == null) return;
        Vector3 mouseWorldPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);//����Ļ����ת������������
        mouseWorldPostion.z = 0;
        currentPlant.transform.position = mouseWorldPostion;//������λ�ø�ֲ���λ��
    }
    public void OnCellClick(Cell cell)
    {
        if (currentPlant == null) return;
        bool isSucess = cell.AddPlant(currentPlant);
        if (isSucess)
        {
            currentPlant = null;
            AudioManager.Instance.PlayClip(Config.plant);
        }
    }
    public void TrantionToPause()
    {

        foreach (Plant plant in plants)
        {
            if (GameManager.instance.IsGameEnd == true)
            {
                plant.TranstionToDisable();
            }
        }

    }
}
