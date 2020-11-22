using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFrom : MonoBehaviour
{
    [SerializeField] GameObject objectToFire;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float fireForce = 10f;
    float nextFire;

    private void Update()
    {
        if (Time.time > nextFire)
        {
            FireObject();
            nextFire = Time.time + 1 / fireRate;
        }
    }

    void FireObject()
    {
        GameObject tempObject = Instantiate(objectToFire, transform.position, transform.rotation);
        tempObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, fireForce), ForceMode2D.Impulse);
        Destroy(tempObject, 3f);
    }

}
