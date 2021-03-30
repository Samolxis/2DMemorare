using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private const int gridRows = 2;
    private const int gridCols = 4;

    private const float offSetX = 3.5f;
    private const float offSetY = 4.5f;

    private FaceCard m_first;
    private FaceCard m_second;


    Score addToScore;

    [SerializeField] private FaceCard mainCard;
    [SerializeField] private Sprite[] images;

    private void Start()
    {
        addToScore = GameObject.FindGameObjectWithTag("GUI").GetComponent<Score>();
        Vector3 startPos = mainCard.transform.position;

        int[] nr = { 0, 0, 1, 1, 2, 2, 3, 3 };
        nr = RngArray(nr);


        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                FaceCard card;
                if (i == 0 && j == 0)
                {
                    card = mainCard;
                }
                else {
                    card = Instantiate(mainCard) as FaceCard;
                }

                int index = j * gridCols + i;
                int id = nr[index];
                card.ChangeImage(id, images[id]);
               
                float posX = (offSetX * i) + startPos.x;
                float posY = (offSetY * j) + startPos.y;
                //Debug.Log(posX + " " + posY);
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }


    // random number Array
    private int[] RngArray(int[] num)
    {
        int[] tempArray = num.Clone() as int[];
        for (int i = 0; i < tempArray.Length; i++)
        {
            // Swap
            int temp = tempArray[i];
            int r = Random.Range(i, tempArray.Length);
            tempArray[i] = tempArray[r];
            tempArray[r] = temp;
        }
        return tempArray;
    }

    public bool canReveal
    {
        get { return m_second == null; }
    }


    public void CardRev(FaceCard card)
    {
        if (m_first == null)
            m_first = card;
        else
        {
            m_second = card;
            StartCoroutine(CheckMatch());
        }
     }

    private IEnumerator CheckMatch()
    {
        if(m_first.GetId() == m_second.GetId())
        {
            //Call Score

            addToScore.AddToScore();

        }
        else
        {
            yield return new WaitForSeconds(0.5f);
         
            m_first.Reveal(); m_second.Reveal();
        }
        // Back to null
        //Debug.Log(m_first.GetId());
        m_first = null; m_second = null;

    }

}
