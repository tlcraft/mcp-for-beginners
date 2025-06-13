<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:31:29+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "tl"
}
-->
# Pag-deploy ng mga MCP Server

Ang pag-deploy ng iyong MCP server ay nagbibigay-daan sa iba na ma-access ang mga tools at resources nito lampas sa iyong lokal na kapaligiran. May iba't ibang estratehiya sa pag-deploy na maaari mong isaalang-alang, depende sa iyong pangangailangan para sa scalability, reliability, at kadalian sa pamamahala. Sa ibaba, makikita mo ang gabay para sa pag-deploy ng MCP servers nang lokal, sa containers, at sa cloud.

## Pangkalahatang-ideya

Tinuturo sa araling ito kung paano i-deploy ang iyong MCP Server app.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Suriin ang iba't ibang paraan ng pag-deploy.
- I-deploy ang iyong app.

## Lokal na pag-develop at pag-deploy

Kung ang iyong server ay gagamitin sa mga makina ng user, sundin ang mga sumusunod na hakbang:

1. **I-download ang server**. Kung hindi ikaw ang sumulat ng server, i-download muna ito sa iyong makina.  
1. **Simulan ang proseso ng server**: Patakbuhin ang iyong MCP server application.

Para sa SSE (hindi kailangan para sa stdio type server)

1. **I-configure ang networking**: Siguraduhing maa-access ang server sa inaasahang port.  
1. **Ikonekta ang mga kliyente**: Gumamit ng lokal na connection URLs tulad ng `http://localhost:3000`.

## Cloud Deployment

Maaaring i-deploy ang mga MCP server sa iba't ibang cloud platforms:

- **Serverless Functions**: I-deploy ang magagaan na MCP servers bilang serverless functions.  
- **Container Services**: Gumamit ng mga serbisyo tulad ng Azure Container Apps, AWS ECS, o Google Cloud Run.  
- **Kubernetes**: I-deploy at pamahalaan ang MCP servers sa Kubernetes clusters para sa mataas na availability.

### Halimbawa: Azure Container Apps

Sinusuportahan ng Azure Container Apps ang pag-deploy ng MCP Servers. Ito ay patuloy pang pinapaunlad at kasalukuyang sumusuporta sa SSE servers.

Ganito ang paraan:

1. I-clone ang repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Patakbuhin ito nang lokal para subukan:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Para subukan ito nang lokal, gumawa ng *mcp.json* file sa loob ng *.vscode* directory at idagdag ang sumusunod na nilalaman:

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

  Kapag nagsimula na ang SSE server, maaari mong i-click ang play icon sa JSON file; makikita mo na ang mga tools sa server ay nakikilala na ng GitHub Copilot, tingnan ang Tool icon.

1. Para i-deploy, patakbuhin ang sumusunod na command:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Ayan, i-deploy ito nang lokal o i-deploy sa Azure gamit ang mga hakbang na ito.

## Karagdagang Mga Mapagkukunan

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)  
- [Azure Container Apps article](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)  
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)  


## Ano ang Susunod

- Susunod: [Praktikal na Implementasyon](/04-PracticalImplementation/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagaman nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na nagmula sa paggamit ng pagsasaling ito.