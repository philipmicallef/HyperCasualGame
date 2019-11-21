using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
// Creating UI Variable 
[Header("Player Options")]
[SerializeField]
private float _speed = 10f;

[SerializeField]
private float _fireRate = 0.5f;

private float _nextFire = -2.0f;

[SerializeField]
private int _lives = 3;

private Rigidbody2D _rigidbody;

void Start()
{
    _rigidbody = GetComponent<Rigidbody2D>();
}


    // Update is called once per frame
    void Update()
    {


        // HELP ****************
        //   V

        // If User taps / presses button
        if(Input.GetKey(KeyCode.Space) && Time.time > _nextFire)
        {
            // Making Knife move
            _rigidbody.AddForce(Vector2.up * _speed, ForceMode2D.Impulse);
            
            //CREATE THROW CLASS
        }
        // If knife hits mark

        // score 1 point
        // else
        // remove 1 life

    }

    public void Throw()
    {

    } 

    public void Damage()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Spin")
        {
            _rigidbody.isKinematic = true;
            transform.SetParent(other.transform);
        }

        if (other.gameObject.name == "Target")
        {
            _rigidbody.isKinematic = true;
            transform.SetParent(other.transform);
        }

        // RE-WORK IF STATEMENT
        // if(other.gameObject.tag != "Target")
        // {
        //     Knife knife = other.GetComponent<Knife>();

        //     if(knife !=null)
        //     {
        //         knife.Damage();
        //     }
        //     Destroy(this.gameObject);
        // }
    }


}
