<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T21:42:07+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ko"
}
-->
# 초기 도입자들의 교훈

## 개요

이 강의에서는 초기 도입자들이 Model Context Protocol(MCP)을 활용해 실제 문제를 해결하고 다양한 산업에서 혁신을 이끌어낸 사례를 살펴봅니다. 상세한 사례 연구와 실습 프로젝트를 통해 MCP가 대형 언어 모델, 도구, 기업 데이터를 하나의 통합된 프레임워크로 연결하여 표준화되고 안전하며 확장 가능한 AI 통합을 어떻게 가능하게 하는지 이해할 수 있습니다. MCP 기반 솔루션을 설계하고 구축하는 실무 경험을 쌓고, 검증된 구현 패턴을 배우며, MCP를 실제 운영 환경에 배포할 때의 모범 사례도 알아봅니다. 또한 MCP 기술의 최신 동향, 미래 방향성, 오픈소스 리소스도 소개하여 MCP와 그 진화하는 생태계의 최전선에 머무를 수 있도록 돕습니다.

## 학습 목표

- 다양한 산업에서의 실제 MCP 구현 사례 분석  
- 완전한 MCP 기반 애플리케이션 설계 및 구축  
- MCP 기술의 최신 트렌드와 미래 방향 탐색  
- 실제 개발 상황에서 모범 사례 적용  

## 실제 MCP 구현 사례

### 사례 연구 1: 엔터프라이즈 고객 지원 자동화

다국적 기업이 MCP 기반 솔루션을 도입해 고객 지원 시스템 전반에서 AI 상호작용을 표준화했습니다. 이를 통해 다음과 같은 효과를 얻었습니다:

- 여러 LLM 공급자를 위한 통합 인터페이스 구축  
- 부서 간 일관된 프롬프트 관리 유지  
- 강력한 보안 및 컴플라이언스 통제 구현  
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

**결과:** 모델 비용 30% 절감, 응답 일관성 45% 향상, 전 세계 운영에서 컴플라이언스 강화

### 사례 연구 2: 헬스케어 진단 보조

헬스케어 제공자는 MCP 인프라를 구축해 여러 전문 의료 AI 모델을 통합하면서도 민감한 환자 데이터를 안전하게 보호했습니다:

- 일반 의료 모델과 전문 의료 모델 간 원활한 전환  
- 엄격한 개인정보 보호 및 감사 추적  
- 기존 전자건강기록(EHR) 시스템과의 통합  
- 의료 용어에 대한 일관된 프롬프트 엔지니어링  

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

**결과:** 의사 진단 지원 개선, HIPAA 완전 준수 유지, 시스템 간 컨텍스트 전환 대폭 감소

### 사례 연구 3: 금융 서비스 위험 분석

금융 기관은 MCP를 도입해 부서별 위험 분석 프로세스를 표준화했습니다:

- 신용 위험, 사기 탐지, 투자 위험 모델을 위한 통합 인터페이스 구축  
- 엄격한 접근 제어 및 모델 버전 관리 구현  
- 모든 AI 권고 사항의 감사 가능성 보장  
- 다양한 시스템 간 일관된 데이터 형식 유지  

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

**결과:** 규제 준수 강화, 모델 배포 주기 40% 단축, 부서 간 위험 평가 일관성 향상

### 사례 연구 4: Microsoft Playwright MCP 서버를 이용한 브라우저 자동화

Microsoft는 Model Context Protocol을 통해 안전하고 표준화된 브라우저 자동화를 가능하게 하는 [Playwright MCP 서버](https://github.com/microsoft/playwright-mcp)를 개발했습니다. 이 솔루션은 AI 에이전트와 LLM이 웹 브라우저와 통제 가능하고 감사 가능한 방식으로 상호작용할 수 있게 하며, 자동화된 웹 테스트, 데이터 추출, 엔드투엔드 워크플로우 등 다양한 활용 사례를 지원합니다.

- 브라우저 자동화 기능(네비게이션, 폼 입력, 스크린샷 캡처 등)을 MCP 도구로 노출  
- 무단 행동 방지를 위한 엄격한 접근 제어 및 샌드박스 적용  
- 모든 브라우저 상호작용에 대한 상세 감사 로그 제공  
- Azure OpenAI 및 기타 LLM 공급자와 통합 지원  

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
- AI 에이전트와 LLM을 위한 안전하고 프로그래밍 가능한 브라우저 자동화 지원  
- 수동 테스트 작업 감소 및 웹 애플리케이션 테스트 범위 향상  
- 기업 환경에서 브라우저 기반 도구 통합을 위한 재사용 가능하고 확장 가능한 프레임워크 제공  

**참고:**  
- [Playwright MCP Server GitHub 저장소](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI 및 자동화 솔루션](https://azure.microsoft.com/en-us/products/ai-services/)

### 사례 연구 5: Azure MCP – 엔터프라이즈급 Model Context Protocol 서비스

Azure MCP([https://aka.ms/azmcp](https://aka.ms/azmcp))는 Microsoft가 제공하는 관리형 엔터프라이즈급 Model Context Protocol 구현체로, 확장 가능하고 안전하며 규정을 준수하는 MCP 서버 기능을 클라우드 서비스로 제공합니다. Azure MCP는 조직이 MCP 서버를 신속하게 배포, 관리, 통합할 수 있도록 지원하며, Azure AI, 데이터, 보안 서비스와 연계해 운영 부담을 줄이고 AI 도입을 가속화합니다.

- 내장된 확장성, 모니터링, 보안을 갖춘 완전 관리형 MCP 서버 호스팅  
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
- 준비된, 규정을 준수하는 MCP 서버 플랫폼 제공으로 엔터프라이즈 AI 프로젝트의 가치 실현 시간 단축  
- LLM, 도구, 기업 데이터 소스 통합 간소화  
- MCP 워크로드의 보안성, 가시성, 운영 효율성 향상  

**참고:**  
- [Azure MCP 문서](https://aka.ms/azmcp)  
- [Azure AI 서비스](https://azure.microsoft.com/en-us/products/ai-services/)

## 사례 연구 6: NLWeb

MCP(Model Context Protocol)는 챗봇과 AI 어시스턴트가 도구와 상호작용할 수 있도록 하는 신흥 프로토콜입니다. 모든 NLWeb 인스턴스는 MCP 서버이기도 하며, 하나의 핵심 메서드인 ask를 지원합니다. ask는 자연어로 웹사이트에 질문할 때 사용되며, 반환된 응답은 웹 데이터를 설명하는 데 널리 쓰이는 어휘인 schema.org를 활용합니다. 넓은 의미에서 MCP는 NLWeb이 Http에 대해 HTML인 것과 같습니다. NLWeb은 프로토콜, Schema.org 형식, 샘플 코드를 결합해 사이트가 이러한 엔드포인트를 빠르게 만들 수 있게 하며, 대화형 인터페이스를 통한 인간 사용자와 자연스러운 에이전트 간 상호작용 모두에 이점을 제공합니다.

NLWeb은 두 가지 주요 구성 요소로 이루어져 있습니다.  
- 자연어로 사이트와 인터페이스하기 위한 매우 간단한 프로토콜과, json 및 schema.org를 활용한 응답 형식 (REST API 문서 참고)  
- 기존 마크업을 활용한 (1)의 간단한 구현체로, 제품, 레시피, 명소, 리뷰 등 항목 목록으로 추상화 가능한 사이트 대상. 사용자 인터페이스 위젯 세트와 함께 사이트에서 대화형 인터페이스를 쉽게 제공할 수 있습니다. 자세한 내용은 Life of a chat query 문서 참고.

**참고:**  
- [Azure MCP 문서](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

## 실습 프로젝트

### 프로젝트 1: 다중 공급자 MCP 서버 구축

**목표:** 특정 기준에 따라 여러 AI 모델 공급자에게 요청을 라우팅할 수 있는 MCP 서버를 만듭니다.

**요구 사항:**  
- 최소 세 가지 모델 공급자 지원(예: OpenAI, Anthropic, 로컬 모델)  
- 요청 메타데이터 기반 라우팅 메커니즘 구현  
- 공급자 자격 증명 관리용 구성 시스템 구축  
- 성능과 비용 최적화를 위한 캐싱 추가  
- 사용량 모니터링을 위한 간단한 대시보드 구축  

**구현 단계:**  
1. 기본 MCP 서버 인프라 설정  
2. 각 AI 모델 서비스용 공급자 어댑터 구현  
3. 요청 속성에 따른 라우팅 로직 작성  
4. 빈번한 요청에 대한 캐싱 메커니즘 추가  
5. 모니터링 대시보드 개발  
6. 다양한 요청 패턴으로 테스트  

**기술 스택:** Python (.NET/Java/Python 중 선택 가능), Redis 캐싱, 대시보드용 간단한 웹 프레임워크

### 프로젝트 2: 엔터프라이즈 프롬프트 관리 시스템

**목표:** 조직 전반에서 프롬프트 템플릿을 관리, 버전 관리, 배포할 수 있는 MCP 기반 시스템 개발

**요구 사항:**  
- 프롬프트 템플릿 중앙 저장소 구축  
- 버전 관리 및 승인 워크플로우 구현  
- 샘플 입력을 통한 템플릿 테스트 기능 개발  
- 역할 기반 접근 제어 구현  
- 템플릿 조회 및 배포용 API 제공  

**구현 단계:**  
1. 템플릿 저장용 데이터베이스 스키마 설계  
2. 템플릿 CRUD 핵심 API 구현  
3. 버전 관리 시스템 개발  
4. 승인 워크플로우 구축  
5. 테스트 프레임워크 개발  
6. 관리용 간단한 웹 인터페이스 제작  
7. MCP 서버와 통합  

**기술 스택:** 백엔드 프레임워크, SQL 또는 NoSQL 데이터베이스, 프론트엔드 프레임워크 자유 선택

### 프로젝트 3: MCP 기반 콘텐츠 생성 플랫폼

**목표:** MCP를 활용해 다양한 콘텐츠 유형에서 일관된 결과를 제공하는 콘텐츠 생성 플랫폼 구축

**요구 사항:**  
- 블로그 게시물, 소셜 미디어, 마케팅 카피 등 다양한 콘텐츠 형식 지원  
- 템플릿 기반 생성 및 사용자 맞춤화 옵션 구현  
- 콘텐츠 검토 및 피드백 시스템 구축  
- 콘텐츠 성과 지표 추적  
- 콘텐츠 버전 관리 및 반복 지원  

**구현 단계:**  
1. MCP 클라이언트 인프라 구축  
2. 콘텐츠 유형별 템플릿 생성  
3. 콘텐츠 생성 파이프라인 구축  
4. 검토 시스템 구현  
5. 지표 추적 시스템 개발  
6. 템플릿 관리 및 콘텐츠 생성용 사용자 인터페이스 제작  

**기술 스택:** 선호하는 프로그래밍 언어, 웹 프레임워크, 데이터베이스 시스템

## MCP 기술의 미래 방향

### 최신 동향

1. **멀티모달 MCP**  
   - 이미지, 오디오, 비디오 모델과의 상호작용 표준화 확대  
   - 교차 모달 추론 기능 개발  
   - 다양한 모달리티별 표준 프롬프트 형식  

2. **연합 MCP 인프라**  
   - 조직 간 자원 공유가 가능한 분산 MCP 네트워크  
   - 안전한 모델 공유를 위한 표준 프로토콜  
   - 개인정보 보호 계산 기술  

3. **MCP 마켓플레이스**  
   - MCP 템플릿과 플러그인 공유 및 수익화 생태계  
   - 품질 보증 및 인증 프로세스  
   - 모델 마켓플레이스와의 통합  

4. **엣지 컴퓨팅용 MCP**  
   - 자원 제약이 있는 엣지 디바이스에 맞춘 MCP 표준 적용  
   - 저대역폭 환경 최적화 프로토콜  
   - IoT 생태계 전용 MCP 구현  

5. **규제 프레임워크**  
   - 규제 준수를 위한 MCP 확장 개발  
   - 표준화된 감사 추적 및 설명 가능성 인터페이스  
   - 신흥 AI 거버넌스 프레임워크와 통합  

### Microsoft의 MCP 솔루션

Microsoft와 Azure는 다양한 시나리오에서 MCP를 구현하는 데 도움이 되는 여러 오픈소스 저장소를 개발했습니다:

#### Microsoft 조직  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - 브라우저 자동화 및 테스트용 Playwright MCP 서버  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - 로컬 테스트 및 커뮤니티 기여용 OneDrive MCP 서버 구현  
3. [NLWeb](https://github.com/microsoft/NlWeb) - AI 웹을 위한 기본 레이어 구축에 중점 둔 오픈 프로토콜 및 도구 모음  

#### Azure-Samples 조직  
1. [mcp](https://github.com/Azure-Samples/mcp) - Azure에서 다중 언어로 MCP 서버 구축 및 통합을 위한 샘플, 도구, 리소스 링크  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - 현재 MCP 사양을 활용한 인증 참조 서버  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions에서 원격 MCP 서버 구현용 랜딩 페이지 및 언어별 저장소 링크  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python을 이용한 원격 MCP 서버 빌드 및 배포용 퀵스타트 템플릿  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - .NET/C#용 원격 MCP 서버 빌드 및 배포 퀵스타트 템플릿  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - TypeScript용 원격 MCP 서버 빌드 및 배포 퀵스타트 템플릿  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Python을 이용한 Azure API Management 기반 AI 게이트웨이  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - MCP 기능을 포함한 APIM ❤️ AI 실험, Azure OpenAI 및 AI Foundry 통합  

이 저장소들은 다양한 프로그래밍 언어와 Azure 서비스를 아우르는 MCP 구현, 템플릿, 리소스를 제공합니다. 기본 서버 구현부터 인증, 클라우드 배포, 엔터프라이즈 통합 시나리오까지 다양한 사용 사례를 다룹니다.

#### MCP 리소스 디렉터리

공식 Microsoft MCP 저장소 내 [MCP Resources 디렉터리](https://github.com/microsoft/mcp/tree/main/Resources)는 MCP 서버에서 사용할 수 있는 샘플 리소스, 프롬프트 템플릿, 도구 정의를 엄선해 제공합니다. 이 디렉터리는 개발자가 재사용 가능한 빌딩 블록과 모범 사례 예제를 통해 MCP를 빠르게 시작할 수 있도록 설계되었습니다.

- **프롬프트 템플릿:** 일반 AI 작업 및 시나리오에 맞춘 즉시 사용 가능한 템플릿, 자체 MCP 서버 구현에 맞게 조정 가능  
- **도구 정의:** 도구 통합과 호출 표준화를 위한 예제 도구 스키마 및 메타데이터  
- **리소스 샘플:** MCP 프레임워크 내 데이터 소스, API, 외부 서비스 연결을 위한 예제 리소스 정의  
- **참조 구현:** 실제 MCP 프로젝트에서 리소스, 프롬프트, 도구를 구조화하고 조직하는 방법을 보여주는 실용 샘플  

이 리소스들은 개발 속도를 높이고 표준화를 촉진하며 MCP 기반 솔루션 구축 및 배포 시 모범 사례를 보장합니다.

#### MCP 리소스 디렉터리  
- [MCP Resources (샘플 프롬프트, 도구, 리소스 정의)](https://github.com/microsoft/mcp/tree/main/Resources)

### 연구 기회

- MCP 프레임워크 내 효율적인 프롬프트 최적화 기법  
- 다중 테넌트 MCP 배포를 위한 보안 모델  
- 다양한 MCP 구현 간 성능 벤치마킹  
- MCP 서버 형식 검증 방법  

## 결론

Model Context Protocol(MCP)은 산업 전반에서 표준화되고 안전하며 상호 운용 가능한 AI 통합의 미래를 빠르게 형성하고 있습니다. 이번 강의의 사례 연구와 실습 프로젝트를 통해 Microsoft와 Azure를 포함한 초기 도입자들이 MCP를 활용해 실제 문제를 해결하고 AI 도입을 가속화하며 컴플라이언스, 보안, 확장성을 확보하는 모습을 확인했습니다. MCP의 모듈식 접근법은 조직이 대형 언어 모델, 도구, 기업 데이터를 통합되고 감사 가능한 프레임워크 내에서 연결할 수 있게 합니다. MCP가 계속 발전함에 따라 커뮤니티 참여, 오픈소스 리소스 탐색, 모범 사례 적용이 견고하고 미래 지향적인 AI 솔루션 구축의 핵심이 될 것입니다.

## 추가 자료

- [MCP GitHub 저장소 (Microsoft)](https://github.com/microsoft/mcp)  
- [MCP 리소스 디렉터리 (샘플 프롬프트, 도구, 리소스 정의)](https://github.com/microsoft/mcp/tree/main/Resources)  
- [MCP 커뮤니티 및 문서](https://modelcontextprotocol.io/introduction)  
- [Azure MCP 문서](https://aka.ms/azmcp)  
- [Playwright MCP 서버 GitHub 저장소](https://github.com/microsoft/playwright-mcp)  
- [Files MCP 서버 (OneDrive)](https://github.com/microsoft/files-mcp-server)  
- [Azure
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## 연습 문제

1. 사례 연구 중 하나를 분석하고 대체 구현 방안을 제안하세요.
2. 프로젝트 아이디어 중 하나를 선택하여 상세한 기술 사양서를 작성하세요.
3. 사례 연구에 포함되지 않은 산업을 조사하고 MCP가 해당 산업의 특정 과제를 어떻게 해결할 수 있을지 개요를 작성하세요.
4. 미래 방향 중 하나를 탐구하고 이를 지원하는 새로운 MCP 확장 개념을 만들어 보세요.

다음: [Best Practices](../08-BestPractices/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있음을 유의하시기 바랍니다. 원본 문서의 원어 버전이 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역의 사용으로 인해 발생하는 어떠한 오해나 오역에 대해서도 당사는 책임을 지지 않습니다.