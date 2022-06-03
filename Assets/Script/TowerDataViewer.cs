using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerDataViewer : MonoBehaviour
{
    [SerializeField]
    private Image       imageTower;
    [SerializeField]
    private TextMeshProUGUI textDamage;
    [SerializeField]
    private TextMeshProUGUI textRate;
    [SerializeField]
    private TextMeshProUGUI textRange;
    [SerializeField]
    private TextMeshProUGUI textLevel;
    [SerializeField]
    private TextMeshProUGUI towerAttackRange;
    

    [SerializeField]
    private Button      buttonUpgrade;


    private SpriteRenderer spriteRenderer;
    private TowerWeapons currentTower;

    private GameManager GM;

    private void Awake()
    {
        OffPanel();
        

    }

    private void update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OffPanel();
        }
    }

    public void OnPanel()
    {
        
        currentTower = GetComponent<TowerWeapons>();
        
        gameObject.SetActive(true);
        UpdateTowerData();
    }

    public void OffPanel()
    {
        gameObject.SetActive(false);
    }

    private void UpdateTowerData()
    {
        
        imageTower.sprite = currentTower.TowerSprite;
    }

    public void OnClickEventTowerUpgrade()
    {
        Debug.Log("clicktest");
        bool isSuccess = currentTower.Upgrade();

        Debug.Log(isSuccess);
        if (isSuccess == true)
        {
            //UpdateTowerData();
            
        }
    }
    
}
