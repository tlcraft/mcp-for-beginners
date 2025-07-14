<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:29:49+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "pa"
}
-->
# ਕੇਸ ਅਧਿਐਨ: API Management ਵਿੱਚ REST API ਨੂੰ MCP ਸਰਵਰ ਵਜੋਂ ਪ੍ਰਗਟ ਕਰੋ

Azure API Management ਇੱਕ ਸੇਵਾ ਹੈ ਜੋ ਤੁਹਾਡੇ API Endpoints ਦੇ ਉੱਪਰ ਇੱਕ ਗੇਟਵੇ ਪ੍ਰਦਾਨ ਕਰਦੀ ਹੈ। ਇਹ ਇਸ ਤਰ੍ਹਾਂ ਕੰਮ ਕਰਦਾ ਹੈ ਕਿ Azure API Management ਤੁਹਾਡੇ APIs ਦੇ ਸਾਹਮਣੇ ਇੱਕ ਪ੍ਰਾਕਸੀ ਵਾਂਗ ਕੰਮ ਕਰਦਾ ਹੈ ਅਤੇ ਆਉਣ ਵਾਲੀਆਂ ਬੇਨਤੀਆਂ ਨਾਲ ਕੀ ਕਰਨਾ ਹੈ, ਇਹ ਫੈਸਲਾ ਕਰ ਸਕਦਾ ਹੈ।

ਇਸਦਾ ਉਪਯੋਗ ਕਰਕੇ, ਤੁਸੀਂ ਕਈ ਫੀਚਰ ਜੋੜ ਸਕਦੇ ਹੋ ਜਿਵੇਂ ਕਿ:

- **ਸੁਰੱਖਿਆ**, ਤੁਸੀਂ API keys, JWT ਤੋਂ ਲੈ ਕੇ managed identity ਤੱਕ ਹਰ ਚੀਜ਼ ਵਰਤ ਸਕਦੇ ਹੋ।
- **ਰੇਟ ਲਿਮਿਟਿੰਗ**, ਇਹ ਇੱਕ ਵਧੀਆ ਫੀਚਰ ਹੈ ਜਿਸ ਨਾਲ ਤੁਸੀਂ ਨਿਰਧਾਰਤ ਸਮੇਂ ਵਿੱਚ ਕਿੰਨੀ ਕਾਲਾਂ ਹੋਣੀਆਂ ਚਾਹੀਦੀਆਂ ਹਨ, ਇਹ ਫੈਸਲਾ ਕਰ ਸਕਦੇ ਹੋ। ਇਸ ਨਾਲ ਯੂਜ਼ਰਾਂ ਨੂੰ ਵਧੀਆ ਅਨੁਭਵ ਮਿਲਦਾ ਹੈ ਅਤੇ ਤੁਹਾਡੀ ਸੇਵਾ ਬੇਨਤੀਆਂ ਨਾਲ ਓਵਰਲੋਡ ਨਹੀਂ ਹੁੰਦੀ।
- **ਸਕੇਲਿੰਗ ਅਤੇ ਲੋਡ ਬੈਲੈਂਸਿੰਗ**। ਤੁਸੀਂ ਕਈ endpoints ਸੈੱਟ ਕਰਕੇ ਲੋਡ ਨੂੰ ਬੈਲੈਂਸ ਕਰ ਸਕਦੇ ਹੋ ਅਤੇ ਇਹ ਵੀ ਫੈਸਲਾ ਕਰ ਸਕਦੇ ਹੋ ਕਿ "ਲੋਡ ਬੈਲੈਂਸ" ਕਿਵੇਂ ਕਰਨਾ ਹੈ।
- **AI ਫੀਚਰ ਜਿਵੇਂ semantic caching**, ਟੋਕਨ ਲਿਮਿਟ ਅਤੇ ਟੋਕਨ ਮਾਨੀਟਰਿੰਗ ਆਦਿ। ਇਹ ਵਧੀਆ ਫੀਚਰ ਹਨ ਜੋ ਜਵਾਬਦੇਹੀ ਵਿੱਚ ਸੁਧਾਰ ਕਰਦੇ ਹਨ ਅਤੇ ਤੁਹਾਡੇ ਟੋਕਨ ਖਰਚ 'ਤੇ ਨਜ਼ਰ ਰੱਖਣ ਵਿੱਚ ਮਦਦ ਕਰਦੇ ਹਨ। [ਇੱਥੇ ਹੋਰ ਪੜ੍ਹੋ](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities)।

## MCP + Azure API Management ਕਿਉਂ?

Model Context Protocol ਤੇਜ਼ੀ ਨਾਲ ਏਜੰਟਿਕ AI ਐਪਸ ਲਈ ਇੱਕ ਮਿਆਰੀ ਤਰੀਕਾ ਬਣ ਰਿਹਾ ਹੈ ਜਿਸ ਨਾਲ ਟੂਲ ਅਤੇ ਡਾਟਾ ਨੂੰ ਇੱਕਸਾਰ ਢੰਗ ਨਾਲ ਪ੍ਰਗਟ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ। ਜਦੋਂ ਤੁਹਾਨੂੰ APIs "ਮੈਨੇਜ" ਕਰਨੇ ਹੁੰਦੇ ਹਨ ਤਾਂ Azure API Management ਇੱਕ ਕੁਦਰਤੀ ਚੋਣ ਹੈ। MCP Servers ਅਕਸਰ ਹੋਰ APIs ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਹੁੰਦੇ ਹਨ ਤਾਂ ਜੋ ਬੇਨਤੀਆਂ ਨੂੰ ਕਿਸੇ ਟੂਲ ਤੱਕ ਹੱਲ ਕੀਤਾ ਜਾ ਸਕੇ। ਇਸ ਲਈ Azure API Management ਅਤੇ MCP ਨੂੰ ਮਿਲਾ ਕੇ ਵਰਤਣਾ ਬਹੁਤ ਸਮਝਦਾਰੀ ਵਾਲਾ ਹੈ।

## ਓਵਰਵਿਊ

ਇਸ ਖਾਸ ਕੇਸ ਵਿੱਚ ਅਸੀਂ ਸਿੱਖਾਂਗੇ ਕਿ API endpoints ਨੂੰ MCP Server ਵਜੋਂ ਕਿਵੇਂ ਪ੍ਰਗਟ ਕਰਨਾ ਹੈ। ਇਸ ਤਰ੍ਹਾਂ, ਅਸੀਂ ਇਹ endpoints ਇੱਕ ਏਜੰਟਿਕ ਐਪ ਦਾ ਹਿੱਸਾ ਬਣਾ ਸਕਦੇ ਹਾਂ ਅਤੇ ਨਾਲ ਹੀ Azure API Management ਦੇ ਫੀਚਰਾਂ ਦਾ ਲਾਭ ਵੀ ਲੈ ਸਕਦੇ ਹਾਂ।

## ਮੁੱਖ ਫੀਚਰ

- ਤੁਸੀਂ ਉਹ endpoint ਮੈਥਡ ਚੁਣਦੇ ਹੋ ਜੋ ਤੁਸੀਂ ਟੂਲ ਵਜੋਂ ਪ੍ਰਗਟ ਕਰਨਾ ਚਾਹੁੰਦੇ ਹੋ।
- ਤੁਹਾਨੂੰ ਮਿਲਣ ਵਾਲੇ ਵਾਧੂ ਫੀਚਰ ਤੁਹਾਡੇ API ਦੀ ਨੀਤੀ ਸੈਕਸ਼ਨ ਵਿੱਚ ਕੀ ਕਨਫਿਗਰ ਕੀਤਾ ਹੈ, ਇਸ 'ਤੇ ਨਿਰਭਰ ਕਰਦੇ ਹਨ। ਪਰ ਇੱਥੇ ਅਸੀਂ ਦਿਖਾਵਾਂਗੇ ਕਿ ਕਿਵੇਂ ਰੇਟ ਲਿਮਿਟਿੰਗ ਜੋੜੀ ਜਾ ਸਕਦੀ ਹੈ।

## ਪਹਿਲਾ ਕਦਮ: API ਇੰਪੋਰਟ ਕਰੋ

ਜੇ ਤੁਹਾਡੇ ਕੋਲ ਪਹਿਲਾਂ ਹੀ Azure API Management ਵਿੱਚ API ਹੈ ਤਾਂ ਵਧੀਆ, ਤੁਸੀਂ ਇਹ ਕਦਮ ਛੱਡ ਸਕਦੇ ਹੋ। ਨਹੀਂ ਤਾਂ, ਇਸ ਲਿੰਕ ਨੂੰ ਵੇਖੋ, [Azure API Management ਵਿੱਚ API ਇੰਪੋਰਟ ਕਰਨਾ](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api)।

## API ਨੂੰ MCP Server ਵਜੋਂ ਪ੍ਰਗਟ ਕਰੋ

API endpoints ਨੂੰ ਪ੍ਰਗਟ ਕਰਨ ਲਈ, ਇਹ ਕਦਮ ਫੋਲੋ ਕਰੋ:

1. Azure Portal ਤੇ ਜਾਓ ਅਤੇ ਇਸ ਪਤੇ ਤੇ ਜਾਓ <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
ਆਪਣੇ API Management ਇੰਸਟੈਂਸ ਤੇ ਜਾਓ।

1. ਖੱਬੇ ਮੀਨੂ ਵਿੱਚ, APIs > MCP Servers > + Create new MCP Server ਚੁਣੋ।

1. API ਵਿੱਚ, ਇੱਕ REST API ਚੁਣੋ ਜਿਸਨੂੰ MCP ਸਰਵਰ ਵਜੋਂ ਪ੍ਰਗਟ ਕਰਨਾ ਹੈ।

1. ਇੱਕ ਜਾਂ ਵੱਧ API Operations ਚੁਣੋ ਜੋ ਤੁਸੀਂ ਟੂਲ ਵਜੋਂ ਪ੍ਰਗਟ ਕਰਨਾ ਚਾਹੁੰਦੇ ਹੋ। ਤੁਸੀਂ ਸਾਰੇ ਓਪਰੇਸ਼ਨ ਜਾਂ ਸਿਰਫ਼ ਕੁਝ ਖਾਸ ਓਪਰੇਸ਼ਨ ਚੁਣ ਸਕਦੇ ਹੋ।

    ![Select methods to expose](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. **Create** 'ਤੇ ਕਲਿੱਕ ਕਰੋ।

1. ਮੀਨੂ ਵਿੱਚ **APIs** ਅਤੇ **MCP Servers** ਤੇ ਜਾਓ, ਤੁਹਾਨੂੰ ਇਹ ਦਿਖਾਈ ਦੇਵੇਗਾ:

    ![See the MCP Server in the main pane](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP ਸਰਵਰ ਬਣ ਗਿਆ ਹੈ ਅਤੇ API ਓਪਰੇਸ਼ਨ ਟੂਲ ਵਜੋਂ ਪ੍ਰਗਟ ਕੀਤੇ ਗਏ ਹਨ। MCP ਸਰਵਰ MCP Servers ਪੈਨ ਵਿੱਚ ਲਿਸਟ ਕੀਤਾ ਗਿਆ ਹੈ। URL ਕਾਲਮ MCP ਸਰਵਰ ਦਾ endpoint ਦਿਖਾਉਂਦਾ ਹੈ ਜਿਸਨੂੰ ਤੁਸੀਂ ਟੈਸਟਿੰਗ ਜਾਂ ਕਲਾਇੰਟ ਐਪਲੀਕੇਸ਼ਨ ਵਿੱਚ ਕਾਲ ਕਰ ਸਕਦੇ ਹੋ।

## ਵਿਕਲਪਿਕ: ਨੀਤੀਆਂ ਕਨਫਿਗਰ ਕਰੋ

Azure API Management ਵਿੱਚ ਨੀਤੀਆਂ ਦਾ ਮੁੱਖ ਸੰਕਲਪ ਹੁੰਦਾ ਹੈ ਜਿੱਥੇ ਤੁਸੀਂ ਆਪਣੇ endpoints ਲਈ ਵੱਖ-ਵੱਖ ਨਿਯਮ ਸੈੱਟ ਕਰਦੇ ਹੋ, ਜਿਵੇਂ ਕਿ ਰੇਟ ਲਿਮਿਟਿੰਗ ਜਾਂ semantic caching। ਇਹ ਨੀਤੀਆਂ XML ਵਿੱਚ ਲਿਖੀਆਂ ਜਾਂਦੀਆਂ ਹਨ।

ਇੱਥੇ ਦਿਖਾਇਆ ਗਿਆ ਹੈ ਕਿ ਕਿਵੇਂ ਤੁਸੀਂ MCP Server ਲਈ ਰੇਟ ਲਿਮਿਟ ਨੀਤੀ ਸੈੱਟ ਕਰ ਸਕਦੇ ਹੋ:

1. ਪੋਰਟਲ ਵਿੱਚ, APIs ਹੇਠਾਂ **MCP Servers** ਚੁਣੋ।

1. ਉਸ MCP ਸਰਵਰ ਨੂੰ ਚੁਣੋ ਜੋ ਤੁਸੀਂ ਬਣਾਇਆ ਹੈ।

1. ਖੱਬੇ ਮੀਨੂ ਵਿੱਚ, MCP ਹੇਠਾਂ **Policies** ਚੁਣੋ।

1. ਨੀਤੀ ਸੰਪਾਦਕ ਵਿੱਚ, ਉਹ ਨੀਤੀਆਂ ਜੋੜੋ ਜਾਂ ਸੋਧੋ ਜੋ ਤੁਸੀਂ MCP ਸਰਵਰ ਦੇ ਟੂਲਾਂ 'ਤੇ ਲਾਗੂ ਕਰਨਾ ਚਾਹੁੰਦੇ ਹੋ। ਨੀਤੀਆਂ XML ਫਾਰਮੈਟ ਵਿੱਚ ਹੁੰਦੀਆਂ ਹਨ। ਉਦਾਹਰਨ ਵਜੋਂ, ਤੁਸੀਂ ਇੱਕ ਨੀਤੀ ਜੋੜ ਸਕਦੇ ਹੋ ਜੋ MCP ਸਰਵਰ ਦੇ ਟੂਲਾਂ ਲਈ ਕਾਲਾਂ ਨੂੰ ਸੀਮਿਤ ਕਰੇ (ਇਸ ਉਦਾਹਰਨ ਵਿੱਚ, 30 ਸਕਿੰਟ ਵਿੱਚ ਪ੍ਰਤੀ ਕਲਾਇੰਟ IP ਪਤਾ 5 ਕਾਲਾਂ)। ਇਹ XML ਇਸ ਤਰ੍ਹਾਂ ਹੋਵੇਗੀ:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    ਨੀਤੀ ਸੰਪਾਦਕ ਦੀ ਇੱਕ ਤਸਵੀਰ:

    ![Policy editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)

## ਇਸਨੂੰ ਅਜ਼ਮਾਓ

ਆਓ ਯਕੀਨੀ ਬਣਾਈਏ ਕਿ ਸਾਡਾ MCP Server ਠੀਕ ਤਰ੍ਹਾਂ ਕੰਮ ਕਰ ਰਿਹਾ ਹੈ।

ਇਸ ਲਈ ਅਸੀਂ Visual Studio Code ਅਤੇ GitHub Copilot ਦੇ Agent ਮੋਡ ਦੀ ਵਰਤੋਂ ਕਰਾਂਗੇ। ਅਸੀਂ MCP ਸਰਵਰ ਨੂੰ *mcp.json* ਵਿੱਚ ਜੋੜਾਂਗੇ। ਇਸ ਤਰ੍ਹਾਂ, Visual Studio Code ਇੱਕ ਏਜੰਟਿਕ ਕਲਾਇੰਟ ਵਜੋਂ ਕੰਮ ਕਰੇਗਾ ਅਤੇ ਅੰਤਮ ਯੂਜ਼ਰ ਪ੍ਰਾਂਪਟ ਟਾਈਪ ਕਰਕੇ ਇਸ ਸਰਵਰ ਨਾਲ ਇੰਟਰੈਕਟ ਕਰ ਸਕਣਗੇ।

Visual Studio Code ਵਿੱਚ MCP ਸਰਵਰ ਜੋੜਨ ਦਾ ਤਰੀਕਾ:

1. Command Palette ਤੋਂ MCP: **Add Server command** ਵਰਤੋ।

1. ਜਦੋਂ ਪੁੱਛਿਆ ਜਾਵੇ, ਸਰਵਰ ਦੀ ਕਿਸਮ ਚੁਣੋ: **HTTP (HTTP ਜਾਂ Server Sent Events)**।

1. API Management ਵਿੱਚ MCP ਸਰਵਰ ਦਾ URL ਦਿਓ। ਉਦਾਹਰਨ: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (SSE endpoint ਲਈ) ਜਾਂ **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (MCP endpoint ਲਈ), ਧਿਆਨ ਦਿਓ ਕਿ ਟ੍ਰਾਂਸਪੋਰਟ ਵਿੱਚ ਫਰਕ `/sse` ਜਾਂ `/mcp` ਹੈ।

1. ਆਪਣੀ ਪਸੰਦ ਦਾ ਸਰਵਰ ID ਦਿਓ। ਇਹ ਕੋਈ ਮਹੱਤਵਪੂਰਨ ਮੁੱਲ ਨਹੀਂ ਹੈ ਪਰ ਇਹ ਤੁਹਾਨੂੰ ਯਾਦ ਰੱਖਣ ਵਿੱਚ ਮਦਦ ਕਰੇਗਾ ਕਿ ਇਹ ਸਰਵਰ ਇੰਸਟੈਂਸ ਕੀ ਹੈ।

1. ਚੁਣੋ ਕਿ ਤੁਸੀਂ ਕਨਫਿਗਰੇਸ਼ਨ ਨੂੰ ਆਪਣੇ ਵਰਕਸਪੇਸ ਸੈਟਿੰਗਜ਼ ਜਾਂ ਯੂਜ਼ਰ ਸੈਟਿੰਗਜ਼ ਵਿੱਚ ਸੇਵ ਕਰਨਾ ਚਾਹੁੰਦੇ ਹੋ।

  - **ਵਰਕਸਪੇਸ ਸੈਟਿੰਗਜ਼** - ਸਰਵਰ ਕਨਫਿਗਰੇਸ਼ਨ ਸਿਰਫ਼ ਮੌਜੂਦਾ ਵਰਕਸਪੇਸ ਵਿੱਚ ਉਪਲਬਧ .vscode/mcp.json ਫਾਈਲ ਵਿੱਚ ਸੇਵ ਹੁੰਦੀ ਹੈ।

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    ਜਾਂ ਜੇ ਤੁਸੀਂ ਸਟ੍ਰੀਮਿੰਗ HTTP ਟ੍ਰਾਂਸਪੋਰਟ ਚੁਣਦੇ ਹੋ ਤਾਂ ਇਹ ਕੁਝ ਵੱਖਰਾ ਹੋਵੇਗਾ:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **ਯੂਜ਼ਰ ਸੈਟਿੰਗਜ਼** - ਸਰਵਰ ਕਨਫਿਗਰੇਸ਼ਨ ਤੁਹਾਡੇ ਗਲੋਬਲ *settings.json* ਫਾਈਲ ਵਿੱਚ ਜੋੜੀ ਜਾਂਦੀ ਹੈ ਅਤੇ ਸਾਰੇ ਵਰਕਸਪੇਸ ਵਿੱਚ ਉਪਲਬਧ ਹੁੰਦੀ ਹੈ। ਕਨਫਿਗਰੇਸ਼ਨ ਕੁਝ ਇਸ ਤਰ੍ਹਾਂ ਦਿਖਾਈ ਦੇਂਦੀ ਹੈ:

    ![User setting](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. ਤੁਹਾਨੂੰ ਇੱਕ ਹੈਡਰ ਵੀ ਜੋੜਨਾ ਪਵੇਗਾ ਤਾਂ ਜੋ ਇਹ Azure API Management ਵੱਲ ਸਹੀ ਤਰੀਕੇ ਨਾਲ ਪ੍ਰਮਾਣਿਤ ਹੋ ਸਕੇ। ਇਹ ਹੈਡਰ **Ocp-Apim-Subscription-Key** ਕਹਿੰਦਾ ਹੈ।

    - ਸੈਟਿੰਗਜ਼ ਵਿੱਚ ਇਸਨੂੰ ਜੋੜਨ ਦਾ ਤਰੀਕਾ:

    ![Adding header for authentication](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png)  
    ਇਸ ਨਾਲ ਇੱਕ ਪ੍ਰਾਂਪਟ ਆਵੇਗਾ ਜੋ ਤੁਹਾਡੇ ਕੋਲ API key ਦਾ ਮੁੱਲ ਮੰਗੇਗਾ ਜੋ ਤੁਸੀਂ Azure Portal ਵਿੱਚ ਆਪਣੇ Azure API Management ਇੰਸਟੈਂਸ ਲਈ ਲੱਭ ਸਕਦੇ ਹੋ।

   - *mcp.json* ਵਿੱਚ ਇਸਨੂੰ ਜੋੜਨ ਲਈ, ਤੁਸੀਂ ਇਸ ਤਰ੍ਹਾਂ ਕਰ ਸਕਦੇ ਹੋ:

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

### Agent ਮੋਡ ਦੀ ਵਰਤੋਂ ਕਰੋ

ਹੁਣ ਅਸੀਂ ਸੈਟਿੰਗਜ਼ ਜਾਂ *.vscode/mcp.json* ਵਿੱਚ ਸੈਟਅਪ ਹੋ ਚੁੱਕੇ ਹਾਂ। ਆਓ ਇਸਨੂੰ ਅਜ਼ਮਾਈਏ।

ਇੱਥੇ ਇੱਕ Tools ਆਈਕਨ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ, ਜਿੱਥੇ ਤੁਹਾਡੇ ਸਰਵਰ ਤੋਂ ਪ੍ਰਗਟ ਕੀਤੇ ਟੂਲਾਂ ਦੀ ਸੂਚੀ ਹੋਵੇਗੀ:

![Tools from the server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Tools ਆਈਕਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ ਅਤੇ ਤੁਹਾਨੂੰ ਟੂਲਾਂ ਦੀ ਸੂਚੀ ਦਿਖਾਈ ਦੇਵੇਗੀ:

    ![Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. ਚੈਟ ਵਿੱਚ ਪ੍ਰਾਂਪਟ ਦਿਓ ਟੂਲ ਨੂੰ ਕਾਲ ਕਰਨ ਲਈ। ਉਦਾਹਰਨ ਵਜੋਂ, ਜੇ ਤੁਸੀਂ ਕਿਸੇ ਆਰਡਰ ਬਾਰੇ ਜਾਣਕਾਰੀ ਲੈਣ ਲਈ ਟੂਲ ਚੁਣਿਆ ਹੈ, ਤਾਂ ਤੁਸੀਂ ਏਜੰਟ ਨੂੰ ਆਰਡਰ ਬਾਰੇ ਪੁੱਛ ਸਕਦੇ ਹੋ। ਇਹ ਇੱਕ ਉਦਾਹਰਨ ਪ੍ਰਾਂਪਟ ਹੈ:

    ```text
    get information from order 2
    ```

    ਹੁਣ ਤੁਹਾਨੂੰ ਇੱਕ ਟੂਲ ਆਈਕਨ ਦਿੱਸੇਗਾ ਜੋ ਤੁਹਾਨੂੰ ਟੂਲ ਕਾਲ ਕਰਨ ਲਈ ਆਗਿਆ ਦੇਵੇਗਾ। ਚਲਾਉਣਾ ਜਾਰੀ ਰੱਖੋ, ਤੁਹਾਨੂੰ ਨਤੀਜਾ ਇਸ ਤਰ੍ਹਾਂ ਦਿਖਾਈ ਦੇਵੇਗਾ:

    ![Result from prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **ਤੁਹਾਨੂੰ ਜੋ ਉੱਪਰ ਦਿੱਸ ਰਿਹਾ ਹੈ, ਉਹ ਤੁਹਾਡੇ ਸੈੱਟ ਕੀਤੇ ਟੂਲਾਂ 'ਤੇ ਨਿਰਭਰ ਕਰਦਾ ਹੈ, ਪਰ ਮਕਸਦ ਇਹ ਹੈ ਕਿ ਤੁਹਾਨੂੰ ਇੱਕ ਲਿਖਤੀ ਜਵਾਬ ਮਿਲੇ।**

## ਸੰਦਰਭ

ਹੋਰ ਜਾਣਕਾਰੀ ਲਈ:

- [Azure API Management ਅਤੇ MCP 'ਤੇ ਟਿਊਟੋਰਿਯਲ](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python ਨਮੂਨਾ: Azure API Management ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਸੁਰੱਖਿਅਤ ਰਿਮੋਟ MCP ਸਰਵਰ (ਪ੍ਰਯੋਗਾਤਮਕ)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP ਕਲਾਇੰਟ ਅਥਾਰਾਈਜ਼ੇਸ਼ਨ ਲੈਬ](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [VS Code ਲਈ Azure API Management ਐਕਸਟੈਂਸ਼ਨ ਦੀ ਵਰਤੋਂ ਕਰਕੇ APIs ਇੰਪੋਰਟ ਅਤੇ ਮੈਨੇਜ ਕਰੋ](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Azure API Center ਵਿੱਚ ਰਿਮੋਟ MCP ਸਰਵਰਾਂ ਨੂੰ ਰਜਿਸਟਰ ਅਤੇ ਖੋਜੋ](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) ਵਧੀਆ ਰਿਪੋ ਜੋ Azure API Management ਨਾਲ ਕਈ AI ਸਮਰੱਥਾਵਾਂ ਦਿਖਾਉਂਦਾ ਹੈ
- [AI Gateway ਵਰਕਸ਼ਾਪ](https://azure-samples.github.io/AI-Gateway/) ਜਿਸ ਵਿੱਚ Azure Portal ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਵਰਕਸ਼ਾਪ ਹਨ, ਜੋ AI ਸਮਰੱਥਾਵਾਂ ਦਾ ਮੁਲਾਂਕਣ ਕਰਨ ਦਾ ਵਧੀਆ ਤਰੀਕਾ ਹੈ।

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।