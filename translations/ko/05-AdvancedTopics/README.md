<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T09:07:03+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ko"
}
-->
# MCP 고급 주제

이 장에서는 Model Context Protocol(MCP) 구현의 고급 주제들을 다룹니다. 멀티모달 통합, 확장성, 보안 모범 사례, 엔터프라이즈 통합 등이 포함되며, 이는 현대 AI 시스템의 요구를 충족하는 견고하고 프로덕션 준비가 된 MCP 애플리케이션을 구축하는 데 필수적입니다.

## 개요

이 수업에서는 MCP 구현의 고급 개념을 탐구하며, 멀티모달 통합, 확장성, 보안 모범 사례, 엔터프라이즈 통합에 중점을 둡니다. 이러한 주제들은 복잡한 요구사항을 처리할 수 있는 프로덕션 수준의 MCP 애플리케이션을 구축하는 데 필수적입니다.

## 학습 목표

이 수업을 마치면 다음을 수행할 수 있습니다:

- MCP 프레임워크 내에서 멀티모달 기능 구현
- 고부하 시나리오에 적합한 확장 가능한 MCP 아키텍처 설계
- MCP 보안 원칙에 맞는 보안 모범 사례 적용
- MCP를 엔터프라이즈 AI 시스템 및 프레임워크와 통합
- 프로덕션 환경에서 성능과 신뢰성 최적화

## 수업 및 샘플 프로젝트

| 링크 | 제목 | 설명 |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Azure와 통합하기 | Azure에서 MCP 서버를 통합하는 방법 학습 |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP 멀티모달 샘플 | 오디오, 이미지 및 멀티모달 응답 샘플 |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 데모 | OAuth2를 사용한 MCP의 최소한의 Spring Boot 앱으로, 인증 및 리소스 서버 역할을 모두 수행합니다. 안전한 토큰 발급, 보호된 엔드포인트, Azure Container Apps 배포, API 관리 통합을 시연합니다. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | 루트 컨텍스트 | 루트 컨텍스트에 대해 더 배우고 구현 방법 학습 |
| [5.5 Routing](./mcp-routing/README.md) | 라우팅 | 다양한 라우팅 유형 학습 |
| [5.6 Sampling](./mcp-sampling/README.md) | 샘플링 | 샘플링 작업 방법 학습 |
| [5.7 Scaling](./mcp-scaling/README.md) | 확장 | 확장에 대해 학습 |
| [5.8 Security](./mcp-security/README.md) | 보안 | MCP 서버 보안 강화 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | 웹 검색 MCP | SerpAPI와 통합된 Python MCP 서버 및 클라이언트로, 실시간 웹, 뉴스, 제품 검색 및 Q&A를 지원합니다. 다중 도구 조율, 외부 API 통합, 견고한 오류 처리 시연. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | 스트리밍 | 오늘날 데이터 중심 세상에서 비즈니스와 애플리케이션이 즉각적인 정보 접근을 요구하는 실시간 데이터 스트리밍의 중요성 소개 |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | 웹 검색 | MCP가 AI 모델, 검색 엔진, 애플리케이션 전반에 걸쳐 표준화된 컨텍스트 관리 방식을 제공하여 실시간 웹 검색을 어떻게 혁신하는지 설명 |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID 인증 | Microsoft Entra ID는 클라우드 기반 강력한 아이덴티티 및 접근 관리 솔루션으로, 권한이 있는 사용자와 애플리케이션만 MCP 서버와 상호작용할 수 있도록 보장 |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Azure AI Foundry 통합 | Model Context Protocol 서버를 Azure AI Foundry 에이전트와 통합하는 방법을 배우며, 표준화된 외부 데이터 소스 연결을 통해 강력한 도구 조율 및 엔터프라이즈 AI 기능 활성화 |

## 추가 참고자료

최신 MCP 고급 주제 정보는 다음을 참고하세요:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## 주요 내용 정리

- 멀티모달 MCP 구현은 텍스트 처리 이상의 AI 기능 확장
- 확장성은 엔터프라이즈 배포에 필수이며 수평 및 수직 확장을 통해 달성 가능
- 포괄적인 보안 조치로 데이터 보호 및 적절한 접근 제어 보장
- Azure OpenAI, Microsoft AI Foundry와 같은 플랫폼과의 엔터프라이즈 통합으로 MCP 기능 강화
- 고급 MCP 구현은 최적화된 아키텍처와 신중한 자원 관리로 이익을 얻음

## 연습문제

특정 사용 사례에 맞는 엔터프라이즈급 MCP 구현을 설계하세요:

1. 사용 사례의 멀티모달 요구사항 파악
2. 민감한 데이터를 보호하기 위한 보안 통제 개요 작성
3. 다양한 부하를 처리할 수 있는 확장 가능한 아키텍처 설계
4. 엔터프라이즈 AI 시스템과의 통합 지점 계획
5. 잠재적 성능 병목 현상 및 완화 전략 문서화

## 추가 자료

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## 다음 단계

- [5.1 MCP Integration](./mcp-integration/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있음을 유의하시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우, 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인한 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.