<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:30:50+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "zh"
}
-->
# 完整的 MCP 客户端示例

本目录包含用不同编程语言编写的完整且可运行的 MCP 客户端示例。每个客户端都展示了主 README.md 教程中描述的全部功能。

## 可用客户端

### 1. Java 客户端 (`client_example_java.java`)
- **传输方式**：基于 HTTP 的 SSE（服务器发送事件）
- **目标服务器**：`http://localhost:8080`
- **功能**：
  - 建立连接及心跳检测
  - 工具列表
  - 计算器操作（加、减、乘、除、帮助）
  - 错误处理及结果提取

**运行方式：**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# 客户端 (`client_example_csharp.cs`)
- **传输方式**：标准输入/输出（Stdio）
- **目标服务器**：通过 dotnet run 启动的本地 .NET MCP 服务器
- **功能**：
  - 通过 stdio 传输自动启动服务器
  - 工具和资源列表
  - 计算器操作
  - JSON 结果解析
  - 全面错误处理

**运行方式：**
```bash
dotnet run
```

### 3. TypeScript 客户端 (`client_example_typescript.ts`)
- **传输方式**：标准输入/输出（Stdio）
- **目标服务器**：本地 Node.js MCP 服务器
- **功能**：
  - 完整的 MCP 协议支持
  - 工具、资源和提示操作
  - 计算器操作
  - 资源读取和提示执行
  - 稳健的错误处理

**运行方式：**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python 客户端 (`client_example_python.py`)
- **传输方式**：标准输入/输出（Stdio）  
- **目标服务器**：本地 Python MCP 服务器
- **功能**：
  - 异步/await 模式操作
  - 工具和资源发现
  - 计算器操作测试
  - 资源内容读取
  - 基于类的组织结构

**运行方式：**
```bash
python client_example_python.py
```

## 所有客户端的共通功能

每个客户端实现都展示了：

1. **连接管理**
   - 建立与 MCP 服务器的连接
   - 处理连接错误
   - 适当的清理和资源管理

2. **服务器发现**
   - 列出可用工具
   - 列出可用资源（支持时）
   - 列出可用提示（支持时）

3. **工具调用**
   - 基础计算器操作（加、减、乘、除）
   - 服务器信息帮助命令
   - 正确传递参数和处理结果

4. **错误处理**
   - 连接错误
   - 工具执行错误
   - 优雅失败和用户反馈

5. **结果处理**
   - 从响应中提取文本内容
   - 格式化输出以便阅读
   - 处理不同的响应格式

## 先决条件

运行这些客户端之前，请确保：

1. **对应的 MCP 服务器正在运行**（来自 `../01-first-server/`）
2. **已安装所选语言所需的依赖**
3. **网络连接正常**（针对基于 HTTP 的传输）

## 各实现的主要差异

| 语言       | 传输方式 | 服务器启动方式 | 异步模型   | 关键库           |
|------------|----------|----------------|------------|------------------|
| Java       | SSE/HTTP | 外部启动       | 同步       | WebFlux, MCP SDK  |
| C#         | Stdio    | 自动启动       | Async/Await| .NET MCP SDK     |
| TypeScript | Stdio    | 自动启动       | Async/Await| Node MCP SDK     |
| Python     | Stdio    | 自动启动       | AsyncIO    | Python MCP SDK   |

## 后续步骤

浏览完这些客户端示例后：

1. **修改客户端**，添加新功能或操作
2. **创建自己的服务器**，并用这些客户端进行测试
3. **尝试不同的传输方式**（SSE 与 Stdio）
4. **构建更复杂的应用**，集成 MCP 功能

## 故障排除

### 常见问题

1. **连接被拒绝**：确认 MCP 服务器在预期端口/路径上运行
2. **模块未找到**：安装对应语言的 MCP SDK
3. **权限被拒绝**：检查 stdio 传输的文件权限
4. **工具未找到**：确认服务器实现了预期的工具

### 调试建议

1. **开启 MCP SDK 的详细日志**
2. **查看服务器日志中的错误信息**
3. **确认客户端和服务器的工具名称及签名一致**
4. **先用 MCP Inspector 测试服务器功能**

## 相关文档

- [主客户端教程](./README.md)
- [MCP 服务器示例](../../../../03-GettingStarted/01-first-server)
- [MCP 与 LLM 集成](../../../../03-GettingStarted/03-llm-client)
- [官方 MCP 文档](https://modelcontextprotocol.io/)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。