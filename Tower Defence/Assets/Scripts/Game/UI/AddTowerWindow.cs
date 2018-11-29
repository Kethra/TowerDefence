using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AddTowerWindow : MonoBehaviour {

    public GameObject towerSlotToAddTowerTo;

    public void AddTower(string towerTypeAsString)
    {
        towerType type = (towerType)Enum.Parse(typeof(towerType), towerTypeAsString, true);

        if (TowerManager.Instance.GetTowerPrice(type) <= GameManager.Instance.gold)
        {
            GameManager.Instance.gold -= TowerManager.Instance.GetTowerPrice(type);

            TowerManager.Instance.CreateNewTower(towerSlotToAddTowerTo, type);

            gameObject.SetActive(false);
        }
    }
}
