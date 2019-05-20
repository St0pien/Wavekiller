using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Audio;

/**
 * Skrypt odpowiedzialny za zarządzanie głównym menu gry.
 * 
 * @author Hubert Paluch.
 * MViRe - na potrzeby kursu UNITY3D v5.
 * mvire.com 
 */
public class Menu : MonoBehaviour
{

    public Canvas quitMenu;
    public Button btnStart;
    public Button btnExit;
    public Canvas Options;
    public Button Optclick;

    public GameObject HUD;

    public AudioMixerSnapshot pauza;
    public AudioMixerSnapshot gra;

    public AudioMixer snd;
    public Slider slider;

    /** Obiekt menu.*/
    private Canvas manuUI;

    void Start()
    {
        manuUI = (Canvas)GetComponent<Canvas>();//Pobranie menu głównego.
        Options = Options.GetComponent<Canvas>();

        quitMenu = quitMenu.GetComponent<Canvas>(); //Pobranie menu pytania o wyjście z gry.

        btnStart = btnStart.GetComponent<Button>();//Ustawienie przycisku uruchomienia gry.
        btnExit = btnExit.GetComponent<Button>();//Ustawienie przycisku wyjścia z gry.
        Optclick = Optclick.GetComponent<Button>();

        HUD = GameObject.FindWithTag("hud");

        quitMenu.enabled = false; //Ukrycie menu z pytaniem o wyjście z gry.

        Time.timeScale = 0;//Zatrzymanie czasu.//Odblokowanie kursora myszy.

        btnExit.enabled = true;
        btnStart.enabled = true;
        Optclick.enabled = true;

        slider = GameObject.Find("all").GetComponent<Slider>();
        PrzyciskStart();
    }

    // Update is called once per frame
    void Update()
    {
        slider = GameObject.Find("all").GetComponent<Slider>();
        HUD = GameObject.FindWithTag("hud");

        Options = GameObject.FindWithTag("sndui").GetComponent<Canvas>();
        if (Input.GetKeyUp(KeyCode.Escape) && GameObject.FindWithTag("sndui").GetComponent<Canvas>().enabled == false)
        { //Jeżeli naciśnięto klawisz "Escape"


            manuUI.enabled = !manuUI.enabled;//Ukrycie/pokazanie menu.

            Cursor.visible = manuUI.enabled;//Ukrycie pokazanie kursora myszy.
            Cursor.lockState = CursorLockMode.Locked;

            if (manuUI.enabled)
            {
                Cursor.lockState = CursorLockMode.Confined;//Odblokowanie kursora myszy.
                Cursor.visible = true;//Pokazanie kursora
                Time.timeScale = 0;//Zatrzymanie czasu.
                quitMenu.enabled = false; //Ukrycie menu pytania.
                btnStart.enabled = true; //Aktywacja przycsiku 'Start'.
                btnExit.enabled = true; //Aktywacja przycsiku 'Wyjście'.
                Optclick.enabled = true;
                //pauza.TransitionTo(0.01f);
                snd.SetFloat("Master", slider.value - 20);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked; //Zablokowanie kursora myszy.
                Cursor.visible = false;//Ukrycie kursora.
                Time.timeScale = 1;//Włączenie czasu.
                quitMenu.enabled = false; //Ukrycie menu pytania.
                PrzyciskStart();
                HUD.SetActive(true);
                gra.TransitionTo(0.01f);
                snd.SetFloat("Master", slider.value);
            }

        }
        if(!manuUI.enabled)
        {
            Cursor.lockState = CursorLockMode.Locked; //Zablokowanie kursora myszy.
            Cursor.visible = false;//Ukrycie kursora.
        }
    }

    //Metoda wywoływana po naciśnięciu przycisku "Exit"
    public void PrzyciskWyjscie()
    {
        quitMenu.enabled = true; //Uaktywnienie meny z pytaniem o wyjście
        btnStart.enabled = false; //Deaktywacja przycsiku 'Start'.
        btnExit.enabled = false; //Deaktywacja przycsiku 'Wyjście'.
        Optclick.enabled = false;
    }

    //Metoda wywoływana podczas udzielenia odpowiedzi przeczącej na pytanie o wyjście z gry.
    public void PrzyciskNieWychodz()
    {
        quitMenu.enabled = false; //Ukrycie menu z pytaniem o wyjście z gry.
        btnStart.enabled = true; //Uaktywnienie przycisku 'Start'.
        btnExit.enabled = true; //Uaktywnienie przycisku 'Wyjscie'.
        Optclick.enabled = true;
    }

    //Metoda wywoływana przez przycisk uruchomienia gry 'Play Game'
    public void PrzyciskStart()
    {
        //Application.LoadLevel (0); //this will load our first level from our build settings. "1" is the second scene in our game  
        manuUI.enabled = false; //Ukrycie głównego menu.
        Options.enabled = false;

        btnExit.enabled = false;
        btnStart.enabled = false;
        Optclick.enabled = false;

        Time.timeScale = 1;//Właczenie czasu.

        Cursor.visible = false;//Ukrycie kursora.
        Cursor.lockState = CursorLockMode.Locked; //Zablokowanie kursora myszy.
        HUD.SetActive(true);
        gra.TransitionTo(0.01f);
        snd.SetFloat("Master", slider.value);
    }

    //Metoda wywoływana podczas udzielenia odpowiedzi twierdzącej na pytanie o wyjście z gry.
    public void PrzyciskTakWyjdz()
    {
        Application.Quit(); //Powoduje wyjście z gry.

    }

    public void Przycisk_Opcje()
    {
        btnExit.enabled = false;
        btnStart.enabled = false;
        Optclick.enabled = false;

        Options.enabled = true;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        snd.FindSnapshot("Game").TransitionTo(0.01f);


    }
}