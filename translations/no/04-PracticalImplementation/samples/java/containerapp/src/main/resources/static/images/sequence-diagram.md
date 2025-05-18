<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eaf9f1f29c86311674013505e9202f3",
  "translation_date": "2025-05-17T14:41:20+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/src/main/resources/static/images/sequence-diagram.md",
  "language_code": "no"
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
```Vennligst skriv utdata fra venstre til høyre.

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

Certainly! Here's the translation of the text to Norwegian:

**Ansvarsfraskrivelse**: 
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på dets opprinnelige språk bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår fra bruken av denne oversettelsen.