<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:30:50+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "it"
}
-->
# Caso di studio: Esporre REST API in API Management come server MCP

Azure API Management è un servizio che fornisce un Gateway sopra i tuoi endpoint API. Il suo funzionamento consiste nel fatto che Azure API Management agisce come un proxy davanti alle tue API e può decidere cosa fare con le richieste in arrivo.

Utilizzandolo, aggiungi una serie di funzionalità come:

- **Sicurezza**, puoi usare tutto, dalle chiavi API, JWT all'identità gestita.
- **Limitazione della frequenza**, una funzionalità molto utile è poter decidere quante chiamate possono passare in una certa unità di tempo. Questo aiuta a garantire una buona esperienza a tutti gli utenti e anche a evitare che il tuo servizio venga sovraccaricato di richieste.
- **Scalabilità e bilanciamento del carico**. Puoi configurare diversi endpoint per bilanciare il carico e puoi anche decidere come effettuare il "bilanciamento del carico".
- **Funzionalità AI come semantic caching**, limite di token, monitoraggio dei token e altro. Sono ottime funzionalità che migliorano la reattività e ti aiutano a tenere sotto controllo la spesa dei token. [Leggi di più qui](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Perché MCP + Azure API Management?

Model Context Protocol sta rapidamente diventando uno standard per le app AI agentiche e per esporre strumenti e dati in modo coerente. Azure API Management è una scelta naturale quando hai bisogno di "gestire" API. I server MCP spesso si integrano con altre API per risolvere richieste verso uno strumento, per esempio. Quindi combinare Azure API Management e MCP ha molto senso.

## Panoramica

In questo caso d’uso specifico impareremo a esporre endpoint API come server MCP. Facendo così, possiamo facilmente rendere questi endpoint parte di un’app agentica sfruttando anche le funzionalità di Azure API Management.

## Funzionalità principali

- Selezioni i metodi degli endpoint che vuoi esporre come strumenti.
- Le funzionalità aggiuntive dipendono da cosa configuri nella sezione policy per la tua API. Qui ti mostreremo come aggiungere la limitazione della frequenza.

## Passo preliminare: importare un’API

Se hai già un’API in Azure API Management, ottimo, puoi saltare questo passaggio. Altrimenti, dai un’occhiata a questo link, [importare un’API in Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Esporre API come server MCP

Per esporre gli endpoint API, segui questi passaggi:

1. Vai al Portale Azure all’indirizzo <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Naviga alla tua istanza di API Management.

1. Nel menu a sinistra, seleziona APIs > MCP Servers > + Crea nuovo MCP Server.

1. In API, seleziona una REST API da esporre come server MCP.

1. Seleziona una o più operazioni API da esporre come strumenti. Puoi selezionare tutte le operazioni o solo alcune specifiche.

    ![Seleziona i metodi da esporre](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Seleziona **Crea**.

1. Vai al menu **APIs** e **MCP Servers**, dovresti vedere quanto segue:

    ![Visualizza il server MCP nel pannello principale](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    Il server MCP è stato creato e le operazioni API sono esposte come strumenti. Il server MCP è elencato nel pannello MCP Servers. La colonna URL mostra l’endpoint del server MCP che puoi chiamare per test o all’interno di un’applicazione client.

## Opzionale: Configurare le policy

Azure API Management ha il concetto fondamentale di policy, dove imposti regole diverse per i tuoi endpoint, come per esempio la limitazione della frequenza o il semantic caching. Queste policy sono scritte in XML.

Ecco come puoi configurare una policy per limitare la frequenza del tuo server MCP:

1. Nel portale, sotto APIs, seleziona **MCP Servers**.

1. Seleziona il server MCP che hai creato.

1. Nel menu a sinistra, sotto MCP, seleziona **Policies**.

1. Nell’editor delle policy, aggiungi o modifica le policy che vuoi applicare agli strumenti del server MCP. Le policy sono definite in formato XML. Per esempio, puoi aggiungere una policy per limitare le chiamate agli strumenti del server MCP (in questo esempio, 5 chiamate ogni 30 secondi per indirizzo IP client). Ecco l’XML che applica la limitazione:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Ecco un’immagine dell’editor delle policy:

    ![Editor delle policy](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Provalo

Assicuriamoci che il nostro server MCP funzioni come previsto.

Per questo useremo Visual Studio Code e GitHub Copilot in modalità Agent. Aggiungeremo il server MCP a un file *mcp.json*. Così facendo, Visual Studio Code agirà come client con capacità agentiche e gli utenti finali potranno digitare un prompt e interagire con il server.

Vediamo come aggiungere il server MCP in Visual Studio Code:

1. Usa il comando MCP: **Add Server dal Command Palette**.

1. Quando richiesto, seleziona il tipo di server: **HTTP (HTTP o Server Sent Events)**.

1. Inserisci l’URL del server MCP in API Management. Esempio: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (per endpoint SSE) o **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (per endpoint MCP), nota la differenza tra i trasporti `/sse` o `/mcp`.

1. Inserisci un ID server a tua scelta. Non è un valore importante ma ti aiuterà a ricordare quale istanza di server è.

1. Seleziona se salvare la configurazione nelle impostazioni di workspace o in quelle utente.

  - **Impostazioni workspace** - La configurazione del server viene salvata in un file .vscode/mcp.json disponibile solo nel workspace corrente.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    oppure, se scegli il trasporto HTTP streaming, sarà leggermente diverso:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Impostazioni utente** - La configurazione del server viene aggiunta al file globale *settings.json* ed è disponibile in tutti i workspace. La configurazione appare simile a questa:

    ![Impostazioni utente](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Devi anche aggiungere una configurazione, un header per assicurarti che l’autenticazione verso Azure API Management funzioni correttamente. Usa un header chiamato **Ocp-Apim-Subscription-Key**.

    - Ecco come aggiungerlo nelle impostazioni:

    ![Aggiunta header per autenticazione](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), questo farà comparire un prompt che ti chiederà il valore della chiave API, che puoi trovare nel Portale Azure per la tua istanza di Azure API Management.

   - Per aggiungerlo invece in *mcp.json*, puoi farlo così:

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

### Usa la modalità Agent

Ora che abbiamo tutto configurato, sia nelle impostazioni che in *.vscode/mcp.json*, proviamolo.

Dovrebbe esserci un’icona Strumenti come questa, dove sono elencati gli strumenti esposti dal tuo server:

![Strumenti dal server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Clicca sull’icona strumenti e vedrai una lista di strumenti come questa:

    ![Strumenti](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Inserisci un prompt nella chat per invocare lo strumento. Per esempio, se hai selezionato uno strumento per ottenere informazioni su un ordine, puoi chiedere all’agente informazioni su un ordine. Ecco un esempio di prompt:

    ```text
    get information from order 2
    ```

    Ora ti verrà mostrata un’icona strumenti che ti chiederà di procedere con la chiamata allo strumento. Seleziona per continuare l’esecuzione dello strumento, dovresti vedere un output simile a questo:

    ![Risultato dal prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **ciò che vedi dipende dagli strumenti che hai configurato, ma l’idea è che ricevi una risposta testuale come quella sopra**


## Riferimenti

Ecco come puoi approfondire:

- [Tutorial su Azure API Management e MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Esempio Python: proteggere server MCP remoti usando Azure API Management (sperimentale)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Laboratorio di autorizzazione client MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Usa l’estensione Azure API Management per VS Code per importare e gestire API](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Registra e scopri server MCP remoti in Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Ottimo repository che mostra molte capacità AI con Azure API Management
- [Workshop AI Gateway](https://azure-samples.github.io/AI-Gateway/) Contiene workshop usando il Portale Azure, un ottimo modo per iniziare a valutare le capacità AI.

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.