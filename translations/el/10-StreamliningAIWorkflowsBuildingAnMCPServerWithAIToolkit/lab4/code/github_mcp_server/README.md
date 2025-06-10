<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:10:42+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "el"
}
-->
# Weather MCP Server

Αυτός είναι ένας δείγμα MCP Server σε Python που υλοποιεί εργαλεία καιρού με ψεύτικες απαντήσεις. Μπορεί να χρησιμοποιηθεί ως βάση για τον δικό σας MCP Server. Περιλαμβάνει τα εξής χαρακτηριστικά:

- **Weather Tool**: Ένα εργαλείο που παρέχει ψεύτικες πληροφορίες καιρού με βάση την τοποθεσία που δίνεται.
- **Git Clone Tool**: Ένα εργαλείο που κλωνοποιεί ένα αποθετήριο git σε έναν συγκεκριμένο φάκελο.
- **VS Code Open Tool**: Ένα εργαλείο που ανοίγει φάκελο στο VS Code ή VS Code Insiders.
- **Connect to Agent Builder**: Μια λειτουργία που επιτρέπει τη σύνδεση του MCP server με τον Agent Builder για δοκιμές και αποσφαλμάτωση.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Μια λειτουργία που επιτρέπει την αποσφαλμάτωση του MCP Server χρησιμοποιώντας τον MCP Inspector.

## Ξεκινώντας με το πρότυπο Weather MCP Server

> **Προαπαιτούμενα**
>
> Για να τρέξετε τον MCP Server στον τοπικό σας υπολογιστή ανάπτυξης, θα χρειαστείτε:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (Απαραίτητο για το εργαλείο git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) ή [VS Code Insiders](https://code.visualstudio.com/insiders/) (Απαραίτητο για το εργαλείο open_in_vscode)
> - (*Προαιρετικό - αν προτιμάτε uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Προετοιμασία περιβάλλοντος

Υπάρχουν δύο τρόποι για να ρυθμίσετε το περιβάλλον για αυτό το έργο. Μπορείτε να επιλέξετε όποιον προτιμάτε.

> Σημείωση: Κάντε επανεκκίνηση του VSCode ή του τερματικού για να βεβαιωθείτε ότι χρησιμοποιείται το python του virtual environment μετά τη δημιουργία του.

| Τρόπος | Βήματα |
| -------- | ----- |
| Χρήση `uv` | 1. Δημιουργία virtual environment: `uv venv` <br>2. Εκτελέστε την εντολή VSCode "***Python: Select Interpreter***" και επιλέξτε το python από το δημιουργημένο virtual environment <br>3. Εγκαταστήστε τις εξαρτήσεις (συμπεριλαμβανομένων των dev dependencies): `uv pip install -r pyproject.toml --extra dev` |
| Χρήση `pip` | 1. Δημιουργία virtual environment: `python -m venv .venv` <br>2. Εκτελέστε την εντολή VSCode "***Python: Select Interpreter***" και επιλέξτε το python από το δημιουργημένο virtual environment<br>3. Εγκαταστήστε τις εξαρτήσεις (συμπεριλαμβανομένων των dev dependencies): `pip install -e .[dev]` |

Αφού ρυθμίσετε το περιβάλλον, μπορείτε να τρέξετε τον server στον τοπικό σας υπολογιστή μέσω Agent Builder ως MCP Client για να ξεκινήσετε:
1. Ανοίξτε το πάνελ αποσφαλμάτωσης του VS Code. Επιλέξτε `Debug in Agent Builder` ή πατήστε `F5` για να ξεκινήσετε την αποσφαλμάτωση του MCP server.
2. Χρησιμοποιήστε το AI Toolkit Agent Builder για να δοκιμάσετε τον server με [αυτό το prompt](../../../../../../../../../../../open_prompt_builder). Ο server θα συνδεθεί αυτόματα με τον Agent Builder.
3. Κάντε κλικ στο `Run` για να δοκιμάσετε τον server με το prompt.

**Συγχαρητήρια**! Έχετε τρέξει επιτυχώς τον Weather MCP Server στον τοπικό σας υπολογιστή μέσω Agent Builder ως MCP Client.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## Τι περιλαμβάνει το πρότυπο

| Φάκελος / Αρχείο | Περιεχόμενα                               |
| ------------ | ---------------------------------------- |
| `.vscode`    | Αρχεία VSCode για αποσφαλμάτωση           |
| `.aitk`      | Ρυθμίσεις για το AI Toolkit                |
| `src`        | Ο πηγαίος κώδικας για τον weather mcp server |

## Πώς να αποσφαλματώσετε τον Weather MCP Server

> Σημειώσεις:
> - Το [MCP Inspector](https://github.com/modelcontextprotocol/inspector) είναι ένα οπτικό εργαλείο ανάπτυξης για δοκιμές και αποσφαλμάτωση MCP servers.
> - Όλοι οι τρόποι αποσφαλμάτωσης υποστηρίζουν breakpoints, οπότε μπορείτε να προσθέσετε breakpoints στον κώδικα υλοποίησης των εργαλείων.

## Διαθέσιμα Εργαλεία

### Weather Tool
Το εργαλείο `get_weather` παρέχει ψεύτικες πληροφορίες καιρού για μια συγκεκριμένη τοποθεσία.

| Παράμετρος | Τύπος | Περιγραφή |
| --------- | ---- | ----------- |
| `location` | string | Τοποθεσία για την οποία ζητείται ο καιρός (π.χ. όνομα πόλης, πολιτεία ή συντεταγμένες) |

### Git Clone Tool
Το εργαλείο `git_clone_repo` κλωνοποιεί ένα αποθετήριο git σε έναν συγκεκριμένο φάκελο.

| Παράμετρος | Τύπος | Περιγραφή |
| --------- | ---- | ----------- |
| `repo_url` | string | URL του αποθετηρίου git που θα κλωνοποιηθεί |
| `target_folder` | string | Διαδρομή του φακέλου όπου θα γίνει η κλωνοποίηση |

Το εργαλείο επιστρέφει ένα JSON αντικείμενο με:
- `success`: Boolean που δείχνει αν η λειτουργία ήταν επιτυχής
- `target_folder` ή `error`: Τη διαδρομή του κλωνοποιημένου αποθετηρίου ή ένα μήνυμα λάθους

### VS Code Open Tool
Το εργαλείο `open_in_vscode` ανοίγει έναν φάκελο στην εφαρμογή VS Code ή VS Code Insiders.

| Παράμετρος | Τύπος | Περιγραφή |
| --------- | ---- | ----------- |
| `folder_path` | string | Διαδρομή του φακέλου που θα ανοίξει |
| `use_insiders` | boolean (προαιρετικό) | Αν θα χρησιμοποιηθεί το VS Code Insiders αντί του κανονικού VS Code |

Το εργαλείο επιστρέφει ένα JSON αντικείμενο με:
- `success`: Boolean που δείχνει αν η λειτουργία ήταν επιτυχής
- `message` ή `error`: Μήνυμα επιβεβαίωσης ή μήνυμα λάθους

## Λειτουργία Αποσφαλμάτωσης | Περιγραφή | Βήματα αποσφαλμάτωσης |
| ---------- | ----------- | --------------- |
| Agent Builder | Αποσφαλμάτωση του MCP server στον Agent Builder μέσω AI Toolkit. | 1. Ανοίξτε το πάνελ αποσφαλμάτωσης του VS Code. Επιλέξτε `Debug in Agent Builder` και πατήστε `F5` για να ξεκινήσετε την αποσφαλμάτωση του MCP server.<br>2. Χρησιμοποιήστε το AI Toolkit Agent Builder για να δοκιμάσετε τον server με [αυτό το prompt](../../../../../../../../../../../open_prompt_builder). Ο server θα συνδεθεί αυτόματα με τον Agent Builder.<br>3. Κάντε κλικ στο `Run` για να δοκιμάσετε τον server με το prompt. |
| MCP Inspector | Αποσφαλμάτωση του MCP server χρησιμοποιώντας τον MCP Inspector. | 1. Εγκαταστήστε το [Node.js](https://nodejs.org/)<br> 2. Ρυθμίστε τον Inspector: `cd inspector` && `npm install` <br> 3. Ανοίξτε το πάνελ αποσφαλμάτωσης του VS Code. Επιλέξτε `Debug SSE in Inspector (Edge)` ή `Debug SSE in Inspector (Chrome)`. Πατήστε F5 για να ξεκινήσετε την αποσφαλμάτωση.<br> 4. Όταν ο MCP Inspector ανοίξει στον browser, κάντε κλικ στο κουμπί `Connect` για να συνδέσετε αυτόν τον MCP server.<br> 5. Μετά μπορείτε να `List Tools`, να επιλέξετε ένα εργαλείο, να εισάγετε παραμέτρους και να `Run Tool` για να αποσφαλματώσετε τον κώδικα του server.<br> |

## Προεπιλεγμένες Θύρες και παραμετροποιήσεις

| Λειτουργία Αποσφαλμάτωσης | Θύρες | Ορισμοί | Παραμετροποιήσεις | Σημείωση |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Επεξεργαστείτε τα [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) για να αλλάξετε τις παραπάνω θύρες. | N/A |
| MCP Inspector | 3001 (Server); 5173 και 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Επεξεργαστείτε τα [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) για να αλλάξετε τις παραπάνω θύρες.| N/A |

## Feedback

Αν έχετε σχόλια ή προτάσεις για αυτό το πρότυπο, παρακαλούμε ανοίξτε ένα issue στο [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η επίσημη πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική μετάφραση από άνθρωπο. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.