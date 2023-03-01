using Controllers;
using UnityEngine;
using UseCases;

public class PlayerMovementController : MonoBehaviour, IPlayerShipController
{
    
    private IUserProfileUseCase m_playerProfileUseCase;
    private Rigidbody2D m_rigidbody;
    public bool IsMoving { get; private set; }
    [field: SerializeField] public int Impulse { get; set; }

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsMoving == false) return;
        m_rigidbody.AddForce(Impulse*transform.up, ForceMode2D.Force);
    }

    public void ProcessKeyDown(KeyCode _keyCode)
    {
       if(_keyCode == KeyCode.Z) IsMoving = true;
    }

    public void ProcessMousePosition(Vector3 _mousePosition)
    {
        var direction = _mousePosition - transform.position;
        var rotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = rotation;
    }

    public void ProcessKeyUp(KeyCode _keyCode)
    {
        if(_keyCode == KeyCode.Z) IsMoving = false;
    }

    public void Initialize(IUserProfileUseCase _playerProfileUserCase)
    {
        m_playerProfileUseCase = _playerProfileUserCase;
    }
    
}
