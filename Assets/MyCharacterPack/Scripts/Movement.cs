using UnityEngine;

public class Movement : MonoBehaviour
{
    private Player _player;

    private string HorizontalAxisName = "Horizontal";
    private string VerticalAxisName = "Vertical";
    private const string IS_WALKING = "IsWalking";

    private float _deadZone = 0.1f;

    private CharacterController _characterController;
    private RotateToView _rotateToView;
    private Animator _animator;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _characterController = GetComponent<CharacterController>();
        _rotateToView = GetComponent<RotateToView>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

        if (input.magnitude > _deadZone)
        {
            Vector3 normalizedInput = input.normalized;
            ProcessMoveTo(normalizedInput);

            if (_rotateToView != null)
            {
                _rotateToView.RotateTowards(normalizedInput);
            }
            _animator.SetBool(IS_WALKING, true);
        }
        else
        {
            _animator.SetBool(IS_WALKING, false);
        }
    }

    private void ProcessMoveTo(Vector3 direction)
    {
        _characterController.Move(direction * _player.Speed * Time.deltaTime);
    }
}
