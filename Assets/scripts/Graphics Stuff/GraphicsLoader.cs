using UnityEngine;

public class GraphicsLoader : MonoBehaviour
{
    public GraphicsScriptable graphicsSettings;
    public GameObject postProcessing;

    void Start()
    {
        if (PlayerPrefs.HasKey("SelectedGraphicsSetting"))
        {
            int selectedSettingIndex = PlayerPrefs.GetInt("SelectedGraphicsSetting");

            if (selectedSettingIndex == 0)
            {
                Debug.Log("High");
                QualitySettings.SetQualityLevel(0);
                RenderSettings.fog = true;
                postProcessing.SetActive(true);
            }
            else if (selectedSettingIndex == 1)
            {
                Debug.Log("Medium");
                QualitySettings.SetQualityLevel(1);
                RenderSettings.fog = false;
                postProcessing.SetActive(true);
            }
            else if (selectedSettingIndex == 2)
            {
                Debug.Log("Low");
                QualitySettings.SetQualityLevel(2);
                RenderSettings.fog = false;
                postProcessing.SetActive(false);
            }
        }
    }
}
