<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:54:18+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "sr"
}
-->
# Studija slučaja: Azure AI Travel Agents – Referentna implementacija

## Pregled

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) je sveobuhvatno referentno rešenje koje je razvio Microsoft, a koje pokazuje kako napraviti aplikaciju za planiranje putovanja sa više agenata pokretanih veštačkom inteligencijom koristeći Model Context Protocol (MCP), Azure OpenAI i Azure AI Search. Ovaj projekat demonstrira najbolje prakse za orkestraciju više AI agenata, integraciju podataka preduzeća i pružanje sigurne, proširive platforme za realne scenarije.

## Ključne karakteristike
- **Orkestracija više agenata:** Koristi MCP za koordinaciju specijalizovanih agenata (npr. za letove, hotele i itinerere) koji sarađuju kako bi izvršili složene zadatke planiranja putovanja.
- **Integracija podataka preduzeća:** Povezuje se sa Azure AI Search i drugim izvorima podataka preduzeća da bi pružio aktuelne i relevantne informacije za preporuke putovanja.
- **Sigurna, skalabilna arhitektura:** Iskorišćava Azure servise za autentifikaciju, autorizaciju i skalabilno postavljanje, prateći najbolje bezbednosne prakse preduzeća.
- **Proširivi alati:** Implementira ponovo upotrebljive MCP alate i predloške za promptove, omogućavajući brzu prilagodbu novim domenima ili poslovnim zahtevima.
- **Korisničko iskustvo:** Pruža konverzacijski interfejs za korisnike da komuniciraju sa agentima za putovanja, pokretan Azure OpenAI i MCP-om.

## Arhitektura
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Opis dijagrama arhitekture

Rešenje Azure AI Travel Agents je dizajnirano za modularnost, skalabilnost i sigurnu integraciju više AI agenata i izvora podataka preduzeća. Glavni delovi i tok podataka su sledeći:

- **Korisnički interfejs:** Korisnici komuniciraju sa sistemom putem konverzacionog UI-ja (kao što je web chat ili Teams bot), koji šalje korisničke upite i prima preporuke za putovanja.
- **MCP Server:** Deluje kao centralni orkestrator, prima korisničke ulaze, upravlja kontekstom i koordinira rad specijalizovanih agenata (npr. FlightAgent, HotelAgent, ItineraryAgent) preko Model Context Protocol-a.
- **AI agenti:** Svaki agent je zadužen za određenu oblast (letovi, hoteli, itinereri) i implementiran je kao MCP alat. Agenti koriste predloške za promptove i logiku da obrađuju zahteve i generišu odgovore.
- **Azure OpenAI Service:** Omogućava napredno razumevanje i generisanje prirodnog jezika, što pomaže agentima da interpretiraju korisničke namere i daju konverzacijske odgovore.
- **Azure AI Search i podaci preduzeća:** Agenti pretražuju Azure AI Search i druge izvore podataka preduzeća da bi pribavili najnovije informacije o letovima, hotelima i opcijama putovanja.
- **Autentifikacija i sigurnost:** Integrisan sa Microsoft Entra ID za sigurnu autentifikaciju i primenjuje pristup sa najmanjim privilegijama na sve resurse.
- **Postavljanje:** Dizajniran za postavljanje na Azure Container Apps, što obezbeđuje skalabilnost, nadzor i efikasnost rada.

Ova arhitektura omogućava neprimetnu orkestraciju više AI agenata, sigurnu integraciju sa podacima preduzeća i robusnu, proširivu platformu za izgradnju AI rešenja specifičnih za određene domene.

## Detaljno objašnjenje dijagrama arhitekture
Zamislite da planirate veliko putovanje i imate tim stručnih pomoćnika koji vam pomažu sa svakim detaljem. Sistem Azure AI Travel Agents funkcioniše na sličan način, koristeći različite delove (kao članove tima) koji svaki imaju svoju specijalnu ulogu. Evo kako sve to funkcioniše zajedno:

### Korisnički interfejs (UI):
Zamislite ovo kao recepciju vašeg putničkog agenta. Tu vi (korisnik) postavljate pitanja ili šaljete zahteve, kao što je „Pronađi mi let za Pariz.“ To može biti prozor za ćaskanje na veb sajtu ili aplikaciji za poruke.

### MCP Server (koordinator):
MCP Server je kao menadžer koji sluša vaš zahtev na recepciji i odlučuje koji specijalista treba da se pozabavi određenim delom. On prati vašu konverzaciju i osigurava da sve funkcioniše glatko.

### AI agenti (specijalistički pomoćnici):
Svaki agent je stručnjak za određenu oblast – jedan zna sve o letovima, drugi o hotelima, a treći o planiranju itinerera. Kada tražite putovanje, MCP Server šalje vaš zahtev odgovarajućem agentu/agentima. Ti agenti koriste svoje znanje i alate da pronađu najbolje opcije za vas.

### Azure OpenAI Service (jezički ekspert):
Ovo je kao da imate jezičkog stručnjaka koji tačno razume šta tražite, bez obzira kako to formulišete. Pomaže agentima da razumeju vaše zahteve i odgovaraju na prirodan, konverzacijski način.

### Azure AI Search i podaci preduzeća (biblioteka informacija):
Zamislite ogromnu, ažuriranu biblioteku sa svim najnovijim informacijama o putovanjima – rasporedima letova, dostupnosti hotela i još mnogo toga. Agenti pretražuju ovu biblioteku da bi vam dali najpreciznije odgovore.

### Autentifikacija i sigurnost (čuvar sigurnosti):
Baš kao što čuvar proverava ko može da uđe u određene prostorije, ovaj deo osigurava da samo ovlašćene osobe i agenti mogu pristupiti osetljivim informacijama. Čuva vaše podatke sigurnim i privatnim.

### Postavljanje na Azure Container Apps (zgrada):
Svi ovi pomoćnici i alati rade zajedno unutar sigurne, skalabilne zgrade (oblaka). To znači da sistem može da podrži veliki broj korisnika istovremeno i da je uvek dostupan kada vam treba.

## Kako sve funkcioniše zajedno:

Počinjete tako što postavite pitanje na recepciji (UI).
Menadžer (MCP Server) odlučuje koji specijalista (agent) treba da vam pomogne.
Specijalista koristi jezičkog eksperta (OpenAI) da razume vaš zahtev i biblioteku (AI Search) da pronađe najbolji odgovor.
Čuvar sigurnosti (Autentifikacija) vodi računa da je sve bezbedno.
Sve se ovo odvija unutar pouzdane, skalabilne zgrade (Azure Container Apps), tako da je vaše iskustvo glatko i sigurno.
Ova saradnja omogućava sistemu da brzo i sigurno pomogne u planiranju putovanja, baš kao tim stručnih agenata za putovanja koji rade zajedno u modernom kancelarijskom prostoru!

## Tehnička implementacija
- **MCP Server:** Hostuje osnovnu logiku orkestracije, izlaže alate agenata i upravlja kontekstom za višestepene tokove planiranja putovanja.
- **Agenti:** Svaki agent (npr. FlightAgent, HotelAgent) implementiran je kao MCP alat sa sopstvenim predlošcima za promptove i logikom.
- **Azure integracija:** Koristi Azure OpenAI za razumevanje prirodnog jezika i Azure AI Search za pristup podacima.
- **Sigurnost:** Integrisan sa Microsoft Entra ID za autentifikaciju i primenjuje pristup sa najmanjim privilegijama na sve resurse.
- **Postavljanje:** Podržava postavljanje na Azure Container Apps radi skalabilnosti i operativne efikasnosti.

## Rezultati i uticaj
- Pokazuje kako se MCP može koristiti za orkestraciju više AI agenata u stvarnom, produkcijskom okruženju.
- Ubrzava razvoj rešenja pružajući ponovo upotrebljive obrasce za koordinaciju agenata, integraciju podataka i sigurno postavljanje.
- Služi kao šablon za izgradnju domen-specifičnih aplikacija pokretanih AI koristeći MCP i Azure servise.

## Reference
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо прецизности, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални превод од стране људског преводиоца. Нисмо одговорни за било каква неспоразума или погрешна тумачења настала употребом овог превода.