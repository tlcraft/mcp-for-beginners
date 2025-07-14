<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:38:32+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "sl"
}
-->
# Študija primera: Izpostavitev REST API v API Management kot MCP strežnik

Azure API Management je storitev, ki zagotavlja prehod (Gateway) nad vašimi API končnimi točkami. Deluje tako, da Azure API Management deluje kot proxy pred vašimi API-ji in lahko odloča, kaj storiti z dohodnimi zahtevki.

Z njegovo uporabo dodate vrsto funkcij, kot so:

- **Varnost**, lahko uporabite vse od API ključev, JWT do upravljane identitete.
- **Omejevanje hitrosti**, odlična funkcija, ki omogoča odločanje, koliko klicev lahko preide v določenem časovnem obdobju. To pomaga zagotoviti odlično izkušnjo za vse uporabnike in preprečuje preobremenitev vaše storitve z zahtevki.
- **Prilagajanje zmogljivosti in uravnoteženje obremenitve**. Lahko nastavite več končnih točk za razporeditev obremenitve in odločite, kako želite "uravnotežiti obremenitev".
- **AI funkcije, kot so semantično predpomnjenje**, omejitev in spremljanje tokenov ter še več. To so odlične funkcije, ki izboljšajo odzivnost in vam pomagajo nadzorovati porabo tokenov. [Preberite več tukaj](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Zakaj MCP + Azure API Management?

Model Context Protocol hitro postaja standard za agentne AI aplikacije in način izpostavitve orodij ter podatkov na dosleden način. Azure API Management je naravna izbira, ko morate "upravljati" API-je. MCP strežniki se pogosto integrirajo z drugimi API-ji za reševanje zahtevkov do orodij, na primer. Zato kombinacija Azure API Management in MCP zelo smiselna.

## Pregled

V tem konkretnem primeru se bomo naučili, kako izpostaviti API končne točke kot MCP strežnik. S tem lahko te končne točke enostavno vključimo v agentno aplikacijo in hkrati izkoristimo funkcije Azure API Management.

## Ključne funkcije

- Izberete metode končnih točk, ki jih želite izpostaviti kot orodja.
- Dodatne funkcije, ki jih dobite, so odvisne od tega, kaj konfigurirate v razdelku politik za vaš API. Tukaj bomo pokazali, kako dodati omejevanje hitrosti.

## Predhodni korak: uvoz API-ja

Če že imate API v Azure API Management, super, potem lahko ta korak preskočite. Če ne, si oglejte ta povezavo, [uvoz API-ja v Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Izpostavitev API-ja kot MCP strežnik

Za izpostavitev API končnih točk sledite tem korakom:

1. Pojdite v Azure Portal na naslov <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Pojdite do vaše instance API Management.

1. V levem meniju izberite APIs > MCP Servers > + Create new MCP Server.

1. Pri API izberite REST API, ki ga želite izpostaviti kot MCP strežnik.

1. Izberite eno ali več API operacij, ki jih želite izpostaviti kot orodja. Lahko izberete vse operacije ali samo določene.

    ![Izberite metode za izpostavitev](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Izberite **Create**.

1. Pojdite v meni **APIs** in **MCP Servers**, kjer bi morali videti naslednje:

    ![MCP strežnik v glavnem pogledu](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP strežnik je ustvarjen in API operacije so izpostavljene kot orodja. MCP strežnik je prikazan v seznamu MCP Servers. Stolpec URL prikazuje končno točko MCP strežnika, ki jo lahko pokličete za testiranje ali znotraj odjemalske aplikacije.

## Neobvezno: konfiguracija politik

Azure API Management temelji na konceptu politik, kjer nastavite različna pravila za vaše končne točke, na primer omejevanje hitrosti ali semantično predpomnjenje. Te politike so zapisane v XML.

Tukaj je, kako lahko nastavite politiko za omejevanje hitrosti vašega MCP strežnika:

1. V portalu, pod APIs, izberite **MCP Servers**.

1. Izberite MCP strežnik, ki ste ga ustvarili.

1. V levem meniju, pod MCP, izberite **Policies**.

1. V urejevalniku politik dodajte ali uredite politike, ki jih želite uporabiti za orodja MCP strežnika. Politike so definirane v XML formatu. Na primer, lahko dodate politiko za omejitev klicev do orodij MCP strežnika (v tem primeru 5 klicev na 30 sekund na IP naslov odjemalca). Tukaj je XML, ki bo to omogočil:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Tukaj je slika urejevalnika politik:

    ![Urejevalnik politik](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Preizkusite

Preverimo, ali naš MCP strežnik deluje kot je pričakovano.

Za to bomo uporabili Visual Studio Code in GitHub Copilot v načinu Agent. Dodali bomo MCP strežnik v datoteko *mcp.json*. S tem bo Visual Studio Code deloval kot odjemalec z agentnimi zmožnostmi, končni uporabniki pa bodo lahko vpisali poziv in komunicirali s tem strežnikom.

Poglejmo, kako dodati MCP strežnik v Visual Studio Code:

1. Uporabite ukaz MCP: **Add Server iz Command Palette**.

1. Ko vas vpraša, izberite tip strežnika: **HTTP (HTTP ali Server Sent Events)**.

1. Vnesite URL MCP strežnika v API Management. Primer: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (za SSE končno točko) ali **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (za MCP končno točko), opazite razliko v transportu `/sse` ali `/mcp`.

1. Vnesite ID strežnika po vaši izbiri. To ni pomembna vrednost, vendar vam bo pomagalo zapomniti, za katero instanco strežnika gre.

1. Izberite, ali želite konfiguracijo shraniti v nastavitve delovnega prostora ali uporabniške nastavitve.

  - **Nastavitve delovnega prostora** - konfiguracija strežnika se shrani v datoteko .vscode/mcp.json, ki je na voljo samo v trenutnem delovnem prostoru.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    ali če izberete streaming HTTP kot transport, bo nekoliko drugače:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Uporabniške nastavitve** - konfiguracija strežnika se doda v globalno datoteko *settings.json* in je na voljo v vseh delovnih prostorih. Konfiguracija izgleda približno takole:

    ![Uporabniške nastavitve](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Prav tako morate dodati konfiguracijo, glavo, da zagotovite pravilno avtentikacijo do Azure API Management. Uporablja glavo z imenom **Ocp-Apim-Subscription-Key**.

    - Tako jo lahko dodate v nastavitve:

    ![Dodajanje glave za avtentikacijo](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), kar bo povzročilo, da se prikaže poziv za vnos vrednosti API ključa, ki ga najdete v Azure Portalu za vašo instanco Azure API Management.

   - Če jo želite dodati v *mcp.json*, jo lahko dodate tako:

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

### Uporaba načina Agent

Zdaj smo pripravljeni bodisi v nastavitvah bodisi v *.vscode/mcp.json*. Preizkusimo.

Na voljo bi moral biti gumb Orodja (Tools), kjer so našteta izpostavljena orodja vašega strežnika:

![Orodja s strežnika](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Kliknite ikono orodij in videli boste seznam orodij, kot je ta:

    ![Orodja](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Vnesite poziv v klepet, da pokličete orodje. Na primer, če ste izbrali orodje za pridobitev informacij o naročilu, lahko agenta vprašate o naročilu. Tukaj je primer poziva:

    ```text
    get information from order 2
    ```

    Zdaj se vam bo prikazala ikona orodij, ki vas bo pozvala, da nadaljujete s klicem orodja. Izberite nadaljevanje izvajanja orodja, videli boste izhod, kot je ta:

    ![Rezultat poziva](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **kar vidite zgoraj, je odvisno od orodij, ki ste jih nastavili, vendar je ideja, da dobite besedilni odgovor, kot je prikazan zgoraj**


## Reference

Tukaj lahko izveste več:

- [Vodič za Azure API Management in MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python primer: Varnost oddaljenih MCP strežnikov z uporabo Azure API Management (eksperimentalno)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Laboratorij za avtorizacijo MCP odjemalcev](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Uporaba razširitve Azure API Management za VS Code za uvoz in upravljanje API-jev](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Registracija in odkrivanje oddaljenih MCP strežnikov v Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Odličen repozitorij, ki prikazuje številne AI zmogljivosti z Azure API Management
- [Delavnice AI Gateway](https://azure-samples.github.io/AI-Gateway/) Vsebuje delavnice z uporabo Azure Portala, kar je odličen način za začetek ocenjevanja AI zmogljivosti.

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.