using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [Header("Components")]
    Rigidbody2D myRigidBody;

    [Header("Properties")]
    [SerializeField] float customGravityScale = 10f;

    [Header("Positon")]
    [SerializeField] float clawGap = 2.3f;
    Vector2 clawPos;

    [Header("References")]
    [SerializeField] BoxCollisionManager boxCollisionManager;
    Animator clawAnimator;
    GameManager gameManager;
    ClawMovement clawMovement;
    
    [Header("Flags")]
    bool dropClicked;

    public void SetDropClicked(bool dropClicked)
    {
        this.dropClicked = dropClicked;
    }

    void Start()
    {
        BoxControl.instance.SetCurrentBox(this);
        clawAnimator = GameObject.Find("claw machine-Sheet_0").GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        myRigidBody = GetComponent<Rigidbody2D>();
        clawMovement = FindObjectOfType<ClawMovement>();
        myRigidBody.gravityScale = 0;
    }

    void Update() 
    {
        FollowClaw();
    }
    
    public void DropBox()
    {
        if(gameManager.GetIsGameOver()) {return;}
        
        clawAnimator.SetBool("isGrabbing", false);
        myRigidBody.gravityScale = customGravityScale;  
        
    }

    void FollowClaw()
    {
        if(gameManager.GetIsGameOver() || dropClicked) {return;}

        clawPos = new Vector3(clawMovement.transform.position.x, clawMovement.transform.position.y - clawGap); 
        transform.position = clawPos;
    }
}