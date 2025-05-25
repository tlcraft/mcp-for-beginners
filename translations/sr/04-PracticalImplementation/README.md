<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T14:02:59+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sr"
}
-->
# Praktična Implementacija

Praktična implementacija je mesto gde snaga Model Context Protocol (MCP) postaje opipljiva. Dok je razumevanje teorije i arhitekture iza MCP-a važno, prava vrednost se pojavljuje kada primenite ove koncepte da biste izgradili, testirali i primenili rešenja koja rešavaju stvarne probleme. Ovo poglavlje povezuje jaz između konceptualnog znanja i praktičnog razvoja, vodeći vas kroz proces oživljavanja aplikacija zasnovanih na MCP-u.

Bilo da razvijate inteligentne asistente, integrišete AI u poslovne tokove ili gradite prilagođene alate za obradu podataka, MCP pruža fleksibilnu osnovu. Njegov dizajn nezavisan od jezika i zvanični SDK-ovi za popularne programske jezike čine ga dostupnim širokom spektru programera. Koristeći ove SDK-ove, možete brzo prototipirati, iterirati i skalirati svoja rešenja na različitim platformama i okruženjima.

U narednim odeljcima, pronaći ćete praktične primere, uzorke koda i strategije za primenu koje pokazuju kako implementirati MCP u C#, Java, TypeScript, JavaScript i Python. Takođe ćete naučiti kako da debagujete i testirate vaše MCP servere, upravljate API-jevima, i primenite rešenja u oblaku koristeći Azure. Ovi praktični resursi su dizajnirani da ubrzaju vaše učenje i pomognu vam da sa sigurnošću izgradite robusne, spremne za proizvodnju MCP aplikacije.

## Pregled

Ova lekcija se fokusira na praktične aspekte implementacije MCP-a u više programskih jezika. Istražićemo kako koristiti MCP SDK-ove u C#, Java, TypeScript, JavaScript i Python za izgradnju robusnih aplikacija, debagovanje i testiranje MCP servera, i kreiranje resursa, upita i alata koji se mogu ponovo koristiti.

## Ciljevi Učenja

Do kraja ove lekcije, bićete u stanju da:
- Implementirate MCP rešenja koristeći zvanične SDK-ove u različitim programskim jezicima
- Sistematski debagujete i testirate MCP servere
- Kreirate i koristite funkcije servera (Resursi, Upiti i Alati)
- Dizajnirate efikasne MCP tokove za složene zadatke
- Optimizujete MCP implementacije za performanse i pouzdanost

## Zvanični SDK Resursi

Model Context Protocol nudi zvanične SDK-ove za više jezika:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Rad sa MCP SDK-ovima

Ovaj odeljak pruža praktične primere implementacije MCP-a u više programskih jezika. Možete pronaći uzorke koda u direktorijumu `samples` organizovane po jeziku.

### Dostupni Uzorci

Repozitorijum uključuje uzorke implementacije u sledećim jezicima:

- C#
- Java
- TypeScript
- JavaScript
- Python

Svaki uzorak demonstrira ključne MCP koncepte i obrasce implementacije za taj specifični jezik i ekosistem.

## Osnovne Funkcije Servera

MCP serveri mogu implementirati bilo koju kombinaciju ovih funkcija:

### Resursi
Resursi pružaju kontekst i podatke koje korisnik ili AI model mogu koristiti:
- Repozitorijumi dokumenata
- Baze znanja
- Strukturirani izvori podataka
- Sistemi fajlova

### Upiti
Upiti su templirane poruke i tokovi za korisnike:
- Preddefinisani šabloni razgovora
- Vođeni obrasci interakcije
- Specijalizovane strukture dijaloga

### Alati
Alati su funkcije koje AI model može izvršiti:
- Alati za obradu podataka
- Integracije sa spoljnim API-jevima
- Računske sposobnosti
- Funkcionalnost pretrage

## Uzorci Implementacije: C#

Zvanični C# SDK repozitorijum sadrži nekoliko uzoraka implementacije koji pokazuju različite aspekte MCP-a:

- **Osnovni MCP Klijent**: Jednostavan primer kako kreirati MCP klijent i pozvati alate
- **Osnovni MCP Server**: Minimalna implementacija servera sa osnovnom registracijom alata
- **Napredni MCP Server**: Server sa punim funkcijama, registracijom alata, autentifikacijom i obradom grešaka
- **Integracija sa ASP.NET**: Primeri koji pokazuju integraciju sa ASP.NET Core
- **Obrasci Implementacije Alata**: Različiti obrasci za implementaciju alata sa različitim nivoima složenosti

C# MCP SDK je u fazi pregleda i API-ji se mogu menjati. Nastavićemo da ažuriramo ovaj blog kako se SDK razvija.

### Ključne Funkcije 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Izgradnja vašeg [prvog MCP Servera](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Za kompletne uzorke implementacije u C#, posetite [zvanični C# SDK uzorci repozitorijum](https://github.com/modelcontextprotocol/csharp-sdk)

## Uzorak Implementacije: Java Implementacija

Java SDK nudi robusne opcije za MCP implementaciju sa funkcijama na nivou preduzeća.

### Ključne Funkcije

- Integracija sa Spring Framework
- Jaka tipizacija
- Podrška za reaktivno programiranje
- Sveobuhvatna obrada grešaka

Za kompletan uzorak implementacije u Java, pogledajte [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) u direktorijumu uzoraka.

## Uzorak Implementacije: JavaScript Implementacija

JavaScript SDK pruža lagan i fleksibilan pristup MCP implementaciji.

### Ključne Funkcije

- Podrška za Node.js i pretraživač
- API zasnovan na obećanjima
- Laka integracija sa Express i drugim okvirima
- Podrška za WebSocket za streaming

Za kompletan uzorak implementacije u JavaScript, pogledajte [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) u direktorijumu uzoraka.

## Uzorak Implementacije: Python Implementacija

Python SDK nudi Pythonic pristup MCP implementaciji sa odličnim integracijama ML okvira.

### Ključne Funkcije

- Podrška za async/await sa asyncio
- Integracija sa Flask i FastAPI
- Jednostavna registracija alata
- Nativna integracija sa popularnim ML bibliotekama

Za kompletan uzorak implementacije u Python, pogledajte [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) u direktorijumu uzoraka.

## Upravljanje API-jima 

Azure API Management je odličan odgovor na pitanje kako možemo osigurati MCP servere. Ideja je postaviti instancu Azure API Management ispred vašeg MCP servera i dozvoliti joj da upravlja funkcijama koje verovatno želite kao što su:

- ograničavanje brzine
- upravljanje tokenima
- monitoring
- balansiranje opterećenja
- sigurnost

### Azure Uzorak

Evo Azure Uzorka koji upravo to radi, tj. [kreira MCP Server i osigurava ga sa Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Pogledajte kako se odvija tok autorizacije na slici ispod:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na prethodnoj slici, dešava se sledeće:

- Autentifikacija/Autorizacija se odvija koristeći Microsoft Entra.
- Azure API Management deluje kao prolaz i koristi politike za usmeravanje i upravljanje saobraćajem.
- Azure Monitor beleži sve zahteve za dalju analizu.

#### Tok autorizacije

Pogledajmo tok autorizacije detaljnije:

![Dijagram Sekvenci](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP specifikacija autorizacije

Saznajte više o [MCP specifikaciji autorizacije](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Primena Daljinskog MCP Servera na Azure

Pogledajmo da li možemo primeniti uzorak koji smo ranije spomenuli:

1. Klonirajte repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registrujte `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` nakon nekog vremena da proverite da li je registracija završena.

2. Pokrenite ovu [azd](https://aka.ms/azd) komandu da biste obezbedili servis za upravljanje API-jem, funkcijsku aplikaciju (sa kodom) i sve druge potrebne Azure resurse

    ```shell
    azd up
    ```

    Ova komanda bi trebalo da primeni sve resurse u oblaku na Azure

### Testiranje vašeg servera sa MCP Inspector

1. U **novom terminal prozoru**, instalirajte i pokrenite MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Trebalo bi da vidite interfejs sličan:

    ![Povezivanje sa Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.sr.png)

1. CTRL kliknite da učitate MCP Inspector web aplikaciju sa URL-a koji je prikazan od strane aplikacije (npr. http://127.0.0.1:6274/#resources)
1. Postavite tip transporta na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` i **Povežite**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Lista Alata**. Kliknite na alat i **Pokrenite Alat**.  

Ako su svi koraci uspeli, sada biste trebali biti povezani sa MCP serverom i mogli ste da pozovete alat.

## MCP serveri za Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ovaj set repozitorijuma su brzi početni šabloni za izgradnju i primenu prilagođenih daljinskih MCP (Model Context Protocol) servera koristeći Azure Functions sa Python, C# .NET ili Node/TypeScript. 

Uzorci pružaju kompletno rešenje koje omogućava programerima da:

- Izgrade i pokrenu lokalno: Razvijaju i debaguju MCP server na lokalnom računaru
- Primene na Azure: Lako primene na oblak sa jednostavnom azd up komandom
- Povežu se sa klijentima: Povežu se sa MCP serverom iz različitih klijenata uključujući VS Code-ov Copilot agent mode i MCP Inspector alat

### Ključne Funkcije:

- Sigurnost po dizajnu: MCP server je osiguran koristeći ključeve i HTTPS
- Opcije autentifikacije: Podržava OAuth koristeći ugrađenu autentifikaciju i/ili upravljanje API-jem
- Izolacija mreže: Omogućava izolaciju mreže koristeći Azure Virtual Networks (VNET)
- Arhitektura bez servera: Koristi Azure Functions za skalabilno, događajno pokretanje
- Lokalni razvoj: Sveobuhvatna podrška za lokalni razvoj i debagovanje
- Jednostavna primena: Ubrzan proces primene na Azure

Repozitorijum uključuje sve potrebne konfiguracione fajlove, izvorni kod i definicije infrastrukture da brzo započnete sa proizvodnom implementacijom MCP servera.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Uzorak implementacije MCP koristeći Azure Functions sa Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Uzorak implementacije MCP koristeći Azure Functions sa C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Uzorak implementacije MCP koristeći Azure Functions sa Node/TypeScript.

## Ključni Zaključci

- MCP SDK-ovi pružaju alate specifične za jezik za implementaciju robusnih MCP rešenja
- Proces debagovanja i testiranja je kritičan za pouzdane MCP aplikacije
- Templati upita koji se mogu ponovo koristiti omogućavaju dosledne AI interakcije
- Dobro dizajnirani tokovi mogu orkestrirati složene zadatke koristeći više alata
- Implementacija MCP rešenja zahteva razmatranje sigurnosti, performansi i obrade grešaka

## Vežba

Dizajnirajte praktičan MCP tok koji rešava stvarni problem u vašem domenu:

1. Identifikujte 3-4 alata koji bi bili korisni za rešavanje ovog problema
2. Kreirajte dijagram toka koji prikazuje kako ovi alati međusobno deluju
3. Implementirajte osnovnu verziju jednog od alata koristeći vaš preferirani jezik
4. Kreirajte šablon upita koji bi pomogao modelu da efikasno koristi vaš alat

## Dodatni Resursi

---

Sledeće: [Napredne Teme](../05-AdvancedTopics/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо ка тачности, имајте у виду да аутоматизовани преводи могу садржати грешке или нетачности. Оригинални документ на свом изворном језику треба сматрати меродавним извором. За критичне информације, препоручује се професионални превод од стране људи. Не сносимо одговорност за било какве неспоразуме или погрешна тумачења која произилазе из коришћења овог превода.