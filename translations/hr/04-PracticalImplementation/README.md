<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T14:03:32+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hr"
}
-->
# Praktična Implementacija

Praktična implementacija je mjesto gdje snaga Model Context Protocola (MCP) postaje opipljiva. Iako je važno razumjeti teoriju i arhitekturu MCP-a, prava vrijednost dolazi kada primijenite te koncepte za izgradnju, testiranje i implementaciju rješenja koja rješavaju stvarne probleme. Ovo poglavlje povezuje konceptualno znanje s praktičnim razvojem, vodeći vas kroz proces oživljavanja aplikacija temeljenih na MCP-u.

Bez obzira razvijate li inteligentne asistente, integrirate AI u poslovne procese ili gradite prilagođene alate za obradu podataka, MCP pruža fleksibilnu osnovu. Njegov dizajn neovisan o jeziku i službeni SDK-ovi za popularne programske jezike čine ga dostupnim širokom krugu programera. Korištenjem ovih SDK-ova, možete brzo prototipirati, iterirati i skalirati svoja rješenja na različitim platformama i okruženjima.

U sljedećim odjeljcima pronaći ćete praktične primjere, uzorke koda i strategije implementacije koje pokazuju kako implementirati MCP u C#, Java, TypeScript, JavaScript i Python. Također ćete naučiti kako ispravljati pogreške i testirati svoje MCP servere, upravljati API-ima i implementirati rješenja u oblaku koristeći Azure. Ovi praktični resursi dizajnirani su da ubrzaju vaše učenje i pomognu vam da s povjerenjem izgradite robusne, za proizvodnju spremne MCP aplikacije.

## Pregled

Ova lekcija fokusira se na praktične aspekte implementacije MCP-a u više programskih jezika. Istražit ćemo kako koristiti MCP SDK-ove u C#, Java, TypeScript, JavaScript i Python za izgradnju robusnih aplikacija, ispravljanje pogrešaka i testiranje MCP servera te stvaranje ponovljivih resursa, upita i alata.

## Ciljevi Učenja

Na kraju ove lekcije, moći ćete:
- Implementirati MCP rješenja koristeći službene SDK-ove u raznim programskim jezicima
- Sustavno ispravljati pogreške i testirati MCP servere
- Stvarati i koristiti značajke servera (Resurse, Upite i Alate)
- Dizajnirati učinkovite MCP tijekove rada za složene zadatke
- Optimizirati MCP implementacije za performanse i pouzdanost

## Službeni SDK Resursi

Model Context Protocol nudi službene SDK-ove za više jezika:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Rad s MCP SDK-ovima

Ovaj odjeljak pruža praktične primjere implementacije MCP-a u više programskih jezika. Možete pronaći uzorke koda u direktoriju `samples` organiziranom prema jeziku.

### Dostupni Uzorci

Repozitorij uključuje uzorke implementacija na sljedećim jezicima:

- C#
- Java
- TypeScript
- JavaScript
- Python

Svaki uzorak prikazuje ključne MCP koncepte i obrasce implementacije za taj specifični jezik i ekosustav.

## Osnovne Značajke Servera

MCP serveri mogu implementirati bilo koju kombinaciju ovih značajki:

### Resursi
Resursi pružaju kontekst i podatke za korisnika ili AI model za korištenje:
- Repozitoriji dokumenata
- Baze znanja
- Strukturirani izvori podataka
- Datotečni sustavi

### Upiti
Upiti su predlošci poruka i tijekovi rada za korisnike:
- Unaprijed definirani predlošci razgovora
- Vođeni obrasci interakcije
- Specijalizirane strukture dijaloga

### Alati
Alati su funkcije koje AI model izvršava:
- Alati za obradu podataka
- Integracije s vanjskim API-jima
- Računalne sposobnosti
- Funkcionalnost pretraživanja

## Uzorci Implementacije: C#

Službeni C# SDK repozitorij sadrži nekoliko uzoraka implementacije koji demonstriraju različite aspekte MCP-a:

- **Osnovni MCP Klijent**: Jednostavan primjer koji prikazuje kako stvoriti MCP klijenta i pozvati alate
- **Osnovni MCP Server**: Minimalna implementacija servera s osnovnom registracijom alata
- **Napredni MCP Server**: Server s punim značajkama s registracijom alata, autentifikacijom i rukovanjem greškama
- **Integracija s ASP.NET**: Primjeri koji pokazuju integraciju s ASP.NET Core
- **Obrasci Implementacije Alata**: Različiti obrasci za implementaciju alata s različitim razinama složenosti

C# MCP SDK je u fazi pregleda i API-ji se mogu mijenjati. Neprestano ćemo ažurirati ovaj blog kako SDK bude evoluirao.

### Ključne Značajke 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Izgradnja vašeg [prvog MCP Servera](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Za potpune uzorke implementacije u C#, posjetite [službeni C# SDK repozitorij uzoraka](https://github.com/modelcontextprotocol/csharp-sdk)

## Uzorak Implementacije: Java Implementacija

Java SDK nudi robusne opcije implementacije MCP-a s značajkama na razini poduzeća.

### Ključne Značajke

- Integracija s Spring Frameworkom
- Snažna sigurnost tipova
- Podrška za reaktivno programiranje
- Sveobuhvatno rukovanje greškama

Za potpuni uzorak implementacije u Javi, pogledajte [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) u direktoriju uzoraka.

## Uzorak Implementacije: JavaScript Implementacija

JavaScript SDK pruža lagan i fleksibilan pristup implementaciji MCP-a.

### Ključne Značajke

- Podrška za Node.js i preglednik
- API temeljen na obećanjima
- Jednostavna integracija s Expressom i drugim okvirima
- Podrška za WebSocket za streaming

Za potpuni uzorak implementacije u JavaScriptu, pogledajte [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) u direktoriju uzoraka.

## Uzorak Implementacije: Python Implementacija

Python SDK nudi Python pristup implementaciji MCP-a s izvrsnim integracijama ML okvira.

### Ključne Značajke

- Podrška za async/await s asyncio
- Integracija s Flaskom i FastAPI-jem
- Jednostavna registracija alata
- Izvorna integracija s popularnim ML knjižnicama

Za potpuni uzorak implementacije u Pythonu, pogledajte [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) u direktoriju uzoraka.

## Upravljanje API-jem 

Azure API Management je izvrsno rješenje za osiguranje MCP servera. Ideja je postaviti instancu Azure API Management ispred vašeg MCP servera i omogućiti joj rukovanje značajkama koje ćete vjerojatno željeti kao što su:

- ograničavanje brzine
- upravljanje tokenima
- nadzor
- ravnoteža opterećenja
- sigurnost

### Azure Uzorak

Evo Azure uzorka koji radi upravo to, tj. [stvara MCP Server i osigurava ga pomoću Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Pogledajte kako se odvija tijek autorizacije na donjoj slici:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na prethodnoj slici događa se sljedeće:

- Autentifikacija/Autorizacija se odvija pomoću Microsoft Entra.
- Azure API Management djeluje kao gateway i koristi politike za usmjeravanje i upravljanje prometom.
- Azure Monitor bilježi sve zahtjeve za daljnju analizu.

#### Tijek autorizacije

Pogledajmo detaljnije tijek autorizacije:

![Sekvencijski Dijagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP specifikacija autorizacije

Saznajte više o [MCP specifikaciji autorizacije](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implementacija Remote MCP Servera na Azure

Pogledajmo možemo li implementirati uzorak koji smo ranije spomenuli:

1. Klonirajte repozitorij

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registrirajte `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` nakon nekog vremena kako biste provjerili je li registracija dovršena.

2. Pokrenite ovu [azd](https://aka.ms/azd) naredbu za postavljanje usluge upravljanja API-jem, funkcijske aplikacije (s kodom) i svih ostalih potrebnih Azure resursa

    ```shell
    azd up
    ```

    Ova naredba bi trebala implementirati sve cloud resurse na Azure

### Testiranje vašeg servera s MCP Inspectorom

1. U **novom prozoru terminala**, instalirajte i pokrenite MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Trebali biste vidjeti sučelje slično:

    ![Povezivanje s Node inspectorom](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.hr.png)

1. CTRL kliknite za učitavanje MCP Inspector web aplikacije s URL-a prikazanog od strane aplikacije (npr. http://127.0.0.1:6274/#resources)
1. Postavite vrstu transporta na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` i **Povežite se**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Popis Alata**. Kliknite na alat i **Pokreni Alat**.  

Ako su svi koraci uspješno izvedeni, sada biste trebali biti povezani s MCP serverom i mogli ste pozvati alat.

## MCP serveri za Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ovaj set repozitorija su predlošci za brzi početak izgradnje i implementacije prilagođenih udaljenih MCP (Model Context Protocol) servera koristeći Azure Functions s Python, C# .NET ili Node/TypeScript. 

Uzorci pružaju cjelovito rješenje koje omogućuje programerima da:

- Izgrade i pokrenu lokalno: Razviju i ispravljaju MCP server na lokalnom računalu
- Implementiraju na Azure: Jednostavno implementiraju na oblak jednostavnom azd up naredbom
- Povežu se s klijentima: Povežu se s MCP serverom iz raznih klijenata uključujući VS Code-ov Copilot agent način i MCP Inspector alat

### Ključne Značajke:

- Sigurnost po dizajnu: MCP server je osiguran korištenjem ključeva i HTTPS-a
- Opcije autentifikacije: Podržava OAuth koristeći ugrađenu autentifikaciju i/ili upravljanje API-jem
- Izolacija mreže: Omogućuje izolaciju mreže korištenjem Azure Virtual Networks (VNET)
- Serverless arhitektura: Koristi Azure Functions za skalabilno, događajima vođeno izvršavanje
- Lokalni razvoj: Sveobuhvatna podrška za lokalni razvoj i ispravljanje pogrešaka
- Jednostavna implementacija: Pojednostavljen proces implementacije na Azure

Repozitorij uključuje sve potrebne konfiguracijske datoteke, izvorni kod i definicije infrastrukture za brzi početak s proizvodno spremnom implementacijom MCP servera.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Uzorak implementacije MCP-a koristeći Azure Functions s Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Uzorak implementacije MCP-a koristeći Azure Functions s C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Uzorak implementacije MCP-a koristeći Azure Functions s Node/TypeScript.

## Ključne Točke

- MCP SDK-ovi pružaju alate specifične za jezik za implementaciju robusnih MCP rješenja
- Proces ispravljanja pogrešaka i testiranja ključan je za pouzdane MCP aplikacije
- Ponovno upotrebljivi predlošci upita omogućuju dosljedne AI interakcije
- Dobro dizajnirani tijekovi rada mogu orkestrirati složene zadatke koristeći više alata
- Implementacija MCP rješenja zahtijeva razmatranje sigurnosti, performansi i rukovanja greškama

## Vježba

Dizajnirajte praktičan MCP tijek rada koji rješava stvarni problem u vašem području:

1. Identificirajte 3-4 alata koja bi bila korisna za rješavanje ovog problema
2. Kreirajte dijagram tijeka rada koji prikazuje kako ti alati međusobno djeluju
3. Implementirajte osnovnu verziju jednog od alata koristeći svoj preferirani jezik
4. Kreirajte predložak upita koji bi pomogao modelu da učinkovito koristi vaš alat

## Dodatni Resursi

---

Sljedeće: [Napredne Teme](../05-AdvancedTopics/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako se trudimo osigurati točnost, imajte na umu da automatizirani prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati mjerodavnim izvorom. Za kritične informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne odgovaramo za nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.