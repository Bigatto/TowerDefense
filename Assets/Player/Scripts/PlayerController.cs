using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private InputActionAsset playerActions;
    [SerializeField] private Transform turrectConnectionPoint;
    private Rigidbody2D _rb;
    private Vector2 _velocity;
    private InputAction _movementAction;

    private bool _isCarrying = false;
    private InputAction _turretCarryingAction;
    private Transform _turretToCarry;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        playerActions.Enable();
        _movementAction = playerActions.FindAction("Movement");
        _turretCarryingAction = playerActions.FindAction("CarryTurret");
        _turretCarryingAction.performed += TurretCarryingTriggered;
    }

    private void Update()
    {
        _velocity = _movementAction.ReadValue<Vector2>();

    }

    private void FixedUpdate()
    {

        _rb.linearVelocity = _velocity * movementSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TurretTrigger"))
        {
            _turretToCarry = collision.transform.parent;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TurretTrigger"))
        {
            _turretToCarry = null;
        }
    }

    private void TurretCarryingTriggered(InputAction.CallbackContext _)
    {
        if (_isCarrying)
        {
            Debug.Log("Dropping tower");
            turrectConnectionPoint.DetachChildren();
            _isCarrying = false;

        }

        else if (_isCarrying == false && _turretToCarry != null)
            {
                _turretToCarry.SetParent(turrectConnectionPoint);
                var turretSprite = _turretToCarry.GetComponent<SpriteRenderer>();
                _turretToCarry.transform.localPosition = new Vector2(0, turretSprite.bounds.extents.y);
                _isCarrying = true;
            }
    }

}
