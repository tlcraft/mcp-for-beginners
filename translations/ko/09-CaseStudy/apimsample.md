<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:28:06+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "ko"
}
-->
# 사례 연구: API Management에서 MCP 서버로 REST API 노출하기

Azure API Management는 API 엔드포인트 위에 게이트웨이를 제공하는 서비스입니다. 작동 방식은 Azure API Management가 API 앞에서 프록시 역할을 하며 들어오는 요청에 대해 어떻게 처리할지 결정할 수 있다는 점입니다.

이를 사용하면 다음과 같은 다양한 기능을 추가할 수 있습니다:

- **보안**: API 키, JWT, 관리형 ID 등 다양한 인증 방식을 사용할 수 있습니다.
- **요청 제한**: 일정 시간 단위로 허용되는 호출 수를 제한할 수 있어, 모든 사용자가 원활한 경험을 할 수 있고 서비스가 과부하되지 않도록 도와줍니다.
- **스케일링 및 부하 분산**: 여러 엔드포인트를 설정해 부하를 분산시키고, 부하 분산 방식을 직접 선택할 수 있습니다.
- **AI 기능**: 의미 기반 캐싱, 토큰 제한 및 모니터링 등 반응성을 높이고 토큰 사용량을 관리하는 데 유용한 기능들이 포함되어 있습니다. [자세히 읽기](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## 왜 MCP + Azure API Management인가?

Model Context Protocol은 에이전트형 AI 앱과 도구 및 데이터를 일관되게 노출하는 표준으로 빠르게 자리잡고 있습니다. API를 "관리"해야 할 때 Azure API Management는 자연스러운 선택입니다. MCP 서버는 종종 다른 API와 통합되어 도구에 대한 요청을 처리하기 때문입니다. 따라서 Azure API Management와 MCP를 결합하는 것은 매우 합리적입니다.

## 개요

이번 사례에서는 API 엔드포인트를 MCP 서버로 노출하는 방법을 배웁니다. 이를 통해 해당 엔드포인트를 에이전트형 앱의 일부로 쉽게 활용할 수 있으며, Azure API Management의 다양한 기능도 함께 이용할 수 있습니다.

## 주요 기능

- 노출할 엔드포인트 메서드를 선택할 수 있습니다.
- 추가 기능은 API 정책 섹션에서 설정한 내용에 따라 달라집니다. 여기서는 요청 제한(rate limiting)을 추가하는 방법을 보여드립니다.

## 사전 단계: API 가져오기

이미 Azure API Management에 API가 있다면 이 단계를 건너뛰어도 좋습니다. 없다면, [Azure API Management에 API 가져오기](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api) 링크를 참고하세요.

## API를 MCP 서버로 노출하기

API 엔드포인트를 노출하려면 다음 단계를 따르세요:

1. Azure 포털에 접속한 후 <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp> 주소로 이동하여 API Management 인스턴스로 이동합니다.

1. 왼쪽 메뉴에서 APIs > MCP Servers > + Create new MCP Server를 선택합니다.

1. API에서 MCP 서버로 노출할 REST API를 선택합니다.

1. 도구로 노출할 하나 이상의 API 작업(Operation)을 선택합니다. 모든 작업을 선택하거나 특정 작업만 선택할 수 있습니다.

    ![노출할 메서드 선택](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. **Create**를 선택합니다.

1. 메뉴에서 **APIs**와 **MCP Servers**로 이동하면 다음과 같이 표시됩니다:

    ![메인 창에서 MCP 서버 확인](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP 서버가 생성되고 API 작업이 도구로 노출됩니다. MCP 서버는 MCP Servers 창에 목록으로 나타나며, URL 열에는 테스트나 클라이언트 애플리케이션에서 호출할 수 있는 MCP 서버의 엔드포인트가 표시됩니다.

## 선택 사항: 정책 구성

Azure API Management는 정책이라는 핵심 개념이 있어, 요청 제한이나 의미 기반 캐싱 같은 다양한 규칙을 엔드포인트에 설정할 수 있습니다. 이 정책은 XML 형식으로 작성됩니다.

MCP 서버에 요청 제한 정책을 설정하는 방법은 다음과 같습니다:

1. 포털에서 APIs 아래의 **MCP Servers**를 선택합니다.

1. 생성한 MCP 서버를 선택합니다.

1. 왼쪽 메뉴에서 MCP 아래의 **Policies**를 선택합니다.

1. 정책 편집기에서 MCP 서버 도구에 적용할 정책을 추가하거나 수정합니다. 정책은 XML 형식으로 정의됩니다. 예를 들어, 클라이언트 IP 주소별로 30초당 5회 호출로 제한하는 정책을 추가할 수 있습니다. 다음은 요청 제한을 적용하는 XML 예시입니다:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    정책 편집기 화면은 다음과 같습니다:

    ![정책 편집기](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## 사용해보기

MCP 서버가 의도한 대로 작동하는지 확인해봅시다.

이를 위해 Visual Studio Code와 GitHub Copilot의 Agent 모드를 사용합니다. MCP 서버를 *mcp.json*에 추가하면 Visual Studio Code가 에이전트 기능을 가진 클라이언트 역할을 하며, 최종 사용자가 프롬프트를 입력해 서버와 상호작용할 수 있습니다.

Visual Studio Code에 MCP 서버를 추가하는 방법은 다음과 같습니다:

1. 명령 팔레트에서 MCP: **Add Server 명령어**를 실행합니다.

1. 서버 유형을 선택하라는 메시지가 뜨면 **HTTP (HTTP 또는 Server Sent Events)**를 선택합니다.

1. API Management에 있는 MCP 서버의 URL을 입력합니다. 예: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (SSE 엔드포인트용) 또는 **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (MCP 엔드포인트용). 전송 방식에 따라 `/sse` 또는 `/mcp`가 차이점입니다.

1. 원하는 서버 ID를 입력합니다. 중요한 값은 아니지만 서버 인스턴스를 기억하는 데 도움이 됩니다.

1. 구성 저장 위치를 작업 공간 설정 또는 사용자 설정 중 선택합니다.

  - **작업 공간 설정** - 서버 구성이 현재 작업 공간에서만 사용 가능한 .vscode/mcp.json 파일에 저장됩니다.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    스트리밍 HTTP 전송 방식을 선택하면 약간 다르게 나타납니다:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **사용자 설정** - 서버 구성이 전역 *settings.json* 파일에 추가되어 모든 작업 공간에서 사용 가능합니다. 구성 예시는 다음과 같습니다:

    ![사용자 설정](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Azure API Management에 올바르게 인증되도록 헤더를 추가해야 합니다. **Ocp-Apim-Subscription-Key**라는 헤더를 사용합니다.

    - 설정에 추가하는 방법은 다음과 같습니다:

    ![인증용 헤더 추가](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png)  
    이 작업을 하면 API 키 값을 입력하라는 프롬프트가 표시되며, Azure 포털에서 Azure API Management 인스턴스의 키를 확인할 수 있습니다.

   - *mcp.json*에 추가하려면 다음과 같이 작성할 수 있습니다:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Agent 모드 사용하기

이제 설정 또는 *.vscode/mcp.json*에 모두 준비가 되었습니다. 사용해봅시다.

서버에서 노출한 도구들이 다음과 같이 도구 아이콘에 표시됩니다:

![서버 도구](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. 도구 아이콘을 클릭하면 다음과 같이 도구 목록이 나타납니다:

    ![도구 목록](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. 채팅에 프롬프트를 입력해 도구를 호출합니다. 예를 들어 주문 정보를 가져오는 도구를 선택했다면, 에이전트에게 주문에 대해 물어볼 수 있습니다. 예시 프롬프트는 다음과 같습니다:

    ```text
    get information from order 2
    ```

    도구 아이콘이 나타나 도구 실행을 계속할지 묻습니다. 계속 실행을 선택하면 다음과 같은 출력 결과를 볼 수 있습니다:

    ![프롬프트 결과](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **위 결과는 설정한 도구에 따라 다르지만, 기본적으로 위와 같은 텍스트 응답을 받게 됩니다.**


## 참고 자료

더 알아보고 싶다면 다음을 참고하세요:

- [Azure API Management와 MCP 튜토리얼](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python 샘플: Azure API Management를 이용한 보안 원격 MCP 서버 (실험적)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP 클라이언트 권한 부여 실습](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [VS Code용 Azure API Management 확장 기능으로 API 가져오기 및 관리하기](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Azure API Center에서 원격 MCP 서버 등록 및 검색](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Azure API Management와 함께 다양한 AI 기능을 보여주는 훌륭한 저장소
- [AI Gateway 워크숍](https://azure-samples.github.io/AI-Gateway/) Azure 포털을 사용한 워크숍으로 AI 기능 평가를 시작하기에 좋은 자료

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의해 주시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.