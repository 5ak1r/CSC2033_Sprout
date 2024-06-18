using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprout : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    public GameObject platform;
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public GameObject platform4;
    public GameObject platform4_enemy;
    public GameObject platform5;
    public GameObject platform5_enemy;
    public GameObject enemy;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject bottom_border;
    public GameObject centre;
    private GameObject chosen_platform;
    private GameObject chosen_enemy;

    public float jumpHeight;
    private bool double_jump;
    private bool alive;
    private bool spawnable;
    private int counter;
    public CameraMovement cameraMovement;
    public ScoreTracker scoreTracker;
    public TransitionHandler transitionHandler; // Load from TransitionUICanvas object - set in inspector
    
    // Start is called before the first frame update
    void Start()
    {
        //get components, reset platform spawn distance, set sprout to alive
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        alive = true;
        spawnable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)
        {
            //jump only when grounded
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && Mathf.Abs(rb.velocity.y) < 0.01f)
            {
                double_jump = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                anim.Play("SproutJump");
            }
            //double jump
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !double_jump)
            {
                double_jump = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                anim.Play("SproutJump");
            }

            if(rb.velocity.y != 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("SproutJump")) {
                anim.Play("SproutJump");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //spawn platform when trigger
        if(other.gameObject.CompareTag("Create") && spawnable)
        {
            Destroy(other.gameObject);
            int choice = Random.Range(0, 6);
            int[] options = new int[] {0,2};
            //2 in 3 chance for cactus or snowman platform in desert and snow biomes
            if((choice) > 4 && ((scoreTracker.score % 20000 <= 7500 && scoreTracker.score > 5000)
            || scoreTracker.score % 20000 >= 17500)) choice += options[Random.Range(1,4) % 2];

            switch (choice) 
            {
                case 0:
                    chosen_platform = platform;
                    break;
                case 1:
                    chosen_platform = platform1;
                    break;
                case 2:
                    chosen_platform = platform2;
                    break;
                case 3:
                    chosen_platform = platform3;
                    break;
                case 4:
                    chosen_platform = platform4;
                    break;
                case 5:
                    chosen_platform = platform5;
                    break;
                case 6:
                    chosen_platform = platform4_enemy;
                    break;
                case 7:
                    chosen_platform = platform5_enemy;
                    break;
            }

            float ypos = Random.Range(bottom_border.transform.position.y + 1.0f, bottom_border.transform.position.y + 2.5f);
            Instantiate(chosen_platform, new Vector2(centre.transform.position.x + 3f*cameraMovement.cameraSpeed, ypos), Quaternion.identity);
            
            int enemy_chance = Random.Range(0,10);
            //chance for platform to have an enemy
            switch(enemy_chance)
            {
                case 0:
                    chosen_enemy = enemy;
                    break;
                case 1:
                    chosen_enemy = enemy1;
                    break;
                case 2:
                    chosen_enemy = enemy2;
                    break;
                default:
                    chosen_enemy = null;
                    break;
                
            }

            float extra_fire = 0f;
            //make sure fire never spawns on the far left, guaranteeing death
            if(chosen_enemy && chosen_enemy.gameObject.CompareTag("Fire")) extra_fire = 1.0f;
            if(chosen_enemy && choice > 2 && choice < 6) Instantiate(chosen_enemy, new Vector2(centre.transform.position.x + 3f*cameraMovement.cameraSpeed + Random.Range(0.4f, choice) + extra_fire, ypos + 0.7f), Quaternion.identity);
            spawnable = false;
            StartCoroutine(WaitForPlatform());
        }
        //game over when touching fire or falling off the map
        else if(other.gameObject.CompareTag("Fire")) 
        {
            StartCoroutine(Death());
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //jumping on enemy (greater y value) = kill enemy; else die
        if(other.gameObject.CompareTag("Enemy"))
        {
            Bounds bounds = GetComponent<Collider2D>().bounds;
            float ymin = bounds.min.y;

            Bounds otherbounds = other.gameObject.GetComponent<Collider2D>().bounds;
            float oycenter = otherbounds.center.y;

            if(ymin > oycenter)
            {

                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                double_jump = false;
                Destroy(other.gameObject);
                scoreTracker.score += 200;
            } 
            else 
            {
                
                StartCoroutine(Death());
            }

        }
        
        //change animation to walking and enable double jump when landing
        else if(other.gameObject.CompareTag("Platform")) 
        {
            double_jump = false;
        }

        else if(other.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        alive = false;
        cameraMovement.cameraSpeed = 0;
        anim.Play("SproutDeath");
        //https://forum.unity.com/threads/how-to-check-if-animator-is-playing.372973/
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("END") == true);
        Destroy(gameObject);
        transitionHandler.closeTransition("GameOver"); // Switch to Game Over scene
    }

    private IEnumerator WaitForPlatform()
    {
        yield return new WaitForSeconds(1 - cameraMovement.cameraSpeed * 0.0000000001f);
        spawnable = true;
    }
    

}


