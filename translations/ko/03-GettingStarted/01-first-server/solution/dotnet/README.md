<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T05:52:43+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ko"
}
-->
# 이 샘플 실행하기

## -1- 의존성 설치하기

```bash
dotnet restore
```

## -3- 샘플 실행하기

```bash
dotnet run
```

## -4- 샘플 테스트하기

한 터미널에서 서버가 실행 중일 때, 다른 터미널을 열고 다음 명령어를 실행하세요:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

이 명령어는 샘플을 테스트할 수 있는 시각적 인터페이스가 포함된 웹 서버를 시작할 것입니다.

서버가 연결되면:

- 도구 목록을 확인하고 `add`를 인수 2와 4와 함께 실행해 보세요. 결과로 6이 보여야 합니다.
- 리소스와 리소스 템플릿으로 이동해 "greeting"을 호출한 후 이름을 입력하면, 입력한 이름이 포함된 인사말을 볼 수 있습니다.

### CLI 모드에서 테스트하기

다음 명령어를 실행하면 바로 CLI 모드로 실행할 수 있습니다:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

이 명령어는 서버에서 사용 가능한 모든 도구를 나열합니다. 다음과 같은 출력이 보여야 합니다:

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
> 보통 브라우저보다 CLI 모드에서 inspector를 실행하는 것이 훨씬 빠릅니다.
> inspector에 대해 더 알아보려면 [여기](https://github.com/modelcontextprotocol/inspector)를 참고하세요.

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있음을 유의하시기 바랍니다. 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.