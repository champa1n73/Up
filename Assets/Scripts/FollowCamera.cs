using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] BoxSpawner boxSpawner;
    [SerializeField] GameManager gameManager;

    [Header("Speed")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float dropDownSpeed = 10f;
    
    [Header("Postions")]
    Vector3 defaultPosition;
    Vector3 newPosition;
    float boxYPos;

    [Header("Gaps")]
    float gapFromSpawner;

    public Vector3 GetNewPosition()
    {
        return newPosition;
    }
    
    void Start()
    {
        gapFromSpawner = boxSpawner.GetSpawnPadding();
        defaultPosition = new Vector3(0, 0, -10);
    }

    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if(gameManager.GetIsGameOver())
        {
            transform.position = Vector3.MoveTowards(transform.position, defaultPosition, dropDownSpeed * Time.deltaTime);
            return;
        }
        
        boxYPos = boxSpawner.transform.position.y; // Tracking Spawner's position
        if(transform.position.y != boxYPos - gapFromSpawner)
        {
            newPosition = new Vector3(0, boxYPos - gapFromSpawner, -10);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
        }
    }
}
