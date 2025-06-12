<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T15:30:38+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "it"
}
-->
# Argomenti Avanzati in MCP

Questo capitolo è dedicato a una serie di argomenti avanzati nell’implementazione del Model Context Protocol (MCP), tra cui integrazione multimodale, scalabilità, best practice per la sicurezza e integrazione aziendale. Questi temi sono fondamentali per costruire applicazioni MCP robuste e pronte per la produzione, in grado di soddisfare le esigenze dei sistemi di intelligenza artificiale moderni.

## Panoramica

Questa lezione esplora concetti avanzati nell’implementazione del Model Context Protocol, con un focus su integrazione multimodale, scalabilità, best practice per la sicurezza e integrazione aziendale. Questi argomenti sono essenziali per sviluppare applicazioni MCP di livello produttivo, capaci di gestire requisiti complessi in ambienti enterprise.

## Obiettivi di Apprendimento

Al termine di questa lezione sarai in grado di:

- Implementare funzionalità multimodali all’interno dei framework MCP
- Progettare architetture MCP scalabili per scenari ad alta domanda
- Applicare best practice di sicurezza in linea con i principi di sicurezza di MCP
- Integrare MCP con sistemi e framework di AI aziendali
- Ottimizzare prestazioni e affidabilità in ambienti di produzione

## Lezioni e Progetti di Esempio

| Link | Titolo | Descrizione |
|------|--------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrazione con Azure | Impara come integrare il tuo MCP Server su Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Esempi MCP multimodali | Esempi per risposte audio, immagini e multimodali |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demo MCP OAuth2 | Applicazione Spring Boot minimale che mostra OAuth2 con MCP, sia come Authorization che Resource Server. Dimostra l’emissione sicura di token, endpoint protetti, deployment su Azure Container Apps e integrazione con API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Approfondisci i root context e come implementarli |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Scopri i diversi tipi di routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Impara a lavorare con il sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Scalabilità | Approfondisci la scalabilità |
| [5.8 Security](./mcp-security/README.md) | Sicurezza | Metti in sicurezza il tuo MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Ricerca Web MCP | Server e client MCP in Python che si integrano con SerpAPI per ricerca web, news, prodotti e Q&A in tempo reale. Dimostra orchestrazione multi-tool, integrazione con API esterne e gestione robusta degli errori. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Lo streaming dati in tempo reale è diventato essenziale nel mondo guidato dai dati di oggi, dove aziende e applicazioni richiedono accesso immediato alle informazioni per prendere decisioni tempestive. |

## Riferimenti Aggiuntivi

Per le informazioni più aggiornate sugli argomenti avanzati di MCP, consulta:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Punti Chiave

- Le implementazioni MCP multimodali ampliano le capacità AI oltre l’elaborazione del testo
- La scalabilità è fondamentale per le implementazioni enterprise e può essere affrontata tramite scaling orizzontale e verticale
- Misure di sicurezza complete proteggono i dati e garantiscono un controllo accessi adeguato
- L’integrazione aziendale con piattaforme come Azure OpenAI e Microsoft AI Foundry potenzia le capacità di MCP
- Le implementazioni avanzate di MCP beneficiano di architetture ottimizzate e di una gestione attenta delle risorse

## Esercizio

Progetta un’implementazione MCP di livello enterprise per un caso d’uso specifico:

1. Identifica i requisiti multimodali per il tuo caso d’uso
2. Definisci i controlli di sicurezza necessari per proteggere i dati sensibili
3. Progetta un’architettura scalabile in grado di gestire carichi variabili
4. Pianifica i punti di integrazione con sistemi AI aziendali
5. Documenta i potenziali colli di bottiglia nelle prestazioni e le strategie di mitigazione

## Risorse Aggiuntive

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Cosa c’è dopo

- [5.1 MCP Integration](./mcp-integration/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.