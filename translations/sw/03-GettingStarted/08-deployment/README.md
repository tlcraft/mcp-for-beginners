<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:55:07+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "sw"
}
-->
# Kuweka Seva za MCP

Kuweka seva yako ya MCP kunaruhusu wengine kupata zana na rasilimali zake nje ya mazingira yako ya ndani. Kuna mikakati kadhaa ya kuweka seva ambayo unaweza kuzingatia, kulingana na mahitaji yako ya upanuzi, kuegemea, na urahisi wa usimamizi. Hapa chini utapata mwongozo wa kuweka seva za MCP ndani ya nchi, kwenye kontena, na kwenye wingu.

## Muhtasari

Somu hili linashughulikia jinsi ya kuweka programu ya seva yako ya MCP.

## Malengo ya Kujifunza

Mwisho wa somu hili, utaweza:

- Kutathmini mbinu tofauti za kuweka seva.
- Kuweka programu yako.

## Maendeleo na uwekaji ndani ya nchi

Ikiwa seva yako inakusudiwa kutumiwa kwa kuendesha kwenye mashine ya mtumiaji, unaweza kufuata hatua zifuatazo:

1. **Pakua seva**. Ikiwa hujaandika seva, basi pakua kwanza kwenye mashine yako.
1. **Anzisha mchakato wa seva**: Endesha programu yako ya seva ya MCP

Kwa SSE (sio lazima kwa seva ya aina ya stdio)

1. **Sanidi mtandao**: Hakikisha seva inapatikana kwenye mlango unaotarajiwa
1. **Unganisha wateja**: Tumia URL za muunganisho wa ndani kama `http://localhost:3000`

## Uwekaji Wingu

Seva za MCP zinaweza kuwekwa kwenye majukwaa mbalimbali ya wingu:

- **Kazi zisizo na seva**: Weka seva za MCP nyepesi kama kazi zisizo na seva
- **Huduma za Kontena**: Tumia huduma kama Azure Container Apps, AWS ECS, au Google Cloud Run
- **Kubernetes**: Weka na usimamie seva za MCP katika vikundi vya Kubernetes kwa upatikanaji wa juu

### Mfano: Azure Container Apps

Azure Container Apps zinaunga mkono uwekaji wa seva za MCP. Bado ni kazi inayoendelea na kwa sasa inaunga mkono seva za SSE.

Hivi ndivyo unavyoweza kufanya:

1. Clone repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Endesha ndani ya nchi ili kujaribu mambo:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Ili kujaribu ndani ya nchi, unda faili *mcp.json* katika saraka ya *.vscode* na ongeza maudhui yafuatayo:

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

  Mara seva ya SSE itakapoanzishwa, unaweza kubofya ikoni ya kucheza kwenye faili ya JSON, sasa unapaswa kuona zana kwenye seva zikichukuliwa na GitHub Copilot, ona ikoni ya Zana.

1. Ili kuweka, endesha amri ifuatayo:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Hapo unayo, weka ndani ya nchi, weka kwenye Azure kupitia hatua hizi.

## Rasilimali Ziada

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Makala ya Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Repo ya Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Nini Kinachofuata

- Ifuatayo: [Utekelezaji wa Kivitendo](/04-PracticalImplementation/README.md)

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuelewana. Hati ya asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo chenye mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatutawajibika kwa kutokuelewana au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.