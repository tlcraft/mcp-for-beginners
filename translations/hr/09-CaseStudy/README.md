<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T14:09:20+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "hr"
}
-->
# MCP u praksi: Studije slučaja iz stvarnog svijeta

Model Context Protocol (MCP) mijenja način na koji AI aplikacije komuniciraju s podacima, alatima i uslugama. Ovaj odjeljak prikazuje stvarne studije slučaja koje pokazuju praktične primjene MCP-a u različitim poslovnim scenarijima.

## Pregled

Ovdje su predstavljeni konkretni primjeri implementacija MCP-a, ističući kako organizacije koriste ovaj protokol za rješavanje složenih poslovnih izazova. Analizom ovih studija slučaja dobit ćete uvid u svestranost, skalabilnost i praktične prednosti MCP-a u stvarnim situacijama.

## Ključni ciljevi učenja

Istraživanjem ovih studija slučaja naučit ćete:

- Kako se MCP može primijeniti za rješavanje specifičnih poslovnih problema
- Različite obrasce integracije i arhitektonske pristupe
- Najbolje prakse za implementaciju MCP-a u poslovnim okruženjima
- Izazove i rješenja na koja se nailazi u stvarnim implementacijama
- Prilike za primjenu sličnih obrazaca u vlastitim projektima

## Istaknute studije slučaja

### 1. [Azure AI Travel Agents – Referentna implementacija](./travelagentsample.md)

Ova studija slučaja analizira Microsoftovo sveobuhvatno referentno rješenje koje pokazuje kako izgraditi aplikaciju za planiranje putovanja s više agenata, pokretanih AI-jem, koristeći MCP, Azure OpenAI i Azure AI Search. Projekt prikazuje:

- Orkestraciju više agenata putem MCP-a
- Integraciju poslovnih podataka s Azure AI Search
- Sigurnu i skalabilnu arhitekturu temeljenu na Azure uslugama
- Proširive alate s ponovo upotrebljivim MCP komponentama
- Konverzacijsko korisničko iskustvo pokretano Azure OpenAI-jem

Arhitektura i detalji implementacije pružaju vrijedne uvide u izgradnju složenih sustava s više agenata s MCP-om kao slojem za koordinaciju.

### 2. [Ažuriranje stavki u Azure DevOps iz YouTube podataka](./UpdateADOItemsFromYT.md)

Ova studija slučaja prikazuje praktičnu primjenu MCP-a za automatizaciju radnih procesa. Pokazuje kako se MCP alati mogu koristiti za:

- Izvlačenje podataka s online platformi (YouTube)
- Ažuriranje radnih stavki u Azure DevOps sustavima
- Kreiranje ponovljivih automatiziranih tijekova rada
- Integraciju podataka između različitih sustava

Ovaj primjer pokazuje kako čak i relativno jednostavne MCP implementacije mogu donijeti značajne uštede vremena automatizacijom rutinskih zadataka i poboljšanjem dosljednosti podataka između sustava.

### 3. [Dohvaćanje dokumentacije u stvarnom vremenu s MCP-om](./docs-mcp/README.md)

Ova studija slučaja vodi vas kroz povezivanje Python konzolnog klijenta s Model Context Protocol (MCP) serverom za dohvaćanje i zapisivanje Microsoftove dokumentacije u stvarnom vremenu, prilagođene kontekstu. Naučit ćete kako:

- Povezati se s MCP serverom koristeći Python klijent i službeni MCP SDK
- Koristiti streaming HTTP klijente za učinkovito dohvaćanje podataka u stvarnom vremenu
- Pozivati alate za dokumentaciju na serveru i zapisivati odgovore izravno u konzolu
- Integrirati najnoviju Microsoftovu dokumentaciju u svoj radni tijek bez napuštanja terminala

Poglavlje uključuje praktični zadatak, minimalni radni primjer koda i poveznice na dodatne resurse za dublje učenje. Pogledajte cjeloviti vodič i kod u povezanom poglavlju kako biste shvatili kako MCP može transformirati pristup dokumentaciji i produktivnost programera u konzolnim okruženjima.

### 4. [Interaktivna web aplikacija za generiranje studijskih planova s MCP-om](./docs-mcp/README.md)

Ova studija slučaja pokazuje kako izgraditi interaktivnu web aplikaciju koristeći Chainlit i Model Context Protocol (MCP) za generiranje personaliziranih studijskih planova za bilo koju temu. Korisnici mogu odabrati predmet (npr. "AI-900 certifikacija") i trajanje učenja (npr. 8 tjedana), a aplikacija će ponuditi tjedni raspored preporučenog sadržaja. Chainlit omogućuje konverzacijsko chat sučelje, čineći iskustvo zanimljivim i prilagodljivim.

- Konverzacijska web aplikacija pokretana Chainlitom
- Korisnički upravljani upiti za temu i trajanje
- Preporuke sadržaja po tjednima koristeći MCP
- Prilagodljivi odgovori u stvarnom vremenu kroz chat sučelje

Projekt ilustrira kako se konverzacijski AI i MCP mogu spojiti za stvaranje dinamičnih, korisnički orijentiranih edukativnih alata u suvremenom web okruženju.

### 5. [Dokumentacija unutar uređivača s MCP serverom u VS Code-u](./docs-mcp/README.md)

Ova studija slučaja pokazuje kako možete dovesti Microsoft Learn Docs izravno u VS Code koristeći MCP server—nema više prebacivanja između kartica preglednika! Vidjet ćete kako:

- Trenutno pretraživati i čitati dokumentaciju unutar VS Code-a koristeći MCP panel ili command palette
- Referencirati dokumentaciju i umetati poveznice izravno u README ili markdown datoteke za tečajeve
- Koristiti GitHub Copilot i MCP zajedno za besprijekorne AI-pokretane radne tokove s dokumentacijom i kodom
- Validirati i unaprijediti svoju dokumentaciju uz povratne informacije u stvarnom vremenu i točnost iz Microsoft izvora
- Integrirati MCP s GitHub radnim tokovima za kontinuiranu validaciju dokumentacije

Implementacija uključuje:
- Primjer `.vscode/mcp.json` konfiguracije za jednostavno postavljanje
- Vodiče s prikazima zaslona za iskustvo unutar uređivača
- Savjete za kombiniranje Copilota i MCP-a za maksimalnu produktivnost

Ovaj scenarij idealan je za autore tečajeva, pisce dokumentacije i programere koji žele ostati fokusirani u uređivaču dok rade s dokumentacijom, Copilotom i alatima za validaciju—sve pokretano MCP-om.

## Zaključak

Ove studije slučaja ističu svestranost i praktične primjene Model Context Protocola u stvarnim situacijama. Od složenih sustava s više agenata do ciljane automatizacije radnih procesa, MCP pruža standardizirani način povezivanja AI sustava s alatima i podacima potrebnima za stvaranje vrijednosti.

Proučavanjem ovih implementacija dobit ćete uvide u arhitektonske obrasce, strategije implementacije i najbolje prakse koje možete primijeniti u vlastitim MCP projektima. Primjeri pokazuju da MCP nije samo teorijski okvir, već praktično rješenje za stvarne poslovne izazove.

## Dodatni resursi

- [Azure AI Travel Agents GitHub repozitorij](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP alat](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP alat](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP server](https://github.com/MicrosoftDocs/mcp)
- [MCP zajednički primjeri](https://github.com/microsoft/mcp)

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je pomoću AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili kriva tumačenja koja proizlaze iz korištenja ovog prijevoda.