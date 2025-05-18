<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:36:04+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "sr"
}
-->
# Studija slučaja: Azure AI turistički agenti – referentna implementacija

## Pregled

[Azure AI turistički agenti](https://github.com/Azure-Samples/azure-ai-travel-agents) je sveobuhvatno referentno rešenje koje je razvio Microsoft i pokazuje kako izgraditi aplikaciju za planiranje putovanja sa više agenata, pokretanu veštačkom inteligencijom, koristeći Model Context Protocol (MCP), Azure OpenAI i Azure AI Search. Ovaj projekat prikazuje najbolje prakse za orkestraciju više AI agenata, integraciju poslovnih podataka i obezbeđivanje sigurne, proširive platforme za stvarne scenarije.

## Ključne funkcije
- **Orkestracija sa više agenata:** Koristi MCP za koordinaciju specijalizovanih agenata (npr. agenata za letove, hotele i itinerere) koji sarađuju kako bi ispunili složene zadatke planiranja putovanja.
- **Integracija poslovnih podataka:** Povezuje se sa Azure AI Search i drugim izvorima poslovnih podataka kako bi pružio ažurirane, relevantne informacije za preporuke putovanja.
- **Sigurna, skalabilna arhitektura:** Koristi Azure usluge za autentifikaciju, autorizaciju i skalabilno postavljanje, prateći najbolje prakse sigurnosti preduzeća.
- **Proširivi alati:** Implementira ponovo upotrebljive MCP alate i šablone upita, omogućavajući brzu adaptaciju na nove domene ili poslovne zahteve.
- **Korisničko iskustvo:** Pruža konverzacioni interfejs za korisnike da interaguju sa turističkim agentima, pokretan Azure OpenAI i MCP.

## Arhitektura
![Arhitektura](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Opis dijagrama arhitekture

Rešenje Azure AI turističkih agenata je projektovano za modularnost, skalabilnost i sigurnu integraciju više AI agenata i izvora poslovnih podataka. Glavne komponente i tok podataka su sledeći:

- **Korisnički interfejs:** Korisnici interaguju sa sistemom putem konverzacionog UI (kao što je web chat ili Teams bot), koji šalje korisničke upite i prima preporuke za putovanja.
- **MCP Server:** Služi kao centralni orkestrator, prima korisničke unose, upravlja kontekstom i koordinira akcije specijalizovanih agenata (npr. FlightAgent, HotelAgent, ItineraryAgent) putem Model Context Protocol-a.
- **AI Agenti:** Svaki agent je odgovoran za specifičnu oblast (letovi, hoteli, itinereri) i implementiran je kao MCP alat. Agenti koriste šablone upita i logiku za obradu zahteva i generisanje odgovora.
- **Azure OpenAI usluga:** Pruža napredno razumevanje prirodnog jezika i generisanje, omogućavajući agentima da interpretiraju korisničke namere i generišu konverzacione odgovore.
- **Azure AI Search & Poslovni podaci:** Agenti pretražuju Azure AI Search i druge izvore poslovnih podataka kako bi dobili ažurirane informacije o letovima, hotelima i opcijama putovanja.
- **Autentifikacija i sigurnost:** Integracija sa Microsoft Entra ID za sigurnu autentifikaciju i primena kontrola pristupa sa najmanjim privilegijama na sve resurse.
- **Postavljanje:** Projektovano za postavljanje na Azure Container Apps, obezbeđujući skalabilnost, monitoring i operativnu efikasnost.

Ova arhitektura omogućava besprekornu orkestraciju više AI agenata, sigurnu integraciju sa poslovnim podacima i robusnu, proširivu platformu za izgradnju AI rešenja specifičnih za domenu.

## Objašnjenje korak-po-korak dijagrama arhitekture
Zamislite planiranje velikog putovanja i tim stručnih asistenata koji vam pomažu sa svakim detaljem. Sistem Azure AI turističkih agenata radi na sličan način, koristeći različite delove (kao članove tima) koji svaki imaju poseban zadatak. Evo kako sve funkcioniše zajedno:

### Korisnički interfejs (UI):
Zamislite ovo kao prednji sto vašeg turističkog agenta. Tu vi (korisnik) postavljate pitanja ili pravite zahteve, kao što je "Pronađi mi let za Pariz." Ovo može biti prozor za chat na web stranici ili aplikacija za poruke.

### MCP Server (Koordinator):
MCP Server je kao menadžer koji sluša vaš zahtev na prednjem stolu i odlučuje koji specijalista treba da obradi svaki deo. On prati vašu konverzaciju i osigurava da sve teče glatko.

### AI Agenti (Specijalizovani asistenti):
Svaki agent je ekspert u određenoj oblasti—jedan zna sve o letovima, drugi o hotelima, a treći o planiranju vašeg itinerera. Kada tražite putovanje, MCP Server šalje vaš zahtev odgovarajućem agentu(ima). Ovi agenti koriste svoje znanje i alate da pronađu najbolje opcije za vas.

### Azure OpenAI usluga (Ekspert za jezik):
Ovo je kao imati eksperta za jezik koji tačno razume šta tražite, bez obzira kako to formulišete. Pomaže agentima da razumeju vaše zahteve i odgovore u prirodnom, konverzacionom jeziku.

### Azure AI Search & Poslovni podaci (Biblioteka informacija):
Zamislite ogromnu, ažuriranu biblioteku sa svim najnovijim informacijama o putovanjima—rasporedima letova, dostupnosti hotela i još mnogo toga. Agenti pretražuju ovu biblioteku da dobiju najtačnije odgovore za vas.

### Autentifikacija i sigurnost (Sigurnosni čuvar):
Baš kao što sigurnosni čuvar proverava ko može ući u određene oblasti, ovaj deo osigurava da samo ovlašćeni ljudi i agenti mogu pristupiti osetljivim informacijama. Čuva vaše podatke sigurnim i privatnim.

### Postavljanje na Azure Container Apps (Zgrada):
Svi ovi asistenti i alati rade zajedno unutar sigurne, skalabilne zgrade (oblaka). To znači da sistem može da obradi mnogo korisnika odjednom i uvek je dostupan kada vam je potreban.

## Kako sve funkcioniše zajedno:

Počinjete postavljanjem pitanja na prednjem stolu (UI).
Menadžer (MCP Server) odlučuje koji specijalista (agent) treba da vam pomogne.
Specijalista koristi jezičkog eksperta (OpenAI) da razume vaš zahtev i biblioteku (AI Search) da pronađe najbolji odgovor.
Sigurnosni čuvar (Autentifikacija) osigurava da je sve sigurno.
Sve ovo se dešava unutar pouzdane, skalabilne zgrade (Azure Container Apps), tako da je vaše iskustvo glatko i sigurno.
Ovaj timski rad omogućava sistemu da brzo i sigurno pomogne u planiranju vašeg putovanja, baš kao tim stručnih turističkih agenata koji rade zajedno u modernoj kancelariji!

## Tehnička implementacija
- **MCP Server:** Hostuje osnovnu logiku orkestracije, izlaže alate agenata i upravlja kontekstom za radne tokove planiranja putovanja sa više koraka.
- **Agenti:** Svaki agent (npr. FlightAgent, HotelAgent) je implementiran kao MCP alat sa svojim šablonima upita i logikom.
- **Azure Integracija:** Koristi Azure OpenAI za razumevanje prirodnog jezika i Azure AI Search za preuzimanje podataka.
- **Sigurnost:** Integracija sa Microsoft Entra ID za autentifikaciju i primena kontrola pristupa sa najmanjim privilegijama na sve resurse.
- **Postavljanje:** Podržava postavljanje na Azure Container Apps za skalabilnost i operativnu efikasnost.

## Rezultati i uticaj
- Pokazuje kako se MCP može koristiti za orkestraciju više AI agenata u stvarnom, proizvodnom scenariju.
- Ubrzava razvoj rešenja pružajući ponovo upotrebljive obrasce za koordinaciju agenata, integraciju podataka i sigurno postavljanje.
- Služi kao nacrt za izgradnju aplikacija pokretanih veštačkom inteligencijom specifičnih za domenu koristeći MCP i Azure usluge.

## Reference
- [Azure AI turistički agenti GitHub repozitorijum](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI usluga](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Одрицање од одговорности**:  
Овај документ је преведен користећи услугу превођења вештачке интелигенције [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо ка тачности, молимо вас да будете свесни да аутоматизовани преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати меродавним извором. За критичне информације, препоручује се професионални људски превод. Не сносимо одговорност за било каква неспоразума или погрешна тумачења која произилазе из коришћења овог превода.