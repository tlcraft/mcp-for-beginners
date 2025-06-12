<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:20:51+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "zh"
}
-->
# Calculator LLM Client

这是一个 Java 应用程序，演示如何使用 LangChain4j 连接到集成了 GitHub Models 的 MCP（模型上下文协议）计算器服务。

## 前提条件

- Java 21 或更高版本
- Maven 3.6+（或使用附带的 Maven 包装器）
- 拥有访问 GitHub Models 权限的 GitHub 账号
- 在 `http://localhost:8080` 上运行的 MCP 计算器服务

## 获取 GitHub Token

该应用使用 GitHub Models，需要 GitHub 个人访问令牌。按照以下步骤获取令牌：

### 1. 访问 GitHub Models
1. 访问 [GitHub Models](https://github.com/marketplace/models)
2. 使用你的 GitHub 账号登录
3. 如果还未获得访问权限，请申请访问 GitHub Models

### 2. 创建个人访问令牌
1. 进入 [GitHub 设置 → 开发者设置 → 个人访问令牌 → 令牌（经典）](https://github.com/settings/tokens)
2. 点击“生成新令牌” → “生成新令牌（经典）”
3. 给令牌起个描述性名称（例如：“MCP Calculator Client”）
4. 根据需要设置过期时间
5. 选择以下权限范围：
   - `repo`（如果需要访问私有仓库）
   - `user:email`
6. 点击“生成令牌”
7. **重要**：请立即复制令牌，之后无法再次查看！

### 3. 设置环境变量

#### Windows（命令提示符）：
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows（PowerShell）：
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux：
```bash
export GITHUB_TOKEN=your_github_token_here
```

## 安装与设置

1. **克隆或进入项目目录**

2. **安装依赖**：
   ```cmd
   mvnw clean install
   ```
   或者如果你全局安装了 Maven：
   ```cmd
   mvn clean install
   ```

3. **设置环境变量**（参考上面“获取 GitHub Token”部分）

4. **启动 MCP 计算器服务**：
   确保你已经启动了第1章中的 MCP 计算器服务，地址为 `http://localhost:8080/sse`。客户端启动前该服务需先运行。

## 运行应用

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## 应用功能说明

该应用演示了与计算器服务的三种主要交互：

1. **加法**：计算 24.5 与 17.3 的和
2. **平方根**：计算 144 的平方根
3. **帮助**：显示可用的计算器功能

## 预期输出

成功运行时，你会看到类似如下的输出：

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## 故障排查

### 常见问题

1. **“GITHUB_TOKEN 环境变量未设置”**
   - 确认你已正确设置了 `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean`

### 调试

要启用调试日志，运行时添加以下 JVM 参数：
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## 配置

应用配置如下：
- 使用 GitHub Models，模型为 `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- 请求超时时间为 60 秒
- 启用请求/响应日志以便调试

## 依赖

本项目的主要依赖：
- **LangChain4j**：用于 AI 集成和工具管理
- **LangChain4j MCP**：支持模型上下文协议
- **LangChain4j GitHub Models**：集成 GitHub Models
- **Spring Boot**：应用框架和依赖注入

## 许可证

本项目采用 Apache License 2.0 许可，详情请参见 [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) 文件。

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。尽管我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。我们不对因使用本翻译而产生的任何误解或误释承担责任。