using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Direction { north, east, south, west }
    public GameObject player;
    public float moveDistance = 2f;
    public float moveTweenTime = 1f;
    public Ease moveEase;

    private bool hasPowerUp;
    public GameObject powerUpIndicator;
    public float powerUpStrength = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MovePlayer(Direction.north);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MovePlayer(Direction.south);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MovePlayer(Direction.west);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MovePlayer(Direction.east);
        }
    }

    void MovePlayer(Direction _direction)
    {
        switch (_direction)
        {
            case Direction.north:
                player.transform.DOMoveZ(player.transform.position.z + moveDistance, moveTweenTime).SetEase(moveEase);
                    break;
            case Direction.east:
                player.transform.DOMoveX(player.transform.position.x + moveDistance, moveTweenTime).SetEase(moveEase);
                    break;
            case Direction.south:
                player.transform.DOMoveZ(player.transform.position.z + -moveDistance, moveTweenTime).SetEase(moveEase);
                    break;
            case Direction.west:
                player.transform.DOMoveX(player.transform.position.x + -moveDistance, moveTweenTime).SetEase(moveEase);
                    break;


        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
            powerUpIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            print("Collided with " + collision.gameObject.name + "with powerup set to " +  hasPowerUp);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }


}
