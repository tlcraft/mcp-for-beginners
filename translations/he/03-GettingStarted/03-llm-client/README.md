<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-17T07:28:28+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "he"
}
-->
# יצירת לקוח עם LLM

עד כה ראית כיצד ליצור שרת ולקוח. הלקוח הצליח לקרוא במפורש לשרת כדי לרשום את הכלים, המשאבים והפרומפטים שלו. עם זאת, זו לא גישה מאוד פרקטית. המשתמש שלך חי בעידן האג'נטי ומצפה להשתמש בפרומפטים ולתקשר עם LLM כדי לעשות זאת. עבור המשתמש שלך, לא משנה אם אתה משתמש ב-MCP או לא כדי לאחסן את היכולות שלך, אבל הם כן מצפים להשתמש בשפה טבעית כדי לתקשר. אז איך פותרים את זה? הפתרון הוא להוסיף LLM ללקוח.

## סקירה כללית

בשיעור זה נתמקד בהוספת LLM ללקוח שלך ונראה כיצד זה מספק חוויית משתמש טובה יותר.

## מטרות הלמידה

בסיום השיעור תוכל:

- ליצור לקוח עם LLM.
- לתקשר בצורה חלקה עם שרת MCP באמצעות LLM.
- לספק חוויית משתמש טובה יותר בצד הלקוח.

## גישה

בוא ננסה להבין את הגישה שעלינו לנקוט. הוספת LLM נשמעת פשוטה, אבל האם באמת נעשה זאת?

כך הלקוח יתקשר עם השרת:

1. יצירת חיבור עם השרת.

1. רשימת היכולות, הפרומפטים, המשאבים והכלים, ושמירת הסכמה שלהם.

1. הוספת LLM והעברת היכולות והשמות שנשמרו בפורמט שה-LLM מבין.

1. טיפול בפרומפט של המשתמש על ידי העברתו ל-LLM יחד עם הכלים שרשום הלקוח.

מעולה, עכשיו כשאנחנו מבינים איך לעשות זאת ברמה גבוהה, בוא ננסה זאת בתרגיל למטה.

## תרגיל: יצירת לקוח עם LLM

בתרגיל זה נלמד כיצד להוסיף LLM ללקוח שלנו.

## אימות באמצעות GitHub Personal Access Token

יצירת טוקן ב-GitHub היא תהליך פשוט. כך עושים זאת:

- עבור ל-GitHub Settings – לחץ על תמונת הפרופיל שלך בפינה הימנית העליונה ובחר Settings.
- עבור ל-Developer Settings – גלול למטה ולחץ על Developer Settings.
- בחר Personal Access Tokens – לחץ על Personal access tokens ואז Generate new token.
- הגדר את הטוקן שלך – הוסף הערה למטרת זיהוי, הגדר תאריך תפוגה ובחר את ההרשאות הנדרשות.
- צור והעתק את הטוקן – לחץ על Generate token, וודא להעתיק אותו מיד כי לא תוכל לראות אותו שוב.

### -1- התחברות לשרת

בוא ניצור קודם את הלקוח שלנו:

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
import { Transport } from "@modelcontextprotocol/sdk/shared/transport.js";
import OpenAI from "openai";
import { z } from "zod"; // Import zod for schema validation

class MCPClient {
    private openai: OpenAI;
    private client: Client;
    constructor(){
        this.openai = new OpenAI({
            baseURL: "https://models.inference.ai.azure.com", 
            apiKey: process.env.GITHUB_TOKEN,
        });

        this.client = new Client(
            {
                name: "example-client",
                version: "1.0.0"
            },
            {
                capabilities: {
                prompts: {},
                resources: {},
                tools: {}
                }
            }
            );    
    }
}
```

בקוד שלמעלה:

- ייבאנו את הספריות הנדרשות
- יצרנו מחלקה עם שני חברים, `client` ו-`openai`, שיעזרו לנו לנהל לקוח ולתקשר עם LLM בהתאמה.
- הגדרנו את מופע ה-LLM שלנו להשתמש ב-GitHub Models על ידי הגדרת `baseUrl` שמצביע ל-API של האינפרנס.

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

בקוד שלמעלה:

- ייבאנו את הספריות הנדרשות ל-MCP
- יצרנו לקוח

### .NET

```csharp
using Azure;
using Azure.AI.Inference;
using Azure.Identity;
using System.Text.Json;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
using System.Text.Json;

var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "/workspaces/mcp-for-beginners/03-GettingStarted/02-client/solution/server/bin/Debug/net8.0/server",
    Arguments = [],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

### Java

ראשית, תצטרך להוסיף את התלויות של LangChain4j לקובץ `pom.xml` שלך. הוסף את התלויות האלה כדי לאפשר אינטגרציה עם MCP ותמיכה ב-GitHub Models:

```xml
<properties>
    <langchain4j.version>1.0.0-beta3</langchain4j.version>
</properties>

<dependencies>
    <!-- LangChain4j MCP Integration -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-mcp</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- OpenAI Official API Client -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-open-ai-official</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- GitHub Models Support -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-github-models</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- Spring Boot Starter (optional, for production apps) -->
    <dependency>
        <groupId>org.springframework.boot</groupId>
        <artifactId>spring-boot-starter-actuator</artifactId>
    </dependency>
</dependencies>
```

לאחר מכן צור את מחלקת הלקוח ב-Java:

```java
import dev.langchain4j.mcp.McpToolProvider;
import dev.langchain4j.mcp.client.DefaultMcpClient;
import dev.langchain4j.mcp.client.McpClient;
import dev.langchain4j.mcp.client.transport.McpTransport;
import dev.langchain4j.mcp.client.transport.http.HttpMcpTransport;
import dev.langchain4j.model.chat.ChatLanguageModel;
import dev.langchain4j.model.openaiofficial.OpenAiOfficialChatModel;
import dev.langchain4j.service.AiServices;
import dev.langchain4j.service.tool.ToolProvider;

import java.time.Duration;
import java.util.List;

public class LangChain4jClient {
    
    public static void main(String[] args) throws Exception {        // Configure the LLM to use GitHub Models
        ChatLanguageModel model = OpenAiOfficialChatModel.builder()
                .isGitHubModels(true)
                .apiKey(System.getenv("GITHUB_TOKEN"))
                .timeout(Duration.ofSeconds(60))
                .modelName("gpt-4.1-nano")
                .build();

        // Create MCP transport for connecting to server
        McpTransport transport = new HttpMcpTransport.Builder()
                .sseUrl("http://localhost:8080/sse")
                .timeout(Duration.ofSeconds(60))
                .logRequests(true)
                .logResponses(true)
                .build();

        // Create MCP client
        McpClient mcpClient = new DefaultMcpClient.Builder()
                .transport(transport)
                .build();
    }
}
```

בקוד שלמעלה:

- **הוספנו את התלויות של LangChain4j**: נדרשות לאינטגרציה עם MCP, לקוח רשמי של OpenAI, ותמיכה ב-GitHub Models
- **ייבאנו את ספריות LangChain4j**: לאינטגרציה עם MCP ולפונקציונליות של מודל הצ'אט של OpenAI
- **יצרנו `ChatLanguageModel`**: שהוגדר להשתמש ב-GitHub Models עם הטוקן שלך מ-GitHub
- **הגדרנו תחבורה HTTP**: באמצעות Server-Sent Events (SSE) להתחברות לשרת MCP
- **יצרנו לקוח MCP**: שיטפל בתקשורת עם השרת
- **השתמשנו בתמיכה המובנית של LangChain4j ב-MCP**: שמפשטת את האינטגרציה בין LLM לשרת MCP

מעולה, לשלב הבא, בוא נרשום את היכולות בשרת.

### -2 רשימת יכולות השרת

כעת נתחבר לשרת ונבקש את היכולות שלו:

### Typescript

באותה מחלקה, הוסף את השיטות הבאות:

```typescript
async connectToServer(transport: Transport) {
     await this.client.connect(transport);
     this.run();
     console.error("MCPClient started on stdin/stdout");
}

async run() {
    console.log("Asking server for available tools");

    // listing tools
    const toolsResult = await this.client.listTools();
}
```

בקוד שלמעלה:

- הוספנו קוד להתחברות לשרת, `connectToServer`.
- יצרנו שיטת `run` שאחראית על ניהול זרימת האפליקציה שלנו. עד כה היא רק מציגה את הכלים, אבל נוסיף לה עוד בקרוב.

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
    print("Tool", tool.inputSchema["properties"])
```

הנה מה שהוספנו:

- רשימת משאבים וכלים והדפסתם. עבור כלים גם רשמנו את `inputSchema` שנשתמש בו מאוחר יותר.

### .NET

```csharp
async Task<List<ChatCompletionsToolDefinition>> GetMcpTools()
{
    Console.WriteLine("Listing tools");
    var tools = await mcpClient.ListToolsAsync();

    List<ChatCompletionsToolDefinition> toolDefinitions = new List<ChatCompletionsToolDefinition>();

    foreach (var tool in tools)
    {
        Console.WriteLine($"Connected to server with tools: {tool.Name}");
        Console.WriteLine($"Tool description: {tool.Description}");
        Console.WriteLine($"Tool parameters: {tool.JsonSchema}");

        // TODO: convert tool defintion from MCP tool to LLm tool     
    }

    return toolDefinitions;
}
```

בקוד שלמעלה:

- רשמנו את הכלים הזמינים בשרת MCP
- עבור כל כלי, רשמנו שם, תיאור והסכמה שלו. האחרון הוא משהו שנשתמש בו כדי לקרוא לכלים בקרוב.

### Java

```java
// Create a tool provider that automatically discovers MCP tools
ToolProvider toolProvider = McpToolProvider.builder()
        .mcpClients(List.of(mcpClient))
        .build();

// The MCP tool provider automatically handles:
// - Listing available tools from the MCP server
// - Converting MCP tool schemas to LangChain4j format
// - Managing tool execution and responses
```

בקוד שלמעלה:

- יצרנו `McpToolProvider` שמגלה ומרשם אוטומטית את כל הכלים משרת MCP
- ספק הכלים מטפל בהמרה בין סכמות הכלים של MCP לפורמט הכלים של LangChain4j באופן פנימי
- גישה זו מסתירה את תהליך רישום הכלים וההמרה הידנית

### -3- המרת יכולות השרת לכלי LLM

השלב הבא לאחר רישום יכולות השרת הוא להמיר אותן לפורמט שה-LLM מבין. ברגע שנעשה זאת, נוכל לספק את היכולות האלה ככלים ל-LLM שלנו.

### TypeScript

1. הוסף את הקוד הבא להמרת תגובת שרת MCP לפורמט כלי שה-LLM יכול להשתמש בו:

    ```typescript
    openAiToolAdapter(tool: {
        name: string;
        description?: string;
        input_schema: any;
        }) {
        // Create a zod schema based on the input_schema
        const schema = z.object(tool.input_schema);
    
        return {
            type: "function" as const, // Explicitly set type to "function"
            function: {
            name: tool.name,
            description: tool.description,
            parameters: {
            type: "object",
            properties: tool.input_schema.properties,
            required: tool.input_schema.required,
            },
            },
        };
    }

    ```

    הקוד שלמעלה לוקח תגובה משרת MCP וממיר אותה להגדרת כלי שה-LLM מבין.

1. עכשיו נעדכן את שיטת `run` כדי לרשום את יכולות השרת:

    ```typescript
    async run() {
        console.log("Asking server for available tools");
        const toolsResult = await this.client.listTools();
        const tools = toolsResult.tools.map((tool) => {
            return this.openAiToolAdapter({
            name: tool.name,
            description: tool.description,
            input_schema: tool.inputSchema,
            });
        });
    }
    ```

    בקוד שלמעלה, עדכנו את שיטת `run` כדי למפות את התוצאה ולקרוא עבור כל פריט ל-`openAiToolAdapter`.

### Python

1. קודם, ניצור את פונקציית ההמרה הבאה

    ```python
    def convert_to_llm_tool(tool):
        tool_schema = {
            "type": "function",
            "function": {
                "name": tool.name,
                "description": tool.description,
                "type": "function",
                "parameters": {
                    "type": "object",
                    "properties": tool.inputSchema["properties"]
                }
            }
        }

        return tool_schema
    ```

    בפונקציה `convert_to_llm_tools` אנו לוקחים תגובת כלי MCP וממירים אותה לפורמט שה-LLM מבין.

1. לאחר מכן, נעדכן את קוד הלקוח שלנו כדי להשתמש בפונקציה כך:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    כאן, אנו מוסיפים קריאה ל-`convert_to_llm_tool` כדי להמיר את תגובת כלי MCP למשהו שנוכל להזין ל-LLM מאוחר יותר.

### .NET

1. נוסיף קוד להמרת תגובת כלי MCP למשהו שה-LLM יכול להבין

```csharp
ChatCompletionsToolDefinition ConvertFrom(string name, string description, JsonElement jsonElement)
{ 
    // convert the tool to a function definition
    FunctionDefinition functionDefinition = new FunctionDefinition(name)
    {
        Description = description,
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = jsonElement
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
    };

    // create a tool definition
    ChatCompletionsToolDefinition toolDefinition = new ChatCompletionsToolDefinition(functionDefinition);
    return toolDefinition;
}
```

בקוד שלמעלה:

- יצרנו פונקציה `ConvertFrom` שלוקחת שם, תיאור וסכמת קלט.
- הגדרנו פונקציונליות שיוצרת `FunctionDefinition` שמועברת ל-`ChatCompletionsDefinition`. האחרון הוא משהו שה-LLM מבין.

1. נראה כיצד נעדכן קוד קיים כדי לנצל את הפונקציה הזו:

    ```csharp
    async Task<List<ChatCompletionsToolDefinition>> GetMcpTools()
    {
        Console.WriteLine("Listing tools");
        var tools = await mcpClient.ListToolsAsync();

        List<ChatCompletionsToolDefinition> toolDefinitions = new List<ChatCompletionsToolDefinition>();

        foreach (var tool in tools)
        {
            Console.WriteLine($"Connected to server with tools: {tool.Name}");
            Console.WriteLine($"Tool description: {tool.Description}");
            Console.WriteLine($"Tool parameters: {tool.JsonSchema}");

            JsonElement propertiesElement;
            tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

            var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
            Console.WriteLine($"Tool definition: {def}");
            toolDefinitions.Add(def);

            Console.WriteLine($"Properties: {propertiesElement}");        
        }

        return toolDefinitions;
    }
    ```

    בקוד שלמעלה:

    - עדכנו את הפונקציה להמרת תגובת כלי MCP לכלי LLM. נציין את הקוד שהוספנו:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        סכמת הקלט היא חלק מתגובת הכלי אך תחת המאפיין "properties", לכן יש לחלץ אותה. בנוסף, כעת אנו קוראים ל-`ConvertFrom` עם פרטי הכלי. לאחר שעשינו את העבודה הכבדה, נראה כיצד הקריאה מתבצעת כשנטפל בפרומפט של המשתמש בהמשך.

### Java

```java
// Create a Bot interface for natural language interaction
public interface Bot {
    String chat(String prompt);
}

// Configure the AI service with LLM and MCP tools
Bot bot = AiServices.builder(Bot.class)
        .chatLanguageModel(model)
        .toolProvider(toolProvider)
        .build();
```

בקוד שלמעלה:

- הגדרנו ממשק פשוט `Bot` לאינטראקציות בשפה טבעית
- השתמשנו ב-`AiServices` של LangChain4j כדי לקשר אוטומטית את ה-LLM עם ספק הכלים של MCP
- המסגרת מטפלת אוטומטית בהמרת סכמות הכלים וקריאות לפונקציות מאחורי הקלעים
- גישה זו מבטלת את הצורך בהמרת כלים ידנית - LangChain4j מטפל בכל המורכבות של המרת כלים מ-MCP לפורמט תואם LLM

מעולה, אנחנו מוכנים לטפל בבקשות משתמש, אז בוא נתקדם לשלב הבא.

### -4- טיפול בבקשת פרומפט של משתמש

בחלק זה של הקוד נטפל בבקשות המשתמש.

### TypeScript

1. הוסף שיטה שתשמש לקריאה ל-LLM שלנו:

    ```typescript
    async callTools(
        tool_calls: OpenAI.Chat.Completions.ChatCompletionMessageToolCall[],
        toolResults: any[]
    ) {
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);


        // 2. Call the server's tool 
        const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
        });

        console.log("Tool result: ", toolResult);

        // 3. Do something with the result
        // TODO  

        }
    }
    ```

    בקוד שלמעלה:

    - הוספנו שיטה בשם `callTools`.
    - השיטה מקבלת תגובת LLM ובודקת אילו כלים נקראו, אם בכלל:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - קוראת לכלי, אם ה-LLM מציין שיש לקרוא לו:

        ```typescript
        // 2. Call the server's tool 
        const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
        });

        console.log("Tool result: ", toolResult);

        // 3. Do something with the result
        // TODO  
        ```

1. עדכן את שיטת `run` לכלול קריאות ל-LLM וקריאה ל-`callTools`:

    ```typescript

    // 1. Create messages that's input for the LLM
    const prompt = "What is the sum of 2 and 3?"

    const messages: OpenAI.Chat.Completions.ChatCompletionMessageParam[] = [
            {
                role: "user",
                content: prompt,
            },
        ];

    console.log("Querying LLM: ", messages[0].content);

    // 2. Calling the LLM
    let response = this.openai.chat.completions.create({
        model: "gpt-4o-mini",
        max_tokens: 1000,
        messages,
        tools: tools,
    });    

    let results: any[] = [];

    // 3. Go through the LLM response,for each choice, check if it has tool calls 
    (await response).choices.map(async (choice: { message: any; }) => {
        const message = choice.message;
        if (message.tool_calls) {
            console.log("Making tool call")
            await this.callTools(message.tool_calls, results);
        }
    });
    ```

מעולה, הנה הקוד המלא:

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
import { Transport } from "@modelcontextprotocol/sdk/shared/transport.js";
import OpenAI from "openai";
import { z } from "zod"; // Import zod for schema validation

class MyClient {
    private openai: OpenAI;
    private client: Client;
    constructor(){
        this.openai = new OpenAI({
            baseURL: "https://models.inference.ai.azure.com", // might need to change to this url in the future: https://models.github.ai/inference
            apiKey: process.env.GITHUB_TOKEN,
        });

       
        
        this.client = new Client(
            {
                name: "example-client",
                version: "1.0.0"
            },
            {
                capabilities: {
                prompts: {},
                resources: {},
                tools: {}
                }
            }
            );    
    }

    async connectToServer(transport: Transport) {
        await this.client.connect(transport);
        this.run();
        console.error("MCPClient started on stdin/stdout");
    }

    openAiToolAdapter(tool: {
        name: string;
        description?: string;
        input_schema: any;
          }) {
          // Create a zod schema based on the input_schema
          const schema = z.object(tool.input_schema);
      
          return {
            type: "function" as const, // Explicitly set type to "function"
            function: {
              name: tool.name,
              description: tool.description,
              parameters: {
              type: "object",
              properties: tool.input_schema.properties,
              required: tool.input_schema.required,
              },
            },
          };
    }
    
    async callTools(
        tool_calls: OpenAI.Chat.Completions.ChatCompletionMessageToolCall[],
        toolResults: any[]
      ) {
        for (const tool_call of tool_calls) {
          const toolName = tool_call.function.name;
          const args = tool_call.function.arguments;
    
          console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);
    
    
          // 2. Call the server's tool 
          const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
          });
    
          console.log("Tool result: ", toolResult);
    
          // 3. Do something with the result
          // TODO  
    
         }
    }

    async run() {
        console.log("Asking server for available tools");
        const toolsResult = await this.client.listTools();
        const tools = toolsResult.tools.map((tool) => {
            return this.openAiToolAdapter({
              name: tool.name,
              description: tool.description,
              input_schema: tool.inputSchema,
            });
        });

        const prompt = "What is the sum of 2 and 3?";
    
        const messages: OpenAI.Chat.Completions.ChatCompletionMessageParam[] = [
            {
                role: "user",
                content: prompt,
            },
        ];

        console.log("Querying LLM: ", messages[0].content);
        let response = this.openai.chat.completions.create({
            model: "gpt-4o-mini",
            max_tokens: 1000,
            messages,
            tools: tools,
        });    

        let results: any[] = [];
    
        // 1. Go through the LLM response,for each choice, check if it has tool calls 
        (await response).choices.map(async (choice: { message: any; }) => {
          const message = choice.message;
          if (message.tool_calls) {
              console.log("Making tool call")
              await this.callTools(message.tool_calls, results);
          }
        });
    }
    
}

let client = new MyClient();
 const transport = new StdioClientTransport({
            command: "node",
            args: ["./build/index.js"]
        });

client.connectToServer(transport);
```

### Python

1. נוסיף כמה ייבואיים הנדרשים לקריאה ל-LLM

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. לאחר מכן נוסיף את הפונקציה שתקריא ל-LLM:

    ```python
    # llm

    def call_llm(prompt, functions):
        token = os.environ["GITHUB_TOKEN"]
        endpoint = "https://models.inference.ai.azure.com"

        model_name = "gpt-4o"

        client = ChatCompletionsClient(
            endpoint=endpoint,
            credential=AzureKeyCredential(token),
        )

        print("CALLING LLM")
        response = client.complete(
            messages=[
                {
                "role": "system",
                "content": "You are a helpful assistant.",
                },
                {
                "role": "user",
                "content": prompt,
                },
            ],
            model=model_name,
            tools = functions,
            # Optional parameters
            temperature=1.,
            max_tokens=1000,
            top_p=1.    
        )

        response_message = response.choices[0].message
        
        functions_to_call = []

        if response_message.tool_calls:
            for tool_call in response_message.tool_calls:
                print("TOOL: ", tool_call)
                name = tool_call.function.name
                args = json.loads(tool_call.function.arguments)
                functions_to_call.append({ "name": name, "args": args })

        return functions_to_call
    ```

    בקוד שלמעלה:

    - העברנו את הפונקציות שמצאנו בשרת MCP והמרנו ל-LLM.
    - לאחר מכן קראנו ל-LLM עם הפונקציות הללו.
    - בדקנו את התוצאה כדי לראות אילו פונקציות יש לקרוא, אם בכלל.
    - לבסוף, העברנו מערך של פונקציות לקריאה.

1. שלב סופי, נעדכן את הקוד הראשי שלנו:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    זהו, זה השלב הסופי, בקוד שלמעלה:

    - קוראים לכלי MCP דרך `call_tool` באמצעות פונקציה שה-LLM חשב שצריך לקרוא לה בהתבסס על הפרומפט שלנו.
    - מדפיסים את תוצאת הקריאה לכלי לשרת MCP.

### .NET

1. נראה קוד לביצוע בקשת פרומפט ל-LLM:

    ```csharp
    var tools = await GetMcpTools();

    for (int i = 0; i < tools.Count; i++)
    {
        var tool = tools[i];
        Console.WriteLine($"MCP Tools def: {i}: {tool}");
    }

    // 0. Define the chat history and the user message
    var userMessage = "add 2 and 4";

    chatHistory.Add(new ChatRequestUserMessage(userMessage));

    // 1. Define tools
    ChatCompletionsToolDefinition def = CreateToolDefinition();


    // 2. Define options, including the tools
    var options = new ChatCompletionsOptions(chatHistory)
    {
        Model = "gpt-4o-mini",
        Tools = { tools[0] }
    };

    // 3. Call the model  

    ChatCompletions? response = await client.CompleteAsync(options);
    var content = response.Content;

    ```

    בקוד שלמעלה:

    - הבאת כלים משרת MCP, `var tools = await GetMcpTools()`.
    - הגדרת פרומפט משתמש `userMessage`.
    - בניית אובייקט אפשרויות שמציין מודל וכלים.
    - ביצוע בקשה ל-LLM.

1. שלב אחרון, נראה אם ה-LLM חושב שצריך לקרוא לפונקציה:

    ```csharp
    // 4. Check if the response contains a function call
    ChatCompletionsToolCall? calls = response.ToolCalls.FirstOrDefault();
    for (int i = 0; i < response.ToolCalls.Count; i++)
    {
        var call = response.ToolCalls[i];
        Console.WriteLine($"Tool call {i}: {call.Name} with arguments {call.Arguments}");
        //Tool call 0: add with arguments {"a":2,"b":4}

        var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(call.Arguments);
        var result = await mcpClient.CallToolAsync(
            call.Name,
            dict!,
            cancellationToken: CancellationToken.None
        );

        Console.WriteLine(result.Content.First(c => c.Type == "text").Text);

    }
    ```

    בקוד שלמעלה:

    - עברנו בלולאה על רשימת קריאות לפונקציות.
    - עבור כל קריאה לכלי, חילצנו שם וארגומנטים וקראנו לכלי בשרת MCP באמצעות לקוח MCP. לבסוף הדפסנו את התוצאות.

הנה הקוד המלא:

```csharp
using Azure;
using Azure.AI.Inference;
using Azure.Identity;
using System.Text.Json;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
using System.Text.Json;

var endpoint = "https://models.inference.ai.azure.com";
var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN"); // Your GitHub Access Token
var client = new ChatCompletionsClient(new Uri(endpoint), new AzureKeyCredential(token));
var chatHistory = new List<ChatRequestMessage>
{
    new ChatRequestSystemMessage("You are a helpful assistant that knows about AI")
};

var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "/workspaces/mcp-for-beginners/03-GettingStarted/02-client/solution/server/bin/Debug/net8.0/server",
    Arguments = [],
});

Console.WriteLine("Setting up stdio transport");

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);

ChatCompletionsToolDefinition ConvertFrom(string name, string description, JsonElement jsonElement)
{ 
    // convert the tool to a function definition
    FunctionDefinition functionDefinition = new FunctionDefinition(name)
    {
        Description = description,
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = jsonElement
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
    };

    // create a tool definition
    ChatCompletionsToolDefinition toolDefinition = new ChatCompletionsToolDefinition(functionDefinition);
    return toolDefinition;
}



async Task<List<ChatCompletionsToolDefinition>> GetMcpTools()
{
    Console.WriteLine("Listing tools");
    var tools = await mcpClient.ListToolsAsync();

    List<ChatCompletionsToolDefinition> toolDefinitions = new List<ChatCompletionsToolDefinition>();

    foreach (var tool in tools)
    {
        Console.WriteLine($"Connected to server with tools: {tool.Name}");
        Console.WriteLine($"Tool description: {tool.Description}");
        Console.WriteLine($"Tool parameters: {tool.JsonSchema}");

        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);

        Console.WriteLine($"Properties: {propertiesElement}");        
    }

    return toolDefinitions;
}

// 1. List tools on mcp server

var tools = await GetMcpTools();
for (int i = 0; i < tools.Count; i++)
{
    var tool = tools[i];
    Console.WriteLine($"MCP Tools def: {i}: {tool}");
}

// 2. Define the chat history and the user message
var userMessage = "add 2 and 4";

chatHistory.Add(new ChatRequestUserMessage(userMessage));


// 3. Define options, including the tools
var options = new ChatCompletionsOptions(chatHistory)
{
    Model = "gpt-4o-mini",
    Tools = { tools[0] }
};

// 4. Call the model  

ChatCompletions? response = await client.CompleteAsync(options);
var content = response.Content;

// 5. Check if the response contains a function call
ChatCompletionsToolCall? calls = response.ToolCalls.FirstOrDefault();
for (int i = 0; i < response.ToolCalls.Count; i++)
{
    var call = response.ToolCalls[i];
    Console.WriteLine($"Tool call {i}: {call.Name} with arguments {call.Arguments}");
    //Tool call 0: add with arguments {"a":2,"b":4}

    var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(call.Arguments);
    var result = await mcpClient.CallToolAsync(
        call.Name,
        dict!,
        cancellationToken: CancellationToken.None
    );

    Console.WriteLine(result.Content.First(c => c.Type == "text").Text);

}

// 5. Print the generic response
Console.WriteLine($"Assistant response: {content}");
```

### Java

```java
try {
    // Execute natural language requests that automatically use MCP tools
    String response = bot.chat("Calculate the sum of 24.5 and 17.3 using the calculator service");
    System.out.println(response);

    response = bot.chat("What's the square root of 144?");
    System.out.println(response);

    response = bot.chat("Show me the help for the calculator service");
    System.out.println(response);
} finally {
    mcpClient.close();
}
```

בקוד שלמעלה:

- השתמשנו בפרומפטים פשוטים בשפה טבעית כדי לתקשר עם כלי שרת MCP
- מסגרת LangChain4j מטפלת אוטומטית ב:
  - המרת פרומפטי משתמש לקריאות לכלים כשצריך
  - קריאה לכלי MCP המתאימים על פי החלטת ה-LLM
  - ניהול זרימת השיחה בין ה-LLM לשרת MCP
- שיטת `bot.chat()` מחזירה תגובות בשפה טבעית שיכולות לכלול תוצאות מביצועי כלי MCP
- גישה זו מספקת חוויית משתמש חלקה שבה המשתמשים לא צריכים לדעת על המימוש הפנימי של MCP

דוגמת קוד מלאה:

```java
public class LangChain4jClient {
    
    public static void main(String[] args) throws Exception {        ChatLanguageModel model = OpenAiOfficialChatModel.builder()
                .isGitHubModels(true)
                .apiKey(System.getenv("GITHUB_TOKEN"))
                .timeout(Duration.ofSeconds(60))
                .modelName("gpt-4.1-nano")
                .timeout(Duration.ofSeconds(60))
                .build();

        McpTransport transport = new HttpMcpTransport.Builder()
                .sseUrl("http://localhost:8080/sse")
                .timeout(Duration.ofSeconds(60))
                .logRequests(true)
                .logResponses(true)
                .build();

        McpClient mcpClient = new DefaultMcpClient.Builder()
                .transport(transport)
                .build();

        ToolProvider toolProvider = McpToolProvider.builder()
                .mcpClients(List.of(mcpClient))
                .build();

        Bot bot = AiServices.builder(Bot.class)
                .chatLanguageModel(model)
                .toolProvider(toolProvider)
                .build();

        try {
            String response = bot.chat("Calculate the sum of 24.5 and 17.3 using the calculator service");
            System.out.println(response);

            response = bot.chat("What's the square root of 144?");
            System.out.println(response);

            response = bot.chat("Show me the help for the calculator service");
            System.out.println(response);
        } finally {
            mcpClient.close();
        }
    }
}
```

מעולה, עשית את זה!

## משימה

קח את הקוד מהתרגיל ובנה את השרת עם עוד כלים. לאחר מכן צור לקוח עם LLM, כמו בתרגיל, ובדוק אותו עם פרומפטים שונים כדי לוודא שכל הכלים בשרת שלך נקראים בצורה דינמית. דרך בניית הלקוח הזו מבטיחה חוויית משתמש מצוינת, שכן המשתמשים יכולים להשתמש בפרומפטים במקום פקודות מדויקות של הלקוח ולהיות בלתי מודעים לקריאות לשרת MCP.

## פתרון

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## נקודות מפתח

- הוספת LLM ללקוח שלך מספקת דרך טובה יותר למשתמשים לתקשר עם שרתי MCP.
- יש להמיר את תגובת שרת MCP למשהו שה-LLM יכול להבין.

## דוגמאות

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## משאבים נוספים

## מה הלאה

- הבא: [צריכת שרת באמצעות Visual Studio Code](../04-vscode/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור הסמכות. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.