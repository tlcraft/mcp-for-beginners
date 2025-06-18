<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:42:59+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "fr"
}
-->
# Démonstration du streaming HTTP du calculateur

Ce projet illustre le streaming HTTP avec Server-Sent Events (SSE) en utilisant Spring Boot WebFlux. Il se compose de deux applications :

- **Calculator Server** : un service web réactif qui effectue des calculs et diffuse les résultats via SSE
- **Calculator Client** : une application cliente qui consomme le point de terminaison de streaming

## Prérequis

- Java 17 ou supérieur
- Maven 3.6 ou supérieur

## Structure du projet

```
java/
├── calculator-server/     # Spring Boot server with SSE endpoint
│   ├── src/main/java/com/example/calculatorserver/
│   │   ├── CalculatorServerApplication.java
│   │   └── CalculatorController.java
│   └── pom.xml
├── calculator-client/     # Spring Boot client application
│   ├── src/main/java/com/example/calculatorclient/
│   │   └── CalculatorClientApplication.java
│   └── pom.xml
└── README.md
```

## Comment ça fonctionne

1. Le **Calculator Server** expose un endpoint `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Consomme la réponse en streaming
   - Affiche chaque événement dans la console

## Lancement des applications

### Option 1 : Avec Maven (recommandé)

#### 1. Démarrer le Calculator Server

Ouvrez un terminal et rendez-vous dans le répertoire du serveur :

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Le serveur démarrera sur `http://localhost:8080`

Vous devriez voir une sortie similaire à :
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Lancer le Calculator Client

Ouvrez un **nouveau terminal** et rendez-vous dans le répertoire du client :

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Le client se connectera au serveur, effectuera le calcul et affichera les résultats en streaming.

### Option 2 : Utiliser Java directement

#### 1. Compiler et lancer le serveur :

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Compiler et lancer le client :

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Tester le serveur manuellement

Vous pouvez aussi tester le serveur via un navigateur web ou curl :

### Avec un navigateur web :
Visitez : `http://localhost:8080/calculate?a=10&b=5&op=add`

### Avec curl :
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Résultat attendu

Lors de l’exécution du client, vous devriez voir une sortie en streaming similaire à :

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Opérations supportées

- `add` - Addition (a + b)
- `sub` - Subtraction (a - b)
- `mul` - Multiplication (a * b)
- `div` - Division (a / b, returns NaN if b = 0)

## API Reference

### GET /calculate

**Parameters:**
- `a` (required): First number (double)
- `b` (required): Second number (double)
- `op` (required): Operation (`add`, `sub`, `mul`, `div`)

**Response:**
- Content-Type: `text/event-stream`
- Retourne des Server-Sent Events avec la progression et le résultat du calcul

**Exemple de requête :**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Exemple de réponse :**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Dépannage

### Problèmes courants

1. **Le port 8080 est déjà utilisé**
   - Arrêtez toute autre application utilisant le port 8080
   - Ou changez le port du serveur dans `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` si le serveur tourne en tâche de fond

## Technologies utilisées

- **Spring Boot 3.3.1** - Framework d’application
- **Spring WebFlux** - Framework web réactif
- **Project Reactor** - Bibliothèque de flux réactifs
- **Netty** - Serveur I/O non bloquant
- **Maven** - Outil de build
- **Java 17+** - Langage de programmation

## Étapes suivantes

Essayez de modifier le code pour :
- Ajouter plus d’opérations mathématiques
- Gérer les erreurs pour les opérations invalides
- Ajouter des logs de requêtes/réponses
- Implémenter l’authentification
- Ajouter des tests unitaires

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, il est recommandé de recourir à une traduction professionnelle réalisée par un humain. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.