<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:18:31+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "fr"
}
-->
# Client Calculatrice LLM

Une application Java qui montre comment utiliser LangChain4j pour se connecter à un service calculatrice MCP (Model Context Protocol) avec intégration des GitHub Models.

## Prérequis

- Java 21 ou supérieur  
- Maven 3.6+ (ou utilisez le wrapper Maven inclus)  
- Un compte GitHub avec accès aux GitHub Models  
- Un service calculatrice MCP en fonctionnement sur `http://localhost:8080`  

## Obtenir le Token GitHub

Cette application utilise les GitHub Models, ce qui nécessite un token d’accès personnel GitHub. Suivez ces étapes pour obtenir votre token :

### 1. Accéder aux GitHub Models  
1. Rendez-vous sur [GitHub Models](https://github.com/marketplace/models)  
2. Connectez-vous avec votre compte GitHub  
3. Demandez l’accès aux GitHub Models si ce n’est pas déjà fait  

### 2. Créer un Token d’Accès Personnel  
1. Allez dans [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)  
2. Cliquez sur "Generate new token" → "Generate new token (classic)"  
3. Donnez un nom descriptif à votre token (par exemple, "MCP Calculator Client")  
4. Définissez la durée de validité selon vos besoins  
5. Sélectionnez les scopes suivants :  
   - `repo` (si vous accédez à des dépôts privés)  
   - `user:email`  
6. Cliquez sur "Generate token"  
7. **Important** : Copiez le token immédiatement - vous ne pourrez plus le voir par la suite !  

### 3. Configurer la Variable d’Environnement

#### Sous Windows (Invite de commandes) :  
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Sous Windows (PowerShell) :  
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### Sous macOS/Linux :  
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Installation et Configuration

1. **Clonez ou rendez-vous dans le répertoire du projet**

2. **Installez les dépendances** :  
   ```cmd
   mvnw clean install
   ```  
   Ou si Maven est installé globalement :  
   ```cmd
   mvn clean install
   ```

3. **Configurez la variable d’environnement** (voir la section "Obtenir le Token GitHub" ci-dessus)

4. **Démarrez le service calculatrice MCP** :  
   Assurez-vous que le service calculatrice MCP du chapitre 1 tourne sur `http://localhost:8080/sse`. Ce service doit être actif avant de lancer le client.

## Lancer l’Application

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Fonctionnalités de l’Application

L’application illustre trois interactions principales avec le service calculatrice :

1. **Addition** : Calcule la somme de 24,5 et 17,3  
2. **Racine carrée** : Calcule la racine carrée de 144  
3. **Aide** : Affiche les fonctions disponibles de la calculatrice  

## Résultat Attendu

En cas de succès, vous devriez voir une sortie similaire à :

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Dépannage

### Problèmes Courants

1. **"GITHUB_TOKEN environment variable not set"**  
   - Vérifiez que vous avez bien configuré la variable `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean`

### Debug

Pour activer les logs de debug, ajoutez l’argument JVM suivant lors de l’exécution :  
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Configuration

L’application est configurée pour :  
- Utiliser les GitHub Models avec `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`  
- Utiliser un timeout de 60 secondes pour les requêtes  
- Activer la journalisation des requêtes/réponses pour faciliter le débogage  

## Dépendances

Principales dépendances utilisées dans ce projet :  
- **LangChain4j** : Pour l’intégration IA et la gestion des outils  
- **LangChain4j MCP** : Pour le support du Model Context Protocol  
- **LangChain4j GitHub Models** : Pour l’intégration des GitHub Models  
- **Spring Boot** : Pour le framework applicatif et l’injection de dépendances  

## Licence

Ce projet est sous licence Apache 2.0 - voir le fichier [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) pour plus de détails.

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour des informations critiques, une traduction professionnelle humaine est recommandée. Nous ne saurions être tenus responsables de tout malentendu ou mauvaise interprétation résultant de l’utilisation de cette traduction.