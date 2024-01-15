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
        private Rigidbody2D _rb;

        public enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }

        private Direction direction;
        public static float speed = 0.005f;
        public GameObject corps;
        public static List<corps> all_corps = new List<corps>();
        Queue<Vector2> positions = new Queue<Vector2>();

        void Start()
        {
            Vector3 pos = transform.position;
            pos.x = 0;
            pos.y = 0;
            _rb = gameObject.GetComponent<Rigidbody2D>() == null
                ? gameObject.AddComponent<Rigidbody2D>()
                : gameObject.GetComponent<Rigidbody2D>();
            _rb.gravityScale = 0;
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }




        void Update()
        {
            checkPressed();
            move();
            move_corps();
        }

        private void move_corps()
        {
            positions.Enqueue(transform.position);

            if (positions.Count > all_corps.Count)
            {
                positions.Dequeue();
            }
            
            if (all_corps.Count == 0)
            {
                return;
            }
            for (int i = 0; i < all_corps.Count; i++)
            {
                all_corps[i].Move(all_corps[i].transform.position, direction);
            }
        }

        private void move()
        {
            switch (direction)
            {
                case Direction.Up:
                    transform.position += new Vector3(0, speed, 0);
                    break;
                case Direction.Down:
                    transform.position += new Vector3(0, -speed, 0);
                    break;
                case Direction.Left:
                    transform.position += new Vector3(-speed, 0, 0);
                    break;
                case Direction.Right:
                    transform.position += new Vector3(speed, 0, 0);
                    break;
            }
        }

        private void checkPressed()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && direction != Direction.Down)
            {
                direction = Direction.Up;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && direction != Direction.Up)
            {
                direction = Direction.Down;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != Direction.Right)
            {
                direction = Direction.Left;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && direction != Direction.Left)
            {
                direction = Direction.Right;
            }
        }

        public void Eat()
        {
            speed += 0.001f;
            Add_corps(direction);
            score++;
        }
        
        
        public void Add_corps(Direction direction)
        {
            Vector3 pos = all_corps.Count == 0 ? transform.position : all_corps[all_corps.Count - 1].transform.position;
            switch (direction)
            {
                case Direction.Down:
                    pos.y += 0.4f + 0.01f;
                    break;
                case Direction.Up:
                    pos.y -= 0.4f + 0.01f;
                    break;
                case Direction.Left:
                    pos.x += 0.4f + 0.01f;
                    break;
                case Direction.Right:
                    pos.x -= 0.4f + 0.01f;
                    break;
            }
            all_corps.Add(Instantiate(corps, pos, Quaternion.identity).transform.GetComponent<corps>());
        }
        
        public void Die()
        {
            Destroy(this);
            // SceneManager.LoadScene("Lose");
        }
    }
}
