<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T15:07:22+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ko"
}
-->
# MCP 고급 주제

이 장에서는 모델 컨텍스트 프로토콜(MCP) 구현의 고급 주제들을 다룹니다. 여기에는 멀티모달 통합, 확장성, 보안 모범 사례, 엔터프라이즈 통합 등이 포함됩니다. 이러한 주제들은 현대 AI 시스템의 요구를 충족하는 견고하고 실무에 적합한 MCP 애플리케이션을 구축하는 데 매우 중요합니다.

## 개요

이번 수업에서는 모델 컨텍스트 프로토콜 구현의 고급 개념을 살펴봅니다. 멀티모달 통합, 확장성, 보안 모범 사례, 엔터프라이즈 통합에 중점을 두며, 복잡한 요구사항을 처리할 수 있는 실무 수준의 MCP 애플리케이션 구축에 필수적인 내용입니다.

## 학습 목표

이 수업을 마치면 다음을 수행할 수 있습니다:

- MCP 프레임워크 내에서 멀티모달 기능 구현
- 고부하 환경을 위한 확장 가능한 MCP 아키텍처 설계
- MCP 보안 원칙에 부합하는 보안 모범 사례 적용
- 엔터프라이즈 AI 시스템 및 프레임워크와 MCP 통합
- 실무 환경에서 성능 및 신뢰성 최적화

## 수업 및 샘플 프로젝트

| 링크 | 제목 | 설명 |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Azure와 통합 | Azure에서 MCP 서버를 통합하는 방법 학습 |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP 멀티모달 샘플 | 오디오, 이미지 및 멀티모달 응답 샘플 |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 데모 | Authorization 및 Resource Server로서의 MCP OAuth2를 보여주는 최소한의 Spring Boot 앱. 보안 토큰 발급, 보호된 엔드포인트, Azure Container Apps 배포, API 관리 통합을 시연합니다. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | 루트 컨텍스트 | 루트 컨텍스트에 대해 더 배우고 구현 방법 학습 |
| [5.5 Routing](./mcp-routing/README.md) | 라우팅 | 다양한 라우팅 유형 학습 |
| [5.6 Sampling](./mcp-sampling/README.md) | 샘플링 | 샘플링 작업 방법 학습 |
| [5.7 Scaling](./mcp-scaling/README.md) | 확장 | 확장에 대해 학습 |
| [5.8 Security](./mcp-security/README.md) | 보안 | MCP 서버 보안 강화 방법 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | 웹 검색 MCP | SerpAPI와 통합된 Python MCP 서버 및 클라이언트로 실시간 웹, 뉴스, 제품 검색, Q&A 기능 시연. 멀티툴 오케스트레이션, 외부 API 통합, 견고한 오류 처리 포함. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | 스트리밍 | 오늘날 데이터 중심 환경에서 즉각적인 정보 접근이 필요한 비즈니스와 애플리케이션을 위한 실시간 데이터 스트리밍 중요성 소개 |

## 추가 참고 자료

최신 MCP 고급 주제 정보는 다음을 참고하세요:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## 주요 내용 요약

- 멀티모달 MCP 구현은 텍스트 처리 이상의 AI 역량을 확장합니다
- 확장성은 엔터프라이즈 배포에 필수적이며 수평 및 수직 확장으로 대응할 수 있습니다
- 포괄적인 보안 조치는 데이터 보호 및 적절한 접근 제어를 보장합니다
- Azure OpenAI, Microsoft AI Foundry 같은 플랫폼과의 엔터프라이즈 통합이 MCP 기능을 강화합니다
- 고급 MCP 구현은 최적화된 아키텍처와 신중한 자원 관리로 이점을 얻습니다

## 실습 과제

특정 사용 사례를 위한 엔터프라이즈급 MCP 구현 설계:

1. 사용 사례에 필요한 멀티모달 요구사항 식별
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
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 내용이 포함될 수 있음을 유의해 주시기 바랍니다. 원문 문서는 해당 언어의 권위 있는 자료로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.