<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:44:36+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sr"
}
-->
# Studija slučaja: Azure AI Travel Agents – Referentna implementacija

## Pregled

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) je sveobuhvatno referentno rešenje koje je razvio Microsoft i koje pokazuje kako izgraditi aplikaciju za planiranje putovanja sa više agenata pokretanu veštačkom inteligencijom, koristeći Model Context Protocol (MCP), Azure OpenAI i Azure AI Search. Ovaj projekat prikazuje najbolje prakse za koordinaciju više AI agenata, integraciju poslovnih podataka i pružanje sigurne, proširive platforme za realne scenarije.

## Ključne karakteristike
- **Orkestracija više agenata:** Koristi MCP za koordinaciju specijalizovanih agenata (npr. za letove, hotele i itinerere) koji zajedno rade na složenim zadacima planiranja putovanja.
- **Integracija poslovnih podataka:** Povezuje se sa Azure AI Search i drugim poslovnim izvorima podataka kako bi pružio aktuelne i relevantne informacije za preporuke putovanja.
- **Sigurna, skalabilna arhitektura:** Koristi Azure servise za autentifikaciju, autorizaciju i skalabilno postavljanje, prateći najbolje prakse u oblasti bezbednosti za preduzeća.
- **Proširivi alati:** Implementira ponovo upotrebljive MCP alate i šablone za upite, omogućavajući brzu prilagodbu novim domenima ili poslovnim zahtevima.
- **Korisničko iskustvo:** Pruža konverzacioni interfejs za korisnike da komuniciraju sa agentima za putovanja, pokretan Azure OpenAI i MCP-om.

## Arhitektura
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Opis dijagrama arhitekture

Rešenje Azure AI Travel Agents je dizajnirano za modularnost, skalabilnost i sigurnu integraciju više AI agenata i poslovnih izvora podataka. Glavne komponente i tok podataka su sledeći:

- **Korisnički interfejs:** Korisnici komuniciraju sa sistemom putem konverzacionog UI-ja (kao što su web chat ili Teams bot), koji šalje korisničke upite i prima preporuke za putovanja.
- **MCP Server:** Djeluje kao centralni orkestrator, prima korisnički unos, upravlja kontekstom i koordinira rad specijalizovanih agenata (npr. FlightAgent, HotelAgent, ItineraryAgent) putem Model Context Protocol-a.
- **AI agenti:** Svaki agent je odgovoran za određenu oblast (letove, hotele, itinerere) i implementiran je kao MCP alat. Agenti koriste šablone za upite i logiku da obrađuju zahteve i generišu odgovore.
- **Azure OpenAI Service:** Omogućava napredno razumevanje i generisanje prirodnog jezika, pomažući agentima da protumače korisničke namere i daju konverzacione odgovore.
- **Azure AI Search i poslovni podaci:** Agenti pretražuju Azure AI Search i druge izvore podataka da bi pribavili najnovije informacije o letovima, hotelima i opcijama putovanja.
- **Autentifikacija i bezbednost:** Integracija sa Microsoft Entra ID-om za sigurnu autentifikaciju i primena principa najmanjih privilegija za pristup svim resursima.
- **Postavljanje:** Dizajnirano za postavljanje na Azure Container Apps, što obezbeđuje skalabilnost, nadzor i efikasnost u radu.

Ova arhitektura omogućava nesmetanu orkestraciju više AI agenata, sigurnu integraciju sa poslovnim podacima i robusnu, proširivu platformu za izgradnju AI rešenja specifičnih za određene domene.

## Detaljno objašnjenje dijagrama arhitekture
Zamislite da planirate veliko putovanje i da imate tim stručnih pomoćnika koji vam pomažu sa svakim detaljem. Sistem Azure AI Travel Agents funkcioniše na sličan način, koristeći različite delove (kao članove tima) koji imaju posebne zadatke. Evo kako se sve uklapa:

### Korisnički interfejs (UI):
Zamislite ovo kao recepciju vašeg putničkog agenta. Tu vi (korisnik) postavljate pitanja ili pravite zahteve, na primer: „Pronađi mi let za Pariz.“ To može biti prozor za čet na web stranici ili aplikaciji za poruke.

### MCP Server (Koordinator):
MCP Server je kao menadžer koji sluša vaš zahtev na recepciji i odlučuje koji specijalista treba da se pozabavi kojim delom. On prati vašu konverzaciju i osigurava da sve funkcioniše bez problema.

### AI agenti (Specijalizovani pomoćnici):
Svaki agent je stručnjak za određenu oblast — jedan zna sve o letovima, drugi o hotelima, a treći o planiranju itinerera. Kada zatražite putovanje, MCP Server šalje vaš zahtev pravom agentu/agentima. Ti agenti koriste svoje znanje i alate da pronađu najbolje opcije za vas.

### Azure OpenAI Service (Jezicki ekspert):
Ovo je kao da imate jezičkog eksperta koji tačno razume šta tražite, bez obzira kako to formulišete. Pomaže agentima da shvate vaše zahteve i odgovore prirodnim, konverzacionim jezikom.

### Azure AI Search i poslovni podaci (Biblioteka informacija):
Zamislite ogromnu, ažuriranu biblioteku sa svim najnovijim informacijama o putovanjima — rasporedima letova, dostupnosti hotela i slično. Agenti pretražuju ovu biblioteku da bi vam dali najpreciznije odgovore.

### Autentifikacija i bezbednost (Čuvar bezbednosti):
Kao što čuvar proverava ko može da uđe u određene prostorije, ovaj deo osigurava da samo ovlašćeni ljudi i agenti imaju pristup osetljivim informacijama. Vaši podaci su zaštićeni i privatni.

### Postavljanje na Azure Container Apps (Zgrada):
Svi ovi pomoćnici i alati rade zajedno unutar sigurne, skalabilne zgrade (oblaka). To znači da sistem može da podrži veliki broj korisnika istovremeno i uvek je dostupan kad vam zatreba.

## Kako sve funkcioniše zajedno:

Počinjete tako što postavite pitanje na recepciji (UI).
Menadžer (MCP Server) odlučuje koji specijalista (agent) treba da vam pomogne.
Specijalista koristi jezičkog eksperta (OpenAI) da razume vaš zahtev i biblioteku (AI Search) da pronađe najbolji odgovor.
Čuvar bezbednosti (Autentifikacija) se brine da je sve sigurno.
Sve se ovo odvija u pouzdanoj, skalabilnoj zgradi (Azure Container Apps), tako da je vaše iskustvo glatko i sigurno.
Ova saradnja omogućava sistemu da brzo i sigurno pomogne u planiranju vašeg putovanja, baš kao tim stručnih agenata za putovanja koji rade zajedno u modernom kancelarijskom okruženju!

## Tehnička implementacija
- **MCP Server:** Hostuje osnovnu logiku orkestracije, izlaže alate agenata i upravlja kontekstom za višestepene tokove planiranja putovanja.
- **Agenti:** Svaki agent (npr. FlightAgent, HotelAgent) je implementiran kao MCP alat sa sopstvenim šablonima upita i logikom.
- **Azure integracija:** Koristi Azure OpenAI za razumevanje prirodnog jezika i Azure AI Search za preuzimanje podataka.
- **Bezbednost:** Integracija sa Microsoft Entra ID za autentifikaciju i primena principa najmanjih privilegija za pristup svim resursima.
- **Postavljanje:** Podržava postavljanje na Azure Container Apps radi skalabilnosti i efikasnosti u radu.

## Rezultati i uticaj
- Pokazuje kako se MCP može koristiti za orkestraciju više AI agenata u realnom, produkcijskom okruženju.
- Ubrzava razvoj rešenja pružajući ponovo upotrebljive obrasce za koordinaciju agenata, integraciju podataka i sigurno postavljanje.
- Služi kao vodič za izgradnju AI aplikacija specifičnih za određene domene koristeći MCP i Azure servise.

## Reference
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korišćenjem AI servisa za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo tačnosti, imajte na umu da automatski prevodi mogu sadržati greške ili netačnosti. Originalni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prevod. Ne snosimo odgovornost za bilo kakva nesporazumevanja ili pogrešna tumačenja koja proisteknu iz korišćenja ovog prevoda.