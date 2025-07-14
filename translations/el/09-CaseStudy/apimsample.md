<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:31:52+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "el"
}
-->
# Μελέτη Περίπτωσης: Έκθεση REST API στο API Management ως MCP server

Το Azure API Management είναι μια υπηρεσία που παρέχει μια Πύλη πάνω από τα API Endpoints σας. Ο τρόπος λειτουργίας του είναι ότι το Azure API Management λειτουργεί ως μεσολαβητής μπροστά από τα APIs σας και μπορεί να αποφασίσει τι θα κάνει με τα εισερχόμενα αιτήματα.

Χρησιμοποιώντας το, προσθέτετε μια σειρά από λειτουργίες όπως:

- **Ασφάλεια**, μπορείτε να χρησιμοποιήσετε από API keys, JWT μέχρι managed identity.
- **Περιορισμός ρυθμού κλήσεων (Rate limiting)**, μια εξαιρετική λειτουργία που σας επιτρέπει να αποφασίσετε πόσες κλήσεις επιτρέπονται ανά μονάδα χρόνου. Αυτό βοηθά να διασφαλιστεί ότι όλοι οι χρήστες έχουν μια καλή εμπειρία και επίσης ότι η υπηρεσία σας δεν υπερφορτώνεται με αιτήματα.
- **Κλιμάκωση & Ισορροπία φορτίου**. Μπορείτε να ρυθμίσετε πολλαπλά endpoints για να ισορροπήσετε το φορτίο και να αποφασίσετε πώς θα γίνει αυτή η "ισορροπία φορτίου".
- **Λειτουργίες AI όπως semantic caching**, όριο tokens και παρακολούθηση tokens και άλλα. Αυτές είναι εξαιρετικές λειτουργίες που βελτιώνουν την ανταπόκριση και σας βοηθούν να έχετε έλεγχο στην κατανάλωση των tokens σας. [Διαβάστε περισσότερα εδώ](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Γιατί MCP + Azure API Management;

Το Model Context Protocol γίνεται γρήγορα ένα πρότυπο για agentic AI εφαρμογές και για το πώς να εκθέτεις εργαλεία και δεδομένα με συνεπή τρόπο. Το Azure API Management είναι η φυσική επιλογή όταν χρειάζεται να "διαχειριστείτε" APIs. Οι MCP Servers συχνά ενσωματώνονται με άλλα APIs για να επιλύουν αιτήματα προς ένα εργαλείο, για παράδειγμα. Επομένως, ο συνδυασμός Azure API Management και MCP έχει πολύ νόημα.

## Επισκόπηση

Σε αυτή την συγκεκριμένη περίπτωση χρήσης θα μάθουμε πώς να εκθέτουμε API endpoints ως MCP Server. Με αυτόν τον τρόπο, μπορούμε εύκολα να ενσωματώσουμε αυτά τα endpoints σε μια agentic εφαρμογή ενώ παράλληλα αξιοποιούμε τις λειτουργίες του Azure API Management.

## Κύρια Χαρακτηριστικά

- Επιλέγετε τις μεθόδους endpoint που θέλετε να εκθέσετε ως εργαλεία.
- Οι επιπλέον λειτουργίες που λαμβάνετε εξαρτώνται από το τι ρυθμίζετε στην ενότητα πολιτικών (policy) για το API σας. Εδώ θα δείξουμε πώς να προσθέσετε περιορισμό ρυθμού κλήσεων.

## Προκαταρκτικό βήμα: εισαγωγή ενός API

Αν έχετε ήδη ένα API στο Azure API Management, υπέροχα, τότε μπορείτε να παραλείψετε αυτό το βήμα. Αν όχι, δείτε αυτόν τον σύνδεσμο, [εισαγωγή API στο Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Έκθεση API ως MCP Server

Για να εκθέσουμε τα API endpoints, ας ακολουθήσουμε τα παρακάτω βήματα:

1. Μεταβείτε στο Azure Portal στη διεύθυνση <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Πλοηγηθείτε στην περίπτωση API Management σας.

1. Στο αριστερό μενού, επιλέξτε APIs > MCP Servers > + Δημιουργία νέου MCP Server.

1. Στο API, επιλέξτε ένα REST API για να εκθέσετε ως MCP server.

1. Επιλέξτε μία ή περισσότερες API Operations για να εκθέσετε ως εργαλεία. Μπορείτε να επιλέξετε όλες τις λειτουργίες ή μόνο συγκεκριμένες.

    ![Επιλογή μεθόδων για έκθεση](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Επιλέξτε **Δημιουργία**.

1. Μεταβείτε στην επιλογή μενού **APIs** και **MCP Servers**, θα δείτε το εξής:

    ![Προβολή MCP Server στο κύριο παράθυρο](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    Ο MCP server έχει δημιουργηθεί και οι API λειτουργίες εκτίθενται ως εργαλεία. Ο MCP server εμφανίζεται στον πίνακα MCP Servers. Η στήλη URL δείχνει το endpoint του MCP server που μπορείτε να καλέσετε για δοκιμές ή μέσα σε μια εφαρμογή πελάτη.

## Προαιρετικό: Ρύθμιση πολιτικών

Το Azure API Management έχει την βασική έννοια των πολιτικών (policies), όπου ορίζετε διαφορετικούς κανόνες για τα endpoints σας, όπως για παράδειγμα περιορισμό ρυθμού κλήσεων ή semantic caching. Αυτές οι πολιτικές γράφονται σε XML.

Δείτε πώς μπορείτε να ρυθμίσετε μια πολιτική για περιορισμό ρυθμού κλήσεων στο MCP Server σας:

1. Στο portal, κάτω από APIs, επιλέξτε **MCP Servers**.

1. Επιλέξτε τον MCP server που δημιουργήσατε.

1. Στο αριστερό μενού, κάτω από MCP, επιλέξτε **Policies**.

1. Στον επεξεργαστή πολιτικών, προσθέστε ή επεξεργαστείτε τις πολιτικές που θέλετε να εφαρμόσετε στα εργαλεία του MCP server. Οι πολιτικές ορίζονται σε μορφή XML. Για παράδειγμα, μπορείτε να προσθέσετε μια πολιτική που περιορίζει τις κλήσεις στα εργαλεία του MCP server (σε αυτό το παράδειγμα, 5 κλήσεις ανά 30 δευτερόλεπτα ανά διεύθυνση IP πελάτη). Ακολουθεί το XML που θα προκαλέσει τον περιορισμό ρυθμού:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Εδώ μια εικόνα του επεξεργαστή πολιτικών:

    ![Επεξεργαστής πολιτικών](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Δοκιμάστε το

Ας βεβαιωθούμε ότι ο MCP Server μας λειτουργεί όπως πρέπει.

Για αυτό, θα χρησιμοποιήσουμε το Visual Studio Code και το GitHub Copilot με τη λειτουργία Agent mode. Θα προσθέσουμε τον MCP server σε ένα αρχείο *mcp.json*. Με αυτόν τον τρόπο, το Visual Studio Code θα λειτουργεί ως πελάτης με agentic δυνατότητες και οι τελικοί χρήστες θα μπορούν να πληκτρολογούν εντολές και να αλληλεπιδρούν με τον server.

Δείτε πώς να προσθέσετε τον MCP server στο Visual Studio Code:

1. Χρησιμοποιήστε την εντολή MCP: **Add Server από το Command Palette**.

1. Όταν σας ζητηθεί, επιλέξτε τον τύπο server: **HTTP (HTTP ή Server Sent Events)**.

1. Εισάγετε το URL του MCP server στο API Management. Παράδειγμα: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (για SSE endpoint) ή **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (για MCP endpoint), σημειώστε τη διαφορά στα transports που είναι `/sse` ή `/mcp`.

1. Εισάγετε ένα server ID της επιλογής σας. Δεν είναι σημαντική τιμή, αλλά θα σας βοηθήσει να θυμάστε ποια περίπτωση server είναι αυτή.

1. Επιλέξτε αν θέλετε να αποθηκεύσετε τη ρύθμιση στα workspace settings ή στα user settings.

  - **Workspace settings** - Η ρύθμιση του server αποθηκεύεται σε αρχείο .vscode/mcp.json που είναι διαθέσιμο μόνο στο τρέχον workspace.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    ή αν επιλέξετε streaming HTTP ως transport, θα είναι ελαφρώς διαφορετικό:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User settings** - Η ρύθμιση του server προστίθεται στο παγκόσμιο αρχείο *settings.json* και είναι διαθέσιμη σε όλα τα workspaces. Η ρύθμιση μοιάζει με την παρακάτω:

    ![User setting](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Πρέπει επίσης να προσθέσετε μια ρύθμιση, ένα header για να βεβαιωθείτε ότι γίνεται σωστή αυθεντικοποίηση προς το Azure API Management. Χρησιμοποιεί ένα header που ονομάζεται **Ocp-Apim-Subscription-Key**.

    - Δείτε πώς να το προσθέσετε στα settings:

    ![Προσθήκη header για αυθεντικοποίηση](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), αυτό θα εμφανίσει ένα prompt που θα σας ζητήσει την τιμή του API key, την οποία μπορείτε να βρείτε στο Azure Portal για την περίπτωση Azure API Management σας.

   - Για να το προσθέσετε στο *mcp.json* αντί αυτού, μπορείτε να το κάνετε ως εξής:

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

### Χρήση Agent mode

Τώρα που έχουμε ρυθμιστεί είτε στα settings είτε στο *.vscode/mcp.json*, ας το δοκιμάσουμε.

Θα πρέπει να υπάρχει ένα εικονίδιο Εργαλείων (Tools) όπως το παρακάτω, όπου εμφανίζονται τα εργαλεία που εκθέτει ο server σας:

![Εργαλεία από τον server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Κάντε κλικ στο εικονίδιο εργαλείων και θα δείτε μια λίστα με εργαλεία όπως η παρακάτω:

    ![Εργαλεία](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Πληκτρολογήστε μια εντολή στο chat για να καλέσετε το εργαλείο. Για παράδειγμα, αν επιλέξατε ένα εργαλείο για να λάβετε πληροφορίες για μια παραγγελία, μπορείτε να ρωτήσετε τον agent για μια παραγγελία. Ακολουθεί ένα παράδειγμα εντολής:

    ```text
    get information from order 2
    ```

    Τώρα θα εμφανιστεί ένα εικονίδιο εργαλείων που θα σας ζητά να συνεχίσετε με την κλήση του εργαλείου. Επιλέξτε να συνεχίσετε την εκτέλεση του εργαλείου, και θα δείτε ένα αποτέλεσμα όπως το παρακάτω:

    ![Αποτέλεσμα από την εντολή](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **Αυτό που βλέπετε παραπάνω εξαρτάται από τα εργαλεία που έχετε ρυθμίσει, αλλά η ιδέα είναι ότι λαμβάνετε μια κειμενική απάντηση όπως παραπάνω**


## Αναφορές

Δείτε πώς μπορείτε να μάθετε περισσότερα:

- [Οδηγός για Azure API Management και MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Παράδειγμα Python: Ασφαλείς απομακρυσμένοι MCP servers με χρήση Azure API Management (πειραματικό)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Εργαστήριο εξουσιοδότησης πελάτη MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Χρήση της επέκτασης Azure API Management για VS Code για εισαγωγή και διαχείριση APIs](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Καταχώρηση και ανακάλυψη απομακρυσμένων MCP servers στο Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Εξαιρετικό αποθετήριο που παρουσιάζει πολλές δυνατότητες AI με Azure API Management
- [Εργαστήρια AI Gateway](https://azure-samples.github.io/AI-Gateway/) Περιέχει εργαστήρια με χρήση Azure Portal, που είναι ένας πολύ καλός τρόπος να ξεκινήσετε την αξιολόγηση δυνατοτήτων AI.

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.