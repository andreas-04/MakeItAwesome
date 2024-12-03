using UnityEngine;

public class BossAttack
{
    public virtual string bossAttack => "temp";
    public virtual int damage => 10;
    //public string bossAttack => "temp";
    //public int damage => 10;



                           // Virtual method for a generic attack
    public virtual void Attack()
    //public void Attack()
    {
        Debug.Log(bossAttack + " attacks with damage: " + damage);
    }
}

public class FireAttack : BossAttack
{
    public override int damage => 15;
    public override string bossAttack => "fire";
    //public int damage => 15;
    //public string bossAttack => "fire";

    public override void Attack()
    //public void Attack()
    {
        Debug.Log(bossAttack + " attacks with damage: " + damage);
    }
}

public class IceAttack : BossAttack
{
    public override int damage => 12;
    public override string bossAttack => "ice";
    //public int damage => 12;
    //public string bossAttack => "ice";

    public override void Attack()
    //public void Attack()
    {
        Debug.Log(bossAttack + " attacks with damage: " + damage);
    }
}

