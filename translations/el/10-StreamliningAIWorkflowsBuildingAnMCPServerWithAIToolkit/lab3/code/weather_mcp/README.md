<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:30:35+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "el"
}
-->
# Weather MCP Server

Αυτός είναι ένας δείγμα MCP Server σε Python που υλοποιεί εργαλεία καιρού με ψεύτικες απαντήσεις. Μπορεί να χρησιμοποιηθεί ως βάση για τον δικό σας MCP Server. Περιλαμβάνει τις εξής λειτουργίες:

- **Weather Tool**: Ένα εργαλείο που παρέχει ψεύτικες πληροφορίες καιρού βάσει της δοθείσας τοποθεσίας.
- **Σύνδεση με Agent Builder**: Μια λειτουργία που σας επιτρέπει να συνδέσετε τον MCP server με τον Agent Builder για δοκιμές και εντοπισμό σφαλμάτων.
- **Debug στο [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Μια λειτουργία που σας επιτρέπει να κάνετε debug τον MCP Server χρησιμοποιώντας το MCP Inspector.

## Ξεκινώντας με το πρότυπο Weather MCP Server

> **Προαπαιτούμενα**
>
> Για να τρέξετε τον MCP Server στον τοπικό σας υπολογιστή ανάπτυξης, θα χρειαστείτε:
>
> - [Python](https://www.python.org/)
> - (*Προαιρετικά - αν προτιμάτε uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Προετοιμασία περιβάλλοντος

Υπάρχουν δύο τρόποι για να ρυθμίσετε το περιβάλλον για αυτό το έργο. Μπορείτε να επιλέξετε οποιονδήποτε ανάλογα με τις προτιμήσεις σας.

> Σημείωση: Κάντε επαναφόρτωση του VSCode ή του τερματικού για να βεβαιωθείτε ότι χρησιμοποιείται η python του virtual περιβάλλοντος μετά τη δημιουργία του.

| Τρόπος | Βήματα |
| -------- | ----- |
| Χρήση `uv` | 1. Δημιουργήστε virtual περιβάλλον: `uv venv` <br>2. Εκτελέστε την εντολή του VSCode "***Python: Select Interpreter***" και επιλέξτε την python από το δημιουργημένο virtual περιβάλλον <br>3. Εγκαταστήστε τις εξαρτήσεις (συμπεριλαμβανομένων των εξαρτήσεων ανάπτυξης): `uv pip install -r pyproject.toml --extra dev` |
| Χρήση `pip` | 1. Δημιουργήστε virtual περιβάλλον: `python -m venv .venv` <br>2. Εκτελέστε την εντολή του VSCode "***Python: Select Interpreter***" και επιλέξτε την python από το δημιουργημένο virtual περιβάλλον<br>3. Εγκαταστήστε τις εξαρτήσεις (συμπεριλαμβανομένων των εξαρτήσεων ανάπτυξης): `pip install -e .[dev]` |

Αφού ρυθμίσετε το περιβάλλον, μπορείτε να τρέξετε τον server στον τοπικό σας υπολογιστή ανάπτυξης μέσω του Agent Builder ως MCP Client για να ξεκινήσετε:
1. Ανοίξτε το πάνελ Debug του VS Code. Επιλέξτε `Debug in Agent Builder` ή πατήστε `F5` για να ξεκινήσετε το debugging του MCP server.
2. Χρησιμοποιήστε το AI Toolkit Agent Builder για να δοκιμάσετε τον server με [αυτό το prompt](../../../../../../../../../../../open_prompt_builder). Ο server θα συνδεθεί αυτόματα με τον Agent Builder.
3. Πατήστε `Run` για να δοκιμάσετε τον server με το prompt.

**Συγχαρητήρια**! Έχετε τρέξει επιτυχώς τον Weather MCP Server στον τοπικό σας υπολογιστή ανάπτυξης μέσω του Agent Builder ως MCP Client.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Τι περιλαμβάνει το πρότυπο

| Φάκελος / Αρχείο | Περιεχόμενο |
| ------------ | -------------------------------------------- |
| `.vscode`    | Αρχεία VSCode για debugging                   |
| `.aitk`      | Ρυθμίσεις για το AI Toolkit                |
| `src`        | Ο πηγαίος κώδικας του weather mcp server   |

## Πώς να κάνετε debug τον Weather MCP Server

> Σημειώσεις:
> - Το [MCP Inspector](https://github.com/modelcontextprotocol/inspector) είναι ένα οπτικό εργαλείο για προγραμματιστές για δοκιμές και debugging MCP servers.
> - Όλοι οι τρόποι debugging υποστηρίζουν breakpoints, οπότε μπορείτε να προσθέσετε breakpoints στον κώδικα υλοποίησης των εργαλείων.

| Τρόπος Debug | Περιγραφή | Βήματα για debug |
| ---------- | ----------- | --------------- |
| Agent Builder | Κάντε debug τον MCP server στον Agent Builder μέσω του AI Toolkit. | 1. Ανοίξτε το πάνελ Debug του VS Code. Επιλέξτε `Debug in Agent Builder` και πατήστε `F5` για να ξεκινήσετε το debugging του MCP server.<br>2. Χρησιμοποιήστε το AI Toolkit Agent Builder για να δοκιμάσετε τον server με [αυτό το prompt](../../../../../../../../../../../open_prompt_builder). Ο server θα συνδεθεί αυτόματα με τον Agent Builder.<br>3. Πατήστε `Run` για να δοκιμάσετε τον server με το prompt. |
| MCP Inspector | Κάντε debug τον MCP server χρησιμοποιώντας το MCP Inspector. | 1. Εγκαταστήστε [Node.js](https://nodejs.org/)<br> 2. Ρυθμίστε το Inspector: `cd inspector` && `npm install` <br> 3. Ανοίξτε το πάνελ Debug του VS Code. Επιλέξτε `Debug SSE in Inspector (Edge)` ή `Debug SSE in Inspector (Chrome)`. Πατήστε F5 για να ξεκινήσετε το debugging.<br> 4. Όταν το MCP Inspector ανοίξει στο πρόγραμμα περιήγησης, πατήστε το κουμπί `Connect` για να συνδέσετε αυτόν τον MCP server.<br> 5. Στη συνέχεια μπορείτε να `List Tools`, να επιλέξετε ένα εργαλείο, να εισάγετε παραμέτρους και να `Run Tool` για να κάνετε debug τον κώδικα του server.<br> |

## Προεπιλεγμένες θύρες και προσαρμογές

| Τρόπος Debug | Θύρες | Ορισμοί | Προσαρμογές | Σημείωση |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Επεξεργαστείτε τα [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) για να αλλάξετε τις παραπάνω θύρες. | Δεν ισχύει |
| MCP Inspector | 3001 (Server); 5173 και 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | Επεξεργαστείτε τα [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) για να αλλάξετε τις παραπάνω θύρες.| Δεν ισχύει |

## Ανατροφοδότηση

Αν έχετε οποιαδήποτε ανατροφοδότηση ή προτάσεις για αυτό το πρότυπο, παρακαλούμε ανοίξτε ένα issue στο [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν σφάλματα ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η επίσημη πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική μετάφραση από ανθρώπους. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.