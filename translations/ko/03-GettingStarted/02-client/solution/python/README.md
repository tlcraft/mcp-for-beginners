<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-16T15:27:49+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "ko"
}
-->
# 이 샘플 실행하기

`uv` 설치를 권장하지만 필수는 아닙니다. 자세한 내용은 [instructions](https://docs.astral.sh/uv/#highlights)를 참고하세요.

## -0- 가상 환경 생성하기

```bash
python -m venv venv
```

## -1- 가상 환경 활성화하기

```bash
venv\Scrips\activate
```

## -2- 의존성 설치하기

```bash
pip install "mcp[cli]"
```

## -3- 샘플 실행하기

```bash
python client.py
```

다음과 비슷한 출력 결과가 보여야 합니다:

```text
LISTING RESOURCES
Resource:  ('meta', None)
Resource:  ('nextCursor', None)
Resource:  ('resources', [])
                    INFO     Processing request of type ListToolsRequest                                                                               server.py:534
LISTING TOOLS
Tool:  add
READING RESOURCE
                    INFO     Processing request of type ReadResourceRequest                                                                            server.py:534
CALL TOOL
                    INFO     Processing request of type CallToolRequest                                                                                server.py:534
[TextContent(type='text', text='8', annotations=None)]
```

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있음을 유의하시기 바랍니다. 원문 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 이 번역 사용으로 인한 오해나 잘못된 해석에 대해서는 당사가 책임지지 않습니다.