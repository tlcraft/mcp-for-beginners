<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:35:47+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "fr"
}
-->
# Générateur de plan d’étude avec Chainlit & Microsoft Learn Docs MCP

## Prérequis

- Python 3.8 ou supérieur  
- pip (gestionnaire de paquets Python)  
- Accès Internet pour se connecter au serveur Microsoft Learn Docs MCP  

## Installation

1. Clonez ce dépôt ou téléchargez les fichiers du projet.  
2. Installez les dépendances requises :  

   ```bash
   pip install -r requirements.txt
   ```

## Utilisation

### Scénario 1 : Requête simple vers Docs MCP  
Un client en ligne de commande qui se connecte au serveur Docs MCP, envoie une requête et affiche le résultat.

1. Lancez le script :  
   ```bash
   python scenario1.py
   ```  
2. Saisissez votre question sur la documentation à l’invite.

### Scénario 2 : Générateur de plan d’étude (application web Chainlit)  
Une interface web (utilisant Chainlit) qui permet aux utilisateurs de générer un plan d’étude personnalisé, semaine par semaine, pour n’importe quel sujet technique.

1. Démarrez l’application Chainlit :  
   ```bash
   chainlit run scenario2.py
   ```  
2. Ouvrez l’URL locale affichée dans votre terminal (par exemple http://localhost:8000) dans votre navigateur.  
3. Dans la fenêtre de chat, saisissez votre sujet d’étude et le nombre de semaines souhaité (par exemple, « certification AI-900, 8 semaines »).  
4. L’application répondra avec un plan d’étude semaine par semaine, incluant des liens vers la documentation Microsoft Learn pertinente.

**Variables d’environnement requises :**

Pour utiliser le Scénario 2 (l’application web Chainlit avec Azure OpenAI), vous devez définir les variables d’environnement suivantes dans un fichier `.env` situé dans le répertoire `python` :

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Remplissez ces valeurs avec les détails de votre ressource Azure OpenAI avant de lancer l’application.

> **Tip :** Vous pouvez facilement déployer vos propres modèles avec [Azure AI Foundry](https://ai.azure.com/).

### Scénario 3 : Documentation intégrée dans l’éditeur avec le serveur MCP dans VS Code

Au lieu de changer d’onglet dans votre navigateur pour chercher la documentation, vous pouvez intégrer Microsoft Learn Docs directement dans VS Code grâce au serveur MCP. Cela vous permet de :  
- Rechercher et lire la documentation dans VS Code sans quitter votre environnement de développement.  
- Référencer la documentation et insérer des liens directement dans vos fichiers README ou de cours.  
- Utiliser GitHub Copilot et MCP ensemble pour un flux de travail documentaire fluide et assisté par IA.

**Exemples d’utilisation :**  
- Ajouter rapidement des liens de référence dans un README pendant la rédaction d’un cours ou d’une documentation de projet.  
- Utiliser Copilot pour générer du code et MCP pour trouver et citer instantanément la documentation pertinente.  
- Rester concentré dans votre éditeur et augmenter votre productivité.

> [!IMPORTANT]  
> Assurez-vous d’avoir une configuration valide [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) dans votre espace de travail (emplacement : `.vscode/mcp.json`).

## Pourquoi Chainlit pour le Scénario 2 ?

Chainlit est un framework open-source moderne pour créer des applications web conversationnelles. Il facilite la création d’interfaces de chat connectées à des services backend comme le serveur Microsoft Learn Docs MCP. Ce projet utilise Chainlit pour offrir une manière simple et interactive de générer des plans d’étude personnalisés en temps réel. Grâce à Chainlit, vous pouvez rapidement construire et déployer des outils de chat qui améliorent la productivité et l’apprentissage.

## Ce que fait cette application

Cette application permet aux utilisateurs de créer un plan d’étude personnalisé en saisissant simplement un sujet et une durée. L’application analyse votre saisie, interroge le serveur Microsoft Learn Docs MCP pour trouver du contenu pertinent, puis organise les résultats en un plan structuré semaine par semaine. Les recommandations de chaque semaine sont affichées dans le chat, ce qui facilite le suivi et la progression. L’intégration garantit que vous obtenez toujours les ressources d’apprentissage les plus récentes et adaptées.

## Exemples de requêtes

Essayez ces requêtes dans la fenêtre de chat pour voir comment l’application répond :

- `certification AI-900, 8 semaines`  
- `Apprendre Azure Functions, 4 semaines`  
- `Azure DevOps, 6 semaines`  
- `Ingénierie des données sur Azure, 10 semaines`  
- `Fondamentaux de la sécurité Microsoft, 5 semaines`  
- `Power Platform, 7 semaines`  
- `Services Azure AI, 12 semaines`  
- `Architecture cloud, 9 semaines`  

Ces exemples montrent la flexibilité de l’application pour différents objectifs d’apprentissage et durées.

## Références

- [Documentation Chainlit](https://docs.chainlit.io/)  
- [Documentation MCP](https://github.com/MicrosoftDocs/mcp)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.