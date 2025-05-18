<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eaf9f1f29c86311674013505e9202f3",
  "translation_date": "2025-05-17T14:42:46+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/src/main/resources/static/images/sequence-diagram.md",
  "language_code": "vi"
}
-->
```mermaid
sequenceDiagram
    actor User
    participant WebApp as Web App<br/>(ContentSafetyController)
    participant SafetyService as Content Safety Service
    participant AzureAPI as Azure Content Safety API
    participant LangChain as LangChain4j
    participant McpClient as MCP Client
    participant McpServer as MCP Calculator Server<br/>(Port 8080)
    participant CalcService as Calculator Service

    %% User Interaction
    User->>WebApp: Enter calculation prompt
    WebApp->>WebApp: Create PromptRequest

    %% Content Safety Check
    WebApp->>SafetyService: processPrompt(prompt)
    SafetyService->>AzureAPI: analyzeText(prompt)
    AzureAPI-->>SafetyService: AnalyzeTextResult
    SafetyService->>SafetyService: Check if content is safe<br/>(severity < 2 for all categories)

    %% Processing Flow - Safe Content
    alt Content is safe
        SafetyService->>LangChain: Pass prompt to Bot.chat()
        LangChain->>McpClient: Process prompt
        McpClient->>McpServer: Call appropriate calculator tool via SSE
        McpServer->>CalcService: Execute calculation<br/>(add, subtract, multiply, etc.)
        CalcService-->>McpServer: Calculation result
        McpServer-->>McpClient: Tool execution result
        McpClient-->>LangChain: Tool result
        LangChain-->>SafetyService: Bot response
        SafetyService-->>WebApp: Return result map<br/>{isSafe: "true", botResponse: result, safetyResult: details}
        WebApp-->>User: Display calculation result and safety info
    else Content is unsafe
        SafetyService-->>WebApp: Return result map<br/>{isSafe: "false", safetyResult: details}
        WebApp-->>User: Display safety warning<br/>(without calculation)
    end
```Vui lòng viết đầu ra từ trái sang phải.

```mermaid
sequenceDiagram
    actor User
    participant WebApp as Web App<br/>(ContentSafetyController)
    participant SafetyService as Content Safety Service
    participant AzureAPI as Azure Content Safety API
    participant LangChain as LangChain4j
    participant McpClient as MCP Client
    participant McpServer as MCP Calculator Server<br/>(Port 8080)
    participant CalcService as Calculator Service

    %% User Interaction
    User->>WebApp: Enter calculation prompt
    WebApp->>WebApp: Create PromptRequest

    %% Content Safety Check
    WebApp->>SafetyService: processPrompt(prompt)
    SafetyService->>AzureAPI: analyzeText(prompt)
    AzureAPI-->>SafetyService: AnalyzeTextResult
    SafetyService->>SafetyService: Check if content is safe<br/>(severity < 2 for all categories)

    %% Processing Flow - Safe Content
    alt Content is safe
        SafetyService->>LangChain: Pass prompt to Bot.chat()
        LangChain->>McpClient: Process prompt
        McpClient->>McpServer: Call appropriate calculator tool via SSE
        McpServer->>CalcService: Execute calculation<br/>(add, subtract, multiply, etc.)
        CalcService-->>McpServer: Calculation result
        McpServer-->>McpClient: Tool execution result
        McpClient-->>LangChain: Tool result
        LangChain-->>SafetyService: Bot response
        SafetyService-->>WebApp: Return result map<br/>{isSafe: "true", botResponse: result, safetyResult: details}
        WebApp-->>User: Display calculation result and safety info
    else Content is unsafe
        SafetyService-->>WebApp: Return result map<br/>{isSafe: "false", safetyResult: details}
        WebApp-->>User: Display safety warning<br/>(without calculation)
    end
```

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn đáng tin cậy. Đối với thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm cho bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.