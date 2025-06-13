<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:00:19+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "mo"
}
-->
# Running this sample

Voici comment exécuter le serveur et le client de streaming HTTP classique, ainsi que le serveur et le client de streaming MCP en Python.

### Overview

- Vous configurerez un serveur MCP qui diffuse des notifications de progression au client pendant le traitement des éléments.
- Le client affichera chaque notification en temps réel.
- Ce guide couvre les prérequis, l'installation, l'exécution et le dépannage.

### Prerequisites

- Python 3.9 ou une version plus récente
- Le package Python `mcp` (installation via `pip install mcp`)

### Installation & Setup

1. Clonez le dépôt ou téléchargez les fichiers de la solution.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Créez et activez un environnement virtuel (recommandé) :**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Installez les dépendances requises :**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Files

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Client:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Running the Classic HTTP Streaming Server

1. Rendez-vous dans le répertoire de la solution :

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Lancez le serveur de streaming HTTP classique :

   ```pwsh
   python server.py
   ```

3. Le serveur démarrera et affichera :

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Running the Classic HTTP Streaming Client

1. Ouvrez un nouveau terminal (activez le même environnement virtuel et répertoire) :

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Vous verrez les messages diffusés s'afficher séquentiellement :

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### Running the MCP Streaming Server

1. Rendez-vous dans le répertoire de la solution :
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Lancez le serveur MCP avec le transport streamable-http :
   ```pwsh
   python server.py mcp
   ```
3. Le serveur démarrera et affichera :
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Running the MCP Streaming Client

1. Ouvrez un nouveau terminal (activez le même environnement virtuel et répertoire) :
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Vous verrez les notifications s'afficher en temps réel au fur et à mesure que le serveur traite chaque élément :
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### Key Implementation Steps

1. **Créez le serveur MCP avec FastMCP.**
2. **Définissez un outil qui traite une liste et envoie des notifications via `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` pour des opérations non bloquantes.**
- Gérez toujours les exceptions côté serveur et client pour assurer la robustesse.
- Testez avec plusieurs clients pour observer les mises à jour en temps réel.
- En cas d’erreurs, vérifiez votre version de Python et assurez-vous que toutes les dépendances sont installées.

**Disclaimer**:  
Thiz documont haz been translatid yusing AI translatyun servyce [Co-op Translator](https://github.com/Azure/co-op-translator). Whyle we stryve for accurasy, pleez be awair that automatyd translatyons may contain errers or inaccuracyz. The orygynal documont in its natyve langwij shood be consydered the authoritatyve sorce. For crytical informashun, profeshunal hooman translatyun is recommynded. We ar not lyable for any missunderstandyngs or missinterpretashuns arysing from the use of this translatyun.