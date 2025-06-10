<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:29:18+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "it"
}
-->
# Server MCP Meteo

Questo è un esempio di Server MCP in Python che implementa strumenti meteo con risposte simulate. Può essere usato come base per il tuo Server MCP. Include le seguenti funzionalità:

- **Weather Tool**: uno strumento che fornisce informazioni meteo simulate in base alla posizione indicata.
- **Connessione a Agent Builder**: una funzionalità che permette di collegare il server MCP ad Agent Builder per test e debug.
- **Debug con [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: una funzionalità che consente di fare il debug del Server MCP usando MCP Inspector.

## Iniziare con il template Weather MCP Server

> **Prerequisiti**
>
> Per eseguire il Server MCP sulla tua macchina di sviluppo locale, ti serviranno:
>
> - [Python](https://www.python.org/)
> - (*Opzionale - se preferisci uv*) [uv](https://github.com/astral-sh/uv)
> - [Estensione Python Debugger](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Preparare l’ambiente

Ci sono due modi per configurare l’ambiente per questo progetto. Puoi scegliere quello che preferisci.

> Nota: Ricarica VSCode o il terminale per assicurarti che venga usato il python dell’ambiente virtuale dopo averlo creato.

| Metodo | Passaggi |
| -------- | ----- |
| Usando `uv` | 1. Crea l’ambiente virtuale: `uv venv` <br>2. Esegui il comando VSCode "***Python: Select Interpreter***" e seleziona il python dell’ambiente virtuale creato <br>3. Installa le dipendenze (incluse quelle di sviluppo): `uv pip install -r pyproject.toml --extra dev` |
| Usando `pip` | 1. Crea l’ambiente virtuale: `python -m venv .venv` <br>2. Esegui il comando VSCode "***Python: Select Interpreter***" e seleziona il python dell’ambiente virtuale creato<br>3. Installa le dipendenze (incluse quelle di sviluppo): `pip install -e .[dev]` |

Dopo aver configurato l’ambiente, puoi avviare il server sulla tua macchina locale tramite Agent Builder come MCP Client per iniziare:
1. Apri il pannello Debug di VS Code. Seleziona `Debug in Agent Builder` oppure premi `F5` per avviare il debug del server MCP.
2. Usa AI Toolkit Agent Builder per testare il server con [questo prompt](../../../../../../../../../../../open_prompt_builder). Il server si collegherà automaticamente ad Agent Builder.
3. Clicca `Run` per testare il server con il prompt.

**Congratulazioni**! Hai eseguito con successo il Weather MCP Server sulla tua macchina locale tramite Agent Builder come MCP Client.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Cosa include il template

| Cartella / File | Contenuti                                  |
| ------------ | -------------------------------------------- |
| `.vscode`    | File di VSCode per il debug                   |
| `.aitk`      | Configurazioni per AI Toolkit                |
| `src`        | Codice sorgente del server weather mcp       |

## Come fare il debug del Weather MCP Server

> Note:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) è uno strumento visivo per sviluppatori per testare e fare debug dei server MCP.
> - Tutte le modalità di debug supportano i breakpoint, quindi puoi aggiungere breakpoint nel codice degli strumenti.

| Modalità di Debug | Descrizione | Passaggi per il debug |
| ---------- | ----------- | --------------- |
| Agent Builder | Debug del server MCP in Agent Builder tramite AI Toolkit. | 1. Apri il pannello Debug di VS Code. Seleziona `Debug in Agent Builder` e premi `F5` per avviare il debug del server MCP.<br>2. Usa AI Toolkit Agent Builder per testare il server con [questo prompt](../../../../../../../../../../../open_prompt_builder). Il server si collegherà automaticamente ad Agent Builder.<br>3. Clicca `Run` per testare il server con il prompt. |
| MCP Inspector | Debug del server MCP usando MCP Inspector. | 1. Installa [Node.js](https://nodejs.org/)<br> 2. Configura Inspector: `cd inspector` && `npm install` <br> 3. Apri il pannello Debug di VS Code. Seleziona `Debug SSE in Inspector (Edge)` o `Debug SSE in Inspector (Chrome)`. Premi F5 per avviare il debug.<br> 4. Quando MCP Inspector si apre nel browser, clicca il pulsante `Connect` per collegare questo server MCP.<br> 5. A questo punto puoi `List Tools`, selezionare uno strumento, inserire i parametri e `Run Tool` per fare il debug del codice del server.<br> |

## Porte predefinite e personalizzazioni

| Modalità di Debug | Porte | Definizioni | Personalizzazioni | Nota |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Modifica [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) per cambiare le porte sopra indicate. | N/A |
| MCP Inspector | 3001 (Server); 5173 e 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Modifica [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) per cambiare le porte sopra indicate. | N/A |

## Feedback

Se hai feedback o suggerimenti per questo template, apri una issue nel [repository AI Toolkit GitHub](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda la traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.