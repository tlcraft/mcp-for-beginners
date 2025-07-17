<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:34:13+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "it"
}
-->
# Esempi Completi di Client MCP

Questa directory contiene esempi completi e funzionanti di client MCP in diversi linguaggi di programmazione. Ogni client dimostra tutte le funzionalità descritte nel tutorial principale README.md.

## Client Disponibili

### 1. Client Java (`client_example_java.java`)
- **Trasporto**: SSE (Server-Sent Events) su HTTP
- **Server di destinazione**: `http://localhost:8080`
- **Caratteristiche**: 
  - Stabilire la connessione e inviare ping
  - Elenco degli strumenti
  - Operazioni della calcolatrice (add, subtract, multiply, divide, help)
  - Gestione degli errori ed estrazione dei risultati

**Per eseguire:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. Client C# (`client_example_csharp.cs`)
- **Trasporto**: Stdio (Input/Output standard)
- **Server di destinazione**: Server MCP .NET locale tramite dotnet run
- **Caratteristiche**:
  - Avvio automatico del server tramite trasporto stdio
  - Elenco di strumenti e risorse
  - Operazioni della calcolatrice
  - Parsing dei risultati in JSON
  - Gestione completa degli errori

**Per eseguire:**
```bash
dotnet run
```

### 3. Client TypeScript (`client_example_typescript.ts`)
- **Trasporto**: Stdio (Input/Output standard)
- **Server di destinazione**: Server MCP Node.js locale
- **Caratteristiche**:
  - Supporto completo del protocollo MCP
  - Operazioni su strumenti, risorse e prompt
  - Operazioni della calcolatrice
  - Lettura delle risorse ed esecuzione dei prompt
  - Gestione robusta degli errori

**Per eseguire:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Client Python (`client_example_python.py`)
- **Trasporto**: Stdio (Input/Output standard)  
- **Server di destinazione**: Server MCP Python locale
- **Caratteristiche**:
  - Pattern async/await per le operazioni
  - Scoperta di strumenti e risorse
  - Test delle operazioni della calcolatrice
  - Lettura del contenuto delle risorse
  - Organizzazione basata su classi

**Per eseguire:**
```bash
python client_example_python.py
```

## Funzionalità Comuni a Tutti i Client

Ogni implementazione client dimostra:

1. **Gestione della Connessione**
   - Stabilire la connessione al server MCP
   - Gestire gli errori di connessione
   - Pulizia e gestione corretta delle risorse

2. **Scoperta del Server**
   - Elencare gli strumenti disponibili
   - Elencare le risorse disponibili (dove supportato)
   - Elencare i prompt disponibili (dove supportato)

3. **Invocazione degli Strumenti**
   - Operazioni base della calcolatrice (add, subtract, multiply, divide)
   - Comando help per informazioni sul server
   - Passaggio corretto degli argomenti e gestione dei risultati

4. **Gestione degli Errori**
   - Errori di connessione
   - Errori nell’esecuzione degli strumenti
   - Fallimenti gestiti con feedback all’utente

5. **Elaborazione dei Risultati**
   - Estrazione del contenuto testuale dalle risposte
   - Formattazione dell’output per una migliore leggibilità
   - Gestione di diversi formati di risposta

## Prerequisiti

Prima di eseguire questi client, assicurati di avere:

1. **Il server MCP corrispondente in esecuzione** (da `../01-first-server/`)
2. **Le dipendenze richieste installate** per il linguaggio scelto
3. **Connettività di rete adeguata** (per trasporti basati su HTTP)

## Differenze Chiave tra le Implementazioni

| Linguaggio | Trasporto | Avvio Server | Modello Async | Librerie Principali |
|------------|-----------|--------------|---------------|---------------------|
| Java       | SSE/HTTP  | Esterno      | Sincrono      | WebFlux, MCP SDK    |
| C#         | Stdio     | Automatico   | Async/Await   | .NET MCP SDK        |
| TypeScript | Stdio     | Automatico   | Async/Await   | Node MCP SDK        |
| Python     | Stdio     | Automatico   | AsyncIO       | Python MCP SDK      |

## Passi Successivi

Dopo aver esplorato questi esempi di client:

1. **Modifica i client** per aggiungere nuove funzionalità o operazioni
2. **Crea il tuo server** e testalo con questi client
3. **Sperimenta con trasporti diversi** (SSE vs. Stdio)
4. **Costruisci un’applicazione più complessa** che integri le funzionalità MCP

## Risoluzione dei Problemi

### Problemi Comuni

1. **Connessione rifiutata**: Assicurati che il server MCP sia in esecuzione sulla porta/percorso previsto
2. **Modulo non trovato**: Installa l’MCP SDK richiesto per il tuo linguaggio
3. **Permesso negato**: Controlla i permessi dei file per il trasporto stdio
4. **Strumento non trovato**: Verifica che il server implementi gli strumenti attesi

### Consigli per il Debug

1. **Abilita il logging dettagliato** nel tuo MCP SDK
2. **Controlla i log del server** per messaggi di errore
3. **Verifica che nomi e firme degli strumenti** corrispondano tra client e server
4. **Testa prima con MCP Inspector** per validare la funzionalità del server

## Documentazione Correlata

- [Tutorial Principale Client](./README.md)
- [Esempi Server MCP](../../../../03-GettingStarted/01-first-server)
- [MCP con Integrazione LLM](../../../../03-GettingStarted/03-llm-client)
- [Documentazione Ufficiale MCP](https://modelcontextprotocol.io/)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.