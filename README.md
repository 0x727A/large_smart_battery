# Large Smart Battery / 大容量智能电池

## 中文

这是一个《缺氧》(Oxygen Not Included) 模组，添加了一个更大容量的智能蓄电池。

### 功能

- 新增建筑：`大智能电池`
- 容量：100 kJ
- 电力损耗：6.7 J/s
- 产热：5 kDTU/s
- 材料：钢、塑料、玻璃
- 使用原版智能蓄电池动画，并通过运行时 tint 做外观区分
- 支持中文和英文游戏内建筑文本
- 不依赖 PLib

### 构建说明

项目文件位于：

```text
源代码/BCSmartBattery.csproj
```

该项目引用本机《缺氧》的 Managed 程序集。如果你的游戏安装路径不同，需要修改 `.csproj` 中的 `HintPath`。

仓库只跟踪源码和模组元数据。编译产物、临时文件和实验动画资源不会提交到仓库。

## English

This is an Oxygen Not Included mod that adds a higher-capacity smart battery.

### Features

- Adds a new building: `Large Smart Battery`
- Capacity: 100 kJ
- Power loss: 6.7 J/s
- Heat generation: 5 kDTU/s
- Materials: steel, plastic, glass
- Uses the original smart battery animation with a runtime tint for visual distinction
- Supports Chinese and English in-game building text
- Does not depend on PLib

### Build Notes

The project file is located at:

```text
源代码/BCSmartBattery.csproj
```

The project references local Oxygen Not Included managed assemblies. If your game is installed in a different location, update the `HintPath` entries in the `.csproj` file.

Only source code and mod metadata are tracked in this repository. Compiled DLLs, temporary files, and experimental animation resources are intentionally ignored.
