<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T14:00:24+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "cs"
}
-->
# Praktická Implementace

Praktická implementace je místem, kde se síla Model Context Protocol (MCP) stává hmatatelnou. Zatímco pochopení teorie a architektury MCP je důležité, skutečná hodnota se projeví, když tyto koncepty použijete k vytváření, testování a nasazování řešení, která řeší problémy reálného světa. Tato kapitola překonává propast mezi konceptuálními znalostmi a praktickým vývojem, a provede vás procesem oživování aplikací založených na MCP.

Ať už vyvíjíte inteligentní asistenty, integrujete AI do podnikových pracovních postupů nebo vytváříte vlastní nástroje pro zpracování dat, MCP poskytuje flexibilní základ. Jeho jazykově nezávislý design a oficiální SDK pro populární programovací jazyky jej činí dostupným pro široké spektrum vývojářů. Využitím těchto SDK můžete rychle prototypovat, iterovat a škálovat svá řešení napříč různými platformami a prostředími.

V následujících sekcích najdete praktické příklady, ukázkový kód a strategie nasazení, které demonstrují, jak implementovat MCP v C#, Java, TypeScript, JavaScript a Python. Naučíte se také, jak ladit a testovat své MCP servery, spravovat API a nasazovat řešení do cloudu pomocí Azure. Tyto praktické zdroje jsou navrženy tak, aby urychlily vaše učení a pomohly vám sebevědomě vytvářet robustní, připravené pro produkci aplikace MCP.

## Přehled

Tato lekce se zaměřuje na praktické aspekty implementace MCP napříč několika programovacími jazyky. Prozkoumáme, jak používat MCP SDK v C#, Java, TypeScript, JavaScript a Python k vytváření robustních aplikací, ladění a testování MCP serverů a vytváření opakovaně použitelných zdrojů, výzev a nástrojů.

## Cíle Učení

Na konci této lekce budete schopni:
- Implementovat MCP řešení pomocí oficiálních SDK v různých programovacích jazycích
- Systematicky ladit a testovat MCP servery
- Vytvářet a používat funkce serveru (Zdroje, Výzvy a Nástroje)
- Navrhovat efektivní MCP pracovní postupy pro složité úkoly
- Optimalizovat implementace MCP pro výkon a spolehlivost

## Oficiální SDK Zdroje

Model Context Protocol nabízí oficiální SDK pro více jazyků:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Práce s MCP SDK

Tato sekce poskytuje praktické příklady implementace MCP napříč několika programovacími jazyky. Ukázkový kód najdete v adresáři `samples` organizovaném podle jazyka.

### Dostupné Ukázky

Repozitář obsahuje ukázkové implementace v následujících jazycích:

- C#
- Java
- TypeScript
- JavaScript
- Python

Každá ukázka demonstruje klíčové MCP koncepty a vzory implementace pro daný jazyk a ekosystém.

## Základní Funkce Serveru

MCP servery mohou implementovat libovolnou kombinaci těchto funkcí:

### Zdroje
Zdroje poskytují kontext a data pro uživatele nebo AI model k použití:
- Dokumentové úložiště
- Znalostní báze
- Strukturované datové zdroje
- Souborové systémy

### Výzvy
Výzvy jsou šablonované zprávy a pracovní postupy pro uživatele:
- Předdefinované konverzační šablony
- Vedené vzory interakce
- Specializované struktury dialogu

### Nástroje
Nástroje jsou funkce, které AI model může vykonávat:
- Pomůcky pro zpracování dat
- Integrace externích API
- Výpočetní schopnosti
- Funkce vyhledávání

## Ukázková Implementace: C#

Oficiální C# SDK repozitář obsahuje několik ukázkových implementací, které demonstrují různé aspekty MCP:

- **Základní MCP Klient**: Jednoduchý příklad ukazující, jak vytvořit MCP klienta a volat nástroje
- **Základní MCP Server**: Minimální implementace serveru s registrací základních nástrojů
- **Pokročilý MCP Server**: Plně vybavený server s registrací nástrojů, autentizací a zpracováním chyb
- **Integrace ASP.NET**: Příklady demonstrující integraci s ASP.NET Core
- **Vzory Implementace Nástrojů**: Různé vzory pro implementaci nástrojů s různou úrovní složitosti

C# MCP SDK je v náhledu a API se mohou měnit. Budeme tento blog průběžně aktualizovat, jak se SDK vyvíjí.

### Klíčové Funkce 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Vytvoření vašeho [prvního MCP Serveru](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pro kompletní ukázky implementace v C# navštivte [oficiální C# SDK ukázkový repozitář](https://github.com/modelcontextprotocol/csharp-sdk)

## Ukázková Implementace: Java Implementace

Java SDK nabízí robustní možnosti implementace MCP s podnikové úrovně funkcemi.

### Klíčové Funkce

- Integrace s Spring Framework
- Silná typová bezpečnost
- Podpora reaktivního programování
- Komplexní zpracování chyb

Pro kompletní ukázku implementace v Java, viz [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) v adresáři ukázek.

## Ukázková Implementace: JavaScript Implementace

JavaScript SDK poskytuje lehký a flexibilní přístup k implementaci MCP.

### Klíčové Funkce

- Podpora pro Node.js a prohlížeče
- API založené na promiscích
- Snadná integrace s Express a dalšími frameworky
- Podpora WebSocket pro streamování

Pro kompletní ukázku implementace v JavaScript, viz [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) v adresáři ukázek.

## Ukázková Implementace: Python Implementace

Python SDK nabízí Pythonický přístup k implementaci MCP s vynikajícími integracemi ML frameworků.

### Klíčové Funkce

- Podpora async/await s asyncio
- Integrace s Flask a FastAPI
- Jednoduchá registrace nástrojů
- Nativní integrace s populárními ML knihovnami

Pro kompletní ukázku implementace v Python, viz [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) v adresáři ukázek.

## Správa API

Azure API Management je skvělou odpovědí na to, jak můžeme zabezpečit MCP servery. Myšlenka je umístit instanci Azure API Management před váš MCP server a nechat ji zpracovat funkce, které pravděpodobně budete chtít jako:

- omezení rychlosti
- správa tokenů
- monitorování
- vyvažování zátěže
- bezpečnost

### Azure Ukázka

Zde je Azure Ukázka, která přesně tohle dělá, tedy [vytváření MCP Serveru a jeho zabezpečení pomocí Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Podívejte se, jak probíhá autorizační tok na níže uvedeném obrázku:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na předchozím obrázku probíhá následující:

- Probíhá autentizace/autorizace pomocí Microsoft Entra.
- Azure API Management funguje jako brána a používá zásady k řízení a správě provozu.
- Azure Monitor zaznamenává všechny požadavky pro další analýzu.

#### Autorizační Tok

Podívejme se na autorizační tok podrobněji:

![Diagram Sekvence](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specifikace Autorizace MCP

Zjistěte více o [specifikaci autorizace MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Nasazení Vzdáleného MCP Serveru na Azure

Podívejme se, zda můžeme nasadit ukázku, kterou jsme zmínili dříve:

1. Klonujte repozitář

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Zaregistrujte `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` po nějaké době pro kontrolu, zda je registrace dokončena.

2. Spusťte tento [azd](https://aka.ms/azd) příkaz k zajištění služby správy API, funkční aplikace (s kódem) a všech dalších potřebných Azure zdrojů

    ```shell
    azd up
    ```

    Tento příkaz by měl nasadit všechny cloudové zdroje na Azure

### Testování vašeho serveru s MCP Inspektorem

1. V **novém terminálovém okně** nainstalujte a spusťte MCP Inspektor

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Měli byste vidět rozhraní podobné:

    ![Připojení k Node inspektoru](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.cs.png)

1. CTRL klikněte pro načtení webové aplikace MCP Inspektor z URL zobrazené aplikací (např. http://127.0.0.1:6274/#resources)
1. Nastavte typ přenosu na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` a **Připojit**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Seznam Nástrojů**. Klikněte na nástroj a **Spusťte Nástroj**.  

Pokud všechny kroky fungovaly, měli byste být nyní připojeni k MCP serveru a měli byste být schopni zavolat nástroj.

## MCP servery pro Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Tento soubor repozitářů je rychlým startovacím šablonou pro vytváření a nasazování vlastních vzdálených MCP (Model Context Protocol) serverů pomocí Azure Functions s Python, C# .NET nebo Node/TypeScript. 

Ukázky poskytují kompletní řešení, které umožňuje vývojářům:

- Vytvářet a spouštět lokálně: Vyvíjet a ladit MCP server na místním stroji
- Nasazovat na Azure: Snadno nasadit do cloudu pomocí jednoduchého příkazu azd up
- Připojovat se z klientů: Připojit se k MCP serveru z různých klientů včetně VS Code's Copilot agent módu a nástroje MCP Inspektor

### Klíčové Funkce:

- Bezpečnost podle návrhu: MCP server je zabezpečen pomocí klíčů a HTTPS
- Možnosti autentizace: Podporuje OAuth pomocí vestavěné autentizace a/nebo správy API
- Izolace sítě: Umožňuje izolaci sítě pomocí Azure Virtual Networks (VNET)
- Bezserverová architektura: Využívá Azure Functions pro škálovatelné, událostmi řízené provedení
- Lokální vývoj: Komplexní podpora pro lokální vývoj a ladění
- Jednoduché nasazení: Zjednodušený proces nasazení na Azure

Repozitář obsahuje všechny potřebné konfigurační soubory, zdrojový kód a definice infrastruktury, které umožňují rychlý start s produkčně připravenou implementací MCP serveru.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Ukázková implementace MCP pomocí Azure Functions s Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Ukázková implementace MCP pomocí Azure Functions s C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Ukázková implementace MCP pomocí Azure Functions s Node/TypeScript.

## Klíčové Závěry

- MCP SDK poskytují jazykově specifické nástroje pro implementaci robustních MCP řešení
- Proces ladění a testování je kritický pro spolehlivé MCP aplikace
- Opakovaně použitelné šablony výzev umožňují konzistentní interakce AI
- Dobře navržené pracovní postupy mohou orchestraci složitých úkolů pomocí více nástrojů
- Implementace MCP řešení vyžaduje zohlednění bezpečnosti, výkonu a zpracování chyb

## Cvičení

Navrhněte praktický MCP pracovní postup, který řeší reálný problém ve vašem oboru:

1. Identifikujte 3-4 nástroje, které by byly užitečné pro řešení tohoto problému
2. Vytvořte diagram pracovního postupu ukazující, jak tyto nástroje spolupracují
3. Implementujte základní verzi jednoho z nástrojů pomocí vámi preferovaného jazyka
4. Vytvořte šablonu výzvy, která by pomohla modelu efektivně využít váš nástroj

## Další Zdroje

---

Další: [Pokročilá Témata](../05-AdvancedTopics/README.md)

**Upozornění**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nezodpovídáme za žádná nedorozumění nebo chybné interpretace vyplývající z použití tohoto překladu.