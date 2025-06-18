<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:28:45+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "cs"
}
-->
# Praktická implementace

Praktická implementace je moment, kdy se síla Model Context Protocolu (MCP) stává hmatatelnou. I když je důležité rozumět teorii a architektuře MCP, skutečná hodnota se projeví, když tyto koncepty použijete k vytváření, testování a nasazení řešení, která řeší reálné problémy. Tato kapitola překlenuje propast mezi konceptuálními znalostmi a praktickým vývojem a provede vás procesem oživení aplikací založených na MCP.

Ať už vyvíjíte inteligentní asistenty, integrujete AI do podnikových pracovních toků nebo vytváříte vlastní nástroje pro zpracování dat, MCP poskytuje flexibilní základ. Jeho jazykově nezávislý design a oficiální SDK pro populární programovací jazyky zpřístupňují MCP širokému spektru vývojářů. Využitím těchto SDK můžete rychle prototypovat, iterovat a škálovat svá řešení napříč různými platformami a prostředími.

V následujících sekcích najdete praktické příklady, ukázkový kód a strategie nasazení, které ukazují, jak implementovat MCP v C#, Java, TypeScriptu, JavaScriptu a Pythonu. Naučíte se také, jak ladit a testovat MCP servery, spravovat API a nasazovat řešení do cloudu pomocí Azure. Tyto praktické zdroje jsou navrženy tak, aby urychlily vaše učení a pomohly vám sebevědomě vytvářet robustní, produkčně připravené MCP aplikace.

## Přehled

Tato lekce se zaměřuje na praktické aspekty implementace MCP v různých programovacích jazycích. Prozkoumáme, jak používat MCP SDK v C#, Java, TypeScriptu, JavaScriptu a Pythonu k vytváření robustních aplikací, ladění a testování MCP serverů a tvorbě znovupoužitelných zdrojů, promptů a nástrojů.

## Cíle učení

Na konci této lekce budete schopni:
- Implementovat MCP řešení pomocí oficiálních SDK v různých programovacích jazycích
- Systematicky ladit a testovat MCP servery
- Vytvářet a používat serverové funkce (Resources, Prompts a Tools)
- Navrhovat efektivní MCP pracovní toky pro složité úkoly
- Optimalizovat implementace MCP pro výkon a spolehlivost

## Oficiální SDK zdroje

Model Context Protocol nabízí oficiální SDK pro více jazyků:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Práce s MCP SDK

Tato sekce poskytuje praktické příklady implementace MCP v různých programovacích jazycích. Ukázkový kód najdete ve složce `samples` uspořádaný podle jazyka.

### Dostupné ukázky

Repozitář obsahuje [ukázkové implementace](../../../04-PracticalImplementation/samples) v následujících jazycích:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Každá ukázka demonstruje klíčové koncepty MCP a vzory implementace pro daný jazyk a ekosystém.

## Základní funkce serveru

MCP servery mohou implementovat libovolnou kombinaci těchto funkcí:

### Resources  
Resources poskytují kontext a data pro uživatele nebo AI model:  
- Repozitáře dokumentů  
- Znalostní báze  
- Strukturované zdrojové datové sady  
- Souborové systémy  

### Prompts  
Prompts jsou šablonované zprávy a pracovní toky pro uživatele:  
- Předdefinované šablony konverzací  
- Řízené vzory interakce  
- Specializované dialogové struktury  

### Tools  
Tools jsou funkce, které AI model může vykonávat:  
- Nástroje pro zpracování dat  
- Integrace s externími API  
- Výpočetní schopnosti  
- Vyhledávací funkce  

## Ukázkové implementace: C#

Oficiální repozitář C# SDK obsahuje několik ukázkových implementací, které demonstrují různé aspekty MCP:

- **Základní MCP klient**: Jednoduchý příklad, jak vytvořit MCP klienta a volat nástroje  
- **Základní MCP server**: Minimální implementace serveru s registrací základních nástrojů  
- **Pokročilý MCP server**: Plnohodnotný server s registrací nástrojů, autentizací a zpracováním chyb  
- **Integrace s ASP.NET**: Příklady integrace s ASP.NET Core  
- **Vzory implementace nástrojů**: Různé vzory implementace nástrojů s různou úrovní složitosti  

MCP C# SDK je ve fázi preview a API se mohou měnit. Tento blog budeme průběžně aktualizovat podle vývoje SDK.

### Klíčové funkce  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)  
- Vytvoření vašeho [prvního MCP serveru](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).  

Pro kompletní ukázky implementace v C# navštivte [oficiální repozitář C# SDK](https://github.com/modelcontextprotocol/csharp-sdk).

## Ukázková implementace: Java

Java SDK nabízí robustní možnosti implementace MCP s funkcemi na úrovni podniku.

### Klíčové funkce

- Integrace se Spring Frameworkem  
- Silná typová bezpečnost  
- Podpora reaktivního programování  
- Komplexní zpracování chyb  

Pro kompletní ukázkovou implementaci v Javě se podívejte na [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) ve složce s ukázkami.

## Ukázková implementace: JavaScript

JavaScript SDK poskytuje lehký a flexibilní přístup k implementaci MCP.

### Klíčové funkce

- Podpora Node.js i prohlížeče  
- API založené na Promise  
- Snadná integrace s Express a dalšími frameworky  
- Podpora WebSocket pro streamování  

Pro kompletní ukázkovou implementaci v JavaScriptu se podívejte na [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) ve složce s ukázkami.

## Ukázková implementace: Python

Python SDK nabízí pythonický přístup k implementaci MCP s výbornou integrací s ML frameworky.

### Klíčové funkce

- Podpora async/await s asyncio  
- Integrace s Flask a FastAPI  
- Jednoduchá registrace nástrojů  
- Nativní integrace s populárními ML knihovnami  

Pro kompletní ukázkovou implementaci v Pythonu se podívejte na [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) ve složce s ukázkami.

## Správa API

Azure API Management je skvělým řešením, jak zabezpečit MCP servery. Myšlenka je umístit instanci Azure API Management před váš MCP server a nechat ji spravovat funkce, které pravděpodobně budete chtít, jako jsou:

- omezení rychlosti (rate limiting)  
- správa tokenů  
- monitorování  
- vyvažování zátěže  
- zabezpečení  

### Azure ukázka

Zde je Azure ukázka, která přesně toto dělá, tedy [vytváří MCP server a zabezpečuje ho pomocí Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Podívejte se, jak probíhá autorizační tok na následujícím obrázku:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na předchozím obrázku probíhá:

- Autentizace/autorizace pomocí Microsoft Entra.  
- Azure API Management funguje jako brána a používá politiky pro směrování a správu provozu.  
- Azure Monitor zaznamenává všechny požadavky pro další analýzu.  

#### Autorizační tok

Podívejme se podrobněji na autorizační tok:

![Sekvenční diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specifikace autorizace MCP

Více informací o [specifikaci autorizace MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Nasazení vzdáleného MCP serveru do Azure

Podívejme se, zda můžeme nasadit výše zmíněnou ukázku:

1. Naklonujte repozitář

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Zaregistrujte `Microsoft.App`  
   ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `  
   nebo  
   Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `  
   a po chvíli zkontrolujte, zda je registrace dokončena příkazem (Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState.

3. Spusťte tento příkaz [azd](https://aka.ms/azd) pro vytvoření služby API management, funkční aplikace (s kódem) a všech dalších potřebných Azure zdrojů

    ```shell
    azd up
    ```

    Tento příkaz by měl nasadit všechny cloudové zdroje na Azure.

### Testování serveru pomocí MCP Inspectoru

1. V **novém terminálovém okně** nainstalujte a spusťte MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Měli byste vidět rozhraní podobné tomuto:

    ![Připojení k Node inspectoru](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.cs.png) 

2. CTRL klikněte pro načtení webové aplikace MCP Inspector z URL zobrazené aplikací (např. http://127.0.0.1:6274/#resources)  
3. Nastavte typ přenosu na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` a klikněte na **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Vypsat nástroje**. Klikněte na nástroj a zvolte **Run Tool**.  

Pokud vše proběhlo správně, nyní byste měli být připojeni k MCP serveru a mohli jste volat nástroj.

## MCP servery pro Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Tato sada repozitářů je rychlý startovací šablonou pro vytváření a nasazení vlastních vzdálených MCP (Model Context Protocol) serverů pomocí Azure Functions s Pythonem, C# .NET nebo Node/TypeScript.

Ukázky poskytují kompletní řešení, které vývojářům umožňuje:

- Lokální vývoj a běh: Vyvíjet a ladit MCP server na lokálním počítači  
- Nasazení do Azure: Jednoduché nasazení do cloudu pomocí příkazu azd up  
- Připojení z klientů: Připojit se k MCP serveru z různých klientů včetně režimu agenta Copilot ve VS Code a nástroje MCP Inspector  

### Klíčové vlastnosti:

- Bezpečnost navržená od začátku: MCP server je zabezpečen pomocí klíčů a HTTPS  
- Možnosti autentizace: Podpora OAuth pomocí vestavěné autentizace a/nebo API Managementu  
- Izolace sítě: Umožňuje síťovou izolaci pomocí Azure Virtual Networks (VNET)  
- Serverless architektura: Využívá Azure Functions pro škálovatelný, událostmi řízený běh  
- Lokální vývoj: Komplexní podpora lokálního vývoje a ladění  
- Jednoduché nasazení: Zjednodušený proces nasazení do Azure  

Repozitář obsahuje všechny potřebné konfigurační soubory, zdrojový kód a definice infrastruktury pro rychlý start s produkčně připravenou implementací MCP serveru.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Ukázková implementace MCP pomocí Azure Functions s Pythonem  
- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Ukázková implementace MCP pomocí Azure Functions s C# .NET  
- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Ukázková implementace MCP pomocí Azure Functions s Node/TypeScript  

## Hlavní poznatky

- MCP SDK poskytují jazykově specifické nástroje pro implementaci robustních MCP řešení  
- Proces ladění a testování je klíčový pro spolehlivé MCP aplikace  
- Znovupoužitelné šablony promptů umožňují konzistentní AI interakce  
- Dobře navržené pracovní toky mohou orchestrálně řídit složité úkoly s využitím více nástrojů  
- Implementace MCP řešení vyžaduje zvážení bezpečnosti, výkonu a zpracování chyb  

## Cvičení

Navrhněte praktický MCP pracovní tok, který řeší reálný problém ve vašem oboru:

1. Identifikujte 3-4 nástroje, které by byly užitečné pro řešení tohoto problému  
2. Vytvořte diagram pracovního toku ukazující, jak tyto nástroje spolupracují  
3. Implementujte základní verzi jednoho z nástrojů ve vámi preferovaném jazyce  
4. Vytvořte šablonu promptu, která pomůže modelu efektivně využít váš nástroj  

## Další zdroje


---

Další: [Pokročilá témata](../05-AdvancedTopics/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro zásadní informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.