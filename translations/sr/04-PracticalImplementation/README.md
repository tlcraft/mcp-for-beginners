<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:28:53+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sr"
}
-->
# Praktična Implementacija

Praktična implementacija je mesto gde moć Model Context Protocol (MCP) postaje opipljiva. Iako je važno razumeti teoriju i arhitekturu iza MCP-a, prava vrednost se pojavljuje kada ove koncepte primenite u izgradnji, testiranju i implementaciji rešenja koja rešavaju stvarne probleme. Ovo poglavlje premošćava jaz između konceptualnog znanja i praktičnog razvoja, vodeći vas kroz proces stvaranja aplikacija zasnovanih na MCP-u.

Bilo da razvijate inteligentne asistente, integrišete AI u poslovne tokove rada ili pravite prilagođene alate za obradu podataka, MCP pruža fleksibilnu osnovu. Njegov dizajn nezavisan od programskog jezika i zvanični SDK-ovi za popularne programske jezike čine ga pristupačnim širokom spektru programera. Korišćenjem ovih SDK-ova, možete brzo praviti prototipove, iterirati i skalirati svoja rešenja na različitim platformama i okruženjima.

U narednim odeljcima pronaći ćete praktične primere, uzorke koda i strategije implementacije koje pokazuju kako koristiti MCP u C#, Java, TypeScript, JavaScript i Python jezicima. Takođe ćete naučiti kako da otklanjate greške i testirate MCP servere, upravljate API-jima i implementirate rešenja u oblaku koristeći Azure. Ovi praktični resursi su osmišljeni da ubrzaju vaše učenje i pomognu vam da sa sigurnošću izgradite robusne MCP aplikacije spremne za produkciju.

## Pregled

Ova lekcija se fokusira na praktične aspekte implementacije MCP-a u više programskih jezika. Istražićemo kako koristiti MCP SDK-ove u C#, Java, TypeScript, JavaScript i Python za pravljenje stabilnih aplikacija, otklanjanje grešaka i testiranje MCP servera, kao i kreiranje ponovo upotrebljivih resursa, promptova i alata.

## Ciljevi učenja

Na kraju ove lekcije moći ćete da:
- Implementirate MCP rešenja koristeći zvanične SDK-ove u različitim programskim jezicima
- Sistematski otklanjate greške i testirate MCP servere
- Kreirate i koristite funkcionalnosti servera (Resurse, Prompte i Alate)
- Dizajnirate efikasne MCP tokove rada za složene zadatke
- Optimizujete MCP implementacije za performanse i pouzdanost

## Zvanični SDK resursi

Model Context Protocol nudi zvanične SDK-ove za više jezika:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Rad sa MCP SDK-ovima

Ovaj odeljak pruža praktične primere implementacije MCP-a u više programskih jezika. Možete pronaći uzorke koda u direktorijumu `samples` organizovane po jezicima.

### Dostupni primeri

Repozitorijum uključuje uzorke implementacija u sledećim jezicima:

- C#
- Java
- TypeScript
- JavaScript
- Python

Svaki primer prikazuje ključne MCP koncepte i obrasce implementacije za određeni jezik i ekosistem.

## Osnovne funkcije servera

MCP serveri mogu implementirati bilo koju kombinaciju sledećih funkcija:

### Resursi
Resursi obezbeđuju kontekst i podatke koje korisnik ili AI model koristi:
- Repozitorijumi dokumenata
- Baze znanja
- Struktuirani izvori podataka
- Fajl sistemi

### Prompti
Prompti su šabloni poruka i tokova rada za korisnike:
- Unapred definisani šabloni konverzacije
- Vođeni obrasci interakcije
- Specijalizovane strukture dijaloga

### Alati
Alati su funkcije koje AI model može izvršavati:
- Alati za obradu podataka
- Integracije sa eksternim API-jima
- Računske mogućnosti
- Funkcionalnost pretrage

## Primeri implementacija: C#

Zvanični C# SDK repozitorijum sadrži nekoliko primera implementacija koji prikazuju različite aspekte MCP-a:

- **Osnovni MCP Klijent**: Jednostavan primer kako kreirati MCP klijenta i pozivati alate
- **Osnovni MCP Server**: Minimalna implementacija servera sa osnovnom registracijom alata
- **Napredni MCP Server**: Potpuni server sa registracijom alata, autentifikacijom i rukovanjem greškama
- **Integracija sa ASP.NET**: Primeri integracije sa ASP.NET Core
- **Obrasci implementacije alata**: Različiti obrasci za implementaciju alata sa različitim nivoima složenosti

MCP C# SDK je u fazi pregleda i API-ji se mogu menjati. Ovaj blog će se kontinuirano ažurirati kako SDK bude evoluirao.

### Ključne funkcije 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Izgradnja vašeg [prvog MCP Servera](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Za kompletne C# primere implementacije, posetite [zvanični repozitorijum C# SDK primera](https://github.com/modelcontextprotocol/csharp-sdk)

## Primer implementacije: Java implementacija

Java SDK nudi robusne opcije za implementaciju MCP-a sa funkcijama na nivou preduzeća.

### Ključne funkcije

- Integracija sa Spring Framework-om
- Snažna tip-sigurnost
- Podrška za reaktivno programiranje
- Sveobuhvatno rukovanje greškama

Za kompletan primer Java implementacije pogledajte [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) u samples direktorijumu.

## Primer implementacije: JavaScript implementacija

JavaScript SDK pruža lagan i fleksibilan pristup implementaciji MCP-a.

### Ključne funkcije

- Podrška za Node.js i browser
- API zasnovan na Promise-ima
- Jednostavna integracija sa Express i drugim framework-ovima
- Podrška za WebSocket za streaming

Za kompletan primer JavaScript implementacije pogledajte [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) u samples direktorijumu.

## Primer implementacije: Python implementacija

Python SDK nudi pitonički pristup implementaciji MCP-a sa odličnom integracijom ML framework-a.

### Ključne funkcije

- Podrška za async/await sa asyncio
- Integracija sa Flask i FastAPI
- Jednostavna registracija alata
- Nativna integracija sa popularnim ML bibliotekama

Za kompletan primer Python implementacije pogledajte [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) u samples direktorijumu.

## Upravljanje API-jima

Azure API Management je odličan odgovor na pitanje kako obezbediti MCP servere. Ideja je da se postavi Azure API Management instanca ispred vašeg MCP servera i da ona upravlja funkcijama koje će vam verovatno trebati kao što su:

- ograničavanje brzine zahteva
- upravljanje tokenima
- nadzor
- balansiranje opterećenja
- bezbednost

### Azure primer

Evo jednog Azure primera koji radi upravo to, tj. [kreira MCP Server i obezbeđuje ga Azure API Management-om](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Pogledajte kako autorizacioni tok funkcioniše na slici ispod:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na prethodnoj slici se dešava sledeće:

- Autentifikacija/Autorizacija se vrši korišćenjem Microsoft Entra.
- Azure API Management funkcioniše kao gateway i koristi politike za usmeravanje i upravljanje saobraćajem.
- Azure Monitor beleži sve zahteve za dalju analizu.

#### Tok autorizacije

Pogledajmo detaljnije tok autorizacije:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP specifikacija autorizacije

Saznajte više o [MCP Authorization specifikaciji](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implementacija Remote MCP Servera na Azure

Hajde da vidimo da li možemo da implementiramo primer koji smo ranije pomenuli:

1. Klonirajte repozitorijum

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Registrujte `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` i nakon nekog vremena proverite da li je registracija završena.

3. Pokrenite ovu [azd](https://aka.ms/azd) komandu da obezbedite api management servis, funkcijsku aplikaciju (sa kodom) i sve ostale potrebne Azure resurse

    ```shell
    azd up
    ```

    Ova komanda treba da implementira sve cloud resurse na Azure-u

### Testiranje vašeg servera sa MCP Inspector

1. U **novom terminal prozoru**, instalirajte i pokrenite MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Trebalo bi da vidite interfejs sličan ovom:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sr.png) 

2. CTRL kliknite da učitate MCP Inspector web aplikaciju sa URL-a koji aplikacija prikazuje (npr. http://127.0.0.1:6274/#resources)
3. Postavite tip transporta na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` i **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Lista alata**. Kliknite na neki alat i **Run Tool**.  

Ako su svi koraci prošli uspešno, sada ste povezani sa MCP serverom i uspeli ste da pozovete alat.

## MCP serveri za Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ovaj skup repozitorijuma je početni šablon za izgradnju i implementaciju prilagođenih udaljenih MCP (Model Context Protocol) servera koristeći Azure Functions sa Python, C# .NET ili Node/TypeScript.

Primeri pružaju kompletno rešenje koje omogućava programerima da:

- Razvijaju i pokreću lokalno: razvijajte i otklanjajte greške MCP servera na lokalnoj mašini
- Implementiraju na Azure: lako implementirajte u oblak sa jednostavnom azd up komandom
- Povezuju se sa klijentima: povežite se sa MCP serverom sa različitih klijenata uključujući VS Code-ov Copilot agent mod i MCP Inspector alat

### Ključne funkcije:

- Bezbednost po dizajnu: MCP server je zaštićen korišćenjem ključeva i HTTPS-a
- Opcije autentifikacije: podrška za OAuth koristeći ugrađenu autentifikaciju i/ili API Management
- Izolacija mreže: omogućava mrežnu izolaciju koristeći Azure Virtual Networks (VNET)
- Serverless arhitektura: koristi Azure Functions za skalabilno, događajima pokretano izvršavanje
- Lokalni razvoj: sveobuhvatna podrška za lokalni razvoj i otklanjanje grešaka
- Jednostavna implementacija: pojednostavljen proces implementacije na Azure

Repozitorijum uključuje sve neophodne konfiguracione fajlove, izvorni kod i definicije infrastrukture za brzo započinjanje sa MCP serverom spremnim za produkciju.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Primer implementacije MCP koristeći Azure Functions sa Python-om

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Primer implementacije MCP koristeći Azure Functions sa C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Primer implementacije MCP koristeći Azure Functions sa Node/TypeScript.

## Ključni zaključci

- MCP SDK-ovi pružaju alate specifične za jezik za implementaciju robusnih MCP rešenja
- Proces otklanjanja grešaka i testiranja je ključan za pouzdane MCP aplikacije
- Ponovo upotrebljivi šabloni promptova omogućavaju dosledne AI interakcije
- Dobro dizajnirani tokovi rada mogu orkestrirati složene zadatke koristeći više alata
- Implementacija MCP rešenja zahteva razmatranje bezbednosti, performansi i rukovanja greškama

## Vežba

Dizajnirajte praktičan MCP tok rada koji rešava stvarni problem u vašoj oblasti:

1. Identifikujte 3-4 alata koji bi bili korisni za rešavanje ovog problema
2. Napravite dijagram toka rada koji prikazuje kako ovi alati međusobno komuniciraju
3. Implementirajte osnovnu verziju jednog od alata koristeći jezik koji preferirate
4. Kreirajte šablon prompta koji bi pomogao modelu da efikasno koristi vaš alat

## Dodatni resursi


---

Sledeće: [Napredne teme](../05-AdvancedTopics/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, имајте у виду да аутоматизовани преводи могу садржати грешке или нетачности. Изворни документ на његовом оригиналном језику треба сматрати ауторитетом. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења настала коришћењем овог превода.