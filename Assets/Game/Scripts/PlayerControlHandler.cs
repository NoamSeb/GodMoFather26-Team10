using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControlHandler : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private Image _cursor;
    
    private Vector2 m_MoveVector;
    private Vector2 direction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Move();
    }
    
    private void OnDisable()
    {
        Destroy(this);
    }
    
    // Update is called once per frame
    public void ReadMoveInput(InputAction.CallbackContext context)
    {
        m_MoveVector = context.ReadValue<Vector2>();
    }
    
    public void ReadInteractInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Interact();
        }
    }

    private void Move()
    {
        direction = new Vector2(m_MoveVector.x, m_MoveVector.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
             _cursor.transform.position += (Vector3) direction * _speed;
        }
    }

    private void Interact()
    {
        
    }
}
