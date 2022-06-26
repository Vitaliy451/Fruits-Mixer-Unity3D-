using System.Collections;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private Animator menuPanelAnim;

 
    public void OpenMenuPanel()
    {
        menuPanel.SetActive(true);
        menuPanelAnim.Play("SlideIn");

    }
    public void CloseMenuPanel()
    {
        StartCoroutine(CloseSettings());
    }
    IEnumerator CloseSettings()
    {
        menuPanelAnim.Play("SlideOut");
        yield return new WaitForSeconds(1f);
        menuPanel.SetActive(false);
    }

}
