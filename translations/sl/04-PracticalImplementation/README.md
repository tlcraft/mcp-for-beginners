<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:30:44+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sl"
}
-->
# Practical Implementation

Praktična izvedba je trenutek, ko moč Model Context Protocola (MCP) postane otipljiva. Medtem ko je razumevanje teorije in arhitekture MCP pomembno, se prava vrednost pokaže, ko te koncepte uporabite za gradnjo, testiranje in uvajanje rešitev, ki rešujejo resnične probleme. Ta poglavje premošča vrzel med konceptualnim znanjem in praktičnim razvojem ter vas vodi skozi postopek oživljanja aplikacij, ki temeljijo na MCP.

Ne glede na to, ali razvijate inteligentne asistente, integrirate AI v poslovne tokove ali gradite prilagojena orodja za obdelavo podatkov, MCP nudi prilagodljivo osnovo. Njegova jezikovno neodvisna zasnova in uradni SDK-ji za priljubljene programske jezike omogočajo dostop širokemu krogu razvijalcev. Z uporabo teh SDK-jev lahko hitro izdelate prototipe, iterirate in razširite svoje rešitve na različnih platformah in okoljih.

V nadaljevanju boste našli praktične primere, vzorčno kodo in strategije uvajanja, ki prikazujejo, kako implementirati MCP v C#, Javi, TypeScriptu, JavaScriptu in Pythonu. Naučili se boste tudi, kako odpravljati napake in testirati MCP strežnike, upravljati API-je ter uvajati rešitve v oblak z uporabo Azure. Ti praktični viri so zasnovani tako, da pospešijo vaše učenje in vam pomagajo samozavestno zgraditi zanesljive, produkcijsko pripravljene MCP aplikacije.

## Overview

Ta lekcija se osredotoča na praktične vidike implementacije MCP v več programskih jezikih. Raziskali bomo, kako uporabljati MCP SDK-je v C#, Javi, TypeScriptu, JavaScriptu in Pythonu za gradnjo robustnih aplikacij, odpravljanje napak in testiranje MCP strežnikov ter ustvarjanje ponovno uporabnih virov, pozivov in orodij.

## Learning Objectives

Na koncu te lekcije boste znali:
- Implementirati MCP rešitve z uporabo uradnih SDK-jev v različnih programskih jezikih
- Sistematično odpravljati napake in testirati MCP strežnike
- Ustvarjati in uporabljati funkcije strežnika (Resources, Prompts in Tools)
- Načrtovati učinkovite MCP poteke za kompleksne naloge
- Optimizirati MCP implementacije za zmogljivost in zanesljivost

## Official SDK Resources

Model Context Protocol ponuja uradne SDK-je za več jezikov:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Working with MCP SDKs

Ta razdelek ponuja praktične primere implementacije MCP v več programskih jezikih. V mapi `samples` boste našli vzorčno kodo razvrščeno po jezikih.

### Available Samples

V repozitoriju so vzorčne implementacije v naslednjih jezikih:

- C#
- Java
- TypeScript
- JavaScript
- Python

Vsak primer prikazuje ključne koncepte MCP in vzorce implementacije za določen jezik in ekosistem.

## Core Server Features

MCP strežniki lahko implementirajo katerokoli kombinacijo teh funkcij:

### Resources
Resources zagotavljajo kontekst in podatke za uporabnika ali AI model:
- Dokumentni repozitoriji
- Baze znanja
- Strukturirani podatkovni viri
- Datotečni sistemi

### Prompts
Prompts so predloge sporočil in poteki za uporabnike:
- Vnaprej določeni predlogi pogovorov
- Vodeni vzorci interakcij
- Specializirane strukture dialoga

### Tools
Tools so funkcije, ki jih AI model lahko izvede:
- Orodja za obdelavo podatkov
- Integracije z zunanjimi API-ji
- Računske zmožnosti
- Iskalne funkcije

## Sample Implementations: C#

Uradni repozitorij C# SDK vsebuje več vzorčnih implementacij, ki prikazujejo različne vidike MCP:

- **Basic MCP Client**: Enostaven primer, ki prikazuje, kako ustvariti MCP klienta in klicati orodja
- **Basic MCP Server**: Minimalna implementacija strežnika z osnovno registracijo orodij
- **Advanced MCP Server**: Polno funkcionalen strežnik z registracijo orodij, avtentikacijo in obravnavo napak
- **ASP.NET Integration**: Primeri integracije z ASP.NET Core
- **Tool Implementation Patterns**: Različni vzorci za implementacijo orodij z različnimi stopnjami kompleksnosti

MCP C# SDK je v predogledu in API-ji se lahko spremenijo. Ta blog bomo sproti posodabljali, ko se SDK razvija.

### Key Features 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Gradnja vašega [prvega MCP strežnika](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Za popolne C# implementacijske primere obiščite [uradni repozitorij C# SDK vzorcev](https://github.com/modelcontextprotocol/csharp-sdk)

## Sample implementation: Java Implementation

Java SDK ponuja robustne možnosti implementacije MCP z enterprise-grade funkcijami.

### Key Features

- Integracija Spring Frameworka
- Močna tipna varnost
- Podpora reaktivnemu programiranju
- Celovita obravnava napak

Za popoln Java implementacijski primer si oglejte [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) v mapi samples.

## Sample implementation: JavaScript Implementation

JavaScript SDK omogoča lahko in prilagodljiv pristop k implementaciji MCP.

### Key Features

- Podpora za Node.js in brskalnik
- API temeljen na obljubah (Promise)
- Enostavna integracija z Express in drugimi okviri
- Podpora za WebSocket za pretakanje

Za popoln JavaScript implementacijski primer si oglejte [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) v mapi samples.

## Sample implementation: Python Implementation

Python SDK ponuja "pythoničen" pristop k implementaciji MCP z odlično integracijo ML okvirov.

### Key Features

- Podpora async/await z asyncio
- Integracija s Flask in FastAPI
- Enostavna registracija orodij
- Nativna integracija s priljubljenimi ML knjižnicami

Za popoln Python implementacijski primer si oglejte [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) v mapi samples.

## API management 

Azure API Management je odlična rešitev za varovanje MCP strežnikov. Ideja je postaviti Azure API Management instanco pred vaš MCP strežnik in ji prepustiti upravljanje funkcij, ki jih boste verjetno potrebovali, kot so:

- omejevanje hitrosti (rate limiting)
- upravljanje žetonov
- spremljanje
- uravnoteženje obremenitve
- varnost

### Azure Sample

Tukaj je Azure primer, ki točno to počne, tj. [ustvarjanje MCP strežnika in njegovo varovanje z Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Poglejte, kako poteka avtorizacijski potek na spodnji sliki:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na zgornji sliki se dogajajo naslednje stvari:

- Avtentikacija/avtorizacija poteka preko Microsoft Entra.
- Azure API Management deluje kot prehod (gateway) in uporablja politike za usmerjanje in upravljanje prometa.
- Azure Monitor beleži vse zahteve za nadaljnjo analizo.

#### Authorization flow

Poglejmo avtorizacijski potek podrobneje:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

Več o [MCP Authorization specifikaciji](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Deploy Remote MCP Server to Azure

Poglejmo, ali lahko uvedemo prej omenjeni primer:

1. Klonirajte repozitorij

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registrirajte `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` in po nekaj časa preverite, če je registracija končana.

2. Zaženite ta [azd](https://aka.ms/azd) ukaz za pripravo storitve API Management, funkcijske aplikacije (s kodo) in vseh drugih potrebnih Azure virov

    ```shell
    azd up
    ```

    Ta ukaz bi moral uvesti vse oblačne vire na Azure.

### Testing your server with MCP Inspector

1. V **novem terminalskem oknu** namestite in zaženite MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Videli boste vmesnik, podoben temu:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sl.png) 

1. CTRL kliknite, da naložite MCP Inspector spletno aplikacijo iz URL-ja, ki ga prikaže aplikacija (npr. http://127.0.0.1:6274/#resources)
1. Nastavite tip prenosa na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` in **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**. Kliknite na orodje in izberite **Run Tool**.

Če so vsi koraki uspeli, ste zdaj povezani z MCP strežnikom in lahko kličete orodje.

## MCP servers for Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ta niz repozitorijev je hitri začetek za gradnjo in uvajanje prilagojenih oddaljenih MCP (Model Context Protocol) strežnikov z uporabo Azure Functions v Pythonu, C# .NET ali Node/TypeScript.

Primeri nudijo celovito rešitev, ki razvijalcem omogoča:

- Lokalno gradnjo in zagon: Razvijajte in odpravljajte napake MCP strežnika na lokalnem računalniku
- Uvajanje v Azure: Enostavno uvajanje v oblak z ukazom azd up
- Povezovanje iz odjemalcev: Povežite se z MCP strežnikom iz različnih odjemalcev, vključno z VS Code Copilot agent načinom in orodjem MCP Inspector

### Key Features:

- Varnost po zasnovi: MCP strežnik je zaščiten z ključi in HTTPS
- Možnosti avtentikacije: Podpora za OAuth z vgrajeno avtentikacijo in/ali API Management
- Omrežna izolacija: Omogoča omrežno izolacijo z uporabo Azure Virtual Networks (VNET)
- Strežnik brez strežnika (serverless): Izkorišča Azure Functions za skalabilno, dogodkovno vodeno izvajanje
- Lokalni razvoj: Celovita podpora za lokalni razvoj in odpravljanje napak
- Enostavno uvajanje: Poenostavljen proces uvajanja v Azure

Repozitorij vključuje vse potrebne konfiguracijske datoteke, izvorno kodo in infrastrukturo za hitro začetek z produkcijsko pripravljeno MCP strežniško implementacijo.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Vzorčna implementacija MCP z uporabo Azure Functions v Pythonu

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Vzorčna implementacija MCP z uporabo Azure Functions v C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Vzorčna implementacija MCP z uporabo Azure Functions v Node/TypeScript.

## Key Takeaways

- MCP SDK-ji nudijo jezikovno specifična orodja za implementacijo robustnih MCP rešitev
- Proces odpravljanja napak in testiranja je ključen za zanesljive MCP aplikacije
- Ponovno uporabne predloge pozivov omogočajo dosledne AI interakcije
- Dobro zasnovani poteki lahko orkestrirajo kompleksne naloge z uporabo več orodij
- Implementacija MCP rešitev zahteva upoštevanje varnosti, zmogljivosti in obravnave napak

## Exercise

Načrtujte praktičen MCP potek, ki rešuje resnični problem na vašem področju:

1. Izberite 3-4 orodja, ki bi bila uporabna za rešitev tega problema
2. Naredite diagram poteka, ki prikazuje, kako ta orodja sodelujejo
3. Implementirajte osnovno različico enega izmed orodij v vašem izbranem jeziku
4. Ustvarite predlogo poziva, ki bo modelu pomagala učinkovito uporabljati vaše orodje

## Additional Resources


---

Next: [Advanced Topics](../05-AdvancedTopics/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvorni jezik je treba upoštevati kot avtoritativni vir. Za kritične informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitna nesporazumevanja ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.