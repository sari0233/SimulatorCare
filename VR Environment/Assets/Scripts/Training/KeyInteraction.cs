using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyInteraction : MonoBehaviour
{
    public TMP_Text instructionText;
    private string m_Text = "Well done! You can now return to the main island by pressing the A button!";

    private bool holdingKey = false;

    private void Update()
    {
        if (holdingKey && OVRInput.GetDown(OVRInput.Button.One))
        {
            SceneManager.LoadScene("Hub");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            instructionText.text = m_Text;
            holdingKey = true;
        }
    }
}