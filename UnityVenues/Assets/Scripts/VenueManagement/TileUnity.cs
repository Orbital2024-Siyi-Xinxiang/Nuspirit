using UnityEngine;
using UnityEngine.Tilemaps;

public static class TileUtility
{
    public static TileBase[] ConvertTexturesToTiles(Texture2D[] textures)
    {
        TileBase[] tiles = new TileBase[textures.Length];
        for (int i = 0; i < textures.Length; i++)
        {
            tiles[i] = TextureToTile(textures[i]);
        }
        return tiles;
    }

    private static TileBase TextureToTile(Texture2D texture)
    {
        Tile tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        return tile;
    }
}
