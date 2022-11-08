using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    private BoxCollider2D m_BoxCollider;
    private SpriteRenderer m_SpriteRenderer;
    private GameStatesSystem gameStatesSystem;
    [SerializeField]
    private GameObject exitChecker;
    
    
    public void Init(GameStatesSystem gameStatesSystem)
    {
        this.gameStatesSystem = gameStatesSystem;
        exitChecker.GetComponent<ExitTheBase>().Init(gameStatesSystem);
        m_BoxCollider = GetComponent<BoxCollider2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Open()
    {
        m_SpriteRenderer.enabled = false;
        m_BoxCollider.enabled = false;
        exitChecker.SetActive(false);
    }
    public void Close()
    {
        m_SpriteRenderer.enabled = true;
        m_BoxCollider.enabled = true;
    }
}
