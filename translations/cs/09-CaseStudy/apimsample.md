<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:36:23+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "cs"
}
-->
# Případová studie: Zpřístupnění REST API v API Management jako MCP server

Azure API Management je služba, která poskytuje bránu nad vašimi API koncovými body. Funguje tak, že Azure API Management působí jako proxy před vašimi API a rozhoduje, co dělat s příchozími požadavky.

Použitím této služby získáte celou řadu funkcí, jako například:

- **Bezpečnost**, můžete využít vše od API klíčů, JWT až po spravovanou identitu.
- **Omezení počtu požadavků (rate limiting)**, skvělá funkce, která vám umožní rozhodnout, kolik volání projde za určitou časovou jednotku. To pomáhá zajistit, že všichni uživatelé mají skvělý zážitek a zároveň, že vaše služba není přetížena požadavky.
- **Škálování a vyvažování zátěže**. Můžete nastavit několik koncových bodů pro rozložení zátěže a také rozhodnout, jakým způsobem bude vyvažování probíhat.
- **AI funkce jako sémantické cachování**, limit tokenů, monitorování tokenů a další. Tyto funkce zlepšují odezvu a zároveň vám pomáhají mít přehled o spotřebě tokenů. [Více informací zde](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Proč MCP + Azure API Management?

Model Context Protocol se rychle stává standardem pro agentní AI aplikace a způsob, jak konzistentně zpřístupnit nástroje a data. Azure API Management je přirozenou volbou, když potřebujete „spravovat“ API. MCP servery často integrují další API, aby například vyřešily požadavky na nástroje. Proto dává smysl kombinovat Azure API Management a MCP.

## Přehled

V tomto konkrétním případě se naučíme, jak zpřístupnit API koncové body jako MCP server. Tímto způsobem můžeme snadno začlenit tyto koncové body do agentní aplikace a zároveň využít funkce Azure API Management.

## Klíčové funkce

- Vyberete metody koncového bodu, které chcete zpřístupnit jako nástroje.
- Další funkce závisí na tom, co nakonfigurujete v sekci politik pro vaše API. Zde vám ukážeme, jak přidat omezení počtu požadavků.

## Předběžný krok: import API

Pokud již máte API v Azure API Management, můžete tento krok přeskočit. Pokud ne, podívejte se na tento odkaz: [import API do Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Zveřejnění API jako MCP server

Pro zpřístupnění API koncových bodů postupujte podle těchto kroků:

1. Přejděte do Azure Portalu na adresu <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Přejděte do vaší instance API Management.

1. V levém menu vyberte **APIs > MCP Servers > + Create new MCP Server**.

1. V sekci API vyberte REST API, které chcete zpřístupnit jako MCP server.

1. Vyberte jednu nebo více operací API, které chcete zpřístupnit jako nástroje. Můžete vybrat všechny operace nebo jen konkrétní.

    ![Vyberte metody k zveřejnění](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Klikněte na **Create**.

1. Přejděte do menu **APIs** a **MCP Servers**, kde byste měli vidět následující:

    ![Zobrazení MCP serveru v hlavním panelu](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP server je vytvořen a API operace jsou zpřístupněny jako nástroje. MCP server je uveden v panelu MCP Servers. Sloupec URL ukazuje koncový bod MCP serveru, který můžete volat pro testování nebo v klientské aplikaci.

## Volitelné: Konfigurace zásad

Azure API Management má základní koncept politik, kde nastavujete různá pravidla pro vaše koncové body, například omezení počtu požadavků nebo sémantické cachování. Tyto politiky se píší v XML.

Zde je návod, jak nastavit politiku pro omezení počtu požadavků na MCP server:

1. V portálu, v sekci **APIs**, vyberte **MCP Servers**.

1. Vyberte vytvořený MCP server.

1. V levém menu, v sekci MCP, vyberte **Policies**.

1. V editoru politik přidejte nebo upravte politiky, které chcete aplikovat na nástroje MCP serveru. Politiky jsou definovány v XML formátu. Například můžete přidat politiku, která omezí volání nástrojů MCP serveru (v tomto příkladu 5 volání za 30 sekund na IP adresu klienta). Zde je XML, které toto omezení způsobí:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Zde je obrázek editoru zásad:

    ![Editor politik](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Vyzkoušejte to

Ujistěme se, že náš MCP server funguje podle očekávání.

K tomu použijeme Visual Studio Code a GitHub Copilot v režimu agenta. Přidáme MCP server do souboru *mcp.json*. Tím Visual Studio Code bude fungovat jako klient s agentními schopnostmi a koncoví uživatelé budou moci zadat prompt a komunikovat s tímto serverem.

Jak přidat MCP server ve Visual Studio Code:

1. Použijte příkaz **MCP: Add Server** z Command Palette.

1. Když budete vyzváni, vyberte typ serveru: **HTTP (HTTP nebo Server Sent Events)**.

1. Zadejte URL MCP serveru v API Management. Například: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (pro SSE endpoint) nebo **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (pro MCP endpoint), všimněte si rozdílu v přenosech `/sse` nebo `/mcp`.

1. Zadejte ID serveru podle vlastního výběru. Není to důležitá hodnota, ale pomůže vám si zapamatovat, o jakou instanci serveru jde.

1. Vyberte, zda chcete konfiguraci uložit do nastavení pracovního prostoru nebo uživatelského nastavení.

  - **Nastavení pracovního prostoru** – Konfigurace serveru je uložena do souboru .vscode/mcp.json, který je dostupný pouze v aktuálním pracovním prostoru.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    nebo pokud zvolíte streaming HTTP jako transport, bude to mírně odlišné:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Uživatelské nastavení** – Konfigurace serveru je přidána do vašeho globálního souboru *settings.json* a je dostupná ve všech pracovních prostorech. Konfigurace vypadá podobně jako následující:

    ![Uživatelské nastavení](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Také je potřeba přidat konfiguraci hlavičky, aby se správně autentizovalo vůči Azure API Management. Používá se hlavička s názvem **Ocp-Apim-Subscription-Key**.

    - Zde je postup, jak ji přidat do nastavení:

    ![Přidání hlavičky pro autentizaci](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), tím se zobrazí výzva k zadání hodnoty API klíče, kterou najdete v Azure Portalu pro vaši instanci Azure API Management.

   - Pokud ji chcete přidat do *mcp.json*, můžete ji přidat takto:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Použití režimu Agent

Nyní máme vše nastaveno buď v nastavení, nebo v *.vscode/mcp.json*. Vyzkoušejme to.

Měla by se zobrazit ikona Nástroje, kde jsou vypsány nástroje zpřístupněné z vašeho serveru:

![Nástroje ze serveru](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Klikněte na ikonu nástrojů a měli byste vidět seznam nástrojů, jako je tento:

    ![Nástroje](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Zadejte výzvu do chatu pro vyvolání nástroje. Například pokud jste vybrali nástroj pro získání informací o objednávce, můžete se agenta zeptat na objednávku. Zde je příklad výzvy:

    ```text
    get information from order 2
    ```

    Nyní se vám zobrazí ikona nástrojů s výzvou k pokračování ve volání nástroje. Vyberte pokračovat ve spuštění nástroje, měli byste vidět výstup takto:

    ![Výsledek výzvy](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **To, co vidíte výše, závisí na tom, jaké nástroje jste nastavili, ale myšlenka je, že dostanete textovou odpověď jako výše.**

## Odkazy

Zde se můžete dozvědět více:

- [Návod na Azure API Management a MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python ukázka: Zabezpečení vzdálených MCP serverů pomocí Azure API Management (experimentální)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Laboratoř autorizace MCP klienta](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Použití rozšíření Azure API Management pro VS Code k importu a správě API](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Registrace a objevování vzdálených MCP serverů v Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Skvělý repozitář, který ukazuje mnoho AI funkcí s Azure API Management
- [AI Gateway workshopy](https://azure-samples.github.io/AI-Gateway/) Obsahuje workshopy využívající Azure Portal, což je skvělý způsob, jak začít s hodnocením AI funkcí.

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.