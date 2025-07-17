<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "dd0fdbbbebbef2b6b179ceba21d82ed2",
  "translation_date": "2025-07-17T05:48:05+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "el"
}
-->
# Ξεκινώντας με το MCP

Καλώς ήρθατε στα πρώτα σας βήματα με το Model Context Protocol (MCP)! Είτε είστε νέοι στο MCP είτε θέλετε να εμβαθύνετε την κατανόησή σας, αυτός ο οδηγός θα σας καθοδηγήσει στη βασική ρύθμιση και τη διαδικασία ανάπτυξης. Θα ανακαλύψετε πώς το MCP επιτρέπει την απρόσκοπτη ενσωμάτωση μεταξύ μοντέλων AI και εφαρμογών, και θα μάθετε πώς να προετοιμάσετε γρήγορα το περιβάλλον σας για την κατασκευή και δοκιμή λύσεων που βασίζονται σε MCP.

> TLDR; Αν δημιουργείτε εφαρμογές AI, γνωρίζετε ότι μπορείτε να προσθέσετε εργαλεία και άλλους πόρους στο LLM (μεγάλο γλωσσικό μοντέλο), για να το κάνετε πιο ενημερωμένο. Ωστόσο, αν τοποθετήσετε αυτά τα εργαλεία και πόρους σε έναν διακομιστή, οι δυνατότητες της εφαρμογής και του διακομιστή μπορούν να χρησιμοποιηθούν από οποιονδήποτε πελάτη με ή χωρίς LLM.

## Επισκόπηση

Αυτό το μάθημα παρέχει πρακτικές οδηγίες για τη ρύθμιση περιβαλλόντων MCP και την κατασκευή των πρώτων σας εφαρμογών MCP. Θα μάθετε πώς να ρυθμίζετε τα απαραίτητα εργαλεία και πλαίσια, να δημιουργείτε βασικούς MCP διακομιστές, να φτιάχνετε εφαρμογές-ξενιστές και να δοκιμάζετε τις υλοποιήσεις σας.

Το Model Context Protocol (MCP) είναι ένα ανοιχτό πρωτόκολλο που τυποποιεί τον τρόπο με τον οποίο οι εφαρμογές παρέχουν πλαίσιο στα LLM. Σκεφτείτε το MCP σαν μια θύρα USB-C για εφαρμογές AI - προσφέρει έναν τυποποιημένο τρόπο σύνδεσης μοντέλων AI με διάφορες πηγές δεδομένων και εργαλεία.

## Στόχοι Μάθησης

Στο τέλος αυτού του μαθήματος, θα μπορείτε να:

- Ρυθμίζετε περιβάλλοντα ανάπτυξης για MCP σε C#, Java, Python, TypeScript και JavaScript
- Δημιουργείτε και αναπτύσσετε βασικούς MCP διακομιστές με προσαρμοσμένα χαρακτηριστικά (πόροι, προτροπές και εργαλεία)
- Δημιουργείτε εφαρμογές-ξενιστές που συνδέονται με MCP διακομιστές
- Δοκιμάζετε και εντοπίζετε σφάλματα στις υλοποιήσεις MCP

## Ρύθμιση του Περιβάλλοντος MCP

Πριν ξεκινήσετε να εργάζεστε με το MCP, είναι σημαντικό να προετοιμάσετε το περιβάλλον ανάπτυξής σας και να κατανοήσετε τη βασική ροή εργασίας. Αυτή η ενότητα θα σας καθοδηγήσει στα αρχικά βήματα ρύθμισης για να εξασφαλίσετε μια ομαλή εκκίνηση με το MCP.

### Προαπαιτούμενα

Πριν βουτήξετε στην ανάπτυξη MCP, βεβαιωθείτε ότι έχετε:

- **Περιβάλλον Ανάπτυξης**: Για τη γλώσσα που έχετε επιλέξει (C#, Java, Python, TypeScript ή JavaScript)
- **IDE/Επεξεργαστή**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ή οποιονδήποτε σύγχρονο επεξεργαστή κώδικα
- **Διαχειριστές Πακέτων**: NuGet, Maven/Gradle, pip ή npm/yarn
- **Κλειδιά API**: Για οποιεσδήποτε υπηρεσίες AI σκοπεύετε να χρησιμοποιήσετε στις εφαρμογές-ξενιστές σας

## Βασική Δομή MCP Διακομιστή

Ένας MCP διακομιστής συνήθως περιλαμβάνει:

- **Διαμόρφωση Διακομιστή**: Ρύθμιση θύρας, αυθεντικοποίησης και άλλων ρυθμίσεων
- **Πόροι**: Δεδομένα και πλαίσιο διαθέσιμα στα LLM
- **Εργαλεία**: Λειτουργίες που μπορούν να καλούν τα μοντέλα
- **Προτροπές**: Πρότυπα για τη δημιουργία ή τη δομή κειμένου

Ακολουθεί ένα απλοποιημένο παράδειγμα σε TypeScript:

```typescript
import { Server, Tool, Resource } from "@modelcontextprotocol/typescript-server-sdk";

// Create a new MCP server
const server = new Server({
  port: 3000,
  name: "Example MCP Server",
  version: "1.0.0"
});

// Register a tool
server.registerTool({
  name: "calculator",
  description: "Performs basic calculations",
  parameters: {
    expression: {
      type: "string",
      description: "The math expression to evaluate"
    }
  },
  handler: async (params) => {
    const result = eval(params.expression);
    return { result };
  }
});

// Start the server
server.start();
```

Στον παραπάνω κώδικα:

- Εισάγουμε τις απαραίτητες κλάσεις από το MCP TypeScript SDK.
- Δημιουργούμε και διαμορφώνουμε μια νέα παρουσία MCP διακομιστή.
- Καταχωρούμε ένα προσαρμοσμένο εργαλείο (`calculator`) με μια συνάρτηση χειρισμού.
- Ξεκινάμε τον διακομιστή για να ακούει εισερχόμενα αιτήματα MCP.

## Δοκιμές και Εντοπισμός Σφαλμάτων

Πριν ξεκινήσετε τις δοκιμές του MCP διακομιστή σας, είναι σημαντικό να κατανοήσετε τα διαθέσιμα εργαλεία και τις βέλτιστες πρακτικές για τον εντοπισμό σφαλμάτων. Η αποτελεσματική δοκιμή διασφαλίζει ότι ο διακομιστής σας λειτουργεί όπως αναμένεται και σας βοηθά να εντοπίσετε και να επιλύσετε γρήγορα προβλήματα. Η επόμενη ενότητα περιγράφει τις προτεινόμενες προσεγγίσεις για την επικύρωση της υλοποίησης MCP.

Το MCP παρέχει εργαλεία για να σας βοηθήσει να δοκιμάσετε και να εντοπίσετε σφάλματα στους διακομιστές σας:

- **Εργαλείο Inspector**, αυτή η γραφική διεπαφή σας επιτρέπει να συνδεθείτε στον διακομιστή σας και να δοκιμάσετε τα εργαλεία, τις προτροπές και τους πόρους σας.
- **curl**, μπορείτε επίσης να συνδεθείτε στον διακομιστή σας χρησιμοποιώντας ένα εργαλείο γραμμής εντολών όπως το curl ή άλλους πελάτες που μπορούν να δημιουργήσουν και να εκτελέσουν εντολές HTTP.

### Χρήση του MCP Inspector

Το [MCP Inspector](https://github.com/modelcontextprotocol/inspector) είναι ένα οπτικό εργαλείο δοκιμών που σας βοηθά να:

1. **Ανακαλύψετε τις Δυνατότητες του Διακομιστή**: Αυτόματη ανίχνευση διαθέσιμων πόρων, εργαλείων και προτροπών
2. **Δοκιμάσετε την Εκτέλεση Εργαλείων**: Δοκιμάστε διαφορετικές παραμέτρους και δείτε τις απαντήσεις σε πραγματικό χρόνο
3. **Δείτε τα Μεταδεδομένα του Διακομιστή**: Εξετάστε πληροφορίες διακομιστή, σχήματα και ρυθμίσεις

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

Όταν εκτελέσετε τις παραπάνω εντολές, ο MCP Inspector θα ανοίξει μια τοπική διεπαφή ιστού στον περιηγητή σας. Αναμένεται να δείτε έναν πίνακα ελέγχου που εμφανίζει τους καταχωρημένους MCP διακομιστές σας, τα διαθέσιμα εργαλεία, πόρους και προτροπές τους. Η διεπαφή σας επιτρέπει να δοκιμάζετε διαδραστικά την εκτέλεση εργαλείων, να ελέγχετε τα μεταδεδομένα του διακομιστή και να βλέπετε απαντήσεις σε πραγματικό χρόνο, καθιστώντας ευκολότερη την επικύρωση και τον εντοπισμό σφαλμάτων στις υλοποιήσεις MCP.

Ακολουθεί ένα στιγμιότυπο οθόνης του πώς μπορεί να φαίνεται:

![](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.el.png)

## Συνηθισμένα Προβλήματα Ρύθμισης και Λύσεις

| Πρόβλημα | Πιθανή Λύση |
|----------|-------------|
| Απόρριψη σύνδεσης | Ελέγξτε αν ο διακομιστής τρέχει και αν η θύρα είναι σωστή |
| Σφάλματα εκτέλεσης εργαλείων | Επανεξετάστε την επικύρωση παραμέτρων και τη διαχείριση σφαλμάτων |
| Αποτυχίες αυθεντικοποίησης | Επαληθεύστε τα κλειδιά API και τα δικαιώματα |
| Σφάλματα επικύρωσης σχήματος | Βεβαιωθείτε ότι οι παράμετροι ταιριάζουν με το ορισμένο σχήμα |
| Ο διακομιστής δεν ξεκινά | Ελέγξτε για συγκρούσεις θυρών ή ελλείποντες εξαρτήσεις |
| Σφάλματα CORS | Ρυθμίστε σωστά τις κεφαλίδες CORS για αιτήματα από άλλες προελεύσεις |
| Προβλήματα αυθεντικοποίησης | Επαληθεύστε την εγκυρότητα του token και τα δικαιώματα |

## Τοπική Ανάπτυξη

Για τοπική ανάπτυξη και δοκιμές, μπορείτε να τρέξετε MCP διακομιστές απευθείας στον υπολογιστή σας:

1. **Ξεκινήστε τη διαδικασία διακομιστή**: Εκτελέστε την εφαρμογή MCP διακομιστή σας
2. **Ρυθμίστε το δίκτυο**: Βεβαιωθείτε ότι ο διακομιστής είναι προσβάσιμος στη σωστή θύρα
3. **Συνδέστε πελάτες**: Χρησιμοποιήστε τοπικά URLs σύνδεσης όπως `http://localhost:3000`

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## Δημιουργία του πρώτου σας MCP Διακομιστή

Έχουμε καλύψει τα [Βασικά Στοιχεία](/01-CoreConcepts/README.md) σε προηγούμενο μάθημα, τώρα ήρθε η ώρα να εφαρμόσουμε αυτή τη γνώση.

### Τι μπορεί να κάνει ένας διακομιστής

Πριν ξεκινήσουμε να γράφουμε κώδικα, ας θυμηθούμε τι μπορεί να κάνει ένας διακομιστής:

Ένας MCP διακομιστής μπορεί, για παράδειγμα:

- Να έχει πρόσβαση σε τοπικά αρχεία και βάσεις δεδομένων
- Να συνδέεται με απομακρυσμένα APIs
- Να εκτελεί υπολογισμούς
- Να ενσωματώνεται με άλλα εργαλεία και υπηρεσίες
- Να παρέχει διεπαφή χρήστη για αλληλεπίδραση

Τέλεια, τώρα που ξέρουμε τι μπορούμε να κάνουμε, ας ξεκινήσουμε τον κώδικα.

## Άσκηση: Δημιουργία διακομιστή

Για να δημιουργήσετε έναν διακομιστή, πρέπει να ακολουθήσετε τα εξής βήματα:

- Εγκαταστήστε το MCP SDK.
- Δημιουργήστε ένα έργο και ρυθμίστε τη δομή του.
- Γράψτε τον κώδικα του διακομιστή.
- Δοκιμάστε τον διακομιστή.

### -1- Εγκατάσταση του SDK

Αυτό διαφέρει λίγο ανάλογα με το runtime που έχετε επιλέξει, οπότε επιλέξτε ένα από τα παρακάτω runtimes:

> [!NOTE]
> Για Python, θα δημιουργήσουμε πρώτα τη δομή του έργου και μετά θα εγκαταστήσουμε τις εξαρτήσεις.

### TypeScript

```sh
npm install @modelcontextprotocol/sdk zod
npm install -D @types/node typescript
```

### Python

```sh
# Create project dir
mkdir calculator-server
cd calculator-server
# Open the folder in Visual Studio Code - Skip this if you are using a different IDE
code .
```

### .NET

```sh
dotnet new console -n McpCalculatorServer
cd McpCalculatorServer
```

### Java

Για Java, δημιουργήστε ένα έργο Spring Boot:

```bash
curl https://start.spring.io/starter.zip \
  -d dependencies=web \
  -d javaVersion=21 \
  -d type=maven-project \
  -d groupId=com.example \
  -d artifactId=calculator-server \
  -d name=McpServer \
  -d packageName=com.microsoft.mcp.sample.server \
  -o calculator-server.zip
```

Αποσυμπιέστε το αρχείο zip:

```bash
unzip calculator-server.zip -d calculator-server
cd calculator-server
# optional remove the unused test
rm -rf src/test/java
```

Προσθέστε την παρακάτω πλήρη διαμόρφωση στο αρχείο *pom.xml*:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<project xmlns="http://maven.apache.org/POM/4.0.0"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    xsi:schemaLocation="http://maven.apache.org/POM/4.0.0 http://maven.apache.org/xsd/maven-4.0.0.xsd">
    <modelVersion>4.0.0</modelVersion>
    
    <!-- Spring Boot parent for dependency management -->
    <parent>
        <groupId>org.springframework.boot</groupId>
        <artifactId>spring-boot-starter-parent</artifactId>
        <version>3.5.0</version>
        <relativePath />
    </parent>

    <!-- Project coordinates -->
    <groupId>com.example</groupId>
    <artifactId>calculator-server</artifactId>
    <version>0.0.1-SNAPSHOT</version>
    <name>Calculator Server</name>
    <description>Basic calculator MCP service for beginners</description>

    <!-- Properties -->
    <properties>
        <java.version>21</java.version>
        <maven.compiler.source>21</maven.compiler.source>
        <maven.compiler.target>21</maven.compiler.target>
    </properties>

    <!-- Spring AI BOM for version management -->
    <dependencyManagement>
        <dependencies>
            <dependency>
                <groupId>org.springframework.ai</groupId>
                <artifactId>spring-ai-bom</artifactId>
                <version>1.0.0-SNAPSHOT</version>
                <type>pom</type>
                <scope>import</scope>
            </dependency>
        </dependencies>
    </dependencyManagement>

    <!-- Dependencies -->
    <dependencies>
        <dependency>
            <groupId>org.springframework.ai</groupId>
            <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
        </dependency>
        <dependency>
            <groupId>org.springframework.boot</groupId>
            <artifactId>spring-boot-starter-actuator</artifactId>
        </dependency>
        <dependency>
         <groupId>org.springframework.boot</groupId>
         <artifactId>spring-boot-starter-test</artifactId>
         <scope>test</scope>
      </dependency>
    </dependencies>

    <!-- Build configuration -->
    <build>
        <plugins>
            <plugin>
                <groupId>org.springframework.boot</groupId>
                <artifactId>spring-boot-maven-plugin</artifactId>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <configuration>
                    <release>21</release>
                </configuration>
            </plugin>
        </plugins>
    </build>

    <!-- Repositories for Spring AI snapshots -->
    <repositories>
        <repository>
            <id>spring-milestones</id>
            <name>Spring Milestones</name>
            <url>https://repo.spring.io/milestone</url>
            <snapshots>
                <enabled>false</enabled>
            </snapshots>
        </repository>
        <repository>
            <id>spring-snapshots</id>
            <name>Spring Snapshots</name>
            <url>https://repo.spring.io/snapshot</url>
            <releases>
                <enabled>false</enabled>
            </releases>
        </repository>
    </repositories>
</project>
```

### TypeScript

```sh
mkdir src
npm install -y
```

### Python

```sh
# Create a virtual env and install dependencies
python -m venv venv
venv\Scripts\activate
pip install "mcp[cli]"
```

### Java

```bash
cd calculator-server
./mvnw clean install -DskipTests
```

### TypeScript

Δημιουργήστε ένα αρχείο *package.json* με το παρακάτω περιεχόμενο:

```json
{
   "type": "module",
   "bin": {
     "weather": "./build/index.js"
   },
   "scripts": {
     "build": "tsc && node build/index.js"
   },
   "files": [
     "build"
   ]
}
```

Δημιουργήστε ένα αρχείο *tsconfig.json* με το παρακάτω περιεχόμενο:

```json
{
  "compilerOptions": {
    "target": "ES2022",
    "module": "Node16",
    "moduleResolution": "Node16",
    "outDir": "./build",
    "rootDir": "./src",
    "strict": true,
    "esModuleInterop": true,
    "skipLibCheck": true,
    "forceConsistentCasingInFileNames": true
  },
  "include": ["src/**/*"],
  "exclude": ["node_modules"]
}
```

### Python

Δημιουργήστε ένα αρχείο *server.py*

```sh
touch server.py
```

### .NET

Εγκαταστήστε τα απαιτούμενα πακέτα NuGet:

```sh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

### Java

Για έργα Java Spring Boot, η δομή του έργου δημιουργείται αυτόματα.

### TypeScript

Δημιουργήστε ένα αρχείο *index.ts* και προσθέστε τον παρακάτω κώδικα:

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
 
// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});
```

Τώρα έχετε έναν διακομιστή, αλλά δεν κάνει πολλά, ας το διορθώσουμε.

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")
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

// add features
```

### Java

Για Java, δημιουργήστε τα βασικά στοιχεία του διακομιστή. Πρώτα, τροποποιήστε την κύρια κλάση εφαρμογής:

*src/main/java/com/microsoft/mcp/sample/server/McpServerApplication.java*:

```java
package com.microsoft.mcp.sample.server;

import org.springframework.ai.tool.ToolCallbackProvider;
import org.springframework.ai.tool.method.MethodToolCallbackProvider;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import com.microsoft.mcp.sample.server.service.CalculatorService;

@SpringBootApplication
public class McpServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(McpServerApplication.class, args);
    }
    
    @Bean
    public ToolCallbackProvider calculatorTools(CalculatorService calculator) {
        return MethodToolCallbackProvider.builder().toolObjects(calculator).build();
    }
}
```

Δημιουργήστε την υπηρεσία calculator *src/main/java/com/microsoft/mcp/sample/server/service/CalculatorService.java*:

```java
package com.microsoft.mcp.sample.server.service;

import org.springframework.ai.tool.annotation.Tool;
import org.springframework.stereotype.Service;

/**
 * Service for basic calculator operations.
 * This service provides simple calculator functionality through MCP.
 */
@Service
public class CalculatorService {

    /**
     * Add two numbers
     * @param a The first number
     * @param b The second number
     * @return The sum of the two numbers
     */
    @Tool(description = "Add two numbers together")
    public String add(double a, double b) {
        double result = a + b;
        return formatResult(a, "+", b, result);
    }

    /**
     * Subtract one number from another
     * @param a The number to subtract from
     * @param b The number to subtract
     * @return The result of the subtraction
     */
    @Tool(description = "Subtract the second number from the first number")
    public String subtract(double a, double b) {
        double result = a - b;
        return formatResult(a, "-", b, result);
    }

    /**
     * Multiply two numbers
     * @param a The first number
     * @param b The second number
     * @return The product of the two numbers
     */
    @Tool(description = "Multiply two numbers together")
    public String multiply(double a, double b) {
        double result = a * b;
        return formatResult(a, "*", b, result);
    }

    /**
     * Divide one number by another
     * @param a The numerator
     * @param b The denominator
     * @return The result of the division
     */
    @Tool(description = "Divide the first number by the second number")
    public String divide(double a, double b) {
        if (b == 0) {
            return "Error: Cannot divide by zero";
        }
        double result = a / b;
        return formatResult(a, "/", b, result);
    }

    /**
     * Calculate the power of a number
     * @param base The base number
     * @param exponent The exponent
     * @return The result of raising the base to the exponent
     */
    @Tool(description = "Calculate the power of a number (base raised to an exponent)")
    public String power(double base, double exponent) {
        double result = Math.pow(base, exponent);
        return formatResult(base, "^", exponent, result);
    }

    /**
     * Calculate the square root of a number
     * @param number The number to find the square root of
     * @return The square root of the number
     */
    @Tool(description = "Calculate the square root of a number")
    public String squareRoot(double number) {
        if (number < 0) {
            return "Error: Cannot calculate square root of a negative number";
        }
        double result = Math.sqrt(number);
        return String.format("√%.2f = %.2f", number, result);
    }

    /**
     * Calculate the modulus (remainder) of division
     * @param a The dividend
     * @param b The divisor
     * @return The remainder of the division
     */
    @Tool(description = "Calculate the remainder when one number is divided by another")
    public String modulus(double a, double b) {
        if (b == 0) {
            return "Error: Cannot divide by zero";
        }
        double result = a % b;
        return formatResult(a, "%", b, result);
    }

    /**
     * Calculate the absolute value of a number
     * @param number The number to find the absolute value of
     * @return The absolute value of the number
     */
    @Tool(description = "Calculate the absolute value of a number")
    public String absolute(double number) {
        double result = Math.abs(number);
        return String.format("|%.2f| = %.2f", number, result);
    }

    /**
     * Get help about available calculator operations
     * @return Information about available operations
     */
    @Tool(description = "Get help about available calculator operations")
    public String help() {
        return "Basic Calculator MCP Service\n\n" +
               "Available operations:\n" +
               "1. add(a, b) - Adds two numbers\n" +
               "2. subtract(a, b) - Subtracts the second number from the first\n" +
               "3. multiply(a, b) - Multiplies two numbers\n" +
               "4. divide(a, b) - Divides the first number by the second\n" +
               "5. power(base, exponent) - Raises a number to a power\n" +
               "6. squareRoot(number) - Calculates the square root\n" + 
               "7. modulus(a, b) - Calculates the remainder of division\n" +
               "8. absolute(number) - Calculates the absolute value\n\n" +
               "Example usage: add(5, 3) will return 5 + 3 = 8";
    }

    /**
     * Format the result of a calculation
     */
    private String formatResult(double a, String operator, double b, double result) {
        return String.format("%.2f %s %.2f = %.2f", a, operator, b, result);
    }
}
```

**Προαιρετικά στοιχεία για μια υπηρεσία έτοιμη για παραγωγή:**

Δημιουργήστε μια ρύθμιση εκκίνησης *src/main/java/com/microsoft/mcp/sample/server/config/StartupConfig.java*:

```java
package com.microsoft.mcp.sample.server.config;

import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class StartupConfig {
    
    @Bean
    public CommandLineRunner startupInfo() {
        return args -> {
            System.out.println("\n" + "=".repeat(60));
            System.out.println("Calculator MCP Server is starting...");
            System.out.println("SSE endpoint: http://localhost:8080/sse");
            System.out.println("Health check: http://localhost:8080/actuator/health");
            System.out.println("=".repeat(60) + "\n");
        };
    }
}
```

Δημιουργήστε έναν ελεγκτή υγείας *src/main/java/com/microsoft/mcp/sample/server/controller/HealthController.java*:

```java
package com.microsoft.mcp.sample.server.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.Map;

@RestController
public class HealthController {
    
    @GetMapping("/health")
    public ResponseEntity<Map<String, Object>> healthCheck() {
        Map<String, Object> response = new HashMap<>();
        response.put("status", "UP");
        response.put("timestamp", LocalDateTime.now().toString());
        response.put("service", "Calculator MCP Server");
        return ResponseEntity.ok(response);
    }
}
```

Δημιουργήστε έναν χειριστή εξαιρέσεων *src/main/java/com/microsoft/mcp/sample/server/exception/GlobalExceptionHandler.java*:

```java
package com.microsoft.mcp.sample.server.exception;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestControllerAdvice;

@RestControllerAdvice
public class GlobalExceptionHandler {

    @ExceptionHandler(IllegalArgumentException.class)
    public ResponseEntity<ErrorResponse> handleIllegalArgumentException(IllegalArgumentException ex) {
        ErrorResponse error = new ErrorResponse(
            "Invalid_Input", 
            "Invalid input parameter: " + ex.getMessage());
        return new ResponseEntity<>(error, HttpStatus.BAD_REQUEST);
    }

    public static class ErrorResponse {
        private String code;
        private String message;

        public ErrorResponse(String code, String message) {
            this.code = code;
            this.message = message;
        }

        // Getters
        public String getCode() { return code; }
        public String getMessage() { return message; }
    }
}
```

Δημιουργήστε ένα προσαρμοσμένο banner *src/main/resources/banner.txt*:

```text
_____      _            _       _             
 / ____|    | |          | |     | |            
| |     __ _| | ___ _   _| | __ _| |_ ___  _ __ 
| |    / _` | |/ __| | | | |/ _` | __/ _ \| '__|
| |___| (_| | | (__| |_| | | (_| | || (_) | |   
 \_____\__,_|_|\___|\__,_|_|\__,_|\__\___/|_|   
                                                
Calculator MCP Server v1.0
Spring Boot MCP Application
```

</details>

### -5- Προσθήκη εργαλείου και πόρου

Προσθέστε ένα εργαλείο και έναν πόρο προσθέτοντας τον παρακάτω κώδικα:

### TypeScript

```typescript
  server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

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
```

Το εργαλείο σας παίρνει παραμέτρους `a` και `b` και εκτελεί μια συνάρτηση που παράγει μια απάντηση στη μορφή:

```typescript
{
  contents: [{
    type: "text", content: "some content"
  }]
}
```

Ο πόρος σας προσπελαύνεται μέσω της συμβολοσειράς "greeting", παίρνει μια παράμετρο `name` και παράγει μια παρόμοια απάντηση με το εργαλείο:

```typescript
{
  uri: "<href>",
  text: "a text"
}
```

### Python

```python
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

Στον παραπάνω κώδικα έχουμε:

- Ορίσει ένα εργαλείο `add` που παίρνει παραμέτρους `a` και `p`, και οι δύο ακέραιοι.
- Δημιουργήσει έναν πόρο με όνομα `greeting` που παίρνει την παράμετρο `name`.

### .NET

Προσθέστε αυτό στο αρχείο Program.cs:

```csharp
[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

### Java

Τα εργαλεία έχουν ήδη δημιουργηθεί στο προηγούμενο βήμα.

### -6 Τελικός κώδικας

Ας προσθέσουμε τον τελευταίο κώδικα που χρειαζόμαστε ώστε ο διακομιστής να μπορεί να ξεκινήσει:

### TypeScript

```typescript
// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

Ορίστε ο πλήρης κώδικας:

```typescript
// index.ts
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
const transport = new StdioServerTransport();
await server.connect(transport);
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

# Main execution block - this is required to run the server
if __name__ == "__main__":
    mcp.run()
```

### .NET

Δημιουργήστε ένα αρχείο Program.cs με το παρακάτω περιεχόμενο:

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

### Java

Η πλήρης κύρια κλάση εφαρμογής σας θα πρέπει να μοιάζει με αυτήν:

```java
// McpServerApplication.java
package com.microsoft.mcp.sample.server;

import org.springframework.ai.tool.ToolCallbackProvider;
import org.springframework.ai.tool.method.MethodToolCallbackProvider;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import com.microsoft.mcp.sample.server.service.CalculatorService;

@SpringBootApplication
public class McpServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(McpServerApplication.class, args);
    }
    
    @Bean
    public ToolCallbackProvider calculatorTools(CalculatorService calculator) {
        return MethodToolCallbackProvider.builder().toolObjects(calculator).build();
    }
}
```

### -7- Δοκιμή του διακομιστή

Ξεκινήστε τον διακομιστή με την παρακάτω εντολή:

### TypeScript

```sh
npm run build
```

### Python

```sh
mcp run server.py
```

> Για να χρησιμοποιήσετε τον MCP Inspector, χρησιμοποιήστε `mcp dev server.py` που αυτόματα ξεκινά τον Inspector και παρέχει το απαιτούμενο token συνεδρίας proxy. Αν χρησιμοποιείτε `mcp run server.py`, θα χρειαστεί να ξεκινήσετε χειροκίνητα τον Inspector και να ρυθμίσετε τη σύνδεση.

### .NET

Βεβαιωθείτε ότι βρίσκεστε στον φάκελο του έργου σας:

```sh
cd McpCalculatorServer
dotnet run
```

### Java

```bash
./mvnw clean install -DskipTests
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### -8- Εκτέλεση με τον inspector

Ο inspector είναι ένα εξαιρετικό εργαλείο που μπορεί να ξεκινήσει τον διακομιστή σας και σας επιτρέπει να αλληλεπιδράσετε μαζί του ώστε να δοκιμάσετε ότι λειτουργεί. Ας τον ξεκινήσουμε:

> [!NOTE]
> μπορεί να φαίνεται διαφορετικό στο πεδίο "command" καθώς περιέχει την εντολή για την εκτέλεση διακομιστή με το συγκεκριμένο runtime σας.

### TypeScript

```sh
npx @modelcontextprotocol/inspector node build/index.js
```

ή προσθέστε το στο *package.json* σας ως εξής: `"inspector": "npx @modelcontextprotocol/inspector node build/index.js"` και μετά τρέξτε `npm run inspect`

Η Python τυλίγει ένα εργαλείο Node.js που ονομάζεται inspector. Είναι δυνατό να καλέ
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Συντηρείται σε συνεργασία με την Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Η επίσημη υλοποίηση σε Rust

## Βασικά Συμπεράσματα

- Η ρύθμιση ενός περιβάλλοντος ανάπτυξης MCP είναι απλή με τα SDKs για κάθε γλώσσα  
- Η δημιουργία MCP servers περιλαμβάνει τη δημιουργία και καταχώρηση εργαλείων με σαφή σχήματα  
- Οι δοκιμές και ο εντοπισμός σφαλμάτων είναι απαραίτητα για αξιόπιστες υλοποιήσεις MCP

## Παραδείγματα

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ανάθεση

Δημιουργήστε έναν απλό MCP server με ένα εργαλείο της επιλογής σας:

1. Υλοποιήστε το εργαλείο στη γλώσσα που προτιμάτε (.NET, Java, Python ή JavaScript).  
2. Ορίστε τις παραμέτρους εισόδου και τις τιμές επιστροφής.  
3. Εκτελέστε το εργαλείο inspector για να βεβαιωθείτε ότι ο server λειτουργεί όπως αναμένεται.  
4. Δοκιμάστε την υλοποίηση με διάφορες εισόδους.

## Λύση

[Solution](./solution/README.md)

## Επιπλέον Πόροι

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Τι ακολουθεί

Επόμενο: [Getting Started with MCP Clients](../02-client/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.