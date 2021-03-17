# Alexander Pihl - Flow 2 Handin
Vi har samlet i gruppen valgt at lave et Tower Defence spil som tager udgangspunkt i et medieval tema. Derfor har indtil videre designet et level med dertilhørende fjender, kanon tårne, UI osv.

I dette projekt har jeg stået for alt UI i spillet og spawning af nye cannon towers. 

# Emner brugt:

### - Scripts og references.
  - Der er brugt scripts til at styre de forskellige UI knapper såsom, start(play), restart game, volume slider osv.
  - Der er også brugt script til spawning af nye cannon towers.
  
TowerSpawner:

```c#
public class TowerSpawner : MonoBehaviour
{

    [SerializeField] private GameObject towerPrefab;
    Vector3 offset = new Vector3(0f,1f,0f);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Instantiate(towerPrefab, hit.point - offset, Quaternion.identity);
            }
        }
    }
}
```
MainMenu:
```c#
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void quitGame()
    {
        Application.Quit();
    }

}
```

RestartGame:
```c#
public class RestartGame : MonoBehaviour
{

public void Restart()
{
    SceneManager.LoadScene(1);
}
 
}
```
### - Camera
  - Til vinkling af view så hele banen med tilkoblet UI kan ses.
### - UI elementer
  - Canvas
    - Til at indramme UI både ind-game og i startmenu.
  - Image
    - Til styling og farver.
  - Panel
    - Til styling og farver.
  - Slider
    - Til visuel styring af volumen fra kanoneksplotionerne in-game.
  - Eventsystem
    - Til håndtering af events.
### - AudioMixer (til håndtering af volume slider)
  - Sat sammen med cannonSound og script for at håndtere lyd volume

```c#
public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("CannonVol", Mathf.Log10(sliderValue) * 20);
    }
}

```
### - Build settings
  - I form at scene queue til styren af load af level fra startmenu
### - Parenting & Childs

