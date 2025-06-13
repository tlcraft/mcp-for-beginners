<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T16:58:05+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ko"
}
-->
# 초기 도입자들의 교훈

## 개요

이 강의에서는 초기 도입자들이 Model Context Protocol(MCP)을 활용해 실제 문제를 해결하고 산업 전반에서 혁신을 이끌어낸 사례를 살펴봅니다. 상세한 사례 연구와 실습 프로젝트를 통해 MCP가 대형 언어 모델, 도구, 기업 데이터를 통합된 프레임워크 안에서 표준화되고 안전하며 확장 가능하게 연결하는 방식을 확인할 수 있습니다. MCP 기반 솔루션 설계 및 구축 경험을 쌓고, 검증된 구현 패턴을 배우며, 실제 운영 환경에서 MCP를 배포할 때의 모범 사례도 익히게 됩니다. 또한 MCP 기술과 그 진화하는 생태계에서 앞서 나갈 수 있도록 신흥 트렌드, 미래 방향, 오픈소스 리소스도 소개합니다.

## 학습 목표

- 다양한 산업에서의 실제 MCP 구현 사례 분석
- 완전한 MCP 기반 애플리케이션 설계 및 구축
- MCP 기술의 신흥 트렌드와 미래 방향 탐색
- 실제 개발 시나리오에서 모범 사례 적용

## 실제 MCP 구현 사례

### 사례 연구 1: 기업 고객 지원 자동화

한 다국적 기업은 고객 지원 시스템 전반에서 AI 상호작용을 표준화하기 위해 MCP 기반 솔루션을 도입했습니다. 이를 통해 다음을 가능하게 했습니다:

- 여러 LLM 제공자를 위한 통합 인터페이스 구축
- 부서 간 일관된 프롬프트 관리 유지
- 강력한 보안 및 컴플라이언스 제어 구현
- 특정 요구에 따라 다양한 AI 모델 간 손쉬운 전환

**기술 구현:**  
```python
# Python MCP server implementation for customer support
import logging
import asyncio
from modelcontextprotocol import create_server, ServerConfig
from modelcontextprotocol.server import MCPServer
from modelcontextprotocol.transports import create_http_transport
from modelcontextprotocol.resources import ResourceDefinition
from modelcontextprotocol.prompts import PromptDefinition
from modelcontextprotocol.tool import ToolDefinition

# Configure logging
logging.basicConfig(level=logging.INFO)

async def main():
    # Create server configuration
    config = ServerConfig(
        name="Enterprise Customer Support Server",
        version="1.0.0",
        description="MCP server for handling customer support inquiries"
    )
    
    # Initialize MCP server
    server = create_server(config)
    
    # Register knowledge base resources
    server.resources.register(
        ResourceDefinition(
            name="customer_kb",
            description="Customer knowledge base documentation"
        ),
        lambda params: get_customer_documentation(params)
    )
    
    # Register prompt templates
    server.prompts.register(
        PromptDefinition(
            name="support_template",
            description="Templates for customer support responses"
        ),
        lambda params: get_support_templates(params)
    )
    
    # Register support tools
    server.tools.register(
        ToolDefinition(
            name="ticketing",
            description="Create and update support tickets"
        ),
        handle_ticketing_operations
    )
    
    # Start server with HTTP transport
    transport = create_http_transport(port=8080)
    await server.run(transport)

if __name__ == "__main__":
    asyncio.run(main())
```

**결과:** 모델 비용 30% 절감, 응답 일관성 45% 향상, 글로벌 운영 전반에서 컴플라이언스 강화.

### 사례 연구 2: 의료 진단 보조 시스템

의료 제공자는 민감한 환자 데이터를 보호하면서 여러 전문 의료 AI 모델을 통합하기 위해 MCP 인프라를 구축했습니다:

- 일반 및 전문 의료 모델 간 원활한 전환
- 엄격한 개인정보 보호 제어 및 감사 추적
- 기존 전자의무기록(EHR) 시스템과 통합
- 의료 용어에 맞춘 일관된 프롬프트 엔지니어링

**기술 구현:**  
```csharp
// C# MCP host application implementation in healthcare application
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.SDK.Client;
using ModelContextProtocol.SDK.Security;
using ModelContextProtocol.SDK.Resources;

public class DiagnosticAssistant
{
    private readonly MCPHostClient _mcpClient;
    private readonly PatientContext _patientContext;
    
    public DiagnosticAssistant(PatientContext patientContext)
    {
        _patientContext = patientContext;
        
        // Configure MCP client with healthcare-specific settings
        var clientOptions = new ClientOptions
        {
            Name = "Healthcare Diagnostic Assistant",
            Version = "1.0.0",
            Security = new SecurityOptions
            {
                Encryption = EncryptionLevel.Medical,
                AuditEnabled = true
            }
        };
        
        _mcpClient = new MCPHostClientBuilder()
            .WithOptions(clientOptions)
            .WithTransport(new HttpTransport("https://healthcare-mcp.example.org"))
            .WithAuthentication(new HIPAACompliantAuthProvider())
            .Build();
    }
    
    public async Task<DiagnosticSuggestion> GetDiagnosticAssistance(
        string symptoms, string patientHistory)
    {
        // Create request with appropriate resources and tool access
        var resourceRequest = new ResourceRequest
        {
            Name = "patient_records",
            Parameters = new Dictionary<string, object>
            {
                ["patientId"] = _patientContext.PatientId,
                ["requestingProvider"] = _patientContext.ProviderId
            }
        };
        
        // Request diagnostic assistance using appropriate prompt
        var response = await _mcpClient.SendPromptRequestAsync(
            promptName: "diagnostic_assistance",
            parameters: new Dictionary<string, object>
            {
                ["symptoms"] = symptoms,
                patientHistory = patientHistory,
                relevantGuidelines = _patientContext.GetRelevantGuidelines()
            });
            
        return DiagnosticSuggestion.FromMCPResponse(response);
    }
}
```

**결과:** 의사의 진단 제안 향상, 완전한 HIPAA 준수 유지, 시스템 간 컨텍스트 전환 대폭 감소.

### 사례 연구 3: 금융 서비스 리스크 분석

한 금융 기관은 부서별 리스크 분석 프로세스를 표준화하기 위해 MCP를 도입했습니다:

- 신용 리스크, 사기 탐지, 투자 리스크 모델을 위한 통합 인터페이스 구축
- 엄격한 접근 제어 및 모델 버전 관리 구현
- 모든 AI 권고 사항에 대한 감사 가능성 확보
- 다양한 시스템 간 일관된 데이터 포맷 유지

**기술 구현:**  
```java
// Java MCP server for financial risk assessment
import org.mcp.server.*;
import org.mcp.security.*;

public class FinancialRiskMCPServer {
    public static void main(String[] args) {
        // Create MCP server with financial compliance features
        MCPServer server = new MCPServerBuilder()
            .withModelProviders(
                new ModelProvider("risk-assessment-primary", new AzureOpenAIProvider()),
                new ModelProvider("risk-assessment-audit", new LocalLlamaProvider())
            )
            .withPromptTemplateDirectory("./compliance/templates")
            .withAccessControls(new SOCCompliantAccessControl())
            .withDataEncryption(EncryptionStandard.FINANCIAL_GRADE)
            .withVersionControl(true)
            .withAuditLogging(new DatabaseAuditLogger())
            .build();
            
        server.addRequestValidator(new FinancialDataValidator());
        server.addResponseFilter(new PII_RedactionFilter());
        
        server.start(9000);
        
        System.out.println("Financial Risk MCP Server running on port 9000");
    }
}
```

**결과:** 규제 준수 강화, 모델 배포 주기 40% 단축, 부서 간 리스크 평가 일관성 향상.

### 사례 연구 4: Microsoft Playwright MCP 서버를 통한 브라우저 자동화

Microsoft는 Model Context Protocol을 활용해 안전하고 표준화된 브라우저 자동화를 가능하게 하는 [Playwright MCP 서버](https://github.com/microsoft/playwright-mcp)를 개발했습니다. 이 솔루션은 AI 에이전트와 LLM이 웹 브라우저와 제어 가능하고 감사 가능한 방식으로 상호작용하도록 지원하며, 자동 웹 테스트, 데이터 추출, 엔드투엔드 워크플로우 등의 활용 사례를 제공합니다.

- 브라우저 자동화 기능(탐색, 폼 입력, 스크린샷 캡처 등)을 MCP 도구로 노출
- 무단 작업 방지를 위한 엄격한 접근 제어 및 샌드박스 구현
- 모든 브라우저 상호작용에 대한 상세 감사 로그 제공
- Azure OpenAI 및 기타 LLM 제공자와의 통합 지원으로 에이전트 기반 자동화 가능

**기술 구현:**  
```typescript
// TypeScript: Registering Playwright browser automation tools in an MCP server
import { createServer, ToolDefinition } from 'modelcontextprotocol';
import { launch } from 'playwright';

const server = createServer({
  name: 'Playwright MCP Server',
  version: '1.0.0',
  description: 'MCP server for browser automation using Playwright'
});

// Register a tool for navigating to a URL and capturing a screenshot
server.tools.register(
  new ToolDefinition({
    name: 'navigate_and_screenshot',
    description: 'Navigate to a URL and capture a screenshot',
    parameters: {
      url: { type: 'string', description: 'The URL to visit' }
    }
  }),
  async ({ url }) => {
    const browser = await launch();
    const page = await browser.newPage();
    await page.goto(url);
    const screenshot = await page.screenshot();
    await browser.close();
    return { screenshot };
  }
);

// Start the MCP server
server.listen(8080);
```

**결과:**  
- AI 에이전트와 LLM을 위한 안전하고 프로그래밍 가능한 브라우저 자동화 실현  
- 수작업 테스트 감소 및 웹 애플리케이션 테스트 커버리지 향상  
- 기업 환경에서 브라우저 기반 도구 통합을 위한 재사용 가능하고 확장 가능한 프레임워크 제공

**참고:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### 사례 연구 5: Azure MCP – 엔터프라이즈급 Model Context Protocol 서비스

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp))는 Microsoft가 제공하는 관리형 엔터프라이즈급 Model Context Protocol 구현체로, 확장 가능하고 안전하며 컴플라이언스가 보장된 MCP 서버 기능을 클라우드 서비스로 제공합니다. Azure MCP를 통해 조직은 MCP 서버를 빠르게 배포, 관리하고 Azure AI, 데이터, 보안 서비스와 통합하여 운영 부담을 줄이고 AI 도입 속도를 높일 수 있습니다.

- 내장된 확장성, 모니터링, 보안 기능을 갖춘 완전 관리형 MCP 서버 호스팅  
- Azure OpenAI, Azure AI Search 등 Azure 서비스와의 네이티브 통합  
- Microsoft Entra ID를 통한 엔터프라이즈 인증 및 권한 관리  
- 맞춤 도구, 프롬프트 템플릿, 리소스 커넥터 지원  
- 기업 보안 및 규제 요구사항 준수

**기술 구현:**  
```yaml
# Example: Azure MCP server deployment configuration (YAML)
apiVersion: mcp.microsoft.com/v1
kind: McpServer
metadata:
  name: enterprise-mcp-server
spec:
  modelProviders:
    - name: azure-openai
      type: AzureOpenAI
      endpoint: https://<your-openai-resource>.openai.azure.com/
      apiKeySecret: <your-azure-keyvault-secret>
  tools:
    - name: document_search
      type: AzureAISearch
      endpoint: https://<your-search-resource>.search.windows.net/
      apiKeySecret: <your-azure-keyvault-secret>
  authentication:
    type: EntraID
    tenantId: <your-tenant-id>
  monitoring:
    enabled: true
    logAnalyticsWorkspace: <your-log-analytics-id>
```

**결과:**  
- 즉시 사용 가능한 컴플라이언트 MCP 서버 플랫폼 제공으로 엔터프라이즈 AI 프로젝트의 가치 실현 시간 단축  
- LLM, 도구, 기업 데이터 소스의 통합 간소화  
- MCP 워크로드의 보안, 관찰 가능성, 운영 효율성 향상

**참고:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## 사례 연구 6: NLWeb  
MCP(Model Context Protocol)는 챗봇과 AI 어시스턴트가 도구와 상호작용할 수 있도록 하는 신흥 프로토콜입니다. 모든 NLWeb 인스턴스는 MCP 서버이기도 하며, 핵심 메서드인 ask를 통해 자연어로 웹사이트에 질문할 수 있습니다. 반환되는 응답은 웹 데이터를 설명하는 데 널리 사용되는 어휘인 schema.org를 활용합니다. 쉽게 말해, MCP는 NLWeb이 HTTP에 대해 HTML인 것과 같은 관계입니다. NLWeb은 프로토콜, Schema.org 형식, 샘플 코드를 결합해 사이트가 빠르게 엔드포인트를 만들 수 있도록 하며, 대화형 인터페이스를 통한 인간의 접근성과 자연스러운 에이전트 간 상호작용을 모두 지원합니다.

NLWeb은 두 가지 주요 구성요소로 이루어져 있습니다.  
- 자연어로 사이트와 인터페이스하기 위한 매우 간단한 프로토콜과, json 및 schema.org를 활용한 응답 형식. REST API 문서에서 자세한 내용을 확인할 수 있습니다.  
- (1)을 간단히 구현한 것으로, 항목 목록(제품, 레시피, 관광지, 리뷰 등)으로 추상화할 수 있는 사이트에서 기존 마크업을 활용합니다. 사용자 인터페이스 위젯과 함께 사이트가 콘텐츠에 대한 대화형 인터페이스를 쉽게 제공할 수 있습니다. Life of a chat query 문서에서 작동 방식을 확인하세요.

**참고:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### 사례 연구 7: Foundry용 MCP – Azure AI 에이전트 통합

Azure AI Foundry MCP 서버는 MCP를 활용해 기업 환경에서 AI 에이전트와 워크플로우를 조율하고 관리하는 방법을 보여줍니다. MCP와 Azure AI Foundry를 통합함으로써 조직은 에이전트 간 상호작용을 표준화하고, Foundry의 워크플로우 관리를 활용하며, 안전하고 확장 가능한 배포를 보장할 수 있습니다. 이 접근법은 빠른 프로토타이핑, 견고한 모니터링, Azure AI 서비스와의 원활한 통합을 가능하게 하며, 지식 관리 및 에이전트 평가 같은 고급 시나리오를 지원합니다. 개발자는 에이전트 파이프라인 구축, 배포, 모니터링을 위한 통합 인터페이스를 활용하고, IT 팀은 보안, 컴플라이언스, 운영 효율성을 개선할 수 있습니다. 복잡한 에이전트 기반 프로세스에 대한 제어를 유지하면서 AI 도입을 가속화하려는 기업에 적합한 솔루션입니다.

**참고:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### 사례 연구 8: Foundry MCP 플레이그라운드 – 실험 및 프로토타이핑

Foundry MCP 플레이그라운드는 MCP 서버와 Azure AI Foundry 통합을 실험할 수 있는 즉시 사용 가능한 환경을 제공합니다. 개발자는 Azure AI Foundry 카탈로그 및 랩의 리소스를 활용해 AI 모델과 에이전트 워크플로우를 빠르게 프로토타입, 테스트, 평가할 수 있습니다. 이 플레이그라운드는 설정 과정을 간소화하고 샘플 프로젝트를 제공하며 협업 개발을 지원해, 최소한의 부담으로 모범 사례와 새로운 시나리오를 탐색할 수 있도록 돕습니다. 복잡한 인프라 없이 아이디어 검증, 실험 공유, 학습 가속화를 원하는 팀에 특히 유용합니다. 진입 장벽을 낮춤으로써 MCP와 Azure AI Foundry 생태계 내 혁신과 커뮤니티 기여를 촉진합니다.

**참고:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### 사례 연구 9: Microsoft Docs MCP 서버 – 학습 및 역량 강화  
Microsoft Docs MCP 서버는 Model Context Protocol(MCP) 서버를 구현하여 AI 어시스턴트가 공식 Microsoft 문서에 실시간으로 접근할 수 있게 합니다. Microsoft 공식 기술 문서에 대해 의미 기반 검색을 수행합니다.

**참고:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## 실습 프로젝트

### 프로젝트 1: 다중 제공자 MCP 서버 구축

**목표:** 특정 기준에 따라 여러 AI 모델 제공자로 요청을 라우팅할 수 있는 MCP 서버를 만듭니다.

**요구사항:**  
- 최소 세 개 이상의 모델 제공자 지원(예: OpenAI, Anthropic, 로컬 모델)  
- 요청 메타데이터 기반 라우팅 메커니즘 구현  
- 제공자 자격 증명 관리를 위한 구성 시스템 구축  
- 성능 및 비용 최적화를 위한 캐싱 추가  
- 사용량 모니터링을 위한 간단한 대시보드 구축

**구현 단계:**  
1. 기본 MCP 서버 인프라 구축  
2. 각 AI 모델 서비스에 대한 제공자 어댑터 구현  
3. 요청 속성에 따른 라우팅 로직 작성  
4. 빈번한 요청에 대한 캐싱 메커니즘 추가  
5. 모니터링 대시보드 개발  
6. 다양한 요청 패턴으로 테스트

**기술:** Python (.NET/Java/Python 중 선호하는 언어 선택), Redis 캐싱, 대시보드를 위한 간단한 웹 프레임워크.

### 프로젝트 2: 기업용 프롬프트 관리 시스템

**목표:** 조직 내 프롬프트 템플릿을 관리, 버전 관리, 배포하는 MCP 기반 시스템 개발

**요구사항:**  
- 프롬프트 템플릿 중앙 저장소 구축  
- 버전 관리 및 승인 워크플로우 구현  
- 샘플 입력으로 템플릿 테스트 기능 구축  
- 역할 기반 접근 제어 개발  
- 템플릿 조회 및 배포용 API 생성

**구현 단계:**  
1. 템플릿 저장용 데이터베이스 스키마 설계  
2. 템플릿 CRUD 작업을 위한 핵심 API 개발  
3. 버전 관리 시스템 구현  
4. 승인 워크플로우 구축  
5. 테스트 프레임워크 개발  
6. 관리용 간단한 웹 인터페이스 제작  
7. MCP 서버와 통합

**기술:** 백엔드 프레임워크, SQL 또는 NoSQL 데이터베이스, 관리 인터페이스용 프론트엔드 프레임워크 선택 가능.

### 프로젝트 3: MCP 기반 콘텐츠 생성 플랫폼

**목표:** 다양한 콘텐츠 유형에서 일관된 결과를 제공하는 MCP 기반 콘텐츠 생성 플랫폼 구축

**요구사항:**  
- 블로그 포스트, 소셜 미디어, 마케팅 카피 등 다양한 콘텐츠 형식 지원  
- 템플릿 기반 생성 및 사용자 맞춤 옵션 구현  
- 콘텐츠 리뷰 및 피드백 시스템 구축  
- 콘텐츠 성과 지표 추적  
- 콘텐츠 버전 관리 및 반복 지원

**구현 단계:**  
1. MCP 클라이언트 인프라 구축  
2. 다양한 콘텐츠 유형에 맞는 템플릿 생성  
3. 콘텐츠 생성 파이프라인 구축  
4. 리뷰 시스템 구현  
5. 지표 추적 시스템 개발  
6. 템플릿 관리 및 콘텐츠 생성을 위한 사용자 인터페이스 제작

**기술:** 선호하는 프로그래밍 언어, 웹 프레임워크, 데이터베이스 시스템 사용.

## MCP 기술의 미래 방향

### 신흥 트렌드

1. **멀티모달 MCP**  
   - 이미지, 오디오, 비디오 모델과의 상호작용 표준화 확대  
   - 교차 모달 추론 기능 개발  
   - 다양한 모달리티에 맞는 표준화된 프롬프트 형식

2. **분산형 MCP 인프라**  
   - 조직 간 리소스 공유가 가능한 분산 MCP 네트워크  
   - 안전한 모델 공유를 위한 표준 프로토콜  
   - 개인정보 보호 계산 기법

3. **MCP 마켓플레이스**  
   - MCP 템플릿과 플러그인을 공유하고 수익화할 수 있는 생태계  
   - 품질 보증 및 인증 프로세스  
   - 모델 마켓플레이스와의 통합

4. **엣지 컴퓨팅용 MCP**  
   - 자원 제한적인 엣지 디바이스에 맞춘 MCP 표준 적응  
   - 저대역폭 환경에 최적화된 프로토콜  
   - IoT 생태계에 특화된 MCP 구현

5. **규제 프레임워크**  
   - 규제 준수를 위한 MCP 확장 개발  
   - 표준화된 감사 추적 및 설명 가능성 인터페이스  
   - 신흥 AI 거버넌스 프레임워크와의 통합

### Microsoft의 MCP 솔루션

Microsoft와 Azure는 다양한 시나리오에서 MCP 구현을 지원하기 위해 여러 오픈소스 저장소를 개발했습니다:

#### Microsoft 조직

1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - 브라우저 자동화 및 테스트용 Playwright MCP 서버  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - 로컬 테스트 및 커뮤니티 기여용 OneDrive MCP 서버 구현  
3. [NLWeb](https://github.com/microsoft/NlWeb) - AI 웹을 위한 기본 계층 구축에 중점 둔 오픈 프로토콜 및 도구 모음  

#### Azure-Samples 조직

1. [mcp](https://github.com/Azure-Samples/mcp) - 다양한 언어를 사용해 Azure에서 MCP 서버 구축 및 통합을 위한 샘플, 도구, 리소스 링크  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - 현재 MCP 사양을 활용한 인증 참조 서버  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions 기반 원격 MCP 서버 구현 링크 모음  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python을 사용한 Azure Functions 기반 원격 MCP 서버 빠른 시작 템플릿  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - .NET/C# 기반 Azure Functions 원격 MCP 서버 빠른 시작 템플릿  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - TypeScript 기반 Azure Functions 원격 MCP 서버 빠른 시작 템플릿  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Python을 사용한 원격 MCP 서버용 Azure API 관리 게이트웨이  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - MCP 기능을 포함한 APIM ❤️ AI 실험, Azure OpenAI 및 AI Foundry 통합

이 저장소들은 다양한 프로그래밍 언어와 Azure 서비스를 아우르는 Model Context Protocol 작업을 위한 여러 구현체, 템플릿, 리소스를 제공합니다. 기본 서버 구현부터 인증, 클라우드 배포, 엔터프라이즈 통합 시나리오까지 다양한 사용 사례를 다룹니다.

#### MCP 리소스 디렉터리

공식 Microsoft MCP 저장소의 [MCP Resources 디렉터리](https://github.com/microsoft/mcp/tree/main/Resources)는 Model Context Protocol 서버에서 사용할 수 있는 샘플 리소스, 프롬프트 템플릿, 도구 정의를 엄선해 제공합니다
- [MCP 커뮤니티 및 문서](https://modelcontextprotocol.io/introduction)
- [Azure MCP 문서](https://aka.ms/azmcp)
- [Playwright MCP 서버 GitHub 저장소](https://github.com/microsoft/playwright-mcp)
- [Files MCP 서버 (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP 인증 서버 (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [원격 MCP 함수 (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [원격 MCP 함수 Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [원격 MCP 함수 .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [원격 MCP 함수 TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [원격 MCP APIM 함수 Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI 및 자동화 솔루션](https://azure.microsoft.com/en-us/products/ai-services/)

## 연습문제

1. 사례 연구 중 하나를 분석하고 대체 구현 방안을 제안하세요.
2. 프로젝트 아이디어 중 하나를 선택하여 상세한 기술 사양서를 작성하세요.
3. 사례 연구에 포함되지 않은 산업을 조사하고 MCP가 해당 산업의 특정 문제를 어떻게 해결할 수 있을지 개요를 작성하세요.
4. 미래 방향 중 하나를 탐색하고 이를 지원하는 새로운 MCP 확장 개념을 만들어 보세요.

다음: [모범 사례](../08-BestPractices/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있음을 유의하시기 바랍니다. 원본 문서는 해당 언어로 된 원문이 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.