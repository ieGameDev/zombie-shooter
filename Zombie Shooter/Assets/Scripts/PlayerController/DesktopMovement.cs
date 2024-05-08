using UnityEngine;

public class DesktopMovement : MonoBehaviour
{
    private Vector3 _moveVector;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _moveVector = Vector3.ClampMagnitude(_moveVector, 1f);

        _playerMovement.PlayerMove(_moveVector);
    }
}
