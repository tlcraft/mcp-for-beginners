<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:52:59+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "ko"
}
-->
# Model Context Protocol (MCP)와 Azure AI Foundry 통합

이 가이드는 Model Context Protocol (MCP) 서버를 Azure AI Foundry 에이전트와 통합하여 강력한 도구 오케스트레이션과 엔터프라이즈 AI 기능을 구현하는 방법을 보여줍니다.

## 소개

Model Context Protocol (MCP)은 AI 애플리케이션이 외부 데이터 소스와 도구에 안전하게 연결할 수 있도록 하는 오픈 표준입니다. Azure AI Foundry와 통합하면 MCP를 통해 에이전트가 다양한 외부 서비스, API 및 데이터 소스에 표준화된 방식으로 접근하고 상호작용할 수 있습니다.

이 통합은 MCP의 도구 생태계 유연성과 Azure AI Foundry의 견고한 에이전트 프레임워크를 결합하여 광범위한 맞춤화가 가능한 엔터프라이즈급 AI 솔루션을 제공합니다.

**Note:** Azure AI Foundry Agent Service에서 MCP를 사용하려면 현재 다음 지역만 지원됩니다: westus, westus2, uaenorth, southindia, switzerlandnorth

## 학습 목표

이 가이드를 완료하면 다음을 할 수 있습니다:

- Model Context Protocol과 그 이점을 이해하기
- Azure AI Foundry 에이전트와 함께 사용할 MCP 서버 설정하기
- MCP 도구 통합으로 에이전트 생성 및 구성하기
- 실제 MCP 서버를 활용한 실용적인 예제 구현하기
- 에이전트 대화에서 도구 응답 및 출처 처리하기

## 사전 준비 사항

시작하기 전에 다음을 준비하세요:

- AI Foundry에 액세스할 수 있는 Azure 구독
- Python 3.10 이상
- Azure CLI 설치 및 구성
- AI 리소스 생성 권한

## Model Context Protocol (MCP)란?

Model Context Protocol은 AI 애플리케이션이 외부 데이터 소스와 도구에 연결할 수 있도록 표준화된 방법입니다. 주요 이점은 다음과 같습니다:

- **표준화된 통합**: 다양한 도구와 서비스에 일관된 인터페이스 제공
- **보안**: 안전한 인증 및 권한 부여 메커니즘
- **유연성**: 다양한 데이터 소스, API 및 맞춤형 도구 지원
- **확장성**: 새로운 기능과 통합을 쉽게 추가 가능

## Azure AI Foundry와 MCP 설정하기

### 1. 환경 구성

먼저 환경 변수와 의존성을 설정합니다:

```python
import os
import time
import json
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential


### 1. Initialize the AI Project Client

```python
project_client = AIProjectClient(
    endpoint="https://your-project-endpoint.services.ai.azure.com/api/projects/your-project",
    credential=DefaultAzureCredential(),
)
```

### 2. Create an Agent with MCP Tools

Configure an agent with MCP server integration:

```python
with project_client:
    agent = project_client.agents.create_agent(
        model="gpt-4.1-nano", 
        name="mcp_agent", 
        instructions="You are a helpful assistant. Use the tools provided to answer questions. Be sure to cite your sources.",
        tools=[
            {
                "type": "mcp",
                "server_label": "microsoft_docs",
                "server_url": "https://learn.microsoft.com/api/mcp",
                "require_approval": "never"
            }
        ],
        tool_resources=None
    )
    print(f"Created agent, agent ID: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # MCP 서버 식별자
    "server_url": "https://api.example.com/mcp", # MCP 서버 엔드포인트
    "require_approval": "never"                 # 승인 정책: 현재는 "never"만 지원
}
```

## Complete Example: Using Microsoft Learn MCP Server

Here's a complete example that demonstrates creating an agent with MCP integration and processing a conversation:

```python
import time
import json
import os
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential

def create_mcp_agent_example():

    project_client = AIProjectClient(
        endpoint="https://your-endpoint.services.ai.azure.com/api/projects/your-project",
        credential=DefaultAzureCredential(),
    )

    with project_client:
        # MCP 도구를 포함한 에이전트 생성
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="You are a helpful assistant specializing in Microsoft documentation. Use the Microsoft Learn MCP server to search for accurate, up-to-date information. Always cite your sources.",
            tools=[
                {
                    "type": "mcp",
                    "server_label": "mslearn",
                    "server_url": "https://learn.microsoft.com/api/mcp",
                    "require_approval": "never"
                }
            ],
            tool_resources=None
        )
        print(f"Created agent, agent ID: {agent.id}")    
        
        # 대화 스레드 생성
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # 메시지 전송
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # 에이전트 실행
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # 완료 대기
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # 실행 단계 및 도구 호출 확인
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # 대화 내용 출력
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
```

## 자주 발생하는 문제 해결

### 1. 연결 문제
- MCP 서버 URL이 접근 가능한지 확인
- 인증 자격 증명 점검
- 네트워크 연결 상태 확인

### 2. 도구 호출 실패
- 도구 인자 및 형식 검토
- 서버별 요구사항 확인
- 적절한 오류 처리 구현

### 3. 성능 문제
- 도구 호출 빈도 최적화
- 적절한 캐싱 적용
- 서버 응답 시간 모니터링

## 다음 단계

MCP 통합을 더욱 향상시키려면:

1. **맞춤 MCP 서버 탐색**: 독자적인 데이터 소스를 위한 MCP 서버 구축
2. **고급 보안 구현**: OAuth2 또는 맞춤 인증 메커니즘 추가
3. **모니터링 및 분석**: 도구 사용에 대한 로깅 및 모니터링 구현
4. **솔루션 확장**: 부하 분산 및 분산 MCP 서버 아키텍처 고려

## 추가 자료

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## 지원

추가 지원 및 문의 사항은 다음을 참고하세요:
- [Azure AI Foundry documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [MCP community resources](https://modelcontextprotocol.io/)

## 다음은

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의하시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.