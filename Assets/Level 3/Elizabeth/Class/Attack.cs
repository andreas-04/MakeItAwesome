using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Virtual
//Override - Comment out override, and it will play the base attack..?

//Base Attack Class
public class Attack
{
    // Defaults for Attacks
    public virtual int v_damage => 0; 
    public virtual int v_knockback => 1;
    public virtual string AnimationTrigger => "BaseTrigger";
    public virtual void ExecuteAttack(Transform playerTransform)
    {
        //Performed a basic attack)

        Debug.Log("Performed a basic attack!");
        Debug.Log("You did " + v_damage + "damage!");
    }
}

//Each attack is a subclass of Attack and will execute the attack based on what is equipped
public class FistAttack : Attack
{
    public override int v_damage => 1; 
    public override int v_knockback => 3;
    public override string AnimationTrigger => "FistTrigger";
    public override void ExecuteAttack(Transform playerTransform)
    {
        Debug.Log("Performed a fist attack!");
        Debug.Log("You did " + v_damage + "damage!");
    }
}

public class SwordAttack : Attack
{
    public override int v_damage => 10; //Higher Damage for Sword
    public override int v_knockback => 3;
    public override string AnimationTrigger => "SwordTrigger";
    public override void ExecuteAttack(Transform playerTransform)
    {
        Debug.Log("Performed a sword attack with extra reach!");
        Debug.Log("You did " + v_damage + "damage!");
        
    }
}

public class StickAttack : Attack
{
    public override int v_damage => 3;// Lower damage but has knockback
    public override int v_knockback => 10;
    public override string AnimationTrigger => "StickTrigger";
    public override void ExecuteAttack(Transform playerTransform)
    {
        Debug.Log("Performed a stick attack with knockback!");

    }

    //Maybe Basket attack..?
}