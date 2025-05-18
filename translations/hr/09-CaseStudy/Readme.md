<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:36:26+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "hr"
}
-->
# Studija slučaja: Azure AI Putnički agenti – Referentna implementacija

## Pregled

[Azure AI Putnički agenti](https://github.com/Azure-Samples/azure-ai-travel-agents) je sveobuhvatno referentno rješenje razvijeno od strane Microsofta koje demonstrira kako izgraditi aplikaciju za planiranje putovanja s više agenata, pogonjenom umjetnom inteligencijom, koristeći Model Context Protocol (MCP), Azure OpenAI i Azure AI Search. Ovaj projekt prikazuje najbolje prakse za orkestraciju više AI agenata, integraciju podataka iz poduzeća i pružanje sigurne, proširive platforme za stvarne scenarije.

## Ključne značajke
- **Orkestracija više agenata:** Koristi MCP za koordinaciju specijaliziranih agenata (npr. agenata za letove, hotele i itinerere) koji surađuju kako bi ispunili složene zadatke planiranja putovanja.
- **Integracija podataka iz poduzeća:** Povezuje se s Azure AI Search i drugim izvorima podataka iz poduzeća kako bi pružio ažurirane, relevantne informacije za preporuke putovanja.
- **Sigurna, skalabilna arhitektura:** Koristi Azure usluge za autentifikaciju, autorizaciju i skalabilno postavljanje, slijedeći najbolje prakse sigurnosti u poduzeću.
- **Proširivi alati:** Implementira ponovno upotrebljive MCP alate i predloške upita, omogućujući brzo prilagođavanje novim domenama ili poslovnim zahtjevima.
- **Korisničko iskustvo:** Pruža sučelje za razgovor za interakciju korisnika s putničkim agentima, pogonjeno Azure OpenAI i MCP.

## Arhitektura
![Arhitektura](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Opis dijagrama arhitekture

Rješenje Azure AI Putnički agenti je projektirano za modularnost, skalabilnost i sigurnu integraciju više AI agenata i izvora podataka iz poduzeća. Glavne komponente i tok podataka su sljedeći:

- **Korisničko sučelje:** Korisnici komuniciraju sa sustavom putem razgovornog sučelja (kao što je web chat ili Teams bot), koje šalje upite korisnika i prima preporuke za putovanja.
- **MCP Server:** Služi kao centralni orkestrator, prima korisnički unos, upravlja kontekstom i koordinira akcije specijaliziranih agenata (npr. FlightAgent, HotelAgent, ItineraryAgent) putem Model Context Protocola.
- **AI Agenti:** Svaki agent je odgovoran za specifičnu domenu (letovi, hoteli, itinereri) i implementiran je kao MCP alat. Agenti koriste predloške upita i logiku za obradu zahtjeva i generiranje odgovora.
- **Azure OpenAI Service:** Pruža napredno razumijevanje i generiranje prirodnog jezika, omogućujući agentima da interpretiraju namjere korisnika i generiraju razgovorne odgovore.
- **Azure AI Search & Podaci iz poduzeća:** Agenti pretražuju Azure AI Search i druge izvore podataka iz poduzeća kako bi dobili ažurirane informacije o letovima, hotelima i opcijama putovanja.
- **Autentifikacija i sigurnost:** Integrira se s Microsoft Entra ID za sigurnu autentifikaciju i primjenjuje kontrole pristupa najmanjeg privilegija na sve resurse.
- **Postavljanje:** Dizajnirano za postavljanje na Azure Container Apps, osiguravajući skalabilnost, praćenje i operativnu učinkovitost.

Ova arhitektura omogućuje besprijekornu orkestraciju više AI agenata, sigurnu integraciju s podacima iz poduzeća i robusnu, proširivu platformu za izgradnju AI rješenja specifičnih za domenu.

## Objašnjenje korak po korak dijagrama arhitekture
Zamislite planiranje velikog putovanja i imati tim stručnih asistenata koji vam pomažu u svakom detalju. Sustav Azure AI Putnički agenti radi na sličan način, koristeći različite dijelove (poput članova tima) koji svaki imaju poseban zadatak. Evo kako sve to funkcionira zajedno:

### Korisničko sučelje (UI):
Zamislite ovo kao prednji pult vašeg putničkog agenta. To je mjesto gdje vi (korisnik) postavljate pitanja ili zahtjeve, poput "Pronađi mi let za Pariz." To može biti prozor za chat na web stranici ili aplikacija za razmjenu poruka.

### MCP Server (Koordinator):
MCP Server je poput upravitelja koji sluša vaš zahtjev na prednjem pultu i odlučuje koji stručnjak treba obraditi svaki dio. Prati vašu konverzaciju i osigurava da sve teče glatko.

### AI Agenti (Stručni asistenti):
Svaki agent je stručnjak u određenom području—jedan zna sve o letovima, drugi o hotelima, a treći o planiranju vašeg itinerera. Kada zatražite putovanje, MCP Server šalje vaš zahtjev odgovarajućem agentu(ima). Ovi agenti koriste svoje znanje i alate da pronađu najbolje opcije za vas.

### Azure OpenAI Service (Jezik stručnjak):
Ovo je kao imati stručnjaka za jezike koji točno razumije što tražite, bez obzira kako to izrazite. Pomaže agentima da razumiju vaše zahtjeve i odgovore u prirodnom, razgovornom jeziku.

### Azure AI Search & Podaci iz poduzeća (Informacijska biblioteka):
Zamislite ogromnu, ažuriranu biblioteku sa svim najnovijim informacijama o putovanjima—rasporedima letova, dostupnosti hotela i više. Agenti pretražuju ovu biblioteku kako bi dobili najtočnije odgovore za vas.

### Autentifikacija i sigurnost (Sigurnosni čuvar):
Kao što sigurnosni čuvar provjerava tko može ući u određena područja, ovaj dio osigurava da samo ovlaštene osobe i agenti mogu pristupiti osjetljivim informacijama. Čuva vaše podatke sigurnima i privatnima.

### Postavljanje na Azure Container Apps (Zgrada):
Svi ovi asistenti i alati rade zajedno unutar sigurne, skalabilne zgrade (oblaka). To znači da sustav može obraditi puno korisnika odjednom i uvijek je dostupan kad ga trebate.

## Kako sve to funkcionira zajedno:

Počinjete postavljanjem pitanja na prednjem pultu (UI).
Upravitelj (MCP Server) odlučuje koji stručnjak (agent) treba pomoći.
Stručnjak koristi jezičnog stručnjaka (OpenAI) da razumije vaš zahtjev i biblioteku (AI Search) da pronađe najbolji odgovor.
Sigurnosni čuvar (Autentifikacija) osigurava da je sve sigurno.
Sve se ovo događa unutar pouzdane, skalabilne zgrade (Azure Container Apps), tako da vaše iskustvo bude glatko i sigurno.
Ova timska suradnja omogućuje sustavu da brzo i sigurno pomogne u planiranju vašeg putovanja, baš kao tim stručnih putničkih agenata koji zajedno rade u modernom uredu!

## Tehnička implementacija
- **MCP Server:** Hostira osnovnu logiku orkestracije, izlaže alate agenata i upravlja kontekstom za višekorake radne tokove planiranja putovanja.
- **Agenti:** Svaki agent (npr. FlightAgent, HotelAgent) implementiran je kao MCP alat sa svojim predlošcima upita i logikom.
- **Integracija s Azure:** Koristi Azure OpenAI za razumijevanje prirodnog jezika i Azure AI Search za dohvat podataka.
- **Sigurnost:** Integrira se s Microsoft Entra ID za autentifikaciju i primjenjuje kontrole pristupa najmanjeg privilegija na sve resurse.
- **Postavljanje:** Podržava postavljanje na Azure Container Apps za skalabilnost i operativnu učinkovitost.

## Rezultati i utjecaj
- Demonstrira kako se MCP može koristiti za orkestraciju više AI agenata u stvarnom, produkcijskom scenariju.
- Ubrzava razvoj rješenja pružanjem ponovljivih obrazaca za koordinaciju agenata, integraciju podataka i sigurno postavljanje.
- Služi kao nacrt za izgradnju aplikacija pogonjenih umjetnom inteligencijom specifičnih za domenu koristeći MCP i Azure usluge.

## Reference
- [Azure AI Putnički agenti GitHub repozitorij](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Odricanje odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako se trudimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne odgovaramo za nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.