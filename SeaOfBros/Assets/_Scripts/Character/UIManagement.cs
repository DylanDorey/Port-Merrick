using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagement : Singleton<UIManagement>
{
    //the UI screen objects
    public GameObject baseUI;
    public GameObject fishingRodUI;
    public GameObject leverUI;
    public GameObject harpoonUI;
    public GameObject useHarpoonUI;


    private void Start()
    {
        EnableBaseUI();
        DisableFishingUI();
        DisableHarpoonUI();
        DisableLeverUI();
        DisableUseHarpoonUI();
    }

    /// <summary>
    /// enables the base UI
    /// </summary>
    public void EnableBaseUI()
    {
        EnableUI(baseUI);
    }

    /// <summary>
    /// disables the base UI
    /// </summary>
    public void DisableBaseUI()
    {
        DisableUI(baseUI);
    }

    /// <summary>
    /// enables the fishing screen
    /// </summary>
    public void EnableFishingUI()
    {
        EnableUI(fishingRodUI);
    }

    /// <summary>
    /// disables the fishing screen
    /// </summary>
    public void DisableFishingUI()
    {
        DisableUI(fishingRodUI);
    }

    /// <summary>
    /// enables the harpoon screen
    /// </summary>
    public void EnableHarpoonUI()
    {
        EnableUI(harpoonUI);
    }

    /// <summary>
    /// disables the harpoon screen
    /// </summary>
    public void DisableHarpoonUI()
    {
        DisableUI(harpoonUI);
    }

    /// <summary>
    /// enables the harpoon screen
    /// </summary>
    public void EnableUseHarpoonUI()
    {
        EnableUI(useHarpoonUI);
    }

    /// <summary>
    /// disables the harpoon screen
    /// </summary>
    public void DisableUseHarpoonUI()
    {
        DisableUI(useHarpoonUI);
    }

    /// <summary>
    /// enables the lever screen
    /// </summary>
    public void EnableLeverUI()
    {
        EnableUI(leverUI);
    }

    /// <summary>
    /// disables the lever screen
    /// </summary>
    public void DisableLeverUI()
    {
        DisableUI(leverUI);
    }

    /// <summary>
    /// enables the correct screen at runtime
    private void EnableUI(GameObject uiScreen)
    {
        uiScreen.SetActive(true);
    }

    /// <summary>
    /// disables the correct screen at runtime
    private void DisableUI(GameObject uiScreen)
    {
        uiScreen.SetActive(false);
    }
}
