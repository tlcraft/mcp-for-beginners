<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-14T05:52:08+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sl"
}
-->
# MCP v praksi: primeri iz resničnega sveta

Model Context Protocol (MCP) spreminja način, kako AI aplikacije komunicirajo s podatki, orodji in storitvami. Ta razdelek predstavlja primere iz resničnega sveta, ki prikazujejo praktične uporabe MCP v različnih poslovnih okoljih.

## Pregled

V tem razdelku so predstavljeni konkretni primeri implementacij MCP, ki poudarjajo, kako organizacije uporabljajo ta protokol za reševanje zahtevnih poslovnih izzivov. S preučevanjem teh primerov boste pridobili vpogled v vsestranskost, razširljivost in praktične koristi MCP v resničnih situacijah.

## Ključni cilji učenja

Z raziskovanjem teh primerov boste:

- razumeli, kako lahko MCP uporabimo za reševanje specifičnih poslovnih problemov
- spoznali različne vzorce integracije in arhitekturne pristope
- prepoznali najboljše prakse za implementacijo MCP v poslovnih okoljih
- pridobili vpogled v izzive in rešitve, s katerimi se srečujejo pri dejanskih implementacijah
- odkrili priložnosti za uporabo podobnih vzorcev v lastnih projektih

## Izpostavljeni primeri

### 1. [Azure AI Travel Agents – referenčna implementacija](./travelagentsample.md)

Ta primer preučuje Microsoftovo celovito referenčno rešitev, ki prikazuje, kako z MCP, Azure OpenAI in Azure AI Search zgraditi večagentno AI aplikacijo za načrtovanje potovanj. Projekt prikazuje:

- večagentno orkestracijo prek MCP
- integracijo poslovnih podatkov z Azure AI Search
- varno in razširljivo arhitekturo z uporabo Azure storitev
- razširljive pripomočke z večkrat uporabnimi MCP komponentami
- pogovorno uporabniško izkušnjo, ki jo poganja Azure OpenAI

Arhitektura in podrobnosti implementacije nudijo dragocene vpoglede v gradnjo kompleksnih večagentnih sistemov z MCP kot koordinacijsko plastjo.

### 2. [Posodabljanje Azure DevOps elementov iz YouTube podatkov](./UpdateADOItemsFromYT.md)

Ta primer prikazuje praktično uporabo MCP za avtomatizacijo delovnih procesov. Pokaže, kako lahko orodja MCP uporabimo za:

- pridobivanje podatkov z spletnih platform (YouTube)
- posodabljanje delovnih elementov v sistemih Azure DevOps
- ustvarjanje ponovljivih avtomatiziranih delovnih tokov
- integracijo podatkov med različnimi sistemi

Primer kaže, kako lahko že razmeroma preproste implementacije MCP prinesejo znatne izboljšave učinkovitosti z avtomatizacijo rutinskih opravil in izboljšanjem skladnosti podatkov med sistemi.

### 3. [Pridobivanje dokumentacije v realnem času z MCP](./docs-mcp/README.md)

Ta primer vas vodi skozi povezavo Python konzolnega odjemalca s strežnikom Model Context Protocol (MCP) za pridobivanje in beleženje kontekstno zavedne Microsoftove dokumentacije v realnem času. Naučili se boste, kako:

- se povezati s MCP strežnikom z uporabo Python odjemalca in uradnega MCP SDK
- uporabljati streaming HTTP odjemalce za učinkovito pridobivanje podatkov v realnem času
- klicati orodja za dokumentacijo na strežniku in odgovore beležiti neposredno v konzolo
- integrirati ažurno Microsoftovo dokumentacijo v svoj delovni proces brez zapuščanja terminala

Poglavje vključuje praktično nalogo, minimalen delujoč primer kode in povezave do dodatnih virov za poglobljeno učenje. Celoten vodič in kodo si oglejte v povezanem poglavju, da razumete, kako MCP lahko spremeni dostop do dokumentacije in produktivnost razvijalcev v konzolnih okoljih.

### 4. [Interaktivna spletna aplikacija za generiranje študijskih načrtov z MCP](./docs-mcp/README.md)

Ta primer prikazuje, kako z uporabo Chainlit in Model Context Protocol (MCP) zgraditi interaktivno spletno aplikacijo za ustvarjanje personaliziranih študijskih načrtov za katerokoli temo. Uporabniki lahko določijo predmet (npr. "certifikat AI-900") in trajanje študija (npr. 8 tednov), aplikacija pa ponudi tedenski pregled priporočene vsebine. Chainlit omogoča pogovorni klepet, ki naredi izkušnjo privlačno in prilagodljivo.

- pogovorna spletna aplikacija, ki jo poganja Chainlit
- uporabniški vnosi za temo in trajanje
- tedenske priporočene vsebine z uporabo MCP
- odzivi v realnem času v klepetalnem vmesniku

Projekt prikazuje, kako lahko združimo pogovorno AI in MCP za ustvarjanje dinamičnih, uporabniško usmerjenih izobraževalnih orodij v sodobnem spletnem okolju.

### 5. [Dokumentacija v urejevalniku z MCP strežnikom v VS Code](./docs-mcp/README.md)

Ta primer prikazuje, kako lahko Microsoft Learn Docs pripeljete neposredno v okolje VS Code z uporabo MCP strežnika – brez preklapljanja med zavihki brskalnika! Spoznali boste, kako:

- takoj iskati in brati dokumentacijo znotraj VS Code prek MCP panela ali ukazne palete
- v dokumentacijo vstaviti reference in povezave neposredno v README ali markdown datoteke tečajev
- uporabljati GitHub Copilot in MCP skupaj za nemotene, AI-podprte delovne tokove dokumentacije in kode
- preverjati in izboljševati dokumentacijo z realnočasovnim povratnim informacijam in natančnostjo iz Microsofta
- integrirati MCP z GitHub delovnimi tokovi za stalno preverjanje dokumentacije

Implementacija vključuje:
- primer konfiguracije `.vscode/mcp.json` za enostavno nastavitev
- vodiče s posnetki zaslona izkušnje znotraj urejevalnika
- nasvete za združevanje Copilota in MCP za največjo produktivnost

Ta scenarij je idealen za avtorje tečajev, pisce dokumentacije in razvijalce, ki želijo ostati osredotočeni v urejevalniku med delom z dokumentacijo, Copilotom in orodji za preverjanje – vse to z močjo MCP.

### 6. [Ustvarjanje MCP strežnika z APIM](./apimsample.md)

Ta primer ponuja korak za korakom vodič, kako ustvariti MCP strežnik z uporabo Azure API Management (APIM). Vključuje:

- nastavitev MCP strežnika v Azure API Management
- izpostavljanje API operacij kot MCP orodij
- konfiguracijo pravil za omejevanje hitrosti in varnost
- testiranje MCP strežnika z Visual Studio Code in GitHub Copilot

Primer prikazuje, kako izkoristiti zmogljivosti Azure za ustvarjanje robustnega MCP strežnika, ki ga je mogoče uporabiti v različnih aplikacijah za izboljšanje integracije AI sistemov s poslovnimi API-ji.

## Zaključek

Ti primeri poudarjajo vsestranskost in praktične uporabe Model Context Protocol v resničnih situacijah. Od kompleksnih večagentnih sistemov do ciljno usmerjenih avtomatiziranih delovnih tokov MCP zagotavlja standardiziran način povezovanja AI sistemov z orodji in podatki, ki jih potrebujejo za ustvarjanje vrednosti.

S preučevanjem teh implementacij lahko pridobite vpogled v arhitekturne vzorce, strategije implementacije in najboljše prakse, ki jih lahko uporabite v svojih MCP projektih. Primeri dokazujejo, da MCP ni le teoretični okvir, temveč praktična rešitev za resnične poslovne izzive.

## Dodatni viri

- [Azure AI Travel Agents GitHub repozitorij](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP orodje](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP orodje](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP strežnik](https://github.com/MicrosoftDocs/mcp)
- [MCP skupnostni primeri](https://github.com/microsoft/mcp)

Naslednje: Hands on Lab [Poenostavitev AI delovnih tokov: gradnja MCP strežnika z AI orodji](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.