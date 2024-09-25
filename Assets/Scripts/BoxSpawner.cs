using System.Collections;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject boxPrefab;
    [SerializeField] GameObject boxContainer;
    [SerializeField] GameManager gameManager;
    [SerializeField] SkyBackgroundControl skyBackgroundControl;
    [SerializeField] ClawMovement clawMovement;
    [SerializeField] Animator clawAnimator;
  
    [Header("Properties")]
    [SerializeField] float delaySpawnTime = 2f;
    [SerializeField] float spawnerPadding;
    GameObject currentSpawnBox;

    [Header("Position")]
    Vector3 clawPos;
    [SerializeField] float clawGap = 2.3f;

    [Header("Flags")]
    bool isFirstTimeSpawn = true;

    public GameObject GetCurrentSpawnBox()
    {
        return currentSpawnBox;
    }

    public float GetSpawnPadding()
    {
        return spawnerPadding;
    }

    void Start()
    {
        StartCoroutine(spawnBox());
        isFirstTimeSpawn = false;
    }

    public IEnumerator spawnBox()
    {
        if(gameManager.GetIsGameOver())
        {
            yield break;
        }
        if(!isFirstTimeSpawn)
        {
            transform.position = new Vector3(0, currentSpawnBox.transform.position.y + spawnerPadding, 0);
            yield return new WaitForSeconds(delaySpawnTime);
            skyBackgroundControl.ScrollBackground();
        }
        clawPos = new Vector3(clawMovement.transform.position.x, clawMovement.transform.position.y - clawGap, 0); 
        currentSpawnBox = Instantiate(boxPrefab, clawPos, Quaternion.identity, boxContainer.transform);
        clawAnimator.SetBool("isGrabbing", true);
    }
}
