# 从 SharpDX 迁移到 Vortice.Windows

## 为什么要迁移

SharpDX 4.2.0 仅提供 .NET Framework 程序集，且自 2019 年起已停止维护（归档状态），因此面向现代 .NET 版本的项目在使用它时需要通过兼容性垫片，并且会触发 NU1701 警告。【F:Client/Client.csproj†L40-L47】相比之下，[Vortice.Windows](https://www.nuget.org/packages/Vortice.Windows/) 处于积极维护状态，并发布针对当前 .NET 运行时构建的库。

## 包级别的变更

1. 从 `Client.csproj` 中移除 `SharpDX`、`SharpDX.Desktop`、`SharpDX.Direct3D9`、`SharpDX.DirectSound` 和 `SharpDX.Mathematics` 的包引用。
2. 添加以下 NuGet 包：
   - `Vortice.Windows`（包含 Direct3D9、DirectSound、DXGI 及通用数学类型）
   - `Vortice.Multimedia`（Wave 格式、XAudio 辅助工具）
   - 如需运行时编译着色器，还需添加 `Vortice.D3DCompiler`。
3. 移除与旧程序集相关的所有绑定重定向（binding redirects）和探测路径（probing paths）。

## 命名空间和类型更新

Vortice 的命名空间与 SharpDX 不同：大多数 Direct3D9 类位于 `Vortice.Direct3D9` 下，音频在 `Vortice.DirectSound` 中，数学辅助工具在 `Vortice.Mathematics` 中，Win32 支持在 `Vortice.Win32` 中。

主要类型替换如下：

| SharpDX 类型 | Vortice.Windows 替换类型 |
|--------------|--------------------------|
| `SharpDX.Direct3D9.Device` | `Vortice.Direct3D9.Device9` |
| `SharpDX.Direct3D9.PresentParameters` | `Vortice.Direct3D9.PresentParameters` |
| `SharpDX.Direct3D9.Sprite` | `Vortice.Direct3D9.Sprite` |
| `SharpDX.DirectSound.SecondarySoundBuffer` | `Vortice.DirectSound.SecondarySoundBuffer` |
| `SharpDX.Mathematics.Interop.RawColorBGRA` | `Vortice.Mathematics.Color4` / `ColorBGRA` |

`System.Numerics` 的向量类型仍然兼容，但构造函数通常需要将值显式转换为 Vortice 提供的 `Vector2F`/`Vector3F` 或 `ColorBGRA` 结构体。

## 渲染层调整

* **设备创建：** Vortice 通过静态方法 `D3D9.CreateDevice` 来创建设备，而非使用实例构造函数。你需要提供适配器（`Adapter` 枚举）、设备类型、窗口句柄、创建标志和 `PresentParameters`。设备重置（reset）的处理方式类似，但 `Reset` 方法返回一个 `Result` 结构体，应检查其中是否包含 `ResultCode.DeviceLost` 或 `ResultCode.DeviceNotReset`。
* **精灵与纹理：** `Sprite.Draw` 接受的参数与 SharpDX 相同——`ColorBGRA`、`Rect?`、`Vector3?`，但这些结构体来自 Vortice 的命名空间。需要替换辅助扩展方法，使其输出 `Vortice.Mathematics` 的结构体。
* **表面与锁定：** 诸如 `Surface.LockRectangle` 之类的方法会返回 `LockedRectangle`，其中包含一个 `DataStream`，但其所有权语义（ownership semantics）与 SharpDX 不同。需要将 SharpDX 特定的扩展方法替换为 Vortice 的等价方法（`ReadRange`、`WriteRange`）。

## 音频管线

SharpDX 的 DirectSound 缓冲区标志与 Vortice 的枚举直接对应。但是，缓冲区状态轮询依赖于 `SecondarySoundBuffer.Status` 返回的 `BufferStatus` 标志枚举，因此任何自定义的辅助包装类都需要相应更新。播放光标的访问通过 `SecondarySoundBuffer.CurrentPlayPosition` / `CurrentWritePosition` 属性实现。

如果项目已经通过 NAudio 来加载 WAV 文件，可以保留这些类型，仅需修改最终互操作层——即将原始 PCM 数据馈入 Vortice 的缓冲区（`SecondarySoundBuffer.Write`）。

## 输入与窗口循环

SharpDX 的 `RenderLoop.Run` 在 Vortice 中有对应的 `Vortice.Win32.MessagePump`。迁移时需确保：
- Win32 窗口句柄（`HWND`）正确传递给 `MessagePump.Run`
- 空闲处理函数使用新的设备类型调用渲染循环

## 测试注意事项

迁移到 Vortice 是一次大规模重构：
* 所有 SharpDX 命名空间的导入都需要替换。
* 颜色、矩形和向量的辅助扩展方法需要重写。
* DirectSound 包装类和缓冲区管理需要验证，以确保行为与 SharpDX 实现一致。
* 着色器编译、纹理加载、设备丢失/重置路径需要在 Windows 10/11 上进行回归测试，覆盖窗口模式和全屏模式。

预计渲染、音频和项目文件将涉及数百行代码的变更。由于 Vortice 的 API 虽然与 SharpDX 相似，但并非完全兼容的替代品，因此需要预留充足的时间进行完整构建和手动游戏测试。
