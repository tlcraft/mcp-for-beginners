<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-16T15:05:17+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "zh"
}
-->
# 基础计算器 MCP 服务

该服务通过模型上下文协议（MCP）提供基础计算器操作。它被设计为初学者学习 MCP 实现的简单示例。

更多信息请参见 [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## 功能

此计算器服务提供以下功能：

1. **基本算术运算**：
   - 两数相加
   - 一数减去另一数
   - 两数相乘
   - 一数除以另一数（包含除零检查）

## 使用 `stdio` 类型

## 配置

1. **配置 MCP 服务器**：
   - 在 VS Code 中打开你的工作区。
   - 在工作区文件夹中创建一个 `.vscode/mcp.json` 文件，用于配置 MCP 服务器。示例配置：
     ```json
     {
       "servers": {
         "MyCalculator": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
                "run",
                "--project",
                "D:\\source\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj"
            ],
           "env": {}
         }
       }
     }
     ```
	- 将路径替换为你的项目路径。路径应为绝对路径，而非相对于工作区文件夹的相对路径。（示例：D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj）

## 使用该服务

该服务通过 MCP 协议暴露以下 API 端点：

- `add(a, b)`: Add two numbers together
- `subtract(a, b)`: Subtract the second number from the first
- `multiply(a, b)`: Multiply two numbers
- `divide(a, b)`: Divide the first number by the second (with zero check)
- isPrime(n): Check if a number is prime

## Test with Github Copilot Chat in VS Code

1. Try making a request to the service using the MCP protocol. For example, you can ask:
   - "Add 5 and 3"
   - "Subtract 10 from 4"
   - "Multiply 6 and 7"
   - "Divide 8 by 2"
   - "Does 37854 prime?"
   - "What are the 3 prime numbers before after 4242?"
2. To make sure it's using the tools add #MyCalculator to the prompt. For example:
   - "Add 5 and 3 #MyCalculator"
   - "Subtract 10 from 4 #MyCalculator


## Containerized Version

The previous soultion is great when you have the .NET SDK installed, and all the dependencies are in place. However, if you would like to share the solution or run it in a different environment, you can use the containerized version.

1. Start Docker and make sure it's running.
1. From a terminal, navigate in the folder `03-GettingStarted\samples\csharp\src` 
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>`，其中 `<YOUR-DOCKER-USERNAME>` 是你的 Docker Hub 用户名：
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. 镜像构建完成后，上传到 Docker Hub。运行以下命令：
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## 使用 Docker 版本

1. 在 `.vscode/mcp.json` 文件中，用以下内容替换服务器配置：
   ```json
    "mcp-calc": {
      "command": "docker",
      "args": [
        "run",
        "--rm",
        "-i",
        "<YOUR-DOCKER-USERNAME>/mcp-calc"
      ],
      "envFile": "",
      "env": {}
    }
   ```
   从配置中可以看到，命令是 `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above ``，和之前一样，你可以让计算器服务帮你做一些数学运算。

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。尽管我们努力确保准确性，但请注意自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。我们不对因使用本翻译而产生的任何误解或曲解承担责任。