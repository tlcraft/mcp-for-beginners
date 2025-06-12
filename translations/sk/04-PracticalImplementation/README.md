<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:26:56+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sk"
}
-->
# Praktická implementácia

Praktická implementácia je moment, kedy sa sila Model Context Protocolu (MCP) stáva hmatateľnou. Aj keď je dôležité porozumieť teórii a architektúre MCP, skutočná hodnota sa prejaví, keď tieto koncepty využijete na vytváranie, testovanie a nasadzovanie riešení, ktoré riešia reálne problémy. Táto kapitola prekladá priepasť medzi konceptuálnymi znalosťami a praktickým vývojom a vedie vás procesom, ako oživiť aplikácie založené na MCP.

Či už vyvíjate inteligentných asistentov, integrujete AI do podnikových procesov alebo tvoríte vlastné nástroje na spracovanie dát, MCP poskytuje flexibilný základ. Jeho jazykovo neutrálna koncepcia a oficiálne SDK pre populárne programovacie jazyky sú prístupné širokému spektru vývojárov. Vďaka týmto SDK môžete rýchlo vytvárať prototypy, iterovať a škálovať svoje riešenia na rôznych platformách a prostrediach.

V nasledujúcich častiach nájdete praktické príklady, ukážkový kód a stratégie nasadenia, ktoré demonštrujú, ako implementovať MCP v C#, Java, TypeScript, JavaScript a Pythone. Naučíte sa tiež, ako debugovať a testovať svoje MCP servery, spravovať API a nasadzovať riešenia do cloudu pomocou Azure. Tieto praktické zdroje sú navrhnuté tak, aby urýchlili vaše učenie a pomohli vám sebavedome vytvárať robustné, produkčne pripravené MCP aplikácie.

## Prehľad

Táto lekcia sa zameriava na praktické aspekty implementácie MCP naprieč viacerými programovacími jazykmi. Preskúmame, ako používať MCP SDK v C#, Java, TypeScript, JavaScript a Pythone na tvorbu robustných aplikácií, debugovanie a testovanie MCP serverov a vytváranie znovupoužiteľných zdrojov, promptov a nástrojov.

## Ciele učenia

Na konci tejto lekcie budete schopní:
- Implementovať MCP riešenia pomocou oficiálnych SDK v rôznych programovacích jazykoch
- Systematicky debugovať a testovať MCP servery
- Vytvárať a používať funkcie servera (Resources, Prompts a Tools)
- Navrhovať efektívne MCP workflow pre zložité úlohy
- Optimalizovať MCP implementácie z hľadiska výkonu a spoľahlivosti

## Oficiálne SDK zdroje

Model Context Protocol ponúka oficiálne SDK pre viacero jazykov:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Práca s MCP SDK

Táto sekcia prináša praktické príklady implementácie MCP v rôznych programovacích jazykoch. Ukážkový kód nájdete v adresári `samples` usporiadanom podľa jazyka.

### Dostupné príklady

Repozitár obsahuje ukážkové implementácie v nasledujúcich jazykoch:

- C#
- Java
- TypeScript
- JavaScript
- Python

Každý príklad demonštruje kľúčové koncepty MCP a vzory implementácie pre daný jazyk a ekosystém.

## Základné funkcie servera

MCP servery môžu implementovať ľubovoľnú kombináciu týchto funkcií:

### Resources  
Resources poskytujú kontext a dáta pre používateľa alebo AI model:
- Úložiská dokumentov
- Znalostné bázy
- Štruktúrované dátové zdroje
- Súborové systémy

### Prompts  
Prompts sú šablónové správy a workflow pre používateľov:
- Preddefinované konverzačné šablóny
- Riadené vzory interakcie
- Špecializované dialógové štruktúry

### Tools  
Tools sú funkcie, ktoré môže AI model vykonávať:
- Nástroje na spracovanie dát
- Integrácie s externými API
- Výpočtové schopnosti
- Vyhľadávacia funkcionalita

## Ukážkové implementácie: C#

Oficiálny C# SDK repozitár obsahuje niekoľko ukážkových implementácií, ktoré demonštrujú rôzne aspekty MCP:

- **Basic MCP Client**: Jednoduchý príklad, ako vytvoriť MCP klienta a volať nástroje
- **Basic MCP Server**: Minimálna implementácia servera so základnou registráciou nástrojov
- **Advanced MCP Server**: Plnofunkčný server s registráciou nástrojov, autentifikáciou a spracovaním chýb
- **ASP.NET Integrácia**: Príklady integrácie s ASP.NET Core
- **Vzory implementácie nástrojov**: Rôzne vzory pre implementáciu nástrojov s rôznou mierou zložitosti

C# SDK MCP je momentálne v preview a API sa môže meniť. Tento blog budeme priebežne aktualizovať podľa vývoja SDK.

### Kľúčové funkcie  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Vytvorenie [prvého MCP servera](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pre kompletné C# ukážky implementácie navštívte [oficiálny repozitár C# SDK príkladov](https://github.com/modelcontextprotocol/csharp-sdk)

## Ukážková implementácia: Java

Java SDK ponúka robustné možnosti implementácie MCP s funkciami na úrovni podnikov.

### Kľúčové funkcie

- Integrácia so Spring Framework
- Silná typová bezpečnosť
- Podpora reaktívneho programovania
- Komplexné spracovanie chýb

Pre kompletný Java príklad implementácie pozrite si [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) v adresári príkladov.

## Ukážková implementácia: JavaScript

JavaScript SDK poskytuje ľahký a flexibilný prístup k implementácii MCP.

### Kľúčové funkcie

- Podpora Node.js a prehliadačov
- API založené na Promise
- Jednoduchá integrácia s Express a inými frameworkmi
- Podpora WebSocket pre streamovanie

Pre kompletný JavaScript príklad implementácie pozrite si [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) v adresári príkladov.

## Ukážková implementácia: Python

Python SDK ponúka Pythonický prístup k implementácii MCP s výbornou integráciou ML frameworkov.

### Kľúčové funkcie

- Podpora async/await s asyncio
- Integrácia s Flask a FastAPI
- Jednoduchá registrácia nástrojov
- Nativna integrácia s populárnymi ML knižnicami

Pre kompletný Python príklad implementácie pozrite si [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) v adresári príkladov.

## Správa API

Azure API Management je výborným riešením, ako zabezpečiť MCP servery. Myšlienka je umiestniť inštanciu Azure API Management pred váš MCP server a nechať ju spravovať funkcie, ktoré pravdepodobne budete potrebovať, ako napríklad:

- obmedzovanie rýchlosti (rate limiting)
- správa tokenov
- monitorovanie
- vyvažovanie záťaže
- bezpečnosť

### Azure príklad

Tu je Azure príklad, ktorý presne toto robí, teda [vytvára MCP server a zabezpečuje ho pomocou Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Pozrite si, ako prebieha autorizačný tok na obrázku nižšie:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na predchádzajúcom obrázku sa deje nasledovné:

- Autentifikácia/Autorizácia prebieha cez Microsoft Entra.
- Azure API Management funguje ako brána a používa politiky na smerovanie a správu prevádzky.
- Azure Monitor zaznamenáva všetky požiadavky na ďalšiu analýzu.

#### Autorizačný tok

Pozrime sa podrobnejšie na autorizačný tok:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Špecifikácia MCP autorizácie

Viac informácií o [špecifikácii MCP autorizácie](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Nasadenie vzdialeného MCP servera na Azure

Pozrime sa, či môžeme nasadiť spomenutý príklad:

1. Naklonujte repozitár

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Zaregistrujte `Microsoft.App`  
   ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `  
   alebo  
   Register-AzResourceProvider -ProviderNamespace Microsoft.App  
   `. Then run `  
   Po chvíli skontrolujte, či je registrácia dokončená.

2. Spustite tento [azd](https://aka.ms/azd) príkaz na provisionovanie API management služby, funkčnej aplikácie (s kódom) a všetkých ďalších potrebných Azure zdrojov

    ```shell
    azd up
    ```

    Tento príkaz by mal nasadiť všetky cloudové zdroje na Azure.

### Testovanie servera s MCP Inspector

1. V **novom terminálovom okne** nainštalujte a spustite MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Mali by ste vidieť rozhranie podobné tomuto:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sk.png) 

1. Stlačte CTRL a kliknite pre načítanie MCP Inspector webovej aplikácie z URL zobrazeného v aplikácii (napr. http://127.0.0.1:6274/#resources)
1. Nastavte typ transportu na `SSE` `
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` a kliknite na **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Zoznam nástrojov**. Kliknite na nástroj a zvoľte **Run Tool**.

Ak všetko prebehlo správne, ste teraz pripojení k MCP serveru a úspešne ste zavolali nástroj.

## MCP servery pre Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Tento súbor repozitárov je šablóna na rýchly štart pre budovanie a nasadzovanie vlastných vzdialených MCP (Model Context Protocol) serverov pomocou Azure Functions s Python, C# .NET alebo Node/TypeScript.

Ukážky poskytujú kompletné riešenie, ktoré umožňuje vývojárom:

- Lokálny vývoj a spustenie: Vývoj a debug MCP servera na lokálnom stroji
- Nasadenie do Azure: Jednoduché nasadenie do cloudu pomocou príkazu azd up
- Pripojenie klientov: Pripojenie ku MCP serveru z rôznych klientov vrátane režimu agenta Copilot vo VS Code a nástroja MCP Inspector

### Kľúčové vlastnosti:

- Bezpečnosť od základu: MCP server je zabezpečený pomocou kľúčov a HTTPS
- Možnosti autentifikácie: Podpora OAuth pomocou vstavaného auth a/alebo API Management
- Izolácia siete: Umožňuje izoláciu siete pomocou Azure Virtual Networks (VNET)
- Serverless architektúra: Využíva Azure Functions pre škálovateľné, event-driven vykonávanie
- Lokálny vývoj: Komplexná podpora lokálneho vývoja a debugovania
- Jednoduché nasadenie: Zjednodušený proces nasadenia do Azure

Repozitár obsahuje všetky potrebné konfiguračné súbory, zdrojový kód a infraštruktúrne definície na rýchly štart s produkčne pripravenou MCP serverovou implementáciou.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Ukážková implementácia MCP pomocou Azure Functions v Pythone

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Ukážková implementácia MCP pomocou Azure Functions v C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Ukážková implementácia MCP pomocou Azure Functions v Node/TypeScript.

## Kľúčové poznatky

- MCP SDK poskytujú jazykovo špecifické nástroje na implementáciu robustných MCP riešení
- Proces debugovania a testovania je kľúčový pre spoľahlivé MCP aplikácie
- Znovupoužiteľné šablóny promptov umožňujú konzistentné AI interakcie
- Dobre navrhnuté workflow dokážu koordinovať zložité úlohy využívajúce viacero nástrojov
- Implementácia MCP riešení vyžaduje zohľadnenie bezpečnosti, výkonu a spracovania chýb

## Cvičenie

Navrhnite praktické MCP workflow, ktoré rieši reálny problém vo vašej oblasti:

1. Identifikujte 3-4 nástroje, ktoré by boli užitočné na riešenie tohto problému
2. Vytvorte diagram workflow, ktorý ukazuje, ako tieto nástroje spolupracujú
3. Implementujte základnú verziu jedného z nástrojov vo vašom preferovanom jazyku
4. Vytvorte šablónu promptu, ktorá pomôže modelu efektívne používať váš nástroj

## Ďalšie zdroje


---

Ďalej: [Advanced Topics](../05-AdvancedTopics/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, majte prosím na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.