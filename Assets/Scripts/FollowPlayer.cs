using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Update()
    {
        Vector3 position =transform.position;
        position.x = player.position.x;
        transform.position = position;
    }
}
