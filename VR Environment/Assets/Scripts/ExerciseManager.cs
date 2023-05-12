using UnityEngine;
using UnityEngine.UI;

public class ExerciseManager : MonoBehaviour
{
    public GameObject[] exerciseCanvases;
    public Button[] exerciseButtons;

    private void Start()
    {
        // Attach OnClick event to each exercise button
        for (int i = 0; i < exerciseButtons.Length; i++)
        {
            int index = i; // Store the value of i in a local variable to avoid a closure problem
            exerciseButtons[i].onClick.AddListener(() => OnExerciseSelected(index));
        }
    }

    private void OnExerciseSelected(int index)
    {
        // Hide the current canvas and show the selected exercise canvas
        foreach (GameObject canvas in exerciseCanvases)
        {
            canvas.SetActive(false);
        }
        exerciseCanvases[index].SetActive(true);
    }
}
