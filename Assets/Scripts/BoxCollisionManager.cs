using Unity.Mathematics;
using UnityEngine;

public class BoxCollisionManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] SmokeEffectController smokeAnimator;
    [SerializeField] StarEffectController starAnimator;
    CameraShake cameraShake;
    BoxSpawner myBoxSpawner;
    ScoreManager scoreManager;
    GameManager gameManager;
    AudioManager audioManager;

    [Header("Components")]
    Rigidbody2D myRigidBody;
    BoxCollider2D thisBoxCollider;

    [Header("Flags")]
    bool collisionDetected;
    bool heightChecked = false;
    bool isPerfectHit;

    [Header("Size")]
    float halfSize_x;
    float halfSize_y;
    public static float towerHeight;
    [SerializeField] float perfectPadding = .05f;


    void Awake()
    {
        halfSize_x = GetComponent<Renderer>().bounds.extents.x;
        halfSize_y = GetComponent<Renderer>().bounds.extents.y;

        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    void Start()
    {
        myBoxSpawner = FindObjectOfType<BoxSpawner>();

        scoreManager = FindObjectOfType<ScoreManager>();

        gameManager = FindObjectOfType<GameManager>();

        myRigidBody = GetComponent<Rigidbody2D>();

        audioManager = FindObjectOfType<AudioManager>();

        thisBoxCollider = GetComponent<BoxCollider2D>();

        collisionDetected = false;
    }

    void Update()
    {
        LowerThanTower();
    }

    void LateUpdate()
    {
        MakeBoxFall();
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(collisionDetected || !ContactFromBelow(other))
        {
            return;
        }

        TouchingPlatform(other);
        
        if(!other.gameObject.tag.Equals("Box"))
        {
            return;
        }
        collisionDetected = true;

        cameraShake.Play();

        StayHalfOnThis(other);
        towerHeight = transform.position.y + halfSize_y;

        StartCoroutine(myBoxSpawner.spawnBox()); 
    }

    bool ContactFromBelow(Collision2D other)
    {
        if(other.contactCount <= 0) // is Contacting?
        {
            return false;
        }
        heightChecked = true;
        ContactPoint2D contact = other.GetContact(0);
        return Vector2.Dot(contact.normal, Vector2.up) > 0.5;
    }

    void MakeBoxFall()
    {
        if(gameManager.GetIsGameOver())
        {
            myRigidBody.bodyType = RigidbodyType2D.Dynamic;
            myRigidBody.freezeRotation = false;
            myRigidBody.gravityScale = 3;
        }
    }

    void LowerThanTower()
    {
        if(heightChecked)
        {
            return;
        }
        if(Mathf.Abs(transform.position.y) > towerHeight)
        {
            return;
        }
        gameManager.GameOver();
    }

    void TouchingPlatform(Collision2D other)
    {
        if(other.gameObject.tag.Equals("Platform"))
        {
            gameManager.GameOver();
        }
    }

    void StayHalfOnThis(Collision2D other)
    {
        BoxCollider2D otherBoxCollider = other.collider as BoxCollider2D;
        if (otherBoxCollider != null)
        {
            Bounds boundsThisBox = thisBoxCollider.bounds;
            Bounds boundsOtherBox = otherBoxCollider.bounds;

            float minX = Mathf.Max(boundsThisBox.min.x, boundsOtherBox.min.x);
            float maxX = Mathf.Min(boundsThisBox.max.x, boundsOtherBox.max.x);
            float overlapX = maxX - minX;

            if (overlapX < halfSize_x)
            {
                isPerfectHit = false;
                scoreManager.AddScore(isPerfectHit);
                gameManager.GameOver();
                return;
            }

            if(overlapX >= halfSize_x * 2 - perfectPadding) // perfect
            {
                starAnimator.PlayStarEffect();
                audioManager.PlayPerfectDropDownClip();
                smokeAnimator.DestroyEffectGameObject();
                isPerfectHit = true;
            }
            else // normal
            {
                smokeAnimator.PlayEffect();
                audioManager.PlayNormalDropDownClip();
                starAnimator.DestroyEffectGameObject();
                isPerfectHit = false;
            }
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            scoreManager.AddScore(isPerfectHit);
        }
    }
    
}
