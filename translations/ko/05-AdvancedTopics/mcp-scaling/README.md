<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-06-12T21:43:57+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "ko"
}
-->
## 분산 아키텍처

분산 아키텍처는 여러 MCP 노드가 함께 작동하여 요청을 처리하고, 자원을 공유하며, 중복성을 제공합니다. 이 접근법은 노드들이 분산 시스템을 통해 소통하고 협력함으로써 확장성과 장애 내성을 향상시킵니다.

Redis를 이용한 조정을 통해 분산 MCP 서버 아키텍처를 구현하는 예제를 살펴보겠습니다.

## 다음 단계

- [5.8 보안](../mcp-security/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확성이 있을 수 있음을 유의해 주시기 바랍니다. 원본 문서의 원어 버전이 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.