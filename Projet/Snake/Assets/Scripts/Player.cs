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

        public static float speed = 0.005f;
        public static int fps = 5;
        private readonly object corpsLock = new object();

        internal Dictionary<string, Vector3> directions = new Dictionary<string, Vector3>
        {
            { "droite", new Vector3(0.4f + speed, 0, 0) },
            { "gauche", new Vector3(-0.4f + speed, 0, 0) },
            { "haut", new Vector3(0, 0.4f + speed, 0) },
            { "bas", new Vector3(0, -0.4f + speed, 0) }
        };

        internal Vector3 direction;
        public GameObject corps;
        public static List<Corps> all_corps = new List<Corps>();

        void Start()
        {
            StartCoroutine(AutoCollision());
            direction = directions["haut"];
            all_corps.Add(Instantiate(corps, new Vector3(0, 0, 0), Quaternion.identity).transform.GetComponent<Corps>());
        }

        private void Awake()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = fps;
        }

        void Update()
        {
            if(Application.targetFrameRate != fps)
                Application.targetFrameRate = fps;
            checkPressed();
            move_corps();
        }

        private void move_corps()
        {
            Corps oldtete = all_corps[all_corps.Count - 1];
            Vector3 pos = oldtete.transform.position + direction;
            Corps newtete = all_corps[0];
            all_corps.RemoveAt(0);
            newtete.Move(pos);
            all_corps.Add(newtete);
        }

        private void checkPressed()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && direction != directions["bas"])
            {
                direction = directions["haut"];
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && direction != directions["haut"])
            {
                direction = directions["bas"];
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != directions["droite"])
            {
                direction = directions["gauche"];
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && direction != directions["gauche"])
            {
                direction = directions["droite"];
            }
        }

        public void Eat()
        {
            speed += 0.001f;
            Add_corps();
            score++;
        }
        
        public void Add_corps()
        {
            Vector3 pos = all_corps[all_corps.Count - 1].transform.position - direction;
            all_corps.Add(Instantiate(corps, pos, Quaternion.identity).transform.GetComponent<Corps>());
        }
        
        public IEnumerator AutoCollision()
        {
            while (true)
            {
                yield return new WaitForSeconds(.1f);
                Vector3 tete = all_corps[all_corps.Count - 1].transform.position;
                for (int i = 0; i < all_corps.Count() - 1; i++)
                {
                    if (Math.Abs(all_corps[i].transform.position.x - tete.x) < 0.003f &&
                        Math.Abs(all_corps[i].transform.position.y - tete.y) < 0.003f)
                    {
                        Die();
                    }
                }
            }
        }
        
        public void Die()
        {
            lock (corpsLock)
            {
                foreach (var co in all_corps)
                {
                    Destroy(co.gameObject);
                    all_corps.Remove(co);
                }
            }
            // SceneManager.LoadScene("Lose");
        }
    }
}
