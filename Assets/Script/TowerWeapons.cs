using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WeaponState { SearchTarget = 0, AttackToTarget }

public class TowerWeapons : MonoBehaviour
{

    [SerializeField]
    private TowerTemplate towerTemplate;

    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform spawnPoint;
    //[SerializeField]
    //private float attackRate = 0.5f;
    //[SerializeField]
    //private float attackRange = 2.0f;
    //[SerializeField]
    //private int attackDamage = 1;
    private int         level = 0;
    private WeaponState weaponState = WeaponState.SearchTarget;
    private Transform attackTarget = null;
    private SpriteRenderer spriteRenderer;
    private EnemySpawner enemySpawner;

    public Sprite   TowerSprite => towerTemplate.weapon[level].sprite;
    public float    Damage      => towerTemplate.weapon[level].damage;
    public float    Rate        => towerTemplate.weapon[level].rate;
    public float    Range       => towerTemplate.weapon[level].range;
    public float    Speedslow   => towerTemplate.weapon[level].speedSlow;
    public float    Firedamage  => towerTemplate.weapon[level].fireDamage;

    public int      Level       => level + 1;

    public void Setup(EnemySpawner enemySpawner)
    {
        this.enemySpawner = enemySpawner;

        ChangeState(WeaponState.SearchTarget);

    }

    public void ChangeState(WeaponState newState)
    {
        StopCoroutine(weaponState.ToString());

        weaponState = newState;

        StartCoroutine(weaponState.ToString());
    }




    private IEnumerator SearchTarget()
    {
        while(true)
        {
            float closeDistSqr = Mathf.Infinity;

            for (int i = 0; i < enemySpawner.EnemyList.Count; ++ i)
            {
                float distance = Vector3.Distance(enemySpawner.EnemyList[i].transform.position, transform.position);

                if(distance <= towerTemplate.weapon[level].range && distance <= closeDistSqr)
                {
                    closeDistSqr = distance;
                    attackTarget = enemySpawner.EnemyList[i].transform;
                }
            }

            if (attackTarget != null)
            {
                ChangeState(WeaponState.AttackToTarget);
            }

            yield return null;
        }
    }

    private IEnumerator AttackToTarget()
    {
        while(true)
        {
            
            if (attackTarget == null)
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            float distance = Vector3.Distance(attackTarget.position, transform.position);
            
            //if (distance == attackRange)
            if (distance > towerTemplate.weapon[level].range)
            {
                attackTarget = null;
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            //yield return new WaitForSeconds(attackRate);
            yield return new WaitForSeconds(towerTemplate.weapon[level].rate);

            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        
        
        GameObject clone = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<Projectile>().Setup(attackTarget, towerTemplate.weapon[level].damage);
        
        
        
        
        
        
    }

    public bool Upgrade()
    {
        level ++;
        spriteRenderer.sprite = towerTemplate.weapon[level].sprite;
        Debug.Log("test");
        return true;
    }

}
