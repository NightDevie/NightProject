using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class Outline : MonoBehaviour
{
	public Color32 outlineColor;
	public bool includeCorners = false;

	[Range(0, 255)]
	public byte alphaCutoff;

	Color32 curOutlineColor = new Color32();

	SpriteRenderer rend;
	public SpriteRenderer rendererToOutline;
	Texture2D originalTexture;

	public bool active;
	public bool flag = true;

	float savedPixelsPerUnit = 32;
	bool textureExists = false;

	int currentWidth = 16;
	int currentHeight = 16;
	

	void Awake()
	{
		rend = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		if (flag && active && rendererToOutline && rendererToOutline.sprite)
		{
			originalTexture = GetTextureFromSprite(rendererToOutline.sprite, rendererToOutline.sprite.texture);
			textureExists = true;
			flag = false;
		}
		else if (flag)
		{
			textureExists = false;
			ClearOutline();
			flag = false;
		}

		if(textureExists) GenerateOutline();
	}

	Texture2D GetTextureFromSprite(Sprite sprite, Texture2D original)
	{
		int spriteX = (int)sprite.rect.x;
		int spriteY = (int)sprite.rect.y;
		int w = (int)sprite.rect.width;
		int h = (int)sprite.rect.height;

		int texWidth = original.width;
		int texHeight = original.height;

		Texture2D newTex = new Texture2D(w + 2, h + 2);
		newTex.filterMode = FilterMode.Point;

		for (int x = 0; x < w + 2; x++)
			for (int y = 0; y < h + 2; y++)
				newTex.SetPixel(x, y, new Color(0, 0, 0, 0));

		for(int x = 0; x < texWidth; x++)
		{
			for(int y = 0; y < texHeight; y++)
			{
				if(x >= spriteX && x < spriteX + w && y >= spriteY && y < spriteY + h)
				{
					int sprX = x - spriteX;
					int sprY = y - spriteY;
					newTex.SetPixel(sprX + 2, sprY + 2, original.GetPixel(x, y));
				}
			}
		}
		newTex.Apply();

		return newTex;
	}

	void ClearOutline()
	{
		int w = currentWidth;
		int h = currentHeight;

		Texture2D t = new Texture2D(w, h)
		{
			filterMode = FilterMode.Point
		};

		for (int x = 0; x < w; x++)
			for (int y = 0; y < h; y++)
				t.SetPixel(x, y, new Color(0, 0, 0, 0));

		t.Apply();

		Sprite empty = Sprite.Create(t, new Rect(0, 0, w, h), Vector2.one / 2, savedPixelsPerUnit);
		rend.sprite = empty;
	}

	void GenerateOutline()
	{
		if (!rendererToOutline)
			return;

		if (rendererToOutline == rend)
		{
			Debug.Log("Variable \"Renderer To Outline\" cannot be set to the SpriteRenderer component attatched to the same GameObject! (Be sure the outline is a seperate sprite, attached as a child of the sprite you want to outline.)");
			return;
		}

		int w = originalTexture.width;
		int h = originalTexture.height;
		currentWidth = w;
		currentHeight = h;

		if (!originalTexture.isReadable)
		{
			ClearOutline();
			Debug.Log("The texture \"" + originalTexture.name + "\" attatched to the sprite you are trying to outline is not readable! (Set \"Read/Write enabled\" to true in the sprite's import settings.)");
			return;
		}

		curOutlineColor = outlineColor;

		Texture2D texture = new Texture2D(w + 2, h + 2)
		{
			filterMode = FilterMode.Point
		};

		for (int x = 0; x < w + 2; x++)
			for (int y = 0; y < h + 2; y++)
				texture.SetPixel(x, y, new Color(0, 0, 0, 0));

		for (int x = 0; x < w + 2; x++)
		{
			for (int y = 0; y < h + 2; y++)
			{
				Color32 color = originalTexture.GetPixel(x, y);
				Color32 up = originalTexture.GetPixel(x, y + 1);
				Color32 down = originalTexture.GetPixel(x, y - 1);
				Color32 right = originalTexture.GetPixel(x + 1, y);
				Color32 left = originalTexture.GetPixel(x - 1, y);
				Color32 topRight = originalTexture.GetPixel(x + 1, y + 1);
				Color32 topLeft = originalTexture.GetPixel(x - 1, y + 1);
				Color32 bottomRight = originalTexture.GetPixel(x + 1, y - 1);
				Color32 bottomLeft = originalTexture.GetPixel(x - 1, y - 1);

				int numNeighbors = 0;

				if (up.a > alphaCutoff - 1) numNeighbors++;
				if (down.a > alphaCutoff - 1) numNeighbors++;
				if (right.a > alphaCutoff - 1) numNeighbors++;
				if (left.a > alphaCutoff - 1) numNeighbors++;

				if (!includeCorners)
				{
					if (color.a < alphaCutoff && numNeighbors > 0)
						texture.SetPixel(x, y, outlineColor);
				}
				else
				{
					if (topRight.a > alphaCutoff - 1) numNeighbors++;
					if (topLeft.a > alphaCutoff - 1) numNeighbors++;
					if (bottomRight.a > alphaCutoff - 1) numNeighbors++;
					if (bottomLeft.a > alphaCutoff - 1) numNeighbors++;

					if (color.a < alphaCutoff && numNeighbors > 0)
						texture.SetPixel(x, y, outlineColor);
				}
				if (x == 0 || y == 0 || x == w + 1 || y == h + 1)
				{
					texture.SetPixel(x, y, new Color(0, 0, 0, 0));
				}
			}
		}
		texture.Apply();
		Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, w + 2, h + 2), Vector2.one / 2, rendererToOutline.sprite.pixelsPerUnit);
		rend.sprite = newSprite;
		savedPixelsPerUnit = newSprite.pixelsPerUnit;
	}
}