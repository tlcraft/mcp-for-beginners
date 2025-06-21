<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T14:10:14+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sl"
}
-->
# MCP v praksi: primeri iz resničnega sveta

Model Context Protocol (MCP) spreminja način, kako AI aplikacije komunicirajo s podatki, orodji in storitvami. Ta razdelek predstavlja primere iz resničnega sveta, ki prikazujejo praktične uporabe MCP v različnih poslovnih okoljih.

## Pregled

V tem razdelku so predstavljeni konkretni primeri implementacij MCP, ki poudarjajo, kako organizacije uporabljajo ta protokol za reševanje zahtevnih poslovnih izzivov. S preučevanjem teh primerov boste pridobili vpogled v vsestranskost, razširljivost in praktične koristi MCP v realnih situacijah.

## Ključni cilji učenja

Z raziskovanjem teh primerov boste:

- razumeli, kako lahko MCP uporabite za reševanje specifičnih poslovnih problemov
- spoznali različne vzorce integracije in arhitekturne pristope
- prepoznali najboljše prakse za implementacijo MCP v podjetniških okoljih
- pridobili vpogled v izzive in rešitve, s katerimi so se srečali pri dejanskih implementacijah
- odkrili priložnosti za uporabo podobnih vzorcev v svojih projektih

## Izpostavljeni primeri

### 1. [Azure AI Travel Agents – referenčna implementacija](./travelagentsample.md)

Ta primer raziskuje celovito referenčno rešitev podjetja Microsoft, ki prikazuje, kako z uporabo MCP, Azure OpenAI in Azure AI Search zgraditi večagentno aplikacijo za načrtovanje potovanj, ki jo poganja AI. Projekt prikazuje:

- večagentno orkestracijo preko MCP
- integracijo podatkov podjetja z Azure AI Search
- varno in razširljivo arhitekturo z uporabo Azure storitev
- razširljive pripomočke z znova uporabnimi MCP komponentami
- pogovorno uporabniško izkušnjo, ki jo omogoča Azure OpenAI

Arhitektura in podrobnosti implementacije nudijo dragocene vpoglede v gradnjo zapletenih večagentnih sistemov z MCP kot koordinacijskim slojem.

### 2. [Posodabljanje Azure DevOps elementov z YouTube podatki](./UpdateADOItemsFromYT.md)

Ta primer prikazuje praktično uporabo MCP za avtomatizacijo delovnih procesov. Pokaže, kako lahko MCP orodja uporabimo za:

- pridobivanje podatkov z spletnih platform (YouTube)
- posodabljanje delovnih elementov v sistemih Azure DevOps
- ustvarjanje ponovljivih avtomatiziranih delovnih tokov
- integracijo podatkov med različnimi sistemi

Ta primer ponazarja, kako lahko že razmeroma preproste implementacije MCP prinesejo znatne izboljšave učinkovitosti z avtomatizacijo rutinskih nalog in izboljšanjem skladnosti podatkov med sistemi.

### 3. [Pridobivanje dokumentacije v realnem času z MCP](./docs-mcp/README.md)

Ta primer vas vodi skozi povezavo Python konzolnega odjemalca z Model Context Protocol (MCP) strežnikom za pridobivanje in beleženje kontekstno prilagojene Microsoftove dokumentacije v realnem času. Naučili se boste, kako:

- vzpostaviti povezavo z MCP strežnikom z uporabo Python odjemalca in uradnega MCP SDK
- uporabljati streaming HTTP odjemalce za učinkovito pridobivanje podatkov v realnem času
- klicati orodja za dokumentacijo na strežniku in neposredno beležiti odzive v konzolo
- vključiti posodobljeno Microsoftovo dokumentacijo v svoj delovni proces, ne da bi zapustili terminal

Poglavje vključuje praktično nalogo, minimalen delujoč primer kode in povezave do dodatnih virov za poglobljeno učenje. Celoten potek in kodo si oglejte v povezanem poglavju, da boste razumeli, kako MCP lahko spremeni dostop do dokumentacije in produktivnost razvijalcev v konzolnih okoljih.

### 4. [Interaktivna spletna aplikacija za generiranje študijskih načrtov z MCP](./docs-mcp/README.md)

Ta primer prikazuje, kako z uporabo Chainlit in Model Context Protocol (MCP) ustvariti interaktivno spletno aplikacijo za generiranje personaliziranih študijskih načrtov za katerokoli temo. Uporabniki lahko določijo predmet (npr. "certifikat AI-900") in trajanje študija (npr. 8 tednov), aplikacija pa ponudi tedenski pregled priporočene vsebine. Chainlit omogoča pogovorni klepet, zaradi česar je izkušnja zanimiva in prilagodljiva.

- pogovorna spletna aplikacija, ki jo poganja Chainlit
- uporabniški pozivi za izbiro teme in trajanja
- tedenske priporočene vsebine z uporabo MCP
- odzivi v realnem času v klepetalnem vmesniku

Projekt prikazuje, kako lahko pogovorni AI in MCP združimo za ustvarjanje dinamičnih, uporabniško usmerjenih izobraževalnih orodij v sodobnem spletnem okolju.

### 5. [Dokumentacija znotraj urejevalnika z MCP strežnikom v VS Code](./docs-mcp/README.md)

Ta primer prikazuje, kako lahko Microsoft Learn Docs pripeljete neposredno v svoje okolje VS Code z uporabo MCP strežnika – brez preklapljanja med zavihki brskalnika! Spoznali boste, kako:

- takoj iskati in brati dokumentacijo znotraj VS Code z uporabo MCP panela ali ukazne palete
- navajati dokumentacijo in vstavljati povezave neposredno v README ali markdown datoteke tečaja
- uporabljati GitHub Copilot in MCP skupaj za nemoteno, AI-podprto delo z dokumentacijo in kodo
- preverjati in izboljševati dokumentacijo z realnočasovnim povratnim informacijam in natančnostjo, ki jo zagotavlja Microsoft
- integrirati MCP z GitHub delovnimi tokovi za neprekinjeno preverjanje dokumentacije

Implementacija vključuje:
- primer `.vscode/mcp.json` konfiguracije za enostavno nastavitev
- vodnike s posnetki zaslona izkušnje znotraj urejevalnika
- nasvete za združevanje Copilota in MCP za največjo produktivnost

Ta scenarij je idealen za avtorje tečajev, pisce dokumentacije in razvijalce, ki želijo ostati osredotočeni v urejevalniku med delom z dokumentacijo, Copilotom in orodji za preverjanje – vse podprto z MCP.

## Zaključek

Ti primeri izpostavljajo vsestranskost in praktične uporabe Model Context Protocol v resničnih situacijah. Od zapletenih večagentnih sistemov do ciljno usmerjenih avtomatiziranih delovnih tokov MCP zagotavlja standardiziran način povezovanja AI sistemov z orodji in podatki, ki jih potrebujejo za ustvarjanje vrednosti.

S preučevanjem teh implementacij lahko pridobite vpogled v arhitekturne vzorce, strategije implementacije in najboljše prakse, ki jih lahko uporabite v svojih MCP projektih. Primeri dokazujejo, da MCP ni le teoretični okvir, ampak praktična rešitev za resnične poslovne izzive.

## Dodatni viri

- [Azure AI Travel Agents GitHub repozitorij](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP orodje](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP orodje](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP strežnik](https://github.com/MicrosoftDocs/mcp)
- [MCP skupnostni primeri](https://github.com/microsoft/mcp)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.