using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapPathFinding : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Tilemap tilemap;
    public Color originalColor = Color.white;
    public Color highlightColor = Color.cyan;

    private List<Vector3> path;
    private Vector3Int highlightedCell;

    void Update()
    {
        HandleMouseClick();
        MoveOnPath();
    }

    public void HandleMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null && hit.collider.CompareTag("Tilemap"))
            {
                Vector3Int targetCell = tilemap.WorldToCell(hit.point);

                if (targetCell != tilemap.WorldToCell(transform.position))
                {
                    if (highlightedCell == targetCell)
                    {
                        // �� ��° Ŭ�� �� ���� �������� �ǵ����� �̵�
                        HighlightTile(targetCell, originalColor);
                        FindPath(transform.position, tilemap.GetCellCenterWorld(targetCell));
                    }
                    else
                    {
                        // ó�� Ŭ�� �� Ÿ�� ���� ����
                        HighlightTile(targetCell, highlightColor);
                    }
                }
            }
        }
    }


    void FindPath(Vector3 startPosition, Vector3 targetPosition)
    {
        Vector3Int startCell = tilemap.WorldToCell(startPosition);
        Vector3Int targetCell = tilemap.WorldToCell(targetPosition);

        path = AStar.FindPath(tilemap, startCell, targetCell);
    }

    void MoveOnPath()
    {
        if (path != null && path.Count > 0)
        {
            Vector3 targetPosition = tilemap.GetCellCenterWorld(tilemap.WorldToCell(path[0]));
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;

            transform.Translate(movement);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                transform.position = targetPosition; // �߽ɿ� ��Ȯ�� ���߱�
                path.RemoveAt(0);
            }
        }
    }

    void HighlightTile(Vector3Int cell, Color color)
    {
        if (highlightedCell != null)
        {
            tilemap.SetTileFlags(highlightedCell, TileFlags.None);
            tilemap.SetColor(highlightedCell, originalColor); // ���⸦ ����
        }

        highlightedCell = cell;
        tilemap.SetTileFlags(highlightedCell, TileFlags.None);
        tilemap.SetColor(highlightedCell, color);
    }
}
