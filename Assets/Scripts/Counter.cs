using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _timeBetweenIncrease = 0.5f;

    private bool _isCounting = false;
    private Coroutine _countCoroutine;

    public int Number { get; private set; }

    public UnityAction<int> NumberChanged;

    private void Start()
    {
        NumberChanged?.Invoke(Number);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounting();
        }
    }

    private IEnumerator AddNumber()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenIncrease);

            Number++;
            NumberChanged?.Invoke(Number);
        }
    }

    private void ToggleCounting()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
            _countCoroutine = StartCoroutine(AddNumber());
        else
            StopCoroutine(_countCoroutine);
    }
}
