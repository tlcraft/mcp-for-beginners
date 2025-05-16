<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-16T15:11:29+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ko"
}
-->
# 샘플 실행하기

## -1- 의존성 설치

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- 샘플 실행

```bash
dotnet run
```

## -4- 샘플 테스트

한 터미널에서 서버가 실행 중일 때, 다른 터미널을 열어 다음 명령어를 실행하세요:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

이 명령어는 샘플을 테스트할 수 있는 시각적 인터페이스가 포함된 웹 서버를 시작합니다.

서버가 연결되면:

- 도구 목록을 확인하고 `add`를 실행해 보세요. 인수로 2와 4를 넣으면 결과로 6이 보여야 합니다.
- resources와 resource template로 이동해 "greeting"을 호출한 후 이름을 입력하면, 입력한 이름을 포함한 인사말이 표시됩니다.

### CLI 모드에서 테스트하기

다음 명령어를 실행하면 바로 CLI 모드로 실행할 수 있습니다:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

서버에서 사용 가능한 모든 도구 목록이 출력됩니다. 다음과 같은 결과를 볼 수 있습니다:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

도구를 호출하려면 다음과 같이 입력하세요:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

다음과 같은 출력이 나타납니다:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> 브라우저보다 CLI 모드에서 inspector를 실행하는 것이 보통 훨씬 빠릅니다.
> inspector에 대해 더 자세히 알고 싶다면 [여기](https://github.com/modelcontextprotocol/inspector)를 참고하세요.

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있음을 유의하시기 바랍니다. 원본 문서는 해당 언어의 원문이 권위 있는 자료로 간주되어야 합니다. 중요한 정보의 경우, 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.