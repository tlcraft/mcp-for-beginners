<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:44:52+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hr"
}
-->
# Case Study: Azure AI Travel Agents – Referentna Implementacija

## Pregled

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) je sveobuhvatno referentno rješenje koje je razvio Microsoft, a koje pokazuje kako izgraditi aplikaciju za planiranje putovanja s više agenata i umjetnom inteligencijom koristeći Model Context Protocol (MCP), Azure OpenAI i Azure AI Search. Ovaj projekt prikazuje najbolje prakse za koordinaciju više AI agenata, integraciju podataka poduzeća i pružanje sigurne, proširive platforme za stvarne scenarije.

## Ključne značajke
- **Orkestracija više agenata:** Koristi MCP za koordinaciju specijaliziranih agenata (npr. za letove, hotele i itinerere) koji surađuju kako bi ispunili složene zadatke planiranja putovanja.
- **Integracija podataka poduzeća:** Povezuje se s Azure AI Search i drugim izvorima podataka poduzeća kako bi pružio ažurirane i relevantne informacije za preporuke putovanja.
- **Sigurna i skalabilna arhitektura:** Iskorištava Azure usluge za autentifikaciju, autorizaciju i skalabilno postavljanje, slijedeći najbolje sigurnosne prakse poduzeća.
- **Proširivi alati:** Implementira višekratno upotrebljive MCP alate i predloške za promptove, omogućujući brzu prilagodbu novim domenama ili poslovnim zahtjevima.
- **Korisničko iskustvo:** Pruža razgovorni sučelje korisnicima za interakciju s agentima za putovanja, pokretano Azure OpenAI i MCP-om.

## Arhitektura
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Opis dijagrama arhitekture

Rješenje Azure AI Travel Agents je dizajnirano za modularnost, skalabilnost i sigurnu integraciju više AI agenata i izvora podataka poduzeća. Glavne komponente i protok podataka su sljedeći:

- **Korisničko sučelje:** Korisnici komuniciraju sa sustavom putem razgovornog sučelja (poput web chata ili Teams bota), koje šalje upite korisnika i prima preporuke za putovanja.
- **MCP Server:** Djeluje kao središnji orkestrator, prima korisničke upite, upravlja kontekstom i koordinira rad specijaliziranih agenata (npr. FlightAgent, HotelAgent, ItineraryAgent) putem Model Context Protocola.
- **AI Agenti:** Svaki agent je odgovoran za određenu domenu (letovi, hoteli, itinereri) i implementiran je kao MCP alat. Agenti koriste predloške promptova i logiku za obradu zahtjeva i generiranje odgovora.
- **Azure OpenAI Service:** Pruža napredno razumijevanje i generiranje prirodnog jezika, omogućujući agentima da interpretiraju korisničke namjere i generiraju razgovorne odgovore.
- **Azure AI Search & Podaci poduzeća:** Agenti pretražuju Azure AI Search i druge izvore podataka poduzeća kako bi dohvatili najnovije informacije o letovima, hotelima i opcijama putovanja.
- **Autentifikacija i sigurnost:** Integrira se s Microsoft Entra ID za sigurnu autentifikaciju i primjenjuje kontrole pristupa s najmanjim privilegijama na sve resurse.
- **Postavljanje:** Dizajnirano za postavljanje na Azure Container Apps, osiguravajući skalabilnost, nadzor i operativnu učinkovitost.

Ova arhitektura omogućuje besprijekornu orkestraciju više AI agenata, sigurnu integraciju s podacima poduzeća i robusnu, proširivu platformu za izgradnju AI rješenja specifičnih za domenu.

## Korak-po-korak objašnjenje dijagrama arhitekture
Zamislite da planirate veliko putovanje i imate tim stručnih pomoćnika koji vam pomažu sa svakim detaljem. Sustav Azure AI Travel Agents radi na sličan način, koristeći različite dijelove (kao članove tima), od kojih svaki ima posebnu ulogu. Evo kako se sve uklapa:

### Korisničko sučelje (UI):
Zamislite ovo kao recepciju vašeg putničkog agenta. Tu vi (korisnik) postavljate pitanja ili upite, poput "Pronađi mi let za Pariz." To može biti chat prozor na web stranici ili aplikaciji za poruke.

### MCP Server (Koordinator):
MCP Server je kao menadžer koji sluša vaš zahtjev na recepciji i odlučuje koji specijalist treba obraditi svaki dio. On prati vaš razgovor i osigurava da sve teče glatko.

### AI Agenti (Specijalizirani pomoćnici):
Svaki agent je stručnjak za određeno područje – jedan zna sve o letovima, drugi o hotelima, a treći o planiranju itinerera. Kad zatražite putovanje, MCP Server šalje vaš zahtjev pravom agentu ili agentima. Ti agenti koriste svoje znanje i alate kako bi pronašli najbolje opcije za vas.

### Azure OpenAI Service (Stručnjak za jezik):
To je kao da imate jezičnog stručnjaka koji točno razumije što tražite, bez obzira kako ste to formulirali. Pomaže agentima da razumiju vaše zahtjeve i odgovore na prirodan, razgovorni način.

### Azure AI Search & Podaci poduzeća (Informacijska knjižnica):
Zamislite ogromnu, uvijek ažuriranu knjižnicu sa svim najnovijim informacijama o putovanjima – rasporedima letova, dostupnosti hotela i još mnogo toga. Agenti pretražuju ovu knjižnicu kako bi vam dali najtočnije odgovore.

### Autentifikacija i sigurnost (Sigurnosnik):
Baš kao što sigurnosnik provjerava tko može ući u određene prostorije, ovaj dio osigurava da samo ovlaštene osobe i agenti mogu pristupiti osjetljivim informacijama. Čuva vaše podatke sigurnima i privatnima.

### Postavljanje na Azure Container Apps (Zgrada):
Svi ovi pomoćnici i alati rade zajedno unutar sigurne, skalabilne zgrade (oblaka). To znači da sustav može istovremeno podržavati mnogo korisnika i uvijek je dostupan kad vam treba.

## Kako sve funkcionira zajedno:

Počinjete tako da postavite pitanje na recepciji (UI).
Menadžer (MCP Server) odlučuje koji specijalist (agent) će vam pomoći.
Specijalist koristi jezičnog stručnjaka (OpenAI) da razumije vaš zahtjev i knjižnicu (AI Search) da pronađe najbolji odgovor.
Sigurnosnik (Autentifikacija) osigurava da je sve sigurno.
Sve se to događa unutar pouzdane, skalabilne zgrade (Azure Container Apps), tako da je vaše iskustvo glatko i sigurno.
Ova suradnja omogućava sustavu da brzo i sigurno pomogne u planiranju vašeg putovanja, kao pravi tim stručnih putničkih agenata koji rade zajedno u modernom uredu!

## Tehnička implementacija
- **MCP Server:** Hostira osnovnu logiku orkestracije, izlaže alate agenata i upravlja kontekstom za višekorake tokove planiranja putovanja.
- **Agenti:** Svaki agent (npr. FlightAgent, HotelAgent) implementiran je kao MCP alat sa svojim predlošcima promptova i logikom.
- **Integracija s Azure:** Koristi Azure OpenAI za razumijevanje prirodnog jezika i Azure AI Search za dohvat podataka.
- **Sigurnost:** Integrira se s Microsoft Entra ID za autentifikaciju i primjenjuje kontrole pristupa s najmanjim privilegijama na sve resurse.
- **Postavljanje:** Podržava postavljanje na Azure Container Apps radi skalabilnosti i operativne učinkovitosti.

## Rezultati i utjecaj
- Pokazuje kako se MCP može koristiti za orkestraciju više AI agenata u stvarnom, produkcijskom okruženju.
- Ubrzava razvoj rješenja pružajući višekratno upotrebljive obrasce za koordinaciju agenata, integraciju podataka i sigurno postavljanje.
- Služi kao predložak za izgradnju domen-specifičnih aplikacija s umjetnom inteligencijom koristeći MCP i Azure usluge.

## Reference
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Izjava o odricanju od odgovornosti**:  
Ovaj dokument preveden je pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za važne informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili kriva tumačenja koja proizlaze iz korištenja ovog prijevoda.