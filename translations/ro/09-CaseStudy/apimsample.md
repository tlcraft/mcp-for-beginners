<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2228721599c0c8673de83496b4d7d7a9",
  "translation_date": "2025-08-18T15:47:16+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "ro"
}
-->
# Studiu de caz: Expunerea unei API REST în API Management ca server MCP

Azure API Management este un serviciu care oferă un Gateway deasupra punctelor finale ale API-urilor tale. Funcționează ca un proxy în fața API-urilor tale și poate decide ce să facă cu cererile primite.

Prin utilizarea acestuia, adaugi o gamă largă de funcționalități precum:

- **Securitate**, poți utiliza totul, de la chei API, JWT, până la identitate gestionată.
- **Limitarea ratei**, o funcționalitate excelentă este abilitatea de a decide câte apeluri sunt permise într-o anumită unitate de timp. Acest lucru ajută la asigurarea unei experiențe bune pentru toți utilizatorii și previne supraîncărcarea serviciului tău cu cereri.
- **Scalare și echilibrare a încărcării**. Poți configura mai multe puncte finale pentru a distribui încărcarea și poți decide cum să "echilibrezi încărcarea".
- **Funcționalități AI precum caching semantic**, limitarea token-urilor, monitorizarea token-urilor și altele. Acestea sunt funcționalități excelente care îmbunătățesc receptivitatea și te ajută să gestionezi consumul de token-uri. [Citește mai multe aici](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## De ce MCP + Azure API Management?

Model Context Protocol devine rapid un standard pentru aplicațiile AI agentice și pentru expunerea instrumentelor și datelor într-un mod consistent. Azure API Management este o alegere naturală atunci când ai nevoie să "gestionezi" API-uri. Serverele MCP se integrează adesea cu alte API-uri pentru a rezolva cereri către un instrument, de exemplu. Prin urmare, combinarea Azure API Management și MCP are mult sens.

## Prezentare generală

În acest caz specific, vom învăța cum să expunem punctele finale ale API-urilor ca un server MCP. Procedând astfel, putem integra cu ușurință aceste puncte finale într-o aplicație agentică, beneficiind în același timp de funcționalitățile oferite de Azure API Management.

## Funcționalități cheie

- Poți selecta metodele punctelor finale pe care dorești să le expui ca instrumente.
- Funcționalitățile suplimentare pe care le obții depind de ceea ce configurezi în secțiunea de politici pentru API-ul tău. Aici vom arăta cum poți adăuga limitarea ratei.

## Pas preliminar: importarea unui API

Dacă ai deja un API în Azure API Management, excelent, poți sări peste acest pas. Dacă nu, consultă acest link: [importarea unui API în Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Expunerea unui API ca server MCP

Pentru a expune punctele finale ale API-ului, urmează acești pași:

1. Accesează portalul Azure la adresa <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>. Navighează la instanța ta de API Management.

1. În meniul din stânga, selectează **APIs > MCP Servers > + Create new MCP Server**.

1. În API, selectează un API REST pe care dorești să-l expui ca server MCP.

1. Selectează una sau mai multe operațiuni ale API-ului pe care dorești să le expui ca instrumente. Poți selecta toate operațiunile sau doar anumite operațiuni.

    ![Selectează metodele de expus](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Selectează **Create**.

1. Navighează la opțiunea de meniu **APIs** și **MCP Servers**, ar trebui să vezi următoarele:

    ![Vezi serverul MCP în panoul principal](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    Serverul MCP este creat, iar operațiunile API-ului sunt expuse ca instrumente. Serverul MCP este listat în panoul MCP Servers. Coloana URL afișează punctul final al serverului MCP pe care îl poți apela pentru testare sau în cadrul unei aplicații client.

## Opțional: Configurarea politicilor

Azure API Management are conceptul de bază al politicilor, unde configurezi reguli diferite pentru punctele tale finale, cum ar fi limitarea ratei sau caching semantic. Aceste politici sunt scrise în format XML.

Iată cum poți configura o politică pentru a limita rata serverului MCP:

1. În portal, sub **APIs**, selectează **MCP Servers**.

1. Selectează serverul MCP pe care l-ai creat.

1. În meniul din stânga, sub MCP, selectează **Policies**.

1. În editorul de politici, adaugă sau editează politicile pe care dorești să le aplici instrumentelor serverului MCP. Politicile sunt definite în format XML. De exemplu, poți adăuga o politică pentru a limita apelurile către instrumentele serverului MCP (în acest exemplu, 5 apeluri la fiecare 30 de secunde per adresă IP a clientului). Iată XML-ul care va cauza limitarea ratei:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Iată o imagine a editorului de politici:

    ![Editor de politici](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)

## Testare

Să ne asigurăm că serverul MCP funcționează conform așteptărilor.

Pentru aceasta, vom folosi Visual Studio Code și GitHub Copilot în modul Agent. Vom adăuga serverul MCP într-un fișier *mcp.json*. Procedând astfel, Visual Studio Code va acționa ca un client cu capabilități agentice, iar utilizatorii finali vor putea introduce un prompt și interacționa cu serverul.

Iată cum să adaugi serverul MCP în Visual Studio Code:

1. Folosește comanda MCP: **Add Server din Command Palette**.

1. Când ți se cere, selectează tipul de server: **HTTP (HTTP sau Server Sent Events)**.

1. Introdu URL-ul serverului MCP din API Management. Exemplu: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (pentru endpoint SSE) sau **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (pentru endpoint MCP), observă diferența dintre transporturi: `/sse` sau `/mcp`.

1. Introdu un ID de server la alegerea ta. Aceasta nu este o valoare importantă, dar te va ajuta să-ți amintești ce reprezintă această instanță de server.

1. Selectează dacă să salvezi configurația în setările workspace-ului sau în setările utilizatorului.

  - **Setările workspace-ului** - Configurația serverului este salvată într-un fișier .vscode/mcp.json disponibil doar în workspace-ul curent.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    sau dacă alegi HTTP streaming ca transport, ar fi ușor diferit:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Setările utilizatorului** - Configurația serverului este adăugată în fișierul global *settings.json* și este disponibilă în toate workspace-urile. Configurația arată similar cu următoarele:

    ![Setare utilizator](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. De asemenea, trebuie să adaugi o configurație, un header pentru a te asigura că autentificarea funcționează corect cu Azure API Management. Se folosește un header numit **Ocp-Apim-Subscription-Key**.

    - Iată cum îl poți adăuga în setări:

    ![Adăugarea header-ului pentru autentificare](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), acest lucru va afișa un prompt pentru a introduce valoarea cheii API, pe care o poți găsi în portalul Azure pentru instanța ta Azure API Management.

   - Pentru a-l adăuga în *mcp.json*, poți face acest lucru astfel:

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

### Utilizarea modului Agent

Acum suntem pregătiți, fie în setări, fie în *.vscode/mcp.json*. Să încercăm.

Ar trebui să existe o pictogramă Tools, unde sunt listate instrumentele expuse de serverul tău:

![Instrumente de la server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Fă clic pe pictograma instrumentelor și ar trebui să vezi o listă de instrumente astfel:

    ![Instrumente](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Introdu un prompt în chat pentru a invoca instrumentul. De exemplu, dacă ai selectat un instrument pentru a obține informații despre o comandă, poți întreba agentul despre o comandă. Iată un exemplu de prompt:

    ```text
    get information from order 2
    ```

    Acum vei fi prezentat cu o pictogramă de instrument care îți cere să continui apelarea unui instrument. Selectează să continui rularea instrumentului, iar acum ar trebui să vezi un rezultat astfel:

    ![Rezultat din prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **ceea ce vezi mai sus depinde de instrumentele pe care le-ai configurat, dar ideea este că primești un răspuns textual ca cel de mai sus**

## Referințe

Iată cum poți afla mai multe:

- [Tutorial despre Azure API Management și MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Exemplu Python: Securizarea serverelor MCP remote folosind Azure API Management (experimental)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Laborator de autorizare client MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Utilizarea extensiei Azure API Management pentru VS Code pentru a importa și gestiona API-uri](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Înregistrarea și descoperirea serverelor MCP remote în Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Un repo excelent care arată multe capabilități AI cu Azure API Management
- [Workshop-uri AI Gateway](https://azure-samples.github.io/AI-Gateway/) Conține workshop-uri folosind portalul Azure, o modalitate excelentă de a începe evaluarea capabilităților AI.

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.