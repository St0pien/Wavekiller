using UnityEngine;
using System.Collections;

public class AI_3 : MonoBehaviour
{

    //Predkosc obrotu przeciwnika.
    public float predkoscObrotu = 6.0f;

    //Gładki obrót przeciwnika
    public bool gladkiObrot = true;


    //Prędkość poruszania się przeciwnika.
    public float predkoscRuchu = 5.0f;
    //Odległość na jaką widzi przeciwnik.
    public float zasiegWzroku = 30f;
    //Odstęp w jakim zatrzyma się obiekt wroga od gracza.
    public float odstepOdGracza = 2f;

    public float Zdrowie = 100;

    private Transform mojObiekt;
    private Transform gracz;
    private bool patrzNaGracza = false;
    private Vector3 pozycjaGraczaXYZ;

    public bool spadl = false;

    float odlicz = 1;
    Vector3 przesuniecie = new Vector3(0,0,0);

    // Use this for initialization
    void Start()
    {

        mojObiekt = transform;
        //Rigidbody pozwala aby na obiekt oddziaływała fizyka.
        //Wyłaczenie oddziaływanie fizyki na XYZ - 
        // jak obiekt będzie wchodził pod górkę to się przechyli prostopadle do zbocza a fizyka pociągnie go w dół i
        // obiekt się przewróci. POZATYM NIE CHCEMY ABY WRÓG SIĘ TAK DZIWNIE OBRACAŁ ;).
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        odlicz -= Time.deltaTime;
        //Pobranie obiektu gracza.
        gracz = GameObject.FindWithTag("Player").transform;

        //Pobranie pozycji gracza.
        pozycjaGraczaXYZ = new Vector3(gracz.position.x, mojObiekt.position.y, gracz.position.z);

        //Pobranie dystansu dzielącego wroga od obiektu gracza.
        float dist = Vector3.Distance(mojObiekt.position, gracz.position);

        patrzNaGracza = false; //Wróg nie patrz na gracza bo jeszcze nie wiadomo czy jest w zasięgu wzroku.

        if (odlicz <= 0)
        {
            przesuniecie = new Vector3(Random.Range(0, 80),0 ,Random.Range(0, 80));
            odlicz = 1;
        }

        //Sprawdzenie czy gracz jest w zasięgu wzroku wroga.
        if (dist <= zasiegWzroku && dist > odstepOdGracza && !isDead())
        {
            patrzNaGracza = true;//Gracz w zasiegu wzroku wiec na neigo patrzymy

            //Teraz wykonujemy ruch wroga.
            //Vector3.MoveTowards - pozwala na zdefiniowanie nowej pozycji gracza oraz wykonanie animacji.
            //Pierwszy parametr obecna pozycja drógi parametr pozycja do jakiej dążymy (czyli pozycja gracza).
            //Trzeci parametr określa z jaką prędkością animacja/ruch ma zostać wykonany.
            if(spadl)
            {
                mojObiekt.position = Vector3.MoveTowards(mojObiekt.position, pozycjaGraczaXYZ + przesuniecie, predkoscRuchu * Time.deltaTime);
            }

        }
        else if (dist <= odstepOdGracza && !isDead())
        { //Jeżeli wróg jest tuż przy graczu to niech ciągle na niego patrzy mimo że nie musi się już poruszać.
            patrzNaGracza = true;
        }

        if (!isDead())
        {
            patrzNaMnie();
        }
        else
        {
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().freezeRotation = false;
                GetComponent<CapsuleCollider>().enabled = false;
                gameObject.tag = "DEAD";
                GetComponentInChildren<Enemys2>().smierc();
            }
        }
    }

    //Wróg może nie mieć potrzeby sie pruszać bo jest blisko gracza ale niech się obraca w jego stronę.
    void patrzNaMnie()
    {
        if (gladkiObrot && patrzNaGracza)
        {

            //Quaternion.LookRotation - zwraca quaternion na podstawie werktora kierunku/pozycji. 
            //Potrzebujemy go aby obrócić wroga w stronę gracza.
            //Quaternion rotation = Quaternion.LookRotation(pozycjaGraczaXYZ - mojObiekt.position);
            //Obracamy wroga w stronę gracza.
           // mojObiekt.rotation = Quaternion.Slerp(mojObiekt.rotation, rotation, Time.deltaTime * predkoscObrotu);
        }
        else if (!gladkiObrot && patrzNaGracza)
        { //Jeżeli nei chcemy gładkiego obracania się wroga tylko błyskawicznego obrotu.

            //Błyskawiczny obrót wroga.
            //transform.LookAt(pozycjaGraczaXYZ);
        }


    }

    public bool isDead()
    { 
        HP h = GetComponent<HP>();

        if (h != null)
        {
            return h.CzyMartwy();
        }
        return false;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            spadl = true;
        }
        else if (collision.gameObject == gameObject)
        {
            //spadl = true;
        }

        else
        {
            spadl = false;
        }

    }

}