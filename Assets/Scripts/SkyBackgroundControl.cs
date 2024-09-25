using UnityEngine;

public class SkyBackgroundControl : MonoBehaviour
{
    [Header("References")]
    Camera mainCamera;

    [Header("Position")]
    Vector3 newPos;
    
    [Header("Properties")]
    [SerializeField] Vector2 offset = new Vector2(0, 0.001f);
    [SerializeField] float maxOffset = 0.8f;

    [Header("Materials")]
    Material material;

    void Start()
    {
        mainCamera = Camera.main;
        material = GetComponent<SpriteRenderer>().material;

    }

    void Update()
    {
        MoveWithCamera();
    }

    void MoveWithCamera()
    {
        newPos = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 0);
        transform.position = newPos;
    }

    public void ScrollBackground()
    {
        if(offset.y <= maxOffset)
        {
            material.mainTextureOffset += offset;
        }
    }
}
