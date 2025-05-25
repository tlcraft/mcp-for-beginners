<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:56:46+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "sl"
}
-->
# Postavitev MCP strežnikov

Postavitev vašega MCP strežnika omogoča drugim dostop do njegovih orodij in virov, ki presegajo vaš lokalni okolje. Obstaja več strategij postavitve, ki jih je treba upoštevati, odvisno od vaših zahtev glede razširljivosti, zanesljivosti in enostavnosti upravljanja. Spodaj boste našli navodila za postavitev MCP strežnikov lokalno, v kontejnerjih in v oblak.

## Pregled

Ta lekcija zajema, kako postaviti aplikacijo MCP strežnika.

## Cilji učenja

Do konca te lekcije boste sposobni:

- Oceniti različne pristope postavitve.
- Postaviti svojo aplikacijo.

## Lokalni razvoj in postavitev

Če je vaš strežnik namenjen uporabi na uporabnikovem računalniku, lahko sledite naslednjim korakom:

1. **Prenesite strežnik**. Če strežnika niste napisali sami, ga najprej prenesite na svoj računalnik.
1. **Zaženite proces strežnika**: Zaženite svojo aplikacijo MCP strežnika.

Za SSE (ni potrebno za strežnik tipa stdio)

1. **Konfigurirajte omrežje**: Poskrbite, da bo strežnik dostopen na pričakovanem portu.
1. **Povežite odjemalce**: Uporabite lokalne povezovalne URL-je kot `http://localhost:3000`.

## Postavitev v oblaku

MCP strežniki se lahko postavijo na različne platforme v oblaku:

- **Funkcije brez strežnika**: Postavite lahke MCP strežnike kot funkcije brez strežnika.
- **Storitev kontejnerjev**: Uporabite storitve, kot so Azure Container Apps, AWS ECS ali Google Cloud Run.
- **Kubernetes**: Postavite in upravljajte MCP strežnike v Kubernetes grozdih za visoko razpoložljivost.

### Primer: Azure Container Apps

Azure Container Apps podpirajo postavitev MCP strežnikov. To je še v delu in trenutno podpira SSE strežnike.

Tukaj je, kako lahko to storite:

1. Klonirajte repozitorij:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Zaženite ga lokalno, da preizkusite stvari:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Da ga preizkusite lokalno, ustvarite datoteko *mcp.json* v imeniku *.vscode* in dodajte naslednjo vsebino:

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

  Ko je SSE strežnik zagnan, lahko kliknete ikono za predvajanje v datoteki JSON, zdaj bi morali videti, da orodja na strežniku zazna GitHub Copilot, glejte ikono orodja.

1. Za postavitev zaženite naslednji ukaz:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Tukaj imate, postavite ga lokalno, postavite ga na Azure s temi koraki.

## Dodatni viri

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Članek o Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repozitorij](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Kaj sledi

- Naslednje: [Praktična izvedba](/04-PracticalImplementation/README.md)

**Izjava o omejitvi odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije priporočamo profesionalni človeški prevod. Ne prevzemamo odgovornosti za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.