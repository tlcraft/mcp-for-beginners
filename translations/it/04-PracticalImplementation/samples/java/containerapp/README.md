<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e5ea5e7582f70008ea9bec3b3820f20a",
  "translation_date": "2025-05-17T14:26:01+00:00",
  "source_file": "04-PracticalImplementation/samples/java/containerapp/README.md",
  "language_code": "it"
}
-->
## Architettura del Sistema

Questo progetto dimostra un'applicazione web che utilizza il controllo di sicurezza dei contenuti prima di passare i prompt dell'utente a un servizio di calcolatrice tramite Model Context Protocol (MCP).

### Come Funziona

1. **Input Utente**: L'utente inserisce un prompt di calcolo nell'interfaccia web
2. **Screening di Sicurezza dei Contenuti (Input)**: Il prompt viene analizzato dall'API di Sicurezza dei Contenuti di Azure
3. **Decisione di Sicurezza (Input)**:
   - Se il contenuto è sicuro (gravità < 2 in tutte le categorie), procede alla calcolatrice
   - Se il contenuto è segnalato come potenzialmente dannoso, il processo si interrompe e viene restituito un avviso
4. **Integrazione con la Calcolatrice**: I contenuti sicuri vengono elaborati da LangChain4j, che comunica con il server calcolatrice MCP
5. **Screening di Sicurezza dei Contenuti (Output)**: La risposta del bot viene analizzata dall'API di Sicurezza dei Contenuti di Azure
6. **Decisione di Sicurezza (Output)**:
   - Se la risposta del bot è sicura, viene mostrata all'utente
   - Se la risposta del bot è segnalata come potenzialmente dannosa, viene sostituita con un avviso
7. **Risposta**: I risultati (se sicuri) vengono visualizzati all'utente insieme alle analisi di sicurezza

## Utilizzo del Model Context Protocol (MCP) con i Servizi di Calcolatrice

Questo progetto dimostra come utilizzare il Model Context Protocol (MCP) per chiamare i servizi MCP della calcolatrice da LangChain4j. L'implementazione utilizza un server MCP locale che opera sulla porta 8080 per fornire operazioni di calcolatrice.

### Configurazione del Servizio di Sicurezza dei Contenuti di Azure

Prima di utilizzare le funzionalità di sicurezza dei contenuti, è necessario creare una risorsa del servizio di Sicurezza dei Contenuti di Azure:

1. Accedi al [Portale Azure](https://portal.azure.com)
2. Clicca su "Crea una risorsa" e cerca "Sicurezza dei Contenuti"
3. Seleziona "Sicurezza dei Contenuti" e clicca su "Crea"
4. Inserisci un nome unico per la tua risorsa
5. Seleziona il tuo abbonamento e gruppo di risorse (o creane uno nuovo)
6. Scegli una regione supportata (controlla [Disponibilità delle regioni](https://azure.microsoft.com/en-us/global-infrastructure/services/?products=cognitive-services) per i dettagli)
7. Seleziona un livello di prezzo appropriato
8. Clicca su "Crea" per distribuire la risorsa
9. Una volta completata la distribuzione, clicca su "Vai alla risorsa"
10. Nel riquadro a sinistra, sotto "Gestione delle risorse", seleziona "Chiavi ed Endpoint"
11. Copia una delle chiavi e l'URL dell'endpoint per utilizzarli nel passaggio successivo

### Configurazione delle Variabili d'Ambiente

Imposta la variabile d'ambiente `GITHUB_TOKEN` per l'autenticazione dei modelli GitHub:
```sh
export GITHUB_TOKEN=<your_github_token>
```

Per le funzionalità di sicurezza dei contenuti, imposta:
```sh
export CONTENT_SAFETY_ENDPOINT=<your_content_safety_endpoint>
export CONTENT_SAFETY_KEY=<your_content_safety_key>
```

Queste variabili d'ambiente vengono utilizzate dall'applicazione per autenticarsi con il servizio di Sicurezza dei Contenuti di Azure. Se queste variabili non sono impostate, l'applicazione utilizzerà valori segnaposto per scopi dimostrativi, ma le funzionalità di sicurezza dei contenuti non funzioneranno correttamente.

### Avvio del Server MCP della Calcolatrice

Prima di eseguire il client, è necessario avviare il server MCP della calcolatrice in modalità SSE su localhost:8080.

## Descrizione del Progetto

Questo progetto dimostra l'integrazione del Model Context Protocol (MCP) con LangChain4j per chiamare i servizi di calcolatrice. Le caratteristiche principali includono:

- Utilizzo di MCP per connettersi a un servizio di calcolatrice per operazioni matematiche di base
- Controllo di sicurezza dei contenuti a doppio livello su prompt utente e risposte del bot
- Integrazione con il modello gpt-4.1-nano di GitHub tramite LangChain4j
- Utilizzo di Server-Sent Events (SSE) per il trasporto MCP

## Integrazione della Sicurezza dei Contenuti

Il progetto include funzionalità di sicurezza dei contenuti complete per garantire che sia gli input degli utenti che le risposte del sistema siano privi di contenuti dannosi:

1. **Screening dell'Input**: Tutti i prompt degli utenti vengono analizzati per categorie di contenuti dannosi come discorsi di odio, violenza, autolesionismo e contenuti sessuali prima della elaborazione.

2. **Screening dell'Output**: Anche quando si utilizzano modelli potenzialmente non censurati, il sistema verifica tutte le risposte generate tramite gli stessi filtri di sicurezza dei contenuti prima di mostrarle all'utente.

Questo approccio a doppio livello garantisce che il sistema rimanga sicuro indipendentemente dal modello AI utilizzato, proteggendo gli utenti sia dagli input dannosi che dai potenziali output problematici generati dall'AI.

## Client Web

L'applicazione include un'interfaccia web user-friendly che consente agli utenti di interagire con il sistema di Calcolatrice di Sicurezza dei Contenuti:

### Caratteristiche dell'Interfaccia Web

- Modulo semplice e intuitivo per inserire prompt di calcolo
- Validazione di sicurezza dei contenuti a doppio livello (input e output)
- Feedback in tempo reale sulla sicurezza del prompt e della risposta
- Indicatori di sicurezza codificati per colore per una facile interpretazione
- Design pulito e reattivo che funziona su vari dispositivi
- Esempi di prompt sicuri per guidare gli utenti

### Utilizzo del Client Web

1. Avvia l'applicazione:
   ```sh
   mvn spring-boot:run
   ```

2. Apri il tuo browser e naviga su `http://localhost:8087`

3. Inserisci un prompt di calcolo nell'area di testo fornita (ad esempio, "Calcola la somma di 24.5 e 17.3")

4. Clicca su "Invia" per elaborare la tua richiesta

5. Visualizza i risultati, che includeranno:
   - Analisi di sicurezza dei contenuti del tuo prompt
   - Il risultato calcolato (se il prompt era sicuro)
   - Analisi di sicurezza dei contenuti della risposta del bot
   - Eventuali avvisi di sicurezza se l'input o l'output sono stati segnalati

Il client web gestisce automaticamente entrambi i processi di verifica della sicurezza dei contenuti, garantendo che tutte le interazioni siano sicure e appropriate indipendentemente dal modello AI utilizzato.

**Disclaimer**:
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.