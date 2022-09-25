using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SG
{

    public class WaveSpawn : MonoBehaviour
    {

        public Transform[] ennemySpawnPoints;
        [SerializeField] GameObject ennemy;
        [SerializeField] GameObject bossEnemy;
        [SerializeField] int bossNumeroWave;
        GameObject child;
        int oldNbr = 0;
        string waveContent;
        int numeroWave;
        [SerializeField] Text waveNbr;
        [SerializeField] GameObject waveAnnouncement;
        private int fiboNm1;
        private int fiboN;
        private int nbrEnemy;
        private int pointNbr;
        GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            fiboNm1 = 1;
            nbrEnemy = GetFiboEnemyNbr();
            pointNbr = 0;
            NewWave();
            waveContent = "Vague n°" + numeroWave + " avec ";
            numeroWave = 0;
            waveNbr.text = numeroWave.ToString();
            GameObject.Find("/EnemyWave/Enemy").SetActive(false); 
            GameObject.Find("/EnemyWave/EnemyBoss").SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

            if (GetRemainingEnnemyNbr() == 0 || Input.GetKeyDown(KeyCode.N))
            {
                numeroWave += 1;
                if (numeroWave < bossNumeroWave)
                {
                    NewWave();

                    waveContent = "Vague n°" + numeroWave + " : ";
                    waveNbr.text = numeroWave.ToString();
                    fiboN = GetFiboEnemyNbr();
                }
                else if (numeroWave==bossNumeroWave)
                {
                    StartCoroutine(WaveAnnouncement());
                    ReplacePlayer();
                    Transform point = ennemySpawnPoints[0];
                    GameObject newEnnemy = bossEnemy;
                    Instantiate(newEnnemy, point.position, Quaternion.identity);
                    newEnnemy.transform.Rotate(new Vector3(0, 180, 0));
                }
                else
                {
                    Debug.Log("Victory");
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }

        private int GetRemainingEnnemyNbr()
        {
            int nbr = GameObject.FindGameObjectsWithTag("Ennemy").Length;
            if (oldNbr != nbr)
            {
                Debug.Log("remaining Ennemy = " + nbr);
                oldNbr = nbr;
            }
            return nbr;
        }
        public void NewWave()
        {
            StartCoroutine(WaveAnnouncement());
            ReplacePlayer();

            while (nbrEnemy < fiboN)
            {
                Transform point = ennemySpawnPoints[pointNbr];
                GameObject newEnnemy = ennemy;
                Instantiate(newEnnemy, point.position, Quaternion.identity);
                int ennemyIndex = getTypeOfEnnemy();
                GameObject ennemyType = newEnnemy.transform.Find("Enemy").gameObject;

                for (int j = 0; j < ennemyType.transform.childCount - 1; j++)
                {
                    ennemyType.transform.GetChild(j).gameObject.SetActive(false);
                    if (j == ennemyIndex)
                    {
                        child = ennemyType.transform.GetChild(j).gameObject;
                        child.SetActive(true);
                    }
                }
                waveContent += child.name + ", ";
                //}
                Debug.Log("ennemySpawnpoint.length = " + ennemySpawnPoints.Length);
                if (pointNbr < ennemySpawnPoints.Length - 1)
                {
                    pointNbr += 1;
                }
                else
                {
                    pointNbr = 0;
                }
                nbrEnemy += 1;
            }
            nbrEnemy = 0;
            Debug.Log(waveContent);
        }

        private int getTypeOfEnnemy()
        {
            return Random.Range(0, GameObject.Find("/Enemy(Clone)/Enemy").transform.childCount - 2);
        }

        IEnumerator WaveAnnouncement()
        {
            for (int i = 0; i < 3; i++)
            {
                waveAnnouncement.SetActive(true);
                yield return new WaitForSeconds(0.6f);
                waveAnnouncement.SetActive(false);
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(2f);
        }

        private int GetFiboEnemyNbr()
        {
            int fiboNm2 = fiboNm1;
            fiboNm1 = fiboN;
            fiboN = fiboNm1 + fiboNm2;
            return fiboN;
        }

        private void ReplacePlayer()
        {
            player = GameObject.Find("Player");
            player.GetComponent<PlayerStats>().CurePlayer();
            player.transform.position = new Vector3(0.0f, 0.0f, -4.0f);
        }
    }
}
