<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ba767f2f54d704d19bb886389228d285",
  "translation_date": "2025-07-04T15:20:05+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "fr"
}
-->
# Premiers pas avec MCP

Bienvenue dans vos premiers pas avec le Model Context Protocol (MCP) ! Que vous découvriez MCP ou que vous souhaitiez approfondir vos connaissances, ce guide vous accompagnera à travers les étapes essentielles de configuration et de développement. Vous découvrirez comment MCP permet une intégration fluide entre les modèles d’IA et les applications, et apprendrez à préparer rapidement votre environnement pour créer et tester des solutions basées sur MCP.

> TLDR ; Si vous développez des applications d’IA, vous savez que vous pouvez ajouter des outils et d’autres ressources à votre LLM (large language model) pour enrichir ses connaissances. Cependant, si vous placez ces outils et ressources sur un serveur, les capacités de l’application et du serveur peuvent être utilisées par n’importe quel client, avec ou sans LLM.

## Vue d’ensemble

Cette leçon fournit des conseils pratiques pour configurer des environnements MCP et créer vos premières applications MCP. Vous apprendrez à installer les outils et frameworks nécessaires, construire des serveurs MCP basiques, créer des applications hôtes et tester vos implémentations.

Le Model Context Protocol (MCP) est un protocole ouvert qui standardise la manière dont les applications fournissent du contexte aux LLM. Pensez à MCP comme un port USB-C pour les applications d’IA : il offre un moyen standardisé de connecter les modèles d’IA à différentes sources de données et outils.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Configurer des environnements de développement MCP en C#, Java, Python, TypeScript et JavaScript
- Construire et déployer des serveurs MCP basiques avec des fonctionnalités personnalisées (ressources, prompts et outils)
- Créer des applications hôtes qui se connectent aux serveurs MCP
- Tester et déboguer des implémentations MCP

## Configuration de votre environnement MCP

Avant de commencer à travailler avec MCP, il est important de préparer votre environnement de développement et de comprendre le flux de travail de base. Cette section vous guidera à travers les étapes initiales pour garantir un démarrage sans accroc avec MCP.

### Prérequis

Avant de vous lancer dans le développement MCP, assurez-vous d’avoir :

- **Environnement de développement** : pour le langage choisi (C#, Java, Python, TypeScript ou JavaScript)
- **IDE/Éditeur** : Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ou tout éditeur de code moderne
- **Gestionnaires de paquets** : NuGet, Maven/Gradle, pip ou npm/yarn
- **Clés API** : pour tous les services d’IA que vous prévoyez d’utiliser dans vos applications hôtes

## Structure basique d’un serveur MCP

Un serveur MCP comprend généralement :

- **Configuration du serveur** : configuration du port, authentification et autres paramètres
- **Ressources** : données et contexte mis à disposition des LLM
- **Outils** : fonctionnalités que les modèles peuvent invoquer
- **Prompts** : modèles pour générer ou structurer du texte

Voici un exemple simplifié en TypeScript :

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

Dans le code précédent, nous avons :

- Importé les classes nécessaires du SDK MCP TypeScript.
- Créé et configuré une nouvelle instance de serveur MCP.
- Enregistré un outil personnalisé (`calculator`) avec une fonction gestionnaire.
- Démarré le serveur pour écouter les requêtes MCP entrantes.

## Tests et débogage

Avant de commencer à tester votre serveur MCP, il est important de comprendre les outils disponibles et les bonnes pratiques pour le débogage. Des tests efficaces garantissent que votre serveur se comporte comme prévu et vous aident à identifier et résoudre rapidement les problèmes. La section suivante décrit les approches recommandées pour valider votre implémentation MCP.

MCP fournit des outils pour vous aider à tester et déboguer vos serveurs :

- **Outil Inspector** : cette interface graphique vous permet de vous connecter à votre serveur et de tester vos outils, prompts et ressources.
- **curl** : vous pouvez aussi vous connecter à votre serveur via un outil en ligne de commande comme curl ou d’autres clients capables de créer et exécuter des commandes HTTP.

### Utilisation de MCP Inspector

Le [MCP Inspector](https://github.com/modelcontextprotocol/inspector) est un outil de test visuel qui vous aide à :

1. **Découvrir les capacités du serveur** : détecter automatiquement les ressources, outils et prompts disponibles
2. **Tester l’exécution des outils** : essayer différents paramètres et voir les réponses en temps réel
3. **Consulter les métadonnées du serveur** : examiner les informations, schémas et configurations du serveur

```bash
# ex TypeScript, installing and running MCP Inspector
npx @modelcontextprotocol/inspector node build/index.js
```

Lorsque vous exécutez les commandes ci-dessus, MCP Inspector lance une interface web locale dans votre navigateur. Vous verrez un tableau de bord affichant vos serveurs MCP enregistrés, leurs outils, ressources et prompts disponibles. L’interface vous permet de tester de manière interactive l’exécution des outils, d’inspecter les métadonnées du serveur et de visualiser les réponses en temps réel, facilitant ainsi la validation et le débogage de vos implémentations MCP.

Voici une capture d’écran de ce à quoi cela peut ressembler :

![](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.fr.png)

## Problèmes courants de configuration et solutions

| Problème | Solution possible |
|----------|-------------------|
| Connexion refusée | Vérifiez que le serveur est en cours d’exécution et que le port est correct |
| Erreurs d’exécution d’outil | Vérifiez la validation des paramètres et la gestion des erreurs |
| Échecs d’authentification | Vérifiez les clés API et les permissions |
| Erreurs de validation de schéma | Assurez-vous que les paramètres correspondent au schéma défini |
| Serveur ne démarre pas | Vérifiez les conflits de port ou les dépendances manquantes |
| Erreurs CORS | Configurez correctement les en-têtes CORS pour les requêtes cross-origin |
| Problèmes d’authentification | Vérifiez la validité des tokens et les permissions |

## Développement local

Pour le développement et les tests locaux, vous pouvez exécuter les serveurs MCP directement sur votre machine :

1. **Démarrez le processus serveur** : lancez votre application serveur MCP
2. **Configurez le réseau** : assurez-vous que le serveur est accessible sur le port attendu
3. **Connectez les clients** : utilisez des URL de connexion locales comme `http://localhost:3000`

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

## Construire votre premier serveur MCP

Nous avons abordé les [concepts de base](/01-CoreConcepts/README.md) dans une leçon précédente, il est maintenant temps de mettre ces connaissances en pratique.

### Ce qu’un serveur peut faire

Avant de commencer à coder, rappelons ce qu’un serveur peut faire :

Un serveur MCP peut par exemple :

- Accéder à des fichiers locaux et bases de données
- Se connecter à des API distantes
- Effectuer des calculs
- S’intégrer à d’autres outils et services
- Fournir une interface utilisateur pour l’interaction

Parfait, maintenant que nous savons ce que nous pouvons faire, commençons à coder.

## Exercice : Créer un serveur

Pour créer un serveur, vous devez suivre ces étapes :

- Installer le SDK MCP.
- Créer un projet et configurer sa structure.
- Écrire le code serveur.
- Tester le serveur.

### -1- Installer le SDK

Cela varie un peu selon le runtime choisi, sélectionnez donc l’un des runtimes ci-dessous :

L’IA générative peut produire du texte, des images, et même du code.

<details>
  <summary>TypeScript</summary>

  ```sh
  npm install @modelcontextprotocol/sdk zod
  npm install -D @types/node typescript
  ```

</details>

<details>
<summary>Python</summary>

```sh
# For server development
pip install "mcp[cli]"
```

</details>

<details>
<summary>.NET</summary>

```sh
dotnet new console -n McpCalculatorServer
cd McpCalculatorServer
```

</details>

<details>
<summary>Java</summary>

Pour Java, créez un projet Spring Boot :

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

Décompressez le fichier zip :

```bash
unzip calculator-server.zip -d calculator-server
cd calculator-server
# optional remove the unused test
rm -rf src/test/java
```

Ajoutez la configuration complète suivante à votre fichier *pom.xml* :

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

</details>

### -2- Créer un projet

Maintenant que vous avez installé le SDK, créons un projet :

<details>
  <summary>TypeScript</summary>

  ```sh
  mkdir src
  npm install -y
  ```

</details>

<details>
  <summary>Python</summary>

  ```sh
  python -m venv venv
  venv\Scripts\activate
  ```

</details>

<details>
<summary>Java</summary>

```bash
cd calculator-server
./mvnw clean install -DskipTests
```

</details>

### -3- Créer les fichiers du projet

<details>
  <summary>TypeScript</summary>
  
  Créez un *package.json* avec le contenu suivant :
  
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

  Créez un *tsconfig.json* avec le contenu suivant :

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

</details>

<details>
<summary>Python</summary>

Créez un fichier *server.py*
</details>

<details>
<summary>.NET</summary>

Installez les paquets NuGet requis :

```sh
dotnet add package ModelContextProtocol --prerelease
dotnet add package Microsoft.Extensions.Hosting
```

</details>

<details>
<summary>Java</summary>

Pour les projets Java Spring Boot, la structure du projet est créée automatiquement.

</details>

### -4- Écrire le code serveur

<details>
  <summary>TypeScript</summary>
  
  Créez un fichier *index.ts* et ajoutez le code suivant :

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

 Vous avez maintenant un serveur, mais il ne fait pas grand-chose, corrigeons cela.
</details>

<details>
<summary>Python</summary>

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")
```

</details>

<details>
<summary>.NET</summary>

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

</details>

<details>
<summary>Java</summary>

Pour Java, créez les composants principaux du serveur. Commencez par modifier la classe principale de l’application :

*src/main/java/com/microsoft/mcp/sample/server/McpServerApplication.java* :

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

Créez le service calculator *src/main/java/com/microsoft/mcp/sample/server/service/CalculatorService.java* :

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

**Composants optionnels pour un service prêt pour la production :**

Créez une configuration de démarrage *src/main/java/com/microsoft/mcp/sample/server/config/StartupConfig.java* :

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

Créez un contrôleur de santé *src/main/java/com/microsoft/mcp/sample/server/controller/HealthController.java* :

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

Créez un gestionnaire d’exceptions *src/main/java/com/microsoft/mcp/sample/server/exception/GlobalExceptionHandler.java* :

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

Créez une bannière personnalisée *src/main/resources/banner.txt* :

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

### -5- Ajouter un outil et une ressource

Ajoutez un outil et une ressource en ajoutant le code suivant :

<details>
  <summary>TypeScript</summary>

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

  Votre outil prend les paramètres `a` et `b` et exécute une fonction qui produit une réponse sous la forme :

  ```typescript
  {
    contents: [{
      type: "text", content: "some content"
    }]
  }
  ```

  Votre ressource est accessible via la chaîne "greeting", prend un paramètre `name` et produit une réponse similaire à l’outil :

  ```typescript
  {
    uri: "<href>",
    text: "a text"
  }
  ```

</details>

<details>
<summary>Python</summary>

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

Dans le code précédent, nous avons :

- Défini un outil `add` qui prend les paramètres `a` et `p`, tous deux des entiers.
- Créé une ressource appelée `greeting` qui prend le paramètre `name`.

</details>

<details>
<summary>.NET</summary>

Ajoutez ceci à votre fichier Program.cs :

```csharp
[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

</details>

<details>
<summary>Java</summary>

Les outils ont déjà été créés à l’étape précédente.

</details>

### -6 Code final

Ajoutons le dernier code nécessaire pour que le serveur puisse démarrer :

<details>
<summary>TypeScript</summary>

```typescript
// Start receiving messages on stdin and sending messages on stdout
const transport = new StdioServerTransport();
await server.connect(transport);
```

Voici le code complet :

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

</details>

<details>
<summary>Python</summary>

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

</details>

<details>
<summary>.NET</summary>

Créez un fichier Program.cs avec le contenu suivant :

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

</details>

<details>
<summary>Java</summary>

Votre classe principale complète devrait ressembler à ceci :

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

</details>

### -7- Tester le serveur

Démarrez le serveur avec la commande suivante :

<details>
<summary>TypeScript</summary>

```sh
npm run build
```

</details>

<details>
<summary>Python</summary>

```sh
mcp run server.py
```

</details>

<details>
<summary>.NET</summary>

Assurez-vous d’être dans le répertoire de votre projet :

```sh
cd McpCalculatorServer
dotnet run
```

</details>

<details>
<summary>Java</summary>

```bash
./mvnw clean install -DskipTests
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

</details>

### -8- Lancer avec l’inspector

L’inspector est un excellent outil qui peut démarrer votre serveur et vous permettre d’interagir avec lui pour tester son bon fonctionnement. Démarrons-le :

> [!NOTE]
> le champ "command" peut apparaître différemment car il contient la commande pour exécuter un serveur avec votre runtime spécifique.

<details>
<summary>TypeScript</summary>

```sh
npx @modelcontextprotocol/inspector node build/index.js
```

ou ajoutez-le à votre *package.json* ainsi : `"inspector": "npx @modelcontextprotocol/inspector node build/index.js"` puis lancez `npm run inspect`

Vous devriez voir l'interface utilisateur suivante :

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.fr.png)

1. Connectez-vous au serveur en sélectionnant le bouton Connect
  Une fois connecté au serveur, vous devriez voir ceci :

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.fr.png)

1. Sélectionnez "Tools" puis "listTools", vous devriez voir apparaître "Add", sélectionnez "Add" et remplissez les valeurs des paramètres.

  Vous devriez voir la réponse suivante, c’est-à-dire un résultat de l’outil "add" :

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.fr.png)

Félicitations, vous avez réussi à créer et exécuter votre premier serveur !

### SDK officiels

MCP propose des SDK officiels pour plusieurs langages :

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Maintenu en collaboration avec Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Maintenu en collaboration avec Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - L’implémentation officielle en TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - L’implémentation officielle en Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - L’implémentation officielle en Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Maintenu en collaboration avec Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - L’implémentation officielle en Rust

## Points clés à retenir

- La mise en place d’un environnement de développement MCP est simple grâce aux SDK spécifiques à chaque langage
- Construire des serveurs MCP consiste à créer et enregistrer des outils avec des schémas clairs
- Les tests et le débogage sont essentiels pour des implémentations MCP fiables

## Exemples

- [Calculatrice Java](../samples/java/calculator/README.md)
- [Calculatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculatrice JavaScript](../samples/javascript/README.md)
- [Calculatrice TypeScript](../samples/typescript/README.md)
- [Calculatrice Python](../../../../03-GettingStarted/samples/python)

## Exercice

Créez un serveur MCP simple avec un outil de votre choix :

1. Implémentez l’outil dans le langage de votre choix (.NET, Java, Python ou JavaScript).
2. Définissez les paramètres d’entrée et les valeurs de retour.
3. Lancez l’outil inspector pour vérifier que le serveur fonctionne comme prévu.
4. Testez l’implémentation avec différentes entrées.

## Solution

[Solution](./solution/README.md)

## Ressources supplémentaires

- [Créer des agents avec Model Context Protocol sur Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP distant avec Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [Agent MCP OpenAI .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Et ensuite

Suivant : [Premiers pas avec les clients MCP](../02-client/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.