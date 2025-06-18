<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:16:34+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "ko"
}
-->
# 이 샘플 실행하기

## -1- 의존성 설치하기

```bash
dotnet restore
```

## -2- 샘플 실행하기

```bash
dotnet run
```

## -3- 샘플 테스트하기

아래 명령어를 실행하기 전에 별도의 터미널을 열어 서버가 계속 실행 중인지 확인하세요.

한 터미널에서 서버가 실행 중일 때, 다른 터미널을 열고 다음 명령어를 실행하세요:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

이 명령어는 샘플을 테스트할 수 있는 시각적 인터페이스가 포함된 웹 서버를 시작합니다.

> **Streamable HTTP**가 전송 유형으로 선택되어 있고, URL이 `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`이며, 인수로 2와 4를 입력하면 결과에 6이 표시되어야 합니다.
- resources와 resource template로 이동하여 "greeting"을 호출한 후 이름을 입력하면, 입력한 이름이 포함된 인사말을 볼 수 있습니다.

### CLI 모드에서 테스트하기

다음 명령어를 실행하면 CLI 모드로 직접 실행할 수 있습니다:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

이 명령어는 서버에서 사용할 수 있는 모든 도구를 나열합니다. 다음과 같은 출력이 보여야 합니다:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

도구를 호출하려면 다음을 입력하세요:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

다음과 같은 출력이 보여야 합니다:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> 일반적으로 브라우저보다 CLI 모드에서 ispector를 실행하는 것이 훨씬 빠릅니다.
> ispector에 대해 더 자세히 알고 싶다면 [여기](https://github.com/modelcontextprotocol/inspector)를 참고하세요.

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확한 내용이 포함될 수 있음을 유의하시기 바랍니다. 원본 문서의 원어가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인한 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.