
using UnityEngine;

using UnityEngine.InputSystem;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;



public class SwpeDetector : MonoBehaviour
{
    const float MinSwipeDp = 50f;     // how far
    const float MaxSwipeTime = 0.4f;  // how fast

    void CheckSwipe(Touch touch)
    {
        if (touch.phase != TouchPhase.Ended) return;

        Vector2 delta = touch.screenPosition - touch.startScreenPosition;
        float dpi = Screen.dpi > 0 ? Screen.dpi : 160f;
        float distDp = delta.magnitude / (dpi / 160f);
        float time = (float)(touch.time - touch.startTime);

        if (distDp < MinSwipeDp || time > MaxSwipeTime) return;

        //if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            //OnSwipe(delta.x > 0 ? Vector2.right : Vector2.left);
        //else
           //OnSwipe(delta.y > 0 ? Vector2.up : Vector2.down);
    }

}
