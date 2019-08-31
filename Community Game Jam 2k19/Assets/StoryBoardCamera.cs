using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryBoardCamera : MonoBehaviour
{
    Camera cam;
    [SerializeField]
    float moveSpeed = 1f;
    [SerializeField]
    Transform Point;
    bool isClicked;
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip clip;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        if (isClicked)
        {
            direction = Point.position - transform.position;
            direction = direction.normalized;
            cam.transform.position += new Vector3(direction.x * moveSpeed, 0, 0) * Time.fixedDeltaTime;
        }
    }

    // Update is called once per frame
    public void OnClick()
    {
        source.clip = clip;
        source.Play();
        isClicked = true;
        StartCoroutine(StartNextLevel());
    }

    IEnumerator StartNextLevel()
    {
        yield return new WaitForSeconds(34f);
        SceneManager.LoadScene("Loading Scene", LoadSceneMode.Single);
    }

}
