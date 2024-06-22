using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public static class TileUtility
{
    public static int gridSize = 100;

    public static TileBase[] ConvertTextureToTiles(Texture2D texture)
    {
        List<TileBase> tiles = new List<TileBase>();
        if (texture != null)
        {
            tiles = SliceTexture(texture, gridSize, gridSize);
        }

        return tiles.ToArray();
    }

    private static List<TileBase> SliceTexture(Texture2D texture, int sliceWidth, int sliceHeight)
    {
        int textureWidth = texture.width;
        int textureHeight = texture.height;
        List<TileBase> tiles = new List<TileBase>();

        for (int y = 0; y <= textureHeight - sliceHeight; y += sliceHeight) // Start from the top
        {
            for (int x = 0; x <= textureWidth - sliceWidth; x += sliceWidth)
            {
                Rect rect = new Rect(x, y, sliceWidth, sliceHeight);
                Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
                tiles.Add(SpriteToTile(sprite));
            }
        }

        return tiles;
    }

    private static TileBase SpriteToTile(Sprite sprite)
    {
        Tile tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = sprite;
        return tile;
    }
}
