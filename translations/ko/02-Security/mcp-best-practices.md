<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-16T23:08:22+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "ko"
}
-->
# MCP 보안 모범 사례

MCP 서버를 사용할 때 데이터, 인프라, 사용자 보호를 위해 다음 보안 모범 사례를 따르세요:

1. **입력 검증**: 항상 입력값을 검증하고 정제하여 인젝션 공격과 혼란 대리 문제를 방지하세요.
2. **접근 제어**: 세밀한 권한 설정을 통해 MCP 서버에 적절한 인증 및 권한 부여를 구현하세요.
3. **보안 통신**: MCP 서버와의 모든 통신에 HTTPS/TLS를 사용하고, 민감한 데이터에는 추가 암호화를 고려하세요.
4. **속도 제한**: 남용, DoS 공격 방지 및 자원 관리를 위해 속도 제한을 구현하세요.
5. **로깅 및 모니터링**: MCP 서버에서 의심스러운 활동을 모니터링하고 포괄적인 감사 추적을 구현하세요.
6. **보안 저장소**: 민감한 데이터와 자격 증명을 적절한 암호화로 안전하게 저장하세요.
7. **토큰 관리**: 모든 모델 입력과 출력을 검증 및 정제하여 토큰 전달 취약점을 방지하세요.
8. **세션 관리**: 세션 탈취 및 고정 공격을 방지하기 위해 안전한 세션 처리를 구현하세요.
9. **도구 실행 샌드박싱**: 도구 실행을 격리된 환경에서 수행하여 침해 시 측면 이동을 방지하세요.
10. **정기 보안 감사**: MCP 구현과 의존성에 대해 주기적인 보안 검토를 수행하세요.
11. **프롬프트 검증**: 입력 및 출력 프롬프트를 검사하고 필터링하여 프롬프트 인젝션 공격을 방지하세요.
12. **인증 위임**: 자체 인증 구현 대신 검증된 ID 공급자를 사용하세요.
13. **권한 범위 설정**: 최소 권한 원칙에 따라 각 도구와 리소스에 대해 세분화된 권한을 적용하세요.
14. **데이터 최소화**: 각 작업에 필요한 최소한의 데이터만 노출하여 위험 노출 면적을 줄이세요.
15. **자동 취약점 스캔**: MCP 서버와 의존성을 정기적으로 알려진 취약점에 대해 스캔하세요.

## MCP 보안 모범 사례 지원 자료

### 입력 검증
- [OWASP 입력 검증 치트 시트](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [MCP에서 프롬프트 인젝션 방지](https://modelcontextprotocol.io/docs/guides/security)
- [Azure 콘텐츠 안전 구현](./azure-content-safety-implementation.md)

### 접근 제어
- [MCP 권한 부여 명세](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [MCP 서버에서 Microsoft Entra ID 사용하기](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [MCP용 인증 게이트웨이로서 Azure API Management](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### 보안 통신
- [전송 계층 보안(TLS) 모범 사례](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP 전송 보안 가이드라인](https://modelcontextprotocol.io/docs/concepts/transports)
- [AI 워크로드를 위한 종단 간 암호화](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### 속도 제한
- [API 속도 제한 패턴](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [토큰 버킷 속도 제한 구현](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Azure API Management에서의 속도 제한](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### 로깅 및 모니터링
- [AI 시스템을 위한 중앙 집중식 로깅](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [감사 로깅 모범 사례](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [AI 워크로드용 Azure Monitor](https://learn.microsoft.com/azure/azure-monitor/overview)

### 보안 저장소
- [자격 증명 저장을 위한 Azure Key Vault](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [휴지 상태 데이터 암호화](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [안전한 토큰 저장 및 토큰 암호화 사용](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### 토큰 관리
- [JWT 모범 사례 (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 보안 모범 사례 (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [토큰 검증 및 수명 모범 사례](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### 세션 관리
- [OWASP 세션 관리 치트 시트](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP 세션 처리 가이드라인](https://modelcontextprotocol.io/docs/guides/security)
- [안전한 세션 설계 패턴](https://learn.microsoft.com/security/engineering/session-security)

### 도구 실행 샌드박싱
- [컨테이너 보안 모범 사례](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [프로세스 격리 구현](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [컨테이너화된 애플리케이션의 자원 제한](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### 정기 보안 감사
- [Microsoft 보안 개발 수명 주기](https://www.microsoft.com/sdl)
- [OWASP 애플리케이션 보안 검증 표준](https://owasp.org/www-project-application-security-verification-standard/)
- [보안 코드 리뷰 가이드라인](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### 프롬프트 검증
- [Microsoft 프롬프트 쉴드](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [AI용 Azure 콘텐츠 안전](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [프롬프트 인젝션 방지](https://github.com/microsoft/prompt-shield-js)

### 인증 위임
- [Microsoft Entra ID 통합](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [MCP 서비스용 OAuth 2.0](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP 보안 제어 2025](./mcp-security-controls-2025.md)

### 권한 범위 설정
- [안전한 최소 권한 접근](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [역할 기반 접근 제어(RBAC) 설계](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [MCP에서 도구별 권한 부여](https://modelcontextprotocol.io/docs/guides/best-practices)

### 데이터 최소화
- [설계 단계에서의 데이터 보호](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI 데이터 개인정보 보호 모범 사례](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [개인정보 보호 강화 기술 구현](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### 자동 취약점 스캔
- [GitHub 고급 보안](https://github.com/security/advanced-security)
- [DevSecOps 파이프라인 구현](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [지속적인 보안 검증](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의하시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.