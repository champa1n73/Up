using UnityEngine;
using UnityEngine.EventSystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
public class BoxControl : MonoBehaviour
{
    [Header("References")]
    public static BoxControl instance;
    BoxMovement currentBox;
    GameObject soundSettingPanel;

    public void SetSoundSettingPanel(GameObject soundSettingPanel)
    {
        this.soundSettingPanel = soundSettingPanel;
    }

    public void SetCurrentBox(BoxMovement currentBox)
    {
        
        this.currentBox = currentBox;
    }

    void OnEnable() 
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
    }

    void Disable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
    }

    void Awake()
    {
        ManageSingleton();
    }

    void Update()
    {
        TouchHandler();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void TouchHandler()
    {
        if(EventSystem.current.IsPointerOverGameObject() || soundSettingPanel.activeSelf)
        {
            return;
        }

        foreach(EnhancedTouch.Touch touch in EnhancedTouch.Touch.activeTouches)
        {
            if(touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
            {
                currentBox.DropBox();
                currentBox.SetDropClicked(true);
            }
        }
    }
}