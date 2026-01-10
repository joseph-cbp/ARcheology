using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler
{
    public static bool TryRayCastHit(out RaycastHit raycastHit)
    {
    // #if ENABLE_INPUT_SYSTEM
    // if(UnityEngine.InputSystem.Mouse.current.leftButton.wasPressedThisFrame)
    //     {
    //         return ReadRayCastByPosition(UnityEngine.InputSystem.Mouse.current.position.ReadValue(), out raycastHit);
    //     }
    // #endif

    if(Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            var position = Touchscreen.current.primaryTouch.position.ReadValue();
            Ray cameraPosition = Camera.main.ScreenPointToRay(position);
            if(Physics.Raycast(cameraPosition, out raycastHit))
            {
                return true;
            }
            raycastHit = default;
            return false;
        }

#if ENABLE_INPUT_SYSTEM
    if (UnityEngine.InputSystem.Mouse.current.leftButton.wasPressedThisFrame)
    {
        Ray ray = Camera.main.ScreenPointToRay(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out raycastHit))
        {
            return true;
        }
    }
#endif

    raycastHit = default;
    return false;
    }

       private static bool ReadRayCastByPosition(Vector3 pos, out RaycastHit raycastHit)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);

        if(Physics.Raycast(ray, out raycastHit))
        {
            return true;
        }

        raycastHit = default;
        return false;
    }
}
