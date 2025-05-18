<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:54:54+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "tl"
}
-->
# Pag-deploy ng MCP Servers

Ang pag-deploy ng iyong MCP server ay nagbibigay-daan sa iba na ma-access ang mga tool at resources nito sa labas ng iyong lokal na kapaligiran. Mayroong ilang mga estratehiya sa pag-deploy na dapat isaalang-alang, depende sa iyong mga pangangailangan para sa scalability, reliability, at kadalian ng pamamahala. Makikita mo sa ibaba ang gabay para sa pag-deploy ng MCP servers sa lokal, sa mga container, at sa cloud.

## Pangkalahatang-ideya

Saklaw ng araling ito kung paano ide-deploy ang iyong MCP Server app.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Suriin ang iba't ibang paraan ng pag-deploy.
- I-deploy ang iyong app.

## Lokal na pag-develop at pag-deploy

Kung ang iyong server ay nilalayong gamitin sa pamamagitan ng pagtakbo sa mga makina ng mga user, maaari mong sundan ang mga sumusunod na hakbang:

1. **I-download ang server**. Kung hindi mo isinulat ang server, i-download muna ito sa iyong makina.
1. **Simulan ang proseso ng server**: Patakbuhin ang iyong MCP server application.

Para sa SSE (hindi kailangan para sa stdio type server)

1. **I-configure ang networking**: Tiyakin na ang server ay naa-access sa inaasahang port.
1. **Ikonekta ang mga kliyente**: Gumamit ng mga lokal na connection URLs tulad ng `http://localhost:3000`

## Pag-deploy sa Cloud

Maaaring i-deploy ang MCP servers sa iba't ibang cloud platforms:

- **Serverless Functions**: I-deploy ang magagaan na MCP servers bilang serverless functions.
- **Container Services**: Gamitin ang mga serbisyo tulad ng Azure Container Apps, AWS ECS, o Google Cloud Run.
- **Kubernetes**: I-deploy at pamahalaan ang MCP servers sa Kubernetes clusters para sa mataas na availability.

### Halimbawa: Azure Container Apps

Sinusuportahan ng Azure Container Apps ang pag-deploy ng MCP Servers. Patuloy pa itong inaayos at kasalukuyang sumusuporta sa SSE servers.

Narito kung paano mo ito magagawa:

1. I-clone ang repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Patakbuhin ito sa lokal upang masubukan:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Upang subukan ito sa lokal, gumawa ng *mcp.json* file sa isang *.vscode* directory at idagdag ang sumusunod na nilalaman:

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

  Kapag nasimulan na ang SSE server, maaari mong i-click ang play icon sa JSON file, dapat mo nang makita ang mga tool sa server na kinukuha ng GitHub Copilot, tingnan ang Tool icon.

1. Upang i-deploy, patakbuhin ang sumusunod na command:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Ayan na, i-deploy ito sa lokal, i-deploy ito sa Azure sa pamamagitan ng mga hakbang na ito.

## Karagdagang Mga Mapagkukunan

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Artikulo ng Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Ano ang Susunod

- Susunod: [Practical Implementation](/04-PracticalImplementation/README.md)

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Habang sinisikap namin ang katumpakan, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi tumpak na impormasyon. Ang orihinal na dokumento sa kanyang katutubong wika ay dapat ituring na mapagkakatiwalaang pinagmulan. Para sa kritikal na impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.