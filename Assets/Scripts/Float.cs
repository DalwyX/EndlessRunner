using UnityEngine;

[CreateAssetMenu(fileName = "New Float variable", menuName = "Var/Float")]
public class Float : ScriptableObject
{
    [SerializeField] private float _value;
    public float Value => _value;

    public void SetValue(float value)
    {
        _value = value;
    }
}
