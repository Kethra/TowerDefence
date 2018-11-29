using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


[Serializable]
public struct TowerCost
{
    public towerType TowerType;
    public int Cost;
}

public class TowerManager : MonoBehaviour
{
    public static TowerManager Instance;

    public GameObject stoneTowerPrefab;
    public GameObject fireTowerPrefab;
    public GameObject iceTowerPrefab;

    public List<TowerCost> TowerCosts = new List<TowerCost>();

    void Awake()
    {
        Instance = this;
    }

    public void CreateNewTower(GameObject slotToFill, towerType towerType)
    {
        switch (towerType)
        {
            case towerType.Stone:
                Instantiate(stoneTowerPrefab, slotToFill.transform.position, Quaternion.identity);
                slotToFill.gameObject.SetActive(false);
                break;
            case towerType.Fire:
                Instantiate(fireTowerPrefab, slotToFill.transform.position, Quaternion.identity);
                slotToFill.gameObject.SetActive(false);
                break;
            case towerType.Ice:
                Instantiate(iceTowerPrefab, slotToFill.transform.position, Quaternion.identity);
                slotToFill.gameObject.SetActive(false);
                break;
        }
    }

    public int GetTowerPrice(towerType towerType)
    {
        return (from towerCost in TowerCosts where towerCost.TowerType == towerType select towerCost.Cost).FirstOrDefault();
    }
}
