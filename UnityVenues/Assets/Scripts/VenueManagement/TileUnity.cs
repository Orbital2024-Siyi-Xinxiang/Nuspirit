using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public static class TileUtility
{
    public static TileBase[] ConvertTexturesToTiles(Texture2D[] textures)
    {
        List<TileBase> tiles = new List<TileBase>();
        foreach (var texture in textures)
        {
            var slicedSprites = SliceTexture(texture, 64, 64);
            foreach (var sprite in slicedSprites)
            {
                tiles.Add(SpriteToTile(sprite));
            }
        }
        return tiles.ToArray();
    }

    private static List<Sprite> SliceTexture(Texture2D texture, int sliceWidth, int sliceHeight)
    {
        Debug.Log("start adding sprites!");
        List<Sprite> sprites = new List<Sprite>();
        int textureWidth = texture.width;
        int textureHeight = texture.height;

        for (int y = 0; y < textureHeight; y += sliceHeight)
        {
            for (int x = 0; x < textureWidth; x += sliceWidth)
            {
                Debug.Log($"{x} , {y}  from {textureWidth}, {textureHeight}");

                Rect rect = new Rect(x, y, sliceWidth, sliceHeight);
                Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
                sprites.Add(sprite);
            }
        }
        return sprites;
    }

    private static TileBase SpriteToTile(Sprite sprite)
    {
        Tile tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = sprite;
        return tile;
    }
}
