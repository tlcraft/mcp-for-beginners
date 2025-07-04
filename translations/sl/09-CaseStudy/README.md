<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-04T19:10:59+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sl"
}
-->
# MCP v praksi: primeri iz resničnega sveta

Model Context Protocol (MCP) spreminja način, kako AI aplikacije komunicirajo s podatki, orodji in storitvami. Ta razdelek predstavlja primere iz resničnega sveta, ki prikazujejo praktične uporabe MCP v različnih poslovnih okoljih.

## Pregled

V tem razdelku so predstavljeni konkretni primeri implementacij MCP, ki poudarjajo, kako organizacije izkoriščajo ta protokol za reševanje zahtevnih poslovnih izzivov. S preučevanjem teh primerov boste pridobili vpogled v vsestranskost, razširljivost in praktične koristi MCP v resničnih situacijah.

## Ključni cilji učenja

Z raziskovanjem teh primerov boste:

- Razumeli, kako lahko MCP uporabimo za reševanje specifičnih poslovnih problemov
- Spoznali različne vzorce integracije in arhitekturne pristope
- Prepoznali najboljše prakse za implementacijo MCP v poslovnih okoljih
- Pridobili vpogled v izzive in rešitve, s katerimi se srečujejo pri dejanskih implementacijah
- Prepoznali priložnosti za uporabo podobnih vzorcev v lastnih projektih

## Izpostavljeni primeri

### 1. [Azure AI Travel Agents – referenčna implementacija](./travelagentsample.md)

Ta primer preučuje Microsoftovo celovito referenčno rešitev, ki prikazuje, kako z MCP, Azure OpenAI in Azure AI Search zgraditi večagentno AI aplikacijo za načrtovanje potovanj. Projekt prikazuje:

- Večagentno orkestracijo prek MCP
- Integracijo poslovnih podatkov z Azure AI Search
- Varnostno in razširljivo arhitekturo z uporabo Azure storitev
- Razširljiva orodja z večkrat uporabnimi MCP komponentami
- Pogovorno uporabniško izkušnjo, ki jo poganja Azure OpenAI

Arhitektura in podrobnosti implementacije nudijo dragocene vpoglede v gradnjo kompleksnih večagentnih sistemov z MCP kot koordinacijsko plastjo.

### 2. [Posodabljanje Azure DevOps elementov iz podatkov YouTube](./UpdateADOItemsFromYT.md)

Ta primer prikazuje praktično uporabo MCP za avtomatizacijo delovnih procesov. Prikazuje, kako lahko MCP orodja uporabimo za:

- Izvlečenje podatkov z spletnih platform (YouTube)
- Posodabljanje delovnih elementov v sistemih Azure DevOps
- Ustvarjanje ponovljivih avtomatiziranih delovnih tokov
- Integracijo podatkov med različnimi sistemi

Ta primer kaže, kako lahko že razmeroma preproste implementacije MCP prinesejo znatne izboljšave učinkovitosti z avtomatizacijo rutinskih opravil in izboljšanjem skladnosti podatkov med sistemi.

### 3. [Pridobivanje dokumentacije v realnem času z MCP](./docs-mcp/README.md)

Ta primer vas vodi skozi povezavo Python konzolnega odjemalca s strežnikom Model Context Protocol (MCP) za pridobivanje in beleženje kontekstno zavedne Microsoftove dokumentacije v realnem času. Naučili se boste, kako:

- Povezati se s MCP strežnikom z uporabo Python odjemalca in uradnega MCP SDK
- Uporabiti streaming HTTP odjemalce za učinkovito pridobivanje podatkov v realnem času
- Klicati dokumentacijska orodja na strežniku in neposredno beležiti odzive v konzolo
- Integrirati ažurno Microsoftovo dokumentacijo v svoj delovni proces brez zapuščanja terminala

Poglavje vključuje praktično nalogo, minimalen delujoč primer kode in povezave do dodatnih virov za poglobljeno učenje. Oglejte si celoten vodič in kodo v povezanem poglavju, da razumete, kako MCP lahko spremeni dostop do dokumentacije in produktivnost razvijalcev v konzolnih okoljih.

### 4. [Interaktivna spletna aplikacija za generiranje študijskih načrtov z MCP](./docs-mcp/README.md)

Ta primer prikazuje, kako z uporabo Chainlit in Model Context Protocol (MCP) zgraditi interaktivno spletno aplikacijo za ustvarjanje personaliziranih študijskih načrtov za katerokoli temo. Uporabniki lahko določijo predmet (npr. "certifikat AI-900") in trajanje študija (npr. 8 tednov), aplikacija pa ponudi tedenski pregled priporočene vsebine. Chainlit omogoča pogovorni klepet, ki naredi izkušnjo privlačno in prilagodljivo.

- Pogovorna spletna aplikacija, ki jo poganja Chainlit
- Uporabniški pozivi za izbiro teme in trajanja
- Tedenske priporočene vsebine z uporabo MCP
- Prilagodljivi odgovori v realnem času v klepetalnem vmesniku

Projekt prikazuje, kako lahko pogovorna AI in MCP združimo za ustvarjanje dinamičnih, uporabniško usmerjenih izobraževalnih orodij v sodobnem spletnem okolju.

### 5. [Dokumentacija v urejevalniku z MCP strežnikom v VS Code](./docs-mcp/README.md)

Ta primer prikazuje, kako lahko Microsoft Learn Docs pripeljete neposredno v okolje VS Code z uporabo MCP strežnika – brez preklapljanja med zavihki brskalnika! Videli boste, kako:

- Takojšnje iskanje in branje dokumentacije znotraj VS Code prek MCP panela ali ukazne palete
- Vstavljanje referenc in povezav neposredno v README ali markdown datoteke tečajev
- Uporaba GitHub Copilot in MCP skupaj za nemotene, AI-podprte delovne tokove dokumentacije in kode
- Validacija in izboljšava dokumentacije z realnočasovnim povratnim informacijam in natančnostjo iz Microsofta
- Integracija MCP z GitHub delovnimi tokovi za stalno validacijo dokumentacije

Implementacija vključuje:
- Primer konfiguracije `.vscode/mcp.json` za enostavno nastavitev
- Vodiče s posnetki zaslona izkušnje znotraj urejevalnika
- Nasvete za združevanje Copilota in MCP za največjo produktivnost

Ta scenarij je idealen za avtorje tečajev, pisce dokumentacije in razvijalce, ki želijo ostati osredotočeni v urejevalniku med delom z dokumentacijo, Copilotom in orodji za validacijo – vse to z močjo MCP.

### 6. [Ustvarjanje MCP strežnika z APIM](./apimsample.md)

Ta primer ponuja korak za korakom vodič, kako ustvariti MCP strežnik z uporabo Azure API Management (APIM). Pokriva:

- Nastavitev MCP strežnika v Azure API Management
- Izpostavljanje API operacij kot MCP orodij
- Konfiguracijo pravil za omejevanje hitrosti in varnost
- Testiranje MCP strežnika z Visual Studio Code in GitHub Copilot

Ta primer prikazuje, kako izkoristiti zmogljivosti Azure za ustvarjanje robustnega MCP strežnika, ki ga je mogoče uporabiti v različnih aplikacijah za izboljšanje integracije AI sistemov s poslovnimi API-ji.

## Zaključek

Ti primeri poudarjajo vsestranskost in praktične uporabe Model Context Protocol v resničnih situacijah. Od kompleksnih večagentnih sistemov do ciljno usmerjenih avtomatiziranih delovnih tokov, MCP zagotavlja standardiziran način povezovanja AI sistemov z orodji in podatki, ki jih potrebujejo za ustvarjanje vrednosti.

S preučevanjem teh implementacij lahko pridobite vpogled v arhitekturne vzorce, strategije implementacije in najboljše prakse, ki jih lahko uporabite v svojih MCP projektih. Primeri dokazujejo, da MCP ni le teoretični okvir, temveč praktična rešitev za resnične poslovne izzive.

## Dodatni viri

- [Azure AI Travel Agents GitHub repozitorij](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP orodje](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP orodje](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP strežnik](https://github.com/MicrosoftDocs/mcp)
- [MCP skupnostni primeri](https://github.com/microsoft/mcp)

Naslednje: Hands on Lab [Poenostavitev AI delovnih tokov: gradnja MCP strežnika z AI orodji](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.