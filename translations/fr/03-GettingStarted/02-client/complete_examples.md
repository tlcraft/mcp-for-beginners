<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:29:05+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "fr"
}
-->
# Exemples complets de clients MCP

Ce répertoire contient des exemples complets et fonctionnels de clients MCP dans différents langages de programmation. Chaque client illustre l’ensemble des fonctionnalités décrites dans le tutoriel principal README.md.

## Clients disponibles

### 1. Client Java (`client_example_java.java`)
- **Transport** : SSE (Server-Sent Events) via HTTP
- **Serveur cible** : `http://localhost:8080`
- **Fonctionnalités** : 
  - Établissement de la connexion et ping
  - Liste des outils
  - Opérations de calculatrice (addition, soustraction, multiplication, division, aide)
  - Gestion des erreurs et extraction des résultats

**Pour exécuter :**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. Client C# (`client_example_csharp.cs`)
- **Transport** : Stdio (entrée/sortie standard)
- **Serveur cible** : serveur MCP .NET local via dotnet run
- **Fonctionnalités** :
  - Démarrage automatique du serveur via le transport stdio
  - Liste des outils et ressources
  - Opérations de calculatrice
  - Analyse des résultats JSON
  - Gestion complète des erreurs

**Pour exécuter :**
```bash
dotnet run
```

### 3. Client TypeScript (`client_example_typescript.ts`)
- **Transport** : Stdio (entrée/sortie standard)
- **Serveur cible** : serveur MCP Node.js local
- **Fonctionnalités** :
  - Support complet du protocole MCP
  - Opérations sur outils, ressources et prompts
  - Opérations de calculatrice
  - Lecture de ressources et exécution de prompts
  - Gestion robuste des erreurs

**Pour exécuter :**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Client Python (`client_example_python.py`)
- **Transport** : Stdio (entrée/sortie standard)  
- **Serveur cible** : serveur MCP Python local
- **Fonctionnalités** :
  - Modèle async/await pour les opérations
  - Découverte d’outils et de ressources
  - Tests des opérations de calculatrice
  - Lecture du contenu des ressources
  - Organisation orientée classes

**Pour exécuter :**
```bash
python client_example_python.py
```

## Fonctionnalités communes à tous les clients

Chaque implémentation client illustre :

1. **Gestion de la connexion**
   - Établissement de la connexion au serveur MCP
   - Gestion des erreurs de connexion
   - Nettoyage et gestion des ressources appropriés

2. **Découverte du serveur**
   - Liste des outils disponibles
   - Liste des ressources disponibles (lorsque supporté)
   - Liste des prompts disponibles (lorsque supporté)

3. **Invocation d’outils**
   - Opérations basiques de calculatrice (addition, soustraction, multiplication, division)
   - Commande d’aide pour les informations serveur
   - Passage correct des arguments et gestion des résultats

4. **Gestion des erreurs**
   - Erreurs de connexion
   - Erreurs d’exécution des outils
   - Échec gracieux et retour utilisateur

5. **Traitement des résultats**
   - Extraction du contenu texte des réponses
   - Formatage de la sortie pour une meilleure lisibilité
   - Gestion des différents formats de réponse

## Prérequis

Avant d’exécuter ces clients, assurez-vous de :

1. **Disposer du serveur MCP correspondant en fonctionnement** (depuis `../01-first-server/`)
2. **Avoir installé les dépendances requises** pour le langage choisi
3. **Avoir une connectivité réseau adéquate** (pour les transports basés sur HTTP)

## Principales différences entre les implémentations

| Langage   | Transport | Démarrage serveur | Modèle Async | Bibliothèques clés |
|-----------|-----------|-------------------|--------------|--------------------|
| Java      | SSE/HTTP  | Externe           | Synchrone    | WebFlux, MCP SDK   |
| C#        | Stdio     | Automatique       | Async/Await  | .NET MCP SDK       |
| TypeScript| Stdio     | Automatique       | Async/Await  | Node MCP SDK       |
| Python    | Stdio     | Automatique       | AsyncIO      | Python MCP SDK     |

## Étapes suivantes

Après avoir exploré ces exemples clients :

1. **Modifiez les clients** pour ajouter de nouvelles fonctionnalités ou opérations
2. **Créez votre propre serveur** et testez-le avec ces clients
3. **Expérimentez avec différents transports** (SSE vs. Stdio)
4. **Développez une application plus complexe** intégrant la fonctionnalité MCP

## Dépannage

### Problèmes courants

1. **Connexion refusée** : Vérifiez que le serveur MCP est bien lancé sur le port/chemin attendu
2. **Module introuvable** : Installez le SDK MCP requis pour votre langage
3. **Permission refusée** : Vérifiez les permissions des fichiers pour le transport stdio
4. **Outil introuvable** : Assurez-vous que le serveur implémente bien les outils attendus

### Conseils de débogage

1. **Activez la journalisation détaillée** dans votre SDK MCP
2. **Consultez les logs du serveur** pour les messages d’erreur
3. **Vérifiez que les noms et signatures des outils** correspondent entre client et serveur
4. **Testez d’abord avec MCP Inspector** pour valider la fonctionnalité serveur

## Documentation associée

- [Tutoriel principal client](./README.md)
- [Exemples de serveurs MCP](../../../../03-GettingStarted/01-first-server)
- [MCP avec intégration LLM](../../../../03-GettingStarted/03-llm-client)
- [Documentation officielle MCP](https://modelcontextprotocol.io/)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.