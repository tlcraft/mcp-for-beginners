<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b96f2864e0bcb6fae9b4926813c3feb1",
  "translation_date": "2025-06-26T13:57:02+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "it"
}
-->
# Argomenti Avanzati in MCP

Questo capitolo è dedicato a una serie di argomenti avanzati nell’implementazione del Model Context Protocol (MCP), tra cui l’integrazione multimodale, la scalabilità, le migliori pratiche di sicurezza e l’integrazione aziendale. Questi temi sono fondamentali per costruire applicazioni MCP robuste e pronte per la produzione, in grado di soddisfare le esigenze dei sistemi di intelligenza artificiale moderni.

## Panoramica

Questa lezione esplora concetti avanzati nell’implementazione del Model Context Protocol, concentrandosi sull’integrazione multimodale, la scalabilità, le migliori pratiche di sicurezza e l’integrazione aziendale. Questi argomenti sono essenziali per sviluppare applicazioni MCP di livello produttivo capaci di gestire requisiti complessi in ambienti aziendali.

## Obiettivi di Apprendimento

Al termine di questa lezione, sarai in grado di:

- Implementare funzionalità multimodali all’interno dei framework MCP
- Progettare architetture MCP scalabili per scenari ad alta richiesta
- Applicare le migliori pratiche di sicurezza in linea con i principi di sicurezza di MCP
- Integrare MCP con sistemi e framework AI aziendali
- Ottimizzare prestazioni e affidabilità negli ambienti di produzione

## Lezioni e Progetti di Esempio

| Link | Titolo | Descrizione |
|------|--------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrazione con Azure | Impara come integrare il tuo MCP Server su Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Esempi MCP Multimodali | Esempi per risposte audio, immagini e multimodali |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demo MCP OAuth2 | Applicazione minimale Spring Boot che mostra OAuth2 con MCP, sia come Authorization che Resource Server. Dimostra emissione sicura di token, endpoint protetti, deployment su Azure Container Apps e integrazione con API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Contesti Root | Approfondisci i contesti root e come implementarli |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Scopri i diversi tipi di routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Campionamento | Impara a lavorare con il campionamento |
| [5.7 Scaling](./mcp-scaling/README.md) | Scalabilità | Approfondisci la scalabilità |
| [5.8 Security](./mcp-security/README.md) | Sicurezza | Metti in sicurezza il tuo MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Ricerca Web MCP | Server e client Python MCP che si integrano con SerpAPI per ricerche web, notizie, prodotti e Q&A in tempo reale. Dimostra orchestrazione multi-tool, integrazione API esterne e gestione robusta degli errori. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Lo streaming dati in tempo reale è diventato essenziale nel mondo odierno guidato dai dati, dove aziende e applicazioni richiedono accesso immediato alle informazioni per prendere decisioni tempestive. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Ricerca Web | Come MCP trasforma la ricerca web in tempo reale offrendo un approccio standardizzato alla gestione del contesto tra modelli AI, motori di ricerca e applicazioni. |
| [5.12 Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Autenticazione Entra ID | Microsoft Entra ID offre una soluzione robusta di gestione delle identità e degli accessi basata sul cloud, garantendo che solo utenti e applicazioni autorizzati possano interagire con il tuo server MCP. |

## Riferimenti Aggiuntivi

Per le informazioni più aggiornate sugli argomenti avanzati di MCP, consulta:
- [Documentazione MCP](https://modelcontextprotocol.io/)
- [Specifiche MCP](https://spec.modelcontextprotocol.io/)
- [Repository GitHub](https://github.com/modelcontextprotocol)

## Punti Chiave

- Le implementazioni MCP multimodali estendono le capacità AI oltre l’elaborazione testuale
- La scalabilità è fondamentale per le implementazioni aziendali e può essere affrontata tramite scalabilità orizzontale e verticale
- Misure di sicurezza complete proteggono i dati e garantiscono un controllo degli accessi adeguato
- L’integrazione aziendale con piattaforme come Azure OpenAI e Microsoft AI Foundry potenzia le capacità MCP
- Le implementazioni avanzate di MCP beneficiano di architetture ottimizzate e di una gestione attenta delle risorse

## Esercizio

Progetta un’implementazione MCP di livello aziendale per un caso d’uso specifico:

1. Identifica i requisiti multimodali per il tuo caso d’uso
2. Delinea i controlli di sicurezza necessari per proteggere i dati sensibili
3. Progetta un’architettura scalabile in grado di gestire carichi variabili
4. Pianifica i punti di integrazione con i sistemi AI aziendali
5. Documenta potenziali colli di bottiglia nelle prestazioni e strategie di mitigazione

## Risorse Aggiuntive

- [Documentazione Azure OpenAI](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Documentazione Microsoft AI Foundry](https://learn.microsoft.com/en-us/ai-services/)

---

## Cosa c’è dopo

- [5.1 MCP Integration](./mcp-integration/README.md)

**Avvertenza**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali fraintendimenti o interpretazioni errate derivanti dall’uso di questa traduzione.