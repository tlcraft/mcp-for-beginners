<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-06-10T04:45:14+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "fr"
}
-->
# Rationaliser les flux de travail IA : Construire un serveur MCP avec AI Toolkit

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.fr.png)

## 🎯 Aperçu

Bienvenue à l’**atelier Model Context Protocol (MCP)** ! Cet atelier pratique complet combine deux technologies de pointe pour révolutionner le développement d’applications IA :

- **🔗 Model Context Protocol (MCP)** : un standard ouvert pour une intégration fluide des outils IA  
- **🛠️ AI Toolkit pour Visual Studio Code (AITK)** : l’extension puissante de Microsoft pour le développement IA

### 🎓 Ce que vous apprendrez

À la fin de cet atelier, vous maîtriserez l’art de créer des applications intelligentes qui connectent les modèles IA aux outils et services du monde réel. Des tests automatisés aux intégrations API personnalisées, vous développerez des compétences pratiques pour résoudre des défis métiers complexes.

## 🏗️ Stack technologique

### 🔌 Model Context Protocol (MCP)

MCP est le **« USB-C de l’IA »** – un standard universel qui connecte les modèles IA aux outils externes et aux sources de données.

**✨ Principales fonctionnalités :**  
- 🔄 **Intégration standardisée** : interface universelle pour connecter les outils IA  
- 🏛️ **Architecture flexible** : serveurs locaux et distants via transport stdio/SSE  
- 🧰 **Écosystème riche** : outils, prompts et ressources réunis dans un seul protocole  
- 🔒 **Prêt pour l’entreprise** : sécurité et fiabilité intégrées  

**🎯 Pourquoi MCP est important :**  
À l’image de ce que USB-C a fait pour le chaos des câbles, MCP simplifie la complexité des intégrations IA. Un protocole, des possibilités infinies.

### 🤖 AI Toolkit pour Visual Studio Code (AITK)

L’extension phare de Microsoft pour le développement IA qui transforme VS Code en une plateforme IA puissante.

**🚀 Capacités clés :**  
- 📦 **Catalogue de modèles** : accès aux modèles Azure AI, GitHub, Hugging Face, Ollama  
- ⚡ **Inférence locale** : exécution optimisée ONNX sur CPU/GPU/NPU  
- 🏗️ **Agent Builder** : développement visuel d’agents IA avec intégration MCP  
- 🎭 **Multi-modal** : support texte, vision et sortie structurée  

**💡 Avantages pour le développement :**  
- Déploiement de modèles sans configuration  
- Conception visuelle de prompts  
- Environnement de test en temps réel  
- Intégration transparente avec les serveurs MCP  

## 📚 Parcours d’apprentissage

### [🚀 Module 1 : Fondamentaux de AI Toolkit](./lab1/README.md)  
**Durée** : 15 minutes  
- 🛠️ Installer et configurer AI Toolkit pour VS Code  
- 🗂️ Explorer le Catalogue de modèles (plus de 100 modèles de GitHub, ONNX, OpenAI, Anthropic, Google)  
- 🎮 Maîtriser le terrain de jeu interactif pour tester les modèles en temps réel  
- 🤖 Créer votre premier agent IA avec Agent Builder  
- 📊 Évaluer les performances des modèles avec les métriques intégrées (F1, pertinence, similarité, cohérence)  
- ⚡ Apprendre le traitement par lots et le support multi-modal  

**🎯 Objectif d’apprentissage** : Créer un agent IA fonctionnel avec une compréhension complète des capacités d’AITK  

### [🌐 Module 2 : MCP avec les fondamentaux d’AI Toolkit](./lab2/README.md)  
**Durée** : 20 minutes  
- 🧠 Maîtriser l’architecture et les concepts du Model Context Protocol (MCP)  
- 🌐 Explorer l’écosystème des serveurs MCP de Microsoft  
- 🤖 Construire un agent d’automatisation de navigateur avec Playwright MCP server  
- 🔧 Intégrer les serveurs MCP avec Agent Builder d’AI Toolkit  
- 📊 Configurer et tester les outils MCP dans vos agents  
- 🚀 Exporter et déployer des agents boostés par MCP en production  

**🎯 Objectif d’apprentissage** : Déployer un agent IA enrichi par des outils externes via MCP  

### [🔧 Module 3 : Développement avancé MCP avec AI Toolkit](./lab3/README.md)  
**Durée** : 20 minutes  
- 💻 Créer des serveurs MCP personnalisés avec AI Toolkit  
- 🐍 Configurer et utiliser le dernier SDK MCP Python (v1.9.3)  
- 🔍 Mettre en place et utiliser MCP Inspector pour le débogage  
- 🛠️ Construire un serveur Weather MCP avec des workflows de débogage professionnels  
- 🧪 Déboguer les serveurs MCP dans Agent Builder et Inspector  

**🎯 Objectif d’apprentissage** : Développer et déboguer des serveurs MCP personnalisés avec des outils modernes  

### [🐙 Module 4 : Développement pratique MCP – Serveur GitHub Clone personnalisé](./lab4/README.md)  
**Durée** : 30 minutes  
- 🏗️ Construire un serveur GitHub Clone MCP réel pour les workflows de développement  
- 🔄 Implémenter un clonage intelligent de dépôts avec validation et gestion des erreurs  
- 📁 Créer une gestion intelligente des répertoires et intégration VS Code  
- 🤖 Utiliser GitHub Copilot Agent Mode avec des outils MCP personnalisés  
- 🛡️ Appliquer fiabilité et compatibilité multiplateforme prêtes pour la production  

**🎯 Objectif d’apprentissage** : Déployer un serveur MCP prêt pour la production qui optimise les workflows de développement réels  

## 💡 Applications concrètes et impact

### 🏢 Cas d’usage en entreprise

#### 🔄 Automatisation DevOps  
Transformez votre flux de développement avec l’automatisation intelligente :  
- **Gestion intelligente des dépôts** : revue de code et décisions de fusion pilotées par IA  
- **CI/CD intelligent** : optimisation automatisée des pipelines selon les changements de code  
- **Tri des issues** : classification et assignation automatiques des bugs  

#### 🧪 Révolution de l’assurance qualité  
Améliorez les tests grâce à l’automatisation IA :  
- **Génération intelligente de tests** : création automatique de suites de tests complètes  
- **Tests de régression visuelle** : détection IA des changements d’interface utilisateur  
- **Surveillance des performances** : identification proactive et résolution des problèmes  

#### 📊 Intelligence des pipelines de données  
Construisez des workflows de traitement de données plus intelligents :  
- **Processus ETL adaptatifs** : transformations de données auto-optimisées  
- **Détection d’anomalies** : surveillance qualité des données en temps réel  
- **Routage intelligent** : gestion intelligente des flux de données  

#### 🎧 Amélioration de l’expérience client  
Créez des interactions client exceptionnelles :  
- **Support contextuel** : agents IA avec accès à l’historique client  
- **Résolution proactive des problèmes** : service client prédictif  
- **Intégration multi-canal** : expérience IA unifiée sur toutes les plateformes  

## 🛠️ Prérequis et installation

### 💻 Configuration système

| Composant            | Exigence               | Remarques                     |
|---------------------|-----------------------|------------------------------|
| **Système d’exploitation** | Windows 10+, macOS 10.15+, Linux | Tout OS moderne               |
| **Visual Studio Code** | Dernière version stable | Requis pour AITK             |
| **Node.js**           | v18.0+ et npm          | Pour le développement serveur MCP |
| **Python**            | 3.10+                  | Optionnel pour serveurs MCP Python |
| **Mémoire**           | Minimum 8 Go RAM       | 16 Go recommandés pour modèles locaux |

### 🔧 Environnement de développement

#### Extensions VS Code recommandées  
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)  
- **Python** (ms-python.python)  
- **Python Debugger** (ms-python.debugpy)  
- **GitHub Copilot** (GitHub.copilot) – optionnel mais utile  

#### Outils optionnels  
- **uv** : gestionnaire de paquets Python moderne  
- **MCP Inspector** : outil visuel de débogage pour serveurs MCP  
- **Playwright** : pour les exemples d’automatisation web  

## 🎖️ Résultats d’apprentissage et parcours de certification

### 🏆 Checklist de maîtrise des compétences

En complétant cet atelier, vous maîtriserez :

#### 🎯 Compétences clés  
- [ ] **Maîtrise du protocole MCP** : compréhension approfondie de l’architecture et des modèles d’implémentation  
- [ ] **Compétence AITK** : utilisation experte d’AI Toolkit pour un développement rapide  
- [ ] **Développement de serveurs personnalisés** : création, déploiement et maintenance de serveurs MCP en production  
- [ ] **Excellence en intégration d’outils** : connexion fluide de l’IA avec les workflows de développement existants  
- [ ] **Application de la résolution de problèmes** : mise en pratique des compétences sur des défis métiers réels  

#### 🔧 Compétences techniques  
- [ ] Installer et configurer AI Toolkit dans VS Code  
- [ ] Concevoir et implémenter des serveurs MCP personnalisés  
- [ ] Intégrer les modèles GitHub avec l’architecture MCP  
- [ ] Construire des workflows de tests automatisés avec Playwright  
- [ ] Déployer des agents IA en production  
- [ ] Déboguer et optimiser les performances des serveurs MCP  

#### 🚀 Capacités avancées  
- [ ] Architecturer des intégrations IA à l’échelle entreprise  
- [ ] Mettre en œuvre les meilleures pratiques de sécurité pour les applications IA  
- [ ] Concevoir des architectures de serveurs MCP évolutives  
- [ ] Créer des chaînes d’outils personnalisées pour des domaines spécifiques  
- [ ] Former d’autres développeurs à la programmation IA native  

## 📖 Ressources complémentaires  
- [Spécification MCP](https://modelcontextprotocol.io/docs)  
- [Dépôt GitHub AI Toolkit](https://github.com/microsoft/vscode-ai-toolkit)  
- [Collection d’exemples de serveurs MCP](https://github.com/modelcontextprotocol/servers)  
- [Guide des meilleures pratiques](https://modelcontextprotocol.io/docs/best-practices)  

---

**🚀 Prêt à révolutionner votre flux de développement IA ?**  

Construisons ensemble le futur des applications intelligentes avec MCP et AI Toolkit !

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.