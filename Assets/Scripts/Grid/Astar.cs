using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class AStar
{
    public static List<Vector3> FindPath(Tilemap tilemap, Vector3Int startCell, Vector3Int targetCell)
    {
        List<Vector3> path = new List<Vector3>();
        HashSet<Vector3Int> openSet = new HashSet<Vector3Int>();
        HashSet<Vector3Int> closedSet = new HashSet<Vector3Int>();
        Dictionary<Vector3Int, Vector3Int> cameFrom = new Dictionary<Vector3Int, Vector3Int>();
        Dictionary<Vector3Int, float> gScore = new Dictionary<Vector3Int, float>();
        Dictionary<Vector3Int, float> fScore = new Dictionary<Vector3Int, float>();

        openSet.Add(startCell);
        gScore[startCell] = 0;
        fScore[startCell] = Vector3.Distance(startCell, targetCell);

        while (openSet.Count > 0)
        {
            Vector3Int currentCell = GetLowestFScore(openSet, fScore);
            openSet.Remove(currentCell);

            if (currentCell == targetCell)
            {
                path = ReconstructPath(cameFrom, currentCell);
                break;
            }

            closedSet.Add(currentCell);

            foreach (Vector3Int neighbor in GetNeighbors(tilemap, currentCell))
            {
                if (closedSet.Contains(neighbor) || !IsTileWalkable(tilemap, neighbor))
                    continue;

                float tentativeGScore = gScore[currentCell] + Vector3.Distance(currentCell, neighbor);

                if (!openSet.Contains(neighbor) || tentativeGScore < gScore[neighbor])
                {
                    cameFrom[neighbor] = currentCell;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + Vector3.Distance(neighbor, targetCell);

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        return path;
    }

    static Vector3Int GetLowestFScore(HashSet<Vector3Int> openSet, Dictionary<Vector3Int, float> fScore)
    {
        float lowestFScore = float.MaxValue;
        Vector3Int lowestCell = Vector3Int.zero;

        foreach (Vector3Int cell in openSet)
        {
            if (fScore.ContainsKey(cell) && fScore[cell] < lowestFScore)
            {
                lowestFScore = fScore[cell];
                lowestCell = cell;
            }
        }

        return lowestCell;
    }

    static List<Vector3Int> GetNeighbors(Tilemap tilemap, Vector3Int cell)
    {
        List<Vector3Int> neighbors = new List<Vector3Int>();

        Vector3Int[] directions =
        {
            new Vector3Int(0, 1, 0),
            new Vector3Int(0, -1, 0),
            new Vector3Int(1, 0, 0),
            new Vector3Int(-1, 0, 0),
        };

        foreach (Vector3Int direction in directions)
        {
            Vector3Int neighbor = cell + direction;

            if (IsTileWithinBounds(tilemap, neighbor))
            {
                neighbors.Add(neighbor);
            }
        }

        return neighbors;
    }

    static bool IsTileWithinBounds(Tilemap tilemap, Vector3Int cell)
    {
        BoundsInt bounds = tilemap.cellBounds;
        return bounds.Contains(cell);
    }

    static bool IsTileWalkable(Tilemap tilemap, Vector3Int cell)
    {
        TileBase tile = tilemap.GetTile(cell);
        return tile != null;
    }

    static List<Vector3> ReconstructPath(Dictionary<Vector3Int, Vector3Int> cameFrom, Vector3Int current)
    {
        List<Vector3> path = new List<Vector3>();

        while (cameFrom.ContainsKey(current))
        {
            path.Add(current);
            current = cameFrom[current];
        }

        path.Reverse();
        return path;
    }
}
