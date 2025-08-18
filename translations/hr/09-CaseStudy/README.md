<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-08-18T17:15:32+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hr"
}
-->
# MCP u praksi: Studije slučaja iz stvarnog svijeta

[![MCP u praksi: Studije slučaja iz stvarnog svijeta](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.hr.png)](https://youtu.be/IxshWb2Az5w)

_(Kliknite na sliku iznad za pregled videa ove lekcije)_

Model Context Protocol (MCP) mijenja način na koji AI aplikacije komuniciraju s podacima, alatima i uslugama. Ovaj odjeljak predstavlja studije slučaja iz stvarnog svijeta koje prikazuju praktične primjene MCP-a u raznim poslovnim scenarijima.

## Pregled

Ovaj odjeljak prikazuje konkretne primjere implementacije MCP-a, ističući kako organizacije koriste ovaj protokol za rješavanje složenih poslovnih izazova. Analizom ovih studija slučaja steći ćete uvid u svestranost, skalabilnost i praktične prednosti MCP-a u stvarnim situacijama.

## Ključni ciljevi učenja

Kroz ove studije slučaja, naučit ćete:

- Kako MCP može biti primijenjen za rješavanje specifičnih poslovnih problema
- Različite obrasce integracije i arhitektonske pristupe
- Najbolje prakse za implementaciju MCP-a u poslovnim okruženjima
- Izazove i rješenja koja se javljaju u stvarnim implementacijama
- Prilike za primjenu sličnih obrazaca u vlastitim projektima

## Istaknute studije slučaja

### 1. [Azure AI Travel Agents – Referentna implementacija](./travelagentsample.md)

Ova studija slučaja analizira Microsoftovo sveobuhvatno referentno rješenje koje pokazuje kako izgraditi aplikaciju za planiranje putovanja s više agenata, pokretanu AI-jem, koristeći MCP, Azure OpenAI i Azure AI Search. Projekt prikazuje:

- Orkestraciju više agenata putem MCP-a
- Integraciju poslovnih podataka s Azure AI Search
- Sigurnu, skalabilnu arhitekturu koristeći Azure usluge
- Proširive alate s ponovljivim MCP komponentama
- Konverzacijsku korisničku interakciju pokretanu Azure OpenAI-jem

Arhitektura i detalji implementacije pružaju vrijedne uvide u izgradnju složenih sustava s više agenata, gdje MCP služi kao sloj koordinacije.

### 2. [Ažuriranje stavki Azure DevOps-a pomoću podataka s YouTubea](./UpdateADOItemsFromYT.md)

Ova studija slučaja prikazuje praktičnu primjenu MCP-a za automatizaciju radnih procesa. Pokazuje kako se MCP alati mogu koristiti za:

- Ekstrakciju podataka s online platformi (YouTube)
- Ažuriranje stavki u sustavima Azure DevOps
- Stvaranje ponovljivih automatiziranih radnih tijekova
- Integraciju podataka između različitih sustava

Ovaj primjer ilustrira kako čak i relativno jednostavne implementacije MCP-a mogu donijeti značajne uštede vremena automatizacijom rutinskih zadataka i poboljšanjem dosljednosti podataka između sustava.

### 3. [Pristup dokumentaciji u stvarnom vremenu pomoću MCP-a](./docs-mcp/README.md)

Ova studija slučaja vodi vas kroz povezivanje Python konzolnog klijenta s MCP serverom za dohvaćanje i bilježenje kontekstualno svjesne Microsoftove dokumentacije u stvarnom vremenu. Naučit ćete kako:

- Povezati se s MCP serverom koristeći Python klijent i službeni MCP SDK
- Koristiti streaming HTTP klijente za učinkovito dohvaćanje podataka u stvarnom vremenu
- Pozivati alate za dokumentaciju na serveru i bilježiti odgovore izravno u konzolu
- Integrirati ažuriranu Microsoftovu dokumentaciju u svoj radni tijek bez napuštanja terminala

Poglavlje uključuje praktični zadatak, minimalni radni uzorak koda i poveznice na dodatne resurse za dublje učenje. Pogledajte cijeli vodič i kod u povezanom poglavlju kako biste razumjeli kako MCP može transformirati pristup dokumentaciji i produktivnost programera u konzolnim okruženjima.

### 4. [Interaktivna web aplikacija za generiranje plana učenja pomoću MCP-a](./docs-mcp/README.md)

Ova studija slučaja pokazuje kako izgraditi interaktivnu web aplikaciju koristeći Chainlit i Model Context Protocol (MCP) za generiranje personaliziranih planova učenja za bilo koju temu. Korisnici mogu odabrati predmet (npr. "AI-900 certifikacija") i trajanje učenja (npr. 8 tjedana), a aplikacija će pružiti tjedni raspored preporučenog sadržaja. Chainlit omogućuje konverzacijsku chat sučelje, čineći iskustvo zanimljivim i prilagodljivim.

- Konverzacijska web aplikacija pokretana Chainlitom
- Korisnički unos za temu i trajanje
- Tjedne preporuke sadržaja koristeći MCP
- Odgovori u stvarnom vremenu prilagođeni korisniku u chat sučelju

Projekt ilustrira kako se konverzacijski AI i MCP mogu kombinirati za stvaranje dinamičnih, korisnički vođenih edukacijskih alata u modernom web okruženju.

### 5. [Dokumentacija u editoru pomoću MCP servera u VS Code](./docs-mcp/README.md)

Ova studija slučaja pokazuje kako možete donijeti Microsoft Learn dokumentaciju izravno u svoje VS Code okruženje koristeći MCP server—bez potrebe za prebacivanjem između kartica preglednika! Vidjet ćete kako:

- Trenutno pretraživati i čitati dokumentaciju unutar VS Code-a koristeći MCP panel ili naredbeni izbornik
- Referencirati dokumentaciju i umetati poveznice izravno u README ili markdown datoteke
- Koristiti GitHub Copilot i MCP zajedno za besprijekorne, AI-pokretane tijekove dokumentacije i koda
- Validirati i poboljšati dokumentaciju uz povratne informacije u stvarnom vremenu i Microsoftovu točnost
- Integrirati MCP s GitHub tijekovima rada za kontinuiranu validaciju dokumentacije

Implementacija uključuje:

- Primjer `.vscode/mcp.json` konfiguracije za jednostavno postavljanje
- Vodiče sa snimkama zaslona za iskustvo u editoru
- Savjete za kombiniranje Copilota i MCP-a za maksimalnu produktivnost

Ovaj scenarij je idealan za autore tečajeva, pisce dokumentacije i programere koji žele ostati fokusirani u editoru dok rade s dokumentacijom, Copilotom i alatima za validaciju—sve pokretano MCP-om.

### 6. [Kreiranje MCP servera pomoću APIM-a](./apimsample.md)

Ova studija slučaja pruža korak-po-korak vodič o tome kako kreirati MCP server koristeći Azure API Management (APIM). Pokriva:

- Postavljanje MCP servera u Azure API Management
- Izlaganje API operacija kao MCP alata
- Konfiguriranje politika za ograničavanje brzine i sigurnost
- Testiranje MCP servera koristeći Visual Studio Code i GitHub Copilot

Ovaj primjer ilustrira kako iskoristiti Azureove mogućnosti za kreiranje robusnog MCP servera koji se može koristiti u raznim aplikacijama, poboljšavajući integraciju AI sustava s poslovnim API-ima.

## Zaključak

Ove studije slučaja ističu svestranost i praktične primjene Model Context Protocol-a u stvarnim scenarijima. Od složenih sustava s više agenata do ciljanih automatiziranih tijekova rada, MCP pruža standardizirani način povezivanja AI sustava s alatima i podacima potrebnim za stvaranje vrijednosti.

Analizom ovih implementacija možete steći uvide u arhitektonske obrasce, strategije implementacije i najbolje prakse koje možete primijeniti u vlastitim MCP projektima. Primjeri pokazuju da MCP nije samo teorijski okvir, već praktično rješenje za stvarne poslovne izazove.

## Dodatni resursi

- [Azure AI Travel Agents GitHub repozitorij](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP alat](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP alat](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP server](https://github.com/MicrosoftDocs/mcp)
- [Primjeri MCP zajednice](https://github.com/microsoft/mcp)

Sljedeće: Praktična radionica [Optimizacija AI tijekova rada: Izgradnja MCP servera s AI alatima](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne preuzimamo odgovornost za bilo kakva pogrešna tumačenja ili nesporazume koji proizlaze iz korištenja ovog prijevoda.