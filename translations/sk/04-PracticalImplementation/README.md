<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:30:11+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sk"
}
-->
# Praktická implementácia

Praktická implementácia je moment, kedy sa sila Model Context Protocolu (MCP) stáva hmatateľnou. Zatiaľ čo porozumenie teórii a architektúre MCP je dôležité, skutočná hodnota sa prejaví, keď tieto koncepty použijete na vytváranie, testovanie a nasadzovanie riešení, ktoré riešia reálne problémy. Táto kapitola prekladá medzeru medzi teoretickými znalosťami a praktickým vývojom a vedie vás procesom, ako oživiť aplikácie založené na MCP.

Či už vyvíjate inteligentných asistentov, integrujete AI do podnikových pracovných tokov alebo vytvárate vlastné nástroje na spracovanie dát, MCP poskytuje flexibilný základ. Jeho nezávislý dizajn na programovacom jazyku a oficiálne SDK pre populárne jazyky sprístupňujú MCP širokému spektru vývojárov. Vďaka týmto SDK môžete rýchlo prototypovať, iterovať a škálovať svoje riešenia naprieč rôznymi platformami a prostrediami.

V nasledujúcich častiach nájdete praktické príklady, ukážkové kódy a stratégie nasadenia, ktoré demonštrujú, ako implementovať MCP v C#, Jave, TypeScripte, JavaScripte a Pythone. Naučíte sa tiež, ako ladit a testovať MCP servery, spravovať API a nasadzovať riešenia do cloudu pomocou Azure. Tieto praktické zdroje sú navrhnuté tak, aby urýchlili vaše učenie a pomohli vám sebavedomo budovať robustné a produkčne pripravené MCP aplikácie.

## Prehľad

Táto lekcia sa zameriava na praktické aspekty implementácie MCP v rôznych programovacích jazykoch. Preskúmame, ako používať MCP SDK v C#, Jave, TypeScripte, JavaScripte a Pythone na tvorbu robustných aplikácií, ladenie a testovanie MCP serverov a tvorbu znovupoužiteľných zdrojov, promptov a nástrojov.

## Ciele učenia

Na konci tejto lekcie budete schopní:
- Implementovať MCP riešenia pomocou oficiálnych SDK v rôznych programovacích jazykoch
- Systematicky ladiť a testovať MCP servery
- Vytvárať a používať funkcie servera (Zdroje, Prompty a Nástroje)
- Navrhovať efektívne MCP pracovné toky pre zložité úlohy
- Optimalizovať MCP implementácie pre výkon a spoľahlivosť

## Oficiálne SDK zdroje

Model Context Protocol ponúka oficiálne SDK pre viacero jazykov:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Práca s MCP SDK

Táto časť poskytuje praktické príklady implementácie MCP v rôznych programovacích jazykoch. Ukážkový kód nájdete v priečinku `samples` usporiadanom podľa jazyka.

### Dostupné ukážky

Repozitár obsahuje [ukážkové implementácie](../../../04-PracticalImplementation/samples) v nasledujúcich jazykoch:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Každý príklad demonštruje kľúčové koncepty MCP a vzory implementácie pre daný jazyk a ekosystém.

## Hlavné funkcie servera

MCP servery môžu implementovať ľubovoľnú kombináciu týchto funkcií:

### Zdroje
Zdroje poskytujú kontext a dáta pre používateľa alebo AI model:
- Repozitáre dokumentov
- Znalostné bázy
- Štruktúrované dátové zdroje
- Súborové systémy

### Prompty
Prompty sú šablónované správy a pracovné toky pre používateľov:
- Preddefinované šablóny konverzácií
- Riadené vzory interakcií
- Špecializované dialógové štruktúry

### Nástroje
Nástroje sú funkcie, ktoré AI model vykonáva:
- Pomôcky na spracovanie dát
- Integrácie s externými API
- Výpočtové schopnosti
- Vyhľadávacia funkcionalita

## Ukážkové implementácie: C#

Oficiálny repozitár C# SDK obsahuje niekoľko ukážkových implementácií, ktoré demonštrujú rôzne aspekty MCP:

- **Základný MCP klient**: Jednoduchý príklad, ako vytvoriť MCP klienta a volať nástroje
- **Základný MCP server**: Minimálna implementácia servera so základnou registráciou nástrojov
- **Pokročilý MCP server**: Plnohodnotný server s registráciou nástrojov, autentifikáciou a spracovaním chýb
- **Integrácia ASP.NET**: Príklady ukazujúce integráciu s ASP.NET Core
- **Vzory implementácie nástrojov**: Rôzne vzory implementácie nástrojov s rôznou úrovňou zložitosti

MCP C# SDK je vo verzii preview a API sa môže meniť. Tento blog budeme priebežne aktualizovať podľa vývoja SDK.

### Kľúčové funkcie 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Vytvorenie [prvého MCP servera](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pre kompletné príklady implementácie v C# navštívte [oficiálny repozitár C# SDK ukážok](https://github.com/modelcontextprotocol/csharp-sdk)

## Ukážková implementácia: Java

Java SDK ponúka robustné možnosti implementácie MCP s funkciami na úrovni podniku.

### Kľúčové funkcie

- Integrácia so Spring Framework
- Silná typová bezpečnosť
- Podpora reaktívneho programovania
- Komplexné spracovanie chýb

Pre kompletný príklad implementácie v Jave pozrite [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) v priečinku so vzormi.

## Ukážková implementácia: JavaScript

JavaScript SDK poskytuje ľahký a flexibilný prístup k implementácii MCP.

### Kľúčové funkcie

- Podpora Node.js a prehliadača
- API založené na Promise
- Jednoduchá integrácia s Express a ďalšími frameworkmi
- Podpora WebSocket pre streamovanie

Pre kompletný príklad implementácie v JavaScripte pozrite [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) v priečinku so vzormi.

## Ukážková implementácia: Python

Python SDK ponúka pythonický prístup k implementácii MCP s vynikajúcou integráciou ML frameworkov.

### Kľúčové funkcie

- Podpora async/await s asyncio
- Integrácia s Flask a FastAPI
- Jednoduchá registrácia nástrojov
- Nativna integrácia s populárnymi ML knižnicami

Pre kompletný príklad implementácie v Pythone pozrite [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) v priečinku so vzormi.

## Správa API

Azure API Management je skvelé riešenie, ako zabezpečiť MCP servery. Myšlienka je umiestniť Azure API Management pred váš MCP server a nechať ho spravovať funkcie, ktoré pravdepodobne budete chcieť, ako napríklad:

- obmedzovanie rýchlosti (rate limiting)
- správa tokenov
- monitorovanie
- vyvažovanie záťaže
- bezpečnosť

### Azure príklad

Tu je príklad Azure, ktorý robí presne toto, t.j. [vytvára MCP server a zabezpečuje ho pomocou Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Pozrite sa, ako prebieha autorizačný tok na obrázku nižšie:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na predchádzajúcom obrázku prebieha:

- Autentifikácia/autorizácia pomocou Microsoft Entra.
- Azure API Management funguje ako brána a používa politiky na smerovanie a správu prevádzky.
- Azure Monitor zaznamenáva všetky požiadavky na ďalšiu analýzu.

#### Autorizačný tok

Pozrime sa podrobnejšie na autorizačný tok:

![Sekvenčný diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Špecifikácia autorizácie MCP

Viac informácií o [špecifikácii MCP autorizácie](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Nasadenie vzdialeného MCP servera do Azure

Pozrime sa, či môžeme nasadiť spomínaný príklad:

1. Naklonujte repozitár

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Zaregistrujte `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` a po chvíli skontrolujte, či je registrácia dokončená.

2. Spustite tento príkaz [azd](https://aka.ms/azd) na vytvorenie služby API Management, funkčnej aplikácie (s kódom) a všetkých ďalších potrebných Azure zdrojov

    ```shell
    azd up
    ```

    Tento príkaz by mal nasadiť všetky cloudové zdroje na Azure

### Testovanie servera pomocou MCP Inspector

1. V **novom terminálovom okne** nainštalujte a spustite MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Mali by ste vidieť rozhranie podobné tomuto:

    ![Pripojenie k Node inspector](../../../translated_images/connect.49432730345c91c54a960e7903f84055fd21ea216176e01ea69f66de4b7602cb.sk.png) 

1. CTRL kliknite pre načítanie MCP Inspector webovej aplikácie z URL zobrazeného aplikáciou (napr. http://127.0.0.1:6274/#resources)
1. Nastavte typ prenosu na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` a **Pripojte sa**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Zoznam nástrojov**. Kliknite na nástroj a **Spustite nástroj**.  

Ak všetky kroky prebehli úspešne, mali by ste byť pripojení k MCP serveru a podarilo sa vám zavolať nástroj.

## MCP servery pre Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Táto sada repozitárov je rýchly štartovací šablónový projekt na tvorbu a nasadenie vlastných vzdialených MCP (Model Context Protocol) serverov pomocou Azure Functions v Pythone, C# .NET alebo Node/TypeScript.

Ukážky poskytujú kompletné riešenie, ktoré umožňuje vývojárom:

- Vývoj a spustenie lokálne: Vyvíjať a ladiť MCP server na lokálnom počítači
- Nasadenie do Azure: Jednoducho nasadiť do cloudu pomocou jednoduchého príkazu azd up
- Pripojenie z klientov: Pripojiť sa k MCP serveru z rôznych klientov vrátane režimu agenta Copilot vo VS Code a nástroja MCP Inspector

### Kľúčové vlastnosti:

- Bezpečnosť v návrhu: MCP server je zabezpečený pomocou kľúčov a HTTPS
- Možnosti autentifikácie: Podpora OAuth s využitím vstavaného autentifikačného systému a/alebo API Management
- Izolácia siete: Umožňuje sieťovú izoláciu pomocou Azure Virtual Networks (VNET)
- Serverless architektúra: Využíva Azure Functions pre škálovateľné, event-driven vykonávanie
- Lokálny vývoj: Komplexná podpora lokálneho vývoja a ladenia
- Jednoduché nasadenie: Zjednodušený proces nasadenia do Azure

Repozitár obsahuje všetky potrebné konfiguračné súbory, zdrojový kód a definície infraštruktúry na rýchly štart s produkčne pripravenou MCP serverovou implementáciou.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Ukážková implementácia MCP pomocou Azure Functions v Pythone

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Ukážková implementácia MCP pomocou Azure Functions v C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Ukážková implementácia MCP pomocou Azure Functions v Node/TypeScript.

## Kľúčové zhrnutie

- MCP SDK poskytujú jazykovo špecifické nástroje na implementáciu robustných MCP riešení
- Proces ladenia a testovania je kľúčový pre spoľahlivé MCP aplikácie
- Znovupoužiteľné šablóny promptov umožňujú konzistentnú interakciu s AI
- Dobre navrhnuté pracovné toky dokážu koordinovať zložité úlohy využívajúce viacero nástrojov
- Implementácia MCP riešení si vyžaduje zohľadnenie bezpečnosti, výkonu a spracovania chýb

## Cvičenie

Navrhnite praktický MCP pracovný tok, ktorý rieši reálny problém vo vašej oblasti:

1. Identifikujte 3-4 nástroje, ktoré by boli užitočné na riešenie tohto problému
2. Vytvorte diagram pracovného toku, ktorý ukáže, ako tieto nástroje spolupracujú
3. Implementujte základnú verziu jedného z nástrojov vo vašom preferovanom jazyku
4. Vytvorte šablónu promptu, ktorá pomôže modelu efektívne používať váš nástroj

## Ďalšie zdroje


---

Ďalej: [Pokročilé témy](../05-AdvancedTopics/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, berte prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nezodpovedáme za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.