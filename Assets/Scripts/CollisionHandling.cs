using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandling : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    AudioSource audioSource;

    void Awake(){
        
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    

    void OnCollisionEnter(Collision collision){

        switch (collision.gameObject.tag){
            case "Start":
                print("Start");
                break;
            case "End":
                print("End");
                Invoke("StartNextLevelSequence",0.5f);
                break;
            case "Obstacle":
                print("OI, STOP TOUCHING ME!");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence(){
        GetComponent<PlayerMovement>().enabled = false;
        audioSource.PlayOneShot(crash);
        Invoke("ReloadLevel",1f);
    }
    void StartNextLevelSequence(){
        GetComponent<PlayerMovement>().enabled = false;
        audioSource.PlayOneShot(success);
        Invoke("LoadNextLevel",1f);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            print(SceneManager.GetActiveScene().buildIndex + 1);
            print(SceneManager.sceneCountInBuildSettings + 1);

            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
