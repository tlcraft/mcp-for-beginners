<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f83bc722dc758efffd68667d6a1db470",
  "translation_date": "2025-06-10T06:43:33+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/README.md",
  "language_code": "tw"
}
-->
# 🐙 Module 4: 實戰 MCP 開發 - 自訂 GitHub 複製伺服器

![Duration](https://img.shields.io/badge/Duration-30_minutes-blue?style=flat-square)
![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-orange?style=flat-square)
![MCP](https://img.shields.io/badge/MCP-Custom%20Server-purple?style=flat-square&logo=github)
![VS Code](https://img.shields.io/badge/VS%20Code-Integration-blue?style=flat-square&logo=visualstudiocode)
![GitHub Copilot](https://img.shields.io/badge/GitHub%20Copilot-Agent%20Mode-green?style=flat-square&logo=github)

> **⚡ 快速上手：** 在 30 分鐘內打造可投入生產的 MCP 伺服器，自動化 GitHub 倉庫複製並整合 VS Code！

## 🎯 學習目標

完成本實作後，你將能夠：

- ✅ 建立符合實務開發流程的自訂 MCP 伺服器
- ✅ 實作透過 MCP 進行 GitHub 倉庫複製的功能
- ✅ 將自訂 MCP 伺服器與 VS Code 及 Agent Builder 整合
- ✅ 使用 GitHub Copilot Agent Mode 搭配自訂 MCP 工具
- ✅ 在生產環境中測試並部署自訂 MCP 伺服器

## 📋 先備條件

- 完成 Labs 1-3（MCP 基礎與進階開發）
- GitHub Copilot 訂閱（[免費註冊](https://github.com/github-copilot/signup)）
- 安裝並啟用 VS Code 的 AI Toolkit 與 GitHub Copilot 擴充功能
- 安裝並設定 Git CLI

## 🏗️ 專案概覽

### **真實開發挑戰**
身為開發者，我們經常需要從 GitHub 複製倉庫並在 VS Code 或 VS Code Insiders 中開啟。這個手動流程通常包含：
1. 開啟終端機/命令提示字元
2. 切換到目標資料夾
3. 執行 `git clone` 指令
4. 在複製後的資料夾中開啟 VS Code

**我們的 MCP 解決方案將這一連串步驟簡化成一條智慧指令！**

### **你將打造的東西**
一個 **GitHub Clone MCP Server** (`git_mcp_server`)，提供：

| 功能 | 說明 | 好處 |
|---------|-------------|---------|
| 🔄 **智慧倉庫複製** | 複製 GitHub 倉庫並驗證 | 自動錯誤檢查 |
| 📁 **智慧目錄管理** | 安全檢查並建立目錄 | 避免覆寫 |
| 🚀 **跨平台 VS Code 整合** | 在 VS Code/Insiders 開啟專案 | 流程無縫銜接 |
| 🛡️ **強健錯誤處理** | 處理網路、權限與路徑問題 | 生產環境級穩定性 |

---

## 📖 逐步實作

### 步驟 1：在 Agent Builder 建立 GitHub Agent

1. 透過 AI Toolkit 擴充功能啟動 Agent Builder
2. 建立新 agent，並設定以下配置：
   ```
   Agent Name: GitHubAgent
   ```

3. 初始化自訂 MCP 伺服器：
   - 前往 **工具** → **新增工具** → **MCP 伺服器**
   - 選擇 **"建立新的 MCP 伺服器"**
   - 選擇 **Python 範本** 以獲得最大彈性
   - **伺服器名稱：** `git_mcp_server`

### 步驟 2：設定 GitHub Copilot Agent Mode

1. 在 VS Code 中開啟 GitHub Copilot（Ctrl/Cmd + Shift + P → "GitHub Copilot: Open"）
2. 在 Copilot 介面選擇 Agent 模型
3. 選擇 Claude 3.7 模型以提升推理能力
4. 啟用 MCP 整合以存取工具

> **💡 專家提示：** Claude 3.7 對開發流程與錯誤處理模式有更優異的理解能力。

### 步驟 3：實作 MCP 伺服器核心功能

**使用以下詳細提示搭配 GitHub Copilot Agent Mode：**

```
Create two MCP tools with the following comprehensive requirements:

🔧 TOOL A: clone_repository
Requirements:
- Clone any GitHub repository to a specified local folder
- Return the absolute path of the successfully cloned project
- Implement comprehensive validation:
  ✓ Check if target directory already exists (return error if exists)
  ✓ Validate GitHub URL format (https://github.com/user/repo)
  ✓ Verify git command availability (prompt installation if missing)
  ✓ Handle network connectivity issues
  ✓ Provide clear error messages for all failure scenarios

🚀 TOOL B: open_in_vscode
Requirements:
- Open specified folder in VS Code or VS Code Insiders
- Cross-platform compatibility (Windows/Linux/macOS)
- Use direct application launch (not terminal commands)
- Auto-detect available VS Code installations
- Handle cases where VS Code is not installed
- Provide user-friendly error messages

Additional Requirements:
- Follow MCP 1.9.3 best practices
- Include proper type hints and documentation
- Implement logging for debugging purposes
- Add input validation for all parameters
- Include comprehensive error handling
```

### 步驟 4：測試你的 MCP 伺服器

#### 4a. 在 Agent Builder 測試

1. 啟動 Agent Builder 的除錯設定
2. 使用以下系統提示設定你的 agent：

```
SYSTEM_PROMPT:
You are my intelligent coding repository assistant. You help developers efficiently clone GitHub repositories and set up their development environment. Always provide clear feedback about operations and handle errors gracefully.
```

3. 使用真實使用情境進行測試：

```
USER_PROMPT EXAMPLES:

Scenario : Basic Clone and Open
"Clone {Your GitHub Repo link such as https://github.com/kinfey/GHCAgentWorkshop
 } and save to {The global path you specify}, then open it with VS Code Insiders"
```

![Agent Builder Testing](../../../../translated_images/DebugAgent.81d152370c503241b3b39a251b8966f7f739286df19dd57f9147f6402214a012.tw.png)

**預期結果：**
- ✅ 成功複製並確認路徑
- ✅ 自動啟動 VS Code
- ✅ 對無效狀況顯示清楚錯誤訊息
- ✅ 正確處理邊界案例

#### 4b. 在 MCP Inspector 測試


![MCP Inspector Testing](../../../../translated_images/DebugInspector.eb5c95f94c69a8ba36944941b9a3588309a3a2fae101ace470ee09bde41d1667.tw.png)

---



**🎉 恭喜！** 你已成功打造出實用且可投入生產的 MCP 伺服器，解決了真實開發流程中的挑戰。你的自訂 GitHub 複製伺服器展現了 MCP 在自動化及提升開發效率上的強大能力。

### 🏆 成就解鎖：
- ✅ **MCP 開發者** - 建立自訂 MCP 伺服器
- ✅ **流程自動化達人** - 精簡開發流程  
- ✅ **整合專家** - 串接多種開發工具
- ✅ **生產準備** - 打造可部署解決方案

---

## 🎓 工作坊結業：你的 Model Context Protocol 旅程

**親愛的工作坊參與者，**

恭喜你完成 Model Context Protocol 工作坊的四個模組！你已從理解 AI Toolkit 基礎概念，邁向打造可投入生產的 MCP 伺服器，成功解決真實開發挑戰。

### 🚀 你的學習歷程回顧：

**[Module 1](../lab1/README.md)**：你從 AI Toolkit 基礎、模型測試及建立第一個 AI agent 開始。

**[Module 2](../lab2/README.md)**：你學會 MCP 架構、整合 Playwright MCP，並打造第一個瀏覽器自動化 agent。

**[Module 3](../lab3/README.md)**：你進階至自訂 MCP 伺服器開發，打造 Weather MCP server，並精通除錯工具。

**[Module 4](../lab4/README.md)**：你將所有知識運用於打造實用的 GitHub 倉庫工作流程自動化工具。

### 🌟 你已掌握：

- ✅ **AI Toolkit 生態系**：模型、agent 與整合模式
- ✅ **MCP 架構**：客戶端-伺服器設計、傳輸協定與安全性
- ✅ **開發工具**：從 Playground 到 Inspector 再到生產部署
- ✅ **自訂開發**：建立、測試與部署專屬 MCP 伺服器
- ✅ **實務應用**：以 AI 解決真實開發流程挑戰

### 🔮 下一步建議：

1. **打造自己的 MCP 伺服器**：運用所學自動化你的專屬流程
2. **加入 MCP 社群**：分享創作並向他人學習
3. **探索進階整合**：將 MCP 伺服器串接企業系統
4. **貢獻開源專案**：協助提升 MCP 工具與文件品質

請記得，這只是開始。Model Context Protocol 生態系持續快速演進，你已具備領先 AI 助力開發工具的能力。

**感謝你的參與與學習熱忱！**

希望這次工作坊能激發你的靈感，改變你與 AI 工具互動及開發的方式。

**祝你編碼愉快！**

---

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議使用專業人工翻譯。我們不對因使用本翻譯而產生之任何誤解或誤譯負責。