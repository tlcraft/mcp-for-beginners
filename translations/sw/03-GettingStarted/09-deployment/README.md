<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:31:38+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "sw"
}
-->
# Deploying MCP Servers

Kupeleka seva yako ya MCP kunaruhusu wengine kufikia zana na rasilimali zake zaidi ya mazingira yako ya ndani. Kuna mikakati kadhaa ya kupeleka seva kulingana na mahitaji yako ya kuongeza wigo, kuaminika, na urahisi wa usimamizi. Hapa chini utapata mwongozo wa kupeleka seva za MCP kwa njia ya ndani, ndani ya kontena, na kwenye wingu.

## Muhtasari

Somo hili linashughulikia jinsi ya kupeleka programu yako ya MCP Server.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kutathmini mbinu tofauti za kupeleka.
- Kupeleka programu yako.

## Maendeleo na Upelekaji wa Ndani

Kama seva yako inakusudiwa kutumiwa kwa kuendeshwa kwenye mashine za watumiaji, unaweza kufuata hatua zifuatazo:

1. **Pakua seva**. Ikiwa hujaunda seva hiyo, pakua kwanza kwenye mashine yako.
1. **Anzisha mchakato wa seva**: Endesha programu yako ya MCP server

Kwa SSE (sio lazima kwa seva ya aina ya stdio)

1. **Sanidi mtandao**: Hakikisha seva inapatikana kwenye bandari inayotarajiwa
1. **Unganisha wateja**: Tumia URL za muunganisho wa ndani kama `http://localhost:3000`

## Upelekaji Wingu

Seva za MCP zinaweza kupelekwa kwenye majukwaa mbalimbali ya wingu:

- **Serverless Functions**: Peleka seva za MCP nyepesi kama serverless functions
- **Huduma za Kontena**: Tumia huduma kama Azure Container Apps, AWS ECS, au Google Cloud Run
- **Kubernetes**: Peleka na simamia seva za MCP kwenye makundi ya Kubernetes kwa upatikanaji wa juu

### Mfano: Azure Container Apps

Azure Container Apps zinaunga mkono upelezaji wa seva za MCP. Hii bado ni kazi inayoendelea na kwa sasa zinaunga mkono seva za SSE.

Hapa ni jinsi unavyoweza kuifanya:

1. Nakili repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Endesha ndani ya mashine yako kujaribu mambo:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Ili kujaribu ndani ya mashine, tengeneza faili *mcp.json* katika saraka ya *.vscode* na ongeza maudhui yafuatayo:

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

  Mara seva ya SSE itakapozinduliwa, unaweza kubofya ikoni ya play kwenye faili la JSON, sasa utaona zana kwenye seva zikichukuliwa na GitHub Copilot, angalia ikoni ya Zana.

1. Ili kupeleka, endesha amri ifuatayo:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Hivyo ndivyo unavyoweza kupeleka ndani ya mashine yako, au kwenye Azure kupitia hatua hizi.

## Rasilimali Zaidi

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps article](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)


## Kinachofuata

- Ifuatayo: [Practical Implementation](/04-PracticalImplementation/README.md)

**Kandido**:  
Hati hii imetafsiriwa kwa kutumia huduma ya utafsiri wa AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upotovu wa maana. Hati ya asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inashauriwa. Hatuna wajibu wowote kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.