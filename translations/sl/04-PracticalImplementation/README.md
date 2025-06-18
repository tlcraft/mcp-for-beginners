<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:37:37+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sl"
}
-->
# Praktična izvedba

Praktična izvedba je trenutek, ko moč Model Context Protocola (MCP) postane otipljiva. Čeprav je razumevanje teorije in arhitekture MCP pomembno, se prava vrednost pokaže, ko te koncepte uporabite za gradnjo, testiranje in uvajanje rešitev, ki rešujejo resnične težave. Ta poglavje premošča vrzel med konceptualnim znanjem in praktičnim razvojem ter vas vodi skozi proces ustvarjanja aplikacij na osnovi MCP.

Ne glede na to, ali razvijate inteligentne asistente, integrirate AI v poslovne procese ali ustvarjate prilagojena orodja za obdelavo podatkov, MCP nudi prilagodljivo osnovo. Njegova jezikovno neodvisna zasnova in uradni SDK-ji za priljubljene programske jezike omogočajo dostop širokemu krogu razvijalcev. Z uporabo teh SDK-jev lahko hitro izdelate prototipe, iterirate in razširite svoje rešitve na različnih platformah in okoljih.

V nadaljevanju boste našli praktične primere, vzorčne kode in strategije uvajanja, ki prikazujejo, kako implementirati MCP v C#, Java, TypeScript, JavaScript in Python. Naučili se boste tudi, kako razhroščevati in testirati MCP strežnike, upravljati API-je ter uvajati rešitve v oblak z uporabo Azure. Ti praktični viri so zasnovani tako, da pospešijo vaše učenje in vam pomagajo samozavestno zgraditi robustne, proizvodno pripravljene MCP aplikacije.

## Pregled

Ta lekcija se osredotoča na praktične vidike implementacije MCP v več programskih jezikih. Raziskali bomo, kako uporabljati MCP SDK-je v C#, Java, TypeScript, JavaScript in Python za gradnjo robustnih aplikacij, razhroščevanje in testiranje MCP strežnikov ter ustvarjanje ponovno uporabnih virov, pozivov in orodij.

## Cilji učenja

Do konca te lekcije boste znali:
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

Ta razdelek ponuja praktične primere implementacije MCP v več programskih jezikih. V imeniku `samples` lahko najdete vzorčno kodo, organizirano po jezikih.

### Razpoložljivi primeri

V repozitoriju so [vzročni primeri](../../../04-PracticalImplementation/samples) v naslednjih jezikih:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Vsak primer prikazuje ključne koncepte MCP in vzorce implementacije za določen jezik in ekosistem.

## Osnovne funkcije strežnika

MCP strežniki lahko implementirajo katerokoli kombinacijo teh funkcij:

### Viri  
Viri zagotavljajo kontekst in podatke za uporabnika ali AI model:  
- Shrambe dokumentov  
- Baze znanja  
- Strukturirani podatkovni viri  
- Datotečni sistemi  

### Pozivi  
Pozivi so predloge sporočil in delovnih tokov za uporabnike:  
- Vnaprej določene predloge pogovorov  
- Vodeni vzorci interakcij  
- Specializirane strukture dialoga  

### Orodja  
Orodja so funkcije, ki jih AI model izvaja:  
- Orodja za obdelavo podatkov  
- Integracije zunanjih API-jev  
- Računske zmogljivosti  
- Funkcionalnosti iskanja  

## Vzorčne implementacije: C#

Uradni C# SDK repozitorij vsebuje več vzorčnih implementacij, ki prikazujejo različne vidike MCP:

- **Osnovni MCP klient**: preprost primer, kako ustvariti MCP klienta in poklicati orodja  
- **Osnovni MCP strežnik**: minimalna implementacija strežnika z osnovno registracijo orodij  
- **Napredni MCP strežnik**: polno funkcionalen strežnik z registracijo orodij, avtentikacijo in obravnavo napak  
- **Integracija ASP.NET**: primeri integracije z ASP.NET Core  
- **Vzorec implementacije orodij**: različni vzorci za implementacijo orodij z različnimi stopnjami kompleksnosti  

MCP C# SDK je v predogledu in se lahko API-ji spreminjajo. Ta blog bomo sproti posodabljali, ko se SDK razvija.

### Ključne funkcije  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Gradnja vašega [prvega MCP strežnika](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Za popolne vzorce implementacije v C# obiščite [uradni repozitorij C# SDK vzorcev](https://github.com/modelcontextprotocol/csharp-sdk)

## Vzorčna implementacija: Java

Java SDK ponuja robustne možnosti implementacije MCP z enterprise-grade funkcijami.

### Ključne funkcije

- Integracija Spring Frameworka  
- Močna tipna varnost  
- Podpora reaktivnemu programiranju  
- Celovita obravnava napak  

Za popoln vzorec implementacije v Javi si oglejte [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) v imeniku vzorcev.

## Vzorčna implementacija: JavaScript

JavaScript SDK ponuja lahkoten in prilagodljiv pristop k implementaciji MCP.

### Ključne funkcije

- Podpora za Node.js in brskalnike  
- API, ki temelji na Promise-ih  
- Enostavna integracija z Express in drugimi okviri  
- Podpora WebSocket za streaming  

Za popoln vzorec implementacije v JavaScriptu si oglejte [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) v imeniku vzorcev.

## Vzorčna implementacija: Python

Python SDK ponuja pythonističen pristop k implementaciji MCP z odlično integracijo ML okvirov.

### Ključne funkcije

- Podpora async/await z asyncio  
- Integracija s Flask in FastAPI  
- Enostavna registracija orodij  
- Nativna integracija s priljubljenimi ML knjižnicami  

Za popoln vzorec implementacije v Pythonu si oglejte [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) v imeniku vzorcev.

## Upravljanje API-jev

Azure API Management je odličen odgovor na vprašanje, kako lahko zaščitimo MCP strežnike. Ideja je, da postavite instanco Azure API Management pred vaš MCP strežnik in ji dovolite upravljanje funkcij, ki jih boste verjetno želeli, kot so:

- omejevanje hitrosti  
- upravljanje žetonov  
- nadzor  
- uravnoteženje obremenitve  
- varnost  

### Azure primer

Tukaj je Azure primer, ki točno to počne, tj. [ustvarjanje MCP strežnika in njegovo zaščito z Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Spodnja slika prikazuje, kako poteka avtentikacijski potek:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na zgornji sliki se zgodi naslednje:

- Avtentikacija/avtorizacija poteka prek Microsoft Entra.  
- Azure API Management deluje kot prehod in uporablja politike za usmerjanje ter upravljanje prometa.  
- Azure Monitor beleži vse zahteve za nadaljnjo analizo.  

#### Potek avtorizacije

Poglejmo si podrobneje potek avtorizacije:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP specifikacija avtorizacije

Več o [MCP specifikaciji avtorizacije](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Uvajanje oddaljenega MCP strežnika v Azure

Poglejmo, ali lahko uvedemo vzorec, ki smo ga omenili prej:

1. Klonirajte repozitorij

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Registrirajte `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` in po določenem času preverite, ali je registracija končana.

3. Zaženite ta [azd](https://aka.ms/azd) ukaz za pripravo storitve upravljanja API-jev, funkcijske aplikacije (s kodo) in vseh drugih potrebnih Azure virov

    ```shell
    azd up
    ```

    Ta ukaz bi moral uvesti vse oblačne vire na Azure.

### Testiranje vašega strežnika z MCP Inspector

1. V **novem terminalskem oknu** namestite in zaženite MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Videti bi morali vmesnik, podoben temu:

    ![Poveži se z Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sl.png) 

2. CTRL kliknite, da naložite MCP Inspector spletno aplikacijo z URL-ja, ki ga aplikacija prikaže (npr. http://127.0.0.1:6274/#resources)  
3. Nastavite vrsto prenosa na `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` in kliknite **Poveži**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Prikaži orodja**. Kliknite na orodje in izberite **Zaženi orodje**.  

Če so bili vsi koraki uspešni, ste zdaj povezani z MCP strežnikom in ste lahko poklicali orodje.

## MCP strežniki za Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ta niz repozitorijev je predloga za hiter začetek za gradnjo in uvajanje prilagojenih oddaljenih MCP (Model Context Protocol) strežnikov z uporabo Azure Functions v Python, C# .NET ali Node/TypeScript.

Primeri nudijo celovito rešitev, ki razvijalcem omogoča:

- Lokalno gradnjo in zagon: razvoj in razhroščevanje MCP strežnika na lokalnem računalniku  
- Uvajanje v Azure: enostavno uvajanje v oblak z ukazom azd up  
- Povezovanje iz odjemalcev: povezovanje z MCP strežnikom iz različnih odjemalcev, vključno z načinom agenta Copilot v VS Code in orodjem MCP Inspector  

### Ključne funkcije:

- Varnost po zasnovi: MCP strežnik je zaščiten z ključi in HTTPS  
- Možnosti avtentikacije: podpira OAuth z vgrajeno avtentikacijo in/ali API Management  
- Omrežna izolacija: omogoča omrežno izolacijo z uporabo Azure Virtual Networks (VNET)  
- Strežniška arhitektura brez strežnika: uporablja Azure Functions za skalabilno, dogodkovno izvedbo  
- Lokalni razvoj: celovita podpora za lokalni razvoj in razhroščevanje  
- Enostavno uvajanje: poenostavljen postopek uvajanja v Azure  

Repozitorij vsebuje vse potrebne konfiguracijske datoteke, izvorno kodo in definicije infrastrukture, da hitro začnete z implementacijo MCP strežnika, pripravljenega za produkcijo.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Vzorčna implementacija MCP z uporabo Azure Functions v Pythonu  

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Vzorčna implementacija MCP z uporabo Azure Functions v C# .NET  

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Vzorčna implementacija MCP z uporabo Azure Functions v Node/TypeScript.  

## Ključne ugotovitve

- MCP SDK-ji nudijo jezikovno specifična orodja za implementacijo robustnih MCP rešitev  
- Proces razhroščevanja in testiranja je ključnega pomena za zanesljive MCP aplikacije  
- Ponovno uporabne predloge pozivov omogočajo dosledne AI interakcije  
- Dobro zasnovani delovni tokovi lahko orkestrirajo kompleksne naloge z uporabo več orodij  
- Implementacija MCP rešitev zahteva upoštevanje varnosti, zmogljivosti in obravnave napak  

## Vaja

Načrtujte praktičen MCP delovni tok, ki rešuje resničen problem v vašem področju:

1. Določite 3-4 orodja, ki bi bila uporabna za reševanje tega problema  
2. Ustvarite diagram delovnega toka, ki prikazuje, kako ta orodja sodelujejo  
3. Implementirajte osnovno različico enega od orodij v izbranem jeziku  
4. Ustvarite predlogo poziva, ki bi modelu pomagala učinkovito uporabljati vaše orodje  

## Dodatni viri


---

Naslednje: [Napredne teme](../05-AdvancedTopics/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitna nesporazume ali napačne razlage, ki izhajajo iz uporabe tega prevoda.