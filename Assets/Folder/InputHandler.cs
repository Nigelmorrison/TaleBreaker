using UnityEngine;

public class InputHandler : MonoBehaviour
{
    Movement player;

    private void Start()
    {
        player = GetComponent<Movement>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        player.TickMovement(new Vector3(h, 0, v));

        if (Input.GetButtonDown("Jump"))
        {
            player.Jump();
        }
    }
}
