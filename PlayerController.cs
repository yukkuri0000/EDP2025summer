using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // ライフ管理
    public int life = 1;

    // 移動速度設定
    public float normalSpeed = 7f;
    public float slowSpeed = 3f;

    // 当たり判定表示
    [SerializeField] GameObject hitbox;

    // UI
    [SerializeField] GameObject gameOverUI;

    //自機の弾
    [SerializeField] GameObject PlayerBullet;

    private Rigidbody2D rb;
    private Vector2 input;

    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f; // 念のためゲーム再開しておく
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }

    void Update()
    {
        if (isDead) return; // ゲームオーバー中は操作不能

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(moveX, moveY).normalized;

        // Shiftキーを押しているか
        bool isSlow = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float currentSpeed = isSlow ? slowSpeed : normalSpeed;

        // プレイヤーを移動させる処理
        transform.Translate(move * currentSpeed * Time.deltaTime);

        // ヒットボックスの見た目だけ切り替え
        if (hitbox != null)
        {
            var renderer = hitbox.GetComponent<SpriteRenderer>();
            if (renderer != null)
                renderer.enabled = isSlow;
        }
    }


    public void OnHit()
    {
        if (isDead) return;

        life--;
        if (life <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");

        isDead = true;
        Time.timeScale = 0f; // ゲーム停止

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }

    // リトライボタンから呼び出す
    public void Retry()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Retryボタンが押された");  //debug log　は確認用

    }

}
