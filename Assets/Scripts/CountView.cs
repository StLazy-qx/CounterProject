using UnityEngine;
using TMPro;

public class CountView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textNumber;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.NumberChanged += OnNumberView;
    }

    private void OnDisable()
    {
        _counter.NumberChanged -= OnNumberView;
    }

    private void OnNumberView(int value)
    {
        _textNumber.text = value.ToString();
    }
}
