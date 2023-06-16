using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class PortalInteraction : MonoBehaviour
{
    public string sceneToLoad;

    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(XRBaseInteractor interactor)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
