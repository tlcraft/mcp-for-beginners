<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb1ab5c924f58cf75ef1732d474f008a",
  "translation_date": "2025-07-14T17:25:22+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sl"
}
-->
# Praktična implementacija

Praktična implementacija je trenutek, ko moč Model Context Protocol (MCP) postane otipljiva. Čeprav je razumevanje teorije in arhitekture MCP pomembno, se prava vrednost pokaže, ko te koncepte uporabite za izdelavo, testiranje in uvajanje rešitev, ki rešujejo resnične probleme. Ta poglavje premošča vrzel med konceptualnim znanjem in praktičnim razvojem ter vas vodi skozi proces oživljanja aplikacij, temelječih na MCP.

Ne glede na to, ali razvijate inteligentne asistente, integrirate AI v poslovne procese ali ustvarjate prilagojena orodja za obdelavo podatkov, MCP nudi prilagodljivo osnovo. Njegova jezikovno neodvisna zasnova in uradni SDK-ji za priljubljene programske jezike omogočajo dostop širokemu krogu razvijalcev. Z uporabo teh SDK-jev lahko hitro izdelate prototipe, iterirate in razširite svoje rešitve na različnih platformah in okoljih.

V naslednjih razdelkih boste našli praktične primere, vzorčno kodo in strategije uvajanja, ki prikazujejo, kako implementirati MCP v C#, Javi, TypeScriptu, JavaScriptu in Pythonu. Naučili se boste tudi, kako razhroščevati in testirati MCP strežnike, upravljati API-je ter uvajati rešitve v oblak z uporabo Azure. Ti praktični viri so zasnovani tako, da pospešijo vaše učenje in vam pomagajo samozavestno graditi robustne, produkcijsko pripravljene MCP aplikacije.

## Pregled

Ta lekcija se osredotoča na praktične vidike implementacije MCP v več programskih jezikih. Raziskali bomo, kako uporabljati MCP SDK-je v C#, Javi, TypeScriptu, JavaScriptu in Pythonu za izdelavo robustnih aplikacij, razhroščevanje in testiranje MCP strežnikov ter ustvarjanje ponovno uporabnih virov, pozivov in orodij.

## Cilji učenja

Ob koncu te lekcije boste znali:
- Implementirati MCP rešitve z uporabo uradnih SDK-jev v različnih programskih jezikih
- Sistematično razhroščevati in testirati MCP strežnike
- Ustvarjati in uporabljati funkcije strežnika (Viri, Pozivi in Orodja)
- Načrtovati učinkovite MCP delovne tokove za kompleksne naloge
- Optimizirati MCP implementacije za zmogljivost in zanesljivost

## Uradni SDK viri

Model Context Protocol ponuja uradne SDK-je za več jezikov:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Delo z MCP SDK-ji

Ta razdelek ponuja praktične primere implementacije MCP v več programskih jezikih. V mapi `samples` lahko najdete vzorčno kodo, organizirano po jezikih.

### Na voljo vzorci

V repozitoriju so [vzorec implementacij](../../../04-PracticalImplementation/samples) v naslednjih jezikih:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Vsak vzorec prikazuje ključne koncepte MCP in vzorce implementacije za določen jezik in ekosistem.

## Osnovne funkcije strežnika

MCP strežniki lahko implementirajo katerokoli kombinacijo teh funkcij:

### Viri
Viri zagotavljajo kontekst in podatke za uporabnika ali AI model:
- Repozitoriji dokumentov
- Baze znanja
- Strukturirani podatkovni viri
- Datotečni sistemi

### Pozivi
Pozivi so predloge sporočil in delovnih tokov za uporabnike:
- Vnaprej določene predloge pogovorov
- Vodeni vzorci interakcij
- Specializirane strukture dialoga

### Orodja
Orodja so funkcije, ki jih AI model lahko izvede:
- Orodja za obdelavo podatkov
- Integracije z zunanjimi API-ji
- Računske zmogljivosti
- Funkcionalnost iskanja

## Vzorčne implementacije: C#

Uradni repozitorij C# SDK vsebuje več vzorčnih implementacij, ki prikazujejo različne vidike MCP:

- **Osnovni MCP klient**: Preprost primer, ki prikazuje, kako ustvariti MCP klienta in klicati orodja
- **Osnovni MCP strežnik**: Minimalna implementacija strežnika z osnovno registracijo orodij
- **Napredni MCP strežnik**: Polno opremljen strežnik z registracijo orodij, avtentikacijo in obravnavo napak
- **Integracija z ASP.NET**: Primeri integracije z ASP.NET Core
- **Vzorec implementacije orodij**: Različni vzorci za implementacijo orodij z različnimi stopnjami kompleksnosti

MCP C# SDK je v predogledu in API-ji se lahko spreminjajo. Ta blog bomo sproti posodabljali, ko se bo SDK razvijal.

### Ključne funkcije 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Izdelava vašega [prvega MCP strežnika](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Za popolne vzorce implementacije v C# obiščite [uradni repozitorij vzorcev C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Vzorčna implementacija: Java

Java SDK ponuja robustne možnosti implementacije MCP z lastnostmi na ravni podjetja.

### Ključne funkcije

- Integracija s Spring Framework
- Močna tipna varnost
- Podpora reaktivnemu programiranju
- Celovita obravnava napak

Za popoln vzorec implementacije v Javi si oglejte [Java vzorec](samples/java/containerapp/README.md) v mapi vzorcev.

## Vzorčna implementacija: JavaScript

JavaScript SDK ponuja lahkoten in prilagodljiv pristop k implementaciji MCP.

### Ključne funkcije

- Podpora za Node.js in brskalnike
- API, ki temelji na obljubah (Promise)
- Enostavna integracija z Express in drugimi ogrodji
- Podpora za WebSocket za pretakanje

Za popoln vzorec implementacije v JavaScriptu si oglejte [JavaScript vzorec](samples/javascript/README.md) v mapi vzorcev.

## Vzorčna implementacija: Python

Python SDK ponuja pythonističen pristop k implementaciji MCP z odlično integracijo z ML ogrodji.

### Ključne funkcije

- Podpora async/await z asyncio
- Integracija s FastAPI
- Enostavna registracija orodij
- Nativna integracija s priljubljenimi ML knjižnicami

Za popoln vzorec implementacije v Pythonu si oglejte [Python vzorec](samples/python/README.md) v mapi vzorcev.

## Upravljanje API-jev

Azure API Management je odličen odgovor na vprašanje, kako lahko zaščitimo MCP strežnike. Ideja je, da pred vaš MCP strežnik postavite instanco Azure API Management in ji prepustite upravljanje funkcij, ki jih boste verjetno želeli, kot so:

- omejevanje hitrosti
- upravljanje žetonov
- nadzor
- uravnoteženje obremenitve
- varnost

### Azure vzorec

Tukaj je Azure vzorec, ki točno to počne, tj. [ustvarjanje MCP strežnika in njegovo zaščito z Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Spodnja slika prikazuje, kako poteka avtentikacijski tok:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na zgornji sliki se zgodi naslednje:

- Avtentikacija/avtorizacija poteka z uporabo Microsoft Entra.
- Azure API Management deluje kot prehod in uporablja politike za usmerjanje in upravljanje prometa.
- Azure Monitor beleži vse zahteve za nadaljnjo analizo.

#### Tok avtorizacije

Poglejmo si tok avtorizacije podrobneje:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specifikacija avtorizacije MCP

Več o [MCP specifikaciji avtorizacije](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Uvajanje oddaljenega MCP strežnika v Azure

Poglejmo, ali lahko uvedemo prej omenjeni vzorec:

1. Klonirajte repozitorij

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registrirajte ponudnika virov `Microsoft.App`.
    * Če uporabljate Azure CLI, zaženite `az provider register --namespace Microsoft.App --wait`.
    * Če uporabljate Azure PowerShell, zaženite `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Nato po nekaj času preverite stanje registracije z ukazom `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`.

2. Zaženite ta [azd](https://aka.ms/azd) ukaz za pripravo storitve upravljanja API-jev, funkcijske aplikacije (s kodo) in vseh drugih potrebnih Azure virov

    ```shell
    azd up
    ```

    Ta ukaz bi moral namestiti vse oblačne vire na Azure.

### Testiranje vašega strežnika z MCP Inspector

1. V **novem terminalskem oknu** namestite in zaženite MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Videli boste vmesnik, podoben temu:

    ![Connect to Node inspector](/03-GettingStarted/01-first-server/assets/connect.png) 

1. Kliknite CTRL in odprite MCP Inspector spletno aplikacijo z URL-jem, ki ga prikaže aplikacija (npr. http://127.0.0.1:6274/#resources)
1. Nastavite tip prenosa na `SSE`
1. Nastavite URL na vaš tekoči API Management SSE konektor, prikazan po ukazu `azd up` in **Povežite se**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Seznam orodij**. Kliknite na orodje in **Zaženi orodje**.  

Če so vsi koraki uspeli, ste zdaj povezani z MCP strežnikom in lahko kličete orodje.

## MCP strežniki za Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ta niz repozitorijev je hitri začetek za gradnjo in uvajanje prilagojenih oddaljenih MCP (Model Context Protocol) strežnikov z uporabo Azure Functions v Pythonu, C# .NET ali Node/TypeScript.

Vzorec ponuja celovito rešitev, ki razvijalcem omogoča:

- Lokalno gradnjo in zagon: Razvijajte in razhroščujte MCP strežnik na lokalnem računalniku
- Uvajanje v Azure: Enostavno uvajanje v oblak z ukazom azd up
- Povezovanje s klienti: Povezovanje z MCP strežnikom iz različnih klientov, vključno z načinom agenta Copilot v VS Code in orodjem MCP Inspector

### Ključne lastnosti:

- Varnost po zasnovi: MCP strežnik je zaščiten z uporabo ključev in HTTPS
- Možnosti avtentikacije: Podpora OAuth z vgrajeno avtentikacijo in/ali API Management
- Omrežna izolacija: Omogoča omrežno izolacijo z uporabo Azure Virtual Networks (VNET)
- Strežnik brez strežnika (serverless): Izrablja Azure Functions za skalabilno, dogodkovno usmerjeno izvajanje
- Lokalni razvoj: Celovita podpora za lokalni razvoj in razhroščevanje
- Enostavno uvajanje: Poenostavljen postopek uvajanja v Azure

Repozitorij vključuje vse potrebne konfiguracijske datoteke, izvorno kodo in definicije infrastrukture za hiter začetek z produkcijsko pripravljeno MCP implementacijo strežnika.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Vzorec implementacije MCP z uporabo Azure Functions v Pythonu

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Vzorec implementacije MCP z uporabo Azure Functions v C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Vzorec implementacije MCP z uporabo Azure Functions v Node/TypeScript.

## Ključne ugotovitve

- MCP SDK-ji nudijo jezikovno specifična orodja za implementacijo robustnih MCP rešitev
- Proces razhroščevanja in testiranja je ključen za zanesljive MCP aplikacije
- Ponovno uporabne predloge pozivov omogočajo dosledne AI interakcije
- Dobro zasnovani delovni tokovi lahko orkestrirajo kompleksne naloge z uporabo več orodij
- Implementacija MCP rešitev zahteva upoštevanje varnosti, zmogljivosti in obravnave napak

## Vaja

Načrtujte praktičen MCP delovni tok, ki rešuje resnični problem v vašem področju:

1. Določite 3-4 orodja, ki bi bila uporabna za reševanje tega problema
2. Ustvarite diagram delovnega toka, ki prikazuje, kako ta orodja sodelujejo
3. Implementirajte osnovno različico enega od orodij v vašem izbranem jeziku
4. Ustvarite predlogo poziva, ki bo modelu pomagala učinkovito uporabljati vaše orodje

## Dodatni viri


---

Naslednje: [Napredne teme](../05-AdvancedTopics/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.