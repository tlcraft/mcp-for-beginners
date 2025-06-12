<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:25:57+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "it"
}
-->
# Client LLM Calcolatrice

Un'applicazione Java che dimostra come usare LangChain4j per connettersi a un servizio calcolatrice MCP (Model Context Protocol) con integrazione GitHub Models.

## Prerequisiti

- Java 21 o superiore
- Maven 3.6+ (oppure usa il wrapper Maven incluso)
- Un account GitHub con accesso a GitHub Models
- Un servizio calcolatrice MCP in esecuzione su `http://localhost:8080`

## Ottenere il Token GitHub

Questa applicazione usa GitHub Models che richiede un token di accesso personale GitHub. Segui questi passaggi per ottenere il tuo token:

### 1. Accedi a GitHub Models
1. Vai su [GitHub Models](https://github.com/marketplace/models)
2. Accedi con il tuo account GitHub
3. Richiedi l'accesso a GitHub Models se non lo hai già fatto

### 2. Crea un Token di Accesso Personale
1. Vai su [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Clicca su "Generate new token" → "Generate new token (classic)"
3. Dai al token un nome descrittivo (es. "MCP Calculator Client")
4. Imposta la scadenza secondo necessità
5. Seleziona i seguenti ambiti:
   - `repo` (se accedi a repository privati)
   - `user:email`
6. Clicca su "Generate token"
7. **Importante**: Copia subito il token - non potrai più visualizzarlo!

### 3. Imposta la Variabile d’Ambiente

#### Su Windows (Prompt dei comandi):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Su Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### Su macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Configurazione e Installazione

1. **Clona o vai nella directory del progetto**

2. **Installa le dipendenze**:
   ```cmd
   mvnw clean install
   ```
   Oppure, se hai Maven installato globalmente:
   ```cmd
   mvn clean install
   ```

3. **Imposta la variabile d’ambiente** (vedi la sezione "Ottenere il Token GitHub" sopra)

4. **Avvia il servizio MCP Calculator**:
   Assicurati che il servizio MCP calculator del capitolo 1 sia attivo su `http://localhost:8080/sse`. Deve essere in esecuzione prima di avviare il client.

## Esecuzione dell’Applicazione

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Cosa Fa l’Applicazione

L’applicazione dimostra tre principali interazioni con il servizio calcolatrice:

1. **Addizione**: Calcola la somma di 24.5 e 17.3
2. **Radice Quadrata**: Calcola la radice quadrata di 144
3. **Aiuto**: Mostra le funzioni disponibili della calcolatrice

## Output Atteso

Se tutto funziona correttamente, dovresti vedere un output simile a:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Risoluzione dei Problemi

### Problemi Comuni

1. **"Variabile d’ambiente GITHUB_TOKEN non impostata"**
   - Assicurati di aver impostato `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean`

### Debug

Per abilitare il logging di debug, aggiungi il seguente argomento JVM durante l’esecuzione:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Configurazione

L’applicazione è configurata per:
- Usare GitHub Models con `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Usare un timeout di 60 secondi per le richieste
- Abilitare il logging di richieste/risposte per il debug

## Dipendenze

Dipendenze chiave usate in questo progetto:
- **LangChain4j**: per integrazione AI e gestione degli strumenti
- **LangChain4j MCP**: per supporto al Model Context Protocol
- **LangChain4j GitHub Models**: per integrazione GitHub Models
- **Spring Boot**: per framework applicativo e dependency injection

## Licenza

Questo progetto è concesso sotto licenza Apache 2.0 - vedi il file [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) per i dettagli.

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire l'accuratezza, si prega di considerare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda la traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall'uso di questa traduzione.