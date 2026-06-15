using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Client.Rendering
{
    /// <summary>
    /// 渲染管线接口
    /// 定义了游戏渲染层的所有抽象操作，支持多种实现（DX9、DX11）
    /// 包括：设备初始化、帧渲染、全屏切换、分辨率设置、纹理绘制、
    /// 透明度/混合模式、文本测量、DPI 获取等功能
    /// </summary>
    public interface IRenderingPipeline
    {
        /// <summary>管线唯一标识符</summary>
        string Id { get; }

        void Initialize(RenderingPipelineContext context);

        void RunMessageLoop(Form form, Action loop);

        bool RenderFrame(Action drawScene);

        void ToggleFullScreen();

        void SetResolution(Size size);

        void SetTargetMonitor(int monitorIndex);

        void CenterOnSelectedMonitor();

        void ResetDevice();

        void OnSceneChanged(bool isGameScene);

        IReadOnlyList<Size> GetSupportedResolutions();

        Size MeasureText(string text, Font font);

        Size MeasureText(string text, Font font, Size proposedSize, TextFormatFlags format);

        float GetHorizontalDpi();

        void ConfigureGraphics(Graphics graphics);

        Color ConvertHslToRgb(float h, float s, float l);

        void SetOpacity(float opacity);

        float GetOpacity();

        void SetBlend(bool enabled, float rate, BlendMode mode);

        bool IsBlending();

        float GetBlendRate();

        BlendMode GetBlendMode();

        float GetLineWidth();

        void SetLineWidth(float width);

        void DrawLine(IReadOnlyList<LinePoint> points, Color colour);

        void DrawTexture(RenderTexture texture, Rectangle sourceRectangle, RectangleF destinationRectangle, Color colour);

        void DrawTexture(RenderTexture texture, Rectangle? sourceRectangle, Matrix3x2 transform, Vector3 center, Vector3 translation, Color colour);

        RenderSurface GetCurrentSurface();

        void SetSurface(RenderSurface surface);

        RenderSurface GetScratchSurface();

        RenderTexture GetScratchTexture();

        void ColorFill(RenderSurface surface, Rectangle rectangle, Color color);

        RenderTargetResource CreateRenderTarget(Size size);

        void ReleaseRenderTarget(RenderTargetResource renderTarget);

        Size GetBackBufferSize();

        void Clear(RenderClearFlags flags, Color colour, float z, int stencil, params Rectangle[] regions);

        void FlushSprite();

        void RegisterControlCache(ITextureCacheItem control);

        void UnregisterControlCache(ITextureCacheItem control);

        RenderTexture CreateTexture(Size size, RenderTextureFormat format, RenderTextureUsage usage, RenderTexturePool pool);

        void ReleaseTexture(RenderTexture texture);

        TextureLock LockTexture(RenderTexture texture, TextureLockMode mode);

        void RegisterTextureCache(ITextureCacheItem texture);

        void UnregisterTextureCache(ITextureCacheItem texture);

        void RegisterSoundCache(ISoundCacheItem sound);

        void UnregisterSoundCache(ISoundCacheItem sound);

        void MemoryClear();

        IReadOnlyList<ISoundCacheItem> GetRegisteredSoundCaches();

        RenderTexture GetColourPaletteTexture();

        byte[] GetColourPaletteData();

        RenderTexture GetLightTexture();

        Size GetLightTextureSize();

        RenderTexture GetPoisonTexture();

        Size GetPoisonTextureSize();

        TextureFilterMode GetTextureFilter();

        void SetTextureFilter(TextureFilterMode mode);

        void Shutdown();
    }
}
