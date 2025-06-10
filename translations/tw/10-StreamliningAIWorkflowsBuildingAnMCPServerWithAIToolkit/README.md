<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-06-10T04:50:25+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "tw"
}
-->
# Streamlining AI Workflows: Building an MCP Server with AI Toolkit

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.tw.png)

## 🎯 概覽

歡迎來到 **Model Context Protocol (MCP) 工作坊**！這個完整的實作工作坊結合兩項尖端技術，徹底改變 AI 應用開發的方式：

- **🔗 Model Context Protocol (MCP)**：一個無縫整合 AI 工具的開放標準
- **🛠️ AI Toolkit for Visual Studio Code (AITK)**：微軟強大的 AI 開發擴充套件

### 🎓 你將學到什麼

完成這個工作坊後，你將能打造智慧型應用程式，將 AI 模型與實際工具和服務串接起來。從自動化測試到客製化 API 整合，實務技能助你解決複雜商業挑戰。

## 🏗️ 技術堆疊

### 🔌 Model Context Protocol (MCP)

MCP 是 AI 的 **「USB-C」** — 一個連接 AI 模型與外部工具和資料來源的通用標準。

**✨ 主要特色：**
- 🔄 **標準化整合**：AI 工具連接的通用介面
- 🏛️ **彈性架構**：支援本地與遠端伺服器，透過 stdio/SSE 傳輸
- 🧰 **豐富生態系**：工具、提示與資源整合於同一協定
- 🔒 **企業級安全**：內建安全與可靠性

**🎯 MCP 的重要性：**
就像 USB-C 解決了線材混亂，MCP 讓 AI 整合不再複雜。一個協定，無限可能。

### 🤖 AI Toolkit for Visual Studio Code (AITK)

微軟旗艦的 AI 開發擴充套件，將 VS Code 變成 AI 能量中心。

**🚀 核心功能：**
- 📦 **模型目錄**：存取 Azure AI、GitHub、Hugging Face、Ollama 等模型
- ⚡ **本地推論**：ONNX 最佳化的 CPU/GPU/NPU 執行
- 🏗️ **Agent Builder**：視覺化 AI 代理開發，整合 MCP
- 🎭 **多模態支援**：文字、視覺與結構化輸出

**💡 開發優勢：**
- 零設定模型部署
- 視覺化提示工程
- 即時測試環境
- 無縫 MCP 伺服器整合

## 📚 學習旅程

### [🚀 Module 1: AI Toolkit Fundamentals](./lab1/README.md)
**時長**：15 分鐘
- 🛠️ 安裝並設定 AI Toolkit for VS Code
- 🗂️ 探索模型目錄（來自 GitHub、ONNX、OpenAI、Anthropic、Google 的 100+ 模型）
- 🎮 精通互動式測試環境，實時測試模型
- 🤖 使用 Agent Builder 建立你的第一個 AI 代理
- 📊 利用內建指標評估模型表現（F1、相關性、相似度、一致性）
- ⚡ 學習批次處理與多模態支援功能

**🎯 學習成果**：打造功能完整的 AI 代理，全面理解 AITK 能力

### [🌐 Module 2: MCP with AI Toolkit Fundamentals](./lab2/README.md)
**時長**：20 分鐘
- 🧠 掌握 Model Context Protocol (MCP) 架構與概念
- 🌐 探索微軟 MCP 伺服器生態系
- 🤖 利用 Playwright MCP 伺服器打造瀏覽器自動化代理
- 🔧 將 MCP 伺服器整合進 AI Toolkit Agent Builder
- 📊 設定並測試代理中的 MCP 工具
- 🚀 匯出並部署 MCP 支援的代理到生產環境

**🎯 學習成果**：部署一個透過 MCP 與外部工具強化的 AI 代理

### [🔧 Module 3: Advanced MCP Development with AI Toolkit](./lab3/README.md)
**時長**：20 分鐘
- 💻 使用 AI Toolkit 建立客製 MCP 伺服器
- 🐍 設定並使用最新 MCP Python SDK (v1.9.3)
- 🔍 建置並運用 MCP Inspector 進行除錯
- 🛠️ 建立具專業除錯流程的天氣 MCP 伺服器
- 🧪 在 Agent Builder 與 Inspector 環境中除錯 MCP 伺服器

**🎯 學習成果**：開發並除錯具現代化工具的客製 MCP 伺服器

### [🐙 Module 4: Practical MCP Development - Custom GitHub Clone Server](./lab4/README.md)
**時長**：30 分鐘
- 🏗️ 建立一個真實世界的 GitHub Clone MCP 伺服器，用於開發流程
- 🔄 實作智慧型版本庫複製，包含驗證與錯誤處理
- 📁 創建智慧型目錄管理與 VS Code 整合
- 🤖 使用 GitHub Copilot Agent Mode 搭配客製 MCP 工具
- 🛡️ 套用生產級可靠性與跨平台相容性

**🎯 學習成果**：部署一個生產就緒的 MCP 伺服器，優化真實開發流程

## 💡 真實應用與影響

### 🏢 企業應用案例

#### 🔄 DevOps 自動化
用智慧自動化改造你的開發流程：
- **智慧版本庫管理**：AI 驅動的程式碼審查與合併決策
- **智慧 CI/CD**：根據程式碼變更自動優化管線
- **問題分類**：自動化錯誤分類與指派

#### 🧪 品質保證革新
用 AI 強化測試自動化：
- **智慧測試生成**：自動產生完整測試套件
- **視覺回歸測試**：AI 驅動的 UI 變更偵測
- **效能監控**：主動偵測與解決問題

#### 📊 資料管線智慧化
打造更聰明的資料處理流程：
- **自適應 ETL 流程**：自我優化資料轉換
- **異常偵測**：即時資料品質監控
- **智慧路由**：智能資料流管理

#### 🎧 客戶體驗提升
創造卓越的客戶互動：
- **情境感知支援**：AI 代理可存取客戶歷史
- **主動問題解決**：預測性客服服務
- **多通路整合**：跨平台統一 AI 體驗

## 🛠️ 先決條件與設定

### 💻 系統需求

| 元件 | 需求 | 備註 |
|-----------|-------------|-------|
| **作業系統** | Windows 10+、macOS 10.15+、Linux | 任何現代作業系統 |
| **Visual Studio Code** | 最新穩定版 | AITK 必備 |
| **Node.js** | v18.0+ 與 npm | 用於 MCP 伺服器開發 |
| **Python** | 3.10+ | Python MCP 伺服器選用 |
| **記憶體** | 最少 8GB RAM | 本地模型建議 16GB |

### 🔧 開發環境

#### 推薦 VS Code 擴充套件
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) - 選用但很有幫助

#### 選用工具
- **uv**：現代 Python 套件管理器
- **MCP Inspector**：MCP 伺服器視覺化除錯工具
- **Playwright**：網頁自動化範例工具

## 🎖️ 學習成果與認證路徑

### 🏆 技能掌握清單

完成此工作坊，你將達成：

#### 🎯 核心能力
- [ ] **MCP 協定精通**：深入理解架構與實作模式
- [ ] **AITK 熟練度**：AI Toolkit 專家級應用
- [ ] **客製伺服器開發**：建置、部署與維護生產 MCP 伺服器
- [ ] **工具整合優勢**：無縫連接 AI 與現有開發流程
- [ ] **問題解決應用**：將技能應用於實際商業挑戰

#### 🔧 技術技能
- [ ] 設定並配置 VS Code 中的 AI Toolkit
- [ ] 設計並實作客製 MCP 伺服器
- [ ] 整合 GitHub 模型與 MCP 架構
- [ ] 建立 Playwright 自動化測試流程
- [ ] 部署 AI 代理至生產環境
- [ ] 除錯與優化 MCP 伺服器效能

#### 🚀 進階能力
- [ ] 架構企業級 AI 整合方案
- [ ] 實施 AI 應用安全最佳實踐
- [ ] 設計可擴充的 MCP 伺服器架構
- [ ] 創建特定領域的客製工具鏈
- [ ] 指導他人進行 AI 原生開發

## 📖 其他資源
- [MCP Specification](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit)
- [Sample MCP Servers Collection](https://github.com/modelcontextprotocol/servers)
- [Best Practices Guide](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 準備好革新你的 AI 開發流程了嗎？**

讓我們與 MCP 和 AI Toolkit 一起打造智慧應用的未來！

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們對於因使用本翻譯而產生的任何誤解或誤釋不負任何責任。