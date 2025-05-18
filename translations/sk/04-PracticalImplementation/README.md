<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T14:00:59+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sk"
}
-->
# Praktická implementácia

Praktická implementácia je miesto, kde sa sila Model Context Protocol (MCP) stáva hmatateľnou. Zatiaľ čo pochopenie teórie a architektúry za MCP je dôležité, skutočná hodnota sa objavuje, keď tieto koncepty použijete na vytvorenie, testovanie a nasadenie riešení, ktoré riešia problémy v reálnom svete. Táto kapitola prekonáva priepasť medzi koncepčnými vedomosťami a praktickým vývojom, vedie vás procesom oživenia aplikácií založených na MCP.

Či už vyvíjate inteligentných asistentov, integrujete AI do obchodných procesov, alebo vytvárate vlastné nástroje na spracovanie dát, MCP poskytuje flexibilný základ. Jeho jazykovo nezávislý dizajn a oficiálne SDK pre populárne programovacie jazyky ho robia prístupným širokému spektru vývojárov. Využitím týchto SDK môžete rýchlo prototypovať, iterovať a škálovať svoje riešenia na rôznych platformách a v rôznych prostrediach.

V nasledujúcich sekciách nájdete praktické príklady, ukážkový kód a stratégie nasadenia, ktoré ukazujú, ako implementovať MCP v C#, Java, TypeScript, JavaScript a Python. Naučíte sa tiež, ako ladit a testovať svoje MCP servery, spravovať API a nasadzovať riešenia do cloudu pomocou Azure. Tieto praktické zdroje sú navrhnuté tak, aby urýchlili vaše učenie a pomohli vám s istotou vytvárať robustné, produkčne pripravené aplikácie MCP.

## Prehľad

Táto lekcia sa zameriava na praktické aspekty implementácie MCP v rôznych programovacích jazykoch. Preskúmame, ako používať MCP SDK v C#, Java, TypeScript, JavaScript a Python na vytváranie robustných aplikácií, ladenie a testovanie MCP serverov a vytváranie znovupoužiteľných zdrojov, výziev a nástrojov.

## Ciele učenia

Na konci tejto lekcie budete schopní:
- Implementovať MCP riešenia pomocou oficiálnych SDK v rôznych programovacích jazykoch
- Systematicky ladit a testovať MCP servery
- Vytvárať a používať funkcie servera (Zdroje, Výzvy a Nástroje)
- Navrhovať efektívne MCP pracovné toky pre komplexné úlohy
- Optimalizovať implementácie MCP pre výkon a spoľahlivosť

## Oficiálne SDK zdroje

Model Context Protocol ponúka oficiálne SDK pre viacero jazykov:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Práca s MCP SDK

Táto sekcia poskytuje praktické príklady implementácie MCP v rôznych programovacích jazykoch. Ukážkový kód nájdete v adresári `samples` usporiadanom podľa jazyka.

### Dostupné ukážky

Repozitár obsahuje ukážkové implementácie v nasledujúcich jazykoch:

- C#
- Java
- TypeScript
- JavaScript
- Python

Každá ukážka demonštruje kľúčové koncepty MCP a vzory implementácie pre konkrétny jazyk a ekosystém.

## Kľúčové funkcie servera

MCP servery môžu implementovať ľubovoľnú kombináciu týchto funkcií:

### Zdroje
Zdroje poskytujú kontext a dáta pre používateľa alebo AI model na použitie:
- Repozitáre dokumentov
- Znalostné bázy
- Štruktúrované zdroje dát
- Súborové systémy

### Výzvy
Výzvy sú šablónované správy a pracovné toky pre používateľov:
- Preddefinované konverzačné šablóny
- Riadené vzory interakcie
- Špecializované štruktúry dialógu

### Nástroje
Nástroje sú funkcie, ktoré má AI model vykonávať:
- Nástroje na spracovanie dát
- Integrácie externých API
- Výpočtové schopnosti
- Funkcionalita vyhľadávania

## Ukážkové implementácie: C#

Oficiálny C# SDK repozitár obsahuje niekoľko ukážkových implementácií, ktoré demonštrujú rôzne aspekty MCP:

- **Základný MCP klient**: Jednoduchý príklad, ako vytvoriť MCP klienta a volať nástroje
- **Základný MCP server**: Minimálna implementácia servera so základnou registráciou nástrojov
- **Pokročilý MCP server**: Plne vybavený server s registráciou nástrojov, autentifikáciou a spracovaním chýb
- **Integrácia ASP.NET**: Príklady demonštrujúce integráciu s ASP.NET Core
- **Vzory implementácie nástrojov**: Rôzne vzory implementácie nástrojov s rôznou úrovňou zložitosti

C# SDK MCP je v prehľade a API sa môžu meniť. Tento blog budeme neustále aktualizovať, ako sa SDK vyvíja.

### Kľúčové funkcie 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Vytvorenie vášho [prvého MCP servera](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pre kompletné ukážky implementácie C# navštívte [oficiálny repozitár ukážok C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Ukážková implementácia: Java implementácia

Java SDK ponúka robustné možnosti implementácie MCP s funkciami na úrovni podniku.

### Kľúčové funkcie

- Integrácia so Spring Framework
- Silná typová bezpečnosť
- Podpora reaktívneho programovania
- Komplexné spracovanie chýb

Pre kompletnú ukážku implementácie v Jave, pozrite si [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) v adresári ukážok.

## Ukážková implementácia: JavaScript implementácia

JavaScript SDK poskytuje ľahký a flexibilný prístup k implementácii MCP.

### Kľúčové funkcie

- Podpora pre Node.js a prehliadač
- API založené na Promise
- Jednoduchá integrácia s Express a ďalšími frameworkami
- Podpora WebSocket pre streamovanie

Pre kompletnú ukážku implementácie v JavaScripte, pozrite si [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) v adresári ukážok.

## Ukážková implementácia: Python implementácia

Python SDK ponúka Pythonický prístup k implementácii MCP s vynikajúcimi integráciami ML frameworkov.

### Kľúčové funkcie

- Podpora Async/await s asyncio
- Integrácia s Flask a FastAPI
- Jednoduchá registrácia nástrojov
- Natívna integrácia s populárnymi ML knižnicami

Pre kompletnú ukážku implementácie v Pythone, pozrite si [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) v adresári ukážok.

## Správa API

Azure API Management je skvelá odpoveď na to, ako môžeme zabezpečiť MCP servery. Myšlienka je umiestniť Azure API Management pred váš MCP server a nechať ho spravovať funkcie, ktoré pravdepodobne budete chcieť, ako sú:

- obmedzenie rýchlosti
- správa tokenov
- monitorovanie
- vyrovnávanie záťaže
- bezpečnosť

### Azure Ukážka

Tu je Azure ukážka, ktorá robí presne to, teda [vytvára MCP server a zabezpečuje ho pomocou Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Pozrite sa, ako prebieha autorizačný tok na obrázku nižšie:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na predchádzajúcom obrázku sa deje nasledovné:

- Autentifikácia/autorizácia prebieha pomocou Microsoft Entra.
- Azure API Management funguje ako brána a používa politiky na riadenie a správu prenosu.
- Azure Monitor zaznamenáva všetky požiadavky pre ďalšiu analýzu.

#### Autorizačný tok

Pozrime sa podrobnejšie na autorizačný tok:

![Sekvenčný diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Špecifikácia autorizácie MCP

Viac sa dozviete o [špecifikácii autorizácie MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Nasadenie vzdialeného MCP servera do Azure

Pozrime sa, či môžeme nasadiť ukážku, ktorú sme spomenuli skôr:

1. Klonujte repozitár

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registrovať `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` po určitom čase na kontrolu, či je registrácia dokončená.

2. Spustite tento [azd](https://aka.ms/azd) príkaz na zriadenie služby správy API, funkčnej aplikácie (s kódom) a všetkých ostatných potrebných zdrojov Azure

    ```shell
    azd up
    ```

    Tento príkaz by mal nasadiť všetky cloudové zdroje na Azure

### Testovanie vášho servera s MCP Inspector

1. V **novom okne terminálu**, nainštalujte a spustite MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Mali by ste vidieť rozhranie podobné:

    ![Pripojenie k Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.sk.png)

1. Stlačte CTRL a kliknite na načítanie webovej aplikácie MCP Inspector z URL zobrazeného aplikáciou (napr. http://127.0.0.1:6274/#resources)
1. Nastavte typ prenosu na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` a **Pripojiť**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Zoznam nástrojov**. Kliknite na nástroj a **Spustiť nástroj**.  

Ak všetky kroky fungovali, mali by ste byť teraz pripojení k MCP serveru a mali by ste byť schopní zavolať nástroj.

## MCP servery pre Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Táto sada repozitárov je rýchlym štartom pre vytváranie a nasadenie vlastných vzdialených MCP (Model Context Protocol) serverov pomocou Azure Functions s Python, C# .NET alebo Node/TypeScript. 

Ukážky poskytujú kompletné riešenie, ktoré umožňuje vývojárom:

- Vytvárať a spúšťať lokálne: Vyvíjať a ladiť MCP server na lokálnom stroji
- Nasadiť do Azure: Jednoducho nasadiť do cloudu pomocou jednoduchého príkazu azd up
- Pripojiť sa z klientov: Pripojiť sa k MCP serveru z rôznych klientov vrátane VS Code's Copilot agent módu a nástroja MCP Inspector

### Kľúčové funkcie:

- Bezpečnosť podľa návrhu: MCP server je zabezpečený pomocou kľúčov a HTTPS
- Možnosti autentifikácie: Podporuje OAuth pomocou vstavaného overovania a/alebo správy API
- Izolácia siete: Umožňuje izoláciu siete pomocou Azure Virtual Networks (VNET)
- Serverless architektúra: Využíva Azure Functions pre škálovateľné, udalosťami riadené vykonávanie
- Lokálny vývoj: Komplexná podpora lokálneho vývoja a ladenia
- Jednoduché nasadenie: Zjednodušený proces nasadenia do Azure

Repozitár obsahuje všetky potrebné konfiguračné súbory, zdrojový kód a definície infraštruktúry, aby ste mohli rýchlo začať s produkčne pripravenou implementáciou MCP servera.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Ukážková implementácia MCP pomocou Azure Functions s Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Ukážková implementácia MCP pomocou Azure Functions s C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Ukážková implementácia MCP pomocou Azure Functions s Node/TypeScript.

## Kľúčové poznatky

- MCP SDK poskytujú jazykovo špecifické nástroje na implementáciu robustných MCP riešení
- Proces ladenia a testovania je kľúčový pre spoľahlivé aplikácie MCP
- Znovupoužiteľné šablóny výziev umožňujú konzistentné AI interakcie
- Dobre navrhnuté pracovné toky môžu orchestrate komplexné úlohy pomocou viacerých nástrojov
- Implementácia MCP riešení vyžaduje zváženie bezpečnosti, výkonu a spracovania chýb

## Cvičenie

Navrhnite praktický MCP pracovný tok, ktorý rieši reálny problém vo vašej oblasti:

1. Identifikujte 3-4 nástroje, ktoré by boli užitočné pri riešení tohto problému
2. Vytvorte diagram pracovného toku, ktorý ukazuje, ako tieto nástroje spolupracujú
3. Implementujte základnú verziu jedného z nástrojov pomocou vášho preferovaného jazyka
4. Vytvorte šablónu výzvy, ktorá by pomohla modelu efektívne používať váš nástroj

## Ďalšie zdroje

---

Ďalej: [Pokročilé témy](../05-AdvancedTopics/README.md)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, uvedomte si, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by sa mal považovať za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.