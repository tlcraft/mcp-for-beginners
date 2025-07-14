<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:37:07+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "ro"
}
-->
# Studiu de caz: Expunerea REST API în API Management ca server MCP

Azure API Management este un serviciu care oferă un Gateway deasupra punctelor tale finale API. Modul în care funcționează este că Azure API Management acționează ca un proxy în fața API-urilor tale și poate decide ce să facă cu cererile primite.

Folosindu-l, adaugi o mulțime de funcționalități precum:

- **Securitate**, poți folosi de la chei API, JWT până la identitate gestionată.
- **Limitarea ratei**, o funcție excelentă este să poți decide câte apeluri trec într-o anumită unitate de timp. Acest lucru ajută să te asiguri că toți utilizatorii au o experiență bună și că serviciul tău nu este copleșit de cereri.
- **Scalare și echilibrare a încărcării**. Poți configura mai multe puncte finale pentru a distribui încărcarea și poți decide cum să faci „load balancing”.
- **Funcții AI precum caching semantic**, limită de tokeni și monitorizarea tokenilor și altele. Acestea sunt funcții excelente care îmbunătățesc timpul de răspuns și te ajută să ții evidența consumului de tokeni. [Citește mai multe aici](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## De ce MCP + Azure API Management?

Model Context Protocol devine rapid un standard pentru aplicațiile AI agentice și modul de expunere a uneltelor și datelor într-un mod consecvent. Azure API Management este o alegere naturală atunci când ai nevoie să „gestionezi” API-uri. Serverele MCP se integrează adesea cu alte API-uri pentru a rezolva cereri către un instrument, de exemplu. Prin urmare, combinarea Azure API Management cu MCP are mult sens.

## Prezentare generală

În acest caz de utilizare specific, vom învăța cum să expunem punctele finale API ca un server MCP. Astfel, putem face cu ușurință aceste puncte finale parte dintr-o aplicație agentică, beneficiind totodată de funcționalitățile Azure API Management.

## Funcționalități cheie

- Selectezi metodele endpoint pe care vrei să le expui ca unelte.
- Funcționalitățile suplimentare depind de ce configurezi în secțiunea de politici pentru API-ul tău. Dar aici îți vom arăta cum să adaugi limitarea ratei.

## Pas preliminar: importă un API

Dacă ai deja un API în Azure API Management, perfect, poți sări peste acest pas. Dacă nu, consultă acest link, [importarea unui API în Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Expunerea API-ului ca server MCP

Pentru a expune punctele finale API, urmează acești pași:

1. Accesează Azure Portal la adresa <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Navighează la instanța ta de API Management.

1. În meniul din stânga, selectează APIs > MCP Servers > + Create new MCP Server.

1. La API, selectează un REST API pe care vrei să-l expui ca server MCP.

1. Selectează una sau mai multe operațiuni API pe care vrei să le expui ca unelte. Poți selecta toate operațiunile sau doar anumite operațiuni.

    ![Selectează metodele de expus](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Selectează **Create**.

1. Navighează la opțiunea de meniu **APIs** și **MCP Servers**, ar trebui să vezi următorul ecran:

    ![Vezi serverul MCP în panoul principal](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    Serverul MCP este creat iar operațiunile API sunt expuse ca unelte. Serverul MCP este listat în panoul MCP Servers. Coloana URL arată endpoint-ul serverului MCP pe care îl poți apela pentru testare sau dintr-o aplicație client.

## Opțional: Configurarea politicilor

Azure API Management are conceptul central de politici, unde setezi reguli diferite pentru punctele tale finale, cum ar fi limitarea ratei sau caching semantic. Aceste politici sunt scrise în XML.

Iată cum poți configura o politică pentru a limita rata serverului MCP:

1. În portal, sub APIs, selectează **MCP Servers**.

1. Selectează serverul MCP creat.

1. În meniul din stânga, sub MCP, selectează **Policies**.

1. În editorul de politici, adaugă sau modifică politicile pe care vrei să le aplici uneltelor serverului MCP. Politicile sunt definite în format XML. De exemplu, poți adăuga o politică pentru a limita apelurile către uneltele serverului MCP (în acest exemplu, 5 apeluri la 30 de secunde per adresă IP client). Iată XML-ul care va face limitarea:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Iată o imagine cu editorul de politici:

    ![Editor de politici](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Testează

Să ne asigurăm că serverul MCP funcționează conform așteptărilor.

Pentru asta vom folosi Visual Studio Code și GitHub Copilot în modul Agent. Vom adăuga serverul MCP într-un fișier *mcp.json*. Astfel, Visual Studio Code va acționa ca un client cu capabilități agentice, iar utilizatorii finali vor putea introduce un prompt și interacționa cu serverul respectiv.

Iată cum să adaugi serverul MCP în Visual Studio Code:

1. Folosește comanda MCP: **Add Server din Command Palette**.

1. Când ți se cere, selectează tipul serverului: **HTTP (HTTP sau Server Sent Events)**.

1. Introdu URL-ul serverului MCP din API Management. Exemplu: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (pentru endpoint SSE) sau **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (pentru endpoint MCP), observă diferența între transporturi: `/sse` sau `/mcp`.

1. Introdu un ID pentru server, după preferință. Nu este o valoare importantă, dar te va ajuta să-ți amintești ce instanță de server este.

1. Selectează dacă vrei să salvezi configurația în setările workspace-ului sau în setările utilizatorului.

  - **Workspace settings** - Configurația serverului este salvată într-un fișier .vscode/mcp.json disponibil doar în workspace-ul curent.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    sau dacă alegi streaming HTTP ca transport, va arăta puțin diferit:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User settings** - Configurația serverului este adăugată în fișierul global *settings.json* și este disponibilă în toate workspace-urile. Configurația arată similar cu următorul exemplu:

    ![Setare utilizator](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. De asemenea, trebuie să adaugi o configurație, un header pentru a te asigura că autentificarea către Azure API Management funcționează corect. Se folosește un header numit **Ocp-Apim-Subscription-Key**.

    - Iată cum îl poți adăuga în setări:

    ![Adăugarea header-ului pentru autentificare](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), acest lucru va face să apară un prompt care îți va cere valoarea cheii API, pe care o poți găsi în Azure Portal pentru instanța ta Azure API Management.

   - Pentru a-l adăuga în *mcp.json*, îl poți adăuga astfel:

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

### Folosește modul Agent

Acum că totul este configurat fie în setări, fie în *.vscode/mcp.json*, să testăm.

Ar trebui să existe o pictogramă Tools ca în imaginea de mai jos, unde sunt listate uneltele expuse de serverul tău:

![Unelte de la server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Apasă pe pictograma tools și ar trebui să vezi o listă de unelte astfel:

    ![Unelte](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Introdu un prompt în chat pentru a apela o unealtă. De exemplu, dacă ai selectat o unealtă pentru a obține informații despre o comandă, poți întreba agentul despre o comandă. Iată un exemplu de prompt:

    ```text
    get information from order 2
    ```

    Acum ți se va afișa o pictogramă tools care te va întreba dacă vrei să continui apelarea uneltei. Selectează să continui rularea uneltei, iar apoi ar trebui să vezi un rezultat astfel:

    ![Rezultat din prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **ce vezi mai sus depinde de uneltele pe care le-ai configurat, dar ideea este că primești un răspuns textual ca în exemplul de mai sus**


## Referințe

Iată cum poți afla mai multe:

- [Tutorial despre Azure API Management și MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Exemplu Python: Servere MCP remote securizate folosind Azure API Management (experimental)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Laborator de autorizare client MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Folosește extensia Azure API Management pentru VS Code pentru a importa și gestiona API-uri](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Înregistrează și descoperă servere MCP remote în Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Un repo excelent care arată multe capabilități AI cu Azure API Management
- [Ateliere AI Gateway](https://azure-samples.github.io/AI-Gateway/) Conține ateliere folosind Azure Portal, o metodă excelentă de a începe evaluarea capabilităților AI.

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.