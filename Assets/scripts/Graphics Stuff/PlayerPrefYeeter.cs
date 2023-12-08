using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefYeeter : MonoBehaviour
{
    void Update()
    {
        // Check if the Delete key is pressed
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            // Delete the PlayerPrefs key
            PlayerPrefs.DeleteKey("SelectedGraphicsSetting");
            PlayerPrefs.Save();
            Debug.Log("PlayerPrefs key deleted");
        }
    }
}
