<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b1cffc51b82049ac3d5e88db0ff4a0a1",
  "translation_date": "2025-06-12T21:41:48+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ko"
}
-->
# Advanced Topics in MCP 

이 장에서는 Model Context Protocol(MCP) 구현의 고급 주제들을 다룹니다. 멀티모달 통합, 확장성, 보안 모범 사례, 엔터프라이즈 통합 등이 포함되며, 이는 현대 AI 시스템의 요구를 충족하는 견고하고 실무에 적합한 MCP 애플리케이션을 구축하는 데 필수적입니다.

## Overview

이 수업에서는 MCP 구현의 고급 개념을 탐구하며, 멀티모달 통합, 확장성, 보안 모범 사례, 엔터프라이즈 통합에 중점을 둡니다. 이러한 주제들은 복잡한 요구사항을 처리할 수 있는 실무 수준의 MCP 애플리케이션을 구축하는 데 필수적입니다.

## Learning Objectives

이 수업을 마치면 다음을 할 수 있습니다:

- MCP 프레임워크 내에서 멀티모달 기능 구현
- 높은 수요 시나리오에 맞는 확장 가능한 MCP 아키텍처 설계
- MCP의 보안 원칙에 부합하는 보안 모범 사례 적용
- MCP를 엔터프라이즈 AI 시스템 및 프레임워크와 통합
- 실무 환경에서 성능과 신뢰성 최적화

## Lessons and sample Projects

| Link | Title | Description |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrate with Azure | Azure에서 MCP Server를 통합하는 방법 학습 |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multi modal samples  | 오디오, 이미지 및 멀티모달 응답 샘플 |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | OAuth2를 MCP의 Authorization 및 Resource Server로 사용하는 최소한의 Spring Boot 앱. 안전한 토큰 발급, 보호된 엔드포인트, Azure Container Apps 배포, API 관리 통합을 시연합니다. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts  | 루트 컨텍스트에 대해 자세히 배우고 구현 방법 익히기 |
| [5.5 Routing](./mcp-routing/README.md) | Routing | 다양한 라우팅 유형 학습 |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | 샘플링 작업 방법 학습 |
| [5.7 Scaling](./mcp-scaling/README.md) | Scaling  | 확장성에 대해 학습 |
| [5.8 Security](./mcp-security/README.md) | Security  | MCP Server 보안 강화 |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP 서버 및 클라이언트가 SerpAPI와 통합되어 실시간 웹, 뉴스, 제품 검색, Q&A를 지원. 다중 도구 오케스트레이션, 외부 API 통합, 견고한 오류 처리 시연. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming  | 실시간 데이터 스트리밍은 오늘날 데이터 중심 세상에서 즉각적인 정보 접근이 필요한 비즈니스와 애플리케이션에 필수적입니다. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | MCP가 AI 모델, 검색 엔진, 애플리케이션 전반에 걸쳐 컨텍스트 관리를 표준화하여 실시간 웹 검색을 혁신하는 방법 설명. |

## Additional References

최신 MCP 고급 주제 정보는 다음을 참고하세요:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Key Takeaways

- 멀티모달 MCP 구현은 텍스트 처리 이상의 AI 역량 확장
- 확장성은 엔터프라이즈 배포에 필수적이며 수평 및 수직 확장으로 대응 가능
- 종합적인 보안 조치는 데이터 보호 및 적절한 접근 제어 보장
- Azure OpenAI, Microsoft AI Foundry 같은 플랫폼과의 엔터프라이즈 통합으로 MCP 역량 강화
- 고급 MCP 구현은 최적화된 아키텍처와 신중한 자원 관리로 이점 획득

## Exercise

특정 사용 사례에 맞는 엔터프라이즈급 MCP 구현 설계:

1. 사용 사례에 필요한 멀티모달 요구사항 파악
2. 민감 데이터 보호를 위한 보안 통제 개요 작성
3. 다양한 부하를 처리할 수 있는 확장 가능한 아키텍처 설계
4. 엔터프라이즈 AI 시스템과의 통합 지점 계획
5. 잠재적 성능 병목 현상 및 완화 전략 문서화

## Additional Resources

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## What's next

- [5.1 MCP Integration](./mcp-integration/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있음을 양지해 주시기 바랍니다. 원문 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해서는 당사가 책임지지 않습니다.