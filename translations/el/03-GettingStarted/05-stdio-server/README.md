<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:33:14+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "el"
}
-->
# MCP Server με μεταφορά stdio

> **⚠️ Σημαντική Ενημέρωση**: Από την MCP Προδιαγραφή 2025-06-18, η ανεξάρτητη μεταφορά SSE (Server-Sent Events) έχει **καταργηθεί** και αντικατασταθεί από τη μεταφορά "Streamable HTTP". Η τρέχουσα προδιαγραφή MCP ορίζει δύο κύριους μηχανισμούς μεταφοράς:
> 1. **stdio** - Τυπική είσοδος/έξοδος (συνιστάται για τοπικούς διακομιστές)
> 2. **Streamable HTTP** - Για απομακρυσμένους διακομιστές που μπορεί να χρησιμοποιούν εσωτερικά SSE
>
> Αυτό το μάθημα έχει ενημερωθεί ώστε να επικεντρώνεται στη μεταφορά **stdio**, η οποία είναι η συνιστώμενη προσέγγιση για τις περισσότερες υλοποιήσεις MCP διακομιστών.

Η μεταφορά stdio επιτρέπει στους MCP διακομιστές να επικοινωνούν με τους πελάτες μέσω των τυπικών ροών εισόδου και εξόδου. Αυτός είναι ο πιο συχνά χρησιμοποιούμενος και συνιστώμενος μηχανισμός μεταφοράς στην τρέχουσα προδιαγραφή MCP, παρέχοντας έναν απλό και αποτελεσματικό τρόπο για τη δημιουργία MCP διακομιστών που μπορούν εύκολα να ενσωματωθούν σε διάφορες εφαρμογές πελατών.

## Επισκόπηση

Αυτό το μάθημα καλύπτει πώς να δημιουργήσετε και να χρησιμοποιήσετε MCP διακομιστές χρησιμοποιώντας τη μεταφορά stdio.

## Στόχοι Μάθησης

Μέχρι το τέλος αυτού του μαθήματος, θα μπορείτε να:

- Δημιουργήσετε έναν MCP διακομιστή χρησιμοποιώντας τη μεταφορά stdio.
- Εντοπίσετε σφάλματα σε έναν MCP διακομιστή χρησιμοποιώντας το Inspector.
- Χρησιμοποιήσετε έναν MCP διακομιστή μέσω του Visual Studio Code.
- Κατανοήσετε τους τρέχοντες μηχανισμούς μεταφοράς MCP και γιατί η stdio συνιστάται.

## Μεταφορά stdio - Πώς λειτουργεί

Η μεταφορά stdio είναι ένας από τους δύο υποστηριζόμενους τύπους μεταφοράς στην τρέχουσα προδιαγραφή MCP (2025-06-18). Δείτε πώς λειτουργεί:

- **Απλή Επικοινωνία**: Ο διακομιστής διαβάζει μηνύματα JSON-RPC από την τυπική είσοδο (`stdin`) και στέλνει μηνύματα στην τυπική έξοδο (`stdout`).
- **Βασισμένο σε διεργασίες**: Ο πελάτης εκκινεί τον MCP διακομιστή ως υποδιεργασία.
- **Μορφή Μηνυμάτων**: Τα μηνύματα είναι μεμονωμένα αιτήματα, ειδοποιήσεις ή απαντήσεις JSON-RPC, διαχωρισμένα με αλλαγές γραμμής.
- **Καταγραφή**: Ο διακομιστής ΜΠΟΡΕΙ να γράψει UTF-8 συμβολοσειρές στην τυπική έξοδο σφαλμάτων (`stderr`) για σκοπούς καταγραφής.

### Βασικές Απαιτήσεις:
- Τα μηνύματα ΠΡΕΠΕΙ να διαχωρίζονται με αλλαγές γραμμής και ΔΕΝ ΠΡΕΠΕΙ να περιέχουν ενσωματωμένες αλλαγές γραμμής.
- Ο διακομιστής ΔΕΝ ΠΡΕΠΕΙ να γράφει τίποτα στο `stdout` που δεν είναι έγκυρο μήνυμα MCP.
- Ο πελάτης ΔΕΝ ΠΡΕΠΕΙ να γράφει τίποτα στο `stdin` του διακομιστή που δεν είναι έγκυρο μήνυμα MCP.

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

Στον παραπάνω κώδικα:

- Εισάγουμε την κλάση `Server` και τη `StdioServerTransport` από το MCP SDK.
- Δημιουργούμε μια παρουσία διακομιστή με βασική διαμόρφωση και δυνατότητες.

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

Στον παραπάνω κώδικα:

- Δημιουργούμε μια παρουσία διακομιστή χρησιμοποιώντας το MCP SDK.
- Ορίζουμε εργαλεία χρησιμοποιώντας διακοσμητές.
- Χρησιμοποιούμε τον διαχειριστή περιβάλλοντος `stdio_server` για να χειριστούμε τη μεταφορά.

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

Η βασική διαφορά από το SSE είναι ότι οι διακομιστές stdio:

- Δεν απαιτούν ρύθμιση διακομιστή ιστού ή HTTP endpoints.
- Εκκινούνται ως υποδιεργασίες από τον πελάτη.
- Επικοινωνούν μέσω των ροών stdin/stdout.
- Είναι πιο απλοί στην υλοποίηση και τον εντοπισμό σφαλμάτων.

## Άσκηση: Δημιουργία διακομιστή stdio

Για να δημιουργήσουμε τον διακομιστή μας, πρέπει να έχουμε υπόψη δύο πράγματα:

- Πρέπει να χρησιμοποιήσουμε έναν διακομιστή ιστού για να εκθέσουμε endpoints για σύνδεση και μηνύματα.

## Εργαστήριο: Δημιουργία απλού MCP διακομιστή stdio

Σε αυτό το εργαστήριο, θα δημιουργήσουμε έναν απλό MCP διακομιστή χρησιμοποιώντας τη συνιστώμενη μεταφορά stdio. Αυτός ο διακομιστής θα εκθέσει εργαλεία που οι πελάτες μπορούν να καλέσουν χρησιμοποιώντας το πρότυπο Model Context Protocol.

### Προαπαιτούμενα

- Python 3.8 ή νεότερη έκδοση.
- MCP Python SDK: `pip install mcp`.
- Βασική κατανόηση ασύγχρονου προγραμματισμού.

Ας ξεκινήσουμε δημιουργώντας τον πρώτο μας MCP διακομιστή stdio:

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## Βασικές διαφορές από την καταργημένη προσέγγιση SSE

**Μεταφορά Stdio (Τρέχον Πρότυπο):**
- Απλό μοντέλο υποδιεργασίας - ο πελάτης εκκινεί τον διακομιστή ως διεργασία παιδί.
- Επικοινωνία μέσω stdin/stdout χρησιμοποιώντας μηνύματα JSON-RPC.
- Δεν απαιτείται ρύθμιση διακομιστή HTTP.
- Καλύτερη απόδοση και ασφάλεια.
- Ευκολότερος εντοπισμός σφαλμάτων και ανάπτυξη.

**Μεταφορά SSE (Καταργήθηκε από MCP 2025-06-18):**
- Απαιτούσε διακομιστή HTTP με endpoints SSE.
- Πιο περίπλοκη ρύθμιση με υποδομή διακομιστή ιστού.
- Πρόσθετες ανησυχίες ασφάλειας για τα HTTP endpoints.
- Τώρα αντικαταστάθηκε από το Streamable HTTP για σενάρια βασισμένα στον ιστό.

### Δημιουργία διακομιστή με μεταφορά stdio

Για να δημιουργήσουμε τον διακομιστή stdio, πρέπει να:

1. **Εισάγουμε τις απαιτούμενες βιβλιοθήκες** - Χρειαζόμαστε τα στοιχεία του MCP διακομιστή και τη μεταφορά stdio.
2. **Δημιουργήσουμε μια παρουσία διακομιστή** - Ορίστε τον διακομιστή με τις δυνατότητές του.
3. **Ορίσουμε εργαλεία** - Προσθέστε τη λειτουργικότητα που θέλουμε να εκθέσουμε.
4. **Ρυθμίσουμε τη μεταφορά** - Διαμορφώστε την επικοινωνία stdio.
5. **Εκκινήσουμε τον διακομιστή** - Ξεκινήστε τον διακομιστή και χειριστείτε μηνύματα.

Ας το χτίσουμε βήμα προς βήμα:

### Βήμα 1: Δημιουργία βασικού διακομιστή stdio

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### Βήμα 2: Προσθήκη περισσότερων εργαλείων

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### Βήμα 3: Εκκίνηση του διακομιστή

Αποθηκεύστε τον κώδικα ως `server.py` και εκτελέστε τον από τη γραμμή εντολών:

```bash
python server.py
```

Ο διακομιστής θα ξεκινήσει και θα περιμένει είσοδο από το stdin. Επικοινωνεί χρησιμοποιώντας μηνύματα JSON-RPC μέσω της μεταφοράς stdio.

### Βήμα 4: Δοκιμή με το Inspector

Μπορείτε να δοκιμάσετε τον διακομιστή σας χρησιμοποιώντας το MCP Inspector:

1. Εγκαταστήστε το Inspector: `npx @modelcontextprotocol/inspector`.
2. Εκτελέστε το Inspector και συνδέστε το στον διακομιστή σας.
3. Δοκιμάστε τα εργαλεία που έχετε δημιουργήσει.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Run the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

3. **Test your server**: The Inspector provides a web interface where you can:
   - View server capabilities
   - Test tools with different parameters
   - Monitor JSON-RPC messages
   - Debug connection issues

### Using VS Code

You can also debug your MCP server directly in VS Code:

1. Create a launch configuration in `.vscode/launch.json`:
   ```json
   {
     "version": "0.2.0",
     "configurations": [
       {
         "name": "Debug MCP Server",
         "type": "python",
         "request": "launch",
         "program": "server.py",
         "console": "integratedTerminal"
       }
     ]
   }
   ```

2. Set breakpoints in your server code
3. Run the debugger and test with the Inspector

### Common debugging tips

- Use `stderr` for logging - never write to `stdout` as it's reserved for MCP messages
- Ensure all JSON-RPC messages are newline-delimited
- Test with simple tools first before adding complex functionality
- Use the Inspector to verify message formats

## Consuming your stdio server in VS Code

Once you've built your MCP stdio server, you can integrate it with VS Code to use it with Claude or other MCP-compatible clients.

### Configuration

1. **Create an MCP configuration file** at `%APPDATA%\Claude\claude_desktop_config.json` (Windows) or `~/Library/Application Support/Claude/claude_desktop_config.json` (Mac):

   ```json
   {
     "mcpServers": {
       "example-stdio-server": {
         "command": "python",
         "args": ["path/to/your/server.py"]
       }
     }
   }
   ```

2. **Restart Claude**: Close and reopen Claude to load the new server configuration.

3. **Test the connection**: Start a conversation with Claude and try using your server's tools:
   - "Can you greet me using the greeting tool?"
   - "Calculate the sum of 15 and 27"
   - "What's the server info?"

### TypeScript stdio server example

Here's a complete TypeScript example for reference:

```typescript
#!/usr/bin/env node
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { CallToolRequestSchema, ListToolsRequestSchema } from "@modelcontextprotocol/sdk/types.js";

const server = new Server(
  {
    name: "example-stdio-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);

// Προσθήκη εργαλείων
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Λάβετε έναν εξατομικευμένο χαιρετισμό",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Όνομα του ατόμου που θα χαιρετηθεί",
            },
          },
          required: ["name"],
        },
      },
    ],
  };
});

server.setRequestHandler(CallToolRequestSchema, async (request) => {
  if (request.params.name === "get_greeting") {
    return {
      content: [
        {
          type: "text",
          text: `Γεια σου, ${request.params.arguments?.name}! Καλώς ήρθες στον MCP stdio server.`,
        },
      ],
    };
  } else {
    throw new Error(`Άγνωστο εργαλείο: ${request.params.name}`);
  }
});

async function runServer() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
}

runServer().catch(console.error);
```

### .NET stdio server example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

var app = builder.Build();
await app.RunAsync();

public class Tools
{
    [Description("Λάβετε έναν εξατομικευμένο χαιρετισμό")]
    public string GetGreeting(string name)
    {
        return $"Γεια σου, {name}! Καλώς ήρθες στον MCP stdio server.";
    }

    [Description("Υπολογίστε το άθροισμα δύο αριθμών")]
    public int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
```

## Summary

In this updated lesson, you learned how to:

- Build MCP servers using the current **stdio transport** (recommended approach)
- Understand why SSE transport was deprecated in favor of stdio and Streamable HTTP
- Create tools that can be called by MCP clients
- Debug your server using the MCP Inspector
- Integrate your stdio server with VS Code and Claude

The stdio transport provides a simpler, more secure, and more performant way to build MCP servers compared to the deprecated SSE approach. It's the recommended transport for most MCP server implementations as of the 2025-06-18 specification.
```

### .NET

1. Ας δημιουργήσουμε πρώτα κάποια εργαλεία. Για αυτό, θα δημιουργήσουμε ένα αρχείο *Tools.cs* με το ακόλουθο περιεχόμενο:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

## Exercise: Testing your stdio server

Now that you've built your stdio server, let's test it to make sure it works correctly.

### Prerequisites

1. Ensure you have the MCP Inspector installed:
   ```bash
   npm install -g @modelcontextprotocol/inspector
   ```

2. Your server code should be saved (e.g., as `server.py`)

### Testing with the Inspector

1. **Start the Inspector with your server**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

2. **Ανοίξτε τη διεπαφή ιστού**: Το Inspector θα ανοίξει ένα παράθυρο προγράμματος περιήγησης που δείχνει τις δυνατότητες του διακομιστή σας.

3. **Δοκιμάστε τα εργαλεία**: 
   - Δοκιμάστε το εργαλείο `get_greeting` με διαφορετικά ονόματα.
   - Δοκιμάστε το εργαλείο `calculate_sum` με διάφορους αριθμούς.
   - Καλέστε το εργαλείο `get_server_info` για να δείτε μεταδεδομένα του διακομιστή.

4. **Παρακολουθήστε την επικοινωνία**: Το Inspector δείχνει τα μηνύματα JSON-RPC που ανταλλάσσονται μεταξύ πελάτη και διακομιστή.

### Τι πρέπει να δείτε

Όταν ο διακομιστής σας ξεκινήσει σωστά, θα πρέπει να δείτε:
- Τις δυνατότητες του διακομιστή να εμφανίζονται στο Inspector.
- Εργαλεία διαθέσιμα για δοκιμή.
- Επιτυχημένες ανταλλαγές μηνυμάτων JSON-RPC.
- Απαντήσεις εργαλείων που εμφανίζονται στη διεπαφή.

### Συνηθισμένα προβλήματα και λύσεις

**Ο διακομιστής δεν ξεκινά:**
- Ελέγξτε ότι όλες οι εξαρτήσεις είναι εγκατεστημένες: `pip install mcp`.
- Επαληθεύστε τη σύνταξη και την εσοχή του Python.
- Αναζητήστε μηνύματα σφάλματος στην κονσόλα.

**Τα εργαλεία δεν εμφανίζονται:**
- Βεβαιωθείτε ότι υπάρχουν οι διακοσμητές `@server.tool()`.
- Ελέγξτε ότι οι συναρτήσεις εργαλείων έχουν οριστεί πριν από το `main()`.
- Επαληθεύστε ότι ο διακομιστής έχει διαμορφωθεί σωστά.

**Προβλήματα σύνδεσης:**
- Βεβαιωθείτε ότι ο διακομιστής χρησιμοποιεί σωστά τη μεταφορά stdio.
- Ελέγξτε ότι δεν παρεμβαίνουν άλλες διεργασίες.
- Επαληθεύστε τη σύνταξη εντολών του Inspector.

## Εργασία

Δοκιμάστε να επεκτείνετε τον διακομιστή σας με περισσότερες δυνατότητες. Δείτε [αυτήν τη σελίδα](https://api.chucknorris.io/) για να προσθέσετε, για παράδειγμα, ένα εργαλείο που καλεί ένα API. Εσείς αποφασίζετε πώς θα μοιάζει ο διακομιστής. Καλή διασκέδαση :)

## Λύση

[Λύση](./solution/README.md) Εδώ είναι μια πιθανή λύση με λειτουργικό κώδικα.

## Βασικά Σημεία

Τα βασικά σημεία αυτού του κεφαλαίου είναι τα εξής:

- Η μεταφορά stdio είναι ο συνιστώμενος μηχανισμός για τοπικούς MCP διακομιστές.
- Η μεταφορά stdio επιτρέπει απρόσκοπτη επικοινωνία μεταξύ MCP διακομιστών και πελατών χρησιμοποιώντας τυπικές ροές εισόδου και εξόδου.
- Μπορείτε να χρησιμοποιήσετε τόσο το Inspector όσο και το Visual Studio Code για να χρησιμοποιήσετε διακομιστές stdio απευθείας, καθιστώντας τον εντοπισμό σφαλμάτων και την ενσωμάτωση απλή.

## Δείγματα 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Πρόσθετοι Πόροι

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Τι Ακολουθεί

## Επόμενα Βήματα

Τώρα που μάθατε πώς να δημιουργείτε MCP διακομιστές με τη μεταφορά stdio, μπορείτε να εξερευνήσετε πιο προχωρημένα θέματα:

- **Επόμενο**: [HTTP Streaming με MCP (Streamable HTTP)](../06-http-streaming/README.md) - Μάθετε για τον άλλο υποστηριζόμενο μηχανισμό μεταφοράς για απομακρυσμένους διακομιστές.
- **Προχωρημένο**: [Καλύτερες Πρακτικές Ασφάλειας MCP](../../02-Security/README.md) - Εφαρμόστε ασφάλεια στους MCP διακομιστές σας.
- **Παραγωγή**: [Στρατηγικές Ανάπτυξης](../09-deployment/README.md) - Αναπτύξτε τους διακομιστές σας για χρήση σε παραγωγή.

## Πρόσθετοι Πόροι

- [MCP Προδιαγραφή 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Επίσημη προδιαγραφή.
- [Τεκμηρίωση MCP SDK](https://github.com/modelcontextprotocol/sdk) - Αναφορές SDK για όλες τις γλώσσες.
- [Παραδείγματα Κοινότητας](../../06-Community

---

**Αποποίηση ευθύνης**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που καταβάλλουμε προσπάθειες για ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα θα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή εσφαλμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.