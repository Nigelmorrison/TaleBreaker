using UnityEngine;

public class InputHandler : MonoBehaviour
{
    Movement player;
    PlayerAttack attack;

    Vector3 attackPoint;


    private void Start()
    {
        player = GetComponent<Movement>();
        attack = GetComponent<PlayerAttack>();
        attackPoint = new Vector3(0.18f, 0.0f, 0);
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        player.TickMovement(new Vector3(h, 0, v));
        if (h > 0)
        {
            player.Flip(false);
            attackPoint.x = 0.18f;
        }
        else if (h < 0)
        {
            player.Flip(true);
            attackPoint.x = -0.18f;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            attack.LightAttack(attackPoint);            
        }
        if (Input.GetButtonDown("Fire2"))
        {
            attack.HeavyAttack(attackPoint);            
        }

        if (Input.GetButtonDown("Jump"))
        {
            player.Jump();
        }
    }
}
