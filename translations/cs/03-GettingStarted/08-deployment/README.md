<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:55:32+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "cs"
}
-->
# Nasazení MCP serverů

Nasazení vašeho MCP serveru umožňuje ostatním přístup k jeho nástrojům a zdrojům mimo vaše lokální prostředí. Existuje několik strategií nasazení, které je třeba zvážit v závislosti na vašich požadavcích na škálovatelnost, spolehlivost a snadnost správy. Níže najdete pokyny pro nasazení MCP serverů lokálně, v kontejnerech a do cloudu.

## Přehled

Tato lekce pokrývá, jak nasadit vaši aplikaci MCP Server.

## Cíle učení

Na konci této lekce budete schopni:

- Vyhodnotit různé přístupy k nasazení.
- Nasadit svou aplikaci.

## Lokální vývoj a nasazení

Pokud je váš server určen k použití na uživatelském počítači, můžete postupovat podle následujících kroků:

1. **Stáhněte server**. Pokud jste server nenapsali, stáhněte jej nejprve na svůj počítač.
2. **Spusťte proces serveru**: Spusťte svou aplikaci MCP serveru.

Pro SSE (není potřeba pro server typu stdio)

1. **Nakonfigurujte síť**: Ujistěte se, že server je přístupný na očekávaném portu.
2. **Připojte klienty**: Použijte lokální připojovací URL jako `http://localhost:3000`.

## Nasazení do cloudu

MCP servery mohou být nasazeny na různé cloudové platformy:

- **Bezserverové funkce**: Nasazení lehkých MCP serverů jako bezserverových funkcí.
- **Služby kontejnerů**: Použijte služby jako Azure Container Apps, AWS ECS nebo Google Cloud Run.
- **Kubernetes**: Nasazení a správa MCP serverů v Kubernetes klastrech pro vysokou dostupnost.

### Příklad: Azure Container Apps

Azure Container Apps podporují nasazení MCP serverů. Stále se pracuje na jeho vývoji a aktuálně podporuje SSE servery.

Jak na to:

1. Klonujte repozitář:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

2. Spusťte ho lokálně pro otestování:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

3. Pro vyzkoušení lokálně vytvořte soubor *mcp.json* ve složce *.vscode* a přidejte následující obsah:

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

  Jakmile je SSE server spuštěn, můžete kliknout na ikonu přehrávání v JSON souboru, nyní byste měli vidět nástroje na serveru, které jsou zachyceny GitHub Copilotem, viz ikona Nástroje.

4. Pro nasazení spusťte následující příkaz:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

A je to, nasadit lokálně, nasadit do Azure podle těchto kroků.

## Další zdroje

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Článek Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Repozitář Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Co dál

- Další: [Praktická implementace](/04-PracticalImplementation/README.md)

**Prohlášení**:  
Tento dokument byl přeložen pomocí služby AI překladatele [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme zodpovědní za jakékoli nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.