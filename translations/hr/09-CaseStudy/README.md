<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-04T19:05:29+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hr"
}
-->
# MCP u praksi: Studije slučaja iz stvarnog svijeta

Model Context Protocol (MCP) mijenja način na koji AI aplikacije komuniciraju s podacima, alatima i uslugama. Ovaj odjeljak prikazuje studije slučaja iz stvarnog svijeta koje demonstriraju praktične primjene MCP-a u različitim poslovnim scenarijima.

## Pregled

Ovaj odjeljak prikazuje konkretne primjere implementacija MCP-a, ističući kako organizacije koriste ovaj protokol za rješavanje složenih poslovnih izazova. Analizom ovih studija slučaja dobit ćete uvid u svestranost, skalabilnost i praktične prednosti MCP-a u stvarnim situacijama.

## Ključni ciljevi učenja

Istražujući ove studije slučaja, naučit ćete:

- Kako se MCP može primijeniti za rješavanje specifičnih poslovnih problema
- Različite obrasce integracije i arhitektonske pristupe
- Najbolje prakse za implementaciju MCP-a u poslovnim okruženjima
- Izazove i rješenja s kojima se susreću stvarne implementacije
- Prilike za primjenu sličnih obrazaca u vlastitim projektima

## Istaknute studije slučaja

### 1. [Azure AI Travel Agents – Referentna implementacija](./travelagentsample.md)

Ova studija slučaja analizira Microsoftovo sveobuhvatno referentno rješenje koje pokazuje kako izgraditi aplikaciju za planiranje putovanja s više agenata, pokretanu AI-jem, koristeći MCP, Azure OpenAI i Azure AI Search. Projekt prikazuje:

- Orkestraciju više agenata putem MCP-a
- Integraciju podataka poduzeća s Azure AI Search
- Sigurnu i skalabilnu arhitekturu koristeći Azure usluge
- Proširive alate s ponovnim upotrebnim MCP komponentama
- Konverzacijsko korisničko iskustvo pokretano Azure OpenAI-jem

Arhitektura i detalji implementacije pružaju vrijedne uvide u izgradnju složenih sustava s više agenata s MCP-om kao slojem koordinacije.

### 2. [Ažuriranje stavki u Azure DevOpsu pomoću podataka s YouTubea](./UpdateADOItemsFromYT.md)

Ova studija slučaja prikazuje praktičnu primjenu MCP-a za automatizaciju radnih procesa. Pokazuje kako se MCP alati mogu koristiti za:

- Izvlačenje podataka s online platformi (YouTube)
- Ažuriranje radnih stavki u Azure DevOps sustavima
- Kreiranje ponovljivih automatiziranih tijekova rada
- Integraciju podataka između različitih sustava

Ovaj primjer ilustrira kako čak i relativno jednostavne MCP implementacije mogu donijeti značajne uštede vremena automatizacijom rutinskih zadataka i poboljšanjem dosljednosti podataka između sustava.

### 3. [Preuzimanje dokumentacije u stvarnom vremenu s MCP-om](./docs-mcp/README.md)

Ova studija slučaja vodi vas kroz povezivanje Python konzolnog klijenta s Model Context Protocol (MCP) serverom za preuzimanje i bilježenje Microsoftove dokumentacije u stvarnom vremenu, prilagođene kontekstu. Naučit ćete kako:

- Povezati se na MCP server koristeći Python klijent i službeni MCP SDK
- Koristiti streaming HTTP klijente za učinkovito preuzimanje podataka u stvarnom vremenu
- Pozivati alate za dokumentaciju na serveru i bilježiti odgovore izravno u konzolu
- Integrirati najnoviju Microsoftovu dokumentaciju u svoj radni tijek bez napuštanja terminala

Poglavlje uključuje praktični zadatak, minimalni radni primjer koda i poveznice na dodatne resurse za dublje učenje. Pogledajte cjeloviti vodič i kod u povezanom poglavlju kako biste razumjeli kako MCP može transformirati pristup dokumentaciji i produktivnost programera u konzolnim okruženjima.

### 4. [Interaktivna web aplikacija za generiranje plana učenja s MCP-om](./docs-mcp/README.md)

Ova studija slučaja pokazuje kako izgraditi interaktivnu web aplikaciju koristeći Chainlit i Model Context Protocol (MCP) za generiranje personaliziranih planova učenja za bilo koju temu. Korisnici mogu odabrati predmet (npr. "AI-900 certifikacija") i trajanje učenja (npr. 8 tjedana), a aplikacija će pružiti tjedni raspored preporučenog sadržaja. Chainlit omogućuje konverzacijsko chat sučelje, čineći iskustvo zanimljivim i prilagodljivim.

- Konverzacijska web aplikacija pokretana Chainlitom
- Korisnički definirani upiti za temu i trajanje
- Preporuke sadržaja tjedan po tjedan koristeći MCP
- Prilagodljivi odgovori u stvarnom vremenu kroz chat sučelje

Projekt ilustrira kako se konverzacijski AI i MCP mogu kombinirati za stvaranje dinamičnih, korisnički vođenih edukativnih alata u modernom web okruženju.

### 5. [Dokumentacija unutar uređivača s MCP serverom u VS Codeu](./docs-mcp/README.md)

Ova studija slučaja pokazuje kako možete dovesti Microsoft Learn Docs izravno u VS Code okruženje koristeći MCP server—nema više prebacivanja između kartica preglednika! Vidjet ćete kako:

- Odmah pretraživati i čitati dokumentaciju unutar VS Codea koristeći MCP panel ili naredbeni paletu
- Referencirati dokumentaciju i umetati poveznice izravno u README ili markdown datoteke tečaja
- Koristiti GitHub Copilot i MCP zajedno za besprijekorne AI-pokretane tijekove rada s dokumentacijom i kodom
- Validirati i poboljšavati dokumentaciju uz povratne informacije u stvarnom vremenu i točnost iz Microsoft izvora
- Integrirati MCP s GitHub tijekovima rada za kontinuiranu validaciju dokumentacije

Implementacija uključuje:
- Primjer konfiguracije `.vscode/mcp.json` za jednostavno postavljanje
- Vodiče s prikazima zaslona iskustva unutar uređivača
- Savjete za kombiniranje Copilota i MCP-a za maksimalnu produktivnost

Ovaj scenarij je idealan za autore tečajeva, pisce dokumentacije i programere koji žele ostati fokusirani u svom uređivaču dok rade s dokumentacijom, Copilotom i alatima za validaciju—sve pokretano MCP-om.

### 6. [Kreiranje APIM MCP servera](./apimsample.md)

Ova studija slučaja pruža korak-po-korak vodič kako kreirati MCP server koristeći Azure API Management (APIM). Obuhvaća:

- Postavljanje MCP servera u Azure API Managementu
- Izlaganje API operacija kao MCP alata
- Konfiguriranje pravila za ograničenje brzine i sigurnost
- Testiranje MCP servera koristeći Visual Studio Code i GitHub Copilot

Ovaj primjer pokazuje kako iskoristiti mogućnosti Azurea za izgradnju robusnog MCP servera koji se može koristiti u različitim aplikacijama, poboljšavajući integraciju AI sustava s poslovnim API-jima.

## Zaključak

Ove studije slučaja ističu svestranost i praktične primjene Model Context Protocola u stvarnim situacijama. Od složenih sustava s više agenata do ciljane automatizacije tijekova rada, MCP pruža standardizirani način povezivanja AI sustava s alatima i podacima potrebnima za isporuku vrijednosti.

Proučavanjem ovih implementacija možete steći uvide u arhitektonske obrasce, strategije implementacije i najbolje prakse koje možete primijeniti u vlastitim MCP projektima. Primjeri pokazuju da MCP nije samo teorijski okvir, već praktično rješenje za stvarne poslovne izazove.

## Dodatni resursi

- [Azure AI Travel Agents GitHub repozitorij](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP alat](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP alat](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP server](https://github.com/MicrosoftDocs/mcp)
- [MCP primjeri iz zajednice](https://github.com/microsoft/mcp)

Sljedeće: Hands on Lab [Streamlining AI Workflows: Building an MCP Server with AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.