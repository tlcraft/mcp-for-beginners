<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T18:40:00+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "el"
}
-->
# SSE Server

Το SSE (Server Sent Events) είναι ένα πρότυπο για streaming από τον διακομιστή προς τον πελάτη, που επιτρέπει στους διακομιστές να στέλνουν ενημερώσεις σε πραγματικό χρόνο στους πελάτες μέσω HTTP. Αυτό είναι ιδιαίτερα χρήσιμο για εφαρμογές που απαιτούν ζωντανές ενημερώσεις, όπως εφαρμογές συνομιλίας, ειδοποιήσεις ή ροές δεδομένων σε πραγματικό χρόνο. Επίσης, ο διακομιστής σας μπορεί να χρησιμοποιηθεί από πολλούς πελάτες ταυτόχρονα, καθώς φιλοξενείται σε έναν διακομιστή που μπορεί να τρέχει, για παράδειγμα, στο cloud.

## Επισκόπηση

Αυτό το μάθημα καλύπτει πώς να δημιουργήσετε και να χρησιμοποιήσετε SSE Servers.

## Στόχοι Μάθησης

Στο τέλος αυτού του μαθήματος, θα μπορείτε να:

- Δημιουργήσετε έναν SSE Server.
- Εντοπίσετε σφάλματα σε έναν SSE Server χρησιμοποιώντας το Inspector.
- Χρησιμοποιήσετε έναν SSE Server με το Visual Studio Code.

## SSE, πώς λειτουργεί

Το SSE είναι ένας από τους δύο υποστηριζόμενους τύπους μεταφοράς. Έχετε ήδη δει τον πρώτο, stdio, να χρησιμοποιείται σε προηγούμενα μαθήματα. Η διαφορά είναι η εξής:

- Το SSE απαιτεί να διαχειρίζεστε δύο πράγματα: τη σύνδεση και τα μηνύματα.
- Επειδή πρόκειται για έναν διακομιστή που μπορεί να φιλοξενηθεί οπουδήποτε, πρέπει αυτό να αντικατοπτρίζεται στον τρόπο που εργάζεστε με εργαλεία όπως το Inspector και το Visual Studio Code. Αυτό σημαίνει ότι αντί να δείχνετε πώς να ξεκινήσετε τον διακομιστή, δείχνετε το endpoint όπου μπορεί να δημιουργηθεί η σύνδεση. Δείτε το παρακάτω παράδειγμα κώδικα:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
    const transport = new SSEServerTransport('/messages', res);
    transports[transport.sessionId] = transport;
    res.on("close", () => {
        delete transports[transport.sessionId];
    });
    await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
    const sessionId = req.query.sessionId as string;
    const transport = transports[sessionId];
    if (transport) {
        await transport.handlePostMessage(req, res);
    } else {
        res.status(400).send('No transport found for sessionId');
    }
});
```

Στον παραπάνω κώδικα:

- Το `/sse` έχει οριστεί ως διαδρομή. Όταν γίνεται αίτημα σε αυτή τη διαδρομή, δημιουργείται μια νέα μεταφορά και ο διακομιστής *συνδέεται* χρησιμοποιώντας αυτή τη μεταφορά.
- Το `/messages` είναι η διαδρομή που διαχειρίζεται τα εισερχόμενα μηνύματα.

### Python

```python
mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)

```

Στον παραπάνω κώδικα:

- Δημιουργούμε μια παρουσία ενός ASGI server (χρησιμοποιώντας συγκεκριμένα το Starlette) και τοποθετούμε τη βασική διαδρομή `/`

  Αυτό που συμβαίνει στο παρασκήνιο είναι ότι οι διαδρομές `/sse` και `/messages` ρυθμίζονται για να διαχειρίζονται τις συνδέσεις και τα μηνύματα αντίστοιχα. Το υπόλοιπο της εφαρμογής, όπως η προσθήκη λειτουργιών και εργαλείων, γίνεται όπως στους stdio servers.

### .NET    

```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services
        .AddMcpServer()
        .WithTools<Tools>();


    builder.Services.AddHttpClient();

    var app = builder.Build();

    app.MapMcp();
    ```

    Υπάρχουν δύο μέθοδοι που μας βοηθούν να μεταβούμε από έναν web server σε έναν web server που υποστηρίζει SSE και αυτές είναι:

    - `AddMcpServer`, αυτή η μέθοδος προσθέτει δυνατότητες.
    - `MapMcp`, αυτή προσθέτει διαδρομές όπως `/SSE` και `/messages`.
```

Now that we know a little bit more about SSE, let's build an SSE server next.

## Exercise: Creating an SSE Server

To create our server, we need to keep two things in mind:

- We need to use a web server to expose endpoints for connection and messages.
- Build our server like we normally do with tools, resources and prompts when we were using stdio.

### -1- Create a server instance

To create our server, we use the same types as with stdio. However, for the transport, we need to choose SSE.

### TypeScript

```typescript
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

const server = new McpServer({
  name: "example-server",
  version: "1.0.0"
});

const app = express();

const transports: {[sessionId: string]: SSEServerTransport} = {};
```

In the preceding code we've:

- Created a server instance.
- Defined an app using the web framework express.
- Created a transports variable that we will use to store incoming connections.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

In the preceding code we've:

- Imported the libraries we're going to need with Starlette (an ASGI framework) being pulled in.
- Created an MCP server instance `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

At this point, we've:

- Created a web app
- Added support for MCP features through `AddMcpServer`.

Let's add the needed routes next.

### -2- Add routes

Let's add routes next that handle the connection and incoming messages:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport('/messages', res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send('No transport found for sessionId');
  }
});

app.listen(3001);
```

In the preceding code we've defined:

- An `/sse` route that instantiates a transport of type SSE and ends up calling `connect` on the MCP server.
- A `/messages` route that takes care of incoming messages.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

In the preceding code we've:

- Created an ASGI app instance using the Starlette framework. As part of that we passes `mcp.sse_app()` to it's list of routes. That ends up mounting an `/sse` and `/messages` route on the app instance.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

We've added one line of code at the end `add.MapMcp()` this means we now have routes `/SSE` and `/messages`. 

Let's add capabilties to the server next.

### -3- Adding server capabilities

Now that we've got everything SSE specific defined, let's add server capabilities like tools, prompts and resources.

### TypeScript

```typescript
server.tool("random-joke", "A joke returned by the chuck norris api", {},
  async () => {
    const response = await fetch("https://api.chucknorris.io/jokes/random");
    const data = await response.json();

    return {
      content: [
        {
          type: "text",
          text: data.value
        }
      ]
    };
  }
);
```

Here's how you can add a tool for example. This specific tool creates a tool call "random-joke" that calls a Chuck Norris API and returns a JSON response.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Now your server has one tool.

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Δημιουργία MCP server
const server = new McpServer({
  name: "example-server",
  version: "1.0.0",
});

const app = express();

const transports: { [sessionId: string]: SSEServerTransport } = {};

app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport("/messages", res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send("No transport found for sessionId");
  }
});

server.tool("random-joke", "A joke returned by the chuck norris api", {}, async () => {
  const response = await fetch("https://api.chucknorris.io/jokes/random");
  const data = await response.json();

  return {
    content: [
      {
        type: "text",
        text: data.value,
      },
    ],
  };
});

app.listen(3001);
```

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Πρόσθεσε δύο αριθμούς"""
    return a + b

# Τοποθέτηση του SSE server στον υπάρχοντα ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. Let's create some tools first, for this we will create a file *Tools.cs* with the following content:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

  namespace server;

  [McpServerToolType]
  public sealed class Tools
  {

      public Tools()
      {
      
      }

      [McpServerTool, Description("Πρόσθεσε δύο αριθμούς.")]
      public async Task<string> AddNumbers(
          [Description("Ο πρώτος αριθμός")] int a,
          [Description("Ο δεύτερος αριθμός")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  Here we've added the following:

  - Created a class `Tools` with the decorator `McpServerToolType`.
  - Defined a tool `AddNumbers` by decorating the method with `McpServerTool`. We've also provided parameters and an implementation.

1. Let's leverage the `Tools` class we just created:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  We've added a call to `WithTools` that specifies `Tools` as the class containing the tools. That's it, we're ready.

Great, we have a server using SSE, let's take it for a spin next.

## Exercise: Debugging an SSE Server with Inspector

Inspector is a great tool that we saw in a previous lesson [Creating your first server](/03-GettingStarted/01-first-server/README.md). Let's see if we can use the Inspector even here:

### -1- Running the inspector

To run the inspector, you first must have an SSE server running, so let's do that next:

1. Run the server 

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Note how we use the executable `uvicorn` that's installed when we typed `pip install "mcp[cli]"`. Typing `server:app` means we're trying to run a file `server.py` and for it to have a Starlette instance called `app`. 

    ### .NET

    ```sh
    dotnet run
    ```

    This should start the server. To interface with it you need a new terminal.

1. Run the inspector

    > ![NOTE]
    > Run this in a separate terminal window than the server is running in. Also note, you need to adjust the below command to fit the URL where your server runs.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
  

    Η εκτέλεση του inspector είναι ίδια σε όλα τα περιβάλλοντα. Παρατηρήστε πως αντί να δίνουμε μια διαδρομή προς τον διακομιστή και μια εντολή για να ξεκινήσει ο διακομιστής, δίνουμε το URL όπου τρέχει ο διακομιστής και επίσης καθορίζουμε τη διαδρομή `/sse`.

### -2- Δοκιμάζοντας το εργαλείο

Συνδεθείτε με τον διακομιστή επιλέγοντας SSE από το αναπτυσσόμενο μενού και συμπληρώστε το πεδίο URL όπου τρέχει ο διακομιστής σας, για παράδειγμα http:localhost:4321/sse. Τώρα πατήστε το κουμπί "Connect". Όπως πριν, επιλέξτε να εμφανιστούν τα εργαλεία, επιλέξτε ένα εργαλείο και δώστε τις τιμές εισόδου. Θα δείτε ένα αποτέλεσμα όπως παρακάτω:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.el.png)

Τέλεια, μπορείτε να δουλέψετε με το inspector, ας δούμε τώρα πώς μπορούμε να δουλέψουμε με το Visual Studio Code.

## Ανάθεση

Δοκιμάστε να επεκτείνετε τον διακομιστή σας με περισσότερες δυνατότητες. Δείτε [αυτή τη σελίδα](https://api.chucknorris.io/) για παράδειγμα, για να προσθέσετε ένα εργαλείο που καλεί ένα API. Εσείς αποφασίζετε πώς θα είναι ο διακομιστής. Καλή διασκέδαση :)

## Λύση

[Λύση](./solution/README.md) Εδώ είναι μια πιθανή λύση με λειτουργικό κώδικα.

## Βασικά Συμπεράσματα

Τα βασικά σημεία που πρέπει να κρατήσετε από αυτό το κεφάλαιο είναι τα εξής:

- Το SSE είναι ο δεύτερος υποστηριζόμενος τύπος μεταφοράς μετά το stdio.
- Για να υποστηρίξετε το SSE, πρέπει να διαχειρίζεστε τις εισερχόμενες συνδέσεις και τα μηνύματα χρησιμοποιώντας ένα web framework.
- Μπορείτε να χρησιμοποιήσετε τόσο το Inspector όσο και το Visual Studio Code για να καταναλώσετε έναν SSE server, όπως και με τους stdio servers. Παρατηρήστε πως υπάρχει μια μικρή διαφορά μεταξύ stdio και SSE. Για το SSE, πρέπει να ξεκινήσετε τον διακομιστή ξεχωριστά και μετά να τρέξετε το εργαλείο inspector. Για το εργαλείο inspector, υπάρχουν επίσης κάποιες διαφορές, καθώς πρέπει να καθορίσετε το URL.

## Παραδείγματα

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Πρόσθετοι Πόροι

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Τι Ακολουθεί

- Επόμενο: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.