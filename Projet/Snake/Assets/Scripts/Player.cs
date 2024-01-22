using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Serpent
{
    public class Player : MonoBehaviour
    {
        public int score = 0;

        public static float Speed = 0.005f;
        public static int FPS = 5;
        private static readonly object _corpsLock = new object();
        internal static bool PlayerDie = false;

        internal Dictionary<string, Vector3> Directions = new Dictionary<string, Vector3>
        {
            { "droite", new Vector3(0.45f + Speed, 0, 0) },
            { "gauche", new Vector3(-0.45f + Speed, 0, 0) },
            { "haut", new Vector3(0, 0.45f + Speed, 0) },
            { "bas", new Vector3(0, -0.45f + Speed, 0) }
        };

        internal Vector3 Direction;
        public GameObject corps;
        public static List<Corps> AllCorps = new List<Corps>();

        private void Awake()
        {
            QualitySettings.vSyncCount = 0;
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
                return;
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

        public void Eat()
        {
            Speed += 0.001f;
            Add_corps();
            score++;
        }
        
        public void Add_corps()
        {
            Vector3 pos = AllCorps[AllCorps.Count - 1].transform.position - Direction;
            AllCorps.Add(Instantiate(corps, pos, Quaternion.identity).transform.GetComponent<Corps>());
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
                            Die(AllCorps);
                        }
                    }
                }
            }
        }
        
        public static void Die(List<Corps> list)
        {
            PlayerDie = true; 
            lock (_corpsLock)
            {
                try
                {
                    foreach (var co in AllCorps)
                    {
                        Destroy(co.gameObject);
                        AllCorps.Remove(co);
                    }
                }
                catch (Exception e)
                {
                    Die(list);
                }
            }
            SceneManager.LoadScene(0);
        }
    }
}
