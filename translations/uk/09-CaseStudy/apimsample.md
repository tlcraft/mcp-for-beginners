<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:39:24+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "uk"
}
-->
# Кейс: Відкриття REST API в API Management як MCP сервер

Azure API Management — це сервіс, який надає шлюз поверх ваших API кінцевих точок. Як це працює: Azure API Management виступає як проксі перед вашими API і може вирішувати, що робити з вхідними запитами.

Використовуючи його, ви отримуєте цілий набір функцій, таких як:

- **Безпека** — можна використовувати все: від API ключів, JWT до керованої ідентичності.
- **Обмеження частоти запитів** — чудова функція, що дозволяє визначати, скільки викликів проходить за певний проміжок часу. Це допомагає забезпечити всім користувачам відмінний досвід і запобігає перевантаженню вашого сервісу.
- **Масштабування та балансування навантаження**. Ви можете налаштувати кілька кінцевих точок для розподілу навантаження і обрати спосіб балансування.
- **AI-функції, такі як семантичне кешування**, обмеження токенів, моніторинг токенів та інше. Ці функції покращують швидкодію та допомагають контролювати витрати токенів. [Детальніше тут](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Чому MCP + Azure API Management?

Model Context Protocol швидко стає стандартом для агентних AI-додатків і способів послідовного відкриття інструментів і даних. Azure API Management — природний вибір, коли потрібно "керувати" API. MCP сервери часто інтегруються з іншими API для обробки запитів до інструментів, наприклад. Тому поєднання Azure API Management і MCP має сенс.

## Огляд

У цьому конкретному випадку ми навчимося відкривати API кінцеві точки як MCP сервер. Це дозволить легко інтегрувати ці кінцеві точки в агентний додаток, одночасно використовуючи можливості Azure API Management.

## Основні функції

- Ви обираєте методи кінцевих точок, які хочете відкрити як інструменти.
- Додаткові функції залежать від того, що ви налаштуєте в розділі політик для вашого API. Тут ми покажемо, як додати обмеження частоти запитів.

## Попередній крок: імпорт API

Якщо у вас вже є API в Azure API Management — чудово, цей крок можна пропустити. Якщо ні, ознайомтеся з цим посиланням: [імпорт API в Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Відкриття API як MCP сервер

Щоб відкрити кінцеві точки API, виконайте наступні кроки:

1. Перейдіть до Azure Portal за адресою <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Перейдіть до вашого екземпляру API Management.

1. У лівому меню оберіть APIs > MCP Servers > + Create new MCP Server.

1. В API виберіть REST API, який хочете відкрити як MCP сервер.

1. Оберіть одну або кілька операцій API, які хочете відкрити як інструменти. Можна вибрати всі операції або лише конкретні.

    ![Вибір методів для відкриття](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Натисніть **Create**.

1. Перейдіть у меню **APIs** та **MCP Servers**, ви побачите таке:

    ![Перегляд MCP сервера у головній панелі](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP сервер створено, а операції API відкриті як інструменти. MCP сервер відображається у панелі MCP Servers. У стовпці URL показано кінцеву точку MCP сервера, яку можна викликати для тестування або у клієнтському додатку.

## Опціонально: налаштування політик

Azure API Management має основну концепцію політик, де ви задаєте різні правила для кінцевих точок, наприклад, обмеження частоти запитів або семантичне кешування. Ці політики описуються у форматі XML.

Ось як можна налаштувати політику для обмеження частоти запитів до MCP сервера:

1. У порталі, в розділі APIs, оберіть **MCP Servers**.

1. Виберіть створений MCP сервер.

1. У лівому меню, під MCP, оберіть **Policies**.

1. У редакторі політик додайте або відредагуйте політики, які хочете застосувати до інструментів MCP сервера. Політики визначаються у форматі XML. Наприклад, можна додати політику, що обмежує виклики інструментів MCP сервера (у цьому прикладі — 5 викликів за 30 секунд на IP клієнта). Ось XML, який реалізує це обмеження:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Ось зображення редактора політик:

    ![Редактор політик](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Спробуйте

Переконаємося, що наш MCP сервер працює як треба.

Для цього ми використаємо Visual Studio Code і GitHub Copilot в режимі агента. Ми додамо MCP сервер у файл *mcp.json*. Таким чином Visual Studio Code буде виступати клієнтом з агентними можливостями, а кінцеві користувачі зможуть вводити запити і взаємодіяти з сервером.

Ось як додати MCP сервер у Visual Studio Code:

1. Використайте команду MCP: **Add Server** з Command Palette.

1. Коли з’явиться запит, оберіть тип сервера: **HTTP (HTTP або Server Sent Events)**.

1. Введіть URL MCP сервера в API Management. Приклад: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (для SSE кінцевої точки) або **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (для MCP кінцевої точки), зверніть увагу, що різниця в транспорті — `/sse` або `/mcp`.

1. Введіть ідентифікатор сервера на свій розсуд. Це не критичне значення, але допоможе вам запам’ятати, що це за сервер.

1. Оберіть, чи зберігати конфігурацію у налаштуваннях робочої області або користувача.

  - **Workspace settings** — конфігурація сервера зберігається у файлі .vscode/mcp.json, доступному лише в поточній робочій області.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    або, якщо обрати стрімінговий HTTP як транспорт, конфігурація буде трохи іншою:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User settings** — конфігурація додається у глобальний файл *settings.json* і доступна у всіх робочих областях. Конфігурація виглядає приблизно так:

    ![Налаштування користувача](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Також потрібно додати конфігурацію заголовка для коректної аутентифікації в Azure API Management. Використовується заголовок **Ocp-Apim-Subscription-Key**.

    - Ось як додати його у налаштування:

    ![Додавання заголовка для аутентифікації](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), це викличе запит на введення значення API ключа, який можна знайти в Azure Portal для вашого екземпляру Azure API Management.

   - Щоб додати його у *mcp.json*, можна зробити так:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Використання режиму агента

Тепер ми все налаштували — у налаштуваннях або у *.vscode/mcp.json*. Спробуємо.

Повинна з’явитися іконка Інструментів, де будуть перераховані відкриті інструменти вашого сервера:

![Інструменти сервера](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Натисніть на іконку інструментів, і ви побачите список інструментів:

    ![Інструменти](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Введіть запит у чат, щоб викликати інструмент. Наприклад, якщо ви обрали інструмент для отримання інформації про замовлення, можна запитати агента про замовлення. Ось приклад запиту:

    ```text
    get information from order 2
    ```

    Вам буде запропоновано натиснути іконку інструментів для підтвердження виклику інструменту. Оберіть продовжити, і ви побачите результат, схожий на цей:

    ![Результат запиту](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **те, що ви бачите, залежить від налаштованих інструментів, але ідея в тому, що ви отримуєте текстову відповідь, як показано вище**


## Посилання

Ось де можна дізнатися більше:

- [Покрокове керівництво по Azure API Management і MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Приклад на Python: Захищені віддалені MCP сервери з Azure API Management (експериментальний)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Лабораторія авторизації MCP клієнта](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Використання розширення Azure API Management для VS Code для імпорту та керування API](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Реєстрація та пошук віддалених MCP серверів в Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Відмінний репозиторій, що демонструє багато AI можливостей з Azure API Management
- [Майстер-класи AI Gateway](https://azure-samples.github.io/AI-Gateway/) Містить майстер-класи з використання Azure Portal — чудовий спосіб почати оцінювати AI можливості.

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.