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

[SerializeField]
private int _score = 0;

private Rigidbody2D _rigidbody;

void Awake()
{
    _rigidbody = GetComponent<Rigidbody2D>();
}

    // Update is called once per frame
    void Update()
    {

        // If User taps / presses button
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            // Making Knife move
            _rigidbody.AddForce(Vector2.up * _speed, ForceMode2D.Impulse);
            GameController.Instance.GameUI.DecrementDisplyedMissileCount();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wheel")
        {
            _rigidbody.isKinematic = true;
            transform.SetParent(other.transform);
            enabled = false;

            // _lives--;
            //Spwan next missile
            // if life = 0, Game Over

            // if(_lives <= 0)
            // {
            //     GameController.Instance.StartGameOverSequence(false);
            // }
        }

        if (other.gameObject.tag == "Target")
        {
            // GetComponent<ParticleSystem>().Play();

            _score++;

            //--------------------------- > Instantiate.ParticleSystem();

            // Destroy Missile
            Destroy(this.gameObject);

            // Destroy Target
            Destroy(other.gameObject);

            // Spwan next Missile
            // if score = 1

            if (_score == 1)
            {
                //Next Scene
            }
        }

        GameController.Instance.OnSuccessfulMissileHit();
    }
}
