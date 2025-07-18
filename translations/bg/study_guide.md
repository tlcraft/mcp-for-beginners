<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e2c6ed897fa98fa08e0146101776c7ff",
  "translation_date": "2025-07-18T10:25:17+00:00",
  "source_file": "study_guide.md",
  "language_code": "bg"
}
-->
# Model Context Protocol (MCP) за начинаещи - Учебно ръководство

Това учебно ръководство предоставя преглед на структурата и съдържанието на хранилището за учебната програма "Model Context Protocol (MCP) за начинаещи". Използвайте това ръководство, за да навигирате ефективно в хранилището и да извлечете максимума от наличните ресурси.

## Преглед на хранилището

Model Context Protocol (MCP) е стандартизиран фреймуърк за взаимодействия между AI модели и клиентски приложения. Първоначално създаден от Anthropic, MCP сега се поддържа от по-широката MCP общност чрез официалната GitHub организация. Това хранилище предлага изчерпателна учебна програма с практически примери на код на C#, Java, JavaScript, Python и TypeScript, предназначена за AI разработчици, системни архитекти и софтуерни инженери.

## Визуална карта на учебната програма

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
      (Real-world Implementations)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (MCP Server Fundamentals)
      (Advanced Development)
      (AI Toolkit Integration)
      (Production Deployment)
      (4-Lab Structure)
```

## Структура на хранилището

Хранилището е организирано в десет основни раздела, всеки от които се фокусира върху различни аспекти на MCP:

1. **Въведение (00-Introduction/)**
   - Преглед на Model Context Protocol
   - Защо стандартизацията е важна в AI процесите
   - Практически случаи на употреба и ползи

2. **Основни концепции (01-CoreConcepts/)**
   - Клиент-сървър архитектура
   - Ключови компоненти на протокола
   - Модели на съобщения в MCP

3. **Сигурност (02-Security/)**
   - Заплахи за сигурността в системи, базирани на MCP
   - Най-добри практики за защита на имплементациите
   - Стратегии за автентикация и авторизация
   - **Изчерпателна документация за сигурността**:
     - MCP Security Best Practices 2025
     - Azure Content Safety Implementation Guide
     - MCP Security Controls and Techniques
     - MCP Best Practices Quick Reference
   - **Ключови теми за сигурността**:
     - Атаки чрез prompt injection и отравяне на инструменти
     - Кражба на сесии и проблеми с confused deputy
     - Уязвимости при token passthrough
     - Прекомерни права и контрол на достъпа
     - Сигурност на веригата за доставки за AI компоненти
     - Интеграция с Microsoft Prompt Shields

4. **Първи стъпки (03-GettingStarted/)**
   - Настройка и конфигурация на средата
   - Създаване на базови MCP сървъри и клиенти
   - Интеграция с вече съществуващи приложения
   - Включва секции за:
     - Първа имплементация на сървър
     - Разработка на клиент
     - Интеграция на LLM клиент
     - Интеграция с VS Code
     - SSE (Server-Sent Events) сървър
     - HTTP стрийминг
     - Интеграция с AI Toolkit
     - Тестови стратегии
     - Насоки за разгръщане

5. **Практическа имплементация (04-PracticalImplementation/)**
   - Използване на SDK-та на различни програмни езици
   - Отстраняване на грешки, тестване и валидация
   - Създаване на многократно използваеми шаблони за prompt-и и работни потоци
   - Примерни проекти с демонстрации на имплементации

6. **Разширени теми (05-AdvancedTopics/)**
   - Техники за инженеринг на контекста
   - Интеграция с Foundry агент
   - Мултимодални AI работни потоци
   - Демонстрации на OAuth2 автентикация
   - Възможности за търсене в реално време
   - Стрийминг в реално време
   - Имплементация на root контексти
   - Стратегии за маршрутизиране
   - Техники за семплиране
   - Подходи за мащабиране
   - Сигурност и съображения
   - Интеграция със сигурността на Entra ID
   - Интеграция на уеб търсене

7. **Приноси от общността (06-CommunityContributions/)**
   - Как да допринасяте с код и документация
   - Сътрудничество чрез GitHub
   - Подобрения и обратна връзка, водени от общността
   - Използване на различни MCP клиенти (Claude Desktop, Cline, VSCode)
   - Работа с популярни MCP сървъри, включително за генериране на изображения

8. **Уроци от ранното приемане (07-LessonsfromEarlyAdoption/)**
   - Реални имплементации и успешни истории
   - Създаване и разгръщане на решения, базирани на MCP
   - Тенденции и бъдеща пътна карта
   - **Ръководство за Microsoft MCP сървъри**: Изчерпателно ръководство за 10 производствени Microsoft MCP сървъра, включително:
     - Microsoft Learn Docs MCP Server
     - Azure MCP Server (над 15 специализирани конектора)
     - GitHub MCP Server
     - Azure DevOps MCP Server
     - MarkItDown MCP Server
     - SQL Server MCP Server
     - Playwright MCP Server
     - Dev Box MCP Server
     - Azure AI Foundry MCP Server
     - Microsoft 365 Agents Toolkit MCP Server

9. **Най-добри практики (08-BestPractices/)**
   - Оптимизация и настройка на производителността
   - Проектиране на устойчиви на грешки MCP системи
   - Стратегии за тестване и устойчивост

10. **Казуси (09-CaseStudy/)**
    - Пример за интеграция с Azure API Management
    - Пример за имплементация на туристически агент
    - Интеграция на Azure DevOps с ъпдейти от YouTube
    - Примери за имплементация на MCP документация
    - Имплементационни примери с подробна документация

11. **Практически уъркшоп (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - Изчерпателен практически уъркшоп, комбиниращ MCP с AI Toolkit
    - Създаване на интелигентни приложения, свързващи AI модели с реални инструменти
    - Практически модули, обхващащи основи, разработка на персонализиран сървър и стратегии за продукционно разгръщане
    - **Структура на лабораториите**:
      - Лаборатория 1: Основи на MCP сървъра
      - Лаборатория 2: Разширена разработка на MCP сървър
      - Лаборатория 3: Интеграция с AI Toolkit
      - Лаборатория 4: Продукционно разгръщане и мащабиране
    - Обучение чрез лаборатории с инструкции стъпка по стъпка

## Допълнителни ресурси

Хранилището включва допълнителни ресурси:

- **Папка с изображения**: Съдържа диаграми и илюстрации, използвани в учебната програма
- **Преводи**: Поддръжка на множество езици с автоматизирани преводи на документацията
- **Официални MCP ресурси**:
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## Как да използвате това хранилище

1. **Последователно учене**: Следвайте главите в ред (от 00 до 10) за структурирано обучение.
2. **Фокус върху конкретен език**: Ако се интересувате от определен програмен език, разгледайте директориите със семпли за имплементации на предпочитания от вас език.
3. **Практическа имплементация**: Започнете с раздела "Първи стъпки", за да настроите средата си и да създадете първия MCP сървър и клиент.
4. **Разширено изследване**: След като усвоите основите, преминете към разширените теми, за да разширите знанията си.
5. **Ангажираност с общността**: Присъединете се към MCP общността чрез GitHub дискусии и Discord канали, за да се свържете с експерти и други разработчици.

## MCP клиенти и инструменти

Учебната програма обхваща различни MCP клиенти и инструменти:

1. **Официални клиенти**:
   - Visual Studio Code
   - MCP в Visual Studio Code
   - Claude Desktop
   - Claude в VSCode
   - Claude API

2. **Общностни клиенти**:
   - Cline (терминален клиент)
   - Cursor (редактор на код)
   - ChatMCP
   - Windsurf

3. **Инструменти за управление на MCP**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## Популярни MCP сървъри

Хранилището представя различни MCP сървъри, включително:

1. **Официални Microsoft MCP сървъри**:
   - Microsoft Learn Docs MCP Server
   - Azure MCP Server (над 15 специализирани конектора)
   - GitHub MCP Server
   - Azure DevOps MCP Server
   - MarkItDown MCP Server
   - SQL Server MCP Server
   - Playwright MCP Server
   - Dev Box MCP Server
   - Azure AI Foundry MCP Server
   - Microsoft 365 Agents Toolkit MCP Server

2. **Официални референтни сървъри**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

3. **Генериране на изображения**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

4. **Инструменти за разработка**:
   - Git MCP
   - Terminal Control
   - Code Assistant

5. **Специализирани сървъри**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## Принос

Това хранилище приветства приноси от общността. Вижте раздела Приноси от общността за насоки как да допринасяте ефективно за MCP екосистемата.

## Промени

| Дата | Промени |
|------|---------|
| 18 юли 2025 | - Актуализирана структура на хранилището с включено Ръководство за Microsoft MCP сървъри<br>- Добавен изчерпателен списък с 10 производствени Microsoft MCP сървъра<br>- Подсилен раздел Популярни MCP сървъри с официални Microsoft MCP сървъри<br>- Обновен раздел Казуси с реални файлови примери<br>- Добавени детайли за структурата на лабораториите в Практическия уъркшоп |
| 16 юли 2025 | - Актуализирана структура на хранилището, отразяваща текущото съдържание<br>- Добавен раздел MCP клиенти и инструменти<br>- Добавен раздел Популярни MCP сървъри<br>- Обновена визуална карта на учебната програма с всички текущи теми<br>- Подсилен раздел Разширени теми с всички специализирани области<br>- Обновени Казуси с реални примери<br>- Изяснен произход на MCP като създаден от Anthropic |
| 11 юни 2025 | - Първоначално създаване на учебното ръководство<br>- Добавена визуална карта на учебната програма<br>- Описана структура на хранилището<br>- Включени примерни проекти и допълнителни ресурси |

---

*Това учебно ръководство е актуализирано на 18 юли 2025 г. и предоставя преглед на хранилището към тази дата. Съдържанието на хранилището може да бъде обновявано след тази дата.*

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.