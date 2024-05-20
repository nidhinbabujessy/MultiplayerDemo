using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private PhotonView view;

    public GameObject Win;
    public GameObject fail;

    private void Start()
    {
        view = GetComponent<PhotonView>();

        // Ensure Win and fail are inactive at the start
        if (Win != null)
        {
            Win.SetActive(false);
        }
        if (fail != null)
        {
            fail.SetActive(false);
        }

        // Assign Win and fail if they are not assigned in the Inspector
        if (Win == null)
        {
            Win = GameObject.FindGameObjectWithTag("win");
            if (Win != null)
            {
                Win.SetActive(false);
            }
            else
            {
                Debug.LogError("Win object with tag 'win' not found!");
            }
        }

        if (fail == null)
        {
            fail = GameObject.FindGameObjectWithTag("fail");
            if (fail != null)
            {
                fail.SetActive(false);
            }
            else
            {
                Debug.LogError("Fail object with tag 'fail' not found!");
            }
        }
    }

    private void Update()
    {
        if (view.IsMine)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (view.IsMine)
            {
                if (Win != null && !Win.activeSelf)
                {
                    Win.SetActive(true);
                    //Debug.Log("win");
                    SceneManager.LoadScene("win");
                }
            }
            view.RPC("ShowMessage", RpcTarget.Others, "Fail");
        }
    }

    [PunRPC]
    void ShowMessage(string message)
    {
        Debug.Log(message);
        if (message == "Fail" && fail != null && !fail.activeSelf)
        {
            SceneManager.LoadScene("fail");
            //fail.SetActive(true);
            Debug.Log("fail");
        }
    }
}
