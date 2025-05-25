<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-16T14:58:24+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "ko"
}
-->
# 이 샘플 실행하기

이 샘플은 클라이언트에 LLM을 두는 것을 포함합니다. LLM이 작동하려면 Codespaces에서 실행하거나 GitHub에서 개인 액세스 토큰을 설정해야 합니다.

## -1- 의존성 설치하기

```bash
npm install
```

## -3- 서버 실행하기

```bash
npm run build
```

## -4- 클라이언트 실행하기

```sh
npm run client
```

다음과 유사한 결과가 나타납니다:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 양지해 주시기 바랍니다. 원문 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인한 오해나 잘못된 해석에 대해서는 책임을 지지 않습니다.