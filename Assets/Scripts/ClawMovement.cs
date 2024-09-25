using UnityEngine;

public class ClawMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameManager gameManager;

    [Header("Position")]
    float position_x;
    Vector2 BottomLeftBounds;
    Vector2 TopRightBounds;

    [Header("Properties")]
    [SerializeField] float moveSpeed = 10f;

    [Header("Size")]
    float clawHalfSize;

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    void Start()
    {
        clawHalfSize = GetComponentInChildren<Renderer>().bounds.extents.x;
        TopRightBounds = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        BottomLeftBounds = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        moveSpeed = gameManager.GetMinSpeed();
    }

    void Update()
    {
        MoveHorizontally();
    }


    void MoveHorizontally()
    {   
        if(gameManager.GetIsGameOver()) {return;}
        
        position_x = transform.position.x + clawHalfSize * Mathf.Sign(moveSpeed); // Real x position
        if( position_x >= TopRightBounds.x - 1.25f || position_x <= BottomLeftBounds.x + 1.25f)
        {
            moveSpeed = -moveSpeed;
        }   
        moveSpeed = Random.Range(gameManager.GetMinSpeed(), gameManager.GetMaxSpeed() + 1) * Mathf.Sign(moveSpeed);
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }
}
