using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public enum Player { Player1, Player2 };
    public Player thisPlayer;

    [Header("Attack")]

    public float windUp;
    public float Hurt;
    public float cooldown;

    [Header("Movement")]

    public float maxSpeed;
    public float acceleration;
    public float deacceleration;
   // [HideInInspector]
    public bool canMove;

    [Header("Health")]
    public float maxHealth;
    [HideInInspector]
    public float health;
    public float knockback;
}
