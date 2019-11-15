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


    // Update is called once per frame
    void Update()
    {
        // HELP ****************
        //   V

        // If User taps / presses button
        if(Input.GetKey(KeyCode.Space) && Time.time > _nextFire)
        {
            // Making Knife move
            transform.Translate (Vector3.up * _speed * Time.deltaTime);
        }
        // If knife hits mark

        // score 1 point
        // else
        // remove 1 life

    }

    public void Damage()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Target")
        {
            Knife knife = other.GetComponent<Knife>();

            if(knife !=null)
            {
                knife.Damage();
            }
            Destroy(this.gameObject);
        }
    }


}
