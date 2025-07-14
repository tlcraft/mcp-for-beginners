<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:38:15+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "ko"
}
-->
# Study Plan Generator with Chainlit & Microsoft Learn Docs MCP

## 사전 준비 사항

- Python 3.8 이상
- pip (파이썬 패키지 관리자)
- Microsoft Learn Docs MCP 서버에 연결할 수 있는 인터넷 접속

## 설치 방법

1. 이 저장소를 클론하거나 프로젝트 파일을 다운로드하세요.
2. 필요한 의존성을 설치하세요:

   ```bash
   pip install -r requirements.txt
   ```

## 사용법

### 시나리오 1: Docs MCP에 간단한 쿼리 보내기
Docs MCP 서버에 연결해 쿼리를 전송하고 결과를 출력하는 커맨드라인 클라이언트입니다.

1. 스크립트를 실행하세요:
   ```bash
   python scenario1.py
   ```
2. 프롬프트에 문서 관련 질문을 입력하세요.

### 시나리오 2: 학습 계획 생성기 (Chainlit 웹 앱)
Chainlit을 사용한 웹 기반 인터페이스로, 사용자가 원하는 기술 주제에 대해 주차별 맞춤 학습 계획을 생성할 수 있습니다.

1. Chainlit 앱을 시작하세요:
   ```bash
   chainlit run scenario2.py
   ```
2. 터미널에 표시된 로컬 URL(예: http://localhost:8000)을 브라우저에서 열어주세요.
3. 채팅 창에 학습 주제와 학습 기간(예: "AI-900 certification, 8 weeks")을 입력하세요.
4. 앱이 주차별 학습 계획과 관련 Microsoft Learn 문서 링크를 응답합니다.

**필요한 환경 변수:**

시나리오 2(Chainlit 웹 앱과 Azure OpenAI)를 사용하려면 `python` 디렉터리 내 `.env` 파일에 다음 환경 변수를 설정해야 합니다:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

앱 실행 전에 Azure OpenAI 리소스 정보를 입력하세요.

> **Tip:** [Azure AI Foundry](https://ai.azure.com/)를 통해 손쉽게 자신만의 모델을 배포할 수 있습니다.

### 시나리오 3: VS Code 내에서 MCP 서버를 이용한 문서 조회

브라우저 탭을 전환하지 않고도 Microsoft Learn Docs를 VS Code 내에서 바로 확인할 수 있습니다. 이를 통해:
- 코딩 환경을 벗어나지 않고 VS Code 내에서 문서를 검색하고 읽을 수 있습니다.
- README나 강의 자료에 문서 참조 링크를 바로 삽입할 수 있습니다.
- GitHub Copilot과 MCP를 함께 사용해 AI 기반 문서 작업 흐름을 원활하게 할 수 있습니다.

**활용 예시:**
- 강의나 프로젝트 문서 작성 중 README에 참조 링크를 빠르게 추가하기
- Copilot으로 코드를 생성하고 MCP로 관련 문서를 즉시 찾아 인용하기
- 에디터 내에서 집중력을 유지하며 생산성 향상하기

> [!IMPORTANT]
> 작업 공간에 유효한 [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) 설정 파일이 있는지 확인하세요 (위치는 `.vscode/mcp.json`).

## 왜 시나리오 2에 Chainlit을 사용할까?

Chainlit은 대화형 웹 애플리케이션을 쉽게 만들 수 있는 최신 오픈소스 프레임워크입니다. Microsoft Learn Docs MCP 서버 같은 백엔드 서비스와 연결되는 채팅 기반 UI를 간단히 구현할 수 있습니다. 이 프로젝트는 Chainlit을 활용해 실시간으로 맞춤형 학습 계획을 생성하는 직관적이고 인터랙티브한 도구를 제공합니다. Chainlit을 사용하면 생산성과 학습 효과를 높이는 채팅형 도구를 빠르게 개발하고 배포할 수 있습니다.

## 이 앱의 기능

사용자가 주제와 기간만 입력하면 개인 맞춤형 학습 계획을 생성해 줍니다. 입력 내용을 분석해 Microsoft Learn Docs MCP 서버에서 관련 자료를 조회하고, 결과를 주차별로 체계적으로 정리합니다. 각 주차별 추천 내용은 채팅창에 표시되어 쉽게 따라가고 진행 상황을 확인할 수 있습니다. 최신의 관련 학습 자료를 항상 제공하는 것이 특징입니다.

## 샘플 쿼리

채팅창에 다음 쿼리를 입력해 앱의 반응을 확인해 보세요:

- `AI-900 certification, 8 weeks`
- `Learn Azure Functions, 4 weeks`
- `Azure DevOps, 6 weeks`
- `Data engineering on Azure, 10 weeks`
- `Microsoft security fundamentals, 5 weeks`
- `Power Platform, 7 weeks`
- `Azure AI services, 12 weeks`
- `Cloud architecture, 9 weeks`

이 예시들은 다양한 학습 목표와 기간에 맞춘 앱의 유연성을 보여줍니다.

## 참고 자료

- [Chainlit Documentation](https://docs.chainlit.io/)
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의하시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.