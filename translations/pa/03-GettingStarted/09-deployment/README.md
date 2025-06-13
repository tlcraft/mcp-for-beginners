<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:28:53+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "pa"
}
-->
# MCP ਸਰਵਰਾਂ ਦੀ ਤਾਇਨਾਤੀ

ਆਪਣੇ MCP ਸਰਵਰ ਨੂੰ ਤਾਇਨਾਤ ਕਰਨ ਨਾਲ ਹੋਰ ਲੋਕ ਇਸਦੇ ਟੂਲ ਅਤੇ ਸਰੋਤਾਂ ਤੱਕ ਤੁਹਾਡੇ ਲੋਕਲ ਵਾਤਾਵਰਨ ਤੋਂ ਬਾਹਰ ਵੀ ਪਹੁੰਚ ਸਕਦੇ ਹਨ। ਤੁਹਾਡੇ ਸਕੇਲਬਿਲਟੀ, ਭਰੋਸੇਯੋਗਤਾ ਅਤੇ ਪ੍ਰਬੰਧਨ ਦੀ ਸੌਖਿਆ ਅਨੁਸਾਰ ਵੱਖ-ਵੱਖ ਤਾਇਨਾਤੀ ਤਰੀਕੇ ਹਨ। ਹੇਠਾਂ ਤੁਸੀਂ MCP ਸਰਵਰਾਂ ਨੂੰ ਲੋਕਲ, ਕੰਟੇਨਰਾਂ ਵਿੱਚ ਅਤੇ ਕਲਾਉਡ 'ਚ ਤਾਇਨਾਤ ਕਰਨ ਲਈ ਮਦਦ ਮਿਲੇਗੀ।

## ਜਾਇਜ਼ਾ

ਇਸ ਪਾਠ ਵਿੱਚ ਤੁਸੀਂ ਸਿੱਖੋਗੇ ਕਿ MCP Server ਐਪ ਨੂੰ ਕਿਵੇਂ ਤਾਇਨਾਤ ਕਰਨਾ ਹੈ।

## ਸਿੱਖਣ ਦੇ ਉਦੇਸ਼

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- ਵੱਖ-ਵੱਖ ਤਾਇਨਾਤੀ ਤਰੀਕਿਆਂ ਦਾ ਮੁਲਾਂਕਣ ਕਰਨ ਲਈ।
- ਆਪਣੀ ਐਪ ਨੂੰ ਤਾਇਨਾਤ ਕਰਨ ਲਈ।

## ਲੋਕਲ ਵਿਕਾਸ ਅਤੇ ਤਾਇਨਾਤੀ

ਜੇ ਤੁਹਾਡਾ ਸਰਵਰ ਉਪਭੋਗਤਾਵਾਂ ਦੀ ਮਸ਼ੀਨ 'ਤੇ ਚਲਾਉਣ ਲਈ ਹੈ, ਤਾਂ ਤੁਸੀਂ ਹੇਠਾਂ ਦਿੱਤੇ ਕਦਮਾਂ ਦੀ ਪਾਲਣਾ ਕਰ ਸਕਦੇ ਹੋ:

1. **ਸਰਵਰ ਡਾਊਨਲੋਡ ਕਰੋ**। ਜੇ ਤੁਸੀਂ ਸਰਵਰ ਨਹੀਂ ਲਿਖਿਆ, ਤਾਂ ਪਹਿਲਾਂ ਇਸਨੂੰ ਆਪਣੀ ਮਸ਼ੀਨ 'ਤੇ ਡਾਊਨਲੋਡ ਕਰੋ।  
1. **ਸਰਵਰ ਪ੍ਰਕਿਰਿਆ ਸ਼ੁਰੂ ਕਰੋ**: ਆਪਣਾ MCP ਸਰਵਰ ਐਪਲੀਕੇਸ਼ਨ ਚਲਾਓ।

SSE ਲਈ (stdio ਕਿਸਮ ਦੇ ਸਰਵਰ ਲਈ ਲੋੜ ਨਹੀਂ)

1. **ਨੈੱਟਵਰਕਿੰਗ ਸੈਟ ਕਰੋ**: ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਸਰਵਰ ਉਮੀਦ ਕੀਤੇ ਪੋਰਟ 'ਤੇ ਪਹੁੰਚਯੋਗ ਹੈ।  
1. **ਕਲਾਇੰਟ ਕਨੈਕਟ ਕਰੋ**: ਲੋਕਲ ਕਨੈਕਸ਼ਨ URLs ਵਰਗੇ `http://localhost:3000` ਵਰਤੋਂ।

## ਕਲਾਉਡ ਤਾਇਨਾਤੀ

MCP ਸਰਵਰਾਂ ਨੂੰ ਵੱਖ-ਵੱਖ ਕਲਾਉਡ ਪਲੇਟਫਾਰਮਾਂ 'ਤੇ ਤਾਇਨਾਤ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ:

- **Serverless Functions**: ਹਲਕੇ MCP ਸਰਵਰਾਂ ਨੂੰ ਸਰਵਰਲੇਸ ਫੰਕਸ਼ਨਾਂ ਵਜੋਂ ਤਾਇਨਾਤ ਕਰੋ।  
- **Container Services**: Azure Container Apps, AWS ECS ਜਾਂ Google Cloud Run ਵਰਗੀਆਂ ਸੇਵਾਵਾਂ ਵਰਤੋ।  
- **Kubernetes**: ਉੱਚ ਉਪਲਬਧਤਾ ਲਈ MCP ਸਰਵਰਾਂ ਨੂੰ Kubernetes ਕਲੱਸਟਰਾਂ ਵਿੱਚ ਤਾਇਨਾਤ ਅਤੇ ਪ੍ਰਬੰਧਿਤ ਕਰੋ।

### ਉਦਾਹਰਨ: Azure Container Apps

Azure Container Apps MCP ਸਰਵਰਾਂ ਦੀ ਤਾਇਨਾਤ ਦਾ ਸਮਰਥਨ ਕਰਦਾ ਹੈ। ਇਹ ਹਾਲੇ ਵੀ ਵਿਕਾਸ ਅਧੀਨ ਹੈ ਅਤੇ ਇਸ ਵੇਲੇ SSE ਸਰਵਰਾਂ ਨੂੰ ਸਮਰਥਨ ਕਰਦਾ ਹੈ।

ਇਸਨੂੰ ਕਰਨ ਦਾ ਤਰੀਕਾ ਇਹ ਹੈ:

1. ਇੱਕ ਰਿਪੋ ਕਲੋਨ ਕਰੋ:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. ਟੈਸਟ ਕਰਨ ਲਈ ਲੋਕਲ ਚਲਾਓ:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. ਲੋਕਲ ਟੈਸਟ ਕਰਨ ਲਈ, *.vscode* ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ *mcp.json* ਫਾਈਲ ਬਣਾਓ ਅਤੇ ਹੇਠਾਂ ਦਿੱਤਾ ਸਮੱਗਰੀ ਸ਼ਾਮਿਲ ਕਰੋ:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  ਜਦੋਂ SSE ਸਰਵਰ ਸ਼ੁਰੂ ਹੋ ਜਾਵੇ, ਤਾਂ JSON ਫਾਈਲ ਵਿੱਚ ਪਲੇ ਆਈਕਨ 'ਤੇ ਕਲਿੱਕ ਕਰੋ, ਹੁਣ ਤੁਸੀਂ GitHub Copilot ਦੁਆਰਾ ਸਰਵਰ ਉੱਤੇ ਟੂਲ ਚੁਣੇ ਜਾਣਗੇ, Tool ਆਈਕਨ ਵੇਖੋ।

1. ਤਾਇਨਾਤ ਕਰਨ ਲਈ, ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾਓ:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

ਹੁਣ ਤੁਸੀਂ ਇਹ ਕਰ ਚੁੱਕੇ ਹੋ, ਲੋਕਲ ਤਾਇਨਾਤ ਕਰੋ ਜਾਂ ਇਨ੍ਹਾਂ ਕਦਮਾਂ ਰਾਹੀਂ Azure 'ਤੇ ਤਾਇਨਾਤ ਕਰੋ।

## ਵਾਧੂ ਸਰੋਤ

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)  
- [Azure Container Apps ਲੇਖ](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)  
- [Azure Container Apps MCP ਰਿਪੋ](https://github.com/anthonychu/azure-container-apps-mcp-sample)  

## ਅਗਲਾ ਕੀ ਹੈ

- ਅਗਲਾ: [ਪ੍ਰਾਇਕਟਿਕਲ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ](/04-PracticalImplementation/README.md)

**ਅਸਵੀਕਾਰੋਪੱਤਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਆਟੋਮੈਟਿਕ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਹੀਤਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਨਾਲ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਭ੍ਰਮਾਂ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।