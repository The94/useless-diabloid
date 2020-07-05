using System.Collections.Generic;
using UnityEngine;

public class KeybindManager
{
    public enum KeyName
    {
        action_0,
        action_1,
        camera_left,
        camera_right,
        camera_zoom_in,
        camera_zoom_out
    }
    private static Dictionary<KeyName, KeyCode> _keys = new Dictionary<KeyName, KeyCode>
    {
        [KeyName.action_0]        = KeyCode.Mouse0,
        [KeyName.action_1]        = KeyCode.Mouse1,
        [KeyName.camera_left]     = KeyCode.Q,
        [KeyName.camera_right]    = KeyCode.E,
        [KeyName.camera_zoom_in]  = KeyCode.Mouse3,
        [KeyName.camera_zoom_out] = KeyCode.Mouse4
    };

    public static KeyCode GetKeyByName(KeyName name)
    {
        return _keys[name];
    }
}

