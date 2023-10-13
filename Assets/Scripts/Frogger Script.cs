using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggerScript : MonoBehaviour
{
    [SerializeField] bool canMove = true;

    /*
     * [SerializeField] isDead;
     * [SerializeField] onPlatform;
     * [SerializeField] onRiver;
     * [SerializeField] 
     * 
     * private void OnTriggerEnter2D(Collider2D other)
     * {
     *      if (other.gameObject.tag == "killVolume" && !isDead)
     *      {
     *              StartCoroutine(PlayerDeath());
     *      }
     *      if (other.gameObject.tag == "River")
     *      {
     *              onRiver = true;
     *      }
     * }
     * 
     * private void OnTriggerExit2D(Collider2D other)
     * {
     *      if (other.gameObject.tag == "River")
     *      {
     *              onRiver = false;
     *      }
     * }
     */

    void Start()
    {
        
    }

    void Update()
    {
        PlayerUpdate();
    }

    void PlayerUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)
            && canMove)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            PlayerMove(Vector3.up);
            StartCoroutine(MoveTime());
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)
                 && canMove)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            PlayerMove(Vector3.down);
            StartCoroutine(MoveTime());
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)
                 && canMove)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            PlayerMove(Vector3.left);
            StartCoroutine(MoveTime());
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)
                 && canMove)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
            PlayerMove(Vector3.right);
            StartCoroutine(MoveTime());
        }
    }

    void PlayerMove(Vector3 direction)
    {
        Vector3 destination = transform.position + direction;
        StartCoroutine(SmoothMove(destination));
    }

    IEnumerator SmoothMove(Vector3 destination)
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0;
        float duration = 0.125f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(startPosition, destination, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = destination;
    }

    IEnumerator MoveTime()
    {
        canMove = false;
        yield return new WaitForSeconds(0.15f);
        canMove = true;
        /*
         * _audi.PlayOneShot(audiomanager.soundFX[1]);
         * if (onRiver)
         * {
         *      if (!onPlatform)
         *      {
         *              StartCoroutine(PlayerDeath());
         *      }
         * }
         * WARNING: Make sure that jumping AWAY from the river does not kill you!
         */
    }

    /*
     * IEnumerator PlayerDeath(int sfx)
     * {
     *      isDead = true;
     *      transform.rotation = Quaternion.Euler(0, 0, 0);
     * }
     */
}
