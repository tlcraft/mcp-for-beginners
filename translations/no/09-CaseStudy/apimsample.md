<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:33:12+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "no"
}
-->
# Case Study: Eksponer REST API i API Management som en MCP-server

Azure API Management er en tjeneste som tilbyr en gateway over API-endepunktene dine. Slik fungerer det: Azure API Management fungerer som en proxy foran API-ene dine og kan bestemme hva som skal gjøres med innkommende forespørsler.

Ved å bruke denne får du en rekke funksjoner som:

- **Sikkerhet**, du kan bruke alt fra API-nøkler, JWT til managed identity.
- **Ratebegrensning**, en flott funksjon som lar deg bestemme hvor mange kall som slipper gjennom per tidsenhet. Dette sikrer at alle brukere får en god opplevelse, samtidig som tjenesten din ikke overbelastes med forespørsler.
- **Skalering og lastbalansering**. Du kan sette opp flere endepunkter for å fordele belastningen, og du kan også bestemme hvordan lastbalanseringen skal skje.
- **AI-funksjoner som semantisk caching**, tokenbegrensning, tokenovervåking og mer. Disse funksjonene forbedrer responstiden og hjelper deg med å holde oversikt over tokenforbruket ditt. [Les mer her](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Hvorfor MCP + Azure API Management?

Model Context Protocol blir raskt en standard for agentiske AI-apper og hvordan man eksponerer verktøy og data på en konsistent måte. Azure API Management er et naturlig valg når du trenger å "administrere" API-er. MCP-servere integreres ofte med andre API-er for å løse forespørsler til et verktøy, for eksempel. Derfor gir det mye mening å kombinere Azure API Management og MCP.

## Oversikt

I dette spesifikke tilfellet skal vi lære hvordan man eksponerer API-endepunkter som en MCP-server. Ved å gjøre dette kan vi enkelt gjøre disse endepunktene til en del av en agentisk app, samtidig som vi utnytter funksjonene i Azure API Management.

## Nøkkelfunksjoner

- Du velger hvilke endepunktmetoder du vil eksponere som verktøy.
- De ekstra funksjonene du får, avhenger av hva du konfigurerer i policy-delen for API-et ditt. Her viser vi hvordan du kan legge til ratebegrensning.

## Forberedelse: importer et API

Hvis du allerede har et API i Azure API Management, flott, da kan du hoppe over dette steget. Hvis ikke, sjekk ut denne lenken, [importere et API til Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Eksponer API som MCP-server

For å eksponere API-endepunktene, følg disse stegene:

1. Gå til Azure-portalen og denne adressen <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Naviger til din API Management-instans.

1. I venstremenyen, velg APIs > MCP Servers > + Create new MCP Server.

1. Under API, velg et REST API du vil eksponere som en MCP-server.

1. Velg en eller flere API-operasjoner du vil eksponere som verktøy. Du kan velge alle operasjoner eller bare spesifikke.

    ![Velg metoder som skal eksponeres](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Velg **Create**.

1. Gå til menyvalget **APIs** og **MCP Servers**, du skal nå se følgende:

    ![Se MCP-serveren i hovedpanelet](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP-serveren er opprettet og API-operasjonene er eksponert som verktøy. MCP-serveren listes i MCP Servers-panelet. URL-kolonnen viser endepunktet til MCP-serveren som du kan kalle for testing eller i en klientapplikasjon.

## Valgfritt: Konfigurer policies

Azure API Management har et kjernebegrep som heter policies, hvor du setter opp ulike regler for endepunktene dine, for eksempel ratebegrensning eller semantisk caching. Disse policyene skrives i XML.

Slik kan du sette opp en policy for å ratebegrense MCP-serveren din:

1. I portalen, under APIs, velg **MCP Servers**.

1. Velg MCP-serveren du opprettet.

1. I venstremenyen, under MCP, velg **Policies**.

1. I policy-editoren legger du til eller redigerer policyene du vil bruke på MCP-serverens verktøy. Policyene defineres i XML-format. For eksempel kan du legge til en policy som begrenser antall kall til MCP-serverens verktøy (i dette eksempelet 5 kall per 30 sekunder per klient-IP-adresse). Her er XML som vil sette opp ratebegrensning:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Her er et bilde av policy-editoren:

    ![Policy-editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Prøv det ut

La oss sikre at MCP-serveren vår fungerer som forventet.

Til dette bruker vi Visual Studio Code og GitHub Copilot i Agent-modus. Vi legger til MCP-serveren i en *mcp.json*. På denne måten vil Visual Studio Code fungere som en klient med agentiske egenskaper, og sluttbrukere kan skrive inn en prompt og samhandle med serveren.

Slik legger du til MCP-serveren i Visual Studio Code:

1. Bruk MCP: **Add Server-kommandoen fra Command Palette**.

1. Når du blir spurt, velg servertype: **HTTP (HTTP eller Server Sent Events)**.

1. Skriv inn URL-en til MCP-serveren i API Management. Eksempel: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (for SSE-endepunkt) eller **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (for MCP-endepunkt), merk forskjellen i transporten er `/sse` eller `/mcp`.

1. Skriv inn et server-ID etter eget valg. Dette er ikke en viktig verdi, men det hjelper deg å huske hva denne serverinstansen er.

1. Velg om du vil lagre konfigurasjonen i arbeidsområdeinnstillinger eller brukerinnstillinger.

  - **Workspace settings** - Serverkonfigurasjonen lagres i en .vscode/mcp.json-fil som kun er tilgjengelig i det gjeldende arbeidsområdet.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    eller hvis du velger streaming HTTP som transport, vil det se litt annerledes ut:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User settings** - Serverkonfigurasjonen legges til i din globale *settings.json*-fil og er tilgjengelig i alle arbeidsområder. Konfigurasjonen ser omtrent slik ut:

    ![Brukerinnstilling](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Du må også legge til en konfigurasjon, en header for å sikre at autentiseringen mot Azure API Management fungerer som den skal. Den bruker en header kalt **Ocp-Apim-Subscription-Key**.

    - Slik kan du legge den til i innstillingene:

    ![Legge til header for autentisering](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), dette vil føre til at du får en prompt som ber om API-nøkkelverdien, som du finner i Azure-portalen for din Azure API Management-instans.

   - For å legge den til i *mcp.json* i stedet, kan du gjøre det slik:

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

### Bruk Agent-modus

Nå er vi klare, enten i innstillingene eller i *.vscode/mcp.json*. La oss prøve det.

Det skal være et verktøyikon som dette, hvor de eksponerte verktøyene fra serveren din listes opp:

![Verktøy fra serveren](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Klikk på verktøyikonet, og du skal se en liste over verktøy som dette:

    ![Verktøy](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Skriv inn en prompt i chatten for å kalle opp verktøyet. For eksempel, hvis du valgte et verktøy for å hente informasjon om en ordre, kan du spørre agenten om en ordre. Her er et eksempel på en prompt:

    ```text
    get information from order 2
    ```

    Du vil nå få opp et verktøyikon som spør om du vil fortsette med å kjøre verktøyet. Velg å fortsette, og du skal nå se et resultat som dette:

    ![Resultat fra prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **Det du ser over avhenger av hvilke verktøy du har satt opp, men ideen er at du får et tekstbasert svar som vist ovenfor.**


## Referanser

Slik kan du lære mer:

- [Veiledning om Azure API Management og MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python-eksempel: Sikre eksterne MCP-servere med Azure API Management (eksperimentelt)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP-klient autorisasjonslab](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Bruk Azure API Management-utvidelsen for VS Code for å importere og administrere API-er](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Registrer og oppdag eksterne MCP-servere i Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Flott repo som viser mange AI-funksjoner med Azure API Management
- [AI Gateway workshops](https://azure-samples.github.io/AI-Gateway/) Inneholder workshops som bruker Azure-portalen, en flott måte å begynne å utforske AI-funksjoner på.

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.