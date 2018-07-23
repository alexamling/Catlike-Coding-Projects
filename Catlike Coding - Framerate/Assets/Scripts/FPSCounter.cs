using UnityEngine;

public class FPSCounter : MonoBehaviour {

    public int frameRange = 60;

    public int AverageFPS { get; private set; }
    public int MinFPS { get; private set; }
    public int MaxFPS { get; private set; }

    int[] fpsBuffer;
    int fpsBufferIndex;

    void Update() {
        if (fpsBuffer == null || fpsBuffer.Length != frameRange)
        {
            InitializeBuffer();
        }
        UpdateBuffer();
        CalculateFPS();
    }

    void InitializeBuffer()
    {
        if (frameRange <= 0)
        {
            frameRange = 1;
        }
        fpsBuffer = new int[frameRange];
        fpsBufferIndex = 0;
    }

    void UpdateBuffer()
    {
        fpsBuffer[fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
        if (fpsBufferIndex >= frameRange)
        {
            fpsBufferIndex = 0;
        }
    }

    void CalculateFPS()
    {
        int sum = 0;
        int min = int.MaxValue;
        int max = 0;
        for(int i = 0; i < frameRange; i++)
        {
            int fps = fpsBuffer[i];
            sum += fps;
            if (fps > max)
            {
                max = fps;
            }
            if (fps < min)
            {
                min = fps;
            }
            AverageFPS = sum / frameRange;
            MaxFPS = max;
            MinFPS = min;
        }
    }
}
