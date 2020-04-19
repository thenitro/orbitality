using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DynamicPlanetTextureController : MonoBehaviour
{
    [Header("Perlin Noise Parameters")]
    [SerializeField] private int _textureWidth = 128;
    [SerializeField] private int _textureHeight = 128;

    [SerializeField] private float _scale = 1.0f;

    [SerializeField] private float _minStartX = 0f;
    [SerializeField] private float _maxStartX = 100f;
    [SerializeField] private float _minStartY = 0f;
    [SerializeField] private float _maxStartY = 100f;
    
    [Header("Planet Color Parameters")]
    [SerializeField] private Color _deep = Color.black;
    [SerializeField] private Color _surface = Color.black;
    [SerializeField] private Color _surface2 = Color.black;
    [SerializeField] private Color _top = Color.black;

    private Texture2D _noiseTexture;
    private Color[] _pixels;
    private Renderer _renderer;

    private void Start()
    {
        if (IsBlack(_deep))
        {
            _deep = Color.HSVToRGB(GoldenRatio(), 0.7f, 0.95f);
        }
        
        if (IsBlack(_surface))
        {
            _surface = Color.HSVToRGB(GoldenRatio(), 0.7f, 0.95f);
        }
        
        if (IsBlack(_surface2))
        {
            _surface2 = Color.HSVToRGB(GoldenRatio(), 0.7f, 0.95f);
        }
        
        if (IsBlack(_top))
        {
            _top = Color.HSVToRGB(GoldenRatio(), 0.7f, 0.95f);
        }

        _renderer = GetComponent<Renderer>();

        _noiseTexture = new Texture2D(_textureWidth, _textureHeight);
        _pixels = new Color[_textureWidth * _textureHeight];

        var startX = Random.Range(_minStartX, _maxStartX);
        var startY = Random.Range(_minStartY, _maxStartY);

        for (var x = 0; x < _textureWidth / 2; x++)
        {
            for (var y = 0; y < _textureHeight; y++)
            {
                var xCoord = startX + (float) x / _textureWidth * _scale;
                var yCoord = startY + (float) y / _textureHeight * _scale;
                
                var sample = Mathf.PerlinNoise(xCoord, yCoord);
                
                SetTexturePoint(sample, x, y);
            }
        }
        
        for (var x = _textureWidth / 2; x > 0; x--)
        {
            for (var y = 0; y < _textureHeight; y++)
            {
                var xCoord = startX + (float) x / _textureWidth * _scale;
                var yCoord = startY + (float) y / _textureHeight * _scale;
                
                var sample = Mathf.PerlinNoise(xCoord, yCoord);
                
                SetTexturePoint(sample, _textureWidth / 2 + _textureWidth / 2 - x, y);
            }
        }

        _noiseTexture.SetPixels(_pixels);
        _noiseTexture.Apply();

        _renderer.material.mainTexture = _noiseTexture;
    }

    private void SetTexturePoint(float sample, int x, int y)
    {        
        _pixels[y * _textureHeight + x] = GetTexturePointColor(sample);
    }

    private Color GetTexturePointColor(float sample)
    {
        if (sample < 0.25f)
        {
            return _deep;
        }
        
        if (sample < 0.5f)
        {
            return _surface;
        }
        
        if (sample < 0.75f)
        {
            return _surface2;
        }
        
        return  _top;
    }
    
    private static float GoldenRatio() 
    {
        var results = Random.Range(0f, 1f);
            results += 0.618033988749895f;
            results %= 1;

        return results;
    }

    private bool IsBlack(Color color)
    {
        return color.r == 0 && color.g == 0 && color.b == 0;
    }
}