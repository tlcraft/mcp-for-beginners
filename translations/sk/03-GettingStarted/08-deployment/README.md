<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:55:45+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "sk"
}
-->
# Nasadenie MCP serverov

Nasadenie vášho MCP servera umožňuje ostatným prístup k jeho nástrojom a zdrojom mimo vášho lokálneho prostredia. Existuje niekoľko stratégií nasadenia, ktoré je potrebné zvážiť, v závislosti od vašich požiadaviek na škálovateľnosť, spoľahlivosť a jednoduchosť správy. Nižšie nájdete odporúčania pre nasadenie MCP serverov lokálne, v kontajneroch a do cloudu.

## Prehľad

Táto lekcia sa zaoberá tým, ako nasadiť vašu aplikáciu MCP Server.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Zhodnotiť rôzne prístupy k nasadeniu.
- Nasadiť vašu aplikáciu.

## Lokálny vývoj a nasadenie

Ak je váš server určený na používanie na počítači používateľa, môžete postupovať podľa nasledujúcich krokov:

1. **Stiahnite server**. Ak ste server nepísali, najprv ho stiahnite do vášho počítača.
1. **Spustite proces servera**: Spustite vašu aplikáciu MCP servera.

Pre SSE (nie je potrebné pre server typu stdio)

1. **Nastavte sieťové pripojenie**: Uistite sa, že server je dostupný na očakávanom porte.
1. **Pripojte klientov**: Použite lokálne URL pre pripojenie ako `http://localhost:3000`.

## Nasadenie do cloudu

MCP servery môžu byť nasadené na rôzne cloudové platformy:

- **Bezserverové funkcie**: Nasadte ľahké MCP servery ako bezserverové funkcie.
- **Služby kontajnerov**: Použite služby ako Azure Container Apps, AWS ECS alebo Google Cloud Run.
- **Kubernetes**: Nasadte a spravujte MCP servery v Kubernetes klastroch pre vysokú dostupnosť.

### Príklad: Azure Container Apps

Azure Container Apps podporuje nasadenie MCP serverov. Je to stále vo vývoji a momentálne podporuje SSE servery.

Takto to môžete urobiť:

1. Klonujte repozitár:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Spustite ho lokálne na otestovanie:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Ak chcete skúsiť lokálne, vytvorte súbor *mcp.json* v adresári *.vscode* a pridajte nasledujúci obsah:

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

  Po spustení SSE servera môžete kliknúť na ikonu prehrávania v súbore JSON, mali by ste teraz vidieť, že nástroje na serveri sú vyzdvihnuté GitHub Copilotom, pozrite si ikonu nástroja.

1. Na nasadenie spustite nasledujúci príkaz:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

A máte to, nasadte to lokálne, nasadte to do Azure cez tieto kroky.

## Ďalšie zdroje

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Článok o Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Repozitár Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Čo ďalej

- Ďalej: [Praktická implementácia](/04-PracticalImplementation/README.md)

**Upozornenie**:  
Tento dokument bol preložený pomocou AI prekladovej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, upozorňujeme, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by sa mal považovať za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.