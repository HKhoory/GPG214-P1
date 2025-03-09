using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GPG214.Hamad
{
    public class TextureLoader : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private string textureFolder; 
        [SerializeField] private string textureName; //name of the sprite texture
        [SerializeField] private string folderPath;

        void Start()
        {

            _spriteRenderer.GetComponent<SpriteRenderer>();

            folderPath = Path.Combine(Application.streamingAssetsPath, textureFolder, textureName);

            LoadSprite();

        }



        private void LoadSprite()
        {
            if (File.Exists(folderPath))
            {
                byte[] imageBytes = File.ReadAllBytes(folderPath);

                Texture2D texture = new Texture2D(2, 2);

                texture.LoadImage(imageBytes);

                _spriteRenderer.GetComponent<Renderer>().material.mainTexture = texture;

                _spriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);


            }
            else
            {
                Debug.Log("Error: Texture file not found");
            }
        }

    }

}