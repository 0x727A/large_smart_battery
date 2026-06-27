# Large Smart Battery / 大容量智能电池

## 中文

这是一个《缺氧》(Oxygen Not Included) 模组，添加了一个更大容量的智能蓄电池。

### 功能

- 新增建筑：大容量智能电池
- 容量：100 kJ
- 支持模组设置中的成本模式选择
- 默认模式：标准成本
  - 1200kg 钢
  - 150kg 塑料
  - 150kg 玻璃
  - 10J/s 漏电
  - 7.5kDTU/s 发热
- 可选模式：轻量成本
  - 800kg 钢
  - 100kg 塑料
  - 100kg 玻璃
  - 6.7J/s 漏电
  - 5kDTU/s 发热
- 使用原版智能蓄电池动画，并通过运行时 tint 做外观区分
- 支持中文和英文游戏内建筑文本
- 内置 PLib 4.25，用于模组设置界面

### 构建说明

项目文件位于：

```text
源代码/BCSmartBattery.csproj
```

该项目引用本机《缺氧》的 Managed 程序集。如果你的游戏安装路径不同，需要修改 `.csproj` 中的 `HintPath`。

仓库跟踪源码、模组元数据和用于设置界面的 `源代码/lib/PLib.dll`。编译产物、临时文件和实验动画资源不会提交到仓库。

## English

This is an Oxygen Not Included mod that adds a higher-capacity smart battery.

### Features

- Adds a new building: Large Smart Battery
- Capacity: 100 kJ
- Supports a configurable cost preset in the mod options
- Default mode: Standard Cost
  - 1200 kg Steel
  - 150 kg Plastic
  - 150 kg Glass
  - 10 J/s power loss
  - 7.5 kDTU/s heat generation
- Optional mode: Light Cost
  - 800 kg Steel
  - 100 kg Plastic
  - 100 kg Glass
  - 6.7 J/s power loss
  - 5 kDTU/s heat generation
- Uses the original smart battery animation with a runtime tint for visual distinction
- Supports Chinese and English in-game building text
- Bundles PLib 4.25 for the mod options UI

### Build Notes

The project file is located at:

```text
源代码/BCSmartBattery.csproj
```

The project references local Oxygen Not Included managed assemblies. If your game is installed in a different location, update the `HintPath` entries in the `.csproj` file.

Source code, mod metadata, and `源代码/lib/PLib.dll` for the options UI are tracked in this repository. Compiled DLLs, temporary files, and experimental animation resources are intentionally ignored.
