<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-14T05:51:52+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hr"
}
-->
# MCP u praksi: Studije slučaja iz stvarnog svijeta

Model Context Protocol (MCP) mijenja način na koji AI aplikacije komuniciraju s podacima, alatima i uslugama. Ovaj odjeljak prikazuje studije slučaja iz stvarnog svijeta koje demonstriraju praktične primjene MCP-a u različitim poslovnim scenarijima.

## Pregled

Ovaj odjeljak prikazuje konkretne primjere implementacija MCP-a, ističući kako organizacije koriste ovaj protokol za rješavanje složenih poslovnih izazova. Analizom ovih studija slučaja dobit ćete uvid u svestranost, skalabilnost i praktične prednosti MCP-a u stvarnim situacijama.

## Ključni ciljevi učenja

Kroz ove studije slučaja, naučit ćete:

- Kako MCP može biti primijenjen za rješavanje specifičnih poslovnih problema
- Različite obrasce integracije i arhitektonske pristupe
- Najbolje prakse za implementaciju MCP-a u poslovnim okruženjima
- Izazove i rješenja koja se javljaju u stvarnim implementacijama
- Prilike za primjenu sličnih obrazaca u vlastitim projektima

## Istaknute studije slučaja

### 1. [Azure AI Travel Agents – Referentna implementacija](./travelagentsample.md)

Ova studija slučaja analizira Microsoftovo sveobuhvatno referentno rješenje koje pokazuje kako izgraditi aplikaciju za planiranje putovanja s više agenata, pokretanu AI-jem, koristeći MCP, Azure OpenAI i Azure AI Search. Projekt uključuje:

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

### 3. [Preuzimanje dokumentacije u stvarnom vremenu s MCP-om](./docs-mcp/README.md)

Ova studija slučaja vodi vas kroz povezivanje Python konzolnog klijenta s Model Context Protocol (MCP) serverom za dohvat i zapisivanje Microsoftove dokumentacije u stvarnom vremenu, prilagođene kontekstu. Naučit ćete kako:

- Povezati se s MCP serverom koristeći Python klijent i službeni MCP SDK
- Koristiti streaming HTTP klijente za učinkovito dohvaćanje podataka u stvarnom vremenu
- Pozivati alate za dokumentaciju na serveru i zapisivati odgovore izravno u konzolu
- Integrirati najnoviju Microsoftovu dokumentaciju u svoj radni tijek bez napuštanja terminala

Poglavlje uključuje praktični zadatak, minimalni radni uzorak koda i poveznice na dodatne resurse za dublje učenje. Pogledajte cijeli vodič i kod u povezanom poglavlju kako biste razumjeli kako MCP može transformirati pristup dokumentaciji i produktivnost programera u konzolnim okruženjima.

### 4. [Interaktivna web aplikacija za generiranje plana učenja pomoću MCP-a](./docs-mcp/README.md)

Ova studija slučaja prikazuje kako izgraditi interaktivnu web aplikaciju koristeći Chainlit i Model Context Protocol (MCP) za generiranje personaliziranih planova učenja za bilo koju temu. Korisnici mogu odabrati predmet (npr. "AI-900 certifikacija") i trajanje učenja (npr. 8 tjedana), a aplikacija će pružiti tjedni raspored preporučenog sadržaja. Chainlit omogućuje konverzacijsko chat sučelje, čineći iskustvo zanimljivim i prilagodljivim.

- Konverzacijska web aplikacija pokretana Chainlitom
- Korisnički definirani upiti za temu i trajanje
- Preporuke sadržaja tjedan po tjedan koristeći MCP
- Odgovori u stvarnom vremenu u chat sučelju

Projekt ilustrira kako se konverzacijski AI i MCP mogu kombinirati za stvaranje dinamičnih, korisnički vođenih edukativnih alata u modernom web okruženju.

### 5. [Dokumentacija u editoru pomoću MCP servera u VS Code](./docs-mcp/README.md)

Ova studija slučaja pokazuje kako možete dovesti Microsoft Learn Docs izravno u VS Code okruženje koristeći MCP server—nema više prebacivanja između kartica preglednika! Vidjet ćete kako:

- Odmah pretraživati i čitati dokumentaciju unutar VS Codea koristeći MCP panel ili naredbeni paletu
- Referencirati dokumentaciju i umetati poveznice izravno u README ili markdown datoteke tečaja
- Koristiti GitHub Copilot i MCP zajedno za besprijekorne AI-pokretane tijekove rada s dokumentacijom i kodom
- Validirati i poboljšavati dokumentaciju uz povratne informacije u stvarnom vremenu i točnost iz Microsoft izvora
- Integrirati MCP s GitHub tijekovima rada za kontinuiranu validaciju dokumentacije

Implementacija uključuje:

- Primjer `.vscode/mcp.json` konfiguracije za jednostavno postavljanje
- Vodiče sa snimkama zaslona za iskustvo u editoru
- Savjete za kombiniranje Copilota i MCP-a za maksimalnu produktivnost

Ovaj scenarij je idealan za autore tečajeva, pisce dokumentacije i programere koji žele ostati fokusirani u editoru dok rade s dokumentacijom, Copilotom i alatima za validaciju—sve pokretano MCP-om.

### 6. [Kreiranje MCP servera pomoću APIM-a](./apimsample.md)

Ova studija slučaja pruža korak-po-korak vodič kako kreirati MCP server koristeći Azure API Management (APIM). Obuhvaća:

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
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.