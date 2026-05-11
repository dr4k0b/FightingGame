using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public enum Player { Player1, Player2 };
    public Player thisPlayer;

    [Header("Attack")]

    public float windUp;
    public float Hurt;
    public float cooldown;
    public bool attacking;

    [Header("Movement")]

    public float maxSpeed;
    public float acceleration;
    public float deacceleration;
    //    [HideInInspector]
    public bool canMove;

    [Header("Health")]
    public float maxHealth;
    [HideInInspector]
    public float health;
    public float knockback;
    public float knockbackDeacceleration;
    [HideInInspector]
    public float currentKnockback;

    [Header("Blocking")]
    public bool isBlocking;
    public float blockWindUp;
    public float blocking;
    public float blockCooldown;
    public float stunnedTime;
    public bool stunned;
}
