using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public Transform player;

    public bool isFlipped = false;


    void Start()
    {
        BossAttack fireAttack = new FireAttack();
        BossAttack iceAttack = new IceAttack();

        fireAttack.Attack(); // Outputs: "Flame Lord attacks with fire damage! Total Damage: 25"
        iceAttack.Attack();  // Outputs: "Frost King attacks with ice damage! Total Damage: 20"
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

}