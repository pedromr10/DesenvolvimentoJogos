using UnityEngine;

public class BossDesertoHeadScript : MonoBehaviour
{
    public Transform player;  
    private float followSpeed = 2f;  

    void Update()
    {
     
        Vector3 newPosition = transform.position;


        newPosition.x = Mathf.Lerp(transform.position.x, player.position.x, followSpeed * Time.deltaTime);

        transform.position = newPosition;
    }
}
