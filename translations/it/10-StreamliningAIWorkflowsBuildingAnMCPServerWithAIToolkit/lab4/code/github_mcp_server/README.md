<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:09:19+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "it"
}
-->
# Server MCP Meteo

Questo è un esempio di Server MCP in Python che implementa strumenti meteo con risposte simulate. Può essere usato come base per il tuo Server MCP. Include le seguenti funzionalità:

- **Weather Tool**: uno strumento che fornisce informazioni meteo simulate in base alla posizione indicata.
- **Git Clone Tool**: uno strumento che clona un repository git in una cartella specificata.
- **VS Code Open Tool**: uno strumento che apre una cartella in VS Code o VS Code Insiders.
- **Connect to Agent Builder**: una funzione che consente di collegare il server MCP all’Agent Builder per test e debug.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: una funzione che permette di fare il debug del Server MCP usando MCP Inspector.

## Inizia con il template Weather MCP Server

> **Prerequisiti**
>
> Per eseguire il Server MCP sulla tua macchina di sviluppo locale, ti serviranno:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (necessario per lo strumento git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) o [VS Code Insiders](https://code.visualstudio.com/insiders/) (necessario per lo strumento open_in_vscode)
> - (*Opzionale - se preferisci uv*) [uv](https://github.com/astral-sh/uv)
> - [Estensione Python Debugger](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Preparare l’ambiente

Ci sono due modi per configurare l’ambiente per questo progetto. Puoi scegliere quello che preferisci.

> Nota: Ricarica VSCode o il terminale per assicurarti che venga usato il python dell’ambiente virtuale dopo averlo creato.

| Metodo | Passaggi |
| -------- | ----- |
| Usando `uv` | 1. Crea ambiente virtuale: `uv venv` <br>2. Esegui il comando di VSCode "***Python: Select Interpreter***" e seleziona il python dell’ambiente virtuale creato <br>3. Installa le dipendenze (comprese quelle di sviluppo): `uv pip install -r pyproject.toml --extra dev` |
| Usando `pip` | 1. Crea ambiente virtuale: `python -m venv .venv` <br>2. Esegui il comando di VSCode "***Python: Select Interpreter***" e seleziona il python dell’ambiente virtuale creato<br>3. Installa le dipendenze (comprese quelle di sviluppo): `pip install -e .[dev]` | 

Dopo aver configurato l’ambiente, puoi eseguire il server sulla tua macchina locale tramite Agent Builder come MCP Client per iniziare:
1. Apri il pannello Debug di VS Code. Seleziona `Debug in Agent Builder` oppure premi `F5` per avviare il debug del server MCP.
2. Usa AI Toolkit Agent Builder per testare il server con [questa richiesta](../../../../../../../../../../../open_prompt_builder). Il server si connetterà automaticamente all’Agent Builder.
3. Clicca `Run` per testare il server con la richiesta.

**Congratulazioni**! Hai eseguito con successo il Weather MCP Server sulla tua macchina locale tramite Agent Builder come MCP Client.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Cosa include il template

| Cartella / File | Contenuti                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | File VSCode per il debug                   |
| `.aitk`      | Configurazioni per AI Toolkit                |
| `src`        | Codice sorgente del server weather mcp   |

## Come fare il debug del Weather MCP Server

> Note:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) è uno strumento visivo per sviluppatori per testare e fare debug dei server MCP.
> - Tutte le modalità di debug supportano i breakpoint, quindi puoi aggiungerli al codice di implementazione degli strumenti.

## Strumenti disponibili

### Weather Tool
Lo strumento `get_weather` fornisce informazioni meteo simulate per una posizione specificata.

| Parametro | Tipo | Descrizione |
| --------- | ---- | ----------- |
| `location` | stringa | Posizione per cui ottenere il meteo (es. nome città, stato o coordinate) |

### Git Clone Tool
Lo strumento `git_clone_repo` clona un repository git in una cartella specificata.

| Parametro | Tipo | Descrizione |
| --------- | ---- | ----------- |
| `repo_url` | stringa | URL del repository git da clonare |
| `target_folder` | stringa | Percorso della cartella in cui clonare il repository |

Lo strumento restituisce un oggetto JSON con:
- `success`: Booleano che indica se l’operazione è riuscita
- `target_folder` o `error`: Il percorso del repository clonato o un messaggio di errore

### VS Code Open Tool
Lo strumento `open_in_vscode` apre una cartella nell’applicazione VS Code o VS Code Insiders.

| Parametro | Tipo | Descrizione |
| --------- | ---- | ----------- |
| `folder_path` | stringa | Percorso della cartella da aprire |
| `use_insiders` | booleano (opzionale) | Se usare VS Code Insiders invece della versione standard |

Lo strumento restituisce un oggetto JSON con:
- `success`: Booleano che indica se l’operazione è riuscita
- `message` o `error`: Messaggio di conferma o messaggio di errore

## Modalità Debug | Descrizione | Passaggi per il debug |
| ---------- | ----------- | --------------- |
| Agent Builder | Debug del server MCP in Agent Builder tramite AI Toolkit. | 1. Apri il pannello Debug di VS Code. Seleziona `Debug in Agent Builder` e premi `F5` per iniziare il debug del server MCP.<br>2. Usa AI Toolkit Agent Builder per testare il server con [questa richiesta](../../../../../../../../../../../open_prompt_builder). Il server si connetterà automaticamente all’Agent Builder.<br>3. Clicca `Run` per testare il server con la richiesta. |
| MCP Inspector | Debug del server MCP usando MCP Inspector. | 1. Installa [Node.js](https://nodejs.org/)<br> 2. Configura Inspector: `cd inspector` && `npm install` <br> 3. Apri il pannello Debug di VS Code. Seleziona `Debug SSE in Inspector (Edge)` o `Debug SSE in Inspector (Chrome)`. Premi F5 per iniziare il debug.<br> 4. Quando MCP Inspector si apre nel browser, clicca il pulsante `Connect` per connettere questo server MCP.<br> 5. Poi puoi `List Tools`, selezionare uno strumento, inserire parametri e `Run Tool` per fare il debug del codice del server.<br> |

## Porte predefinite e personalizzazioni

| Modalità Debug | Porte | Definizioni | Personalizzazioni | Nota |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Modifica [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) per cambiare le porte sopra. | N/A |
| MCP Inspector | 3001 (Server); 5173 e 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Modifica [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) per cambiare le porte sopra.| N/A |

## Feedback

Se hai feedback o suggerimenti per questo template, apri una issue nel [repository AI Toolkit su GitHub](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire l'accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non siamo responsabili per eventuali fraintendimenti o interpretazioni errate derivanti dall'uso di questa traduzione.