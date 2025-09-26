<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "719117a0a5f34ade7b5dfb61ee06fb13",
  "translation_date": "2025-09-26T19:11:05+00:00",
  "source_file": "study_guide.md",
  "language_code": "sr"
}
-->
# Водич за почетнике - Протокол контекста модела (MCP)

Овај водич пружа преглед структуре и садржаја репозиторијума за наставни план "Протокол контекста модела (MCP) за почетнике". Користите овај водич да бисте ефикасно прегледали репозиторијум и искористили доступне ресурсе.

## Преглед репозиторијума

Протокол контекста модела (MCP) је стандардизован оквир за интеракцију између AI модела и клијентских апликација. Првобитно креиран од стране Anthropic-а, MCP сада одржава шира MCP заједница преко званичне GitHub организације. Овај репозиторијум пружа свеобухватан наставни план са практичним примерима кода у C#, Java, JavaScript, Python и TypeScript, намењен AI програмерима, системским архитектама и софтверским инжењерима.

## Визуелна мапа наставног плана

```mermaid
mindmap
  root((MCP for Beginners))
    00. Introduction
      ::icon(fa fa-book)
      (Protocol Overview)
      (Standardization Benefits)
      (Real-world Use Cases)
      (AI Integration Fundamentals)
    01. Core Concepts
      ::icon(fa fa-puzzle-piece)
      (Client-Server Architecture)
      (Protocol Components)
      (Messaging Patterns)
      (Transport Mechanisms)
    02. Security
      ::icon(fa fa-shield)
      (AI-Specific Threats)
      (Best Practices 2025)
      (Azure Content Safety)
      (Auth & Authorization)
      (Microsoft Prompt Shields)
    03. Getting Started
      ::icon(fa fa-rocket)
      (First Server Implementation)
      (Client Development)
      (LLM Client Integration)
      (VS Code Extensions)
      (SSE Server Setup)
      (HTTP Streaming)
      (AI Toolkit Integration)
      (Testing Frameworks)
      (Deployment Strategies)
    04. Practical Implementation
      ::icon(fa fa-code)
      (Multi-Language SDKs)
      (Testing & Debugging)
      (Prompt Templates)
      (Sample Projects)
      (Production Patterns)
    05. Advanced Topics
      ::icon(fa fa-graduation-cap)
      (Context Engineering)
      (Foundry Agent Integration)
      (Multi-modal AI Workflows)
      (OAuth2 Authentication)
      (Real-time Search)
      (Streaming Protocols)
      (Root Contexts)
      (Routing Strategies)
      (Sampling Techniques)
      (Scaling Solutions)
      (Security Hardening)
      (Entra ID Integration)
      (Web Search MCP)
      
    06. Community
      ::icon(fa fa-users)
      (Code Contributions)
      (Documentation)
      (MCP Client Ecosystem)
      (MCP Server Registry)
      (Image Generation Tools)
      (GitHub Collaboration)
    07. Early Adoption
      ::icon(fa fa-lightbulb)
      (Production Deployments)
      (Microsoft MCP Servers)
      (Azure MCP Service)
      (Enterprise Case Studies)
      (Future Roadmap)
    08. Best Practices
      ::icon(fa fa-check)
      (Performance Optimization)
      (Fault Tolerance)
      (System Resilience)
      (Monitoring & Observability)
    09. Case Studies
      ::icon(fa fa-file-text)
      (Azure API Management)
      (AI Travel Agent)
      (Azure DevOps Integration)
      (Documentation MCP)
      (GitHub MCP Registry)
      (VS Code Integration)
      (Real-world Implementations)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (MCP Server Fundamentals)
      (Advanced Development)
      (AI Toolkit Integration)
      (Production Deployment)
      (4-Lab Structure)
```

## Структура репозиторијума

Репозиторијум је организован у десет главних секција, од којих свака покрива различите аспекте MCP-а:

1. **Увод (00-Introduction/)**
   - Преглед Протокола контекста модела
   - Зашто је стандардизација важна у AI процесима
   - Практични примери употребе и предности

2. **Основни концепти (01-CoreConcepts/)**
   - Клијент-сервер архитектура
   - Кључне компоненте протокола
   - Шаблони за размену порука у MCP-у

3. **Безбедност (02-Security/)**
   - Претње безбедности у системима заснованим на MCP-у
   - Најбоље праксе за обезбеђивање имплементација
   - Стратегије аутентификације и ауторизације
   - **Свеобухватна документација о безбедности**:
     - MCP Најбоље праксе за безбедност 2025
     - Водич за имплементацију Azure Content Safety
     - Контроле и технике MCP безбедности
     - Брзи референтни водич за MCP безбедност
   - **Кључне теме безбедности**:
     - Напади убризгавањем упита и тровање алатима
     - Отимање сесије и проблеми са конфузним заступником
     - Рупе у безбедности токена
     - Прекомерне дозволе и контроле приступа
     - Безбедност ланца снабдевања за AI компоненте
     - Интеграција Microsoft Prompt Shields-а

4. **Почетак рада (03-GettingStarted/)**
   - Подешавање и конфигурација окружења
   - Креирање основних MCP сервера и клијената
   - Интеграција са постојећим апликацијама
   - Укључује секције за:
     - Прву имплементацију сервера
     - Развој клијента
     - Интеграцију LLM клијента
     - Интеграцију са VS Code-ом
     - SSE сервер
     - HTTP стриминг
     - Интеграцију AI алатки
     - Стратегије тестирања
     - Водич за распоређивање

5. **Практична имплементација (04-PracticalImplementation/)**
   - Коришћење SDK-ова у различитим програмским језицима
   - Технике дебаговања, тестирања и валидације
   - Креирање поновљивих шаблона упита и радних токова
   - Пример пројекти са имплементацијама

6. **Напредне теме (05-AdvancedTopics/)**
   - Технике инжењеринга контекста
   - Интеграција Foundry агента
   - Мултимодални AI радни токови
   - Демонстрације аутентификације преко OAuth2
   - Могућности претраге у реалном времену
   - Стриминг у реалном времену
   - Имплементација коренских контекста
   - Стратегије рутирања
   - Технике узорковања
   - Приступи скалирању
   - Разматрања безбедности
   - Интеграција Entra ID безбедности
   - Интеграција веб претраге

7. **Доприноси заједнице (06-CommunityContributions/)**
   - Како допринети коду и документацији
   - Сарадња преко GitHub-а
   - Побољшања и повратне информације вођене заједницом
   - Коришћење различитих MCP клијената (Claude Desktop, Cline, VSCode)
   - Рад са популарним MCP серверима укључујући генерисање слика

8. **Лекције из ране примене (07-LessonsfromEarlyAdoption/)**
   - Примери из стварног света и успешне приче
   - Изградња и распоређивање решења заснованих на MCP-у
   - Трендови и будућа мапа пута
   - **Водич за Microsoft MCP сервере**: Свеобухватан водич за 10 производних Microsoft MCP сервера, укључујући:
     - Microsoft Learn Docs MCP сервер
     - Azure MCP сервер (15+ специјализованих конектора)
     - GitHub MCP сервер
     - Azure DevOps MCP сервер
     - MarkItDown MCP сервер
     - SQL Server MCP сервер
     - Playwright MCP сервер
     - Dev Box MCP сервер
     - Azure AI Foundry MCP сервер
     - Microsoft 365 Agents Toolkit MCP сервер

9. **Најбоље праксе (08-BestPractices/)**
   - Подешавање перформанси и оптимизација
   - Дизајнирање отпорних MCP система
   - Стратегије тестирања и отпорности

10. **Студије случаја (09-CaseStudy/)**
    - **Седам свеобухватних студија случаја** које демонстрирају свестраност MCP-а у различитим сценаријима:
    - **Azure AI Travel Agents**: Оркестрација више агената са Azure OpenAI и AI Search
    - **Интеграција Azure DevOps-а**: Аутоматизација радних процеса са ажурирањима података са YouTube-а
    - **Претраживање документације у реалном времену**: Python конзолни клијент са HTTP стримингом
    - **Интерактивни генератор плана учења**: Chainlit веб апликација са конверзацијским AI-јем
    - **Документација у уређивачу**: Интеграција VS Code-а са GitHub Copilot радним токовима
    - **Azure API Management**: Интеграција предузетничких API-ја са креирањем MCP сервера
    - **GitHub MCP Registry**: Развој екосистема и платформа за интеграцију агената
    - Примери имплементације који обухватају предузетничку интеграцију, продуктивност програмера и развој екосистема

11. **Практична радионица (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - Свеобухватна практична радионица која комбинује MCP са AI алаткама
    - Изградња интелигентних апликација које повезују AI моделе са стварним алатима
    - Практични модули који покривају основе, развој прилагођених сервера и стратегије распоређивања у производњи
    - **Структура лабораторије**:
      - Лабораторија 1: Основе MCP сервера
      - Лабораторија 2: Напредни развој MCP сервера
      - Лабораторија 3: Интеграција AI алатки
      - Лабораторија 4: Распоређивање у производњи и скалирање
    - Приступ учењу заснован на лабораторијама са упутствима корак по корак

## Додатни ресурси

Репозиторијум укључује подржавајуће ресурсе:

- **Фолдер са сликама**: Садржи дијаграме и илустрације коришћене кроз наставни план
- **Преводи**: Подршка за више језика са аутоматизованим преводима документације
- **Званични MCP ресурси**:
  - [MCP документација](https://modelcontextprotocol.io/)
  - [MCP спецификација](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub репозиторијум](https://github.com/modelcontextprotocol)

## Како користити овај репозиторијум

1. **Секвенцијално учење**: Пратите поглавља редом (00 до 10) за структурирано учење.
2. **Фокус на одређени језик**: Ако вас интересује одређени програмски језик, истражите директоријуме са примерима имплементације у вашем омиљеном језику.
3. **Практична имплементација**: Почните са секцијом "Почетак рада" да подесите своје окружење и креирате свој први MCP сервер и клијент.
4. **Напредно истраживање**: Када савладате основе, истражите напредне теме да проширите своје знање.
5. **Ангажовање у заједници**: Придружите се MCP заједници преко GitHub дискусија и Discord канала да се повежете са стручњацима и другим програмерима.

## MCP клијенти и алатке

Наставни план покрива различите MCP клијенте и алатке:

1. **Званични клијенти**:
   - Visual Studio Code 
   - MCP у Visual Studio Code-у
   - Claude Desktop
   - Claude у VSCode-у 
   - Claude API

2. **Клијенти заједнице**:
   - Cline (заснован на терминалу)
   - Cursor (уређивач кода)
   - ChatMCP
   - Windsurf

3. **Алатке за управљање MCP-ом**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## Популарни MCP сервери

Репозиторијум представља различите MCP сервере, укључујући:

1. **Званични Microsoft MCP сервери**:
   - Microsoft Learn Docs MCP сервер
   - Azure MCP сервер (15+ специјализованих конектора)
   - GitHub MCP сервер
   - Azure DevOps MCP сервер
   - MarkItDown MCP сервер
   - SQL Server MCP сервер
   - Playwright MCP сервер
   - Dev Box MCP сервер
   - Azure AI Foundry MCP сервер
   - Microsoft 365 Agents Toolkit MCP сервер

2. **Званични референтни сервери**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

3. **Генерисање слика**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

4. **Алатке за развој**:
   - Git MCP
   - Terminal Control
   - Code Assistant

5. **Специјализовани сервери**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## Доприноси

Овај репозиторијум поздравља доприносе заједнице. Погледајте секцију Доприноси заједнице за упутства о томе како ефикасно допринети MCP екосистему.

## Промене

| Датум | Промене |
|------|---------|
| 26. септембар 2025 | - Додата студија случаја GitHub MCP Registry у секцију 09-CaseStudy<br>- Ажуриране студије случаја да одражавају седам свеобухватних студија<br>- Побољшани описи студија случаја са специфичним детаљима имплементације<br>- Ажурирана Визуелна мапа наставног плана да укључи GitHub MCP Registry<br>- Ревидирана структура водича за учење да одражава фокус на развој екосистема |
| 18. јул 2025 | - Ажурирана структура репозиторијума да укључи Водич за Microsoft MCP сервере<br>- Додата свеобухватна листа од 10 производних Microsoft MCP сервера<br>- Побољшана секција Популарни MCP сервери са званичним Microsoft MCP серверима<br>- Ажурирана секција Студије случаја са стварним примерима датотека<br>- Додати детаљи структуре лабораторије за Практичну радионицу |
| 16. јул 2025 | - Ажурирана структура репозиторијума да одражава тренутни садржај<br>- Додата секција MCP клијенти и алатке<br>- Додата секција Популарни MCP сервери<br>- Ажурирана Визуелна мапа наставног плана са свим тренутним темама<br>- Побољшана секција Напредне теме са свим специјализованим областима<br>- Ажуриране студије случаја да одражавају стварне примере<br>- Разјашњено порекло MCP-а као креирано од стране Anthropic-а |
| 11. јун 2025 | - Почетно креирање водича за учење<br>- Додата Визуелна мапа наставног плана<br>- Описана структура репозиторијума<br>- Укључени пример пројекти и додатни ресурси |

---

*Овај водич за учење је ажуриран 26. септембра 2025. и пружа преглед репозиторијума закључно са тим датумом. Садржај репозиторијума може бити ажуриран након овог датума.*

---

