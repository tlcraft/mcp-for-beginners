<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-06-10T04:55:43+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "pl"
}
-->
# Usprawnianie przepływów pracy AI: Budowa serwera MCP z AI Toolkit

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.pl.png)

## 🎯 Przegląd

Witamy na **Model Context Protocol (MCP) Workshop**! Ten kompleksowy warsztat praktyczny łączy dwie nowoczesne technologie, które zrewolucjonizują tworzenie aplikacji AI:

- **🔗 Model Context Protocol (MCP)**: otwarty standard do bezproblemowej integracji narzędzi AI
- **🛠️ AI Toolkit for Visual Studio Code (AITK)**: potężne rozszerzenie Microsoftu do rozwoju AI

### 🎓 Czego się nauczysz

Na koniec warsztatu opanujesz sztukę tworzenia inteligentnych aplikacji łączących modele AI z rzeczywistymi narzędziami i usługami. Od automatycznych testów po niestandardowe integracje API – zdobędziesz praktyczne umiejętności rozwiązywania złożonych problemów biznesowych.

## 🏗️ Stos technologiczny

### 🔌 Model Context Protocol (MCP)

MCP to **„USB-C dla AI”** – uniwersalny standard łączący modele AI z zewnętrznymi narzędziami i źródłami danych.

**✨ Kluczowe cechy:**
- 🔄 **Standaryzowana integracja**: uniwersalny interfejs do łączenia narzędzi AI
- 🏛️ **Elastyczna architektura**: serwery lokalne i zdalne przez transport stdio/SSE
- 🧰 **Bogaty ekosystem**: narzędzia, podpowiedzi i zasoby w jednym protokole
- 🔒 **Gotowość korporacyjna**: wbudowane zabezpieczenia i niezawodność

**🎯 Dlaczego MCP jest ważny:**
Tak jak USB-C wyeliminował bałagan z kablami, MCP upraszcza integracje AI. Jeden protokół, nieskończone możliwości.

### 🤖 AI Toolkit for Visual Studio Code (AITK)

Flagowe rozszerzenie Microsoftu do rozwoju AI, które zmienia VS Code w potężne narzędzie AI.

**🚀 Główne możliwości:**
- 📦 **Katalog modeli**: dostęp do modeli z Azure AI, GitHub, Hugging Face, Ollama
- ⚡ **Lokalne wnioskowanie**: zoptymalizowane ONNX dla CPU/GPU/NPU
- 🏗️ **Agent Builder**: wizualne tworzenie agentów AI z integracją MCP
- 🎭 **Multi-modalność**: wsparcie tekstu, obrazu i danych strukturalnych

**💡 Korzyści dla deweloperów:**
- Wdrażanie modeli bez konfiguracji
- Wizualne projektowanie podpowiedzi
- Plac zabaw do testów w czasie rzeczywistym
- Płynna integracja z serwerem MCP

## 📚 Plan nauki

### [🚀 Moduł 1: Podstawy AI Toolkit](./lab1/README.md)
**Czas trwania**: 15 minut
- 🛠️ Instalacja i konfiguracja AI Toolkit dla VS Code
- 🗂️ Poznanie Model Catalog (ponad 100 modeli z GitHub, ONNX, OpenAI, Anthropic, Google)
- 🎮 Opanowanie Interactive Playground do testów modeli w czasie rzeczywistym
- 🤖 Budowa pierwszego agenta AI z Agent Builder
- 📊 Ocena wydajności modeli za pomocą wbudowanych metryk (F1, trafność, podobieństwo, spójność)
- ⚡ Nauka przetwarzania wsadowego i obsługi multi-modalnej

**🎯 Efekt nauki**: Stworzenie funkcjonalnego agenta AI z pełnym zrozumieniem możliwości AITK

### [🌐 Moduł 2: MCP z podstawami AI Toolkit](./lab2/README.md)
**Czas trwania**: 20 minut
- 🧠 Poznanie architektury i koncepcji Model Context Protocol (MCP)
- 🌐 Zapoznanie się z ekosystemem serwerów MCP Microsoftu
- 🤖 Budowa agenta do automatyzacji przeglądarki z użyciem Playwright MCP server
- 🔧 Integracja serwerów MCP z Agent Builder AI Toolkit
- 📊 Konfiguracja i testowanie narzędzi MCP w agentach
- 🚀 Eksport i wdrożenie agentów MCP do produkcji

**🎯 Efekt nauki**: Wdrożenie agenta AI wzbogaconego o zewnętrzne narzędzia przez MCP

### [🔧 Moduł 3: Zaawansowany rozwój MCP z AI Toolkit](./lab3/README.md)
**Czas trwania**: 20 minut
- 💻 Tworzenie własnych serwerów MCP z AI Toolkit
- 🐍 Konfiguracja i użycie najnowszego MCP Python SDK (v1.9.3)
- 🔍 Ustawienie i korzystanie z MCP Inspector do debugowania
- 🛠️ Budowa Weather MCP Server z profesjonalnymi procesami debugowania
- 🧪 Debugowanie serwerów MCP w Agent Builder i Inspector

**🎯 Efekt nauki**: Tworzenie i debugowanie własnych serwerów MCP z nowoczesnymi narzędziami

### [🐙 Moduł 4: Praktyczny rozwój MCP – niestandardowy serwer GitHub Clone](./lab4/README.md)
**Czas trwania**: 30 minut
- 🏗️ Budowa rzeczywistego serwera GitHub Clone MCP dla przepływów pracy developerskich
- 🔄 Implementacja inteligentnego klonowania repozytoriów z walidacją i obsługą błędów
- 📁 Tworzenie inteligentnego zarządzania katalogami i integracja z VS Code
- 🤖 Użycie GitHub Copilot Agent Mode z niestandardowymi narzędziami MCP
- 🛡️ Zapewnienie niezawodności produkcyjnej i kompatybilności międzyplatformowej

**🎯 Efekt nauki**: Wdrożenie produkcyjnego serwera MCP usprawniającego rzeczywiste przepływy pracy

## 💡 Zastosowania w praktyce i wpływ

### 🏢 Przypadki użycia w przedsiębiorstwach

#### 🔄 Automatyzacja DevOps
Zmień swój workflow developerski dzięki inteligentnej automatyzacji:
- **Inteligentne zarządzanie repozytoriami**: AI wspiera przegląd kodu i decyzje o scalaniu
- **Inteligentne CI/CD**: automatyczna optymalizacja pipeline’ów na podstawie zmian w kodzie
- **Triaging zgłoszeń**: automatyczna klasyfikacja i przypisywanie błędów

#### 🧪 Rewolucja w kontroli jakości
Podnieś jakość testów dzięki automatyzacji AI:
- **Inteligentne generowanie testów**: automatyczne tworzenie kompleksowych zestawów testowych
- **Testy regresji wizualnej**: wykrywanie zmian UI wspomagane AI
- **Monitorowanie wydajności**: proaktywne wykrywanie i rozwiązywanie problemów

#### 📊 Inteligentne przetwarzanie danych
Buduj mądrzejsze przepływy danych:
- **Adaptacyjne procesy ETL**: samonaprawiające się transformacje danych
- **Wykrywanie anomalii**: monitorowanie jakości danych w czasie rzeczywistym
- **Inteligentne kierowanie danych**: zarządzanie przepływem danych

#### 🎧 Ulepszanie doświadczeń klienta
Twórz wyjątkowe interakcje z klientami:
- **Wsparcie z kontekstem**: agenci AI z dostępem do historii klienta
- **Proaktywne rozwiązywanie problemów**: przewidywanie potrzeb obsługi klienta
- **Integracja wielokanałowa**: jednolite doświadczenie AI na różnych platformach

## 🛠️ Wymagania wstępne i konfiguracja

### 💻 Wymagania systemowe

| Komponent           | Wymaganie             | Uwagi                 |
|---------------------|-----------------------|-----------------------|
| **System operacyjny**| Windows 10+, macOS 10.15+, Linux | Dowolny nowoczesny OS |
| **Visual Studio Code** | Najnowsza stabilna wersja | Wymagane do AITK      |
| **Node.js**          | v18.0+ i npm          | Do tworzenia serwerów MCP |
| **Python**           | 3.10+                 | Opcjonalnie do serwerów MCP w Pythonie |
| **Pamięć**           | Minimum 8GB RAM       | 16GB zalecane dla lokalnych modeli |

### 🔧 Środowisko developerskie

#### Polecane rozszerzenia VS Code
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) – opcjonalnie, ale pomocne

#### Narzędzia opcjonalne
- **uv**: nowoczesny menedżer pakietów Python
- **MCP Inspector**: wizualne narzędzie do debugowania serwerów MCP
- **Playwright**: do przykładów automatyzacji webowej

## 🎖️ Efekty nauki i ścieżka certyfikacji

### 🏆 Lista umiejętności do opanowania

Po ukończeniu warsztatu osiągniesz biegłość w:

#### 🎯 Kluczowe kompetencje
- [ ] **Mistrzostwo protokołu MCP**: dogłębne zrozumienie architektury i wzorców implementacji
- [ ] **Biegłość w AITK**: eksperckie wykorzystanie AI Toolkit do szybkiego rozwoju
- [ ] **Tworzenie niestandardowych serwerów**: budowa, wdrażanie i utrzymanie produkcyjnych serwerów MCP
- [ ] **Doskonałość integracji narzędzi**: płynne łączenie AI z istniejącymi workflow developerskimi
- [ ] **Zastosowanie rozwiązań problemów**: wykorzystanie umiejętności do realnych wyzwań biznesowych

#### 🔧 Umiejętności techniczne
- [ ] Konfiguracja i uruchomienie AI Toolkit w VS Code
- [ ] Projektowanie i implementacja niestandardowych serwerów MCP
- [ ] Integracja modeli GitHub z architekturą MCP
- [ ] Budowa automatycznych workflow testowych z Playwright
- [ ] Wdrażanie agentów AI do produkcji
- [ ] Debugowanie i optymalizacja wydajności serwerów MCP

#### 🚀 Zaawansowane możliwości
- [ ] Projektowanie integracji AI na skalę przedsiębiorstwa
- [ ] Wdrażanie najlepszych praktyk bezpieczeństwa w aplikacjach AI
- [ ] Projektowanie skalowalnych architektur serwerów MCP
- [ ] Tworzenie niestandardowych łańcuchów narzędzi dla konkretnych dziedzin
- [ ] Mentoring innych w rozwoju natywnym AI

## 📖 Dodatkowe materiały
- [MCP Specification](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit)
- [Sample MCP Servers Collection](https://github.com/modelcontextprotocol/servers)
- [Best Practices Guide](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 Gotowy zrewolucjonizować swój workflow rozwoju AI?**

Zbudujmy razem przyszłość inteligentnych aplikacji z MCP i AI Toolkit!

**Zastrzeżenie**:  
Ten dokument został przetłumaczony za pomocą usługi tłumaczeń AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było precyzyjne, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za wiarygodne źródło. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.