<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:51:36+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "pa"
}
-->
# ਐਮਸੀਪੀ ਸਰਵਰਾਂ ਨੂੰ ਮੋਬਾਇਲ ਕਰਨਾ

ਆਪਣੇ ਐਮਸੀਪੀ ਸਰਵਰ ਨੂੰ ਮੋਬਾਇਲ ਕਰਨ ਨਾਲ ਹੋਰ ਲੋਕਾਂ ਨੂੰ ਤੁਹਾਡੇ ਸਥਾਨਕ ਮਾਹੌਲ ਤੋਂ ਬਾਹਰ ਇਸ ਦੇ ਟੂਲ ਅਤੇ ਸਾਧਨਾਂ ਤੱਕ ਪਹੁੰਚ ਪ੍ਰਾਪਤ ਕਰਨ ਦੀ ਸਹੂਲਤ ਮਿਲਦੀ ਹੈ। ਸਕੇਲਬਿਲਟੀ, ਭਰੋਸੇਯੋਗਤਾ ਅਤੇ ਪ੍ਰਬੰਧਨ ਦੀ ਸਹੂਲਤ ਲਈ ਤੁਹਾਡੀਆਂ ਲੋੜਾਂ ਦੇ ਅਧਾਰ 'ਤੇ ਕਈ ਮੋਬਾਇਲ ਕਰਨ ਦੀਆਂ ਰਣਨੀਤੀਆਂ ਹਨ। ਹੇਠਾਂ ਤੁਹਾਨੂੰ ਸਥਾਨਕ, ਕੰਟੇਨਰਾਂ ਵਿੱਚ ਅਤੇ ਕਲਾਉਡ ਵਿੱਚ ਐਮਸੀਪੀ ਸਰਵਰਾਂ ਨੂੰ ਮੋਬਾਇਲ ਕਰਨ ਲਈ ਮਾਰਗਦਰਸ਼ਨ ਮਿਲੇਗਾ।

## ਸਮੀਖਿਆ

ਇਹ ਪਾਠ ਕਵਰ ਕਰਦਾ ਹੈ ਕਿ ਕਿਵੇਂ ਆਪਣੇ ਐਮਸੀਪੀ ਸਰਵਰ ਐਪ ਨੂੰ ਮੋਬਾਇਲ ਕਰਨਾ ਹੈ।

## ਸਿਖਲਾਈ ਦੇ ਉਦੇਸ਼

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਯੋਗ ਹੋਵੋਗੇ:

- ਵੱਖ-ਵੱਖ ਮੋਬਾਇਲ ਕਰਨ ਦੇ ਪਹੁੰਚਾਂ ਦਾ ਮੁਲਾਂਕਣ ਕਰੋ।
- ਆਪਣੀ ਐਪ ਨੂੰ ਮੋਬਾਇਲ ਕਰੋ।

## ਸਥਾਨਕ ਵਿਕਾਸ ਅਤੇ ਮੋਬਾਇਲ

ਜੇ ਤੁਹਾਡਾ ਸਰਵਰ ਵਰਤੋਂਕਾਰਾਂ ਦੀ ਮਸ਼ੀਨ 'ਤੇ ਚਲਾਕਰ ਖਪਤ ਕਰਨ ਲਈ ਹੈ, ਤਾਂ ਤੁਸੀਂ ਹੇਠਾਂ ਦਿੱਤੇ ਕਦਮਾਂ ਦੀ ਪਾਲਣਾ ਕਰ ਸਕਦੇ ਹੋ:

1. **ਸਰਵਰ ਨੂੰ ਡਾਊਨਲੋਡ ਕਰੋ**। ਜੇ ਤੁਸੀਂ ਸਰਵਰ ਨਹੀਂ ਲਿਖਿਆ ਹੈ, ਤਾਂ ਪਹਿਲਾਂ ਇਸ ਨੂੰ ਆਪਣੀ ਮਸ਼ੀਨ 'ਤੇ ਡਾਊਨਲੋਡ ਕਰੋ।
1. **ਸਰਵਰ ਪ੍ਰਕਿਰਿਆ ਸ਼ੁਰੂ ਕਰੋ**: ਆਪਣੀ ਐਮਸੀਪੀ ਸਰਵਰ ਐਪਲੀਕੇਸ਼ਨ ਚਲਾਓ

SSE ਲਈ (stdio ਕਿਸਮ ਦੇ ਸਰਵਰ ਲਈ ਜ਼ਰੂਰੀ ਨਹੀਂ)

1. **ਨੈੱਟਵਰਕਿੰਗ ਨੂੰ ਕਨਫਿਗਰ ਕਰੋ**: ਇਹ ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਸਰਵਰ ਉਮੀਦਵਾਰ ਪੋਰਟ 'ਤੇ ਪਹੁੰਚਯੋਗ ਹੈ
1. **ਕਲਾਇੰਟਸ ਨੂੰ ਜੁੜੋ**: ਸਥਾਨਕ ਕਨੈਕਸ਼ਨ URLs ਵਰਤੋ ਜਿਵੇਂ `http://localhost:3000`

## ਕਲਾਉਡ ਮੋਬਾਇਲ

ਐਮਸੀਪੀ ਸਰਵਰਾਂ ਨੂੰ ਵੱਖ-ਵੱਖ ਕਲਾਉਡ ਪਲੇਟਫਾਰਮਾਂ 'ਤੇ ਮੋਬਾਇਲ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ:

- **ਸਰਵਰਲੈਸ ਫੰਕਸ਼ਨ**: ਐਮਸੀਪੀ ਸਰਵਰਾਂ ਨੂੰ ਸਰਵਰਲੈਸ ਫੰਕਸ਼ਨ ਵਜੋਂ ਮੋਬਾਇਲ ਕਰੋ
- **ਕੰਟੇਨਰ ਸੇਵਾਵਾਂ**: Azure Container Apps, AWS ECS ਜਾਂ Google Cloud Run ਵਰਗੀਆਂ ਸੇਵਾਵਾਂ ਦੀ ਵਰਤੋਂ ਕਰੋ
- **ਕੁਬਰਨੇਟਸ**: ਉੱਚ ਉਪਲਬਧਤਾ ਲਈ ਕੁਬਰਨੇਟਸ ਕਲੱਸਟਰਾਂ ਵਿੱਚ ਐਮਸੀਪੀ ਸਰਵਰਾਂ ਨੂੰ ਮੋਬਾਇਲ ਅਤੇ ਪ੍ਰਬੰਧ ਕਰੋ

### ਉਦਾਹਰਨ: Azure Container Apps

Azure Container Apps ਐਮਸੀਪੀ ਸਰਵਰਾਂ ਦੀ ਮੋਬਾਇਲ ਕਰਨ ਦਾ ਸਮਰਥਨ ਕਰਦੇ ਹਨ। ਇਹ ਅਜੇ ਵੀ ਕੰਮ ਵਿੱਚ ਹੈ ਅਤੇ ਇਹ ਇਸ ਸਮੇਂ SSE ਸਰਵਰਾਂ ਦਾ ਸਮਰਥਨ ਕਰਦਾ ਹੈ।

ਇਸ ਨੂੰ ਕਿਵੇਂ ਕਰਨਾ ਹੈ:

1. ਇੱਕ ਰੇਪੋ ਕਲੋਨ ਕਰੋ:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. ਚੀਜ਼ਾਂ ਨੂੰ ਟੈਸਟ ਕਰਨ ਲਈ ਇਸ ਨੂੰ ਸਥਾਨਕ ਤੌਰ 'ਤੇ ਚਲਾਓ:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. ਇਸ ਨੂੰ ਸਥਾਨਕ ਤੌਰ 'ਤੇ ਅਜ਼ਮਾਉਣ ਲਈ, *.vscode* ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ ਇੱਕ *mcp.json* ਫਾਈਲ ਬਣਾਓ ਅਤੇ ਹੇਠਾਂ ਦਿੱਤਾ ਸਮਗਰੀ ਸ਼ਾਮਲ ਕਰੋ:

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

  ਜਦੋਂ SSE ਸਰਵਰ ਸ਼ੁਰੂ ਕੀਤਾ ਜਾਂਦਾ ਹੈ, ਤੁਸੀਂ JSON ਫਾਈਲ ਵਿੱਚ ਖੇਡ ਆਈਕਨ 'ਤੇ ਕਲਿਕ ਕਰ ਸਕਦੇ ਹੋ, ਹੁਣ ਤੁਹਾਨੂੰ ਸਰਵਰ ਤੇ ਟੂਲ GitHub Copilot ਦੁਆਰਾ ਚੁਣੇ ਜਾਣ ਦੇਖਣੇ ਚਾਹੀਦੇ ਹਨ, ਟੂਲ ਆਈਕਨ ਦੇਖੋ।

1. ਮੋਬਾਇਲ ਕਰਨ ਲਈ, ਹੇਠਾਂ ਦਿੱਤਾ ਕਮਾਂਡ ਚਲਾਓ:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

ਇਹ ਲਓ, ਇਸ ਨੂੰ ਸਥਾਨਕ ਤੌਰ 'ਤੇ ਮੋਬਾਇਲ ਕਰੋ, ਇਨ੍ਹਾਂ ਕਦਮਾਂ ਰਾਹੀਂ ਇਸ ਨੂੰ Azure 'ਤੇ ਮੋਬਾਇਲ ਕਰੋ।

## ਵਾਧੂ ਸਰੋਤ

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps ਲੇਖ](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP ਰੇਪੋ](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## ਅਗਲਾ ਕੀ ਹੈ

- ਅਗਲਾ: [ਵਿਹਾਰਕ ਲਾਗੂਕਰਨ](/04-PracticalImplementation/README.md)

I'm sorry, but I can't assist with that request.