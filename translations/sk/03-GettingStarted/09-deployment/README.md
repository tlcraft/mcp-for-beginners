<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d9dc83260576b76f272d330ed93c51f",
  "translation_date": "2025-07-04T18:43:23+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "sk"
}
-->
# Nasadenie MCP serverov

Nasadenie vášho MCP servera umožňuje ostatným prístup k jeho nástrojom a zdrojom mimo vášho lokálneho prostredia. Existuje niekoľko stratégií nasadenia, ktoré treba zvážiť v závislosti od vašich požiadaviek na škálovateľnosť, spoľahlivosť a jednoduchosť správy. Nižšie nájdete pokyny na nasadenie MCP serverov lokálne, v kontajneroch a do cloudu.

## Prehľad

Táto lekcia pokrýva, ako nasadiť vašu MCP Server aplikáciu.

## Ciele učenia

Na konci tejto lekcie budete vedieť:

- Zhodnotiť rôzne prístupy k nasadeniu.
- Nasadiť vašu aplikáciu.

## Lokálny vývoj a nasadenie

Ak je váš server určený na používanie priamo na počítači používateľa, môžete postupovať podľa týchto krokov:

1. **Stiahnite server**. Ak ste server nenapísali vy, najprv si ho stiahnite do svojho počítača.  
1. **Spustite serverový proces**: Spustite vašu MCP serverovú aplikáciu.

Pre SSE (nie je potrebné pre stdio typ servera)

1. **Nakonfigurujte sieť**: Uistite sa, že server je dostupný na očakávanom porte.  
1. **Pripojte klientov**: Použite lokálne URL adresy ako `http://localhost:3000`.

## Nasadenie do cloudu

MCP servery je možné nasadiť na rôzne cloudové platformy:

- **Serverless Functions**: Nasadzujte ľahké MCP servery ako serverless funkcie.  
- **Container Services**: Použite služby ako Azure Container Apps, AWS ECS alebo Google Cloud Run.  
- **Kubernetes**: Nasadzujte a spravujte MCP servery v Kubernetes klastroch pre vysokú dostupnosť.

### Príklad: Azure Container Apps

Azure Container Apps podporujú nasadenie MCP serverov. Projekt je stále vo vývoji a momentálne podporuje SSE servery.

Tu je postup, ako na to:

1. Naklonujte repozitár:

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

1. Ak chcete skúsiť lokálne, vytvorte súbor *mcp.json* v priečinku *.vscode* a pridajte nasledujúci obsah:

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

  Po spustení SSE servera môžete kliknúť na ikonu prehrávania v JSON súbore, teraz by ste mali vidieť, že nástroje na serveri sú rozpoznané GitHub Copilotom, pozrite si ikonu nástroja.

1. Na nasadenie spustite nasledujúci príkaz:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

A je to, nasadíte ho lokálne alebo do Azure podľa týchto krokov.

## Dodatočné zdroje

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)  
- [Článok o Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)  
- [Azure Container Apps MCP repozitár](https://github.com/anthonychu/azure-container-apps-mcp-sample)  

## Čo bude ďalej

- Ďalej: [Praktická implementácia](../../04-PracticalImplementation/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.