using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            Shoot();
            //Debug.Log("Shooting!");
            //new ShootAttack();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}


public class EAttack
{
    public virtual int v_damage => 5;
    public virtual int v_range => 1;
    public virtual void EnemyExecuteAttack(Transform enemyTransform)
    {
        Debug.Log("Enemy attacks with a normal attack");
    }
}

public class ShootAttack : EAttack
{
    public override int v_damage => 10;
    public override int v_range => 10;
    public override void EnemyExecuteAttack(Transform enemyTransform)
    {
        Debug.Log("Enemy attacks with a ranged attack");
    }


}
