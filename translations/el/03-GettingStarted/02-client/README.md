<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:01:39+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "el"
}
-->
# Δημιουργία πελάτη

Οι πελάτες είναι προσαρμοσμένες εφαρμογές ή σενάρια που επικοινωνούν απευθείας με έναν MCP Server για να ζητήσουν πόρους, εργαλεία και προτροπές. Σε αντίθεση με τη χρήση του εργαλείου επιθεώρησης, που παρέχει γραφικό περιβάλλον για αλληλεπίδραση με τον διακομιστή, η συγγραφή του δικού σας πελάτη επιτρέπει προγραμματιστική και αυτοματοποιημένη αλληλεπίδραση. Αυτό δίνει τη δυνατότητα στους προγραμματιστές να ενσωματώσουν τις δυνατότητες του MCP στις δικές τους ροές εργασίας, να αυτοματοποιήσουν εργασίες και να δημιουργήσουν προσαρμοσμένες λύσεις που ανταποκρίνονται σε συγκεκριμένες ανάγκες.

## Επισκόπηση

Αυτό το μάθημα εισάγει την έννοια των πελατών στο οικοσύστημα του Model Context Protocol (MCP). Θα μάθετε πώς να γράψετε τον δικό σας πελάτη και να τον συνδέσετε με έναν MCP Server.

## Στόχοι Μάθησης

Στο τέλος αυτού του μαθήματος, θα μπορείτε να:

- Κατανοήσετε τι μπορεί να κάνει ένας πελάτης.
- Γράψετε τον δικό σας πελάτη.
- Συνδέσετε και δοκιμάσετε τον πελάτη με έναν MCP server για να βεβαιωθείτε ότι λειτουργεί όπως αναμένεται.

## Τι απαιτείται για να γράψετε έναν πελάτη;

Για να γράψετε έναν πελάτη, θα χρειαστεί να κάνετε τα εξής:

- **Εισαγωγή των σωστών βιβλιοθηκών**. Θα χρησιμοποιήσετε την ίδια βιβλιοθήκη όπως πριν, απλώς διαφορετικές δομές.
- **Δημιουργία ενός πελάτη**. Αυτό περιλαμβάνει τη δημιουργία μιας παρουσίας πελάτη και τη σύνδεσή του με την επιλεγμένη μέθοδο μεταφοράς.
- **Απόφαση για το ποιοι πόροι θα εμφανιστούν**. Ο MCP server σας διαθέτει πόρους, εργαλεία και προτροπές, πρέπει να αποφασίσετε ποια θα εμφανίσετε.
- **Ενσωμάτωση του πελάτη σε μια εφαρμογή υποδοχής**. Μόλις γνωρίζετε τις δυνατότητες του διακομιστή, πρέπει να ενσωματώσετε τον πελάτη στην εφαρμογή υποδοχής ώστε όταν ένας χρήστης πληκτρολογεί μια προτροπή ή άλλη εντολή, να καλείται η αντίστοιχη λειτουργία του διακομιστή.

Τώρα που κατανοούμε σε γενικές γραμμές τι πρόκειται να κάνουμε, ας δούμε ένα παράδειγμα παρακάτω.

### Παράδειγμα πελάτη

Ας δούμε αυτό το παράδειγμα πελάτη:

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";

const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);

// List prompts
const prompts = await client.listPrompts();

// Get a prompt
const prompt = await client.getPrompt({
  name: "example-prompt",
  arguments: {
    arg1: "value"
  }
});

// List resources
const resources = await client.listResources();

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});
```

Στον παραπάνω κώδικα:

- Εισάγουμε τις βιβλιοθήκες
- Δημιουργούμε μια παρουσία πελάτη και τη συνδέουμε χρησιμοποιώντας stdio για τη μεταφορά.
- Λίστα προτροπών, πόρων και εργαλείων και τα καλούμε όλα.

Κάπως έτσι, έχουμε έναν πελάτη που μπορεί να επικοινωνήσει με έναν MCP Server.

Ας αφιερώσουμε χρόνο στην επόμενη ενότητα άσκησης για να αναλύσουμε κάθε κομμάτι κώδικα και να εξηγήσουμε τι συμβαίνει.

## Άσκηση: Γράφοντας έναν πελάτη

Όπως αναφέρθηκε παραπάνω, ας αφιερώσουμε χρόνο για να εξηγήσουμε τον κώδικα, και φυσικά μπορείτε να γράφετε κώδικα παράλληλα αν θέλετε.

### -1- Εισαγωγή βιβλιοθηκών

Ας εισάγουμε τις βιβλιοθήκες που χρειαζόμαστε, θα χρειαστούμε αναφορές σε έναν πελάτη και στο επιλεγμένο πρωτόκολλο μεταφοράς, stdio. Το stdio είναι ένα πρωτόκολλο για εφαρμογές που προορίζονται να τρέχουν τοπικά στη μηχανή σας. Το SSE είναι ένα άλλο πρωτόκολλο μεταφοράς που θα δείξουμε σε μελλοντικά κεφάλαια, αλλά αυτή είναι η άλλη επιλογή σας. Προς το παρόν, ας συνεχίσουμε με το stdio.

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

### Java

Για Java, θα δημιουργήσετε έναν πελάτη που συνδέεται με τον MCP server από την προηγούμενη άσκηση. Χρησιμοποιώντας την ίδια δομή έργου Java Spring Boot από το [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), δημιουργήστε μια νέα κλάση Java με όνομα `SDKClient` στον φάκελο `src/main/java/com/microsoft/mcp/sample/client/` και προσθέστε τις ακόλουθες εισαγωγές:

```java
import java.util.Map;
import org.springframework.web.reactive.function.client.WebClient;
import io.modelcontextprotocol.client.McpClient;
import io.modelcontextprotocol.client.transport.WebFluxSseClientTransport;
import io.modelcontextprotocol.spec.McpClientTransport;
import io.modelcontextprotocol.spec.McpSchema.CallToolRequest;
import io.modelcontextprotocol.spec.McpSchema.CallToolResult;
import io.modelcontextprotocol.spec.McpSchema.ListToolsResult;
```

Ας προχωρήσουμε στη δημιουργία παρουσίας.

### -2- Δημιουργία παρουσίας πελάτη και μεταφοράς

Θα χρειαστεί να δημιουργήσουμε μια παρουσία της μεταφοράς και μια του πελάτη:

### TypeScript

```typescript
const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);
```

Στον παραπάνω κώδικα έχουμε:

- Δημιουργήσει μια παρουσία stdio μεταφοράς. Σημειώστε πώς καθορίζει την εντολή και τα ορίσματα για το πώς να βρει και να ξεκινήσει τον διακομιστή, καθώς αυτό είναι κάτι που θα χρειαστεί να κάνουμε καθώς δημιουργούμε τον πελάτη.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Δημιουργήσει έναν πελάτη δίνοντάς του όνομα και έκδοση.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Συνδέσει τον πελάτη με την επιλεγμένη μεταφορά.

    ```typescript
    await client.connect(transport);
    ```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client

# Create server parameters for stdio connection
server_params = StdioServerParameters(
    command="mcp",  # Executable
    args=["run", "server.py"],  # Optional command line arguments
    env=None,  # Optional environment variables
)

async def run():
    async with stdio_client(server_params) as (read, write):
        async with ClientSession(
            read, write
        ) as session:
            # Initialize the connection
            await session.initialize()

          

if __name__ == "__main__":
    import asyncio

    asyncio.run(run())
```

Στον παραπάνω κώδικα έχουμε:

- Εισάγει τις απαραίτητες βιβλιοθήκες
- Δημιουργήσει ένα αντικείμενο παραμέτρων διακομιστή που θα χρησιμοποιήσουμε για να τρέξουμε τον διακομιστή ώστε να συνδεθούμε με τον πελάτη μας.
- Ορίσει μια μέθοδο `run` που με τη σειρά της καλεί `stdio_client` που ξεκινά μια συνεδρία πελάτη.
- Δημιουργήσει ένα σημείο εισόδου όπου παρέχουμε τη μέθοδο `run` στο `asyncio.run`.

### .NET

```dotnet
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();



var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "dotnet",
    Arguments = ["run", "--project", "path/to/file.csproj"],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

Στον παραπάνω κώδικα έχουμε:

- Εισάγει τις απαραίτητες βιβλιοθήκες.
- Δημιουργήσει μια stdio μεταφορά και έναν πελάτη `mcpClient`. Αυτό θα το χρησιμοποιήσουμε για να εμφανίσουμε και να καλέσουμε λειτουργίες στον MCP Server.

Σημείωση, στα "Arguments" μπορείτε είτε να δείξετε στο *.csproj* είτε στο εκτελέσιμο αρχείο.

### Java

```java
public class SDKClient {
    
    public static void main(String[] args) {
        var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
        new SDKClient(transport).run();
    }
    
    private final McpClientTransport transport;

    public SDKClient(McpClientTransport transport) {
        this.transport = transport;
    }

    public void run() {
        var client = McpClient.sync(this.transport).build();
        client.initialize();
        
        // Your client logic goes here
    }
}
```

Στον παραπάνω κώδικα έχουμε:

- Δημιουργήσει μια μέθοδο main που ρυθμίζει μια SSE μεταφορά που δείχνει στο `http://localhost:8080` όπου θα τρέχει ο MCP server μας.
- Δημιουργήσει μια κλάση πελάτη που παίρνει τη μεταφορά ως παράμετρο κατασκευαστή.
- Στη μέθοδο `run`, δημιουργούμε έναν συγχρονισμένο MCP πελάτη χρησιμοποιώντας τη μεταφορά και αρχικοποιούμε τη σύνδεση.
- Χρησιμοποιήσαμε τη μεταφορά SSE (Server-Sent Events) που είναι κατάλληλη για επικοινωνία βασισμένη σε HTTP με MCP servers Java Spring Boot.

### -3- Εμφάνιση των λειτουργιών του διακομιστή

Τώρα έχουμε έναν πελάτη που μπορεί να συνδεθεί αν τρέξει το πρόγραμμα. Ωστόσο, δεν εμφανίζει τις λειτουργίες του, οπότε ας το κάνουμε αυτό τώρα:

### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

### Python

```python
# List available resources
resources = await session.list_resources()
print("LISTING RESOURCES")
for resource in resources:
    print("Resource: ", resource)

# List available tools
tools = await session.list_tools()
print("LISTING TOOLS")
for tool in tools.tools:
    print("Tool: ", tool.name)
```

Εδώ εμφανίζουμε τους διαθέσιμους πόρους, `list_resources()` και εργαλεία, `list_tools` και τα εκτυπώνουμε.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Παραπάνω είναι ένα παράδειγμα για το πώς μπορούμε να εμφανίσουμε τα εργαλεία στον διακομιστή. Για κάθε εργαλείο, εκτυπώνουμε το όνομά του.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

Στον παραπάνω κώδικα έχουμε:

- Καλέσει `listTools()` για να πάρουμε όλα τα διαθέσιμα εργαλεία από τον MCP server.
- Χρησιμοποιήσει `ping()` για να επαληθεύσουμε ότι η σύνδεση με τον διακομιστή λειτουργεί.
- Το `ListToolsResult` περιέχει πληροφορίες για όλα τα εργαλεία, συμπεριλαμβανομένων των ονομάτων, περιγραφών και σχημάτων εισόδου.

Τέλεια, τώρα έχουμε καταγράψει όλες τις λειτουργίες. Τώρα το ερώτημα είναι πότε τις χρησιμοποιούμε; Αυτός ο πελάτης είναι αρκετά απλός, με την έννοια ότι θα πρέπει να καλούμε ρητά τις λειτουργίες όταν τις θέλουμε. Στο επόμενο κεφάλαιο, θα δημιουργήσουμε έναν πιο προηγμένο πελάτη που θα έχει πρόσβαση στο δικό του μεγάλο γλωσσικό μοντέλο, LLM. Προς το παρόν όμως, ας δούμε πώς μπορούμε να καλέσουμε τις λειτουργίες στον διακομιστή:

### -4- Κλήση λειτουργιών

Για να καλέσουμε τις λειτουργίες πρέπει να βεβαιωθούμε ότι καθορίζουμε τα σωστά ορίσματα και σε ορισμένες περιπτώσεις το όνομα αυτού που προσπαθούμε να καλέσουμε.

### TypeScript

```typescript

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});

// call prompt
const promptResult = await client.getPrompt({
    name: "review-code",
    arguments: {
        code: "console.log(\"Hello world\")"
    }
})
```

Στον παραπάνω κώδικα:

- Διαβάζουμε έναν πόρο, τον καλούμε με `readResource()` καθορίζοντας το `uri`. Να πώς πιθανότατα φαίνεται στην πλευρά του διακομιστή:

    ```typescript
    server.resource(
        "readFile",
        new ResourceTemplate("file://{name}", { list: undefined }),
        async (uri, { name }) => ({
          contents: [{
            uri: uri.href,
            text: `Hello, ${name}!`
          }]
        })
    );
    ```

    Η τιμή `uri` μας `file://example.txt` ταιριάζει με το `file://{name}` στον διακομιστή. Το `example.txt` θα αντιστοιχηθεί στο `name`.

- Καλούμε ένα εργαλείο, το καλούμε καθορίζοντας το `name` και τα `arguments` του ως εξής:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Παίρνουμε μια προτροπή, για να πάρουμε μια προτροπή, καλούμε `getPrompt()` με `name` και `arguments`. Ο κώδικας του διακομιστή φαίνεται ως εξής:

    ```typescript
    server.prompt(
        "review-code",
        { code: z.string() },
        ({ code }) => ({
            messages: [{
            role: "user",
            content: {
                type: "text",
                text: `Please review this code:\n\n${code}`
            }
            }]
        })
    );
    ```

    και ο αντίστοιχος κώδικας πελάτη φαίνεται έτσι ώστε να ταιριάζει με όσα δηλώνονται στον διακομιστή:

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

Στον παραπάνω κώδικα έχουμε:

- Καλέσει έναν πόρο με όνομα `greeting` χρησιμοποιώντας `read_resource`.
- Καλεί ένα εργαλείο με όνομα `add` χρησιμοποιώντας `call_tool`.

### .NET

1. Ας προσθέσουμε κώδικα για να καλέσουμε ένα εργαλείο:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Για να εκτυπώσουμε το αποτέλεσμα, εδώ είναι κώδικας για να το χειριστούμε:

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

### Java

```java
// Call various calculator tools
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
System.out.println("Add Result = " + resultAdd);

CallToolResult resultSubtract = client.callTool(new CallToolRequest("subtract", Map.of("a", 10.0, "b", 4.0)));
System.out.println("Subtract Result = " + resultSubtract);

CallToolResult resultMultiply = client.callTool(new CallToolRequest("multiply", Map.of("a", 6.0, "b", 7.0)));
System.out.println("Multiply Result = " + resultMultiply);

CallToolResult resultDivide = client.callTool(new CallToolRequest("divide", Map.of("a", 20.0, "b", 4.0)));
System.out.println("Divide Result = " + resultDivide);

CallToolResult resultHelp = client.callTool(new CallToolRequest("help", Map.of()));
System.out.println("Help = " + resultHelp);
```

Στον παραπάνω κώδικα έχουμε:

- Καλέσει πολλαπλά εργαλεία αριθμομηχανής χρησιμοποιώντας τη μέθοδο `callTool()` με αντικείμενα `CallToolRequest`.
- Κάθε κλήση εργαλείου καθορίζει το όνομα του εργαλείου και έναν `Map` με τα ορίσματα που απαιτούνται από το εργαλείο.
- Τα εργαλεία του διακομιστή αναμένουν συγκεκριμένα ονόματα παραμέτρων (όπως "a", "b" για μαθηματικές πράξεις).
- Τα αποτελέσματα επιστρέφονται ως αντικείμενα `CallToolResult` που περιέχουν την απάντηση από τον διακομιστή.

### -5- Εκτέλεση του πελάτη

Για να εκτελέσετε τον πελάτη, πληκτρολογήστε την ακόλουθη εντολή στο τερματικό:

### TypeScript

Προσθέστε την ακόλουθη εγγραφή στην ενότητα "scripts" στο *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Καλέστε τον πελάτη με την ακόλουθη εντολή:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Πρώτα, βεβαιωθείτε ότι ο MCP server σας τρέχει στο `http://localhost:8080`. Στη συνέχεια εκτελέστε τον πελάτη:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Εναλλακτικά, μπορείτε να τρέξετε το πλήρες έργο πελάτη που παρέχεται στον φάκελο λύσης `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Ανάθεση

Σε αυτή την ανάθεση, θα χρησιμοποιήσετε όσα μάθατε για να δημιουργήσετε έναν πελάτη, αλλά φτιάξτε έναν δικό σας πελάτη.

Εδώ είναι ένας διακομιστής που μπορείτε να χρησιμοποιήσετε και πρέπει να τον καλέσετε μέσω του κώδικα του πελάτη σας. Δοκιμάστε να προσθέσετε περισσότερες λειτουργίες στον διακομιστή για να τον κάνετε πιο ενδιαφέροντα.

### TypeScript

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout

async function main() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
  console.error("MCPServer started on stdin/stdout");
}

main().catch((error) => {
  console.error("Fatal error: ", error);
  process.exit(1);
});
```

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

Δείτε αυτό το έργο για να δείτε πώς μπορείτε να [προσθέσετε προτροπές και πόρους](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Επίσης, ελέγξτε αυτόν τον σύνδεσμο για το πώς να καλέσετε [προτροπές και πόρους](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Λύση

Ο **φάκελος λύσης** περιέχει πλήρεις, έτοιμες προς εκτέλεση υλοποιήσεις πελατών που παρουσιάζουν όλες τις έννοιες που καλύφθηκαν σε αυτό το σεμινάριο. Κάθε λύση περιλαμβάνει κώδικα πελάτη και διακομιστή οργανωμένο σε ξεχωριστά, αυτόνομα έργα.

### 📁 Δομή Λύσης

Ο κατάλογος της λύσης είναι οργανωμένος ανά γλώσσα προγραμματισμού:

```
solution/
├── typescript/          # TypeScript client with npm/Node.js setup
│   ├── package.json     # Dependencies and scripts
│   ├── tsconfig.json    # TypeScript configuration
│   └── src/             # Source code
├── java/                # Java Spring Boot client project
│   ├── pom.xml          # Maven configuration
│   ├── src/             # Java source files
│   └── mvnw            # Maven wrapper
├── python/              # Python client implementation
│   ├── client.py        # Main client code
│   ├── server.py        # Compatible server
│   └── README.md        # Python-specific instructions
├── dotnet/              # .NET client project
│   ├── dotnet.csproj    # Project configuration
│   ├── Program.cs       # Main client code
│   └── dotnet.sln       # Solution file
└── server/              # Additional .NET server implementation
    ├── Program.cs       # Server code
    └── server.csproj    # Server project file
```

### 🚀 Τι Περιλαμβάνει Κάθε Λύση

Κάθε λύση ειδική για γλώσσα παρέχει:

- **Πλήρη υλοποίηση πελάτη** με όλες τις λειτουργίες από το σεμινάριο
- **Λειτουργική δομή έργου** με σωστές εξαρτήσεις και ρυθμίσεις
- **Σενάρια κατασκευής και εκτέλεσης** για εύκολη εγκατάσταση και εκτέλεση
- **Λεπτομερές README** με οδηγίες ειδικές για τη γλώσσα
- **Παραδείγματα χειρισμού σφαλμάτων** και επεξεργασίας αποτελεσμάτων

### 📖 Χρήση των Λύσεων

1. **Πλοηγηθείτε στον φάκελο της προτιμώμενης γλώσσας**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Ακολουθήστε τις οδηγίες στο README** σε κάθε φάκελο για:
   - Εγκατάσταση εξαρτήσεων
   - Κατασκευή του έργου
   - Εκτέλεση του πελάτη

3. **Παράδειγμα εξόδου** που θα πρέπει να δείτε:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Για πλήρη τεκμηρίωση και βήμα-βήμα οδηγίες, δείτε: **[📖 Τεκμηρίωση Λύσης](./solution/README.md)**

## 🎯 Πλήρη Παραδείγματα

Παρέχουμε πλήρεις, λειτουργικούς πελάτες για όλες τις γλώσσες προγραμματισμού που καλύφθηκαν σε αυτό το σεμινάριο. Αυτά τα παραδείγματα παρουσιάζουν όλη τη λειτουργικότητα που περιγράφηκε παραπάνω και μπορούν να χρησιμοποιηθούν ως υλοποιήσεις αναφοράς ή σημεία εκκίνησης για τα δικά σας έργα.

### Διαθέσιμα Πλήρη Παραδείγματα

| Γλώσσα | Αρχείο | Περιγραφή |
|--------|--------|-----------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | Πλήρης πελάτης Java με χρήση SSE μεταφοράς και ολοκληρωμένο χειρισμό σφαλμάτων |
| **C#** | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | Πλήρης πελάτης C# με χρήση stdio μεταφοράς και αυτόματη εκκίνηση διακομιστή |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Πλήρης πελάτης TypeScript με πλήρη υποστήριξη πρωτοκόλλου MCP |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py) | Πλήρης πελάτης Python με χρήση προτύπων async/await |

Κάθε πλήρες παράδειγμα περιλαμβάνει:

- ✅ **Εγκατάσταση σύνδεσης** και χειρισμό σφαλμάτων
- ✅ **Ανακάλυψη διακομιστή** (εργαλεία, πό
Και οι δύο προσεγγίσεις είναι πολύτιμες - χρησιμοποιήστε τον **φάκελο λύσεων** για ολοκληρωμένα έργα και τα **πλήρη παραδείγματα** για εκμάθηση και αναφορά.  
## Βασικά Συμπεράσματα

Τα βασικά συμπεράσματα αυτού του κεφαλαίου σχετικά με τους clients είναι τα εξής:

- Μπορούν να χρησιμοποιηθούν τόσο για την ανακάλυψη όσο και για την εκτέλεση λειτουργιών στον server.  
- Μπορούν να ξεκινήσουν έναν server ενώ ξεκινούν και οι ίδιοι (όπως σε αυτό το κεφάλαιο), αλλά οι clients μπορούν επίσης να συνδεθούν σε ήδη ενεργούς servers.  
- Αποτελούν έναν εξαιρετικό τρόπο για να δοκιμάσετε τις δυνατότητες του server, παράλληλα με εναλλακτικές όπως ο Inspector, όπως περιγράφηκε στο προηγούμενο κεφάλαιο.  

## Επιπλέον Πόροι

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Παραδείγματα

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Τι Ακολουθεί

- Επόμενο: [Creating a client with an LLM](../03-llm-client/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.