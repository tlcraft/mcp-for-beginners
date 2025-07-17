<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T01:57:32+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "it"
}
-->
# Best Practice di Sicurezza MCP - Aggiornamento Luglio 2025

## Best Practice di Sicurezza Complete per le Implementazioni MCP

Quando lavori con i server MCP, segui queste best practice di sicurezza per proteggere i tuoi dati, l’infrastruttura e gli utenti:

1. **Validazione degli Input**: Valida e sanifica sempre gli input per prevenire attacchi di injection e problemi di confused deputy.
   - Implementa una validazione rigorosa per tutti i parametri degli strumenti
   - Usa la validazione dello schema per assicurarti che le richieste rispettino i formati attesi
   - Filtra contenuti potenzialmente dannosi prima della loro elaborazione

2. **Controllo degli Accessi**: Implementa un’autenticazione e un’autorizzazione adeguate per il tuo server MCP con permessi granulati.
   - Usa OAuth 2.0 con provider di identità consolidati come Microsoft Entra ID
   - Implementa il controllo degli accessi basato sui ruoli (RBAC) per gli strumenti MCP
   - Non implementare mai un’autenticazione personalizzata se esistono soluzioni consolidate

3. **Comunicazione Sicura**: Usa HTTPS/TLS per tutte le comunicazioni con il server MCP e considera l’aggiunta di crittografia supplementare per i dati sensibili.
   - Configura TLS 1.3 dove possibile
   - Implementa il certificate pinning per le connessioni critiche
   - Ruota regolarmente i certificati e verifica la loro validità

4. **Limitazione della Frequenza**: Implementa limiti di frequenza per prevenire abusi, attacchi DoS e gestire il consumo delle risorse.
   - Imposta limiti di richieste appropriati in base ai modelli di utilizzo previsti
   - Implementa risposte graduate a richieste eccessive
   - Considera limiti di frequenza specifici per utente in base allo stato di autenticazione

5. **Logging e Monitoraggio**: Monitora il server MCP per attività sospette e implementa audit trail completi.
   - Registra tutti i tentativi di autenticazione e le invocazioni degli strumenti
   - Implementa alert in tempo reale per pattern sospetti
   - Assicurati che i log siano archiviati in modo sicuro e non possano essere manomessi

6. **Archiviazione Sicura**: Proteggi i dati sensibili e le credenziali con una crittografia adeguata a riposo.
   - Usa key vault o archivi sicuri per tutte le credenziali
   - Implementa la crittografia a livello di campo per i dati sensibili
   - Ruota regolarmente chiavi di crittografia e credenziali

7. **Gestione dei Token**: Previeni vulnerabilità di token passthrough validando e sanificando tutti gli input e output dei modelli.
   - Implementa la validazione dei token basata sulle audience claims
   - Non accettare mai token non esplicitamente emessi per il tuo server MCP
   - Gestisci correttamente la durata e la rotazione dei token

8. **Gestione delle Sessioni**: Implementa una gestione sicura delle sessioni per prevenire hijacking e attacchi di session fixation.
   - Usa ID di sessione sicuri e non deterministici
   - Associa le sessioni a informazioni specifiche dell’utente
   - Implementa una corretta scadenza e rotazione delle sessioni

9. **Sandboxing dell’Esecuzione degli Strumenti**: Esegui gli strumenti in ambienti isolati per prevenire movimenti laterali in caso di compromissione.
   - Implementa l’isolamento tramite container per l’esecuzione degli strumenti
   - Applica limiti di risorse per prevenire attacchi di esaurimento risorse
   - Usa contesti di esecuzione separati per domini di sicurezza differenti

10. **Audit di Sicurezza Regolari**: Conduci revisioni periodiche di sicurezza delle tue implementazioni MCP e delle dipendenze.
    - Pianifica test di penetrazione regolari
    - Usa strumenti di scansione automatizzati per rilevare vulnerabilità
    - Mantieni aggiornate le dipendenze per risolvere problemi di sicurezza noti

11. **Filtraggio della Sicurezza dei Contenuti**: Implementa filtri di sicurezza per input e output.
    - Usa Azure Content Safety o servizi simili per rilevare contenuti dannosi
    - Implementa tecniche di prompt shield per prevenire prompt injection
    - Scansiona i contenuti generati per potenziali fughe di dati sensibili

12. **Sicurezza della Supply Chain**: Verifica l’integrità e l’autenticità di tutti i componenti nella tua supply chain AI.
    - Usa pacchetti firmati e verifica le firme
    - Implementa l’analisi del software bill of materials (SBOM)
    - Monitora aggiornamenti malevoli alle dipendenze

13. **Protezione della Definizione degli Strumenti**: Previeni il tool poisoning proteggendo definizioni e metadata degli strumenti.
    - Valida le definizioni degli strumenti prima dell’uso
    - Monitora cambiamenti inattesi ai metadata degli strumenti
    - Implementa controlli di integrità per le definizioni degli strumenti

14. **Monitoraggio Dinamico dell’Esecuzione**: Monitora il comportamento a runtime dei server MCP e degli strumenti.
    - Implementa analisi comportamentale per rilevare anomalie
    - Configura alert per pattern di esecuzione inattesi
    - Usa tecniche di runtime application self-protection (RASP)

15. **Principio del Privilegio Minimo**: Assicurati che server MCP e strumenti operino con i permessi minimi necessari.
    - Concedi solo i permessi specifici necessari per ogni operazione
    - Rivedi e audita regolarmente l’uso dei permessi
    - Implementa accesso just-in-time per le funzioni amministrative

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.