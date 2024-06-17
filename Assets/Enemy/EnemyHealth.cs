using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int MaxHitPoints = 5;
    [SerializeField] int CurrentHitPoints = 0;

    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }


    void OnEnable()
    {
        CurrentHitPoints = MaxHitPoints;
    }
   void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        CurrentHitPoints--;

        if (CurrentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            MaxHitPoints += difficultyRamp;
            enemy.RewardGold();
            //Destroy(gameObject);
        }
       
    }
}
