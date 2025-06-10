<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2aa9dbc165e104764fa57e8a0d3f1c73",
  "translation_date": "2025-06-10T05:19:15+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab1/README.md",
  "language_code": "it"
}
-->
# 🚀 Modulo 1: Fondamenti di AI Toolkit

[![Duration](https://img.shields.io/badge/Duration-15%20minutes-blue.svg)]()
[![Difficulty](https://img.shields.io/badge/Difficulty-Beginner-green.svg)]()
[![Prerequisites](https://img.shields.io/badge/Prerequisites-VS%20Code-orange.svg)]()

## 📋 Obiettivi di Apprendimento

Al termine di questo modulo, sarai in grado di:
- ✅ Installare e configurare AI Toolkit per Visual Studio Code
- ✅ Navigare nel Catalogo Modelli e comprendere le diverse fonti dei modelli
- ✅ Utilizzare il Playground per testare e sperimentare con i modelli
- ✅ Creare agenti AI personalizzati con Agent Builder
- ✅ Confrontare le prestazioni dei modelli tra diversi provider
- ✅ Applicare le migliori pratiche per il prompt engineering

## 🧠 Introduzione a AI Toolkit (AITK)

**AI Toolkit per Visual Studio Code** è l’estensione principale di Microsoft che trasforma VS Code in un ambiente completo per lo sviluppo AI. Colma il divario tra ricerca AI e sviluppo pratico, rendendo l’intelligenza artificiale generativa accessibile a sviluppatori di tutti i livelli.

### 🌟 Funzionalità Principali

| Funzionalità | Descrizione | Caso d’uso |
|--------------|-------------|------------|
| **🗂️ Model Catalog** | Accesso a oltre 100 modelli da GitHub, ONNX, OpenAI, Anthropic, Google | Scoperta e selezione modelli |
| **🔌 BYOM Support** | Integra i tuoi modelli (locali/remoti) | Deploy di modelli personalizzati |
| **🎮 Interactive Playground** | Test in tempo reale con interfaccia chat | Prototipazione rapida e test |
| **📎 Multi-Modal Support** | Gestione di testo, immagini e allegati | Applicazioni AI complesse |
| **⚡ Batch Processing** | Esecuzione simultanea di più prompt | Workflow di test efficienti |
| **📊 Model Evaluation** | Metriche integrate (F1, rilevanza, similarità, coerenza) | Valutazione delle prestazioni |

### 🎯 Perché AI Toolkit è Importante

- **🚀 Sviluppo Accelerato**: Dall’idea al prototipo in pochi minuti
- **🔄 Workflow Unificato**: Un’unica interfaccia per più provider AI
- **🧪 Sperimentazione Semplice**: Confronta modelli senza configurazioni complesse
- **📈 Pronto per la Produzione**: Transizione fluida dal prototipo al deployment

## 🛠️ Prerequisiti & Configurazione

### 📦 Installazione dell’Estensione AI Toolkit

**Passo 1: Accedi al Marketplace delle Estensioni**
1. Apri Visual Studio Code
2. Vai alla vista Estensioni (`Ctrl+Shift+X` o `Cmd+Shift+X`)
3. Cerca "AI Toolkit"

**Passo 2: Scegli la Versione**
- **🟢 Release**: Consigliata per l’uso in produzione
- **🔶 Pre-release**: Accesso anticipato a funzionalità all’avanguardia

**Passo 3: Installa e Attiva**

![AI Toolkit Extension](../../../../translated_images/aitkext.d28945a03eed003c39fc39bc96ae655af9b64b9b922e78e88b07214420ed7985.it.png)

### ✅ Checklist di Verifica
- [ ] L’icona AI Toolkit appare nella barra laterale di VS Code
- [ ] L’estensione è abilitata e attiva
- [ ] Nessun errore di installazione nel pannello output

## 🧪 Esercizio Pratico 1: Esplorare i Modelli GitHub

**🎯 Obiettivo**: Imparare a usare il Model Catalog e testare il primo modello AI

### 📊 Passo 1: Naviga nel Model Catalog

Il Model Catalog è la tua porta d’ingresso all’ecosistema AI. Aggrega modelli da diversi provider, facilitando scoperta e confronto.

**🔍 Guida alla Navigazione:**

Clicca su **MODELS - Catalog** nella barra laterale di AI Toolkit

![Model Catalog](../../../../translated_images/aimodel.263ed2be013d8fb0e2265c4f742cfe490f6f00eca5e132ec50438c8e826e34ed.it.png)

**💡 Consiglio**: Cerca modelli con capacità specifiche che si adattino al tuo caso d’uso (es. generazione di codice, scrittura creativa, analisi).

**⚠️ Nota**: I modelli ospitati su GitHub (GitHub Models) sono gratuiti ma soggetti a limiti di richieste e token. Per accedere a modelli esterni (es. ospitati su Azure AI o altri endpoint), dovrai fornire la chiave API o autenticazione adeguata.

### 🚀 Passo 2: Aggiungi e Configura il Primo Modello

**Strategia di Selezione Modello:**
- **GPT-4.1**: Ideale per ragionamenti complessi e analisi
- **Phi-4-mini**: Leggero e veloce per compiti semplici

**🔧 Processo di Configurazione:**
1. Seleziona **OpenAI GPT-4.1** dal catalogo
2. Clicca su **Add to My Models** per registrare il modello
3. Scegli **Try in Playground** per aprire l’ambiente di test
4. Attendi l’inizializzazione del modello (la prima volta potrebbe richiedere qualche istante)

![Playground Setup](../../../../translated_images/playground.dd6f5141344878ca4d4f3de819775da7b113518941accf37c291117c602f85db.it.png)

**⚙️ Parametri del Modello:**
- **Temperature**: Controlla la creatività (0 = deterministico, 1 = creativo)
- **Max Tokens**: Lunghezza massima della risposta
- **Top-p**: Campionamento nucleus per diversità della risposta

### 🎯 Passo 3: Padroneggia l’Interfaccia del Playground

Il Playground è il tuo laboratorio di sperimentazione AI. Ecco come sfruttarlo al meglio:

**🎨 Best Practice per il Prompt Engineering:**
1. **Sii Specifico**: Istruzioni chiare e dettagliate danno risultati migliori
2. **Fornisci Contesto**: Includi informazioni di background rilevanti
3. **Usa Esempi**: Mostra al modello cosa vuoi con esempi concreti
4. **Itera**: Affina i prompt in base ai risultati iniziali

**🧪 Scenari di Test:**
```markdown
# Example 1: Code Generation
"Write a Python function that calculates the factorial of a number using recursion. Include error handling and docstrings."

# Example 2: Creative Writing
"Write a professional email to a client explaining a project delay, maintaining a positive tone while being transparent about challenges."

# Example 3: Data Analysis
"Analyze this sales data and provide insights: [paste your data]. Focus on trends, anomalies, and actionable recommendations."
```

![Testing Results](../../../../translated_images/result.1dfcf211fb359cf65902b09db191d3bfc65713ca15e279c1a30be213bb526949.it.png)

### 🏆 Esercizio Sfida: Confronto delle Prestazioni dei Modelli

**🎯 Obiettivo**: Confrontare diversi modelli usando gli stessi prompt per valutarne i punti di forza

**📋 Istruzioni:**
1. Aggiungi **Phi-4-mini** al tuo workspace
2. Usa lo stesso prompt per GPT-4.1 e Phi-4-mini

![set](../../../../translated_images/set.88132df189ecde2cbbda256c1841db5aac8e9bdeba1a4e343dfa031b9545d6c9.it.png)

3. Confronta qualità, velocità e accuratezza delle risposte
4. Documenta le tue osservazioni nella sezione risultati

![Model Comparison](../../../../translated_images/compare.97746cd0f907495503c1fc217739f3890dc76ea5f6fd92379a6db0cc331feb58.it.png)

**💡 Spunti Chiave da Scoprire:**
- Quando usare LLM vs SLM
- Compromessi tra costi e prestazioni
- Capacità specializzate di diversi modelli

## 🤖 Esercizio Pratico 2: Creare Agenti Personalizzati con Agent Builder

**🎯 Obiettivo**: Costruire agenti AI specializzati per compiti e workflow specifici

### 🏗️ Passo 1: Comprendere Agent Builder

Agent Builder è il vero punto di forza di AI Toolkit. Ti permette di creare assistenti AI su misura, combinando la potenza dei grandi modelli linguistici con istruzioni personalizzate, parametri specifici e conoscenze specializzate.

**🧠 Componenti dell’Architettura Agente:**
- **Core Model**: Il modello base LLM (GPT-4, Groks, Phi, ecc.)
- **System Prompt**: Definisce la personalità e il comportamento dell’agente
- **Parametri**: Impostazioni ottimizzate per le prestazioni
- **Integrazione Strumenti**: Connessione ad API esterne e servizi MCP
- **Memoria**: Contesto della conversazione e persistenza della sessione

![Agent Builder Interface](../../../../translated_images/agentbuilder.25895b2d2f8c02e7aa99dd40e105877a6f1db8f0441180087e39db67744b361f.it.png)

### ⚙️ Passo 2: Approfondimento sulla Configurazione dell’Agente

**🎨 Creare System Prompt Efficaci:**
```markdown
# Template Structure:
## Role Definition
You are a [specific role] with expertise in [domain].

## Capabilities
- List specific abilities
- Define scope of knowledge
- Clarify limitations

## Behavior Guidelines
- Response style (formal, casual, technical)
- Output format preferences
- Error handling approach

## Examples
Provide 2-3 examples of ideal interactions
```

*Naturalmente, puoi anche usare Generate System Prompt per farti aiutare dall’AI a creare e ottimizzare i prompt*

**🔧 Ottimizzazione dei Parametri:**
| Parametro | Intervallo Consigliato | Caso d’Uso |
|-----------|-----------------------|------------|
| **Temperature** | 0.1-0.3 | Risposte tecniche/fattuali |
| **Temperature** | 0.7-0.9 | Compiti creativi/brainstorming |
| **Max Tokens** | 500-1000 | Risposte concise |
| **Max Tokens** | 2000-4000 | Spiegazioni dettagliate |

### 🐍 Passo 3: Esercizio Pratico - Agente di Programmazione Python

**🎯 Missione**: Creare un assistente specializzato in coding Python

**📋 Passi di Configurazione:**

1. **Selezione Modello**: Scegli **Claude 3.5 Sonnet** (ottimo per codice)

2. **Design del System Prompt**:
```markdown
# Python Programming Expert Agent

## Role
You are a senior Python developer with 10+ years of experience. You excel at writing clean, efficient, and well-documented Python code.

## Capabilities
- Write production-ready Python code
- Debug complex issues
- Explain code concepts clearly
- Suggest best practices and optimizations
- Provide complete working examples

## Response Format
- Always include docstrings
- Add inline comments for complex logic
- Suggest testing approaches
- Mention relevant libraries when applicable

## Code Quality Standards
- Follow PEP 8 style guidelines
- Use type hints where appropriate
- Handle exceptions gracefully
- Write readable, maintainable code
```

3. **Configurazione Parametri**:
   - Temperature: 0.2 (per codice affidabile e coerente)
   - Max Tokens: 2000 (spiegazioni dettagliate)
   - Top-p: 0.9 (creatività bilanciata)

![Python Agent Configuration](../../../../translated_images/pythonagent.5e51b406401c165fcabfd66f2d943c27f46b5fed0f9fb73abefc9e91ca3489d4.it.png)

### 🧪 Passo 4: Testare il Tuo Agente Python

**Scenari di Test:**
1. **Funzione Base**: "Crea una funzione per trovare numeri primi"
2. **Algoritmo Complesso**: "Implementa un albero di ricerca binaria con metodi insert, delete e search"
3. **Problema Reale**: "Costruisci un web scraper che gestisca rate limiting e retry"
4. **Debugging**: "Correggi questo codice [incolla codice con errori]"

**🏆 Criteri di Successo:**
- ✅ Il codice funziona senza errori
- ✅ Include documentazione adeguata
- ✅ Rispetta le best practice di Python
- ✅ Fornisce spiegazioni chiare
- ✅ Suggerisce miglioramenti

## 🎓 Conclusione Modulo 1 & Passi Successivi

### 📊 Verifica delle Conoscenze

Metti alla prova le tue competenze:
- [ ] Riesci a spiegare le differenze tra i modelli nel catalogo?
- [ ] Hai creato e testato con successo un agente personalizzato?
- [ ] Sai come ottimizzare i parametri per diversi casi d’uso?
- [ ] Sei in grado di progettare system prompt efficaci?

### 📚 Risorse Aggiuntive

- **Documentazione AI Toolkit**: [Official Microsoft Docs](https://github.com/microsoft/vscode-ai-toolkit)
- **Guida al Prompt Engineering**: [Best Practices](https://platform.openai.com/docs/guides/prompt-engineering)
- **Modelli in AI Toolkit**: [Models in Develpment](https://github.com/microsoft/vscode-ai-toolkit/blob/main/doc/models.md)

**🎉 Complimenti!** Hai acquisito le basi di AI Toolkit e sei pronto per sviluppare applicazioni AI più avanzate!

### 🔜 Prosegui al Modulo Successivo

Pronto per funzionalità più avanzate? Prosegui con **[Modulo 2: MCP con AI Toolkit Fundamentals](../lab2/README.md)** dove imparerai a:
- Collegare i tuoi agenti a strumenti esterni usando Model Context Protocol (MCP)
- Costruire agenti di automazione browser con Playwright
- Integrare server MCP con i tuoi agenti AI Toolkit
- Potenziare i tuoi agenti con dati e funzionalità esterne

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali fraintendimenti o interpretazioni errate derivanti dall’uso di questa traduzione.