using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] GameObject[] bubble;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    public Rigidbody r;

    public void getHit()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(BubbleSpawn());

        r = GetComponent<Rigidbody>();
    }

    IEnumerator BubbleSpawn()
    {
        while(true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(bubble[Random.Range(0, bubble.Length)],
            position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shooter")
        {
            Destroy(collision.gameObject);
        }
    }


}
