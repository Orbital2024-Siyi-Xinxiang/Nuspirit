using UnityEngine;

public static class SpriteUtility
{
    // Convert a Texture2D to a Sprite
    public static Sprite ConvertToSprite(Texture2D texture)
    {
        // Check if the texture is null
        if (texture == null)
        {
            Debug.LogError("Texture is null. Cannot convert to sprite.");
            return null;
        }

        // Create a new sprite using the texture
        Sprite sprite = Sprite.Create(
            texture,
            new Rect(0.0f, 0.0f, texture.width, texture.height),
            new Vector2(0.5f, 0.5f),
            100.0f // pixels per unit, adjust this value if needed
        );

        return sprite;
    }
}
