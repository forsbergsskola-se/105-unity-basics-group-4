using UnityEngine;
using UnityEngine.Events;

public class ToString : MonoBehaviour
{
    public UnityEvent<string> ValueChanged;

    public void ChangeValue(object value)
    {
        ValueChanged.Invoke(value.ToString());
    }
}
