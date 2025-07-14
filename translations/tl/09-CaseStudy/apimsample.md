<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:35:21+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "tl"
}
-->
# Case Study: I-expose ang REST API sa API Management bilang isang MCP server

Ang Azure API Management ay isang serbisyo na nagbibigay ng Gateway sa ibabaw ng iyong mga API Endpoints. Ang paraan ng pag-andar nito ay parang proxy ang Azure API Management sa harap ng iyong mga API at maaaring magdesisyon kung ano ang gagawin sa mga papasok na kahilingan.

Sa paggamit nito, makakakuha ka ng maraming mga tampok tulad ng:

- **Seguridad**, maaari mong gamitin ang lahat mula sa API keys, JWT hanggang sa managed identity.
- **Rate limiting**, isang mahusay na tampok na nagbibigay-daan upang magdesisyon kung ilang tawag ang papayagang makalusot sa loob ng isang takdang oras. Nakakatulong ito upang matiyak na lahat ng gumagamit ay may magandang karanasan at hindi rin mabibigatan ang iyong serbisyo ng mga kahilingan.
- **Scaling at Load balancing**. Maaari kang mag-set up ng ilang endpoints upang pantayin ang load at maaari mo ring piliin kung paano mag-"load balance".
- **Mga AI na tampok tulad ng semantic caching**, token limit at token monitoring at iba pa. Magagandang tampok ito na nagpapabuti ng pagiging mabilis ng tugon pati na rin tumutulong na masubaybayan ang iyong token na nagagastos. [Basahin pa dito](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Bakit MCP + Azure API Management?

Ang Model Context Protocol ay mabilis na nagiging pamantayan para sa mga agentic AI apps at kung paano i-expose ang mga tools at data sa isang pare-parehong paraan. Ang Azure API Management ay natural na pagpipilian kapag kailangan mong "pamahalaan" ang mga API. Madalas na nakikipag-integrate ang MCP Servers sa iba pang mga API upang lutasin ang mga kahilingan sa isang tool halimbawa. Kaya't ang pagsasama ng Azure API Management at MCP ay may malaking katuturan.

## Pangkalahatang-ideya

Sa partikular na paggamit na ito, matututuhan natin kung paano i-expose ang mga API endpoints bilang isang MCP Server. Sa paggawa nito, madali nating maisasama ang mga endpoints na ito bilang bahagi ng isang agentic app habang ginagamit din ang mga tampok mula sa Azure API Management.

## Pangunahing Mga Tampok

- Pinipili mo ang mga endpoint methods na nais mong i-expose bilang mga tools.
- Ang mga karagdagang tampok na makukuha mo ay nakadepende sa kung ano ang iyong i-configure sa policy section para sa iyong API. Ngunit dito ipapakita namin kung paano magdagdag ng rate limiting.

## Paunang Hakbang: mag-import ng API

Kung mayroon ka nang API sa Azure API Management, maganda, maaari mo nang laktawan ang hakbang na ito. Kung wala pa, tingnan ang link na ito, [pag-import ng API sa Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## I-expose ang API bilang MCP Server

Para i-expose ang mga API endpoints, sundin natin ang mga hakbang na ito:

1. Pumunta sa Azure Portal sa sumusunod na address <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Pumunta sa iyong API Management instance.

1. Sa kaliwang menu, piliin ang APIs > MCP Servers > + Create new MCP Server.

1. Sa API, piliin ang isang REST API na i-eexpose bilang MCP server.

1. Piliin ang isa o higit pang API Operations na i-eexpose bilang mga tools. Maaari mong piliin lahat ng operasyon o piling mga operasyon lamang.

    ![Select methods to expose](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Piliin ang **Create**.

1. Pumunta sa menu option na **APIs** at **MCP Servers**, makikita mo ang sumusunod:

    ![See the MCP Server in the main pane](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    Nabuo na ang MCP server at na-expose na bilang mga tools ang mga API operations. Nakalista ang MCP server sa MCP Servers pane. Ipinapakita ng URL column ang endpoint ng MCP server na maaari mong tawagan para sa testing o sa loob ng isang client application.

## Opsyonal: I-configure ang mga polisiya

Ang Azure API Management ay may pangunahing konsepto ng mga polisiya kung saan nagse-set up ka ng iba't ibang mga patakaran para sa iyong mga endpoints tulad ng rate limiting o semantic caching. Ang mga polisiya ay isinusulat sa XML.

Ganito ang paraan ng pag-set up ng polisiya para sa rate limiting ng iyong MCP Server:

1. Sa portal, sa ilalim ng APIs, piliin ang **MCP Servers**.

1. Piliin ang MCP server na iyong ginawa.

1. Sa kaliwang menu, sa ilalim ng MCP, piliin ang **Policies**.

1. Sa policy editor, idagdag o i-edit ang mga polisiya na nais mong ipatupad sa mga tools ng MCP server. Ang mga polisiya ay nakasaad sa XML format. Halimbawa, maaari kang magdagdag ng polisiya upang limitahan ang mga tawag sa mga tools ng MCP server (sa halimbawang ito, 5 tawag bawat 30 segundo kada client IP address). Narito ang XML na magpapatupad ng rate limiting:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Narito ang larawan ng policy editor:

    ![Policy editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Subukan ito

Tiyakin nating gumagana ang ating MCP Server ayon sa inaasahan.

Para dito, gagamit tayo ng Visual Studio Code at GitHub Copilot kasama ang Agent mode nito. Idadagdag natin ang MCP server sa isang *mcp.json* file. Sa paggawa nito, gagana ang Visual Studio Code bilang isang client na may agentic capabilities at makakapag-type ang mga end user ng prompt upang makipag-ugnayan sa nasabing server.

Tingnan natin kung paano idagdag ang MCP server sa Visual Studio Code:

1. Gamitin ang MCP: **Add Server command mula sa Command Palette**.

1. Kapag na-prompt, piliin ang uri ng server: **HTTP (HTTP o Server Sent Events)**.

1. Ilagay ang URL ng MCP server sa API Management. Halimbawa: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (para sa SSE endpoint) o **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (para sa MCP endpoint), tandaan ang pagkakaiba ng mga transport ay `/sse` o `/mcp`.

1. Ilagay ang server ID na iyong nais. Hindi ito mahalagang halaga ngunit makakatulong ito upang maalala mo kung ano ang instance ng server na ito.

1. Piliin kung saan ise-save ang configuration, sa workspace settings o user settings.

  - **Workspace settings** - Ang server configuration ay ise-save sa isang .vscode/mcp.json file na makikita lamang sa kasalukuyang workspace.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    o kung pipiliin mo ang streaming HTTP bilang transport, medyo iba ito:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User settings** - Ang server configuration ay idinadagdag sa iyong global *settings.json* file at makikita sa lahat ng workspaces. Ganito ang hitsura ng configuration:

    ![User setting](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Kailangan mo ring magdagdag ng configuration, isang header upang matiyak na tama ang authentication papunta sa Azure API Management. Gumagamit ito ng header na tinatawag na **Ocp-Apim-Subscription-Key**.

    - Ganito mo ito idinadagdag sa settings:

    ![Adding header for authentication](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), magpapakita ito ng prompt para hilingin ang API key value na makikita mo sa Azure Portal para sa iyong Azure API Management instance.

   - Para idagdag ito sa *mcp.json* sa halip, ganito ang paraan:

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

### Gamitin ang Agent mode

Handa na tayo sa settings o sa *.vscode/mcp.json*. Subukan natin ito.

Dapat mayroong Tools icon na ganito, kung saan nakalista ang mga exposed tools mula sa iyong server:

![Tools from the server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. I-click ang tools icon at makikita mo ang listahan ng mga tools na ganito:

    ![Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Maglagay ng prompt sa chat upang tawagin ang tool. Halimbawa, kung pumili ka ng tool para kumuha ng impormasyon tungkol sa isang order, maaari mong tanungin ang agent tungkol sa order. Narito ang halimbawa ng prompt:

    ```text
    get information from order 2
    ```

    Makikita mo ngayon ang tools icon na hihilingin sa iyo na ipagpatuloy ang pagtawag sa tool. Piliin ang pagpapatuloy ng pagpapatakbo ng tool, makikita mo na ngayon ang output na ganito:

    ![Result from prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **ang makikita mo sa itaas ay depende sa mga tools na na-setup mo, ngunit ang ideya ay makakakuha ka ng tekstuwal na tugon tulad ng nasa itaas**

## Mga Sanggunian

Ganito mo matututuhan pa nang higit:

- [Tutorial sa Azure API Management at MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python sample: Secure remote MCP servers gamit ang Azure API Management (experimental)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP client authorization lab](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Gamitin ang Azure API Management extension para sa VS Code upang mag-import at mag-manage ng mga API](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Magrehistro at mag-discover ng remote MCP servers sa Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Mahusay na repo na nagpapakita ng maraming AI capabilities gamit ang Azure API Management
- [AI Gateway workshops](https://azure-samples.github.io/AI-Gateway/) Naglalaman ng mga workshops gamit ang Azure Portal, na isang mahusay na paraan upang simulan ang pagsusuri ng mga AI capabilities.

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.