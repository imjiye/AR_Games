
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject camera;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Fire()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                GameManager.instance.AddScore(10);
                Destroy(hit.transform.gameObject);
                SoundManager.Instance.PlaySound("score");
                Instantiate(prefab1, hit.point, Quaternion.LookRotation(hit.normal));
                audio.Play();
            }
            else if(hit.transform.tag == "Point")
            {
                GameManager.instance.AddScore(15);
                Destroy(hit.transform.gameObject);
                SoundManager.Instance.PlaySound("point");
                Instantiate(prefab2, hit.point, Quaternion.LookRotation(hit.normal));
            }
            else if(hit.transform.tag == "Ghost")
            {
                GameManager.instance.SubScore(20);
                Destroy(hit.transform.gameObject);
                Instantiate(prefab3, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
