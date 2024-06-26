using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Serpent
{
    public class Player : MonoBehaviour
    {
        public static int Score ;
        public static int HighScore;
        public static float Speed = 0.005f;
        public static int FPS = 5;
        private static readonly object CorpsLock = new object();
        internal static bool PlayerDie;

        internal Dictionary<string, Vector3> Directions = new Dictionary<string, Vector3>
        {
            { "droite", new Vector3(0.5f + Speed, 0, 0) },
            { "gauche", new Vector3(-0.5f + Speed, 0, 0) },
            { "haut", new Vector3(0, 0.5f + Speed, 0) },
            { "bas", new Vector3(0, -0.5f + Speed, 0) }
        };

        public static Vector3 Direction;
        public GameObject corps;
        public static List<Corps> AllCorps = new List<Corps>();

        private void Awake()
        {
            Debug.Log("Player Awake");
            PlayerDie = false;
            QualitySettings.vSyncCount = 0;
            Speed = 0.005f;
            FPS = 5;
            Application.targetFrameRate = FPS;
            StartCoroutine(AutoCollision());
            Direction = Directions["haut"];
            Corps tete = Instantiate(corps, new Vector3(0, 0, 0), Quaternion.identity).transform.GetComponent<Corps>();
            tete.tag = "Player";
            AllCorps.Add(tete);
        }

        void Update()
        {
            if(Application.targetFrameRate != FPS)
                Application.targetFrameRate = FPS;
            if (PlayerDie)
            {
                Debug.Log("PlayerDie");
                Destroy(this);
                return;
            }
            CheckPressed();
            move_corps();
        }

        private void move_corps()
        {
            if (AllCorps.Count <= 0)
                return;
            Corps oldtete = AllCorps[AllCorps.Count - 1];
            Vector3 pos = oldtete.transform.position + Direction;
            Corps newtete = AllCorps[0];
            oldtete.tag = "Corps";
            newtete.tag = "Player";
            AllCorps.RemoveAt(0);
            newtete.Move(pos);
            AllCorps.Add(newtete);
        }

        private void CheckPressed()
        {
            if ((Score % 50 >= 0 && Score % 50 < 10) && Score >= 50)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) && Direction != Directions["haut"])
                {
                    Direction = Directions["bas"];
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && Direction != Directions["bas"])
                {
                    Direction = Directions["haut"];
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && Direction != Directions["gauche"])
                {
                    Direction = Directions["droite"];
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) && Direction != Directions["droite"])
                {
                    Direction = Directions["gauche"];
                }
            } else
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) && Direction != Directions["bas"])
                {
                    Direction = Directions["haut"];
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && Direction != Directions["haut"])
                {
                    Direction = Directions["bas"];
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && Direction != Directions["droite"])
                {
                    Direction = Directions["gauche"];
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) && Direction != Directions["gauche"])
                {
                    Direction = Directions["droite"];
                }
            }
        }

        public void Eat()
        {
            Speed += 0.001f;
            Add_corps();
            Score++;
            if (Score > HighScore)
                HighScore = Score;
        }
        
        public void Add_corps()
        {
            Vector3 pos = AllCorps[0].transform.position - Direction;
            AllCorps.Insert(0, Instantiate(corps, pos, Quaternion.identity).transform.GetComponent<Corps>());
        }
        
        public IEnumerator AutoCollision()
        {
            while (true)
            {
                yield return new WaitForSeconds(.1f);
                if (AllCorps.Count > 1)
                {
                    Corps tete = AllCorps[AllCorps.Count - 1];
                    for (int i = 0; i < AllCorps.Count - 1; i++)
                    {
                        if (tete.transform.position == AllCorps[i].transform.position)
                        {
                            Debug.Log("Collision");
                            Die(AllCorps);
                        }
                    }
                }
            }
        }
        
        public static void Die(List<Corps> list)
        {
            PlayerDie = true;
            lock (CorpsLock)
            {
                try
                {
                    foreach (var co in AllCorps)
                    {
                        Destroy(co.gameObject);
                        AllCorps.Remove(co);
                    }
                }
                catch (Exception)
                {
                    Die(list);
                }
            }
            SceneManager.LoadScene(5);
        }
    }
}
