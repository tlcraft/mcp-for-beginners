<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-16T14:43:07+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "ko"
}
-->
# Security Best Practices

Model Context Protocol(MCP)를 도입하면 AI 기반 애플리케이션에 강력한 기능을 제공하지만, 전통적인 소프트웨어 위험을 넘어서는 독특한 보안 과제도 함께 발생합니다. 안전한 코딩, 최소 권한 원칙, 공급망 보안과 같은 기존의 우려 사항 외에도, MCP와 AI 워크로드는 프롬프트 인젝션, 도구 중독, 동적 도구 수정과 같은 새로운 위협에 직면합니다. 이러한 위험은 적절히 관리되지 않으면 데이터 유출, 개인정보 침해, 의도하지 않은 시스템 동작으로 이어질 수 있습니다.

이 강의에서는 MCP와 관련된 가장 중요한 보안 위험—인증, 권한 부여, 과도한 권한, 간접 프롬프트 인젝션, 공급망 취약점 등을 살펴보고, 이를 완화하기 위한 실질적인 통제 수단과 모범 사례를 제공합니다. 또한 Microsoft의 Prompt Shields, Azure Content Safety, GitHub Advanced Security와 같은 솔루션을 활용해 MCP 구현을 강화하는 방법도 배웁니다. 이러한 통제 수단을 이해하고 적용하면 보안 침해 가능성을 크게 줄이고 AI 시스템을 견고하고 신뢰할 수 있게 유지할 수 있습니다.

# Learning Objectives

이 강의를 마치면 다음을 할 수 있습니다:

- Model Context Protocol(MCP)이 도입하면서 발생하는 프롬프트 인젝션, 도구 중독, 과도한 권한, 공급망 취약점 등 고유한 보안 위험을 식별하고 설명할 수 있습니다.
- 강력한 인증, 최소 권한, 안전한 토큰 관리, 공급망 검증과 같은 MCP 보안 위험 완화 수단을 설명하고 적용할 수 있습니다.
- Prompt Shields, Azure Content Safety, GitHub Advanced Security와 같은 Microsoft 솔루션을 이해하고 활용해 MCP와 AI 워크로드를 보호할 수 있습니다.
- 도구 메타데이터 검증, 동적 변경 모니터링, 간접 프롬프트 인젝션 공격 방어의 중요성을 인식할 수 있습니다.
- 안전한 코딩, 서버 강화, 제로 트러스트 아키텍처와 같은 검증된 보안 모범 사례를 MCP 구현에 통합해 보안 침해 가능성과 영향을 줄일 수 있습니다.

# MCP security controls

중요한 리소스에 접근하는 모든 시스템은 암묵적인 보안 과제를 가집니다. 이러한 보안 문제는 일반적으로 기본 보안 통제와 개념을 올바르게 적용함으로써 해결할 수 있습니다. MCP는 새로 정의된 프로토콜로, 사양이 빠르게 변하고 있으며 프로토콜이 발전함에 따라 보안 통제도 점차 성숙해져 기업 및 기존 보안 아키텍처와 모범 사례와 더 잘 통합될 것입니다.

[Microsoft Digital Defense Report](https://aka.ms/mddr)에 따르면 보고된 침해 사건의 98%는 강력한 보안 위생으로 예방 가능하며, 침해를 막는 최선의 방법은 기본 보안 위생, 안전한 코딩 모범 사례, 공급망 보안을 제대로 갖추는 것입니다. 이미 알려진 검증된 방법들이 여전히 보안 위험 감소에 가장 큰 영향을 미칩니다.

MCP 도입 시 보안 위험을 다루기 시작할 수 있는 몇 가지 방법을 살펴보겠습니다.

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** 다음 정보는 2025년 4월 26일 기준으로 정확합니다. MCP 프로토콜은 지속적으로 발전 중이며, 향후 구현에서는 새로운 인증 패턴과 통제가 도입될 수 있습니다. 최신 업데이트와 지침은 항상 [MCP Specification](https://spec.modelcontextprotocol.io/) 및 공식 [MCP GitHub repository](https://github.com/modelcontextprotocol)를 참조하세요.

### 문제 설명  
초기 MCP 사양은 개발자가 자체 인증 서버를 작성할 것으로 가정했습니다. 이는 OAuth 및 관련 보안 제약에 대한 지식을 필요로 했습니다. MCP 서버는 OAuth 2.0 권한 부여 서버 역할을 하며, Microsoft Entra ID와 같은 외부 서비스에 위임하지 않고 사용자 인증을 직접 관리했습니다. 2025년 4월 26일자 MCP 사양 업데이트로 MCP 서버가 사용자 인증을 외부 서비스에 위임할 수 있게 되었습니다.

### 위험  
- MCP 서버의 권한 부여 로직이 잘못 구성되면 민감한 데이터 노출과 부적절한 접근 제어가 발생할 수 있습니다.
- 로컬 MCP 서버에서 OAuth 토큰이 도난당할 경우, 해당 토큰을 사용해 MCP 서버를 가장하고 OAuth 토큰이 허용하는 서비스의 리소스와 데이터에 접근할 수 있습니다.

### 완화 통제  
- **권한 부여 로직 검토 및 강화:** MCP 서버의 권한 부여 구현을 신중히 감사하여 의도된 사용자와 클라이언트만 민감한 리소스에 접근할 수 있도록 하세요. 실용적인 가이드는 [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)와 [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)를 참고하세요.
- **안전한 토큰 관리 시행:** [Microsoft의 토큰 검증 및 수명에 관한 모범 사례](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)를 따라 접근 토큰 오용을 방지하고 토큰 재사용 또는 도난 위험을 줄이세요.
- **토큰 저장 보호:** 토큰은 항상 안전하게 저장하고, 저장 및 전송 시 암호화를 사용하세요. 구현 팁은 [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)를 참조하세요.

# Excessive permissions for MCP servers

### 문제 설명  
MCP 서버가 접근하는 서비스나 리소스에 과도한 권한이 부여되었을 수 있습니다. 예를 들어, AI 영업 애플리케이션의 일부인 MCP 서버가 기업 데이터 저장소에 연결할 때, 영업 데이터에만 접근할 수 있어야 하며 저장소 내 모든 파일에 접근해서는 안 됩니다. 최소 권한 원칙(가장 오래된 보안 원칙 중 하나)을 참고하면, 어떤 리소스도 수행할 작업에 필요한 권한 이상을 가져서는 안 됩니다. AI는 유연성을 위해 정확한 권한 범위를 정의하기 어려워 이 점에서 도전이 더 큽니다.

### 위험  
- 과도한 권한 부여는 MCP 서버가 접근해서는 안 되는 데이터를 유출하거나 수정할 수 있게 합니다. 특히 개인 식별 정보(PII)가 포함된 경우 개인정보 문제로 이어질 수 있습니다.

### 완화 통제  
- **최소 권한 원칙 적용:** MCP 서버가 필요한 작업을 수행하는 데 필요한 최소한의 권한만 부여하세요. 권한을 정기적으로 검토하고 업데이트하여 불필요하게 권한이 늘어나지 않도록 하세요. 자세한 지침은 [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)를 참고하세요.
- **역할 기반 접근 제어(RBAC) 사용:** MCP 서버에 특정 리소스와 작업에 엄격히 제한된 역할을 할당하여 광범위하거나 불필요한 권한을 피하세요.
- **권한 모니터링 및 감사:** 권한 사용을 지속적으로 모니터링하고 접근 로그를 감사하여 과도하거나 사용하지 않는 권한을 신속히 식별하고 조치하세요.

# Indirect prompt injection attacks

### 문제 설명

악의적이거나 손상된 MCP 서버는 고객 데이터 노출 또는 의도하지 않은 행동을 유발하는 심각한 위험을 초래할 수 있습니다. 이러한 위험은 특히 AI 및 MCP 기반 워크로드에서 중요합니다:

- **프롬프트 인젝션 공격:** 공격자가 프롬프트나 외부 콘텐츠에 악성 명령을 삽입해 AI 시스템이 의도하지 않은 동작을 하거나 민감한 데이터를 유출하게 합니다. 자세히 보기: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **도구 중독:** 공격자가 도구 메타데이터(설명이나 매개변수 등)를 조작해 AI의 동작을 변경하고 보안 통제를 우회하거나 데이터를 유출할 수 있습니다. 세부 내용: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **교차 도메인 프롬프트 인젝션:** 악성 명령이 문서, 웹페이지, 이메일 등에 삽입되고 AI가 이를 처리하면서 데이터 유출이나 조작이 발생합니다.
- **동적 도구 수정(러그 풀):** 사용자 승인 후 도구 정의가 변경되어 악의적 행동이 추가될 수 있습니다.

이 취약점들은 MCP 서버와 도구를 환경에 통합할 때 강력한 검증, 모니터링, 보안 통제가 필요함을 보여줍니다. 자세한 내용은 위 링크를 참고하세요.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.ko.png)

**간접 프롬프트 인젝션**(Indirect Prompt Injection, 교차 도메인 프롬프트 인젝션 또는 XPIA라고도 함)은 Model Context Protocol(MCP)을 사용하는 생성 AI 시스템에서 심각한 취약점입니다. 이 공격은 문서, 웹페이지, 이메일 등 외부 콘텐츠에 악성 명령을 숨겨 AI가 이를 정상 사용자 명령으로 인식하게 만듭니다. 결과적으로 데이터 유출, 유해 콘텐츠 생성, 사용자 상호작용 조작과 같은 의도하지 않은 동작이 발생할 수 있습니다. 자세한 설명과 실제 사례는 [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)을 참고하세요.

특히 위험한 형태는 **도구 중독**입니다. 공격자는 MCP 도구의 메타데이터(도구 설명, 매개변수 등)에 악성 명령을 삽입합니다. 대형 언어 모델(LLM)은 이 메타데이터를 바탕으로 어떤 도구를 호출할지 결정하기 때문에, 손상된 설명은 모델이 무단 도구 호출이나 보안 통제 우회를 하도록 유도할 수 있습니다. 이러한 조작은 사용자에게는 보이지 않지만 AI 시스템이 해석하고 실행할 수 있습니다. 특히 호스팅되는 MCP 서버 환경에서는 사용자 승인 후 도구 정의가 변경될 수 있는데, 이를 "[러그 풀](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)"이라고 합니다. 이 경우 이전에 안전했던 도구가 나중에 악의적 동작을 수행하도록 바뀔 수 있으며, 데이터 유출이나 시스템 동작 변경이 사용자 모르게 발생할 수 있습니다. 관련 공격 벡터는 [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)을 참고하세요.

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.ko.png)

## 위험  
AI의 의도하지 않은 동작은 데이터 유출과 개인정보 침해를 포함한 다양한 보안 위험을 초래합니다.

### 완화 통제  
### 간접 프롬프트 인젝션 공격 방어를 위한 Prompt Shields 사용
-----------------------------------------------------------------------------

**AI Prompt Shields**는 Microsoft가 개발한 솔루션으로, 직접 및 간접 프롬프트 인젝션 공격 모두를 방어합니다. 주요 기능은 다음과 같습니다:

1.  **탐지 및 필터링:** Prompt Shields는 고급 머신러닝 알고리즘과 자연어 처리 기술을 사용해 문서, 웹페이지, 이메일 등 외부 콘텐츠에 삽입된 악성 명령을 탐지하고 필터링합니다.
    
2.  **스포트라이팅(Spotlighting):** 이 기술은 AI 시스템이 유효한 시스템 명령과 신뢰할 수 없는 외부 입력을 구분하도록 돕습니다. 입력 텍스트를 모델에 더 적합한 형태로 변환하여 악성 명령을 더 잘 식별하고 무시할 수 있게 합니다.
    
3.  **구분자 및 데이터마킹:** 시스템 메시지에 구분자를 포함해 입력 텍스트 위치를 명확히 하여 AI가 사용자 입력과 잠재적 유해 외부 콘텐츠를 구분할 수 있도록 지원합니다. 데이터마킹은 신뢰된 데이터와 신뢰되지 않은 데이터 경계를 특수 표시로 강조합니다.
    
4.  **지속적 모니터링 및 업데이트:** Microsoft는 Prompt Shields를 지속적으로 모니터링하고 업데이트하여 새로운 위협과 진화하는 공격 기법에 대응합니다.
    
5. **Azure Content Safety와 통합:** Prompt Shields는 Azure AI Content Safety 제품군의 일부로, 탈옥 시도, 유해 콘텐츠, 기타 AI 보안 위험 탐지 도구를 추가로 제공합니다.

AI Prompt Shields에 대해 더 알고 싶다면 [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)을 참고하세요.

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.ko.png)

### Supply chain security

공급망 보안은 AI 시대에도 여전히 기본적이지만, 공급망의 범위가 확대되었습니다. 전통적인 코드 패키지뿐 아니라, 기반 모델, 임베딩 서비스, 컨텍스트 제공자, 타사 API 등 AI 관련 모든 구성 요소를 엄격히 검증하고 모니터링해야 합니다. 이들 각각이 적절히 관리되지 않으면 취약점이나 위험을 초래할 수 있습니다.

**AI 및 MCP를 위한 주요 공급망 보안 관행:**  
- **통합 전 모든 구성 요소 검증:** 오픈소스 라이브러리뿐 아니라 AI 모델, 데이터 소스, 외부 API도 출처, 라이선스, 알려진 취약점을 반드시 확인하세요.  
- **안전한 배포 파이프라인 유지:** 보안 스캔이 통합된 자동화된 CI/CD 파이프라인을 사용해 문제를 조기에 발견하고, 신뢰할 수 있는 아티팩트만 프로덕션에 배포하세요.  
- **지속적 모니터링 및 감사:** 모델과 데이터 서비스 등 모든 의존성을 지속적으로 감시해 신규 취약점이나 공급망 공격을 탐지하세요.  
- **최소 권한 및 접근 통제 적용:** MCP 서버가 기능 수행에 필요한 최소한의 모델, 데이터, 서비스에만 접근하도록 제한하세요.  
- **위협에 신속 대응:** 침해가 발견되면 손상된 구성 요소를 패치하거나 교체하고, 비밀 정보나 자격 증명을 신속히 교체하는 절차를 마련하세요.

[GitHub Advanced Security](https://github.com/security/advanced-security)는 비밀 스캔, 의존성 스캔, CodeQL 분석 기능을 제공하며, [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) 및 [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/)와 통합되어 코드와 AI 공급망 구성 요소 전반의 취약점 식별 및 완화를 지원합니다.

Microsoft는 자사 제품 전반에 걸쳐 광범위한 공급망 보안 관행을 내부적으로 적용하고 있습니다. 자세한 내용은 [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)를 참고하세요.

# Established security best practices that will uplift your MCP implementation's security posture

모든 MCP 구현은 기반이 되는 조직 환경의 기존 보안 태세를 계승합니다. 따라서 MCP를 전체 AI 시스템의 구성요소로 고려할 때는 기존 보안 태세를 강화하는 것이 권장됩니다. 다음의 검증된 보안 통제가 특히 중요합니다:

- AI 애플리케이션에서 안전한 코딩 모범 사례 적용 — [OWASP Top 10](https://owasp.org/www-project-top-ten/), [LLM용 OWASP Top 10](https://genai.owasp.org/download/43299/?tmstv=1731900559) 대응, 비밀 및 토큰을 위한 안전한 보관소 사용, 모든 애플리케이션 구성 요소 간 종단 간 보안 통신 구현 등  
- 서버 강화 — 가능한 경우 MFA 사용, 최신 패치 유지, 제3자 ID 공급자와 서버 통합 등  
- 장치, 인프라, 애플리케이션의 최신 패치 유지  
- 보안 모니터링 — AI 애플리케이션(MCP 클라이언트/서버 포함)의 로깅 및 모니터링 구현, 중앙 SIEM으로 로그 전송하여 이상 활동 탐지  
- 제로 트러스트 아키텍처 — 네트워크 및 ID 통제를 통한 구성 요소 격리로 AI 애플리케이션 침해 시 측면 이동 최소화

# Key Takeaways

- 보안의 기본은 여전히 중요합니다: 안전한 코딩, 최소 권한, 공급망 검증, 지속적 모니터링은 MCP와 AI 워크로드에 필수적입니다.
- MCP는 프롬프트 인젝션, 도구 중독, 과도한 권한과 같은 새로운 위험을 도입하며, 전통적 및 AI 특화 통제를 모두 요구합니다.
- 강력한 인증, 권한 부여, 토큰 관리 관행을 사용하고, 가능하면 Microsoft Entra ID와 같은 외부 ID 공급자를 활용하세요.
- 도구 메타데이터 검증, 동적 변경 모니터링, Microsoft Prompt Shields와 같은 솔루션을 활용해 간접 프롬프트 인젝션과 도구 중독을 방어하세요.
- AI 공급망의 모든 구성 요소(모델, 임베딩, 컨텍스트 제공자 포함)를 코드 의존성과 동일한 엄격함으로 다루세요.
- 진화하는 MCP 사양을 주시하고, 커뮤니티에 기여해 안전한 표준 형성에 참여하세요.

# Additional Resources

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### 다음

다음: [3장: 시작하기](/03-GettingStarted/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의해 주시기 바랍니다. 원본 문서는 해당 언어의 원문이 권위 있는 자료로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해서는 당사가 책임지지 않습니다.