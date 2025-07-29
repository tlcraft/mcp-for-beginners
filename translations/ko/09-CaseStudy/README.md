<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-07-29T00:30:55+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "ko"
}
-->
# MCP 실전: 실제 사례 연구

[![MCP 실전: 실제 사례 연구](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.ko.png)](https://youtu.be/IxshWb2Az5w)

_(위 이미지를 클릭하면 이 강의의 동영상을 볼 수 있습니다)_

모델 컨텍스트 프로토콜(MCP)은 AI 애플리케이션이 데이터, 도구, 서비스와 상호작용하는 방식을 혁신하고 있습니다. 이 섹션에서는 다양한 기업 환경에서 MCP의 실질적인 활용 사례를 보여주는 실제 사례 연구를 제공합니다.

## 개요

이 섹션에서는 MCP 구현의 구체적인 사례를 소개하며, 조직들이 이 프로토콜을 활용해 복잡한 비즈니스 문제를 해결하는 방법을 강조합니다. 이러한 사례 연구를 통해 MCP의 다양성, 확장성, 실질적인 이점을 실제 환경에서 이해할 수 있습니다.

## 주요 학습 목표

이 사례 연구를 통해 다음을 배울 수 있습니다:

- MCP를 활용하여 특정 비즈니스 문제를 해결하는 방법 이해
- 다양한 통합 패턴 및 아키텍처 접근 방식 학습
- 기업 환경에서 MCP를 구현하기 위한 모범 사례 인식
- 실제 구현에서 직면한 문제와 해결책에 대한 통찰력 얻기
- 자신의 프로젝트에 유사한 패턴을 적용할 수 있는 기회 식별

## 주요 사례 연구

### 1. [Azure AI 여행 에이전트 – 참조 구현](./travelagentsample.md)

이 사례 연구는 MCP, Azure OpenAI, Azure AI Search를 사용하여 다중 에이전트 기반의 AI 여행 계획 애플리케이션을 구축하는 방법을 보여주는 Microsoft의 포괄적인 참조 솔루션을 다룹니다. 프로젝트는 다음을 보여줍니다:

- MCP를 통한 다중 에이전트 오케스트레이션
- Azure AI Search를 활용한 기업 데이터 통합
- Azure 서비스를 사용한 안전하고 확장 가능한 아키텍처
- 재사용 가능한 MCP 구성 요소를 활용한 확장 가능한 도구
- Azure OpenAI로 구동되는 대화형 사용자 경험

아키텍처와 구현 세부 사항은 MCP를 조정 계층으로 사용하여 복잡한 다중 에이전트 시스템을 구축하는 데 유용한 통찰력을 제공합니다.

### 2. [YouTube 데이터로 Azure DevOps 항목 업데이트](./UpdateADOItemsFromYT.md)

이 사례 연구는 MCP를 활용한 워크플로 자동화의 실질적인 응용을 보여줍니다. MCP 도구를 사용하여 다음을 수행하는 방법을 설명합니다:

- 온라인 플랫폼(YouTube)에서 데이터 추출
- Azure DevOps 시스템의 작업 항목 업데이트
- 반복 가능한 자동화 워크플로 생성
- 서로 다른 시스템 간 데이터 통합

이 예시는 비교적 간단한 MCP 구현이 일상적인 작업을 자동화하고 시스템 간 데이터 일관성을 개선하여 상당한 효율성을 제공할 수 있음을 보여줍니다.

### 3. [MCP를 활용한 실시간 문서 검색](./docs-mcp/README.md)

이 사례 연구는 Python 콘솔 클라이언트를 MCP 서버에 연결하여 실시간으로 Microsoft 문서를 검색하고 기록하는 방법을 안내합니다. 다음을 배울 수 있습니다:

- 공식 MCP SDK를 사용하여 Python 클라이언트를 MCP 서버에 연결
- 효율적인 실시간 데이터 검색을 위한 스트리밍 HTTP 클라이언트 사용
- 서버의 문서 도구 호출 및 응답을 콘솔에 직접 기록
- 터미널을 벗어나지 않고 최신 Microsoft 문서를 워크플로에 통합

이 장에는 실습 과제, 최소 작동 코드 샘플, 심화 학습을 위한 추가 리소스 링크가 포함되어 있습니다. MCP가 문서 접근성과 개발자 생산성을 콘솔 기반 환경에서 어떻게 혁신할 수 있는지 이해하려면 링크된 장의 전체 워크스루와 코드를 참조하세요.

### 4. [MCP를 활용한 대화형 학습 계획 생성 웹 앱](./docs-mcp/README.md)

이 사례 연구는 Chainlit과 모델 컨텍스트 프로토콜(MCP)을 사용하여 주제별 맞춤형 학습 계획을 생성하는 대화형 웹 애플리케이션을 구축하는 방법을 보여줍니다. 사용자는 주제(예: "AI-900 인증")와 학습 기간(예: 8주)을 지정할 수 있으며, 앱은 주별 추천 콘텐츠를 제공합니다. Chainlit은 대화형 채팅 인터페이스를 제공하여 경험을 더욱 흥미롭고 적응적으로 만듭니다.

- Chainlit으로 구동되는 대화형 웹 앱
- 주제와 기간에 대한 사용자 지정 프롬프트
- MCP를 활용한 주별 콘텐츠 추천
- 채팅 인터페이스에서 실시간 적응형 응답

이 프로젝트는 대화형 AI와 MCP를 결합하여 현대 웹 환경에서 동적이고 사용자 중심의 교육 도구를 만드는 방법을 보여줍니다.

### 5. [VS Code에서 MCP 서버를 활용한 문서 검색](./docs-mcp/README.md)

이 사례 연구는 브라우저 탭을 전환하지 않고도 Microsoft Learn 문서를 VS Code 환경으로 직접 가져오는 방법을 보여줍니다. MCP 서버를 활용하여 다음을 수행할 수 있습니다:

- MCP 패널 또는 명령 팔레트를 사용하여 VS Code 내에서 문서를 즉시 검색 및 읽기
- README 또는 코스 마크다운 파일에 문서 링크를 직접 삽입
- GitHub Copilot과 MCP를 함께 사용하여 AI 기반 문서 및 코드 워크플로를 원활하게 수행
- 실시간 피드백과 Microsoft 출처의 정확성을 통해 문서를 검증 및 개선
- GitHub 워크플로와 MCP를 통합하여 지속적인 문서 검증 수행

구현에는 다음이 포함됩니다:

- 간단한 설정을 위한 `.vscode/mcp.json` 구성 예제
- 에디터 경험에 대한 스크린샷 기반 워크스루
- Copilot과 MCP를 결합하여 생산성을 극대화하는 팁

이 시나리오는 코스 저자, 문서 작성자, 개발자가 에디터에 집중하면서 문서, Copilot, 검증 도구를 활용하고자 할 때 이상적입니다.

### 6. [APIM MCP 서버 생성](./apimsample.md)

이 사례 연구는 Azure API Management(APIM)를 사용하여 MCP 서버를 생성하는 단계별 가이드를 제공합니다. 다음을 다룹니다:

- Azure API Management에서 MCP 서버 설정
- MCP 도구로 API 작업 노출
- 속도 제한 및 보안을 위한 정책 구성
- Visual Studio Code와 GitHub Copilot을 사용하여 MCP 서버 테스트

이 예시는 Azure의 기능을 활용하여 다양한 애플리케이션에서 사용할 수 있는 강력한 MCP 서버를 생성하고 AI 시스템과 기업 API의 통합을 강화하는 방법을 보여줍니다.

## 결론

이 사례 연구는 실제 환경에서 모델 컨텍스트 프로토콜의 다양성과 실질적인 응용을 강조합니다. 복잡한 다중 에이전트 시스템부터 목표 지향적인 자동화 워크플로까지, MCP는 AI 시스템이 필요한 도구와 데이터를 연결하여 가치를 제공하는 표준화된 방법을 제공합니다.

이 구현을 연구함으로써 아키텍처 패턴, 구현 전략, 모범 사례에 대한 통찰력을 얻을 수 있으며, 이를 자신의 MCP 프로젝트에 적용할 수 있습니다. 이 예시는 MCP가 단순한 이론적 프레임워크가 아니라 실제 비즈니스 문제에 대한 실질적인 솔루션임을 보여줍니다.

## 추가 리소스

- [Azure AI 여행 에이전트 GitHub 저장소](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP 도구](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP 도구](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP 서버](https://github.com/MicrosoftDocs/mcp)
- [MCP 커뮤니티 예제](https://github.com/microsoft/mcp)

다음: 실습 랩 [AI 워크플로 간소화: AI 툴킷으로 MCP 서버 구축](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있지만, 자동 번역에는 오류나 부정확성이 포함될 수 있습니다. 원본 문서의 원어 버전을 권위 있는 출처로 간주해야 합니다. 중요한 정보의 경우, 전문적인 인간 번역을 권장합니다. 이 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 책임을 지지 않습니다.