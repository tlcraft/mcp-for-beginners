<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:54:39+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "hr"
}
-->
# Case Study: Azure AI Travel Agents – Referentna Implementacija

## Pregled

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) je sveobuhvatno referentno rješenje koje je razvio Microsoft, a koje pokazuje kako izgraditi aplikaciju za planiranje putovanja s više agenata pokretanu AI-jem, koristeći Model Context Protocol (MCP), Azure OpenAI i Azure AI Search. Ovaj projekt prikazuje najbolje prakse za koordinaciju više AI agenata, integraciju podataka poduzeća i pružanje sigurne, proširive platforme za stvarne scenarije.

## Ključne značajke
- **Orkestracija više agenata:** Koristi MCP za koordinaciju specijaliziranih agenata (npr. agenti za letove, hotele i itinerare) koji surađuju kako bi ispunili složene zadatke planiranja putovanja.
- **Integracija podataka poduzeća:** Povezuje se s Azure AI Search i drugim izvorima podataka poduzeća kako bi pružio ažurirane i relevantne informacije za preporuke putovanja.
- **Sigurna, skalabilna arhitektura:** Iskorištava Azure usluge za autentikaciju, autorizaciju i skalabilnu implementaciju, slijedeći najbolje sigurnosne prakse poduzeća.
- **Proširivi alati:** Implementira ponovno upotrebljive MCP alate i predloške za promptove, omogućujući brzu prilagodbu novim domenama ili poslovnim zahtjevima.
- **Korisničko iskustvo:** Pruža konverzacijsko sučelje za korisnike za interakciju s agentima za putovanja, pokretano Azure OpenAI i MCP-om.

## Arhitektura
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Opis dijagrama arhitekture

Rješenje Azure AI Travel Agents dizajnirano je za modularnost, skalabilnost i sigurnu integraciju više AI agenata i izvora podataka poduzeća. Glavne komponente i protok podataka su sljedeći:

- **Korisničko sučelje:** Korisnici komuniciraju sa sustavom putem konverzacijskog UI-ja (poput web chata ili Teams bota), koji šalje upite korisnika i prima preporuke za putovanja.
- **MCP Server:** Služi kao centralni orkestrator, prima korisničke ulaze, upravlja kontekstom i koordinira rad specijaliziranih agenata (npr. FlightAgent, HotelAgent, ItineraryAgent) preko Model Context Protocol-a.
- **AI agenti:** Svaki agent je odgovoran za određenu domenu (letovi, hoteli, itinerari) i implementiran je kao MCP alat. Agenti koriste predloške za promptove i logiku za obradu zahtjeva i generiranje odgovora.
- **Azure OpenAI Service:** Pruža napredno razumijevanje i generiranje prirodnog jezika, omogućujući agentima da interpretiraju namjeru korisnika i generiraju konverzacijske odgovore.
- **Azure AI Search & podaci poduzeća:** Agenti pretražuju Azure AI Search i druge izvore podataka poduzeća kako bi dohvatili ažurirane informacije o letovima, hotelima i opcijama putovanja.
- **Autentikacija i sigurnost:** Integrira se s Microsoft Entra ID za sigurnu autentikaciju i primjenjuje kontrole pristupa s najmanjim potrebnim privilegijama za sve resurse.
- **Implementacija:** Dizajnirano za implementaciju na Azure Container Apps, osiguravajući skalabilnost, nadzor i operativnu učinkovitost.

Ova arhitektura omogućuje besprijekornu orkestraciju više AI agenata, sigurnu integraciju s podacima poduzeća i robusnu, proširivu platformu za izgradnju AI rješenja specifičnih za domenu.

## Korak-po-korak objašnjenje dijagrama arhitekture
Zamislite da planirate veliko putovanje i imate tim stručnih pomoćnika koji vam pomažu sa svakim detaljem. Sustav Azure AI Travel Agents radi na sličan način, koristeći različite dijelove (poput članova tima) od kojih svaki ima posebnu ulogu. Evo kako se sve uklapa:

### Korisničko sučelje (UI):
Zamislite ovo kao recepciju vašeg putnog agenta. Tu vi (korisnik) postavljate pitanja ili dajete zahtjeve, poput "Pronađi mi let za Pariz." To može biti prozor za chat na web stranici ili aplikaciji za razmjenu poruka.

### MCP Server (Koordinator):
MCP Server je poput menadžera koji sluša vaš zahtjev na recepciji i odlučuje koji specijalist treba obraditi svaki dio. Prati vašu konverzaciju i osigurava da sve teče glatko.

### AI agenti (Specijalistički pomoćnici):
Svaki agent je stručnjak za određeno područje—jedan zna sve o letovima, drugi o hotelima, a treći o planiranju itinerara. Kada zatražite putovanje, MCP Server šalje vaš zahtjev pravom agentu ili agentima. Ti agenti koriste svoje znanje i alate da pronađu najbolje opcije za vas.

### Azure OpenAI Service (Stručnjak za jezik):
To je kao da imate jezičnog stručnjaka koji točno razumije što tražite, bez obzira kako to izrazite. Pomaže agentima da shvate vaše zahtjeve i odgovore prirodnim, konverzacijskim jezikom.

### Azure AI Search & podaci poduzeća (Informacijska knjižnica):
Zamislite ogromnu, ažuriranu knjižnicu sa svim najnovijim informacijama o putovanjima—rasporedima letova, dostupnosti hotela i slično. Agenti pretražuju ovu knjižnicu kako bi dobili najtočnije odgovore za vas.

### Autentikacija i sigurnost (Čuvar sigurnosti):
Baš kao što čuvar sigurnosti provjerava tko može ući u određena područja, ovaj dio osigurava da samo ovlaštene osobe i agenti mogu pristupiti osjetljivim informacijama. Čuva vaše podatke sigurnima i privatnima.

### Implementacija na Azure Container Apps (Zgrada):
Svi ovi pomoćnici i alati rade zajedno unutar sigurne, skalabilne zgrade (oblaka). To znači da sustav može istovremeno podržati velik broj korisnika i uvijek je dostupan kad vam treba.

## Kako sve to funkcionira zajedno:

Započinjete postavljanjem pitanja na recepciji (UI).
Menadžer (MCP Server) odlučuje koji specijalist (agent) će vam pomoći.
Specijalist koristi jezičnog stručnjaka (OpenAI) da razumije vaš zahtjev i knjižnicu (AI Search) da pronađe najbolji odgovor.
Čuvar sigurnosti (Autentikacija) osigurava da je sve sigurno.
Sve se to odvija unutar pouzdane, skalabilne zgrade (Azure Container Apps), pa je vaše iskustvo glatko i sigurno.
Ova suradnja omogućuje sustavu da brzo i sigurno pomogne u planiranju vašeg putovanja, baš kao tim stručnih agenata za putovanja koji rade zajedno u modernom uredu!

## Tehnička implementacija
- **MCP Server:** Hostira osnovnu logiku orkestracije, izlaže alate agenata i upravlja kontekstom za višestepene tijekove planiranja putovanja.
- **Agenti:** Svaki agent (npr. FlightAgent, HotelAgent) implementiran je kao MCP alat sa svojim predlošcima za promptove i logikom.
- **Azure integracija:** Koristi Azure OpenAI za razumijevanje prirodnog jezika i Azure AI Search za dohvat podataka.
- **Sigurnost:** Integrira se s Microsoft Entra ID za autentikaciju i primjenjuje kontrole pristupa s najmanjim potrebnim privilegijama za sve resurse.
- **Implementacija:** Podržava implementaciju na Azure Container Apps radi skalabilnosti i operativne učinkovitosti.

## Rezultati i utjecaj
- Pokazuje kako se MCP može koristiti za orkestraciju više AI agenata u stvarnom, proizvodnom okruženju.
- Ubrzava razvoj rješenja pružajući ponovljive obrasce za koordinaciju agenata, integraciju podataka i sigurnu implementaciju.
- Služi kao nacrt za izgradnju domenom specifičnih, AI-pokretanih aplikacija koristeći MCP i Azure usluge.

## Reference
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prijevod [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Nismo odgovorni za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.