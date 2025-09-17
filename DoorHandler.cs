using UnityEngine;
using TMPro;

[RequireComponent (typeof (Rigidbody))]
public class DoorHandler : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField, Range(0, 1)] float _doorOpenAngle;
    [SerializeField] private TextMeshProUGUI _doorAngleText;
    
    [SerializeField] private float _startRotation;
    [SerializeField] private float _limitRotation;

    private HingeJoint _doorHJ;
    private void Awake()
    {
        _doorHJ = gameObject.GetComponent<HingeJoint>();
    }
    private void Start()
    {
        JointLimits limits = _doorHJ.limits;
        limits.min = _startRotation;
        limits.max = _limitRotation;
        _doorHJ.limits = limits;
    }
    private void FixedUpdate()
    {
        _doorOpenAngle = Mathf.Abs(_door.rotation.y);
    }
    private void Update()
    {
        _doorAngleText.text = _doorOpenAngle.ToString();
    }
}
