using UnityEngine;
using TMPro;

public class GraphicsChanger : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public GraphicsScriptable graphicsSettings;

    public void SaveSelectedSetting()
    {
        int selectedSettingIndex = dropdown.value;
        graphicsSettings.selectedQualityIndex = selectedSettingIndex;
        PlayerPrefs.SetInt("SelectedGraphicsSetting", selectedSettingIndex);
        PlayerPrefs.Save();
    }
}
