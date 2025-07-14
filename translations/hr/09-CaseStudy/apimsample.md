<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:38:10+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "hr"
}
-->
# Studija slučaja: Izložite REST API u API Managementu kao MCP server

Azure API Management je usluga koja pruža Gateway iznad vaših API krajnjih točaka. Način na koji radi jest da Azure API Management djeluje kao proxy ispred vaših API-ja i može odlučiti što učiniti s dolaznim zahtjevima.

Korištenjem ove usluge dobivate niz značajki kao što su:

- **Sigurnost**, možete koristiti sve od API ključeva, JWT do upravljanog identiteta.
- **Ograničenje brzine poziva**, sjajna značajka koja vam omogućuje da odredite koliko poziva može proći u određenom vremenskom razdoblju. To pomaže osigurati da svi korisnici imaju izvrsno iskustvo i da vaša usluga nije preopterećena zahtjevima.
- **Skaliranje i balansiranje opterećenja**. Možete postaviti više krajnjih točaka za raspodjelu opterećenja i također odlučiti kako želite "balansirati opterećenje".
- **AI značajke poput semantičkog keširanja**, ograničenja tokena, praćenja tokena i još mnogo toga. To su izvrsne značajke koje poboljšavaju odzivnost i pomažu vam pratiti potrošnju tokena. [Pročitajte više ovdje](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Zašto MCP + Azure API Management?

Model Context Protocol brzo postaje standard za agentne AI aplikacije i način izlaganja alata i podataka na dosljedan način. Azure API Management je prirodan izbor kada trebate "upravljati" API-jima. MCP serveri često se integriraju s drugim API-jima kako bi, na primjer, riješili zahtjeve prema nekom alatu. Stoga kombinacija Azure API Managementa i MCP-a ima puno smisla.

## Pregled

U ovom konkretnom slučaju naučit ćemo kako izložiti API krajnje točke kao MCP server. Time možemo lako učiniti te krajnje točke dijelom agentne aplikacije, a istovremeno iskoristiti značajke Azure API Managementa.

## Ključne značajke

- Odabirete metode krajnjih točaka koje želite izložiti kao alate.
- Dodatne značajke koje dobivate ovise o tome što konfigurirate u odjeljku politika za vaš API. Ovdje ćemo pokazati kako dodati ograničenje brzine poziva.

## Pripremni korak: uvoz API-ja

Ako već imate API u Azure API Managementu, odlično, možete preskočiti ovaj korak. Ako ne, pogledajte ovaj link, [uvoz API-ja u Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Izložite API kao MCP Server

Za izlaganje API krajnjih točaka slijedite ove korake:

1. Idite na Azure Portal i na adresu <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
   Otvorite vašu instancu API Managementa.

1. U lijevom izborniku odaberite APIs > MCP Servers > + Create new MCP Server.

1. U API-ju odaberite REST API koji želite izložiti kao MCP server.

1. Odaberite jednu ili više API operacija koje želite izložiti kao alate. Možete odabrati sve operacije ili samo određene.

    ![Odaberite metode za izlaganje](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Odaberite **Create**.

1. Idite na izbornik **APIs** i **MCP Servers**, trebali biste vidjeti sljedeće:

    ![Pogledajte MCP Server u glavnom prozoru](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP server je kreiran, a API operacije su izložene kao alati. MCP server je naveden u odjeljku MCP Servers. Stupac URL prikazuje krajnju točku MCP servera koju možete pozvati za testiranje ili unutar klijentske aplikacije.

## Opcionalno: Konfigurirajte politike

Azure API Management ima osnovni koncept politika gdje postavljate različita pravila za svoje krajnje točke, poput ograničenja brzine poziva ili semantičkog keširanja. Te se politike pišu u XML formatu.

Evo kako možete postaviti politiku za ograničenje brzine poziva na vaš MCP Server:

1. U portalu, pod APIs, odaberite **MCP Servers**.

1. Odaberite MCP server koji ste kreirali.

1. U lijevom izborniku, pod MCP, odaberite **Policies**.

1. U uređivaču politika dodajte ili uredite politike koje želite primijeniti na alate MCP servera. Politike su definirane u XML formatu. Na primjer, možete dodati politiku koja ograničava pozive alatima MCP servera (u ovom primjeru, 5 poziva na 30 sekundi po IP adresi klijenta). Evo XML-a koji će to omogućiti:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Evo slike uređivača politika:

    ![Uređivač politika](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Isprobajte

Provjerimo radi li naš MCP Server kako treba.

Za to ćemo koristiti Visual Studio Code i GitHub Copilot u Agent modu. Dodati ćemo MCP server u *mcp.json* datoteku. Time će Visual Studio Code djelovati kao klijent s agentnim mogućnostima, a krajnji korisnici moći će upisivati upite i komunicirati s tim serverom.

Evo kako dodati MCP server u Visual Studio Code:

1. Koristite MCP: **Add Server naredbu iz Command Palette**.

1. Kad se zatraži, odaberite tip servera: **HTTP (HTTP ili Server Sent Events)**.

1. Unesite URL MCP servera u API Managementu. Primjer: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (za SSE krajnju točku) ili **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (za MCP krajnju točku), obratite pažnju na razliku u transportu `/sse` ili `/mcp`.

1. Unesite ID servera po želji. Nije važna vrijednost, ali će vam pomoći da zapamtite o kojoj se instanci servera radi.

1. Odaberite želite li spremiti konfiguraciju u postavke radnog prostora ili korisničke postavke.

  - **Postavke radnog prostora** - Konfiguracija servera se sprema u .vscode/mcp.json datoteku koja je dostupna samo u trenutnom radnom prostoru.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    ili ako odaberete streaming HTTP kao transport, izgledat će malo drugačije:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Korisničke postavke** - Konfiguracija servera se dodaje u globalnu *settings.json* datoteku i dostupna je u svim radnim prostorima. Konfiguracija izgleda otprilike ovako:

    ![Korisnička postavka](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Također trebate dodati konfiguraciju, zaglavlje koje osigurava ispravnu autentifikaciju prema Azure API Managementu. Koristi se zaglavlje pod nazivom **Ocp-Apim-Subscription-Key**.

    - Evo kako ga možete dodati u postavke:

    ![Dodavanje zaglavlja za autentifikaciju](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), što će prikazati upit za unos vrijednosti API ključa koji možete pronaći u Azure Portalu za vašu Azure API Management instancu.

   - Za dodavanje u *mcp.json* umjesto toga, možete ga dodati ovako:

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

### Koristite Agent mod

Sada smo spremni, bilo u postavkama ili u *.vscode/mcp.json*. Isprobajmo.

Trebao bi se pojaviti ikona Alata (Tools) kao na slici, gdje su navedeni izloženi alati s vašeg servera:

![Alati sa servera](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Kliknite na ikonu alata i trebali biste vidjeti popis alata kao na slici:

    ![Alati](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Unesite upit u chat da pozovete alat. Na primjer, ako ste odabrali alat za dobivanje informacija o narudžbi, možete pitati agenta o narudžbi. Evo primjera upita:

    ```text
    get information from order 2
    ```

    Sada će vam se prikazati ikona alata koja traži potvrdu za pozivanje alata. Odaberite da nastavite s izvršavanjem alata, trebali biste vidjeti izlaz kao na slici:

    ![Rezultat upita](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **što vidite ovisi o alatima koje ste postavili, ali ideja je da dobijete tekstualni odgovor kao gore**


## Reference

Evo gdje možete saznati više:

- [Tutorial o Azure API Managementu i MCP-u](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python primjer: Sigurni udaljeni MCP serveri koristeći Azure API Management (eksperimentalno)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP klijent autorizacijski laboratorij](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Koristite Azure API Management ekstenziju za VS Code za uvoz i upravljanje API-jima](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Registrirajte i otkrijte udaljene MCP servere u Azure API Centeru](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Odličan repozitorij koji prikazuje mnoge AI mogućnosti s Azure API Managementom
- [AI Gateway radionice](https://azure-samples.github.io/AI-Gateway/) Sadrži radionice koristeći Azure Portal, što je izvrstan način za početak evaluacije AI mogućnosti.

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.