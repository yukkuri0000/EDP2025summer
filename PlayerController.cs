using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // ���C�t�Ǘ�
    public int life = 1;

    // �ړ����x�ݒ�
    public float normalSpeed = 7f;
    public float slowSpeed = 3f;

    // �����蔻��\��
    [SerializeField] GameObject hitbox;

    // UI
    [SerializeField] GameObject gameOverUI;

    //���@�̒e
    [SerializeField] GameObject PlayerBullet;

    private Rigidbody2D rb;
    private Vector2 input;

    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f; // �O�̂��߃Q�[���ĊJ���Ă���
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }

    void Update()
    {
        if (isDead) return; // �Q�[���I�[�o�[���͑���s�\

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(moveX, moveY).normalized;

        // Shift�L�[�������Ă��邩
        bool isSlow = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float currentSpeed = isSlow ? slowSpeed : normalSpeed;

        // �v���C���[���ړ������鏈��
        transform.Translate(move * currentSpeed * Time.deltaTime);

        // �q�b�g�{�b�N�X�̌����ڂ����؂�ւ�
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
        Time.timeScale = 0f; // �Q�[����~

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }

    // ���g���C�{�^������Ăяo��
    public void Retry()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Retry�{�^���������ꂽ");  //debug log�@�͊m�F�p

    }

}
