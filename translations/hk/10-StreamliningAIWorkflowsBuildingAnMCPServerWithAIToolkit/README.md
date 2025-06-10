<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-06-10T04:49:59+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "hk"
}
-->
# Streamlining AI Workflows: Building an MCP Server with AI Toolkit

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)  
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)  
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.hk.png)

## 🎯 Overview

歡迎參加 **Model Context Protocol (MCP) 工作坊**！呢個全面嘅實戰工作坊結合咗兩個最前沿嘅技術，徹底改變 AI 應用開發方式：

- **🔗 Model Context Protocol (MCP)**：一個無縫連接 AI 工具嘅開放標準  
- **🛠️ AI Toolkit for Visual Studio Code (AITK)**：微軟強大嘅 AI 開發擴充套件

### 🎓 你將學到啲乜

完成工作坊後，你會掌握點樣打造智能應用，將 AI 模型同現實工具同服務連結。由自動化測試到自訂 API 整合，你會學識實用技能解決複雜商業問題。

## 🏗️ 技術棧

### 🔌 Model Context Protocol (MCP)

MCP 就係 AI 嘅「USB-C」，一個通用標準，用嚟連接 AI 模型同外部工具同數據來源。

**✨ 主要特色：**  
- 🔄 **標準化整合**：AI 工具連接嘅通用介面  
- 🏛️ **靈活架構**：支援本地及遠端伺服器，透過 stdio/SSE 傳輸  
- 🧰 **豐富生態系統**：工具、提示詞同資源集合於一個協議  
- 🔒 **企業級安全**：內建安全同穩定性保障

**🎯 MCP 嘅重要性：**  
好似 USB-C 解決咗纜線混亂，MCP 解決咗 AI 整合嘅複雜性。只用一個協議，無限可能。

### 🤖 AI Toolkit for Visual Studio Code (AITK)

微軟旗艦嘅 AI 開發擴充，將 VS Code 變成 AI 強大平台。

**🚀 核心功能：**  
- 📦 **模型目錄**：存取 Azure AI、GitHub、Hugging Face、Ollama 嘅模型  
- ⚡ **本地推理**：ONNX 優化嘅 CPU/GPU/NPU 執行  
- 🏗️ **代理人建構器**：視覺化 AI 代理開發，支援 MCP 整合  
- 🎭 **多模態支援**：文字、影像同結構化輸出

**💡 開發優勢：**  
- 零設定模型部署  
- 視覺化提示詞設計  
- 即時測試環境  
- 無縫 MCP 伺服器整合

## 📚 學習旅程

### [🚀 Module 1: AI Toolkit Fundamentals](./lab1/README.md)  
**時長**：15 分鐘  
- 🛠️ 安裝同設定 AI Toolkit for VS Code  
- 🗂️ 探索模型目錄（來自 GitHub、ONNX、OpenAI、Anthropic、Google 超過 100 個模型）  
- 🎮 精通互動測試平台，實時測試模型  
- 🤖 用代理人建構器建立你第一個 AI 代理  
- 📊 用內建指標評估模型表現（F1、相關度、相似度、一致性）  
- ⚡ 學習批次處理同多模態支援

**🎯 學習成果**：建立一個功能完善嘅 AI 代理，全面了解 AITK 功能

### [🌐 Module 2: MCP with AI Toolkit Fundamentals](./lab2/README.md)  
**時長**：20 分鐘  
- 🧠 掌握 Model Context Protocol (MCP) 架構同概念  
- 🌐 探索微軟 MCP 伺服器生態系  
- 🤖 用 Playwright MCP 伺服器建立瀏覽器自動化代理  
- 🔧 將 MCP 伺服器整合到 AI Toolkit 代理人建構器  
- 📊 配置同測試代理人內嘅 MCP 工具  
- 🚀 匯出並部署 MCP 支援嘅代理人到生產環境

**🎯 學習成果**：部署一個用外部工具強化嘅 AI 代理

### [🔧 Module 3: Advanced MCP Development with AI Toolkit](./lab3/README.md)  
**時長**：20 分鐘  
- 💻 用 AI Toolkit 自行創建 MCP 伺服器  
- 🐍 配置同使用最新 MCP Python SDK (v1.9.3)  
- 🔍 設置同使用 MCP Inspector 進行除錯  
- 🛠️ 建立專業除錯流程嘅天氣 MCP 伺服器  
- 🧪 於代理人建構器同 Inspector 環境中除錯 MCP 伺服器

**🎯 學習成果**：用現代工具開發同除錯自訂 MCP 伺服器

### [🐙 Module 4: Practical MCP Development - Custom GitHub Clone Server](./lab4/README.md)  
**時長**：30 分鐘  
- 🏗️ 建立一個真實世界嘅 GitHub Clone MCP 伺服器，支援開發工作流程  
- 🔄 實作智能倉庫複製，含驗證同錯誤處理  
- 📁 創建智能目錄管理同 VS Code 整合  
- 🤖 用 GitHub Copilot 代理模式搭配自訂 MCP 工具  
- 🛡️ 應用生產級穩定性同跨平台兼容性

**🎯 學習成果**：部署一個生產就緒嘅 MCP 伺服器，優化真實開發流程

## 💡 真實應用同影響

### 🏢 企業使用案例

#### 🔄 DevOps 自動化  
用智能自動化改造開發流程：  
- **智能倉庫管理**：AI 驅動嘅代碼審查同合併決策  
- **智能 CI/CD**：根據代碼變更自動優化管道  
- **問題分類**：自動化錯誤分類同分派

#### 🧪 品質保證革命  
用 AI 自動化提升測試質素：  
- **智能測試生成**：自動創建全面嘅測試套件  
- **視覺回歸測試**：AI 驅動嘅 UI 變更檢測  
- **性能監控**：主動識別同解決問題

#### 📊 數據流程智能化  
建立更智能嘅數據處理流程：  
- **自適應 ETL 流程**：自我優化數據轉換  
- **異常偵測**：實時數據質量監控  
- **智能路由**：智慧數據流管理

#### 🎧 客戶體驗提升  
創造卓越嘅客戶互動：  
- **上下文感知支援**：AI 代理可訪問客戶歷史  
- **主動問題解決**：預測式客戶服務  
- **多渠道整合**：跨平台統一 AI 體驗

## 🛠️ 前置條件同設定

### 💻 系統需求

| 組件 | 要求 | 備註 |
|------|------|------|
| **作業系統** | Windows 10+、macOS 10.15+、Linux | 任何現代操作系統 |
| **Visual Studio Code** | 最新穩定版 | AITK 必需 |
| **Node.js** | v18.0+ 同 npm | 用於 MCP 伺服器開發 |
| **Python** | 3.10+ | Python MCP 伺服器可選 |
| **記憶體** | 最少 8GB RAM | 本地模型建議 16GB |

### 🔧 開發環境

#### 推薦 VS Code 擴充套件  
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)  
- **Python** (ms-python.python)  
- **Python Debugger** (ms-python.debugpy)  
- **GitHub Copilot** (GitHub.copilot) - 可選但有幫助

#### 可選工具  
- **uv**：現代 Python 套件管理器  
- **MCP Inspector**：MCP 伺服器視覺化除錯工具  
- **Playwright**：用於網頁自動化範例

## 🎖️ 學習成果同認證路徑

### 🏆 技能掌握清單

完成工作坊後，你會精通：

#### 🎯 核心能力  
- [ ] **MCP 協議掌握**：深入理解架構同實作模式  
- [ ] **AITK 熟練度**：專家級使用 AI Toolkit 快速開發  
- [ ] **自訂伺服器開發**：構建、部署同維護生產 MCP 伺服器  
- [ ] **工具整合優秀**：無縫連接 AI 同現有開發流程  
- [ ] **問題解決應用**：將所學技能應用於實際商業挑戰

#### 🔧 技術技能  
- [ ] 設置同配置 VS Code 內嘅 AI Toolkit  
- [ ] 設計同實作自訂 MCP 伺服器  
- [ ] 將 GitHub 模型整合入 MCP 架構  
- [ ] 建立 Playwright 自動化測試流程  
- [ ] 部署生產用 AI 代理人  
- [ ] 除錯同優化 MCP 伺服器效能

#### 🚀 進階能力  
- [ ] 架構企業級 AI 整合方案  
- [ ] 實施 AI 應用嘅安全最佳實踐  
- [ ] 設計可擴展嘅 MCP 伺服器架構  
- [ ] 創建針對特定領域嘅自訂工具鏈  
- [ ] 指導他人進行 AI 原生開發

## 📖 額外資源
- [MCP Specification](https://modelcontextprotocol.io/docs)  
- [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit)  
- [Sample MCP Servers Collection](https://github.com/modelcontextprotocol/servers)  
- [Best Practices Guide](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 準備好徹底革新你嘅 AI 開發流程未？**

一齊用 MCP 同 AI Toolkit 打造智能應用嘅未來！

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我哋致力確保準確性，但請注意，自動翻譯可能會包含錯誤或不準確之處。原始文件嘅母語版本應被視為權威來源。對於重要資料，建議使用專業人工翻譯。我哋對因使用本翻譯而引致嘅任何誤解或誤釋概不負責。