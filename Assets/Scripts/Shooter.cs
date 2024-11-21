using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private Projectile bullet;
    [SerializeField] private Transform firePoint;
    private Coroutine shoot_routine = null;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FireLaser()
    {
        while (true)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(fireRate);
        }
    }
    
    void OnShoot(InputValue value)
    {
        if (value.isPressed)
        {
            if(shoot_routine != null)
            {
                StopCoroutine(shoot_routine);
            }
            //StopAllCoroutines();
            shoot_routine = StartCoroutine("FireLaser");
        }
        else
        {
            StopCoroutine("FireLaser");
            shoot_routine = null;
        }
    }
}