using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    private Animator _playerAnim; //Animasyon

    public float _jumpForce;
    public float _gravityModifier;
    public bool _isOnGround = true;
    public bool _gameOver = false;
    public ParticleSystem _explosionParticle;
    public ParticleSystem _dirtParticle;
    public AudioClip _crashSound;
    public AudioClip _jumpSound;
    private AudioSource _playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>(); //Animasyon
        _playerAudio = GetComponent<AudioSource>();
        //1 _playerRb.AddForce(Vector3.up * 100);
        Physics.gravity *= _gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && !_gameOver)
        {
            //2 _playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _playerAnim.SetTrigger("Jump_trig"); //Animasyon
            _dirtParticle.Stop();
            _playerAudio.PlayOneShot(_jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision _collision)
    {
        //_isOnGround = true;

        if (_collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            _dirtParticle.Play();
        }
        else if (_collision.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            Debug.Log("Game Over!");
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);
            _explosionParticle.Play();
            _dirtParticle.Stop();
            _playerAudio.PlayOneShot(_crashSound, 1.0f);
        }
    }
}
