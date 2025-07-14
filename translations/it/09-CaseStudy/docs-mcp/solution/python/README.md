<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:39:54+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "it"
}
-->
# Generatore di Piani di Studio con Chainlit & Microsoft Learn Docs MCP

## Prerequisiti

- Python 3.8 o superiore  
- pip (gestore di pacchetti Python)  
- Connessione a Internet per collegarsi al server Microsoft Learn Docs MCP  

## Installazione

1. Clona questo repository o scarica i file del progetto.  
2. Installa le dipendenze richieste:  

   ```bash
   pip install -r requirements.txt
   ```  

## Utilizzo

### Scenario 1: Query Semplice a Docs MCP  
Un client da riga di comando che si connette al server Docs MCP, invia una query e stampa il risultato.

1. Esegui lo script:  
   ```bash
   python scenario1.py
   ```  
2. Inserisci la tua domanda sulla documentazione al prompt.

### Scenario 2: Generatore di Piani di Studio (App Web Chainlit)  
Un’interfaccia web (basata su Chainlit) che permette agli utenti di generare un piano di studio personalizzato, settimana per settimana, su qualsiasi argomento tecnico.

1. Avvia l’app Chainlit:  
   ```bash
   chainlit run scenario2.py
   ```  
2. Apri l’URL locale fornito nel terminale (es. http://localhost:8000) nel tuo browser.  
3. Nella finestra di chat, inserisci l’argomento di studio e il numero di settimane in cui vuoi studiare (es. "certificazione AI-900, 8 settimane").  
4. L’app risponderà con un piano di studio settimanale, includendo link alla documentazione Microsoft Learn pertinente.

**Variabili d’Ambiente Necessarie:**  

Per usare lo Scenario 2 (l’app web Chainlit con Azure OpenAI), devi impostare le seguenti variabili d’ambiente in un file `.env` nella cartella `python`:  

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```  

Compila questi valori con i dettagli della tua risorsa Azure OpenAI prima di avviare l’app.

> **Tip:** Puoi facilmente distribuire i tuoi modelli usando [Azure AI Foundry](https://ai.azure.com/).

### Scenario 3: Documentazione In-Editor con MCP Server in VS Code

Invece di cambiare scheda nel browser per cercare documentazione, puoi integrare Microsoft Learn Docs direttamente in VS Code usando il server MCP. Questo ti permette di:  
- Cercare e leggere la documentazione dentro VS Code senza uscire dall’ambiente di sviluppo.  
- Inserire riferimenti e link direttamente nei file README o nei materiali del corso.  
- Usare GitHub Copilot e MCP insieme per un flusso di lavoro documentale potenziato dall’AI.

**Esempi di utilizzo:**  
- Aggiungere rapidamente link di riferimento a un README mentre scrivi la documentazione di un corso o progetto.  
- Usare Copilot per generare codice e MCP per trovare e citare subito la documentazione rilevante.  
- Rimanere concentrato nell’editor aumentando la produttività.

> [!IMPORTANT]  
> Assicurati di avere una configurazione valida di [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) nel tuo workspace (posizione: `.vscode/mcp.json`).

## Perché Chainlit per lo Scenario 2?

Chainlit è un framework open-source moderno per costruire applicazioni web conversazionali. Rende semplice creare interfacce chat che si collegano a servizi backend come il server Microsoft Learn Docs MCP. Questo progetto usa Chainlit per offrire un modo semplice e interattivo di generare piani di studio personalizzati in tempo reale. Grazie a Chainlit, puoi costruire e distribuire rapidamente strumenti chat che migliorano produttività e apprendimento.

## Cosa Fa Questo

Questa app permette agli utenti di creare un piano di studio personalizzato semplicemente inserendo un argomento e una durata. L’app interpreta il tuo input, interroga il server Microsoft Learn Docs MCP per contenuti rilevanti e organizza i risultati in un piano strutturato settimana per settimana. Le raccomandazioni di ogni settimana vengono mostrate nella chat, facilitando il monitoraggio e il progresso. L’integrazione garantisce sempre l’accesso alle risorse di apprendimento più aggiornate e pertinenti.

## Esempi di Query

Prova queste query nella finestra di chat per vedere come risponde l’app:

- `certificazione AI-900, 8 settimane`  
- `Imparare Azure Functions, 4 settimane`  
- `Azure DevOps, 6 settimane`  
- `Data engineering su Azure, 10 settimane`  
- `Fondamenti di sicurezza Microsoft, 5 settimane`  
- `Power Platform, 7 settimane`  
- `Servizi AI di Azure, 12 settimane`  
- `Architettura cloud, 9 settimane`  

Questi esempi mostrano la flessibilità dell’app per diversi obiettivi di apprendimento e durate.

## Riferimenti

- [Documentazione Chainlit](https://docs.chainlit.io/)  
- [Documentazione MCP](https://github.com/MicrosoftDocs/mcp)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.