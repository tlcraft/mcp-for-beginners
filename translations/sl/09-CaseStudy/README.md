<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-08-18T22:19:19+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sl"
}
-->
# MCP v praksi: Študije primerov iz resničnega sveta

[![MCP v praksi: Študije primerov iz resničnega sveta](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.sl.png)](https://youtu.be/IxshWb2Az5w)

_(Kliknite na zgornjo sliko za ogled videa te lekcije)_

Model Context Protocol (MCP) spreminja način, kako aplikacije umetne inteligence komunicirajo s podatki, orodji in storitvami. Ta razdelek predstavlja študije primerov iz resničnega sveta, ki prikazujejo praktične uporabe MCP v različnih poslovnih scenarijih.

## Pregled

Ta razdelek prikazuje konkretne primere implementacij MCP, ki poudarjajo, kako organizacije uporabljajo ta protokol za reševanje kompleksnih poslovnih izzivov. S preučevanjem teh študij primerov boste pridobili vpogled v vsestranskost, skalabilnost in praktične koristi MCP v resničnih scenarijih.

## Ključni cilji učenja

S preučevanjem teh študij primerov boste:

- Razumeli, kako MCP lahko uporabite za reševanje specifičnih poslovnih težav
- Spoznali različne vzorce integracije in arhitekturne pristope
- Prepoznali najboljše prakse za implementacijo MCP v poslovnih okoljih
- Pridobili vpogled v izzive in rešitve, s katerimi se srečujejo pri implementacijah v resničnem svetu
- Identificirali priložnosti za uporabo podobnih vzorcev v svojih projektih

## Izbrane študije primerov

### 1. [Azure AI Travel Agents – Referenčna implementacija](./travelagentsample.md)

Ta študija primera preučuje Microsoftovo celovito referenčno rešitev, ki prikazuje, kako zgraditi večagentno aplikacijo za načrtovanje potovanj, ki temelji na umetni inteligenci, z uporabo MCP, Azure OpenAI in Azure AI Search. Projekt prikazuje:

- Orkestracijo več agentov prek MCP
- Integracijo poslovnih podatkov z Azure AI Search
- Varnostno in skalabilno arhitekturo z uporabo storitev Azure
- Razširljiva orodja z večkratno uporabo MCP komponent
- Pogovorno uporabniško izkušnjo, ki jo omogoča Azure OpenAI

Arhitekturne in implementacijske podrobnosti ponujajo dragocen vpogled v gradnjo kompleksnih večagentnih sistemov z MCP kot koordinacijsko plastjo.

### 2. [Posodabljanje elementov Azure DevOps z YouTube podatki](./UpdateADOItemsFromYT.md)

Ta študija primera prikazuje praktično uporabo MCP za avtomatizacijo delovnih procesov. Prikazuje, kako lahko MCP orodja uporabite za:

- Ekstrakcijo podatkov z spletnih platform (YouTube)
- Posodabljanje delovnih elementov v sistemih Azure DevOps
- Ustvarjanje ponovljivih avtomatiziranih delovnih tokov
- Integracijo podatkov med različnimi sistemi

Ta primer ponazarja, kako lahko že relativno preproste implementacije MCP prinesejo pomembne izboljšave učinkovitosti z avtomatizacijo rutinskih nalog in izboljšanjem doslednosti podatkov med sistemi.

### 3. [Pridobivanje dokumentacije v realnem času z MCP](./docs-mcp/README.md)

Ta študija primera vas vodi skozi povezovanje Python konzolnega odjemalca z Model Context Protocol (MCP) strežnikom za pridobivanje in beleženje Microsoftove dokumentacije v realnem času, prilagojene kontekstu. Naučili se boste:

- Povezati se z MCP strežnikom z uporabo Python odjemalca in uradnega MCP SDK
- Uporabljati pretočne HTTP odjemalce za učinkovito pridobivanje podatkov v realnem času
- Klicati orodja za dokumentacijo na strežniku in beležiti odgovore neposredno v konzolo
- Integrirati najnovejšo Microsoftovo dokumentacijo v svoj delovni tok brez zapuščanja terminala

Poglavje vključuje praktično nalogo, minimalni delujoči vzorec kode in povezave do dodatnih virov za poglobljeno učenje. Celoten vodič in kodo si oglejte v povezanem poglavju, da razumete, kako MCP lahko spremeni dostop do dokumentacije in produktivnost razvijalcev v okolju konzole.

### 4. [Interaktivna spletna aplikacija za generiranje študijskega načrta z MCP](./docs-mcp/README.md)

Ta študija primera prikazuje, kako zgraditi interaktivno spletno aplikacijo z uporabo Chainlit in Model Context Protocol (MCP) za generiranje personaliziranih študijskih načrtov za katerokoli temo. Uporabniki lahko določijo predmet (npr. "AI-900 certifikacija") in trajanje študija (npr. 8 tednov), aplikacija pa bo zagotovila tedenski razpored priporočenih vsebin. Chainlit omogoča pogovorni vmesnik, ki izkušnjo naredi privlačno in prilagodljivo.

- Pogovorna spletna aplikacija, ki jo poganja Chainlit
- Uporabniško vodeni pozivi za temo in trajanje
- Tedenski razpored vsebin z uporabo MCP
- Prilagodljivi odgovori v realnem času v pogovornem vmesniku

Projekt prikazuje, kako lahko pogovorna umetna inteligenca in MCP združita moči za ustvarjanje dinamičnih, uporabniško usmerjenih izobraževalnih orodij v sodobnem spletnem okolju.

### 5. [Dokumentacija v urejevalniku z MCP strežnikom v VS Code](./docs-mcp/README.md)

Ta študija primera prikazuje, kako lahko Microsoft Learn dokumentacijo pripeljete neposredno v svoje VS Code okolje z uporabo MCP strežnika—brez preklapljanja med zavihki brskalnika! Videli boste, kako:

- Takoj poiščete in preberete dokumentacijo znotraj VS Code z uporabo MCP plošče ali ukazne palete
- Vstavite reference dokumentacije in povezave neposredno v svoje README ali markdown datoteke tečaja
- Uporabite GitHub Copilot in MCP skupaj za brezhibne, z umetno inteligenco podprte delovne tokove dokumentacije in kode
- Validirate in izboljšate svojo dokumentacijo z povratnimi informacijami v realnem času in Microsoftovo natančnostjo
- Integrirate MCP z GitHub delovnimi tokovi za neprekinjeno validacijo dokumentacije

Implementacija vključuje:

- Primer `.vscode/mcp.json` konfiguracije za enostavno nastavitev
- Vodiče s posnetki zaslona za izkušnjo v urejevalniku
- Nasvete za kombiniranje Copilot in MCP za maksimalno produktivnost

Ta scenarij je idealen za avtorje tečajev, pisce dokumentacije in razvijalce, ki želijo ostati osredotočeni v svojem urejevalniku med delom z dokumentacijo, Copilotom in orodji za validacijo—vse to omogoča MCP.

### 6. [Ustvarjanje MCP strežnika z APIM](./apimsample.md)

Ta študija primera ponuja korak za korakom vodič o tem, kako ustvariti MCP strežnik z uporabo Azure API Management (APIM). Pokriva:

- Nastavitev MCP strežnika v Azure API Management
- Izpostavljanje API operacij kot MCP orodij
- Konfiguracijo politik za omejevanje hitrosti in varnost
- Testiranje MCP strežnika z uporabo Visual Studio Code in GitHub Copilot

Ta primer prikazuje, kako izkoristiti zmogljivosti Azure za ustvarjanje robustnega MCP strežnika, ki ga je mogoče uporabiti v različnih aplikacijah, izboljšuje integracijo sistemov umetne inteligence z poslovnimi API-ji.

## Zaključek

Te študije primerov poudarjajo vsestranskost in praktične uporabe Model Context Protocol v resničnih scenarijih. Od kompleksnih večagentnih sistemov do ciljno usmerjenih avtomatiziranih delovnih tokov MCP ponuja standardiziran način povezovanja sistemov umetne inteligence z orodji in podatki, ki jih potrebujejo za ustvarjanje vrednosti.

S preučevanjem teh implementacij lahko pridobite vpogled v arhitekturne vzorce, strategije implementacije in najboljše prakse, ki jih lahko uporabite v svojih MCP projektih. Primeri dokazujejo, da MCP ni zgolj teoretični okvir, temveč praktična rešitev za resnične poslovne izzive.

## Dodatni viri

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Naprej: Praktična delavnica [Poenostavitev delovnih tokov AI: Gradnja MCP strežnika z AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve AI za prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije priporočamo profesionalni človeški prevod. Ne prevzemamo odgovornosti za morebitne nesporazume ali napačne razlage, ki izhajajo iz uporabe tega prevoda.