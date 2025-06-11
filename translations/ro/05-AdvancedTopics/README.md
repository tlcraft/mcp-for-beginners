<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T16:23:33+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ro"
}
-->
# Subiecte Avansate în MCP

Acest capitol are scopul de a acoperi o serie de subiecte avansate în implementarea Model Context Protocol (MCP), inclusiv integrarea multi-modală, scalabilitatea, cele mai bune practici de securitate și integrarea în mediul enterprise. Aceste teme sunt esențiale pentru construirea de aplicații MCP robuste și pregătite pentru producție, capabile să răspundă cerințelor sistemelor AI moderne.

## Prezentare generală

Această lecție explorează concepte avansate în implementarea Model Context Protocol, concentrându-se pe integrarea multi-modală, scalabilitate, cele mai bune practici de securitate și integrarea în mediul enterprise. Aceste subiecte sunt fundamentale pentru dezvoltarea aplicațiilor MCP de nivel producție, care pot gestiona cerințe complexe în medii enterprise.

## Obiectivele de învățare

La finalul acestei lecții, vei putea:

- Implementa capabilități multi-modale în cadrul MCP
- Proiecta arhitecturi MCP scalabile pentru scenarii cu cerere ridicată
- Aplica cele mai bune practici de securitate aliniate principiilor MCP
- Integra MCP cu sisteme și cadre AI enterprise
- Optimiza performanța și fiabilitatea în medii de producție

## Lecții și proiecte exemplu

| Link | Titlu | Descriere |
|------|-------|-----------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrare cu Azure | Învață cum să integrezi MCP Server pe Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Exemple MCP multi-modal | Exemple pentru răspunsuri audio, imagine și multi-modale |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demo MCP OAuth2 | Aplicație minimală Spring Boot care arată OAuth2 cu MCP, atât ca Authorization cât și Resource Server. Demonstrează emiterea securizată a token-urilor, endpoint-uri protejate, implementare în Azure Container Apps și integrare cu API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Contexturi root | Află mai multe despre contextul root și cum să îl implementezi |
| [5.5 Routing](./mcp-routing/README.md) | Rutare | Învață diferite tipuri de rutare |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Învață cum să lucrezi cu sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Scalare | Învață despre scalare |
| [5.8 Security](./mcp-security/README.md) | Securitate | Asigură securitatea MCP Serverului tău |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Căutare Web MCP | Server și client Python MCP care integrează SerpAPI pentru căutare web, știri, produse și Q&A în timp real. Demonstrează orchestrarea multi-tool, integrarea API extern și gestionarea robustă a erorilor. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming de date în timp real a devenit esențial în lumea actuală bazată pe date, unde afacerile și aplicațiile necesită acces imediat la informații pentru a lua decizii rapide. |

## Referințe suplimentare

Pentru cele mai recente informații despre subiecte avansate MCP, consultă:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Concluzii cheie

- Implementările MCP multi-modale extind capabilitățile AI dincolo de procesarea textului
- Scalabilitatea este esențială pentru implementările enterprise și poate fi abordată prin scalare orizontală și verticală
- Măsurile de securitate cuprinzătoare protejează datele și asigură un control adecvat al accesului
- Integrarea enterprise cu platforme precum Azure OpenAI și Microsoft AI Foundry îmbunătățește capabilitățile MCP
- Implementările avansate MCP beneficiază de arhitecturi optimizate și o gestionare atentă a resurselor

## Exercițiu

Proiectează o implementare MCP de nivel enterprise pentru un caz de utilizare specific:

1. Identifică cerințele multi-modale pentru cazul tău de utilizare
2. Conturează controalele de securitate necesare pentru protejarea datelor sensibile
3. Proiectează o arhitectură scalabilă care să poată gestiona încărcări variabile
4. Planifică punctele de integrare cu sistemele AI enterprise
5. Documentează posibilele blocaje de performanță și strategiile de atenuare

## Resurse suplimentare

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Ce urmează

- [5.1 MCP Integration](./mcp-integration/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original, în limba sa nativă, trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea în urma utilizării acestei traduceri.