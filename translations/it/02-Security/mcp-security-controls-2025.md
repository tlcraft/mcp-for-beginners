<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T01:50:35+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "it"
}
-->
# Ultimi Controlli di Sicurezza MCP - Aggiornamento Luglio 2025

Con l’evoluzione del Model Context Protocol (MCP), la sicurezza rimane una considerazione fondamentale. Questo documento illustra gli ultimi controlli di sicurezza e le migliori pratiche per implementare MCP in modo sicuro a partire da luglio 2025.

## Autenticazione e Autorizzazione

### Supporto alla Delegazione OAuth 2.0

Gli aggiornamenti recenti alla specifica MCP consentono ora ai server MCP di delegare l’autenticazione degli utenti a servizi esterni come Microsoft Entra ID. Questo migliora significativamente la postura di sicurezza grazie a:

1. **Eliminazione di implementazioni di autenticazione personalizzate**: Riduce il rischio di vulnerabilità nel codice di autenticazione personalizzato  
2. **Sfruttamento di provider di identità consolidati**: Approfitta delle funzionalità di sicurezza a livello enterprise  
3. **Centralizzazione della gestione delle identità**: Semplifica la gestione del ciclo di vita degli utenti e il controllo degli accessi  

## Prevenzione del Passaggio di Token

La Specifica di Autorizzazione MCP vieta esplicitamente il passaggio diretto di token per evitare la elusione dei controlli di sicurezza e problemi di responsabilità.

### Requisiti Chiave

1. **I server MCP NON DEVONO accettare token non emessi per loro**: Verificare che tutti i token abbiano la corretta audience  
2. **Implementare una corretta validazione dei token**: Controllare issuer, audience, scadenza e firma  
3. **Utilizzare l’emissione separata di token**: Emettere nuovi token per i servizi a valle invece di passare quelli esistenti  

## Gestione Sicura delle Sessioni

Per prevenire attacchi di hijacking e fixation delle sessioni, implementare i seguenti controlli:

1. **Usare ID di sessione sicuri e non deterministici**: Generati con generatori di numeri casuali crittograficamente sicuri  
2. **Associare le sessioni all’identità dell’utente**: Combinare gli ID di sessione con informazioni specifiche dell’utente  
3. **Implementare una corretta rotazione delle sessioni**: Dopo cambiamenti di autenticazione o escalation di privilegi  
4. **Impostare timeout di sessione appropriati**: Bilanciare sicurezza ed esperienza utente  

## Sandboxing dell’Esecuzione degli Strumenti

Per prevenire movimenti laterali e contenere eventuali compromissioni:

1. **Isolare gli ambienti di esecuzione degli strumenti**: Usare container o processi separati  
2. **Applicare limiti alle risorse**: Prevenire attacchi di esaurimento delle risorse  
3. **Implementare il principio del minimo privilegio**: Concedere solo i permessi necessari  
4. **Monitorare i pattern di esecuzione**: Rilevare comportamenti anomali  

## Protezione della Definizione degli Strumenti

Per prevenire il poisoning degli strumenti:

1. **Validare le definizioni degli strumenti prima dell’uso**: Controllare istruzioni malevole o pattern inappropriati  
2. **Usare la verifica di integrità**: Hashare o firmare le definizioni per rilevare modifiche non autorizzate  
3. **Implementare il monitoraggio delle modifiche**: Segnalare modifiche inattese ai metadata degli strumenti  
4. **Versionare le definizioni degli strumenti**: Tenere traccia delle modifiche e abilitare il rollback se necessario  

Questi controlli lavorano insieme per creare una solida postura di sicurezza nelle implementazioni MCP, affrontando le sfide uniche dei sistemi guidati dall’IA mantenendo al contempo solide pratiche di sicurezza tradizionali.

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non siamo responsabili per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.