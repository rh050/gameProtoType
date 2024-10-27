
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Start()
    {
     if (player == null)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogError("Player object not found! Please ensure the player has the 'Player' tag.");
            }
            
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            //change all but not the z
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, -10);
        }
    }
  
}
