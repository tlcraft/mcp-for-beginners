<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:52:27+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "ko"
}
-->
# 기본 계산기 MCP 서비스

이 서비스는 Model Context Protocol(MCP)을 통해 기본 계산기 연산을 제공합니다. MCP 구현을 처음 배우는 초보자들을 위한 간단한 예제로 설계되었습니다.

자세한 내용은 [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)를 참조하세요.

## 기능

이 계산기 서비스는 다음과 같은 기능을 제공합니다:

1. **기본 산술 연산**:
   - 두 숫자의 덧셈
   - 한 숫자에서 다른 숫자를 뺌
   - 두 숫자의 곱셈
   - 한 숫자를 다른 숫자로 나눔 (0으로 나누기 체크 포함)

## `stdio` 타입 사용하기

## 설정

1. **MCP 서버 구성**:
   - VS Code에서 작업 공간을 엽니다.
   - 작업 공간 폴더에 `.vscode/mcp.json` 파일을 만들어 MCP 서버를 구성합니다. 예시 구성:

     ```jsonc
     {
       "inputs": [
         {
           "type": "promptString",
           "id": "repository-root",
           "description": "The absolute path to the repository root"
         }
       ],
       "servers": {
         "calculator-mcp-dotnet": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
             "run",
             "--project",
             "${input:repository-root}/03-GettingStarted/samples/csharp/src/calculator.csproj"
           ]
         }
       }
     }
     ```

   - GitHub 저장소 루트를 입력하라는 메시지가 나타나며, `git rev-parse --show-toplevel` 명령어로 확인할 수 있습니다. Docker Hub 사용자 이름을 포함하여 다음과 같이 입력하세요:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ```  
1. 이미지가 빌드된 후에는 Docker Hub에 업로드합니다. 다음 명령어를 실행하세요:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## 도커 버전 사용하기

1. `.vscode/mcp.json` 파일에서 서버 구성을 다음과 같이 변경하세요:
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
   설정을 보면 명령어가 `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`로 되어 있으며, 이전과 마찬가지로 계산기 서비스에 수학 연산을 요청할 수 있습니다.

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확한 내용이 포함될 수 있음을 유의하시기 바랍니다. 원본 문서의 원어 버전을 권위 있는 자료로 간주해야 합니다. 중요한 정보의 경우 전문 인간 번역을 권장합니다. 본 번역의 사용으로 인해 발생하는 오해나 잘못된 해석에 대해서는 책임을 지지 않습니다.