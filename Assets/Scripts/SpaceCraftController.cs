using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class SpaceCraftController : MonoBehaviour
{
    [SerializeField] private float _linearSpeed = 0.5f;
    [SerializeField] private float _rollSpeed = 0.3f;
    [SerializeField] private float _spinSpeed = 0.3f;
    
    [SerializeField] private float _linearForce = 0.5f;
    [SerializeField] private float _rollForce = 0.3f;
    [SerializeField] private float _spinForce = 0.3f;
    
    private bool _boosterInput = false;
    private float _rollInput = 0f;
    private float _spinInput = 0f;
    
    private Rigidbody _rigidbody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if(_rigidbody == null)
        { 
            Debug.LogWarning("No rigidbody attached");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //No physics controller ----------------------------------------------
         // if (_boosterInput)
         // {
         //     transform.transform.Translate(0, 0, _linearSpeed * Time.deltaTime);
         // }
         // transform.Rotate(_rollInput * _rollSpeed * Time.deltaTime, _spinInput * _spinSpeed * Time.deltaTime, 0);

        //Full Physics controller
         if (_boosterInput)
         {
             _rigidbody.AddForce(transform.forward * _linearForce);
         }
         _rigidbody.AddRelativeTorque(_rollInput * _rollForce, _spinInput * _spinForce, 0);

        //Semi-Physics controller
        // if (_boosterInput)
        // {
        //     _rigidbody.linearVelocity = transform.forward * _linearSpeed;
        // }
    } 
    
    void OnBooster(InputValue value)
    {
        _boosterInput = value.isPressed;
    }
    
    void OnRollUpDown(InputValue value)
    {
        _rollInput = value.Get<float>();
    }
    
    void OnSpinLeftRight(InputValue value)
    {
        _spinInput = value.Get<float>();
    }
}
