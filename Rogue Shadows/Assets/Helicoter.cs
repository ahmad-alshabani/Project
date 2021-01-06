using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Helicoter : MonoBehaviour
{
    Rigidbody rb;

    public GameObject fps,weapon, objCamera;
    public string fpsScr, weaponScr, cameraScr;
    public bool inControl = true;

    AudioSource helicopterFX;
    public bool isGrounded;
    private bool isControlEnabled = true;
    private bool isWin;
    int loadingTime = 2;


    bool inputEnabled = false;

    //SerializeFields
    [SerializeField] float rotationSpeed;
    [SerializeField] AudioClip chopper;

    [SerializeField] GameObject fpsPlayer;
    [SerializeField] GameObject particles;
    [SerializeField] GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        helicopterFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            Thrust();
            Rotate();
        }
        if (!helicopterFX.isPlaying)
        {
            helicopterFX.PlayOneShot(chopper);
        }

        if (inputEnabled == true)
        {
            transform.Translate(Vector3.right * 5 * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
            transform.Translate(Vector3.up * 5 * Input.GetAxisRaw("Vertical") * Time.deltaTime);
        }

        /*if (Input.GetKey(KeyCode.E))
        {
            Swap();
        }*/
    }

    void Activate()
    {
        inputEnabled = true;
    }

    void Deactivate()
    {
        inputEnabled = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("No worries!");
                
                break;
            case "Finish":
                isWin = true;
                print("You Win!!");
                //winFX.SetActive(true);
                if ((SceneManager.GetActiveScene().buildIndex + 1) == (SceneManager.sceneCountInBuildSettings))
                {
                    
                    /*if (!effectAudioSource.isPlaying)
                    {
                        effectAudioSource.PlayOneShot(victory);
                    }*/
                    Invoke("LoadNextScene", loadingTime + 8);
                }
                else
                {
                    /*if (!effectAudioSource.isPlaying)
                    {
                        effectAudioSource.PlayOneShot(roundWin);
                    }*/
                    Invoke("LoadNextScene", loadingTime);
                }
                isControlEnabled = false;
                break;
            default:
                //effectAudioSource.PlayOneShot(explodeSound);
                print("You Lose :(");
                if (isWin == false)
                {
                    Invoke("LoadFirstLevel", loadingTime - 1);
                }
                isControlEnabled = false;
                break;
        }
    }

    void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * 30);
            /*if (!helicopterFX.isPlaying)
            {
                helicopterFX.PlayOneShot(chopper);
            }*/
        }
        /*else
        {
            helicopterFX.Stop();
        }*/
    }

    void Swap() {

        /*other = GameObject.Find("FPS Player"); 

        other.GetComponent<PlayerMovement>().enabled = false;*/
        if (inControl == true)
        {
            (fps.GetComponent(fpsScr) as MonoBehaviour).enabled = false;
            (weapon.GetComponent(weaponScr) as MonoBehaviour).enabled = false;
            (objCamera.GetComponent(cameraScr) as MonoBehaviour).enabled = false;
            inControl = false;
            fps.SetActive(false);
            weapon.SetActive(false);
            objCamera.SetActive(false);
        }
        else
        {
            (fps.GetComponent(fpsScr) as MonoBehaviour).enabled = true;
            (weapon.GetComponent(weaponScr) as MonoBehaviour).enabled = true;
            (objCamera.GetComponent(cameraScr) as MonoBehaviour).enabled = true;
            inControl = true;
            fps.SetActive(true);
            weapon.SetActive(true);
            objCamera.SetActive(true);
        }
    }


    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void LoadFirstLevel()
    {
        print("Round 1");
        SceneManager.LoadScene(0);
    }

    void Rotate()
    {
        rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.right * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.left * rotationSpeed);
        }
        rb.freezeRotation = false;
    }

}
