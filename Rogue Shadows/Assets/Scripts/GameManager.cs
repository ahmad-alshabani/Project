using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject fps, weapon, objCamera,canvas;
    public GameObject heliCopter,heliCamera;
    public Vector3 myPos;
    public string fpsScr, weaponScr, cameraScr, heliScript,heliCamScr;
    public int inControl = 1;

    AudioSource sound;
    [SerializeField] AudioClip theme;

    public Transform heli;
    public Transform fpsPlayer;

    public Transform character1;
    public Transform character2;

    private float nextTimeToSwap;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!sound.isPlaying)
        {
            sound.PlayOneShot(theme);
        }
        if (Input.GetKey(KeyCode.N))
        {
            character1.gameObject.SendMessage("Activate");
            character2.gameObject.SendMessage("Deactivate");
        }

        if (Input.GetKey(KeyCode.B))
        {

            character2.gameObject.SendMessage("Activate");
            character1.gameObject.SendMessage("Deactivate");
        }

        if (Input.GetKey(KeyCode.E) && Time.time >= nextTimeToSwap )
        {
            fpsPlayer.transform.position = heli.transform.position + myPos;
            //fpsPlayer.transform.position.Set(heli.transform.position.x + 5f, heli.transform.position.y, heli.transform.position.z + 5f);
            nextTimeToSwap =  Time.time + 1f / 4f;
            Swap();
        }
    }

    void Swap()
    {

        /*other = GameObject.Find("FPS Player"); 

        other.GetComponent<PlayerMovement>().enabled = false;*/
        if (inControl == 2 && (fpsPlayer.transform.position.x < 40f || fpsPlayer.transform.position.z < 40f))
        {
            (fps.GetComponent(fpsScr) as MonoBehaviour).enabled = false;
            (weapon.GetComponent(weaponScr) as MonoBehaviour).enabled = false;
            (objCamera.GetComponent(cameraScr) as MonoBehaviour).enabled = false;
            fps.SetActive(false);
            weapon.SetActive(false);
            objCamera.SetActive(false);
            canvas.SetActive(false);

            inControl = 1;
            (heliCopter.GetComponent(heliScript) as MonoBehaviour).enabled = true;
            (heliCamera.GetComponent(heliCamScr) as MonoBehaviour).enabled = true;
            heliCopter.SetActive(true);
            heliCamera.SetActive(true);
        }
        else if(inControl == 1 )
        {
            (heliCopter.GetComponent(heliScript) as MonoBehaviour).enabled = false;
            (heliCamera.GetComponent(heliCamScr) as MonoBehaviour).enabled = false;
            //heliCopter.SetActive(false);
            heliCamera.SetActive(false);

            inControl = 2;
            (fps.GetComponent(fpsScr) as MonoBehaviour).enabled = true;
            (weapon.GetComponent(weaponScr) as MonoBehaviour).enabled = true;
            (objCamera.GetComponent(cameraScr) as MonoBehaviour).enabled = true;
            fps.SetActive(true);
            weapon.SetActive(true);
            objCamera.SetActive(true);
            canvas.SetActive(true);
        }
    }
}